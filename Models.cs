using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace HAMS
{
  public static class Global
  {
    public static string DbSource = $"Data Source={System.IO.Directory.GetCurrentDirectory()}/Data.db";
  }
  public class SqlContext : DbContext
  {
    public static SqlContext Instance = new SqlContext();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite(Global.DbSource);
    }
    public DbSet<Login> Logins { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<House> Houses { get; set; }
    public DbSet<Type> Types { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<Fitment> Fitments { get; set; }
    public DbSet<Favor> Favors { get; set; }
    public DbSet<Method> Methods { get; set; }
    public DbSet<Floor> Floors { get; set; }
  }

  /// <summary>
  /// 用户类型，分求租人和出租人
  /// </summary>
  public enum EUserType { Want, Lend }
  /// <summary>
  /// 登录信息表
  /// </summary>
  public class Login
  {
    public int Id { get; set; }
    /// <summary>
    /// 登录Id
    /// </summary>
    public string Login_Id { get; set; }
    /// <summary>
    /// 员工Id
    /// </summary>
    public string Employee_Id { get; set; }
    /// <summary>
    /// 登录名
    /// </summary>
    public string Login_Name { get; set; }
    /// <summary>
    /// 登录密码
    /// </summary>
    public string Login_Pwd { get; set; }
    /// <summary>
    /// 权限
    /// </summary>
    public string Login_Power { get; set; }
  }

  /// <summary>
  /// 客户信息表
  /// </summary>
  public class User
  {
    public int Id { get; set; }
    /// <summary>
    /// 客户编号
    /// </summary>
    public string User_Id { get; set; }
    /// <summary>
    /// 姓名
    /// </summary>
    public string User_Name { get; set; }
    /// <summary>
    /// 性别
    /// </summary>
    public string User_Sex { get; set; }
    /// <summary>
    /// 生日
    /// </summary>
    public DateTime User_Birthday { get; set; }
    /// <summary>
    /// 手机号
    /// </summary>
    public string User_Phone { get; set; }
    /// <summary>
    /// 固话
    /// </summary>
    public string User_HomePhone { get; set; }
    /// <summary>
    /// Email
    /// </summary>
    public string User_Email { get; set; }
    /// <summary>
    /// 身份证
    /// </summary>
    public string User_CardId { get; set; }
    /// <summary>
    /// 用户类型
    /// </summary>
    public string User_Type { get; set; }
    /// <summary>
    /// 房屋编号
    /// </summary>
    public string House_Id { get; set; }
    /// <summary>
    /// 记录日期
    /// </summary>
    public DateTime User_RecordDate { get; set; }
  }

  /// <summary>
  /// 房源信息表
  /// </summary>
  public class House
  {
    public int Id { get; set; }
    /// <summary>
    /// 房屋编号
    /// </summary>
    public string House_Id { get; set; }
    /// <summary>
    /// 物业名称
    /// </summary>
    public string House_CompanyName { get; set; }
    /// <summary>
    /// 房型编号
    /// </summary>
    public string House_TypeId { get; set; }
    /// <summary>
    /// 幢/座编号
    /// </summary>
    public string House_SeatId { get; set; }
    /// <summary>
    /// 状态
    /// </summary>
    public string House_State { get; set; }
    /// <summary>
    /// 装修编号
    /// </summary>
    public string House_FitmentId { get; set; }
    /// <summary>
    /// 朝向编号
    /// </summary>
    public string House_FavorId { get; set; }
    /// <summary>
    /// 用途编号
    /// </summary>
    public string House_MothedId { get; set; }
    /// <summary>
    /// 结构图
    /// </summary>
    public string House_Map { get; set; }
    /// <summary>
    /// 价格
    /// </summary>
    public double House_Price { get; set; }
    /// <summary>
    /// 楼层编号
    /// </summary>
    public string House_FloorId { get; set; }
    /// <summary>
    /// 建筑年限
    /// </summary>
    public string House_BuildYear { get; set; }
    /// <summary>
    /// 建筑面积
    /// </summary>
    public string House_Area { get; set; }
    /// <summary>
    /// 备注
    /// </summary>
    public string House_Remark { get; set; }
    /// <summary>
    /// 用户编号
    /// </summary>
    public string User_Id { get; set; }
  }

  /// <summary>
  /// 房型信息表
  /// </summary>
  public class Type
  {
    public int Id { get; set; }
    public string House_TypeId { get; set; }
    public string Type_Name { get; set; }
    public string Type_Remark { get; set; }
  }

  /// <summary>
  /// 朝向信息表
  /// </summary>
  public class Favor
  {
    public int Id { get; set; }
    public string House_FavorId { get; set; }
    public string Favor_Name { get; set; }
    public string Favor_Remark { get; set; }
  }

  /// <summary>
  /// 装修信息表
  /// </summary>
  public class Fitment
  {
    public int Id { get; set; }
    public string House_FitmentId { get; set; }
    public string Fitment_Name { get; set; }
    public string Fitment_Remark { get; set; }
  }

  /// <summary>
  /// 楼层信息表
  /// </summary>
  public class Floor
  {
    public int Id { get; set; }
    public string House_FloorId { get; set; }
    public string Floor_Name { get; set; }
    public string Floor_Remark { get; set; }
  }
  public class Method
  {
    public int Id { get; set; }
    public string House_MothedId { get; set; }
    public string Mothed_Name { get; set; }
    public string Mothed_Remark { get; set; }
  }

  public class Seat
  {
    public int Id { get; set; }
    public string House_SeatId { get; set; }
    public string Seat_Name { get; set; }
    public string Seat_Remark { get; set; }
  }

  /// <summary>
  /// 民族信息表
  /// </summary>
  public class Gov
  {
    public int Id { get; set; }
    public string Gov_Id { get; set; }
    public string Gov_Name { get; set; }
    public string Gov_Remark { get; set; }
  }
  /// <summary>
  /// 意向信息表
  /// </summary>
  public class Intent
  {
    public int Id { get; set; }
    public string Intent_Id { get; set; }
    /// <summary>
    /// 求租人编号
    /// </summary>
    public string UserId { get; set; }
    public string House_TypeId { get; set; }
    public string House_SeatId { get; set; }
    public string House_FitmentId { get; set; }
    public string House_FloorId { get; set; }
    public string House_MothedId { get; set; }
    public string House_Price { get; set; }
    public string House_Area { get; set; }
  }
  public class Log
  {
    public int Id { get; set; }

    public string Log_Id { get; set; }
    public string Login_Name { get; set; }
    public string Login_Pwd { get; set; }
    public string Login_Time { get; set; }
  }

  /// <summary>
  /// 费用信息表
  /// </summary>
  public class MoneyInfo
  {
    public int Id { get; set; }
    public string Money_Id { get; set; }
    public double Pay_Money { get; set; }
    public string Employee_Id { get; set; }
    public string House_Id { get; set; }
    public DateTime Pay_Date { get; set; }
    public string Money_Remark { get; set; }
    public string Lend_Id { get; set; }
    public string Want_Id { get; set; }
  }

  /// <summary>
  /// 学历信息表
  /// </summary>
  public class Education
  {
    public int Id { get; set; }
    public string Education_Id { get; set; }
    public string Education_Name { get; set; }
    public string Education_Remark { get; set; }
  }
}
