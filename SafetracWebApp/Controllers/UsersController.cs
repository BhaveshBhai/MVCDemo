using SafetracWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SafetracWebApp.Controllers
{
    public class UsersController : Controller
    {
        UserModelView userModel = new UserModelView();
        AreaModel areaModel = new AreaModel();
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult List()

        {
            return Json(new { data = userModel.GetAllUsers() }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UsersList()
        {
            return View();
        }
        [HttpPost]
        public JsonResult LoadAllUsersData()

        {
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            var search = Request.Form.GetValues("search[value]").FirstOrDefault();
            //Find Order Column
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int PageNumber = start != null ? Convert.ToInt32(start) / Convert.ToInt32(length) + 1 : 0;

            var lstUsers = userModel.LoadAllUsers(search.ToString(), PageNumber, pageSize, sortColumn, sortColumnDir);
            int TotalRecord = lstUsers.Select(x => x.MaxRows.Value).First();
            return Json(new { draw = draw, recordsFiltered = TotalRecord, recordsTotal = TotalRecord, data = lstUsers }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add()
        {
            ViewBag.Areas = new SelectList(areaModel.LoadAreas().ToList(), "id", "area_name");
            return PartialView("_AddUsers");
        }
        [HttpPost]
        public ActionResult AddUsers(UserModelView users)
        {
            var result = userModel.AddUserWithPermission(users);
            return RedirectToAction("Index");
        }
    }
}