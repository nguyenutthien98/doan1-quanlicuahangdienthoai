﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAO
{
    public class TaiKhoanDAO
    {
        public TaiKhoan kttk(string name, string pass)
        {
            TaiKhoan a = new TaiKhoan();
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.TaiKhoans.SingleOrDefault(p => p.UserName == name && p.Password == pass);
                //a = (from i in dbs.TaiKhoans
                //     where i.UserName == name && i.Password == pass
                //     select new TaiKhoan(i.UserName,i.Password))
            }
            //return a;
        }
        public TaiKhoan Get1TK(string name)
        {
            TaiKhoan a = new TaiKhoan();
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                return dbs.TaiKhoans.SingleOrDefault(p => p.UserName == name);
                //a = (from i in dbs.TaiKhoans
                //     where i.UserName == name && i.Password == pass
                //     select new TaiKhoan(i.UserName,i.Password))
            }
            //return a;
        }
        public int matruycap(string name, string pass)
        {
            TaiKhoan a = new TaiKhoan();
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
               string loaitk= dbs.TaiKhoans.SingleOrDefault(p => p.UserName == name && p.Password == pass).MaLoaiTK;
                if (loaitk == "admin")
                    return 0;
                else
                    if (loaitk == "qlk")
                    return 1;
                else
                     if (loaitk == "qlns")
                    return 2;
                if (loaitk == "qlch")
                    return 3;
                return 4;
                
            }
             
        }
        public void ThayDoiMK(TaiKhoan obj)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                dbs.TaiKhoans.Attach(obj);
                dbs.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                dbs.SaveChanges();
            }
        }
        public List<TaiKhoan> GetAllTK()
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
               return dbs.TaiKhoans.ToList();
            }
        }
        public void ThemTK(TaiKhoan obj)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                dbs.TaiKhoans.Add(obj);
                dbs.SaveChanges();
            }
        }
        public void XoaTK(string User)
        {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                var obj= dbs.TaiKhoans.SingleOrDefault(p => p.UserName == User);
                dbs.TaiKhoans.Attach(obj);
                dbs.TaiKhoans.Remove(obj);
                dbs.SaveChanges();
            }
        }
        public void EditTk(TaiKhoan obj)
         {
            using (GalaxyMobileEntities dbs = new GalaxyMobileEntities())
            {
                dbs.TaiKhoans.Attach(obj);
                dbs.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                dbs.SaveChanges();
            }
}
        
        
    }
}
