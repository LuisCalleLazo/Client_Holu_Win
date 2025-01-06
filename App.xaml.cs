using DotNetEnv;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Client_Holu_Win;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
  protected override void OnStartup(StartupEventArgs e)
  {
    Env.Load();
    base.OnStartup(e);
  }
}

