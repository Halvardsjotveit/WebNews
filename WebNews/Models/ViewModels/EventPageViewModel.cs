using System;
using System.ComponentModel.DataAnnotations;
using Castle.Core.Internal;
using EPiServer;
using WebNews.Models.Pages;

namespace WebNews.Models.ViewModels
{
    public class EventPageViewModel : PageViewModel<EventPage>
    {
        public double Long { get; set; }
        public double Lat { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public EventPageViewModel(EventPage currentPage)
            : base(currentPage)
        {
            ServiceLocator = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<IContentLoader>();

            if (currentPage.EventPerson != null)
            {
                PhoneNumber = GetPhoneNumber(currentPage);
                Email = GetEmail(currentPage);
            }

            Lat = GetPosition(currentPage, 0);
            Long = GetPosition(currentPage, 1);

            StartTime = GetTimeString(currentPage.StartTime);
            EndTime = GetTimeString(currentPage.EndTime);
        }
        private double GetPosition(EventPage currentPage, int i)
        {
            var cordString = currentPage.Coordinates;
            if (cordString.IsNullOrEmpty())
                return 0;
            return double.Parse(currentPage.Coordinates.Split(',')[i]);
        }

        private string GetTimeString(DateTime? dateTime)
        {
            if (dateTime.HasValue)
                return dateTime.Value.ToString(Utils.Constants.DateTimeFormats.StandardFullFormat);

            return string.Empty;
        }

        private string GetPhoneNumber(EventPage currentPage)
        {
            return ServiceLocator.Get<PersonPage>(currentPage.EventPerson).PhoneNumber;
        }

        private string GetEmail(EventPage currentPage)
        {
            return ServiceLocator.Get<PersonPage>(currentPage.EventPerson).Email;
        }
    }

}