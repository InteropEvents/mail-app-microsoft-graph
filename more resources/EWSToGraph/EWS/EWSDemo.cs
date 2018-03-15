using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using ExchangeAuthentication;
using Microsoft.Exchange.WebServices.Data;

namespace EWS
{
    public partial class FormEWSDemo : Form
    {
        static ExchangeService service;

        public FormEWSDemo()
        {
            InitializeComponent();
            this.txtUserName.Text = ConfigurationManager.AppSettings.Get("defaultUserName");
            this.txtPwd.Text = ConfigurationManager.AppSettings.Get("defaultPassword");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            initialMailListView();
            this.treeViewFolder.Nodes.Clear();
            this.listViewMail.Items.Clear();
            initialMeetingList();
            this.listViewMeeting.Items.Clear();
            this.listViewReminder.Items.Clear();
            this.listViewCalendar.Items.Clear();
            this.listViewCalendarMeeting.Items.Clear();

            UserDataFromConsole.UserData = new UserDataFromConsole();
            UserDataFromConsole.UserData.EmailAddress = this.txtUserName.Text;
            UserDataFromConsole.UserData.Password = this.txtPwd.Text;
            string defaultAutodiscoverUrl = ConfigurationManager.AppSettings.Get("defaultAutodiscoverUrl");
            if (!string.IsNullOrEmpty(defaultAutodiscoverUrl))
            {
                UserDataFromConsole.UserData.AutodiscoverUrl = new Uri(defaultAutodiscoverUrl);
            }

            try
            {
                service = Service.ConnectToService(UserDataFromConsole.UserData, new TraceListener());
                this.txtLog.Text = "Login Success\r\nEWS API: AutodiscoverUrl\r\nLocation: ..\\EWS\\Authentication\\Service.cs(61)\r\n\r\n";

                Folder inboxFolder = Folder.Bind(service, WellKnownFolderName.Inbox);
                TreeNode treeNode = this.treeViewFolder.Nodes.Add(inboxFolder.Id.UniqueId, inboxFolder.DisplayName);
                this.treeViewFolder.SelectedNode = treeNode;
                getMails(null, null);
                this.tabControlMenu.Enabled = true;
                this.tabControlMenu.SelectedTab = this.tabPageMail;
            }
            catch (Exception ex)
            {
                this.tabControlMenu.SelectedTab = this.tabPageMail;
                this.tabControlMenu.Enabled = false;
                MessageBox.Show("Login failed, check your user name and password");
            }
        }

        public Folder GetFolder(string displayName)
        {
            FolderView folderView = new FolderView(int.MaxValue) { Traversal = FolderTraversal.Shallow };

            if (displayName == "Inbox")
            {
                this.txtLog.Text += "EWS API: Folder.Bind\r\nLocation:..\\EWS\\EWS\\Form1.cs(60)\r\n\r\n";
                return Folder.Bind(service, WellKnownFolderName.Inbox);
            }
            else
            {
                SearchFilter.ContainsSubstring filter = new SearchFilter.ContainsSubstring(FolderSchema.DisplayName,
    displayName, ContainmentMode.FullString, ComparisonMode.IgnoreCase);
                FindFoldersResults findFoldersResults = service.FindFolders(WellKnownFolderName.Inbox, filter, new FolderView(int.MaxValue) { Traversal = FolderTraversal.Deep });
                this.txtLog.Text += "EWS API: FindFolders\r\nLocation:..\\EWS\\EWS\\Form1.cs(64)\r\n\r\n";
                if (findFoldersResults.Count() > 0)
                {
                    return findFoldersResults.First();
                }
                else
                {
                    return null;
                }
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            Collection<Person> person = service.GetPeopleInsights(new List<string> { this.txtUserName.Text });
            this.txtLog.Text = "displayName: " + person[0].DisplayName + "\r\n";
            this.txtLog.Text += "mobilePhone: " + person[0].PhoneNumber + "\r\n";
            this.txtLog.Text += "officeLocation: " + person[0].Office + "\r\n";
            this.txtLog.Text += "mail: " + person[0].EmailAddress + "\r\n";
            this.txtLog.Text += "department: " + person[0].Department + "\r\n\r\n";
            this.txtLog.Text += "Get profile success\r\nEWS API: GetPeopleInsights\r\nLocation:..\\EWS\\EWS\\Form1.cs(81)\r\n\r\n";
        }

        private void btnGetMails_Click(object sender, EventArgs e)
        {
            initialMailListView();
            getMails(null, null);
        }

        public void getMails(string folderName, string keyword)
        {
            SearchFilter sf = null;
            FindItemsResults<Item> findResults = null;
            if (!string.IsNullOrEmpty(keyword))
            {
                sf = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.ContainsSubstring(ItemSchema.Subject, keyword, ContainmentMode.Substring, ComparisonMode.IgnoreCase));
            }

            if (string.IsNullOrEmpty(folderName))
            {
                if (sf != null)
                {
                    sf = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.ContainsSubstring(ItemSchema.Subject, keyword, ContainmentMode.Substring, ComparisonMode.IgnoreCase));
                    findResults = service.FindItems(WellKnownFolderName.Inbox, sf, new ItemView(10));
                }
                else
                {
                    findResults = service.FindItems(WellKnownFolderName.Inbox, new ItemView(10));
                }
            }
            else
            {
                if (treeViewFolder.SelectedNode == null)
                {
                    MessageBox.Show("Select a folder under Inbox firstly.");
                    return;
                }
                else
                {
                    FolderId folderId = new FolderId(folderName);
                    if (sf != null)
                    {
                        sf = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.ContainsSubstring(ItemSchema.Subject, keyword, ContainmentMode.Substring, ComparisonMode.IgnoreCase));
                        findResults = service.FindItems(folderId, sf, new ItemView(10));
                    }
                    else
                    {
                        findResults = service.FindItems(folderId, new ItemView(10));
                    }
                }
            }

            this.listViewMail.View = View.Details;
            this.listViewMail.Items.Clear();

            foreach (Item item in findResults.Items)
            {
                EmailMessage em = item as EmailMessage;
                var listViewItem = new ListViewItem(new[] { em.Sender.Name, em.DisplayTo, item.Subject, item.DateTimeReceived.ToString(), em.Id.UniqueId, em.IsRead ? "Read" : "UnRead" });

                this.listViewMail.Items.Add(listViewItem);
            }

            this.txtLog.Text += "Get mail list success\r\nEWS API:FindItems\r\nLocation:..\\EWS\\EWS\\Form1.cs line(112, 116, 132, 136)\r\n\r\n";
        }

        private void btnCreateFolder_Click(object sender, EventArgs e)
        {
            initialMailListView();
            Folder newCreatedFolder = GetFolder(CreatedFolder());
            TreeNode treeNode = treeViewFolder.Nodes[0].Nodes.Add(newCreatedFolder.Id.UniqueId, newCreatedFolder.DisplayName);
            treeViewFolder.SelectedNode = treeNode;
            treeViewFolder.ExpandAll();
        }

        public string CreatedFolder()
        {
            Folder folder = new Folder(service);
            folder.DisplayName = "Custom Folder" + DateTime.Now.ToString();
            folder.FolderClass = "IPF.Note";

            // Save the folder as a child folder of the Inbox.
            folder.Save(WellKnownFolderName.Inbox);
            this.txtLog.Text += "Create folder success\r\nEWS API: Save\r\nLocation:..\\EWS\\EWS\\Form1.cs(171)\r\n\r\n";
            return folder.DisplayName;
        }

        private void btnDeleteFolder_Click(object sender, EventArgs e)
        {
            initialMailListView();
            if (this.treeViewFolder.SelectedNode == null)
            {
                MessageBox.Show("Select a folder under Inbox firstly");
                return;
            }

            Folder folder = Folder.Bind(service, new FolderId(this.treeViewFolder.SelectedNode.Name));
            if (this.treeViewFolder.SelectedNode != this.treeViewFolder.Nodes[0])
            {
                folder.Delete(DeleteMode.MoveToDeletedItems);
                this.txtLog.Text += "Delete folder success\r\nEWS API: Delete\r\nLocation:..\\EWS\\EWS\\Form1.cs(187)\r\n\r\n";
            }
            else
            {
                MessageBox.Show("Select a folder under Inbox firstly.");
                return;
            }

            if (GetFolder(folder.DisplayName) == null)
            {
                this.treeViewFolder.Nodes[0].Nodes[folder.Id.UniqueId].Remove();
                getMails(null, null);
            }
        }

        private void btnCreateMail_Click(object sender, EventArgs e)
        {
            initialCreateMailView();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            EmailMessage message = new EmailMessage(service);
            if (string.IsNullOrWhiteSpace(this.txtSubject.Text))
            {
                DialogResult dr = MessageBox.Show("Do you want to send this message without a subject", "Warning", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No)
                {
                    return;
                }
            }

            // Set properties on the email message.
            string[] toList = this.txtTo.Text.Split(';');
            foreach (var to in toList)
            {
                message.ToRecipients.Add(to);
            }

            message.Subject = this.txtSubject.Text;
            message.Body = this.richTxtBody.Text;
            message.Attachments.AddFileAttachment(this.lblAttachedFile.Tag.ToString());

            // Save the email message to the Drafts folder (where it can be retrieved, updated, and sent at a later time).
            // This method call results in a CreateItem call to EWS.
            message.Send();
            this.btnGetMails_Click(sender, e);
            this.txtLog.Text = "Send mail success\r\nEWS API: Send\r\nLocation:..\\EWS\\EWS\\Form1.cs(247)\r\n\r\n" + this.txtLog.Text;
        }

        private void btnDeleteMail_Click(object sender, EventArgs e)
        {
            if (this.listViewMail.Visible && this.listViewMail.SelectedItems.Count > 0)
            {
                List<ItemId> deletedMailId = new List<ItemId>();
                foreach (ListViewItem id in this.listViewMail.SelectedItems)
                {
                    ItemId itemId = new ItemId(id.SubItems[4].Text);
                    deletedMailId.Add(itemId);
                }

                if (deletedMailId.Count > 0)
                {
                    ServiceResponseCollection<ServiceResponse> response = service.DeleteItems(deletedMailId, DeleteMode.MoveToDeletedItems, SendCancellationsMode.SendOnlyToAll, AffectedTaskOccurrence.SpecifiedOccurrenceOnly);
                    this.txtLog.Text = "Delete mail success\r\nEWS API: DeleteItems\r\nLocation:..\\EWS\\EWS\\Form1.cs(274)\r\n\r\n";
                    getMails(null, null);
                }
            }
            else
            {
                MessageBox.Show("Select a mail firstly");
                initialMailListView();
                return;
            }
        }

        private void listview_maillist_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                e.NewWidth = 0;
                e.Cancel = true;
            }
        }
        private void btnViewMail_Click(object sender, EventArgs e)
        {
            if (this.listViewMail.Visible && this.listViewMail.SelectedItems.Count > 0)
            {
                initialViewMailView();
                ItemId itemId = new ItemId(this.listViewMail.SelectedItems[0].SubItems[4].Text);
                EmailMessage em = EmailMessage.Bind(service, itemId);
                this.txtLog.Text = "View mail success\r\nEWS API: EmailMessage.Bind\r\nLocation:..\\EWS\\EWS\\Form1.cs(299)\r\n\r\n";

                this.txtFrom.Text = em.From.Address;
                this.txtTo.Text = GetToString(em.ToRecipients);
                this.txtSubject.Text = em.Subject;
                this.webBrowserBody.DocumentText = em.Body;

                if (em.HasAttachments)
                {
                    this.lblAttachedFile.Text = "Attached: ";
                    foreach (var item in em.Attachments)
                    {
                        this.lblAttachedFile.Text += item.Name;
                    }
                }

                em.IsRead = true;
                em.Update(ConflictResolutionMode.AutoResolve);
                this.txtLog.Text += "Mark as read success\r\nEWS API: Update\r\nLocation:..\\EWS\\EWS\\Form1.cs(316)\r\n\r\n";
            }
            else
            {
                MessageBox.Show("Select a mail firstly");
                initialMailListView();
                return;
            }
        }

        private string GetToString(EmailAddressCollection addressList)
        {
            string to = string.Empty;

            foreach (var address in addressList)
            {
                to += address.Address + ";";
            }

            if (addressList.Count > 0)
            {
                to = to.Remove(to.LastIndexOf(";"), 1);
            }

            return to;
        }


        private void btnMarkRead_Click(object sender, EventArgs e)
        {
            if (this.listViewMail.Visible && this.listViewMail.SelectedItems.Count > 0)
            {
                ItemId itemId = new ItemId(this.listViewMail.SelectedItems[0].SubItems[4].Text);
                EmailMessage em = EmailMessage.Bind(service, itemId);
                this.txtLog.Text = "Get single mail success\r\nEWS API: EmailMessage.Bind\r\nLocation:..\\EWS\\EWS\\Form1.cs(331)\r\n\r\n";
                em.IsRead = true;
                em.Update(ConflictResolutionMode.AutoResolve);
                this.txtLog.Text += "Mark as read success\r\nEWS API: Update\r\nLocation:..\\EWS\\EWS\\Form1.cs(334)\r\n\r\n";
                getMails(null, null);
            }
            else
            {
                MessageBox.Show("Select a mail firstly");
                initialMailListView();
                return;
            }
        }

        private void btnFindMail_Click(object sender, EventArgs e)
        {
            initialMailListView();
            getMails(null, this.txtKeyWord.Text);
        }

        private void btnMoveToFolder_Click(object sender, EventArgs e)
        {
            if (this.treeViewFolder.SelectedNode == null)
            {
                MessageBox.Show("Select a folder under Inbox firstly.");
                return;
            }

            if (this.listViewMail.Visible && this.listViewMail.SelectedItems.Count > 0)
            {
                ItemId itemId = new ItemId(this.listViewMail.SelectedItems[0].SubItems[4].Text);
                EmailMessage em = EmailMessage.Bind(service, itemId);

                if (this.treeViewFolder.SelectedNode.Name == em.ParentFolderId.UniqueId)
                {
                    MessageBox.Show("This folder is the same folder of mail, select another folder.");
                    return;
                }
                else
                {
                    em.Move(new FolderId(this.treeViewFolder.SelectedNode.Name));
                    this.txtLog.Text += "Move mail into folder success\r\nEWS API: Move\r\nLocation:..\\EWS\\EWS\\Form1.cs(379)\r\n\r\n";
                    getMails(this.treeViewFolder.SelectedNode.Name, null);
                }
            }
            else
            {
                MessageBox.Show("Select a mail firstly");
                initialMailListView();
                return;
            }
        }

        private void btnCopyToFolder_Click(object sender, EventArgs e)
        {
            initialMailListView();
            if (this.treeViewFolder.SelectedNode == null)
            {
                MessageBox.Show("Select a folder under Inbox firstly.");
                return;
            }

            if (this.listViewMail.Visible && this.listViewMail.SelectedItems.Count > 0)
            {
                ItemId itemId = new ItemId(this.listViewMail.SelectedItems[0].SubItems[4].Text);
                EmailMessage em = EmailMessage.Bind(service, itemId);

                if (this.treeViewFolder.SelectedNode.Name == em.ParentFolderId.UniqueId)
                {
                    MessageBox.Show("This folder is the same folder of mail, select another folder.");
                    return;
                }
                else
                {
                    em.Copy(new FolderId(this.treeViewFolder.SelectedNode.Name));
                    this.txtLog.Text += "Copy mail into folder success\r\nEWS API: Copy\r\nLocation:..\\EWS\\EWS\\Form1.cs(415)\r\n\r\n";
                    getMails(this.treeViewFolder.SelectedNode.Name, null);
                }
            }
            else
            {
                MessageBox.Show("Select a mail firstly");
                initialMailListView();
                return;
            }
        }

        private void treeView_folder_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.listViewMail.Visible = true;
            this.groupBoxMail.Visible = false;
            this.txtLog.Text = string.Empty;
            getMails(e.Node.Name, null);
        }

        private void initialMailListView()
        {
            this.listViewMail.Visible = true;
            this.groupBoxMail.Visible = false;
            this.txtLog.Text = string.Empty;
        }

        private void initialCreateMailView()
        {
            this.listViewMail.Visible = false;
            this.listViewMail.SelectedItems.Clear();
            this.groupBoxMail.Visible = true;
            this.webBrowserBody.Visible = false;
            this.richTxtBody.Visible = true;
            this.btnSend.Enabled = true;
            this.txtFrom.Enabled = false;
            this.txtLog.Text = string.Empty;

            this.txtFrom.Text = string.Empty;
            this.txtTo.Text = ConfigurationManager.AppSettings.Get("defaultUserName");
            this.richTxtBody.Text = string.Empty;

            string fileName = Path.GetTempPath() + DateTime.Now.ToString("yyyyMMddhhmmss") + "Test.txt";
            if (!File.Exists(fileName))
            {
                File.WriteAllText(fileName, fileName);
            }

            this.lblAttachedFile.Tag = fileName;
            this.lblAttachedFile.Text = "Attached: " + Path.GetFileName(fileName);
        }

        private void initialViewMailView()
        {
            this.listViewMail.Visible = false;
            this.groupBoxMail.Visible = true;
            this.webBrowserBody.Visible = true;
            this.richTxtBody.Visible = false;
            this.btnSend.Enabled = false;
            this.txtFrom.Enabled = false;
            this.txtLog.Text = string.Empty;
        }

        private void txtKeyWord_Enter(object sender, EventArgs e)
        {
            this.txtKeyWord.Text = string.Empty;
        }

        private void btnGetMeetingList_Click(object sender, EventArgs e)
        {
            initialMeetingList();
            CalendarFolder calendar = CalendarFolder.Bind(service, WellKnownFolderName.Calendar);
            CalendarView cView = new CalendarView(DateTime.Now.AddMonths(-6), DateTime.Now.AddYears(1), int.MaxValue);

            FindItemsResults<Appointment> appointments = calendar.FindAppointments(cView);
            var items = appointments.Items.OrderByDescending(x => x.DateTimeReceived);
            this.listViewMeeting.View = View.Details;
            this.listViewMeeting.Items.Clear();
            foreach (Appointment item in items)
            {
                var listViewItem = new ListViewItem(new[] { item.Id.UniqueId, item.Organizer.Name, item.DisplayTo, item.Subject, item.DateTimeReceived.ToString(), item.MyResponseType.ToString() });
                this.listViewMeeting.Items.Add(listViewItem);
            }

            GetReminders();
            this.txtLogForMeeting.Text = "Get meeting list success\r\nEWS API:CalendarFolder.Bind\r\nLocation:..\\EWS\\EWS\\Form1.cs line(112, 116, 132, 136)\r\n" +
                "EWS API:FindAppointments\r\nLocation:..\\EWS\\EWS\\Form1.cs line(112, 116, 132, 136)\r\n\r\n";
        }

        private void GetReminders()
        {
            this.listViewReminder.View = View.Details;
            this.listViewReminder.Items.Clear();

            /// This is the XML request that is sent to the Exchange server.
            string getRemindersSOAPRequest = string.Format(@"<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
               xmlns:m=""http://schemas.microsoft.com/exchange/services/2006/messages"" 
               xmlns:t=""http://schemas.microsoft.com/exchange/services/2006/types"" 
               xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
  <soap:Header>
    <t:RequestServerVersion Version=""Exchange2016"" />
  </soap:Header>
  <soap:Body>
    <m:GetReminders>
      <m:BeginTime>{0}</m:BeginTime>
      <m:ReminderType>All</m:ReminderType>
    </m:GetReminders>
  </soap:Body>
</soap:Envelope>", DateTime.UtcNow.AddYears(-1).ToString("yyyy-MM-ddThh:mm:ssZ"));

            try
            {
                XElement responseEnvelope = processRequest(getRemindersSOAPRequest);

                // Process the response.
                IEnumerable<XElement> reminders = from reminderElement in responseEnvelope.Descendants(XName.Get("Reminder", "http://schemas.microsoft.com/exchange/services/2006/types"))
                                                  select reminderElement;

                foreach (var reminder in reminders)
                {
                    List<XNode> nodes = reminder.Nodes().ToList();
                    var reminderTime = Convert.ToDateTime((nodes[2] as XElement).Value).ToLocalTime();
                    if (DateTime.Now.CompareTo(reminderTime) >= 0)
                    {
                        var subject = (nodes[0] as XElement).Value;
                        var location = (nodes[1] as XElement).Value;
                        var startDate = (nodes[3] as XElement).Value;
                        var endDate = (nodes[4] as XElement).Value;
                        var itemId = (nodes[5] as XElement).Attribute(XName.Get("Id")).Value;
                        var changeKey = (nodes[5] as XElement).Attribute(XName.Get("ChangeKey")).Value;
                        var listViewItem = new ListViewItem(new[] { itemId, changeKey, subject, location, reminderTime.ToString(), Convert.ToDateTime(startDate).ToLocalTime().ToString(), Convert.ToDateTime(endDate).ToLocalTime().ToString() });//, item.Start.ToString(), ts.ToString() + (ts.TotalMinutes < 0 ? string.Empty : " overdue") });
                        this.listViewReminder.Items.Add(listViewItem);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Get reminders list failed, exception details: " + ex.Message);
            }
        }

        private void btnDismiss_Click(object sender, EventArgs e)
        {
            initialMeetingList();
            if (this.listViewReminder.SelectedItems.Count > 0)
            {
                ListViewItem listViewItem = this.listViewReminder.SelectedItems[0];
                PerformReminderAction("Dismiss", listViewItem.SubItems[0].Text, listViewItem.SubItems[1].Text, DateTime.UtcNow.AddMinutes(1));
                GetReminders();
            }
            else
            {
                MessageBox.Show("Select a reminder firstly.");
                return;
            }
        }

        private void btnSnooze_Click(object sender, EventArgs e)
        {
            initialMeetingList();
            if (this.listViewReminder.SelectedItems.Count > 0)
            {
                ListViewItem listViewItem = this.listViewReminder.SelectedItems[0];
                PerformReminderAction("Snooze", listViewItem.SubItems[0].Text, listViewItem.SubItems[1].Text, DateTime.UtcNow.AddMinutes(1));
                GetReminders();
            }
            else
            {
                MessageBox.Show("Select a reminder firstly");
                return;
            }
        }

        private void PerformReminderAction(string actionType, string itemId, string changeKey, DateTime datetime)
        {
            string soapRequest = string.Format(@"<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
               xmlns:m=""http://schemas.microsoft.com/exchange/services/2006/messages""
               xmlns:t=""http://schemas.microsoft.com/exchange/services/2006/types""
               xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
  <soap:Header>
    <t:RequestServerVersion Version=""Exchange2016"" />
  </soap:Header>
  <soap:Body>
    <m:PerformReminderAction>
      <m:ReminderItemActions>
        <t:ReminderItemAction>
          <t:ActionType>{0}</t:ActionType>
          <t:ItemId Id=""{1}""
           ChangeKey=""{2}""/>
          <t:NewReminderTime>{3}</t:NewReminderTime>
        </t:ReminderItemAction>
      </m:ReminderItemActions>
    </m:PerformReminderAction>
  </soap:Body>
</soap:Envelope>", actionType, itemId, changeKey, datetime.ToString("yyyy-MM-ddThh:mm:ssZ"));

            try
            {
                XElement responseEnvelope = processRequest(soapRequest);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0} reminder failed, exception details: {1}", actionType, ex.Message));
            }
        }

        private XElement processRequest(string soapRequest)
        {
            var request = WebRequest.CreateHttp(service.Url);
            request.AllowAutoRedirect = false;
            request.Credentials = new NetworkCredential(this.txtUserName.Text, this.txtPwd.Text);
            request.Method = "POST";
            request.ContentType = "text/xml";
            var requestWriter = new StreamWriter(request.GetRequestStream());
            requestWriter.Write(soapRequest);
            requestWriter.Close();

            try
            {
                var response = (HttpWebResponse)(request.GetResponse());
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseStream = response.GetResponseStream();
                    XElement responseEnvelope = XElement.Load(responseStream);

                    if (responseEnvelope != null)
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        XmlWriterSettings settings = new XmlWriterSettings();
                        settings.Indent = true;
                        XmlWriter writer = XmlWriter.Create(stringBuilder, settings);
                        responseEnvelope.Save(writer);
                        writer.Close();
                        return responseEnvelope;
                    }

                    IEnumerable<XElement> errorCodes = from errorCode in responseEnvelope.Descendants
                                               ("{http://schemas.microsoft.com/exchange/services/2006/messages}ResponseCode")
                                                       select errorCode;
                    foreach (var errorCode in errorCodes)
                    {
                        if (errorCode.Value != "NoError")
                        {
                            switch (errorCode.Parent.Name.LocalName.ToString())
                            {
                                case "Response":
                                    string responseError = "Response-level error getting inbox information:\n" + errorCode.Value;
                                    throw new ApplicationException(responseError);

                                case "UserResponse":
                                    string userError = "User-level error getting inbox information:\n" + errorCode.Value;
                                    throw new ApplicationException(userError);
                            }
                        }
                    }

                }
            }
            catch
            {
                throw;
            }

            return null;
        }

        private void btnCreateMeeting_Click(object sender, EventArgs e)
        {
            initialCreateMeetingView(null, null, null);
            this.webBrowserMeetingBody.Visible = false;
            this.richTextBoxMeetingBody.Visible = true;
        }

        private void initialMeetingList()
        {
            this.groupBoxMeetingList.Visible = true;
            this.groupBoxMeetingView.Visible = false;
        }

        private void initialMeetingView()
        {
            this.groupBoxMeetingList.Visible = false;
            this.groupBoxMeetingView.Visible = true;
            this.webBrowserMeetingBody.Visible = true;
            this.richTextBoxMeetingBody.Visible = false;
            this.btnSendMeeting.Enabled = false;
            this.txtMeetingFrom.Enabled = false;
        }

        private void initialCreateMeetingView(string to, string subject, string location)
        {
            this.groupBoxMeetingList.Visible = false;
            this.groupBoxMeetingView.Visible = true;
            this.btnSendMeeting.Enabled = true;
            this.txtMeetingFrom.Enabled = false;
            this.txtMeetingFrom.Text = string.Empty;

            DateTime now = DateTime.Now;
            this.txtMeetingTo.Text = to ?? this.txtUserName.Text;
            this.txtMeetingSubject.Text = subject ?? "Meeting Subject " + now.ToString();
            this.txtMeetingLocation.Text = location ?? "Location test room 123";
            this.txtMeetingStart.Text = now.ToString();
            this.txtMeetingEnd.Text = now.AddHours(1).ToString();
            this.richTextBoxMeetingBody.Text = "Meeting Body is created at " + now.ToString();
            this.btnSendMeeting.Text = "Send";
        }

        private void btnViewMeeting_Click(object sender, EventArgs e)
        {
            Appointment appointment = getOneMeeting();
            if (appointment == null)
            {
                return;
            }

            initialMeetingView();
            this.txtMeetingFrom.Text = appointment.Organizer.Name;
            this.txtMeetingTo.Text = appointment.DisplayTo;
            this.txtMeetingSubject.Text = appointment.Subject;
            this.txtMeetingLocation.Text = appointment.Location;
            this.txtMeetingStart.Text = appointment.Start.ToLocalTime().ToString();
            this.txtMeetingEnd.Text = appointment.End.ToLocalTime().ToString();
            this.webBrowserMeetingBody.DocumentText = appointment.Body;
        }

        private Appointment getOneMeeting()
        {
            if (this.listViewMeeting.SelectedItems.Count > 0)
            {
                ListViewItem listViewItem = this.listViewMeeting.SelectedItems[0];
                ItemId itemId = new ItemId(listViewItem.SubItems[0].Text);
                Appointment appointment = Appointment.Bind(service, itemId);
                return appointment;
            }
            else
            {
                MessageBox.Show("Select a mail firstly");
                return null;
            }
        }

        private void btnSendMeeting_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtMeetingSubject.Text))
            {
                DialogResult dr = MessageBox.Show("Do you want to send this message without a subject", "Warning", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No)
                {
                    return;
                }
            }

            Appointment appointment = null;
            if (this.btnSendMeeting.Text == "Send")
            {
                appointment = new Appointment(service);
                appointment.Body = this.richTextBoxMeetingBody.Text;
            }
            else
            {
                ItemId itemId = new ItemId(this.listViewMeeting.SelectedItems[0].SubItems[0].Text);
                appointment = Appointment.Bind(service, itemId);
                appointment.Body.Text = this.webBrowserMeetingBody.DocumentText;
            }

            appointment.RequiredAttendees.Clear();
            string[] toList = this.txtMeetingTo.Text.Split(';');
            foreach (var to in toList)
            {
                appointment.RequiredAttendees.Add(to);
            }

            appointment.Subject = this.txtMeetingSubject.Text;
            appointment.Start = Convert.ToDateTime(this.txtMeetingStart.Text);
            appointment.End = Convert.ToDateTime(this.txtMeetingEnd.Text);
            appointment.Location = this.txtMeetingLocation.Text;

            if (this.btnSendMeeting.Text == "Send")
            {
                appointment.Save(SendInvitationsMode.SendToAllAndSaveCopy);
                this.txtLog.Text = "Send meeting success\r\nEWS API: Send\r\nLocation:..\\EWS\\EWS\\Form1.cs(247)\r\n\r\n" + this.txtLog.Text;
            }
            else
            {
                appointment.Update(ConflictResolutionMode.AutoResolve, SendInvitationsOrCancellationsMode.SendToAllAndSaveCopy);
            }

            this.btnGetMeetingList_Click(sender, e);
        }

        private void btnUpdateMeeting_Click(object sender, EventArgs e)
        {
            Appointment appointment = getOneMeeting();
            if (appointment == null)
            {
                return;
            }

            if (appointment.MyResponseType != MeetingResponseType.Organizer)
            {
                MessageBox.Show("Select a meeting which you are organizer.");
                return;
            }

            string to = string.Empty;

            foreach (var address in appointment.RequiredAttendees)
            {
                to += address.Address + ";";
            }

            to = to.Remove(to.LastIndexOf(";"), 1);
            initialCreateMeetingView(to, appointment.Subject, appointment.Location);
            this.btnSendMeeting.Text = "Send Update";
            appointment.Body += "<br/>Message is updated at " + DateTime.Now.ToString();
            appointment.Body += "<br/>Original start date is at " + appointment.Start.ToLocalTime().ToString();
            appointment.Body += "<br/>Originial end date is at " + appointment.End.ToLocalTime().ToString();
            this.webBrowserMeetingBody.DocumentText = appointment.Body;
            this.richTextBoxMeetingBody.Visible = false;
            this.webBrowserMeetingBody.Visible = true;
        }

        private void btnDeleteMeeting_Click(object sender, EventArgs e)
        {
            initialMeetingList();
            List<ItemId> deletedMeetingId = new List<ItemId>();
            if (this.listViewMeeting.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a mail firstly");
                return;
            }

            foreach (ListViewItem id in this.listViewMeeting.SelectedItems)
            {
                ItemId itemId = new ItemId(id.SubItems[0].Text);
                deletedMeetingId.Add(itemId);
            }

            if (deletedMeetingId.Count > 0)
            {
                ServiceResponseCollection<ServiceResponse> response = service.DeleteItems(deletedMeetingId, DeleteMode.MoveToDeletedItems, SendCancellationsMode.SendOnlyToAll, AffectedTaskOccurrence.SpecifiedOccurrenceOnly);
                this.txtLog.Text = "Delete meeting success\r\nEWS API: DeleteItems\r\nLocation:..\\EWS\\EWS\\Form1.cs(274)\r\n\r\n";
                this.btnGetMeetingList_Click(sender, e);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            AcceptTentativeDecline(MeetingResponseType.Accept, sender, e);
        }

        private void btnTentative_Click(object sender, EventArgs e)
        {
            AcceptTentativeDecline(MeetingResponseType.Tentative, sender, e);
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            AcceptTentativeDecline(MeetingResponseType.Decline, sender, e);
        }

        private void AcceptTentativeDecline(MeetingResponseType type, object sender, EventArgs e)
        {
            Appointment appointment = getOneMeeting();
            if (appointment == null)
            {
                return;
            }

            if (appointment.MyResponseType == MeetingResponseType.Organizer)
            {
                MessageBox.Show("Select a meeting which you are not organizer.");
                return;
            }

            switch (type)
            {
                case MeetingResponseType.Accept:
                    appointment.Accept(false);
                    break;
                case MeetingResponseType.Tentative:
                    appointment.AcceptTentatively(false);
                    break;
                case MeetingResponseType.Decline:
                    appointment.Decline(false);
                    break;
            }

            this.btnGetMeetingList_Click(sender, e);
        }

        private void btnGetCalendarList_Click(object sender, EventArgs e)
        {
            Folder root = Folder.Bind(service, WellKnownFolderName.Root);
            SearchFilter.ContainsSubstring filter = new SearchFilter.ContainsSubstring(FolderSchema.FolderClass,
    "IPF.Appointment", ContainmentMode.Substring, ComparisonMode.IgnoreCase);
            FindFoldersResults findFoldersResults = root.FindFolders(filter, new FolderView(int.MaxValue) { Traversal = FolderTraversal.Deep });
            this.listViewCalendar.View = View.Details;
            this.listViewCalendar.Items.Clear();
            foreach (var item in findFoldersResults)
            {
                var listViewItem = new ListViewItem(new[] { item.Id.UniqueId, item.DisplayName });
                this.listViewCalendar.Items.Add(listViewItem);
            }

            this.listViewCalendar.Items[0].Selected = true;
            initialListViewCalendarMeeting(this.listViewCalendar.Items[0].Text);
        }

        private void btnDeleteCalendar_Click(object sender, EventArgs e)
        {
            if (this.listViewCalendar.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select calendar firstly.");
                return;
            }

            ListViewItem item = this.listViewCalendar.SelectedItems[0];
            FolderId folderId = new FolderId(item.SubItems[0].Text);
            if (item.SubItems[1].Text == "Calendar")
            {
                MessageBox.Show("Calendar can't be deleted.");
                return;
            }

            Folder folder = Folder.Bind(service, folderId);
            folder.Delete(DeleteMode.HardDelete);
            this.btnGetCalendarList_Click(sender, e);
        }

        private void btnCreateCalendar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtCalendarName.Text))
            {
                MessageBox.Show("Input calendar name firstly.");
                return;
            }

            CalendarFolder folder = new CalendarFolder(service);
            folder.DisplayName = this.txtCalendarName.Text;
            folder.Save(WellKnownFolderName.Calendar);
            this.btnGetCalendarList_Click(sender, e);
        }

        private void btnUpdateCalendar_Click(object sender, EventArgs e)
        {
            if (this.listViewCalendar.SelectedItems.Count > 0)
            {
                ListViewItem listViewItem = this.listViewCalendar.SelectedItems[0];
                if (listViewItem.SubItems[1].Text == "Calendar")
                {
                    MessageBox.Show("Calendar can't be deleted.");
                    return;
                }

                FolderId folderId = new FolderId(listViewItem.SubItems[0].Text);
                if (string.IsNullOrWhiteSpace(this.txtCalendarName.Text))
                {
                    MessageBox.Show("Input calendar name firstly.");
                    return;
                }

                Folder folder = Folder.Bind(service, folderId);
                folder.DisplayName = this.txtCalendarName.Text;
                folder.Update();
                this.btnGetCalendarList_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Select a calendar to update");
                return;
            }
        }

        private void btnViewCalendar_Click(object sender, EventArgs e)
        {
            if (this.listViewCalendar.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = this.listViewCalendar.SelectedItems[0];
                initialListViewCalendarMeeting(selectedItem.SubItems[0].Text);
            }
            else
            {
                MessageBox.Show("Select a calendar to view");
                return;
            }
        }

        private void initialListViewCalendarMeeting(string id)
        {
            FolderId folderId = new FolderId(id);
            CalendarFolder calendar = CalendarFolder.Bind(service, folderId);
            CalendarView cView = new CalendarView(DateTime.Now.AddMonths(-6), DateTime.Now.AddYears(1), int.MaxValue);

            FindItemsResults<Appointment> appointments = calendar.FindAppointments(cView);
            var items = appointments.Items.OrderByDescending(x => x.Start);
            this.listViewCalendarMeeting.View = View.Details;
            this.listViewCalendarMeeting.Items.Clear();
            foreach (Appointment item in items)
            {
                var listViewItem = new ListViewItem(new[] { item.Id.UniqueId, item.Organizer.Name, item.DisplayTo, item.Subject, item.DateTimeReceived.ToString(), item.Start.ToString() });
                this.listViewCalendarMeeting.Items.Add(listViewItem);
            }
        }

        private void tabControlMenu_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0:
                    this.btnGetMails_Click(sender, e);
                    break;
                case 1:
                    this.btnGetMeetingList_Click(sender, e);
                    break;
                case 2:
                    this.btnGetCalendarList_Click(sender, e);
                    break;
            }
        }
    }
}
