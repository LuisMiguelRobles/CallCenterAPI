namespace Domain.Helpers
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;

    public class DomainHelper: IDomainHelper
    {
        public DateTime GeDateTime(string message)
        {
            var dateTime = DateTime.MinValue;
            var match = Regex.Match(message, @"\d{2}\:\d{2}\:\d{2}");
            string date = match.Value;
            if (!string.IsNullOrEmpty(date))
            {
                dateTime = DateTime.ParseExact(date, "HH:mm:ss", CultureInfo.CurrentCulture);
            }

            return dateTime;
        }
    }
}
