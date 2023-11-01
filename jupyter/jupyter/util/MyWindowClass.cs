﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace jupyter.util
{
    internal abstract class MyWindowClass // 抽象类，不支持实例化
    {
        public static void 关闭非指定窗口(List<string> wn)
        {
            // 遍历并关闭所有子窗口
            Window[] childArray = Application.Current.Windows.Cast<Window>().ToArray();
            for (int i = childArray.Length; i-- > 0;)
            {
                Window item = childArray[i];
                if (item.Title == "") continue; // 忽略无标题窗口
                if (wn.Contains(item.Title) == false) item.Close();
            }
        }

        public static void 隐藏非指定窗口(string wn)
        {
            // 遍历并关闭所有子窗口
            Window[] childArray = Application.Current.Windows.Cast<Window>().ToArray();
            for (int i = childArray.Length; i-- > 0;)
            {
                Window item = childArray[i];
                if (item.Title == "") continue; // 忽略无标题窗口
                if (item.Title != wn) item.Hide();
            }
        }
    }

    // 仅适用于不传参数的窗口
    public class WindowsManager<TWindow> where TWindow : System.Windows.Window, new()
    {
        static TWindow window;

        public static void Show(object vm)
        {
            if (window == null)
            {
                window = new TWindow();
                window.Closing += new CancelEventHandler(onClosing);
            }
            // 更新DataContext
            window.DataContext = vm;
            WindowsManager<TWindow>.window.Show();
            // 再次打开窗口时需要激活
            WindowsManager<TWindow>.window.Activate();
        }

        static void onClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            window = null;
        }

    }
}
