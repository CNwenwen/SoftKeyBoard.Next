﻿using System.Configuration;
using System.Data;
using System.Windows;

namespace softkeyboard;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        // 显示启动画面
        ShowSplashScreen();
    }

    private void ShowSplashScreen()
    {
        // 这里要注意的点就是StartFlash.jpg 要设置为资源.
        SplashScreen splash = new SplashScreen(@"Desktop - 1@1x.png");
        /*
         * 第一个参数表示是否自动关闭
         * 第二个参数表示启动画面窗口是否会被置于顶层,即使有其他程序的窗口处于活动状态,
         * 启动画面也会显示在它们之上.
         * 如果设置为false,表示遵循正常的窗口焦点规则,如果用户切换到其他程序,
         * 启动画面可能会被其他窗口遮挡.
         * 如果设置为true,保证用户一直能够看到它.
         */
        splash.Show(true, true);
    }
}