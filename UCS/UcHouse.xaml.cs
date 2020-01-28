using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;

namespace HAMS.UCS
{
  /// <summary>
  /// UcHouse.xaml 的交互逻辑
  /// </summary>
  public partial class UcHouse : UserControl
  {
    public string HouseId { get; set; }
    public UcHouse()
    {
      InitializeComponent();
      Loaded += UcHouse_Loaded;
      GrpResult.Visibility = Visibility.Hidden;
    }

    private void UcHouse_Loaded(object sender, RoutedEventArgs e)
    {
      if(string.IsNullOrEmpty(HouseId))
      {
        HouseId = "hou1000";
      }
      else
      {
        string id = SqlContext.Instance.Houses.Max(s => s.House_Id);
        HouseId =$"hou{Convert.ToInt32(id.Substring(3)) + 1}";
      }
      TxtHouseInfo.Text = HouseId;
      CmbType.ItemsSource = SqlContext.Instance.Types.ToList();
      CmbType.DisplayMemberPath = "Type_Name";
      CmbType.SelectedValuePath = "Id";
      CmbFloor.ItemsSource = SqlContext.Instance.Floors.ToList();
      CmbFloor.DisplayMemberPath = "Floor_Name";
      CmbFloor.SelectedValuePath = "Id";
      CmbFavor.ItemsSource = SqlContext.Instance.Favors.ToList();
      CmbFavor.DisplayMemberPath = "Favor_Name";
      CmbFavor.SelectedValuePath = "Id";
      CmbSeat.ItemsSource = SqlContext.Instance.Seats.ToList();
      CmbSeat.DisplayMemberPath = "Seat_Name";
      CmbSeat.SelectedValuePath = "Id";
      CmbMethod.ItemsSource = SqlContext.Instance.Methods.ToList();
      CmbMethod.DisplayMemberPath = "Method_Name";
      CmbMethod.SelectedValuePath = "Id";
      CmbFitment.ItemsSource = SqlContext.Instance.Fitments.ToList();
      CmbFitment.DisplayMemberPath = "Fitment_Name";
      CmbFitment.SelectedValuePath = "Id";
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
      if(Parent is UniformGrid grid)
      {
        grid.Children.Clear();
      }
    }
    private short SelectInfo { get; set; }
    private void BtnInfo_Click(object sender, RoutedEventArgs e)
    {
      Button ui = sender as Button;
      Pop.PlacementTarget = ui;
      switch (ui.Name)
      {
        case "BtnType":
          TxtInfoLbl.Text = "房型：";
          Pop.IsOpen = true;
          SelectInfo = 0;
          break;
        case "BtnFloor":
          TxtInfoLbl.Text = "楼层：";
          Pop.IsOpen = true;
          SelectInfo = 1;
          break;
        case "BtnFavor":
          TxtInfoLbl.Text = "朝向：";
          Pop.IsOpen = true;
          SelectInfo = 2;
          break;
        case "BtnSeat":
          TxtInfoLbl.Text = "幢/座：";
          Pop.IsOpen = true;
          SelectInfo = 3;
          break;
        case "BtnMothed":
          TxtInfoLbl.Text = "用途：";
          Pop.IsOpen = true;
          SelectInfo = 4;
          break;
        case "BtnFitment":
          TxtInfoLbl.Text = "装修：";
          Pop.IsOpen = true;
          SelectInfo = 5;
          break;

      }
    }

    private void BtnAdd_Click(object sender, RoutedEventArgs e)
    {
      if(!string.IsNullOrEmpty(TxtId.Text.Trim())&&!string.IsNullOrEmpty(TxtInfo.Text.Trim()))
      {
        switch (SelectInfo)
        {
          case 0:

            break;
          case 1:
            break;
          case 2:
            break;
          case 3:
            break;
          case 4:
            break;
          case 5:
            break;
        }
      }
      else
      {
        MessageBox.Show("请输入编号和名称！");
      }
    }

    private void BtnUpdate_Click(object sender, RoutedEventArgs e)
    {
      if (!string.IsNullOrEmpty(TxtId.Text.Trim()) && !string.IsNullOrEmpty(TxtInfo.Text.Trim()))
      {
        switch (SelectInfo)
        {
          case 0:

            break;
          case 1:
            break;
          case 2:
            break;
          case 3:
            break;
          case 4:
            break;
          case 5:
            break;
        }
      }
      else
      {
        MessageBox.Show("请输入编号和名称！");
      }
    }

    private void BtnDelete_Click(object sender, RoutedEventArgs e)
    {
      if (!string.IsNullOrEmpty(TxtId.Text.Trim()) && !string.IsNullOrEmpty(TxtInfo.Text.Trim()))
      {
        switch (SelectInfo)
        {
          case 0:

            break;
          case 1:
            break;
          case 2:
            break;
          case 3:
            break;
          case 4:
            break;
          case 5:
            break;
        }
      }
      else
      {
        MessageBox.Show("请输入编号和名称！");
      }
    }

    /// <summary>
    /// 更改Info
    /// </summary>
    /// <param name="n">值为1 2 3</param>
    private void ChangeInfo(short n)
    {
      if(n==3)
      if (!string.IsNullOrEmpty(TxtId.Text.Trim()) && !string.IsNullOrEmpty(TxtInfo.Text.Trim()))
      {
        switch (SelectInfo)
        {
          case 0:

            break;
          case 1:
            break;
          case 2:
            break;
          case 3:
            break;
          case 4:
            break;
          case 5:
            break;
        }
      }
      else
      {
        MessageBox.Show("请输入编号和名称！");
      }
    }
  }
}
