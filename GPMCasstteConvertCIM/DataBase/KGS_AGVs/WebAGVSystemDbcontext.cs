using System;
using System.Collections.Generic;
using GPMCasstteConvertCIM.DataBase.KGS_AGVs.Models;
using Microsoft.EntityFrameworkCore;

namespace GPMCasstteConvertCIM.DataBase.KGS_AGVs;

public partial class WebAGVSystemDbcontext : DbContext
{
    public WebAGVSystemDbcontext(DbContextOptions<WebAGVSystemDbcontext> options)
        : base(options)
    {
    }

    public virtual DbSet<AGVInfo> AGVInfos { get; set; }

    public virtual DbSet<AGVRemoteSetting> AGVRemoteSettings { get; set; }

    public virtual DbSet<AlarmLog> AlarmLogs { get; set; }

    public virtual DbSet<BatterySet> BatterySets { get; set; }

    public virtual DbSet<ExecutingSkdTask> ExecutingSkdTasks { get; set; }

    public virtual DbSet<ExecutingTask> ExecutingTasks { get; set; }

    public virtual DbSet<MeasureInfo> MeasureInfos { get; set; }

    public virtual DbSet<OccurringAlarm> OccurringAlarms { get; set; }

    public virtual DbSet<PMHistory> PMHistories { get; set; }

    public virtual DbSet<PMSetting> PMSettings { get; set; }

    public virtual DbSet<PathInfo> PathInfos { get; set; }

    public virtual DbSet<ProductInfo> ProductInfos { get; set; }

    public virtual DbSet<RunStatusChange> RunStatusChanges { get; set; }

    public virtual DbSet<SkdTask> SkdTasks { get; set; }

    public virtual DbSet<TaskDto> Tasks { get; set; }

    public virtual DbSet<TrafficTask> TrafficTasks { get; set; }

    public virtual DbSet<UserGroup> UserGroups { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    public virtual DbSet<UserLoginLog> UserLoginLogs { get; set; }

    public virtual DbSet<ver> vers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AGVInfo>(entity =>
        {
            entity.HasKey(e => e.AGVID);

            entity.ToTable("AGVInfo");

            entity.Property(e => e.AGVID).ValueGeneratedNever();
            entity.Property(e => e.AGVName).HasMaxLength(50);
            entity.Property(e => e.AlarmDescription)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CSTID)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.DoTaskName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.E82VehicleState)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AGVRemoteSetting>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AGVRemoteSetting");
        });

        modelBuilder.Entity<AlarmLog>(entity =>
        {
            entity.HasKey(e => new { e.OccuredDate, e.AlarmCode });

            entity.ToTable("AlarmLog");

            entity.Property(e => e.OccuredDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.FinishDate).HasColumnType("datetime");
            entity.Property(e => e.Location)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.OPID)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Owner)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TaskName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BatterySet>(entity =>
        {
            entity.HasKey(e => e.AGVID).HasName("PK_BatterySet_1");

            entity.ToTable("BatterySet");

            entity.Property(e => e.AGVID).ValueGeneratedNever();
        });

        modelBuilder.Entity<ExecutingSkdTask>(entity =>
        {
            entity.HasKey(e => e.CommandID).HasName("PK__Executin__6B4108E6FC5A9447");

            entity.ToTable("ExecutingSkdTask");

            entity.Property(e => e.CommandID)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Bay)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FinishedPoints)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MeasurePoints)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PatrolPoints)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Schedule_Time).HasColumnType("datetime");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<ExecutingTask>(entity =>
        {
            entity.HasKey(e => e.Name);

            entity.ToTable("ExecutingTask");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AcquireTime).HasColumnType("datetime");
            entity.Property(e => e.ActionType)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.AssignUserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CSTID)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.DepositTime).HasColumnType("datetime");
            entity.Property(e => e.FromStation)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.FromStationName)
                .HasMaxLength(30)
                .IsRequired(false)
                .IsUnicode(false);
            entity.Property(e => e.Receive_Time).HasColumnType("datetime");
            entity.Property(e => e.StartTime).HasColumnType("datetime")
                .IsRequired(false);
            entity.Property(e => e.AcquireTime).HasColumnType("datetime")
                .IsRequired(false);
            entity.Property(e => e.DepositTime).HasColumnType("datetime")
                .IsRequired(false);
            entity.Property(e => e.ToStation)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ToStationName)
                .HasMaxLength(30)
                .IsRequired(false)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MeasureInfo>(entity =>
        {
            entity.HasKey(e => e.CommandID).HasName("PK__MeasureI__6B4108E638B57D6A");

            entity.ToTable("MeasureInfo");

            entity.Property(e => e.CommandID)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Bay)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Points)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Receive_Time).HasColumnType("datetime");
        });

        modelBuilder.Entity<OccurringAlarm>(entity =>
        {
            entity.HasKey(e => new { e.OccuredDate, e.AlarmCode });

            entity.ToTable("OccurringAlarm");

            entity.Property(e => e.OccuredDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Location)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.OPID)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Owner)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TaskName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PMHistory>(entity =>
        {
            entity.HasKey(e => new { e.AGVID, e.PMDate }).HasName("PK__PMHistor__BF79F47E5B8B69E4");

            entity.ToTable("PMHistory");

            entity.Property(e => e.PMDate).HasColumnType("datetime");
            entity.Property(e => e.Comment).HasColumnType("text");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PMSetting>(entity =>
        {
            entity.HasKey(e => e.AGVID).HasName("PK__PMSettin__FCDD6E55EF600E4B");

            entity.ToTable("PMSetting");

            entity.Property(e => e.AGVID).ValueGeneratedNever();
        });

        modelBuilder.Entity<PathInfo>(entity =>
        {
            entity.HasKey(e => new { e.ChangeTime, e.AGVID }).HasName("PK__PathInfo__DBD97340F2E9DD81");

            entity.ToTable("PathInfo");

            entity.Property(e => e.ChangeTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProductInfo>(entity =>
        {
            entity.ToTable("ProductInfo");

            entity.Property(e => e.ID)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CommandID)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Frame)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InRackLDTime).HasColumnType("datetime");
            entity.Property(e => e.LayerNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LotID)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OutRackOPID)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.OutRackULDTime).HasColumnType("datetime");
            entity.Property(e => e.OvenLDTime).HasColumnType("datetime");
            entity.Property(e => e.OvenULDTime).HasColumnType("datetime");
            entity.Property(e => e.PartID)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Receive_Time).HasColumnType("datetime");
            entity.Property(e => e.RecipeID)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SerialID)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Stamp)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RunStatusChange>(entity =>
        {
            entity.HasKey(e => new { e.ChangeTime, e.AGVID });

            entity.ToTable("RunStatusChange");

            entity.Property(e => e.ChangeTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<SkdTask>(entity =>
        {
            entity.HasKey(e => e.CommandID).HasName("PK__SkdTask__6B4108E6FBEE8DDE");

            entity.ToTable("SkdTask");

            entity.Property(e => e.CommandID)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Bay)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.FailedPoints)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MeasurePoints)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PatrolPoints)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Schedule_Time).HasColumnType("datetime");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<TaskDto>(entity =>
        {
            entity.HasKey(e => e.Name);

            entity.ToTable("Task");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AcquireTime).HasColumnType("datetime");
            entity.Property(e => e.ActionType)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.AssignUserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CSTID)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CancelUserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DepositTime).HasColumnType("datetime");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.FailReason).HasColumnType("text");
            entity.Property(e => e.FromStation)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FromStationName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Receive_Time).HasColumnType("datetime");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.ToStation)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ToStationName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TotalTime)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TrafficTask>(entity =>
        {
            entity.HasKey(e => e.AGVID);

            entity.ToTable("TrafficTask");

            entity.Property(e => e.AGVID).ValueGeneratedNever();
            entity.Property(e => e.BookingPath).HasColumnType("text");
            entity.Property(e => e.CrossPoint)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FullPath).HasColumnType("text");
            entity.Property(e => e.InvolvePoint).HasColumnType("text");
            entity.Property(e => e.ShortPath).HasColumnType("text");
            entity.Property(e => e.StartPos)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TargetPos)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserGroup>(entity =>
        {
            entity.HasKey(e => e.UserGroup1);

            entity.ToTable("UserGroup");

            entity.Property(e => e.UserGroup1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UserGroup");
            entity.Property(e => e.Functions)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.UserName);

            entity.ToTable("UserInfo");

            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserGroup)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserPassword).HasMaxLength(50);
        });

        modelBuilder.Entity<UserLoginLog>(entity =>
        {
            entity.HasKey(e => new { e.UserName, e.DateTime });

            entity.ToTable("UserLoginLog");

            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateTime).HasColumnType("datetime");
            entity.Property(e => e.Operation).HasMaxLength(50);
        });

        modelBuilder.Entity<ver>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ver");

            entity.Property(e => e.version)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
