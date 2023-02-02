using Microsoft.AspNetCore.Mvc;
using MVCTicketDemoCore.Models;
using System.Diagnostics;

//https://localhost:7018/
namespace MVCTicketDemoCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        HttpClient client = new HttpClient();
        HttpResponseMessage response;
        IList<TBLMovieDetails> movieslist = new List<TBLMovieDetails>();
        private readonly IHttpContextAccessor _context;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor cttpca)
        {
            _logger = logger;
            client.BaseAddress = new Uri("https://localhost:7018/");
            _context = cttpca;
        }



        //const string SessionName = "_Name";
        //const string SessionAge = "_Age";




        //---------------------------------------------------------------------------------------
        public IActionResult Index()
        {
            response = client.GetAsync("api/MovieDetails/GetMovies").Result;
            movieslist = response.Content.ReadAsAsync<IList<TBLMovieDetails>>().Result;
            return View(movieslist);
        }
        //**********************************************************************************************
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(TBLUserInfo tbl1)
        {

            TBLUserInfo user = new TBLUserInfo();
            // user.IdUs = tbl1.IdUs;
            user.UserRole = tbl1.UserRole;
            user.Email = tbl1.Email;
            user.MobileNumber = tbl1.MobileNumber;
            user.UsernameUs = tbl1.UsernameUs;
            user.PasswordUs = tbl1.PasswordUs;
            user.RePasswordUs = tbl1.RePasswordUs;
            response = client.PostAsJsonAsync("api/Home/Signup/", user).Result;
            var x = response.Content.ReadAsStringAsync().Result;  //***********************************************  imp  ******************************
            //var foo = resp.Content.ReadAsStringAsync().Result;
            string y = x.ToString();
            //if (response.IsSuccessStatusCode)
            if (y == "true")
            {
                _context.HttpContext.Session.SetString("UserName", tbl1.UsernameUs.ToString());
                _context.HttpContext.Session.SetInt32("UserId", tbl1.IdUs);
                _context.HttpContext.Session.SetString("UserRole", tbl1.UserRole.ToString());


                //HttpContext.Session.SetInt32(SessionAge, 24);
                //Session["IdUsSS"] = tbl1.IdUs.ToString();
                //    Session["UsernameSS"] = tbl1.UsernameUs.ToString();
                //    Session["UserId"] = tbl1.IdUs.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "This account has already existed";
                return RedirectToAction("Signup");
            }

        }

        public ActionResult Logout()
        {
            // Session.Clear();
            _context.HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }



        public ActionResult Login()
        { return View(); }


        IList<TBLUserInfo> userslist = new List<TBLUserInfo>();
        [HttpPost]

        public ActionResult Login(TBLUserInfo tbl2)
        {

            response = client.GetAsync("api/UserDetails/GetUsers").Result;
            userslist = response.Content.ReadAsAsync<IList<TBLUserInfo>>().Result;
            var checkLogin = userslist.Where(x => x.UsernameUs.Equals(tbl2.UsernameUs) && x.PasswordUs.Equals(tbl2.PasswordUs)).FirstOrDefault();
            if (checkLogin != null)
            {

                _context.HttpContext.Session.SetString("UserName", tbl2.UsernameUs.ToString());
                _context.HttpContext.Session.SetInt32("UserId", tbl2.IdUs);
                _context.HttpContext.Session.SetString("UserRole", tbl2.UserRole.ToString());

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "Wrong Username or password";
            }
            return View();
        }

        //*******************************************************************************************
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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


        //***************************************************************************************

        IList<Booking> booklist = new List<Booking>();
        public ActionResult BookedTicketsOfUser()
        {
            string us = Convert.ToString(_context.HttpContext.Session.GetString("UserName"));
            response = client.GetAsync("api/BookingDetails/GetBookings").Result;
            booklist = response.Content.ReadAsAsync<IList<Booking>>().Result;
            IList<Booking> bookings = booklist.Where(x => x.UserName == us).ToList();

            return View(bookings);

        }

        public ActionResult AdminFunctionality()
        {
            return View();
        }

        //     @* <h3>
        //    <a href = "@Url.Action("GetUsersByNamemvc","Users", new {name="Sahithi" })"
        //       class="btn btn-primary btn-lg">Get User By Name</a>
        //</h3>*@
        public ActionResult Profile()
        {
            string username = _context.HttpContext.Session.GetString("UserName");
            return RedirectToAction("GetUsersByNamemvc", "Users", new { name = username });
        }



    }
}