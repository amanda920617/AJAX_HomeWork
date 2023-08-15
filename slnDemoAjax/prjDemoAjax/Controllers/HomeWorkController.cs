using Microsoft.AspNetCore.Mvc;

namespace prjDemoAjax.Controllers
{
    public class HomeWorkController : Controller
    {
        //作業一 改用 jQuery 完成JSON資料讀取並顯示在表格中的練習
        public IActionResult Index()
        {
            return View();
        }
        //作業二 引用 datas/Travel.js 中的JSON，讀取資料後，透過 bootstrap cards component 顯示在網頁上
        public IActionResult Travel()
        {
            return View();
        }
        //作業三 檢查帳號是否存在
        //在Register.cshtml中，使用者輸入姓名離開後，透過Ajax技術將姓名送到api/CheckAccount Action
        //在 CheckAccount Action 中檢查帳號是否存在，將檢查結果回傳給Client端顯示
        //作業五 選擇圖片上傳時先進行預覽
        public IActionResult Register()
        {
            return View();
        }
        //作業四 const cities = ["台北市", "新北市", "桃園市", "台中市", "台南市", "高雄市"]
        //將cities城市資料放進select標籤中
        //使用者選取了某個城市後，將選到的城市顯示在span標籤中
        public IActionResult City()
        {
            return View();
        }
        //作業六 改用fetch() 加上 async await 來完成住址連動的功能
        //作業七 想想看 AutoComplete 的功能要如何做，使用fetch()及 async await 的技術
        public IActionResult Address()
        {
            return View();
        }
    }
}
