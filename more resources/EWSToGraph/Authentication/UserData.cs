using System;
using Microsoft.Exchange.WebServices.Data;

namespace ExchangeAuthentication
{
    public interface IUserData
    {
        ExchangeVersion Version { get; }
        string EmailAddress { get; set; }
        string Password { get; set; }
        Uri AutodiscoverUrl { get; set; }
    }

    public class UserDataFromConsole : IUserData
    {
        public static UserDataFromConsole UserData;

        public static IUserData GetUserData()
        {
            return UserData;
        }
        public ExchangeVersion Version { get { return ExchangeVersion.Exchange2016; } }

        public string EmailAddress
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public Uri AutodiscoverUrl
        {
            get;
            set;
        }
    }
}
