using System;
using System.Collections.Generic;
using System.Text;

namespace AppTest.Models.Antonis
{
  public  class CalendarModel : PropertyChangeModel
    {
        public DateTime Date { get; set; }

        private bool _isCurrentDate;

        public bool IsCurrentDate
        {
            get => _isCurrentDate;
            set => SetProperty(ref _isCurrentDate, value);
        }
    }
}
