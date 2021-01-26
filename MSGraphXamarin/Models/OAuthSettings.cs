using System;
using System.Collections.Generic;
using System.Text;

namespace MSGraphXamarin.Models
{
    public static class OAuthSettings
    {
        public const string ApplicationId = "477e9d4e-2939-441c-97b2-7f68ed3ee1c7";
        public const string Scopes = "User.Read MailboxSettings.Read Calendars.ReadWrite";
        public const string RedirectUri = "msauth://com.companyname.MSGraphXamarin";
    }
}
