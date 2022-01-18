using System;
using System.Globalization;

namespace SpecFlowProject2.Pages
{
    public class Appointment
    {
        public enum Type
        {
            Billable = 0,
            NonBillable = 1,
            Travel = 2
        }

        public Type type;
        public DateTime date;
        public DateTime startTime;
        public DateTime endTime;
        public string staff;
        public string client;
        public string service;
        public string payCode;
        public string placeOfService;
        public string location;
        public string tag;
        public string mileage;

        public Appointment(Type type, DateTime date, DateTime startTime, DateTime endTime, string staff, string client, string service, string payCode, string placeOfService = "",  string location = "",string tag="", string mileage="")
        {
            this.type = type;
            this.date = date;
            this.startTime = startTime;
            this.endTime = endTime;
            this.staff = staff;
            this.client = client;
            this.service = service;
            this.payCode = payCode;
            this.placeOfService = placeOfService;
            this.location = location;
            this.tag = tag;
            this.mileage = mileage;
        }

        public Appointment(Appointment temp)
        {
            this.type = temp.type;
            this.date = temp.date;
            this.startTime = temp.startTime;
            this.endTime = temp.endTime;
            this.staff = temp.staff;
            this.client = temp.client;
            this.service = temp.service;
            this.payCode = temp.payCode;
            this.placeOfService = temp.placeOfService;
            this.location = temp.location;
            this.tag = temp.tag;
            this.mileage = temp.mileage;
        }

        public string GetShortFirstName()
        {
            var shortFirstName = client.Substring(0, 1) + ".";
            return shortFirstName;
        }

        public string GetApptXPath()
        {
            string color = String.Empty;
            switch (type)
            {
                case Type.Billable:
                    {
                        color = "green";
                        break;
                    }
                case Type.NonBillable:
                    {
                        color = "blue";
                        break;
                    }

                case Type.Travel:
                    {
                        color = "yellow";
                        break;
                    }
            }

            int day = (int)date.DayOfWeek;
            if (day == 0)
                day = 7;

            var start = startTime.ToString("hh:mm tt", CultureInfo.InvariantCulture);
            var end = endTime.ToString("hh:mm tt", CultureInfo.InvariantCulture);

            string path = string.Format(
                  $"//div[contains(@class, '{color}') and not(contains(@class,'cancelledEvent'))]" +
                  $"/div/div[contains(., '{start}') and contains(., '{end}') and contains(., '{GetShortFirstName()}') and not(contains(@class, 'inner'))]");
            return path;
        }
    }
}
