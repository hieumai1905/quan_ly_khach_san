using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HotelManagements.Models;

public partial class QuanLyKhachSanContext : DbContext
{
    public QuanLyKhachSanContext()
    {
    }

    public QuanLyKhachSanContext(DbContextOptions<QuanLyKhachSanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TChiTietDatPhong> TChiTietDatPhongs { get; set; }

    public virtual DbSet<TChiTietKh> TChiTietKhs { get; set; }

    public virtual DbSet<TDangKy> TDangKies { get; set; }

    public virtual DbSet<TDanhGium> TDanhGia { get; set; }
    public virtual DbSet<TDatPhong> TDatPhongs { get; set; }

    public virtual DbSet<TDoanhThu> TDoanhThus { get; set; }

    public virtual DbSet<TLoaiKhachHang> TLoaiKhachHangs { get; set; }

    public virtual DbSet<TLoaiPhong> TLoaiPhongs { get; set; }

    public virtual DbSet<TSoPhongLoaiPhong> TSoPhongLoaiPhongs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=HIEU-MAI\\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TChiTietDatPhong>(entity =>
        {
            entity.HasKey(e => new { e.MaDp, e.LoaiPhong }).HasName("pk_tChiTietDatPhong");

            entity.ToTable("tChiTietDatPhong");

            entity.Property(e => e.MaDp)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaDP");
            entity.Property(e => e.LoaiPhong)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SlphongDat).HasColumnName("SLPhongDat");

            entity.HasOne(d => d.LoaiPhongNavigation).WithMany(p => p.TChiTietDatPhongs)
                .HasForeignKey(d => d.LoaiPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tChiTietDatPhong_tLoaiPhong");

            entity.HasOne(d => d.MaDpNavigation).WithMany(p => p.TChiTietDatPhongs)
                .HasForeignKey(d => d.MaDp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tChiTietDatPhong_tDatPhong");
        });

        modelBuilder.Entity<TChiTietKh>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("pk_tChiTietKH");

            entity.ToTable("tChiTietKH");

            entity.Property(e => e.MaKh)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaKH");
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.DienThoai).HasMaxLength(7);
            entity.Property(e => e.LoaiKh)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LoaiKH");
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.TenKh)
                .HasMaxLength(50)
                .HasColumnName("TenKH");
            entity.Property(e => e.TheCanCuoc).HasMaxLength(20);

            entity.HasOne(d => d.LoaiKhNavigation).WithMany(p => p.TChiTietKhs)
                .HasForeignKey(d => d.LoaiKh)
                .HasConstraintName("FK_tChiTietKH_tLoaiKhachHang");
        });

        modelBuilder.Entity<TDangKy>(entity =>
        {
            entity.HasKey(e => e.MaDk).HasName("pk_tDangKy");

            entity.ToTable("tDangKy");

            entity.Property(e => e.MaDk)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaDK");
            entity.Property(e => e.MaKh)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaKH");
            entity.Property(e => e.NgayRa).HasColumnType("datetime");
            entity.Property(e => e.NgayVao).HasColumnType("datetime");
            entity.Property(e => e.SoPhong)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.TDangKies)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK_tDangKy_tChiTietKH");

            entity.HasOne(d => d.SoPhongNavigation).WithMany(p => p.TDangKies)
                .HasForeignKey(d => d.SoPhong)
                .HasConstraintName("FK_tDangKy_tSoPhong_LoaiPhong");
        });

        modelBuilder.Entity<TDanhGium>(entity =>
        {
            entity.HasKey(e => e.MaDg).HasName("pk_tDanhGiay");

            entity.ToTable("tDanhGia");

            entity.Property(e => e.MaDg)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaDG");
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.GiaCa)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.MonAn)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.NguoiDanhGia).HasMaxLength(50);
            entity.Property(e => e.NoiDung).HasMaxLength(4000);
            entity.Property(e => e.PhucVu)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.TienNghi)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.VeSinh)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.ViTri)
                .HasMaxLength(1)
                .IsFixedLength();
        });

        modelBuilder.Entity<TDatPhong>(entity =>
        {
            entity.HasKey(e => e.MaDp).HasName("pk_tDatPhongy");

            entity.ToTable("tDatPhong");

            entity.Property(e => e.MaDp)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaDP");
            entity.Property(e => e.DiaChiCty).HasMaxLength(255);
            entity.Property(e => e.Diachi).HasMaxLength(250);
            entity.Property(e => e.MaKh)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaKH");
            entity.Property(e => e.MaSoThue).HasMaxLength(150);
            entity.Property(e => e.TenCongTy).HasMaxLength(250);

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.TDatPhongs)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK_tDatPhong_tChiTietKH");
        });

        modelBuilder.Entity<TDoanhThu>(entity =>
        {
            entity.HasKey(e => e.MaDk);

            entity.ToTable("tDoanhThu");

            entity.Property(e => e.MaDk)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaDK");
            entity.Property(e => e.LoaiPhong)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.MaDkNavigation).WithOne(p => p.TDoanhThu)
                .HasForeignKey<TDoanhThu>(d => d.MaDk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tDoanhThu_tDangKy");
        });

        modelBuilder.Entity<TLoaiKhachHang>(entity =>
        {
            entity.HasKey(e => e.LoaiKh);

            entity.ToTable("tLoaiKhachHang");

            entity.Property(e => e.LoaiKh)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LoaiKH");
            entity.Property(e => e.DienGiai).HasMaxLength(50);
        });

        modelBuilder.Entity<TLoaiPhong>(entity =>
        {
            entity.HasKey(e => e.LoaiPhong);

            entity.ToTable("tLoaiPhong");

            entity.Property(e => e.LoaiPhong)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.BonTam)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.DienTich)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.HinhAnh).HasMaxLength(50);
            entity.Property(e => e.MoTa).HasMaxLength(50);
            entity.Property(e => e.SoGiuong)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.SoPhongNgu)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.SoPhongTam)
                .HasMaxLength(1)
                .IsFixedLength();
        });

        modelBuilder.Entity<TSoPhongLoaiPhong>(entity =>
        {
            entity.HasKey(e => e.SoPhong).HasName("PK_tSoPhong_LoaiPhong_1");

            entity.ToTable("tSoPhong_LoaiPhong");

            entity.Property(e => e.SoPhong)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LoaiPhong)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.LoaiPhongNavigation).WithMany(p => p.TSoPhongLoaiPhongs)
                .HasForeignKey(d => d.LoaiPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tSoPhong_LoaiPhong_tLoaiPhong");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
