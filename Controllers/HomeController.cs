using DashClassLib.FarmOwner;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AgroTourismDashboard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost] //login 

        public async Task<ActionResult> Login(LoginRS model)
        {

            BALFarmOwner obj = new BALFarmOwner();
            DataSet ds = await obj.Login(model);

            if (ds.Tables[0].Rows.Count > 0)
            {
                // OWNER
                Session["UserId"] = ds.Tables[0].Rows[0]["UserId"];
                Session["Email"] = ds.Tables[0].Rows[0]["Email"];
                Session["OwnerCode"] = ds.Tables[0].Rows[0]["FarmOwnerCode"];
                Session["OwnerName"] = ds.Tables[0].Rows[0]["FullName"];


                return RedirectToAction("DashboardMG", "FarmOwner");
            }
            else if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                // VISITOR
                Session["UserId"] = ds.Tables[1].Rows[0]["UserId"];
                Session["Email"] = ds.Tables[1].Rows[0]["Email"];
                Session["VisitorCode"] = ds.Tables[1].Rows[0]["VisitorCode"];

                return RedirectToAction("Dashboard", "Visitor");
            }
            else
            {
                ViewBag.Message = "Invalid Email or Password";
                return View("Index");
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}