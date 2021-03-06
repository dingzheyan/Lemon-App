﻿using Lemon_App.Properties;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Lemon_App
{
    /// <summary>
    /// SearchBox.xaml 的交互逻辑
    /// </summary>
    public partial class SearchBox : UserControl
    {
        public SearchBox()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
                if (textBox1.Text != "")
                    Process.Start(Uri.EscapeUriString(Settings.Default.SearchUrl.Replace("%2a", textBox1.Text)));
                else
                    Toast.SetToastNotion("Lemon提示:", "尚未输入搜索内容", "-----来自Lemon Toast").Show();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (textBox1.Text != "")
                Process.Start(Uri.EscapeUriString(Settings.Default.SearchUrl.Replace("%2a", textBox1.Text)));
            else
                Toast.SetToastNotion("Lemon提示:", "尚未输入搜索内容", "-----来自Lemon Toast").Show();
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    if (textBox1.Text != "搜索")
                    {
                        HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create("http://suggestion.baidu.com/su?wd=" + Uri.EscapeDataString(textBox1.Text) + "&action=opensearch");
                        hwr.Proxy = He.proxy;
                        string html6 = "";
                        Stream sr = hwr.GetResponse().GetResponseStream();
                        byte[] b = new byte[1024];
                        sr.Read(b, 0, 1024);
                        html6 = Encoding.Default.GetString(b);
                        html6 = html6.Replace("\0", "");
                        string Htp = html6.Substring(html6.LastIndexOf(",[")).Replace("]]", "").Replace(",[", "").Replace(",", "");
                        string[] aa = Htp.Split(new char[] { '\"' }, StringSplitOptions.RemoveEmptyEntries);
                        listBox.Items.Clear();
                        foreach (var item in aa)
                        {
                            listBox.Items.Add(item);
                        }
                    }
                }
            }
            catch { }
        }

        private void UserControl_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
        }
    }
}
