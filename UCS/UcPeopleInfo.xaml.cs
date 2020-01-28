using System;
using System.Collections.Generic;
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
  /// UcPeopleInfo.xaml 的交互逻辑
  /// </summary>
  public partial class UcPeopleInfo : UserControl
  {
    public EUserType UserType { get;set; }//只有出租人和求租人两种类型
    private int CurId { get; set; }
    private readonly User NewUser = new User();
    public UcPeopleInfo()
    {
      InitializeComponent();
    }

    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
      if (UserType == EUserType.Want)
      {
        TxtTitle.Text = "求租人基本信息";
        BtnInputHouse.Visibility = Visibility.Collapsed;
      }
      else
      {
        TxtTitle.Text = "出租人基本信息";
        BtnInputHouse.Visibility = Visibility.Visible;
      }
      string maxid = SqlContext.Instance.Users.Where(s => s.User_Type == UserType.ToString()).Max(s => s.User_Id);
      if(maxid!=null)
      {
        CurId = Convert.ToInt32(maxid.Substring(4)) + 1;
      }
      else
      {
        CurId = 1000;
      }
    }

    private void BtnOK_Click(object sender, RoutedEventArgs e)
    {
      NewUser.User_Id = $"{UserType}{CurId}";
      NewUser.User_Name = TxtName.Text.Trim();
      NewUser.User_Phone = TxtPhone.Text.Trim();
      NewUser.User_HomePhone = TxtHomePhone.Text.Trim();
      NewUser.User_Birthday = (DateTime)DpkBrithday.SelectedDate;
      NewUser.User_Sex = CmbSex.Text;
      NewUser.User_Type = UserType.ToString();
      NewUser.User_CardId = TxtCardID.Text.Trim();
      NewUser.User_RecordDate = DateTime.Now;
      NewUser.User_Email = TxtEmail.Text.Trim();
      SqlContext.Instance.Users.Add(NewUser);
    }

    private void BtnInputHouse_Click(object sender, RoutedEventArgs e)
    {
      UcHouse house = new UcHouse();
      GrdUc.Children.Add(house);
    }

    private void BtnClear_Click(object sender, RoutedEventArgs e)
    {

    }

    private void UserControl_Unloaded(object sender, RoutedEventArgs e)
    {
      SqlContext.Instance.SaveChangesAsync();
    }
  }
}
