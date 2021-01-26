using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.Graph;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TimeZoneConverter;


namespace MSGraphXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarPage : ContentPage
    {
        public CalendarPage()
        {
            InitializeComponent();
        }
        private static DateTime GetUtcStartOfWeekInTimeZone(DateTime today, string timeZoneId)
        {
            // Time zone returned by Graph could be Windows or IANA style
            // .NET Core's FindSystemTimeZoneById needs IANA on Linux/MacOS,
            // and needs Windows style on Windows.
            // TimeZoneConverter can handle this for us
            TimeZoneInfo userTimeZone = TZConvert.GetTimeZoneInfo(timeZoneId);

            // Assumes Sunday as first day of week
            int diff = System.DayOfWeek.Sunday - today.DayOfWeek;

            // create date as unspecified kind
            var unspecifiedStart = DateTime.SpecifyKind(today.AddDays(diff), DateTimeKind.Unspecified);

            // convert to UTC
            return TimeZoneInfo.ConvertTimeToUtc(unspecifiedStart, userTimeZone);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Get start and end of week in user's time zone
            var startOfWeek = GetUtcStartOfWeekInTimeZone(DateTime.Today, App.UserTimeZone.ToString());
            var endOfWeek = startOfWeek.AddDays(7);

            var queryOptions = new List<QueryOption>
            {
                new QueryOption("startDateTime", startOfWeek.ToString("o")),
                new QueryOption("endDateTime", endOfWeek.ToString("o"))
             };

            // Get the events
            var events = await App.GraphClient.Me.CalendarView.Request(queryOptions)
                .Header("Prefer", $"outlook.timezone=\"{App.UserTimeZone.DisplayName}\"")
                .Select(e => new
                {
                    e.Subject,
                    e.Organizer,
                    e.Start,
                    e.End
                })
                .OrderBy("start/DateTime")
                .Top(50)
                .GetAsync();

            // Add the events to the list view
            CalendarList.ItemsSource = events.CurrentPage.ToList();
        }
    }
}