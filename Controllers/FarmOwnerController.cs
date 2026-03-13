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
    public class FarmOwnerController : Controller
    {
        // GET: FarmOwner

        BALFarmOwner objbalfarm = new BALFarmOwner();
        public ActionResult Index()
        {
            return View();
        }

        #region MohanishDashboard


        //..............................Card Count Show........................ \\
        /*public async Task<ActionResult> DashboardMG()
        {
            string farmownercode = Session["OwnerCode"].ToString();

            BALFarmOwner.DashboardDelegate objdel = objbalfarm.LoadDashboardCountsMG;

            DataSet ds1 = await objdel("TotalBokingMG", farmownercode );
            DataSet ds2 = await objdel("WeeklyEarningMG", farmownercode);
            DataSet ds3 = await objdel("MonthlyEarningMG", farmownercode);
            DataSet ds4 = await objdel("UpcomingBookingMG", farmownercode);
            DataSet ds5 = await objdel("CancelledBookingMG", farmownercode);
            DataSet ds6 = await objdel("ClosedFarmhouseMG", farmownercode);
            DataSet ds7 = await objdel("CurrentSubscriptionMG", farmownercode);

            ViewBag.TotalBooking = ds1.Tables[0].Rows[0][0];
            ViewBag.WeeklyEarning = ds2.Tables[0].Rows[0][0];
            ViewBag.MonthlyEarning = ds3.Tables[0].Rows[0][0];
            ViewBag.UpcomingBooking = ds4.Tables[0].Rows[0][0];
            ViewBag.CancelledBooking = ds5.Tables[0].Rows[0][0];
            ViewBag.ClosedFarmhouse = ds6.Tables[0].Rows[0][0];

            ViewBag.PlanName = ds7.Tables[0].Rows[0]["PlanTypeName"];
            ViewBag.EndDate = ds7.Tables[0].Rows[0]["EndDate"];
            ViewBag.DaysLeft = ds7.Tables[0].Rows[0]["DaysLeft"];

            return View();
        }*/

        public async Task<ActionResult> DashboardMG()
        {
            string farmownercode = Session["OwnerCode"].ToString();

            BALFarmOwner.DashboardDelegate objdel = objbalfarm.LoadDashboardCountsMG;

            DataSet ds1 = await objdel("TotalBokingMG", farmownercode);
            DataSet ds2 = await objdel("WeeklyEarningMG", farmownercode);
            DataSet ds3 = await objdel("MonthlyEarningMG", farmownercode);
            DataSet ds4 = await objdel("UpcomingBookingMG", farmownercode);
            DataSet ds5 = await objdel("CancelledBookingMG", farmownercode);
            DataSet ds6 = await objdel("ClosedFarmhouseMG", farmownercode);
            DataSet ds7 = await objdel("CurrentSubscriptionMG", farmownercode);

            ViewBag.TotalBooking = ds1.Tables[0].Rows[0][0];
            ViewBag.WeeklyEarning = ds2.Tables[0].Rows[0][0];
            ViewBag.MonthlyEarning = ds3.Tables[0].Rows[0][0];
            ViewBag.UpcomingBooking = ds4.Tables[0].Rows[0][0];
            ViewBag.CancelledBooking = ds5.Tables[0].Rows[0][0];
            ViewBag.ClosedFarmhouse = ds6.Tables[0].Rows[0][0];

            if (ds7.Tables[0].Rows.Count > 0)
            {
                ViewBag.PlanName = ds7.Tables[0].Rows[0]["PlanTypeName"];
                ViewBag.EndDate = ds7.Tables[0].Rows[0]["EndDate"];
                ViewBag.DaysLeft = ds7.Tables[0].Rows[0]["DaysLeft"];
            }
            else
            {
                ViewBag.PlanName = "No Plan";
                ViewBag.EndDate = "-";
                ViewBag.DaysLeft = 0;
            }

            return View();
        }


        //--------------------------------------Cards List--------------------------\\
        public async Task<JsonResult> GetListMG(string flag)
        {
            string ownerCode = Session["OwnerCode"].ToString();

            BALFarmOwner.DashboardDelegate del = objbalfarm.LoadDashboardCountsMG;

            DataSet ds = await del(flag, ownerCode);

            var result = new List<List<string>>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                result.Add(row.ItemArray.Select(x => x.ToString()).ToList());
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //----------------------------------------1 Graph GetRevenueChart--------------\\
        public async Task<JsonResult> GetRevenueChartMG(string filterType)
        {
            string ownerCode = Session["OwnerCode"].ToString();

            DataSet ds = await objbalfarm.LoadDashboardGraphMG("MonthlyRevenueGraphMG",ownerCode, filterType);

            var result = new List<List<string>>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                result.Add(row.ItemArray.Select(x => x.ToString()).ToList());
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //---------------------------------------GetPackageByFarmHouseChart----------------\\
        public async Task<JsonResult> GetPackageChartMG(string filterType)
        {
            string ownerCode = Session["OwnerCode"].ToString();

            DataSet ds = await objbalfarm.LoadDashboardGraphMG("PackageByFarmHouseMG", ownerCode, filterType);

            var result = new List<List<string>>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                result.Add(row.ItemArray.Select(x => x.ToString()).ToList());
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //---------------------------------------GetFarmhouseBookingChart----------------\\
        public async Task<JsonResult> GetFarmhouseBookingChartMG(string filterType)
        {
            string ownerCode = Session["OwnerCode"].ToString();

            DataSet ds = await objbalfarm.LoadDashboardGraphMG("FarmhouseBookingGraphMG", ownerCode, filterType);

            var result = new List<List<string>>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                result.Add(row.ItemArray.Select(x => x.ToString()).ToList());
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //------------------------Booking Status Overview Pie Chart-----\\
        public async Task<JsonResult> GetBookingStatusChartMG(string filterType)
        {
            string ownerCode = Session["OwnerCode"].ToString();

            DataSet ds = await objbalfarm.LoadDashboardGraphMG("BookingStatusOverviewMG", ownerCode, filterType);

            var result = new List<List<string>>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                result.Add(row.ItemArray.Select(x => x.ToString()).ToList());
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        

        // -------------------------------------------Revenue Details List---------------\\
        public async Task<JsonResult> GetRevenueDetailsListMG(string month, string filterType)
        {
            string ownerCode = Session["OwnerCode"].ToString();

            DataSet ds = await objbalfarm.LoadDashboardListMG("RevenueDetailsListMG", ownerCode, month, filterType);

            var result = new List<List<string>>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                result.Add(row.ItemArray.Select(x => x.ToString()).ToList());
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //----------------------------------- Farmhouse Bookings List---------------\\
        public async Task<JsonResult> GetFarmhouseBookingsListMG(string farmName, string month)
        {
            string ownerCode = Session["OwnerCode"].ToString();

            DataSet ds = await objbalfarm.LoadDashboardListMG("FarmhouseBookingsListMG", ownerCode, farmName, month);

            var result = new List<List<string>>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                result.Add(row.ItemArray.Select(x => x.ToString()).ToList());
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // ---------------------------------Package Bookings List----------------\\
        public async Task<JsonResult> GetPackageBookingsListMG(string packageName, string month, string filterType)
        {
            string ownerCode = Session["OwnerCode"].ToString();

            DataSet ds = await objbalfarm.LoadDashboardListMG("PackageBookingsListMG", ownerCode, packageName, month);

            var result = new List<List<string>>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                result.Add(row.ItemArray.Select(x => x.ToString()).ToList());
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion  
    }
}