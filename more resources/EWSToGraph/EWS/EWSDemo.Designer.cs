using System.Configuration;

namespace EWS
{
    partial class FormEWSDemo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.btnGetMails = new System.Windows.Forms.Button();
            this.listViewMail = new System.Windows.Forms.ListView();
            this.columnHeaderFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRecipients = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderHasRead = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.treeViewFolder = new System.Windows.Forms.TreeView();
            this.btnCreateFolder = new System.Windows.Forms.Button();
            this.btnDeleteFolder = new System.Windows.Forms.Button();
            this.btnCreateMail = new System.Windows.Forms.Button();
            this.groupBoxMail = new System.Windows.Forms.GroupBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.webBrowserBody = new System.Windows.Forms.WebBrowser();
            this.lblAttachedFile = new System.Windows.Forms.Label();
            this.richTxtBody = new System.Windows.Forms.RichTextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDeleteMail = new System.Windows.Forms.Button();
            this.btnViewMail = new System.Windows.Forms.Button();
            this.btnMarkRead = new System.Windows.Forms.Button();
            this.btnFindMail = new System.Windows.Forms.Button();
            this.btnMoveToFolder = new System.Windows.Forms.Button();
            this.btnCopyToFolder = new System.Windows.Forms.Button();
            this.txtKeyWord = new System.Windows.Forms.TextBox();
            this.groupBoxOperations = new System.Windows.Forms.GroupBox();
            this.groupBoxLogin = new System.Windows.Forms.GroupBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.tabControlMenu = new System.Windows.Forms.TabControl();
            this.tabPageMail = new System.Windows.Forms.TabPage();
            this.tabPageMeeting = new System.Windows.Forms.TabPage();
            this.btnDecline = new System.Windows.Forms.Button();
            this.btnTentative = new System.Windows.Forms.Button();
            this.groupBoxMeetingView = new System.Windows.Forms.GroupBox();
            this.txtMeetingFrom = new System.Windows.Forms.TextBox();
            this.lblMeetingFrom = new System.Windows.Forms.Label();
            this.txtMeetingEnd = new System.Windows.Forms.TextBox();
            this.txtMeetingStart = new System.Windows.Forms.TextBox();
            this.txtMeetingLocation = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.webBrowserMeetingBody = new System.Windows.Forms.WebBrowser();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSendMeeting = new System.Windows.Forms.Button();
            this.richTextBoxMeetingBody = new System.Windows.Forms.RichTextBox();
            this.txtMeetingSubject = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMeetingTo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxMeetingList = new System.Windows.Forms.GroupBox();
            this.listViewMeeting = new System.Windows.Forms.ListView();
            this.meetingID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.meetingFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.meetingTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.meetingSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.meetingDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.meetingResponseType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewReminder = new System.Windows.Forms.ListView();
            this.reminderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.reminderChangeKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.reminderSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.reminderLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.reminderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.reminderStartDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.reminderEndDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblReminderList = new System.Windows.Forms.Label();
            this.btnSnooze = new System.Windows.Forms.Button();
            this.txtLogForMeeting = new System.Windows.Forms.RichTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnDismiss = new System.Windows.Forms.Button();
            this.btnDeleteMeeting = new System.Windows.Forms.Button();
            this.btnUpdateMeeting = new System.Windows.Forms.Button();
            this.btnViewMeeting = new System.Windows.Forms.Button();
            this.btnGetMeetingList = new System.Windows.Forms.Button();
            this.btnCreateMeeting = new System.Windows.Forms.Button();
            this.tabPageCalendar = new System.Windows.Forms.TabPage();
            this.txtLogForCalendar = new System.Windows.Forms.RichTextBox();
            this.listViewCalendarMeeting = new System.Windows.Forms.ListView();
            this.calendarMeetingID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.calendarMeetingFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.calendarMeetingTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.calendarMeetingSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.calendarMeetingDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.calendarMeetingStart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewCalendar = new System.Windows.Forms.ListView();
            this.calendarID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.calendarName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblCalendarName = new System.Windows.Forms.Label();
            this.txtCalendarName = new System.Windows.Forms.TextBox();
            this.btnDeleteCalendar = new System.Windows.Forms.Button();
            this.btnUpdateCalendar = new System.Windows.Forms.Button();
            this.btnViewCalendar = new System.Windows.Forms.Button();
            this.btnGetCalendarList = new System.Windows.Forms.Button();
            this.btnCreateCalendar = new System.Windows.Forms.Button();
            this.groupBoxMail.SuspendLayout();
            this.groupBoxOperations.SuspendLayout();
            this.groupBoxLogin.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.tabControlMenu.SuspendLayout();
            this.tabPageMail.SuspendLayout();
            this.tabPageMeeting.SuspendLayout();
            this.groupBoxMeetingView.SuspendLayout();
            this.groupBoxMeetingList.SuspendLayout();
            this.tabPageCalendar.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(383, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(85, 13);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(280, 20);
            this.txtUserName.TabIndex = 2;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(445, 13);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(329, 20);
            this.txtPwd.TabIndex = 3;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(780, 11);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(85, 23);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(11, 12);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(75, 23);
            this.btnProfile.TabIndex = 5;
            this.btnProfile.Text = "Get Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(6, 101);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(240, 265);
            this.txtLog.TabIndex = 7;
            this.txtLog.Text = "";
            // 
            // btnGetMails
            // 
            this.btnGetMails.Location = new System.Drawing.Point(93, 12);
            this.btnGetMails.Name = "btnGetMails";
            this.btnGetMails.Size = new System.Drawing.Size(75, 23);
            this.btnGetMails.TabIndex = 8;
            this.btnGetMails.Text = "Mail List";
            this.btnGetMails.UseVisualStyleBackColor = true;
            this.btnGetMails.Click += new System.EventHandler(this.btnGetMails_Click);
            // 
            // listViewMail
            // 
            this.listViewMail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFrom,
            this.columnHeaderRecipients,
            this.columnHeaderSubject,
            this.columnHeaderDate,
            this.columnHeaderId,
            this.columnHeaderHasRead});
            this.listViewMail.FullRowSelect = true;
            this.listViewMail.HideSelection = false;
            this.listViewMail.Location = new System.Drawing.Point(249, 13);
            this.listViewMail.Name = "listViewMail";
            this.listViewMail.Size = new System.Drawing.Size(614, 353);
            this.listViewMail.TabIndex = 9;
            this.listViewMail.UseCompatibleStateImageBehavior = false;
            this.listViewMail.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listview_maillist_ColumnWidthChanging);
            // 
            // columnHeaderFrom
            // 
            this.columnHeaderFrom.Text = "From";
            this.columnHeaderFrom.Width = 100;
            // 
            // columnHeaderRecipients
            // 
            this.columnHeaderRecipients.Text = "Recipients";
            this.columnHeaderRecipients.Width = 100;
            // 
            // columnHeaderSubject
            // 
            this.columnHeaderSubject.Text = "Subject";
            this.columnHeaderSubject.Width = 100;
            // 
            // columnHeaderDate
            // 
            this.columnHeaderDate.Text = "Date";
            this.columnHeaderDate.Width = 100;
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "Id";
            this.columnHeaderId.Width = 0;
            // 
            // columnHeaderHasRead
            // 
            this.columnHeaderHasRead.Text = "Unread";
            // 
            // treeViewFolder
            // 
            this.treeViewFolder.HideSelection = false;
            this.treeViewFolder.Location = new System.Drawing.Point(6, 13);
            this.treeViewFolder.Name = "treeViewFolder";
            this.treeViewFolder.Size = new System.Drawing.Size(240, 82);
            this.treeViewFolder.TabIndex = 10;
            this.treeViewFolder.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_folder_NodeMouseDoubleClick);
            // 
            // btnCreateFolder
            // 
            this.btnCreateFolder.Location = new System.Drawing.Point(515, 12);
            this.btnCreateFolder.Name = "btnCreateFolder";
            this.btnCreateFolder.Size = new System.Drawing.Size(83, 23);
            this.btnCreateFolder.TabIndex = 11;
            this.btnCreateFolder.Text = "Create Folder";
            this.btnCreateFolder.UseVisualStyleBackColor = true;
            this.btnCreateFolder.Click += new System.EventHandler(this.btnCreateFolder_Click);
            // 
            // btnDeleteFolder
            // 
            this.btnDeleteFolder.Location = new System.Drawing.Point(606, 12);
            this.btnDeleteFolder.Name = "btnDeleteFolder";
            this.btnDeleteFolder.Size = new System.Drawing.Size(97, 23);
            this.btnDeleteFolder.TabIndex = 12;
            this.btnDeleteFolder.Text = "Delete Folder";
            this.btnDeleteFolder.UseVisualStyleBackColor = true;
            this.btnDeleteFolder.Click += new System.EventHandler(this.btnDeleteFolder_Click);
            // 
            // btnCreateMail
            // 
            this.btnCreateMail.Location = new System.Drawing.Point(336, 12);
            this.btnCreateMail.Name = "btnCreateMail";
            this.btnCreateMail.Size = new System.Drawing.Size(84, 23);
            this.btnCreateMail.TabIndex = 13;
            this.btnCreateMail.Text = "Create Mail";
            this.btnCreateMail.UseVisualStyleBackColor = true;
            this.btnCreateMail.Click += new System.EventHandler(this.btnCreateMail_Click);
            // 
            // groupBoxMail
            // 
            this.groupBoxMail.Controls.Add(this.txtFrom);
            this.groupBoxMail.Controls.Add(this.lblFrom);
            this.groupBoxMail.Controls.Add(this.btnSend);
            this.groupBoxMail.Controls.Add(this.webBrowserBody);
            this.groupBoxMail.Controls.Add(this.lblAttachedFile);
            this.groupBoxMail.Controls.Add(this.richTxtBody);
            this.groupBoxMail.Controls.Add(this.txtSubject);
            this.groupBoxMail.Controls.Add(this.label5);
            this.groupBoxMail.Controls.Add(this.txtTo);
            this.groupBoxMail.Controls.Add(this.label3);
            this.groupBoxMail.Location = new System.Drawing.Point(249, 7);
            this.groupBoxMail.Name = "groupBoxMail";
            this.groupBoxMail.Size = new System.Drawing.Size(614, 359);
            this.groupBoxMail.TabIndex = 24;
            this.groupBoxMail.TabStop = false;
            this.groupBoxMail.Visible = false;
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(343, 12);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(214, 20);
            this.txtFrom.TabIndex = 37;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(304, 16);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 36;
            this.lblFrom.Text = "From:";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(563, 12);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(47, 68);
            this.btnSend.TabIndex = 35;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // webBrowserBody
            // 
            this.webBrowserBody.Location = new System.Drawing.Point(2, 83);
            this.webBrowserBody.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserBody.Name = "webBrowserBody";
            this.webBrowserBody.Size = new System.Drawing.Size(606, 278);
            this.webBrowserBody.TabIndex = 34;
            this.webBrowserBody.Visible = false;
            // 
            // lblAttachedFile
            // 
            this.lblAttachedFile.AutoSize = true;
            this.lblAttachedFile.Location = new System.Drawing.Point(4, 67);
            this.lblAttachedFile.Name = "lblAttachedFile";
            this.lblAttachedFile.Size = new System.Drawing.Size(53, 13);
            this.lblAttachedFile.TabIndex = 33;
            this.lblAttachedFile.Text = "Attached:";
            // 
            // richTxtBody
            // 
            this.richTxtBody.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.richTxtBody.Location = new System.Drawing.Point(2, 83);
            this.richTxtBody.Name = "richTxtBody";
            this.richTxtBody.Size = new System.Drawing.Size(606, 270);
            this.richTxtBody.TabIndex = 30;
            this.richTxtBody.Text = "";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(58, 41);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(499, 20);
            this.txtSubject.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Subject:";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(58, 12);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(240, 20);
            this.txtTo.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "To:";
            // 
            // btnDeleteMail
            // 
            this.btnDeleteMail.Location = new System.Drawing.Point(255, 12);
            this.btnDeleteMail.Name = "btnDeleteMail";
            this.btnDeleteMail.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteMail.TabIndex = 25;
            this.btnDeleteMail.Text = "Delete Mail";
            this.btnDeleteMail.UseVisualStyleBackColor = true;
            this.btnDeleteMail.Click += new System.EventHandler(this.btnDeleteMail_Click);
            // 
            // btnViewMail
            // 
            this.btnViewMail.Location = new System.Drawing.Point(174, 11);
            this.btnViewMail.Name = "btnViewMail";
            this.btnViewMail.Size = new System.Drawing.Size(75, 23);
            this.btnViewMail.TabIndex = 26;
            this.btnViewMail.Text = "View Mail";
            this.btnViewMail.UseVisualStyleBackColor = true;
            this.btnViewMail.Click += new System.EventHandler(this.btnViewMail_Click);
            // 
            // btnMarkRead
            // 
            this.btnMarkRead.Location = new System.Drawing.Point(425, 12);
            this.btnMarkRead.Name = "btnMarkRead";
            this.btnMarkRead.Size = new System.Drawing.Size(84, 23);
            this.btnMarkRead.TabIndex = 27;
            this.btnMarkRead.Text = "Mark as Read";
            this.btnMarkRead.UseVisualStyleBackColor = true;
            this.btnMarkRead.Click += new System.EventHandler(this.btnMarkRead_Click);
            // 
            // btnFindMail
            // 
            this.btnFindMail.Location = new System.Drawing.Point(606, 41);
            this.btnFindMail.Name = "btnFindMail";
            this.btnFindMail.Size = new System.Drawing.Size(98, 23);
            this.btnFindMail.TabIndex = 28;
            this.btnFindMail.Text = "Find Mail";
            this.btnFindMail.UseVisualStyleBackColor = true;
            this.btnFindMail.Click += new System.EventHandler(this.btnFindMail_Click);
            // 
            // btnMoveToFolder
            // 
            this.btnMoveToFolder.Location = new System.Drawing.Point(707, 12);
            this.btnMoveToFolder.Name = "btnMoveToFolder";
            this.btnMoveToFolder.Size = new System.Drawing.Size(157, 23);
            this.btnMoveToFolder.TabIndex = 29;
            this.btnMoveToFolder.Text = "Move Mail into Folder";
            this.btnMoveToFolder.UseVisualStyleBackColor = true;
            this.btnMoveToFolder.Click += new System.EventHandler(this.btnMoveToFolder_Click);
            // 
            // btnCopyToFolder
            // 
            this.btnCopyToFolder.Location = new System.Drawing.Point(707, 41);
            this.btnCopyToFolder.Name = "btnCopyToFolder";
            this.btnCopyToFolder.Size = new System.Drawing.Size(157, 23);
            this.btnCopyToFolder.TabIndex = 30;
            this.btnCopyToFolder.Text = "Copy Mail into Folder";
            this.btnCopyToFolder.UseVisualStyleBackColor = true;
            this.btnCopyToFolder.Click += new System.EventHandler(this.btnCopyToFolder_Click);
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.Location = new System.Drawing.Point(12, 40);
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size(586, 20);
            this.txtKeyWord.TabIndex = 31;
            this.txtKeyWord.Text = "Search current mailbox";
            this.txtKeyWord.Enter += new System.EventHandler(this.txtKeyWord_Enter);
            // 
            // groupBoxOperations
            // 
            this.groupBoxOperations.Controls.Add(this.txtKeyWord);
            this.groupBoxOperations.Controls.Add(this.btnDeleteFolder);
            this.groupBoxOperations.Controls.Add(this.btnCopyToFolder);
            this.groupBoxOperations.Controls.Add(this.btnProfile);
            this.groupBoxOperations.Controls.Add(this.btnMoveToFolder);
            this.groupBoxOperations.Controls.Add(this.btnGetMails);
            this.groupBoxOperations.Controls.Add(this.btnFindMail);
            this.groupBoxOperations.Controls.Add(this.btnCreateFolder);
            this.groupBoxOperations.Controls.Add(this.btnMarkRead);
            this.groupBoxOperations.Controls.Add(this.btnCreateMail);
            this.groupBoxOperations.Controls.Add(this.btnViewMail);
            this.groupBoxOperations.Controls.Add(this.btnDeleteMail);
            this.groupBoxOperations.Location = new System.Drawing.Point(-1, -2);
            this.groupBoxOperations.Name = "groupBoxOperations";
            this.groupBoxOperations.Size = new System.Drawing.Size(872, 74);
            this.groupBoxOperations.TabIndex = 35;
            this.groupBoxOperations.TabStop = false;
            // 
            // groupBoxLogin
            // 
            this.groupBoxLogin.Controls.Add(this.label2);
            this.groupBoxLogin.Controls.Add(this.label1);
            this.groupBoxLogin.Controls.Add(this.txtUserName);
            this.groupBoxLogin.Controls.Add(this.txtPwd);
            this.groupBoxLogin.Controls.Add(this.btnLogin);
            this.groupBoxLogin.Location = new System.Drawing.Point(0, -7);
            this.groupBoxLogin.Name = "groupBoxLogin";
            this.groupBoxLogin.Size = new System.Drawing.Size(872, 42);
            this.groupBoxLogin.TabIndex = 35;
            this.groupBoxLogin.TabStop = false;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.treeViewFolder);
            this.groupBox.Controls.Add(this.txtLog);
            this.groupBox.Controls.Add(this.groupBoxMail);
            this.groupBox.Controls.Add(this.listViewMail);
            this.groupBox.Location = new System.Drawing.Point(-1, 65);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(872, 362);
            this.groupBox.TabIndex = 36;
            this.groupBox.TabStop = false;
            // 
            // tabControlMenu
            // 
            this.tabControlMenu.Controls.Add(this.tabPageMail);
            this.tabControlMenu.Controls.Add(this.tabPageMeeting);
            this.tabControlMenu.Controls.Add(this.tabPageCalendar);
            this.tabControlMenu.Enabled = false;
            this.tabControlMenu.Location = new System.Drawing.Point(0, 37);
            this.tabControlMenu.Name = "tabControlMenu";
            this.tabControlMenu.SelectedIndex = 0;
            this.tabControlMenu.Size = new System.Drawing.Size(872, 452);
            this.tabControlMenu.TabIndex = 35;
            this.tabControlMenu.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlMenu_Selected);
            // 
            // tabPageMail
            // 
            this.tabPageMail.Controls.Add(this.groupBoxOperations);
            this.tabPageMail.Controls.Add(this.groupBox);
            this.tabPageMail.Location = new System.Drawing.Point(4, 22);
            this.tabPageMail.Name = "tabPageMail";
            this.tabPageMail.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMail.Size = new System.Drawing.Size(864, 426);
            this.tabPageMail.TabIndex = 0;
            this.tabPageMail.Text = "Mail Scenario";
            this.tabPageMail.UseVisualStyleBackColor = true;
            // 
            // tabPageMeeting
            // 
            this.tabPageMeeting.Controls.Add(this.btnDecline);
            this.tabPageMeeting.Controls.Add(this.btnTentative);
            this.tabPageMeeting.Controls.Add(this.groupBoxMeetingView);
            this.tabPageMeeting.Controls.Add(this.groupBoxMeetingList);
            this.tabPageMeeting.Controls.Add(this.btnSnooze);
            this.tabPageMeeting.Controls.Add(this.txtLogForMeeting);
            this.tabPageMeeting.Controls.Add(this.btnAccept);
            this.tabPageMeeting.Controls.Add(this.btnDismiss);
            this.tabPageMeeting.Controls.Add(this.btnDeleteMeeting);
            this.tabPageMeeting.Controls.Add(this.btnUpdateMeeting);
            this.tabPageMeeting.Controls.Add(this.btnViewMeeting);
            this.tabPageMeeting.Controls.Add(this.btnGetMeetingList);
            this.tabPageMeeting.Controls.Add(this.btnCreateMeeting);
            this.tabPageMeeting.Location = new System.Drawing.Point(4, 22);
            this.tabPageMeeting.Name = "tabPageMeeting";
            this.tabPageMeeting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMeeting.Size = new System.Drawing.Size(864, 426);
            this.tabPageMeeting.TabIndex = 1;
            this.tabPageMeeting.Text = "Meeting Scenario";
            this.tabPageMeeting.UseVisualStyleBackColor = true;
            // 
            // btnDecline
            // 
            this.btnDecline.Location = new System.Drawing.Point(793, 8);
            this.btnDecline.Name = "btnDecline";
            this.btnDecline.Size = new System.Drawing.Size(61, 23);
            this.btnDecline.TabIndex = 27;
            this.btnDecline.Text = "Decline";
            this.btnDecline.UseVisualStyleBackColor = true;
            this.btnDecline.Click += new System.EventHandler(this.btnDecline_Click);
            // 
            // btnTentative
            // 
            this.btnTentative.Location = new System.Drawing.Point(724, 8);
            this.btnTentative.Name = "btnTentative";
            this.btnTentative.Size = new System.Drawing.Size(61, 23);
            this.btnTentative.TabIndex = 26;
            this.btnTentative.Text = "Tentative";
            this.btnTentative.UseVisualStyleBackColor = true;
            this.btnTentative.Click += new System.EventHandler(this.btnTentative_Click);
            // 
            // groupBoxMeetingView
            // 
            this.groupBoxMeetingView.Controls.Add(this.txtMeetingFrom);
            this.groupBoxMeetingView.Controls.Add(this.lblMeetingFrom);
            this.groupBoxMeetingView.Controls.Add(this.txtMeetingEnd);
            this.groupBoxMeetingView.Controls.Add(this.txtMeetingStart);
            this.groupBoxMeetingView.Controls.Add(this.txtMeetingLocation);
            this.groupBoxMeetingView.Controls.Add(this.label9);
            this.groupBoxMeetingView.Controls.Add(this.label8);
            this.groupBoxMeetingView.Controls.Add(this.webBrowserMeetingBody);
            this.groupBoxMeetingView.Controls.Add(this.label6);
            this.groupBoxMeetingView.Controls.Add(this.btnSendMeeting);
            this.groupBoxMeetingView.Controls.Add(this.richTextBoxMeetingBody);
            this.groupBoxMeetingView.Controls.Add(this.txtMeetingSubject);
            this.groupBoxMeetingView.Controls.Add(this.label7);
            this.groupBoxMeetingView.Controls.Add(this.txtMeetingTo);
            this.groupBoxMeetingView.Controls.Add(this.label4);
            this.groupBoxMeetingView.Location = new System.Drawing.Point(-4, 32);
            this.groupBoxMeetingView.Name = "groupBoxMeetingView";
            this.groupBoxMeetingView.Size = new System.Drawing.Size(872, 253);
            this.groupBoxMeetingView.TabIndex = 25;
            this.groupBoxMeetingView.TabStop = false;
            this.groupBoxMeetingView.Visible = false;
            // 
            // txtMeetingFrom
            // 
            this.txtMeetingFrom.Location = new System.Drawing.Point(464, 13);
            this.txtMeetingFrom.Name = "txtMeetingFrom";
            this.txtMeetingFrom.Size = new System.Drawing.Size(309, 20);
            this.txtMeetingFrom.TabIndex = 41;
            // 
            // lblMeetingFrom
            // 
            this.lblMeetingFrom.AutoSize = true;
            this.lblMeetingFrom.Location = new System.Drawing.Point(426, 15);
            this.lblMeetingFrom.Name = "lblMeetingFrom";
            this.lblMeetingFrom.Size = new System.Drawing.Size(33, 13);
            this.lblMeetingFrom.TabIndex = 40;
            this.lblMeetingFrom.Text = "From:";
            // 
            // txtMeetingEnd
            // 
            this.txtMeetingEnd.Location = new System.Drawing.Point(464, 86);
            this.txtMeetingEnd.Name = "txtMeetingEnd";
            this.txtMeetingEnd.ReadOnly = true;
            this.txtMeetingEnd.Size = new System.Drawing.Size(309, 20);
            this.txtMeetingEnd.TabIndex = 39;
            // 
            // txtMeetingStart
            // 
            this.txtMeetingStart.Location = new System.Drawing.Point(60, 87);
            this.txtMeetingStart.Name = "txtMeetingStart";
            this.txtMeetingStart.ReadOnly = true;
            this.txtMeetingStart.Size = new System.Drawing.Size(340, 20);
            this.txtMeetingStart.TabIndex = 38;
            // 
            // txtMeetingLocation
            // 
            this.txtMeetingLocation.Location = new System.Drawing.Point(60, 61);
            this.txtMeetingLocation.Name = "txtMeetingLocation";
            this.txtMeetingLocation.Size = new System.Drawing.Size(713, 20);
            this.txtMeetingLocation.TabIndex = 37;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Location:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(408, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "End Time:";
            // 
            // webBrowserMeetingBody
            // 
            this.webBrowserMeetingBody.Location = new System.Drawing.Point(4, 130);
            this.webBrowserMeetingBody.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserMeetingBody.Name = "webBrowserMeetingBody";
            this.webBrowserMeetingBody.Size = new System.Drawing.Size(862, 123);
            this.webBrowserMeetingBody.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Start Time:";
            // 
            // btnSendMeeting
            // 
            this.btnSendMeeting.Location = new System.Drawing.Point(780, 13);
            this.btnSendMeeting.Name = "btnSendMeeting";
            this.btnSendMeeting.Size = new System.Drawing.Size(84, 94);
            this.btnSendMeeting.TabIndex = 32;
            this.btnSendMeeting.Text = "Send";
            this.btnSendMeeting.UseVisualStyleBackColor = true;
            this.btnSendMeeting.Click += new System.EventHandler(this.btnSendMeeting_Click);
            // 
            // richTextBoxMeetingBody
            // 
            this.richTextBoxMeetingBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxMeetingBody.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.richTextBoxMeetingBody.Location = new System.Drawing.Point(6, 111);
            this.richTextBoxMeetingBody.Name = "richTextBoxMeetingBody";
            this.richTextBoxMeetingBody.Size = new System.Drawing.Size(866, 142);
            this.richTextBoxMeetingBody.TabIndex = 30;
            this.richTextBoxMeetingBody.Text = "";
            // 
            // txtMeetingSubject
            // 
            this.txtMeetingSubject.Location = new System.Drawing.Point(61, 37);
            this.txtMeetingSubject.Name = "txtMeetingSubject";
            this.txtMeetingSubject.Size = new System.Drawing.Size(712, 20);
            this.txtMeetingSubject.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Subject:";
            // 
            // txtMeetingTo
            // 
            this.txtMeetingTo.Location = new System.Drawing.Point(61, 12);
            this.txtMeetingTo.Name = "txtMeetingTo";
            this.txtMeetingTo.Size = new System.Drawing.Size(350, 20);
            this.txtMeetingTo.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "To:";
            // 
            // groupBoxMeetingList
            // 
            this.groupBoxMeetingList.Controls.Add(this.listViewMeeting);
            this.groupBoxMeetingList.Controls.Add(this.listViewReminder);
            this.groupBoxMeetingList.Controls.Add(this.lblReminderList);
            this.groupBoxMeetingList.Location = new System.Drawing.Point(-4, 30);
            this.groupBoxMeetingList.Name = "groupBoxMeetingList";
            this.groupBoxMeetingList.Size = new System.Drawing.Size(872, 255);
            this.groupBoxMeetingList.TabIndex = 11;
            this.groupBoxMeetingList.TabStop = false;
            // 
            // listViewMeeting
            // 
            this.listViewMeeting.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.meetingID,
            this.meetingFrom,
            this.meetingTo,
            this.meetingSubject,
            this.meetingDate,
            this.meetingResponseType});
            this.listViewMeeting.FullRowSelect = true;
            this.listViewMeeting.HideSelection = false;
            this.listViewMeeting.Location = new System.Drawing.Point(2, 7);
            this.listViewMeeting.Name = "listViewMeeting";
            this.listViewMeeting.Size = new System.Drawing.Size(870, 97);
            this.listViewMeeting.TabIndex = 7;
            this.listViewMeeting.UseCompatibleStateImageBehavior = false;
            // 
            // meetingID
            // 
            this.meetingID.Width = 0;
            // 
            // meetingFrom
            // 
            this.meetingFrom.Text = "From";
            this.meetingFrom.Width = 150;
            // 
            // meetingTo
            // 
            this.meetingTo.Text = "Recipients";
            this.meetingTo.Width = 150;
            // 
            // meetingSubject
            // 
            this.meetingSubject.Text = "Subject";
            this.meetingSubject.Width = 150;
            // 
            // meetingDate
            // 
            this.meetingDate.Text = "Received Date";
            this.meetingDate.Width = 150;
            // 
            // meetingResponseType
            // 
            this.meetingResponseType.Text = "Response Type";
            this.meetingResponseType.Width = 150;
            // 
            // listViewReminder
            // 
            this.listViewReminder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.reminderID,
            this.reminderChangeKey,
            this.reminderSubject,
            this.reminderLocation,
            this.reminderTime,
            this.reminderStartDate,
            this.reminderEndDate});
            this.listViewReminder.FullRowSelect = true;
            this.listViewReminder.HideSelection = false;
            this.listViewReminder.Location = new System.Drawing.Point(2, 124);
            this.listViewReminder.Name = "listViewReminder";
            this.listViewReminder.Size = new System.Drawing.Size(870, 131);
            this.listViewReminder.TabIndex = 9;
            this.listViewReminder.UseCompatibleStateImageBehavior = false;
            // 
            // reminderID
            // 
            this.reminderID.Width = 0;
            // 
            // reminderChangeKey
            // 
            this.reminderChangeKey.Text = "Change Key";
            this.reminderChangeKey.Width = 0;
            // 
            // reminderSubject
            // 
            this.reminderSubject.Text = "Subject";
            this.reminderSubject.Width = 150;
            // 
            // reminderLocation
            // 
            this.reminderLocation.Text = "Location";
            this.reminderLocation.Width = 150;
            // 
            // reminderTime
            // 
            this.reminderTime.Text = "Reminder Time";
            this.reminderTime.Width = 150;
            // 
            // reminderStartDate
            // 
            this.reminderStartDate.Text = "Start Date";
            this.reminderStartDate.Width = 150;
            // 
            // reminderEndDate
            // 
            this.reminderEndDate.Text = "End Date";
            this.reminderEndDate.Width = 150;
            // 
            // lblReminderList
            // 
            this.lblReminderList.AutoSize = true;
            this.lblReminderList.Location = new System.Drawing.Point(8, 111);
            this.lblReminderList.Name = "lblReminderList";
            this.lblReminderList.Size = new System.Drawing.Size(77, 13);
            this.lblReminderList.TabIndex = 40;
            this.lblReminderList.Text = "Reminder List: ";
            // 
            // btnSnooze
            // 
            this.btnSnooze.Location = new System.Drawing.Point(586, 8);
            this.btnSnooze.Name = "btnSnooze";
            this.btnSnooze.Size = new System.Drawing.Size(61, 23);
            this.btnSnooze.TabIndex = 10;
            this.btnSnooze.Text = "Snooze";
            this.btnSnooze.UseVisualStyleBackColor = true;
            this.btnSnooze.Click += new System.EventHandler(this.btnSnooze_Click);
            // 
            // txtLogForMeeting
            // 
            this.txtLogForMeeting.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLogForMeeting.Location = new System.Drawing.Point(-1, 285);
            this.txtLogForMeeting.Name = "txtLogForMeeting";
            this.txtLogForMeeting.ReadOnly = true;
            this.txtLogForMeeting.Size = new System.Drawing.Size(869, 145);
            this.txtLogForMeeting.TabIndex = 8;
            this.txtLogForMeeting.Text = "";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(655, 8);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(61, 23);
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnDismiss
            // 
            this.btnDismiss.Location = new System.Drawing.Point(517, 8);
            this.btnDismiss.Name = "btnDismiss";
            this.btnDismiss.Size = new System.Drawing.Size(61, 23);
            this.btnDismiss.TabIndex = 5;
            this.btnDismiss.Text = "Dismiss";
            this.btnDismiss.UseVisualStyleBackColor = true;
            this.btnDismiss.Click += new System.EventHandler(this.btnDismiss_Click);
            // 
            // btnDeleteMeeting
            // 
            this.btnDeleteMeeting.Location = new System.Drawing.Point(415, 8);
            this.btnDeleteMeeting.Name = "btnDeleteMeeting";
            this.btnDeleteMeeting.Size = new System.Drawing.Size(94, 23);
            this.btnDeleteMeeting.TabIndex = 4;
            this.btnDeleteMeeting.Text = "Delete Meeting";
            this.btnDeleteMeeting.UseVisualStyleBackColor = true;
            this.btnDeleteMeeting.Click += new System.EventHandler(this.btnDeleteMeeting_Click);
            // 
            // btnUpdateMeeting
            // 
            this.btnUpdateMeeting.Location = new System.Drawing.Point(313, 8);
            this.btnUpdateMeeting.Name = "btnUpdateMeeting";
            this.btnUpdateMeeting.Size = new System.Drawing.Size(94, 23);
            this.btnUpdateMeeting.TabIndex = 3;
            this.btnUpdateMeeting.Text = "Update Meeting";
            this.btnUpdateMeeting.UseVisualStyleBackColor = true;
            this.btnUpdateMeeting.Click += new System.EventHandler(this.btnUpdateMeeting_Click);
            // 
            // btnViewMeeting
            // 
            this.btnViewMeeting.Location = new System.Drawing.Point(211, 8);
            this.btnViewMeeting.Name = "btnViewMeeting";
            this.btnViewMeeting.Size = new System.Drawing.Size(94, 23);
            this.btnViewMeeting.TabIndex = 2;
            this.btnViewMeeting.Text = "View Meeting";
            this.btnViewMeeting.UseVisualStyleBackColor = true;
            this.btnViewMeeting.Click += new System.EventHandler(this.btnViewMeeting_Click);
            // 
            // btnGetMeetingList
            // 
            this.btnGetMeetingList.Location = new System.Drawing.Point(7, 8);
            this.btnGetMeetingList.Name = "btnGetMeetingList";
            this.btnGetMeetingList.Size = new System.Drawing.Size(94, 23);
            this.btnGetMeetingList.TabIndex = 0;
            this.btnGetMeetingList.Text = "Get Meeting List";
            this.btnGetMeetingList.UseVisualStyleBackColor = true;
            this.btnGetMeetingList.Click += new System.EventHandler(this.btnGetMeetingList_Click);
            // 
            // btnCreateMeeting
            // 
            this.btnCreateMeeting.Location = new System.Drawing.Point(109, 8);
            this.btnCreateMeeting.Name = "btnCreateMeeting";
            this.btnCreateMeeting.Size = new System.Drawing.Size(94, 23);
            this.btnCreateMeeting.TabIndex = 1;
            this.btnCreateMeeting.Text = "Create Meeting";
            this.btnCreateMeeting.UseVisualStyleBackColor = true;
            this.btnCreateMeeting.Click += new System.EventHandler(this.btnCreateMeeting_Click);
            // 
            // tabPageCalendar
            // 
            this.tabPageCalendar.Controls.Add(this.txtLogForCalendar);
            this.tabPageCalendar.Controls.Add(this.listViewCalendarMeeting);
            this.tabPageCalendar.Controls.Add(this.listViewCalendar);
            this.tabPageCalendar.Controls.Add(this.lblCalendarName);
            this.tabPageCalendar.Controls.Add(this.txtCalendarName);
            this.tabPageCalendar.Controls.Add(this.btnDeleteCalendar);
            this.tabPageCalendar.Controls.Add(this.btnUpdateCalendar);
            this.tabPageCalendar.Controls.Add(this.btnViewCalendar);
            this.tabPageCalendar.Controls.Add(this.btnGetCalendarList);
            this.tabPageCalendar.Controls.Add(this.btnCreateCalendar);
            this.tabPageCalendar.Location = new System.Drawing.Point(4, 22);
            this.tabPageCalendar.Name = "tabPageCalendar";
            this.tabPageCalendar.Size = new System.Drawing.Size(864, 426);
            this.tabPageCalendar.TabIndex = 2;
            this.tabPageCalendar.Text = "Calendar Scenario";
            this.tabPageCalendar.UseVisualStyleBackColor = true;
            // 
            // txtLogForCalendar
            // 
            this.txtLogForCalendar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLogForCalendar.Location = new System.Drawing.Point(-8, 281);
            this.txtLogForCalendar.Name = "txtLogForCalendar";
            this.txtLogForCalendar.ReadOnly = true;
            this.txtLogForCalendar.Size = new System.Drawing.Size(872, 149);
            this.txtLogForCalendar.TabIndex = 15;
            this.txtLogForCalendar.Text = "";
            // 
            // listViewCalendarMeeting
            // 
            this.listViewCalendarMeeting.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.calendarMeetingID,
            this.calendarMeetingFrom,
            this.calendarMeetingTo,
            this.calendarMeetingSubject,
            this.calendarMeetingDate,
            this.calendarMeetingStart});
            this.listViewCalendarMeeting.FullRowSelect = true;
            this.listViewCalendarMeeting.HideSelection = false;
            this.listViewCalendarMeeting.Location = new System.Drawing.Point(139, 41);
            this.listViewCalendarMeeting.Name = "listViewCalendarMeeting";
            this.listViewCalendarMeeting.Size = new System.Drawing.Size(721, 239);
            this.listViewCalendarMeeting.TabIndex = 12;
            this.listViewCalendarMeeting.UseCompatibleStateImageBehavior = false;
            // 
            // calendarMeetingID
            // 
            this.calendarMeetingID.Width = 0;
            // 
            // calendarMeetingFrom
            // 
            this.calendarMeetingFrom.Text = "From";
            this.calendarMeetingFrom.Width = 140;
            // 
            // calendarMeetingTo
            // 
            this.calendarMeetingTo.Text = "Recipients";
            this.calendarMeetingTo.Width = 140;
            // 
            // calendarMeetingSubject
            // 
            this.calendarMeetingSubject.Text = "Subject";
            this.calendarMeetingSubject.Width = 120;
            // 
            // calendarMeetingDate
            // 
            this.calendarMeetingDate.Text = "Received Date";
            this.calendarMeetingDate.Width = 140;
            // 
            // calendarMeetingStart
            // 
            this.calendarMeetingStart.Text = "Start Date";
            this.calendarMeetingStart.Width = 140;
            // 
            // listViewCalendar
            // 
            this.listViewCalendar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.calendarID,
            this.calendarName});
            this.listViewCalendar.FullRowSelect = true;
            this.listViewCalendar.HideSelection = false;
            this.listViewCalendar.Location = new System.Drawing.Point(0, 41);
            this.listViewCalendar.MultiSelect = false;
            this.listViewCalendar.Name = "listViewCalendar";
            this.listViewCalendar.Size = new System.Drawing.Size(133, 239);
            this.listViewCalendar.TabIndex = 13;
            this.listViewCalendar.UseCompatibleStateImageBehavior = false;
            // 
            // calendarID
            // 
            this.calendarID.Width = 0;
            // 
            // calendarName
            // 
            this.calendarName.Text = "Name";
            this.calendarName.Width = 120;
            // 
            // lblCalendarName
            // 
            this.lblCalendarName.AutoSize = true;
            this.lblCalendarName.Location = new System.Drawing.Point(580, 17);
            this.lblCalendarName.Name = "lblCalendarName";
            this.lblCalendarName.Size = new System.Drawing.Size(86, 13);
            this.lblCalendarName.TabIndex = 11;
            this.lblCalendarName.Text = "Calendar Name: ";
            // 
            // txtCalendarName
            // 
            this.txtCalendarName.Location = new System.Drawing.Point(672, 15);
            this.txtCalendarName.Name = "txtCalendarName";
            this.txtCalendarName.Size = new System.Drawing.Size(184, 20);
            this.txtCalendarName.TabIndex = 10;
            // 
            // btnDeleteCalendar
            // 
            this.btnDeleteCalendar.Location = new System.Drawing.Point(241, 12);
            this.btnDeleteCalendar.Name = "btnDeleteCalendar";
            this.btnDeleteCalendar.Size = new System.Drawing.Size(107, 23);
            this.btnDeleteCalendar.TabIndex = 9;
            this.btnDeleteCalendar.Text = "Delete Calendar";
            this.btnDeleteCalendar.UseVisualStyleBackColor = true;
            this.btnDeleteCalendar.Click += new System.EventHandler(this.btnDeleteCalendar_Click);
            // 
            // btnUpdateCalendar
            // 
            this.btnUpdateCalendar.Location = new System.Drawing.Point(467, 12);
            this.btnUpdateCalendar.Name = "btnUpdateCalendar";
            this.btnUpdateCalendar.Size = new System.Drawing.Size(107, 23);
            this.btnUpdateCalendar.TabIndex = 8;
            this.btnUpdateCalendar.Text = "Update Calendar";
            this.btnUpdateCalendar.UseVisualStyleBackColor = true;
            this.btnUpdateCalendar.Click += new System.EventHandler(this.btnUpdateCalendar_Click);
            // 
            // btnViewCalendar
            // 
            this.btnViewCalendar.Location = new System.Drawing.Point(128, 12);
            this.btnViewCalendar.Name = "btnViewCalendar";
            this.btnViewCalendar.Size = new System.Drawing.Size(107, 23);
            this.btnViewCalendar.TabIndex = 7;
            this.btnViewCalendar.Text = "View Calendar";
            this.btnViewCalendar.UseVisualStyleBackColor = true;
            this.btnViewCalendar.Click += new System.EventHandler(this.btnViewCalendar_Click);
            // 
            // btnGetCalendarList
            // 
            this.btnGetCalendarList.Location = new System.Drawing.Point(15, 12);
            this.btnGetCalendarList.Name = "btnGetCalendarList";
            this.btnGetCalendarList.Size = new System.Drawing.Size(107, 23);
            this.btnGetCalendarList.TabIndex = 6;
            this.btnGetCalendarList.Text = "Get Calendar List";
            this.btnGetCalendarList.UseVisualStyleBackColor = true;
            this.btnGetCalendarList.Click += new System.EventHandler(this.btnGetCalendarList_Click);
            // 
            // btnCreateCalendar
            // 
            this.btnCreateCalendar.Location = new System.Drawing.Point(354, 12);
            this.btnCreateCalendar.Name = "btnCreateCalendar";
            this.btnCreateCalendar.Size = new System.Drawing.Size(107, 23);
            this.btnCreateCalendar.TabIndex = 5;
            this.btnCreateCalendar.Text = "Create Calendar";
            this.btnCreateCalendar.UseVisualStyleBackColor = true;
            this.btnCreateCalendar.Click += new System.EventHandler(this.btnCreateCalendar_Click);
            // 
            // FormEWSDemo
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 492);
            this.Controls.Add(this.tabControlMenu);
            this.Controls.Add(this.groupBoxLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormEWSDemo";
            this.Text = "EWS Demo";
            this.groupBoxMail.ResumeLayout(false);
            this.groupBoxMail.PerformLayout();
            this.groupBoxOperations.ResumeLayout(false);
            this.groupBoxOperations.PerformLayout();
            this.groupBoxLogin.ResumeLayout(false);
            this.groupBoxLogin.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.tabControlMenu.ResumeLayout(false);
            this.tabPageMail.ResumeLayout(false);
            this.tabPageMeeting.ResumeLayout(false);
            this.groupBoxMeetingView.ResumeLayout(false);
            this.groupBoxMeetingView.PerformLayout();
            this.groupBoxMeetingList.ResumeLayout(false);
            this.groupBoxMeetingList.PerformLayout();
            this.tabPageCalendar.ResumeLayout(false);
            this.tabPageCalendar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Button btnGetMails;
        private System.Windows.Forms.ListView listViewMail;
        private System.Windows.Forms.ColumnHeader columnHeaderFrom;
        private System.Windows.Forms.ColumnHeader columnHeaderRecipients;
        private System.Windows.Forms.ColumnHeader columnHeaderSubject;
        private System.Windows.Forms.ColumnHeader columnHeaderDate;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.TreeView treeViewFolder;
        private System.Windows.Forms.Button btnCreateFolder;
        private System.Windows.Forms.Button btnDeleteFolder;
        private System.Windows.Forms.Button btnCreateMail;
        private System.Windows.Forms.GroupBox groupBoxMail;
        private System.Windows.Forms.Label lblAttachedFile;
        private System.Windows.Forms.RichTextBox richTxtBody;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDeleteMail;
        private System.Windows.Forms.Button btnViewMail;
        private System.Windows.Forms.WebBrowser webBrowserBody;
        private System.Windows.Forms.ColumnHeader columnHeaderHasRead;
        private System.Windows.Forms.Button btnMarkRead;
        private System.Windows.Forms.Button btnFindMail;
        private System.Windows.Forms.Button btnMoveToFolder;
        private System.Windows.Forms.Button btnCopyToFolder;
        private System.Windows.Forms.TextBox txtKeyWord;
        private System.Windows.Forms.GroupBox groupBoxOperations;
        private System.Windows.Forms.GroupBox groupBoxLogin;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TabControl tabControlMenu;
        private System.Windows.Forms.TabPage tabPageMail;
        private System.Windows.Forms.TabPage tabPageMeeting;
        private System.Windows.Forms.Button btnDismiss;
        private System.Windows.Forms.Button btnDeleteMeeting;
        private System.Windows.Forms.Button btnUpdateMeeting;
        private System.Windows.Forms.Button btnViewMeeting;
        private System.Windows.Forms.Button btnGetMeetingList;
        private System.Windows.Forms.Button btnCreateMeeting;
        private System.Windows.Forms.ListView listViewMeeting;
        private System.Windows.Forms.ColumnHeader meetingID;
        private System.Windows.Forms.ColumnHeader meetingFrom;
        private System.Windows.Forms.ColumnHeader meetingSubject;
        private System.Windows.Forms.ColumnHeader meetingDate;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.ColumnHeader meetingTo;
        private System.Windows.Forms.RichTextBox txtLogForMeeting;
        private System.Windows.Forms.ListView listViewReminder;
        private System.Windows.Forms.ColumnHeader reminderID;
        private System.Windows.Forms.ColumnHeader reminderSubject;
        private System.Windows.Forms.ColumnHeader reminderLocation;
        private System.Windows.Forms.ColumnHeader reminderTime;
        private System.Windows.Forms.ColumnHeader reminderStartDate;
        private System.Windows.Forms.ColumnHeader reminderEndDate;
        private System.Windows.Forms.Button btnSnooze;
        private System.Windows.Forms.ColumnHeader reminderChangeKey;
        private System.Windows.Forms.GroupBox groupBoxMeetingList;
        private System.Windows.Forms.GroupBox groupBoxMeetingView;
        private System.Windows.Forms.TextBox txtMeetingEnd;
        private System.Windows.Forms.TextBox txtMeetingStart;
        private System.Windows.Forms.TextBox txtMeetingLocation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.WebBrowser webBrowserMeetingBody;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSendMeeting;
        private System.Windows.Forms.RichTextBox richTextBoxMeetingBody;
        private System.Windows.Forms.TextBox txtMeetingSubject;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMeetingTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDecline;
        private System.Windows.Forms.Button btnTentative;
        private System.Windows.Forms.ColumnHeader meetingResponseType;
        private System.Windows.Forms.TabPage tabPageCalendar;
        private System.Windows.Forms.ListView listViewCalendar;
        private System.Windows.Forms.ColumnHeader calendarName;
        private System.Windows.Forms.Label lblCalendarName;
        private System.Windows.Forms.TextBox txtCalendarName;
        private System.Windows.Forms.Button btnDeleteCalendar;
        private System.Windows.Forms.Button btnUpdateCalendar;
        private System.Windows.Forms.Button btnViewCalendar;
        private System.Windows.Forms.Button btnGetCalendarList;
        private System.Windows.Forms.Button btnCreateCalendar;
        private System.Windows.Forms.ColumnHeader calendarID;
        private System.Windows.Forms.ListView listViewCalendarMeeting;
        private System.Windows.Forms.ColumnHeader calendarMeetingID;
        private System.Windows.Forms.ColumnHeader calendarMeetingFrom;
        private System.Windows.Forms.ColumnHeader calendarMeetingTo;
        private System.Windows.Forms.ColumnHeader calendarMeetingSubject;
        private System.Windows.Forms.ColumnHeader calendarMeetingDate;
        private System.Windows.Forms.ColumnHeader calendarMeetingStart;
        private System.Windows.Forms.RichTextBox txtLogForCalendar;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblReminderList;
        private System.Windows.Forms.TextBox txtMeetingFrom;
        private System.Windows.Forms.Label lblMeetingFrom;
    }
}

