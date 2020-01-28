using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;

namespace HAMS
{
  /// <summary>
  /// LoginWindow.xaml 的交互逻辑
  /// </summary>
  public partial class LoginWindow : Window
  {
    public LoginWindow()
    {
      InitializeComponent();
      CmbUserName.ItemsSource = SqlContext.Instance.Logins.ToList();
      CmbUserName.DisplayMemberPath = "Login_Name";
      CmbUserName.SelectedValuePath = "Id";
      if (CmbUserName.HasItems) CmbUserName.SelectedIndex = 0;
    }

    private void BtnLogin_Click(object sender, RoutedEventArgs e)
    {
      var login = SqlContext.Instance.Logins.FirstOrDefault(t => t.Id == Convert.ToInt32(CmbUserName.SelectedValue));
      if (login.Login_Pwd== PsdPass.Password)
      {
        MainWindow main = new MainWindow
        {
          Login = login
        };
        main.Show();
        Close();
      }
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }
  }
}
