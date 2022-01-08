﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DON_DAT_HANG> DON_DAT_HANG { get; set; }
        public virtual DbSet<DONDATHANG_MATHANG> DONDATHANG_MATHANG { get; set; }
        public virtual DbSet<HOA_DON> HOA_DON { get; set; }
        public virtual DbSet<HOADON_MATHANG> HOADON_MATHANG { get; set; }
        public virtual DbSet<KHACH_HANG> KHACH_HANG { get; set; }
        public virtual DbSet<LOAI_MAT_HANG> LOAI_MAT_HANG { get; set; }
        public virtual DbSet<MAT_HANG> MAT_HANG { get; set; }
        public virtual DbSet<NHA_CUNG_CAP> NHA_CUNG_CAP { get; set; }
        public virtual DbSet<NHAN_VIEN> NHAN_VIEN { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    
        [DbFunction("Entities", "FNMAT_HANG")]
        public virtual IQueryable<FNMAT_HANG_Result> FNMAT_HANG()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FNMAT_HANG_Result>("[Entities].[FNMAT_HANG]()");
        }
    
        public virtual ObjectResult<MATHANG_Result> MATHANG()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MATHANG_Result>("MATHANG");
        }
    
        [DbFunction("Entities", "FNLOAIMAT_HANG")]
        public virtual IQueryable<FNLOAIMAT_HANG_Result> FNLOAIMAT_HANG()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FNLOAIMAT_HANG_Result>("[Entities].[FNLOAIMAT_HANG]()");
        }
    
        [DbFunction("Entities", "FNBANHANG")]
        public virtual IQueryable<FNBANHANG_Result> FNBANHANG()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FNBANHANG_Result>("[Entities].[FNBANHANG]()");
        }
    
        [DbFunction("Entities", "FNBANHANGByTIME")]
        public virtual IQueryable<FNBANHANGByTIME_Result> FNBANHANGByTIME(Nullable<System.DateTime> nGAY)
        {
            var nGAYParameter = nGAY.HasValue ?
                new ObjectParameter("NGAY", nGAY) :
                new ObjectParameter("NGAY", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FNBANHANGByTIME_Result>("[Entities].[FNBANHANGByTIME](@NGAY)", nGAYParameter);
        }
    
        [DbFunction("Entities", "FNBANHANGByTIMEGROUP")]
        public virtual IQueryable<FNBANHANGByTIMEGROUP_Result> FNBANHANGByTIMEGROUP(Nullable<System.DateTime> nGAY)
        {
            var nGAYParameter = nGAY.HasValue ?
                new ObjectParameter("NGAY", nGAY) :
                new ObjectParameter("NGAY", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FNBANHANGByTIMEGROUP_Result>("[Entities].[FNBANHANGByTIMEGROUP](@NGAY)", nGAYParameter);
        }
    
        [DbFunction("Entities", "FNBANHANGByTIMEGROUPMH")]
        public virtual IQueryable<FNBANHANGByTIMEGROUPMH_Result> FNBANHANGByTIMEGROUPMH(Nullable<System.DateTime> nGAY)
        {
            var nGAYParameter = nGAY.HasValue ?
                new ObjectParameter("NGAY", nGAY) :
                new ObjectParameter("NGAY", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FNBANHANGByTIMEGROUPMH_Result>("[Entities].[FNBANHANGByTIMEGROUPMH](@NGAY)", nGAYParameter);
        }
    
        [DbFunction("Entities", "FNKHACHHANGGROUP")]
        public virtual IQueryable<FNKHACHHANGGROUP_Result> FNKHACHHANGGROUP(Nullable<System.DateTime> nGAY)
        {
            var nGAYParameter = nGAY.HasValue ?
                new ObjectParameter("NGAY", nGAY) :
                new ObjectParameter("NGAY", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FNKHACHHANGGROUP_Result>("[Entities].[FNKHACHHANGGROUP](@NGAY)", nGAYParameter);
        }
    
        public virtual ObjectResult<BANHANG_Result> BANHANG(Nullable<System.DateTime> tUNGAY, Nullable<System.DateTime> dENNGAY)
        {
            var tUNGAYParameter = tUNGAY.HasValue ?
                new ObjectParameter("TUNGAY", tUNGAY) :
                new ObjectParameter("TUNGAY", typeof(System.DateTime));
    
            var dENNGAYParameter = dENNGAY.HasValue ?
                new ObjectParameter("DENNGAY", dENNGAY) :
                new ObjectParameter("DENNGAY", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BANHANG_Result>("BANHANG", tUNGAYParameter, dENNGAYParameter);
        }
    
        public virtual ObjectResult<DONDATHANG_Result> DONDATHANG(Nullable<System.DateTime> tUNGAY, Nullable<System.DateTime> dENNGAY)
        {
            var tUNGAYParameter = tUNGAY.HasValue ?
                new ObjectParameter("TUNGAY", tUNGAY) :
                new ObjectParameter("TUNGAY", typeof(System.DateTime));
    
            var dENNGAYParameter = dENNGAY.HasValue ?
                new ObjectParameter("DENNGAY", dENNGAY) :
                new ObjectParameter("DENNGAY", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DONDATHANG_Result>("DONDATHANG", tUNGAYParameter, dENNGAYParameter);
        }
    
        [DbFunction("Entities", "FNKHACHHANGByTIME")]
        public virtual IQueryable<FNKHACHHANGByTIME_Result> FNKHACHHANGByTIME(Nullable<System.DateTime> nGAY)
        {
            var nGAYParameter = nGAY.HasValue ?
                new ObjectParameter("NGAY", nGAY) :
                new ObjectParameter("NGAY", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FNKHACHHANGByTIME_Result>("[Entities].[FNKHACHHANGByTIME](@NGAY)", nGAYParameter);
        }
    
        public virtual ObjectResult<HOADON_Result> HOADON(Nullable<System.DateTime> nGAY)
        {
            var nGAYParameter = nGAY.HasValue ?
                new ObjectParameter("NGAY", nGAY) :
                new ObjectParameter("NGAY", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HOADON_Result>("HOADON", nGAYParameter);
        }
    
        public virtual ObjectResult<KHACHHANG_Result> KHACHHANG()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<KHACHHANG_Result>("KHACHHANG");
        }
    
        [DbFunction("Entities", "FNTHONGKEDOANHTHU")]
        public virtual IQueryable<FNTHONGKEDOANHTHU_Result> FNTHONGKEDOANHTHU()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FNTHONGKEDOANHTHU_Result>("[Entities].[FNTHONGKEDOANHTHU]()");
        }
    }
}
