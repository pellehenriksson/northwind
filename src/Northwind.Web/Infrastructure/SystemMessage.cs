using System;

namespace Northwind.Web.Infrastructure
{
    [Serializable]
    public class SystemMessage
    {
        public const string Key = "SystemMessage";
        
        private SystemMessage(MessageCategory category, string heading, string message)
        {
            this.Category = category;
            this.Heading = heading;
            this.Message = message;
        }

        public enum MessageCategory
        {
            Error,
            Success,
            Information
        }

        public MessageCategory Category { get; private set; }
        
        public string Heading { get; private set; }
        
        public string Message { get; private set; }

        public static SystemMessage CreateErrorMessage(string heading, string message)
        {
            return new SystemMessage(MessageCategory.Error, heading, message);
        }

        public static SystemMessage CreateSuccessMessage(string heading, string message)
        {
            return new SystemMessage(MessageCategory.Success, heading, message);
        }

        public static SystemMessage CreateInformationMessage(string heading, string message)
        {
            return new SystemMessage(MessageCategory.Information, heading, message);
        }
    }
}