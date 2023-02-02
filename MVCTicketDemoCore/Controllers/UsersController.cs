using Microsoft.AspNetCore.Mvc;
using MVCTicketDemoCore.Models;


namespace MVCTicketDemoCore.Controllers
{
    public class UsersController : Controller
    {

        HttpClient client = new HttpClient();
        HttpResponseMessage response;
        IList<TBLUserInfo> userslist = new List<TBLUserInfo>();
        public UsersController()
        {
            client.BaseAddress = new Uri("https://localhost:7018/");
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetUsersmvc() // list of all movies - no view given already used in Index/Home
        {
            response = client.GetAsync("api/UserDetails/GetUsers").Result;
            userslist = response.Content.ReadAsAsync<IList<TBLUserInfo>>().Result;
            return View(userslist);
        }

        [HttpGet]
        public ActionResult GetUsersByIdmvc(int id)
        {
            response = client.GetAsync("api/UserDetails/GetUsersByID/" + id).Result;

            var user = response.Content.ReadAsAsync<TBLUserInfo>().Result;

            TBLUserInfo user1 = new TBLUserInfo
            {
                IdUs = user.IdUs,
                UserRole = user.UserRole,
                Email = user.Email,
                MobileNumber = user.MobileNumber,
                UsernameUs = user.UsernameUs,
                PasswordUs = user.PasswordUs,
                RePasswordUs = user.RePasswordUs
            };

            return View(user1);
        }


        [HttpGet]
        public ActionResult GetUsersByNamemvc(string name)
        {
            response = client.GetAsync("api/UserDetails/GetUsersByNAME/" + name).Result;

            var user = response.Content.ReadAsAsync<TBLUserInfo>().Result;
            if (response.IsSuccessStatusCode)
            {

                TBLUserInfo user1 = new TBLUserInfo
                {
                    IdUs = user.IdUs,
                    UserRole = user.UserRole,
                    Email = user.Email,
                    MobileNumber = user.MobileNumber,
                    UsernameUs = user.UsernameUs,
                    PasswordUs = user.PasswordUs,
                    RePasswordUs = user.RePasswordUs
                };


                return View(user1);
            }
            else return RedirectToAction("Index", "Home");


        }



        [HttpGet]
        public ActionResult AddUsermvc()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUsermvcc(TBLUserInfo u)
        {
            TBLUserInfo user2 = new TBLUserInfo
            {
                //IdUs = u.IdUs,
                UserRole = u.UserRole,
                Email = u.Email,
                MobileNumber = u.MobileNumber,
                UsernameUs = u.UsernameUs,
                PasswordUs = u.PasswordUs,
                RePasswordUs = u.RePasswordUs
            };
            response = client.PostAsJsonAsync("api/UserDetails/AddUser/", user2).Result;

            return RedirectToAction("GetUsersmvc");
        }


        [HttpGet]
        public ActionResult AllUsersListAdmin()
        {
            return RedirectToAction("GetUsersmvc", "Users");
        }
    }
}
