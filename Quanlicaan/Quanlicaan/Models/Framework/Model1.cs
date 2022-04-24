using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Quanlicaan.Models.Framework
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<CaAn> CaAns { get; set; }
        public virtual DbSet<ChiTietSuatAn> ChiTietSuatAns { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SuatAn> SuatAns { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaAn>()
                .HasMany(e => e.ChiTietSuatAns)
                .WithRequired(e => e.CaAn)
                .HasForeignKey(e => e.IDCaan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.username)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.upassword)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.ChiTietSuatAns)
                .WithRequired(e => e.NhanVien)
                .HasForeignKey(e => e.IDUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.SuatAns)
                .WithOptional(e => e.NhanVien)
                .HasForeignKey(e => e.IDUser);

            modelBuilder.Entity<PhongBan>()
                .HasMany(e => e.NhanViens)
                .WithRequired(e => e.PhongBan)
                .HasForeignKey(e => e.IDPhongBan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.NhanViens)
                .WithOptional(e => e.Role)
                .HasForeignKey(e => e.IDrole);

            modelBuilder.Entity<SuatAn>()
                .HasMany(e => e.ChiTietSuatAns)
                .WithOptional(e => e.SuatAn)
                .HasForeignKey(e => e.IDSuatAn);
        }
    }
}
