using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Planet
{
    public partial class MainWindow : Window
    {
        #region Anims
        private Storyboard storyboard;
        private IEasingFunction EasingFunc { get; set; } = new QuarticEase
        {
            EasingMode = EasingMode.EaseInOut
        };
        private void FadeIn(DependencyObject Object)
        {
            DoubleAnimation doubleanimation = new DoubleAnimation();
            doubleanimation.From = 0.0;
            doubleanimation.To = 1.0;
            doubleanimation.EasingFunction = EasingFunc;
            doubleanimation.Duration = new Duration(TimeSpan.FromMilliseconds(1000.0));
            storyboard = new Storyboard();
            storyboard.Children.Add(doubleanimation);
            Storyboard.SetTarget(doubleanimation, Object);
            Storyboard.SetTargetProperty(doubleanimation, new PropertyPath(FrameworkElement.OpacityProperty));
            this.storyboard.Children.Add(doubleanimation);
            storyboard.Begin();
            storyboard.Children.Remove(doubleanimation);
        }
        private void FadeOut(DependencyObject Object)
        {
            DoubleAnimation doubleanimation = new DoubleAnimation();
            doubleanimation.From = 1.0;
            doubleanimation.To = 0.0;
            doubleanimation.EasingFunction = EasingFunc;
            doubleanimation.Duration = new Duration(TimeSpan.FromMilliseconds(600.0));
            storyboard = new Storyboard();
            storyboard.Children.Add(doubleanimation);
            Storyboard.SetTarget(doubleanimation, Object);
            Storyboard.SetTargetProperty(doubleanimation, new PropertyPath(FrameworkElement.OpacityProperty));
            this.storyboard.Children.Add(doubleanimation);
            storyboard.Begin();
            storyboard.Children.Remove(doubleanimation);
        }
        private void Slide(DependencyObject Object, Thickness from, Thickness to)
        {
            ThicknessAnimation thicknessanimation = new ThicknessAnimation();
            thicknessanimation.From = new Thickness?(from);
            thicknessanimation.To = new Thickness?(to);
            thicknessanimation.EasingFunction = EasingFunc;
            thicknessanimation.Duration = new Duration(TimeSpan.FromMilliseconds(1200.0));
            storyboard = new Storyboard();
            storyboard.Children.Add(thicknessanimation);
            Storyboard.SetTarget(thicknessanimation, Object);
            Storyboard.SetTargetProperty(thicknessanimation, new PropertyPath(FrameworkElement.MarginProperty));
            this.storyboard.Children.Add(thicknessanimation);
            storyboard.Begin();
            storyboard.Children.Remove(thicknessanimation);
        }
        private void HeightTo(DependencyObject Object, double from, double to)
        {
            DoubleAnimation doubleanimation = new DoubleAnimation();
            doubleanimation.From = from;
            doubleanimation.To = to;
            doubleanimation.EasingFunction = EasingFunc;
            doubleanimation.Duration = new Duration(TimeSpan.FromMilliseconds(600.0));
            storyboard = new Storyboard();
            storyboard.Children.Add(doubleanimation);
            Storyboard.SetTarget(doubleanimation, Object);
            Storyboard.SetTargetProperty(doubleanimation, new PropertyPath(FrameworkElement.HeightProperty));
            this.storyboard.Children.Add(doubleanimation);
            storyboard.Begin();
            storyboard.Children.Remove(doubleanimation);
        }
        private void WidthTo(DependencyObject Object, double from, double to)
        {
            DoubleAnimation doubleanimation = new DoubleAnimation();
            doubleanimation.From = from;
            doubleanimation.To = to;
            doubleanimation.EasingFunction = EasingFunc;
            doubleanimation.Duration = new Duration(TimeSpan.FromMilliseconds(1000.0));
            storyboard = new Storyboard();
            storyboard.Children.Add(doubleanimation);
            Storyboard.SetTarget(doubleanimation, Object);
            Storyboard.SetTargetProperty(doubleanimation, new PropertyPath(FrameworkElement.WidthProperty));
            this.storyboard.Children.Add(doubleanimation);
            storyboard.Begin();
            storyboard.Children.Remove(doubleanimation);
        }
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            NewNotification("Planet", "Planet succesfully loaded, enjoy.", "Debug");
            NewNotification("Planet", "Planet succesfully loaded, enjoy.", "Debug");
        }

        private void moveWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
   
        public async void NewNotification(string Title, string Desc, string NotificationType)
        {
            int queue = 0;
            queue++;
            switch (queue)
            {
                case 0:
                
                    break;
                case 1:

                    //
                    break;
            }
            var imageBrush = (ImageBrush)statusimage.Background;
            switch (NotificationType)
            { 
                case "Info":
                    var filename = "https://cdn.discordapp.com/attachments/883506179806990436/888078252894224404/outline_info_white_24dp.png";
                    imageBrush.ImageSource = new BitmapImage(new Uri(filename, UriKind.Absolute));
                    break;
             
                case "Debug":
                    var filename2 = "https://cdn.discordapp.com/attachments/883506179806990436/888078253003247636/outline_bug_report_white_24dp.png";
                    imageBrush.ImageSource = new BitmapImage(new Uri(filename2, UriKind.Absolute));
                    break;
                case "Error":
                    var filename3 = "https://cdn.discordapp.com/attachments/883506179806990436/888078255851180132/outline_error_outline_white_24dp.png";
                    imageBrush.ImageSource = new BitmapImage(new Uri(filename3, UriKind.Absolute));
                    break;
                case "Idea":
                    var filename4 = "https://cdn.discordapp.com/attachments/883506179806990436/888078254559358996/outline_lightbulb_white_24dp.png";
                    imageBrush.ImageSource = new BitmapImage(new Uri(filename4, UriKind.Absolute));
                    break;
            }
            titletxt.Content = Title + " - " + NotificationType;
            desctxt.Content = Desc;
            await Task.Delay(2000);
            FadeIn(popup);
            Slide(popup, new Thickness(117.563, 288.729, 116.436, -33.842), new Thickness(117.293, 242.481, 116.166, 12.406));
            await Task.Delay(3000);
            WidthTo(bar, 0, 226);
            await Task.Delay(2000);
            Slide(popup,new Thickness(117.293, 242.481, 116.166, 12.406), new Thickness(117.563, 288.729, 116.436, -33.842));
            FadeOut(popup);
          
        }

        private async void Init(object sender, EventArgs e)
        {
            subroot.Opacity = 0;
            this.Topmost = true;
            Slide(root, new Thickness(900), new Thickness(10));
            FadeIn(root);
            FadeIn(root);
            await Task.Delay(1500);
            Topmost = false;
            FadeIn(subroot);
          
        }
        // To 117.293,242.481,116.166,12.406
        // From 117.563,288.729,116.436,-33.842
    }
}
