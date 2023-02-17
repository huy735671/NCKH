using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NCKH.Models;

public class HomeController : Controller
{
   CTSVEn data = new CTSVEn();
    public ActionResult Index()
    {
        return View();
    }

    public ActionResult About()
    {
        ViewBag.Message = "Your application description page.";

        return View();
    }

    public ActionResult Contact()
    {
        if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
        {
            return RedirectToAction("Dangnhap", "Login");
        }
        else
        {
            return View();
        }
    }
    public ActionResult Theloai()
    {
        var theloai = from n in data.LOAITTs select n;
        return PartialView(theloai);
    }
    
}