using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using prjDemoAjax.Models;
using prjDemoAjax.ViewModels;
using System.Drawing;
using System.IO;

namespace prjDemoAjax.Controllers
{
    public class ApiController : Controller
    {
        private readonly DemoContext _context;
        private readonly IWebHostEnvironment _host;

        public ApiController(DemoContext context, IWebHostEnvironment host)
        {
            _context = context;
            _host = host;
        }
        public IActionResult Index()
        {
            System.Threading.Thread.Sleep(5000); //睡5秒鐘，再往下執行
            return Content("Hello Ajax");
        }
        public IActionResult GetDemo(UserViewModel user)//string name, int age = 18
        {
            if (string.IsNullOrEmpty(user.name))
            {
                user.name = "guest";
            }
            return Content($"Hello {user.name}, You are {user.age} years old.");
        }
        public IActionResult CheckAccount(string? Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return Content("姓名不可為空白");
            }
            else
            {
                Members member = _context.Members.FirstOrDefault(x => x.Name == Name);
                if (member != null)
                {
                    return Content("姓名重複，請重新輸入");
                }
            }
            return Content("此姓名可註冊");
        }
        public IActionResult Register(Members member, IFormFile file)
        {

            //return Content($"{_host.ContentRootPath}");
            //結果 => C:\MSIT150\AJAX\slnDemoAjax\prjDemoAjax

            //return Content($"{_host.WebRootPath}");
            //結果 => C:\MSIT150\AJAX\slnDemoAjax\prjDemoAjax\wwwroot

            string filePath = Path.Combine(_host.WebRootPath, "uploads", file.FileName);
            //結果 => C:\shared\Ajax\MSIT150Site\wwwroot\uploads\檔案名稱

            //上傳檔案到uploads資料夾中
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            //將圖轉成二進位
            byte[]? imgByte = null;
            using (var memorystream = new MemoryStream())
            {
                file.CopyTo(memorystream);
                imgByte = memorystream.ToArray();
            }

            //確認檔案位置
            //return Content($"上傳檔案到 {filePath}");

            //檔案名稱 - 檔案大小 - 檔案類型
            //return Content($"{file.FileName} - {file.Length} - {file.ContentType}");

            //註冊到資料庫儲存
            member.FileName = file.FileName;
            member.FileData = imgByte;
            _context.Members.Add(member);
            _context.SaveChanges();
            return Content("註冊成功");
        }
        public IActionResult GetImageByte(int id = 1)
        {
            //要搜尋pk的話，可以不使用Where(條件)+FirstOrDefault()，Find會直接搜尋pk
            Members? member = _context.Members.Find(id);
            byte[]? img = member.FileData;
            //回傳型態可使用File(資料流(byte[]), 檔案類型(類型/種類 => image/jpeg or text/html 等等))
            if (img == null)
                return null;
            return File(img, "image/jpeg");
        }

        //回傳城市的JSON資料
        public IActionResult Cities()
        {
            var cities = _context.Address.Select(c => c.City).Distinct();
            //var cities = _context.Address.Select(c => new
            //{
            //    c.City
            //}).Distinct();
            return Json(cities);
        }

        //根據城市名稱，回傳城市的鄉鎮區JSON資料
        public IActionResult Districts(string city)
        {
            var districts = _context.Address.Where(a => a.City == city).Select(c => c.SiteId).Distinct();

            return Json(districts);
        }

        //根據鄉鎮區名稱，回傳鄉鎮區的路名JSON資料
        public IActionResult Roads(string siteId)
        {
            var roads = _context.Address.Where(a => a.SiteId == siteId).Select(c => c.Road).Distinct();

            return Json(roads);
        }
        public IActionResult ShowImg(IFormFile file)
        {
            byte[]? imgByte = null;
            using (var memorystream = new MemoryStream())
            {
                file.CopyTo(memorystream);
                imgByte = memorystream.ToArray();
            }

            if (imgByte == null)
                return null;
            return File(imgByte, "image/jpeg");
        }
        public IActionResult AutoComplete(string? keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return Json(null);
            }

            var citys = _context.Address.Where(x => x.City.ToUpper().Contains(keyword.ToUpper())).Select(x => x.City).Distinct();
            return Json(citys);
        }
    }
}
