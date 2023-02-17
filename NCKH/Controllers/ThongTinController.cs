using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NCKH.Models;
using PagedList.Mvc;
using PagedList;
using System.IO;

namespace NCKH.Controllers
{
    public class ThongTinController : Controller
    {
        CTSVEn data = new CTSVEn();
        private string fileName;

        // GET: ThongTin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Danhmuc(int id, int? page)
        {
            /* var sanpham = data.SANPHAMs.Where(n => n.MADM == 1).Take(50).ToList();*/
            ViewBag.MADM = id;
            int isize = 9;
            var ipageNum = (page ?? 1);
            var sanpham = from s in data.THONGTINs where s.MADM == id orderby s.MADM select s;
            return View(sanpham.ToPagedList(ipageNum, isize));
        }

        public ActionResult DanhmucPartial()
        {
            return PartialView(data.DANHMUCs);
        }

        public ActionResult ThongTin(int? page)
        {
            int iPageNum = (page ?? 1);
            int iPageSize = 7;
            return View(data.THONGTINs.ToList().OrderBy(n => n.MATT).ToPagedList(iPageNum, iPageSize));
        }
        public ActionResult ChitietThongTin(int id)
        {
            var sp = from n in data.THONGTINs where n.MATT == id select n;
            return View(sp);
        }
        public ActionResult Thontinnoibat()
        {
            var sp = from n in data.THONGTINs select n;
            return PartialView(sp.Take(8));
        }


        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }

        [HttpGet]
        public ActionResult DownloadFile(string namefile)
        {
            string nameDisplay = "";
            CTSVEn request = new CTSVEn();
            try

            {
               
                return Content("Download Err");
            }
            catch (Exception)
            {
                string baseFolder = "~/Upload";///path 
                string[] sElement = namefile.Split('.');
                int vt = sElement.Length - 1;

                nameDisplay += "." + sElement[vt];
                if (!string.IsNullOrEmpty(fileName))
                {

                    string path = Server.MapPath(baseFolder + fileName);
                    var bytes = System.IO.File.ReadAllBytes(path);

                    return File(bytes, "application/octet-stream", nameDisplay);
                }
                return Content("File not found");

            }
        }

    }
}