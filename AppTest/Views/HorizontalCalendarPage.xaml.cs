using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using AppTest.Models.Antonis;


namespace AppTest.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HorizontalCalendarPage : StackLayout
	{

        #region Bindable Property
        public static readonly BindableProperty SelectedDateProperty = BindableProperty.Create(
        nameof(SelectedDate),
        typeof(DateTime),
        declaringType: typeof(HorizontalCalendarPage),
        defaultBindingMode: BindingMode.TwoWay,
        defaultValue: DateTime.Now
         );


        public DateTime SelectedDate
        {
            get => (DateTime)GetValue(SelectedDateProperty);
            set => SetValue(SelectedDateProperty, value);
        }
        #endregion
        public ObservableCollection<CalendarModel> Dates { get; set; } = new ObservableCollection<CalendarModel>();
        public HorizontalCalendarPage ()
		{
			InitializeComponent ();
            
            BindDates(DateTime.Today);
        }


        private void BindDates(DateTime selectedDate)
        {
            var startingDate = FirstDayOfWeek(selectedDate);
            Console.WriteLine($"starting Date for calendar : {startingDate}");
            var startingDateDay = startingDate.Day;
            int daysCount = DateTime.DaysInMonth(startingDate.Year, startingDate.Month);
            for (int day = startingDateDay; day <= startingDateDay + 13; day++)
            {

                if (DateTime.DaysInMonth(startingDate.Year, startingDate.Month) < day)
                {

                    var newDayValue = day - DateTime.DaysInMonth(startingDate.Year, startingDate.Month);
                    var newyearValue = startingDate.AddYears(1).Year;
                    if (startingDate.Month == 12)
                    {
                        Dates.Add(new CalendarModel
                        {

                            Date = new DateTime(newyearValue, startingDate.AddMonths(1).Month, newDayValue)
                        });
                    }
                    else
                        Dates.Add(new CalendarModel
                        {

                            Date = new DateTime(startingDate.Year, startingDate.AddMonths(1).Month, newDayValue)
                        });
                }
                else
                {
                    Dates.Add(new CalendarModel
                    {
                        Date = new DateTime(startingDate.Year, startingDate.Month, day)
                    });
                }

            }
            Dates.Where(f => f.Date.Date == selectedDate.Date).FirstOrDefault().IsCurrentDate = true;


        }

        public static DateTime FirstDayOfWeek(DateTime date)
        {
            //var today = DateTime.Today;


            // create a culture in which first day of week is monday
            CultureInfo targetCulture = new CultureInfo("En-GB");
            var formattedDate = date.ToString("d", targetCulture);
            //convert todaydate to the same culture
            DateTime targetDate = DateTime.Parse(formattedDate, targetCulture);
            DayOfWeek fdow = targetCulture.DateTimeFormat.FirstDayOfWeek;
            //firstday of week minus date position in week
            var dayOfWeek = targetDate.DayOfWeek == 0 ? 7 : (int)targetDate.DayOfWeek;
            int offset = (int)fdow - dayOfWeek;
            DateTime fdowDate = date.AddDays(offset);
            return fdowDate;
        }

        #region Commands
        public ICommand CurrentdateCommand => new Command<CalendarModel>((currentDate) =>
        {

            SelectedDate = currentDate.Date;
            Dates.ToList().ForEach(f => f.IsCurrentDate = false);
            currentDate.IsCurrentDate = true;
        });

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            var tapEventArgs = (TappedEventArgs)e;
            var currentDate = (CalendarModel)tapEventArgs.Parameter;
            SelectedDate = currentDate.Date;
            Dates.ToList().ForEach(f => f.IsCurrentDate = false);
            currentDate.IsCurrentDate = true;

        }
        #endregion
    }
}