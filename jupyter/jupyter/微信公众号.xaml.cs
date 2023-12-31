﻿using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace jupyter
{
    /// <summary>
    /// 微信公众号.xaml 的交互逻辑
    /// </summary>
    public partial class 微信公众号 : Window
    {
        public 微信公众号()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += (s, e) => { this.Close(); };

            // 右下角显示
            var r = SystemParameters.WorkArea;
            this.Left = r.Right - ActualWidth;
            this.Top = r.Bottom - ActualHeight;
            this.SizeChanged += (o, e) =>
            {
                var r = SystemParameters.WorkArea;
                this.Left = r.Right - ActualWidth;
                this.Top = r.Bottom - ActualHeight;
            };
        }

    }
}
