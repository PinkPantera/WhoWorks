using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WhoWorks.WpfCustomControlLibrary.Buttons
{
    public class IconTextButton : Button
    {
        public static readonly DependencyProperty IconSourceProperty =
            DependencyProperty.Register(nameof(IconSource), typeof(ImageSource), typeof(IconTextButton),
                new PropertyMetadata(default(ImageSource)));

        public static readonly DependencyProperty ContentOrientationProperty =
            DependencyProperty.Register(nameof(ContentOrientation), typeof(Orientation), typeof(IconTextButton),
                new PropertyMetadata(default(Orientation)));

        public static readonly DependencyProperty IconVisibilityProperty =
            DependencyProperty.Register(nameof(IconVisibility), typeof(Visibility), typeof(IconTextButton),
                new PropertyMetadata(default(Visibility)));

        public static readonly DependencyProperty IconWidthProperty =
            DependencyProperty.Register(nameof(IconWidth), typeof(double), typeof(IconTextButton),
                new PropertyMetadata((double)20));

        public static readonly DependencyProperty IconHeightProperty =
            DependencyProperty.Register(nameof(IconHeight), typeof(double), typeof(IconTextButton),
                new PropertyMetadata((double)40));

        public static readonly DependencyProperty TextVisibilityProperty =
            DependencyProperty.Register(nameof(TextVisibility), typeof(Visibility), typeof(IconTextButton),
                new PropertyMetadata(default(Visibility)));

        static IconTextButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IconTextButton), 
                new FrameworkPropertyMetadata(typeof(IconTextButton)));
        }

        public ImageSource IconSource
        {
            get { return (ImageSource)GetValue(IconSourceProperty); }
            set { SetValue(IconSourceProperty, value); }
        }

        public Orientation ContentOrientation
        {
            get { return (Orientation)GetValue(ContentOrientationProperty); }
            set { SetValue(ContentOrientationProperty, value); }
        }

        public Visibility IconVisibility
        {
            get { return (Visibility)GetValue(IconVisibilityProperty); }
            set { SetValue(IconVisibilityProperty, value); }
        }

        public double IconWidth
        {
            get { return (double)GetValue(IconWidthProperty); }
            set { SetValue(IconWidthProperty, value); }
        }

        public double IconHeight
        {
            get { return (double)GetValue(IconHeightProperty); }
            set { SetValue(IconHeightProperty, value); }
        }
        public Visibility TextVisibility
        {
            get { return (Visibility)GetValue(TextVisibilityProperty); }
            set { SetValue(TextVisibilityProperty, value); }
        }
    }
}
