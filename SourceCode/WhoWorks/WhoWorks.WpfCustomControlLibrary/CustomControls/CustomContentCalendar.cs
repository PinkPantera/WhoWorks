using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WhoWorks.WpfCustomControlLibrary.Buttons;

namespace WhoWorks.WpfCustomControlLibrary.CustomControls
{
    public class CustomContentCalendar : ContentControl
    {
        public static readonly DependencyProperty TitleProperty = 
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(CustomContentCalendar));
        public static readonly DependencyProperty BodyProperty =
           DependencyProperty.Register(nameof(Body), typeof(string), typeof(CustomContentCalendar));
        public static readonly DependencyProperty HoursAmProperty=
            DependencyProperty.Register(nameof(HoursAm), typeof (string), typeof (CustomContentCalendar));
        public static readonly DependencyProperty HoursPmProperty =
         DependencyProperty.Register(nameof(HoursPm), typeof(string), typeof(CustomContentCalendar));

        static CustomContentCalendar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomContentCalendar),
                new FrameworkPropertyMetadata(typeof(CustomContentCalendar)));
        }
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public string Body
        {
            get { return (string)GetValue(BodyProperty); }
            set { SetValue(BodyProperty, value); }
        }
        public string HoursAm
        {
            get { return (string)GetValue(HoursAmProperty); }
            set { SetValue(HoursAmProperty, value); }
        }
        public string HoursPm
        {
            get { return (string)GetValue(HoursPmProperty); }
            set { SetValue(HoursPmProperty, value); }
        }
    }
}
