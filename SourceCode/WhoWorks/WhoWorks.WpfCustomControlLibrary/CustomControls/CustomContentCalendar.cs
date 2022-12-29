using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WhoWorks.WpfCustomControlLibrary.Buttons;

namespace WhoWorks.WpfCustomControlLibrary.CustomControls
{
    public class CustomContentCalendar : ContentControl
    {
        public static readonly DependencyProperty TitleProperty = 
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(CustomContentCalendar));
        public static readonly DependencyProperty BodyProperty =
           DependencyProperty.Register(nameof(Body), typeof(string), typeof(CustomContentCalendar));
        public static readonly DependencyProperty HoursProperty =
          DependencyProperty.Register(nameof(Hours), typeof(List<AssignedHours>), typeof(CustomContentCalendar));
        public static readonly DependencyProperty ActivateDayCommandProperty = 
            DependencyProperty.Register(nameof(ActivateDayCommand), typeof(ICommand), typeof(CustomContentCalendar), null);
        public static readonly DependencyProperty CommandParameterProperty = 
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(CustomContentCalendar), null);

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
        public List<AssignedHours> Hours
        {
            get { return (List<AssignedHours>)GetValue(HoursProperty); }
            set { SetValue(HoursProperty, value); }
        }
        public ICommand ActivateDayCommand
        {
            get
            {
                return (ICommand)GetValue(ActivateDayCommandProperty);
            }
            set
            {
                SetValue(ActivateDayCommandProperty, value);
            }
        }
        public object CommandParameter
        {
            get
            {
                return GetValue(CommandParameterProperty);
            }
            set
            {
                SetValue(CommandParameterProperty, value);
            }
        }
    }
}
