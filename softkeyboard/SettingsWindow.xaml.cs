using System.IO;
using System.Windows;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iNKORE.UI.WPF.Modern.Controls;


namespace softkeyboard;

public partial class SettingsWindow : Window
{
    public bool StartOnStartup { get; set; }
    public class Settings
    {
        public bool startonstart { get; set; }
    }
    public SettingsWindow()
    {
        InitializeComponent();
        if (File.Exists(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Settings\\Settings.json"))
        {
            Settings settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Settings\\Settings.json"));
            StartOnStartupToggleSwitch.IsOn = settings.startonstart;
        }
    }

    private async void StartOnStartup_ToggleSwitch_OnToggled(object sender, RoutedEventArgs e)
    {
        Settings settings = new();
        var senderToggleSwitch = sender as ToggleSwitch;
        settings.startonstart = senderToggleSwitch.IsOn;
        Directory.CreateDirectory(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Settings\\");
        string fileName = "Settings\\Settings.json";
        await using FileStream createStream = File.Create(fileName);
        await System.Text.Json.JsonSerializer.SerializeAsync(createStream, settings);
    }
}