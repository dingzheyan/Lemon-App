﻿using Lemon_App.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lemon_App
{
    /// <summary>
    /// lemon.xaml 的交互逻辑
    /// </summary>
    public partial class lemon : Window
    {
        Timer t = new Timer();
        public lemon()
        {
            InitializeComponent();
            t.BeginInit();
            t.Elapsed += T_Elapsed;
            t.Interval = 1000;
            t.Start();
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            GC.Collect();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void CLOSE_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
        Boolean isopen = false;
        private void SSPath_Copy_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!isopen)
            {
                Litt.Data = Geometry.Parse("M10.85,8.145L7.607,4.902C7.412,4.707 7.095,4.707 6.9,4.902 6.705,5.097 6.705,5.414 6.9,5.609L9.791,8.5 6.9,11.391C6.705,11.586 6.705,11.903 6.9,12.098 7.095,12.293 7.412,12.293 7.607,12.098L10.85,8.856C10.949,8.757 10.997,8.628 10.996,8.501 10.996,8.371 10.948,8.243 10.85,8.145z");
                isopen = true;
                Width = 310;
                Height = 410;
                Page.Clip = new RectangleGeometry() { RadiusX = 3, RadiusY = 3, Rect = new Rect() { Width = Page.ActualWidth, Height = Page.ActualHeight } };
            }else
            {
                Litt.Data = Geometry.Parse("M7.209,8.5L10.1,5.609C10.295,5.414 10.295,5.097 10.1,4.902 9.905,4.707 9.588,4.707 9.393,4.902L6.15,8.145C6.052,8.243 6.004,8.371 6.004,8.5 6.004,8.629 6.052,8.757 6.15,8.855L9.393,12.097C9.588,12.292 9.905,12.292 10.1,12.097 10.295,11.902 10.295,11.585 10.1,11.39L7.209,8.5z");
                isopen = false;
                Width = 855;
                Height = 610;
                Page.Clip = new RectangleGeometry() { RadiusX = 3, RadiusY = 3, Rect = new Rect() { Width = Page.ActualWidth, Height = Page.ActualHeight } };
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {Page.Clip = new RectangleGeometry() { RadiusX = 3, RadiusY = 3, Rect = new Rect() { Width = Page.ActualWidth, Height = Page.ActualHeight } };
        //    (IContentPage.Child as UserControl).Width = IContentPage.ActualWidth;
           // (IContentPage.Child as UserControl).Height = ActualHeight;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if((sender as Border).ToolTip.ToString()== "小萌机器人")
            {
                BackgroundPage.Background = new SolidColorBrush(Color.FromArgb(255,253,253,253));
                BackgroundPage.Effect = new BlurEffect() { Radius = 0 };
                Robot.Visibility = Visibility.Visible;
                Music.Visibility = Visibility.Collapsed;
                User.Visibility = Visibility.Collapsed;
                All.Visibility = Visibility.Collapsed;
                //IContentPage.Children.Clear();
                //IContentPage.Children.Add(new IMBOX());
                Mus.Fill = new SolidColorBrush(Color.FromArgb(255, 180, 180, 193));
                ALL.Fill = new SolidColorBrush(Color.FromArgb(255, 180, 180, 193));
                Rbt.Fill = new SolidColorBrush(Color.FromArgb(255, 31, 183, 245));
            }
            else if((sender as Border).ToolTip.ToString() == "小萌音乐")
            {
                BackgroundPage.Background = new SolidColorBrush(Color.FromArgb(255, 253, 253, 253));
                BackgroundPage.Effect = new BlurEffect() { Radius = 0 };
                Robot.Visibility = Visibility.Collapsed;
                All.Visibility = Visibility.Collapsed;
                User.Visibility = Visibility.Collapsed;
                Music.Visibility = Visibility.Visible;
                //IContentPage.Children.Clear();
                //   IContentPage.Children.Add(new MusicControl());
                Mus.Fill = new SolidColorBrush(Color.FromArgb(255, 31, 183, 245));
                ALL.Fill = new SolidColorBrush(Color.FromArgb(255, 180, 180, 193));
                Rbt.Fill = new SolidColorBrush(Color.FromArgb(255, 180, 180, 193));
            }
            else if ((sender as Border).ToolTip.ToString() == "其他")
            {
                BackgroundPage.Background = new SolidColorBrush(Color.FromArgb(255, 253, 253, 253));
                BackgroundPage.Effect = new BlurEffect() { Radius = 0 };
                Robot.Visibility = Visibility.Collapsed;
                Music.Visibility = Visibility.Collapsed;
                User.Visibility = Visibility.Collapsed;
                All.Visibility = Visibility.Visible;
                //  IContentPage.Children.Clear();
                //IContentPage.Children.Add(new AllControl());
                Mus.Fill = new SolidColorBrush(Color.FromArgb(255, 180, 180, 193));
                ALL.Fill = new SolidColorBrush(Color.FromArgb(255, 31, 183, 245));
                Rbt.Fill = new SolidColorBrush(Color.FromArgb(255, 180, 180, 193));
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ZX.BeginAnimation(OpacityProperty, new DoubleAnimation(0.3, 1, TimeSpan.FromSeconds(1)) { AutoReverse = true });
            if (await Lemon_Updata.IsLemonNew(He.KMS))
                new UpdataWindow().Show();
            if (!Uuuhh.Lalala("www.mi.com"))
                ZX.Background = MIN.Background;
            else ZX.Background = MAX.Background;
            if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "UserImage.bmp"))
            { tx.Background = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "UserImage.bmp", UriKind.Absolute))); }
            DateTime tmCur = DateTime.Now;
            if (tmCur.Hour > 18 && tmCur.Hour < 24)
                Toast.SetToastNotion("晚上好:", "欢迎回来" + Settings.Default.RobotName, "------早睡早起身体好").Show();
            else if (tmCur.Hour >= 11 && tmCur.Hour < 12)
                Toast.SetToastNotion("中午好:", "欢迎回来" + Settings.Default.RobotName, "------中午啦~吃饭饭了~~").Show();
            else if (tmCur.Hour > 1 && tmCur.Hour < 5)
                Toast.SetToastNotion("凌晨好:", "欢迎回来" + Settings.Default.RobotName, "-----不乖哦，还没有睡觉~").Show();
            else if (tmCur.Hour > 6 && tmCur.Hour < 11)
                Toast.SetToastNotion("早上好:", "欢迎回来" + Settings.Default.RobotName, "-----一日之计在于晨，早上是最宝贵的时间哦~").Show();
            else if (tmCur.Hour > 13 && tmCur.Hour < 17)
                Toast.SetToastNotion("下午好:", "欢迎回来" + Settings.Default.RobotName, "------祝你今天好运！").Show();
            LemonWeather w = new LemonWeather(Settings.Default.WeatherInfo);
            Toast.SetToastNotion($"今日{w.WeatherName}天气", w.WeatherMessage, "-----来自柠檬天气Toast").Show();
        }

        private void tx_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //if (Email.Text != "")
            //{
            //    Random ra = new Random();
            //    ini = ra.Next().ToString();
            //    MailMessage m = new MailMessage()
            //    {
            //        From = new MailAddress("lemon.app@qq.com", "Lemon团队")
            //    };
            //    m.To.Add(new MailAddress(Email.Text));
            //    m.Subject = "Lemon App";
            //    m.SubjectEncoding = Encoding.UTF8;
            //    m.Body = He.EmailMessage.Replace("{ninini}", ini);
            //    m.BodyEncoding = Encoding.UTF8;
            //    m.IsBodyHtml = true;
            //    SmtpClient s = new SmtpClient()
            //    {
            //        Host = "smtp.qq.com",
            //        Port = 587,
            //        EnableSsl = true,
            //        Credentials = new NetworkCredential("lemon.app@qq.com", "qtmiqibczofmddbi")
            //    };
            //    s.Send(m);
            //}
            Robot.Visibility = Visibility.Collapsed;
            All.Visibility = Visibility.Collapsed;
            Music.Visibility = Visibility.Collapsed;
            User.Visibility = Visibility.Visible;
            Mus.Fill = new SolidColorBrush(Color.FromArgb(255, 180, 180, 193));
            ALL.Fill = new SolidColorBrush(Color.FromArgb(255, 180, 180, 193));
            Rbt.Fill = new SolidColorBrush(Color.FromArgb(255, 180, 180, 193));
            BackgroundPage.Background = User.TXIMAGE;
            BackgroundPage.Effect = new BlurEffect() { Radius = 80 };
        }
    }
}
