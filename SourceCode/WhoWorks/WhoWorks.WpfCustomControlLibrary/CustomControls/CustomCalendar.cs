using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WhoWorks.WpfCustomControlLibrary.CustomControls
{
    public class CustomCalendar : ItemsControl
    {
        public static readonly DependencyProperty ColumnIndexProperty
            = DependencyProperty.Register(nameof(ColumnIndex), typeof(int), typeof(CustomCalendar));
        public static readonly DependencyProperty RowIndexProperty
          = DependencyProperty.Register(nameof(RowIndex), typeof(int), typeof(CustomCalendar));
        public static readonly DependencyProperty HeadersProperty
            = DependencyProperty.Register(nameof(Headers), typeof(IEnumerable), typeof(CustomCalendar));

        static CustomCalendar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomCalendar),
                new FrameworkPropertyMetadata(typeof(CustomCalendar)));
        }

        public CustomCalendar()
        {
            Headers = new List<DayOfWeek>();
            for (int i = 0; i < 6; i++)
            {
                Headers.Add(new(i, System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.DayNames[i + 1]));
            }

            Headers.Add(new(6, System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.DayNames[0]));
        }

        public int ColumnIndex
        {
            get
            {
                return (int)GetValue(ColumnIndexProperty);
            }
            set
            {
                SetValue(ColumnIndexProperty, value);
            }
        }
        public int RowIndex
        {
            get
            {
                return (int)GetValue(RowIndexProperty);
            }
            set
            {
                SetValue(RowIndexProperty, value);
            }
        }
        public IList<DayOfWeek> Headers
        {
            get
            {
                return (IList<DayOfWeek>)GetValue(HeadersProperty);
            }
            set
            {
                SetValue(HeadersProperty, value);
            }
        }

    }
}
