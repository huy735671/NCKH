using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NCKH.Models;
using Microsoft.Web.Infrastructure;
using System.Web.Razor;
using System.Web.WebPages.Deployment;
using System.Web.WebPages.Razor;

namespace NCKH.Controllers
{
    public class LoginController : Controller
    {
        CTSVEn data = new CTSVEn();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Dangnhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection collection)
        {
            var sTenDn = collection["TenDN"];
            var sMatKhau = collection["MatKhau"];
            KHACHHANG kh = data.KHACHHANGs.SingleOrDefault(n => n.USERNAME == sTenDn && n.PASSWORD == sMatKhau);
            if (kh != null)
            {
                ViewBag.ThongBao = "Chúc mừng đăng nhập thành công";
                Session["Taikhoan"] = kh;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ThongBao = "Tên Đăng Nhập hoặc mật khẩu không đúng";
            }
            return View();
        }

        public ActionResult LoginLogout()
        {
            return PartialView("LoginLogout");
        }
    }
}