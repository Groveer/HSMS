using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HAMS.UCS
{
  /// <summary>
  /// UcPeopleList.xaml 的交互逻辑
  /// </summary>
  public partial class UcPeopleList : UserControl
  {
    private readonly ObservableCollection<User> Users;
    private User SelectUser {get;set;}
    public UcPeopleList()
    {
      InitializeComponent();
      SqlContext.Instance.Users.ToList();
      Users = SqlContext.Instance.Users.Local.ToObservableCollection();
      DgUser.ItemsSource = Users;
    }

    private void DgUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      SelectUser = DgUser.SelectedItem as User;
      if(SelectUser!=null)
      {
        BtnDelete.IsEnabled= BtnChange.IsEnabled = true;
        if (SelectUser.User_Type == EUserType.Lend.ToString())
          ShowLend();
        if (SelectUser.User_Type == EUserType.Want.ToString())
          ShowWant();
      }
      else
      {
        BtnDelete.IsEnabled = BtnChange.IsEnabled = false;
      }
    }
    private void ShowLend()
    {
      TabMsg.SelectedIndex = 0;
      TabLend.DataContext = SelectUser;
    }
    private void ShowWant()
    {
      TabMsg.SelectedIndex = 1;
      TabWant.DataContext = SelectUser;
    }

    private void BtnChange_Click(object sender, RoutedEventArgs e)
    {
      SqlContext.Instance.Users.Update(SelectUser);
    }

    private void TabMsg_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (TabMsg.SelectedIndex == 0)
      {
        DgUser.ItemsSource = Users.Where(s=>s.User_Type==EUserType.Lend.ToString());
      }
      else
      {
        DgUser.ItemsSource = Users.Where(s => s.User_Type == EUserType.Want.ToString());
      }
    }

    private void UserControl_Unloaded(object sender, RoutedEventArgs e)
    {
      SqlContext.Instance.SaveChangesAsync();
    }

    private void BtnDelete_Click(object sender, RoutedEventArgs e)
    {
      SqlContext.Instance.Users.Remove(SelectUser);
    }

    private void BtnSearch_Click(object sender, RoutedEventArgs e)
    {

    }
  }

}
