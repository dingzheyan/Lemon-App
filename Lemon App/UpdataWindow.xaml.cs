﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lemon_App
{
    /// <summary>
    /// UpdataWindow.xaml 的交互逻辑
    /// </summary>
    public partial class UpdataWindow : Window
    {
        public UpdataWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (textBlock1.Text != "下载更新中...")
            {
                WebClient dc = new WebClient();
                dc.DownloadFileAsync(new Uri("http://cname.lemonapp.tk/Setup.exe"), AppDomain.CurrentDomain.BaseDirectory + @"Setup.exe");
                dc.DownloadFileCompleted += OK;
                dc.DownloadProgressChanged += DownloadFileCompleted;
                textBlock1.Text = "下载更新中...";
            }
        }

        private void DownloadFileCompleted(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void OK(object sender, AsyncCompletedEventArgs e)
        {
            if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"Setup.exe"))
            { Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"Setup.exe"); Environment.Exit(0); }
            else Toast.SetToastNotion("Lemon App:", "啊哦 下载更新失败了", "-----来自Lemon Updata").Show();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.K.Text = await Lemon_Updata.NewText(He.KMS);
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void label1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
