using Microsoft.AspNetCore.Mvc;
using TicketDemoCoreWebApi.DataAccessLayer;
using TicketDemoCoreWebApi.Models;
using TicketDemoCoreWebApi.Repository;

namespace TicketDemoCoreWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        MovieRepository repo;
        RepositoryAuthentication repoA;
        TicketDALContext _ticketDAL;
        public HomeController(TicketDALContext c)
        {
            repo = new MovieRepository(c);
            repoA = new RepositoryAuthentication(c);
            _ticketDAL = c;
        }
        //https://localhost:7018/

        [HttpPost]
        public ActionResult<string> Signup(TBLUserInfo tbl1)
        {
            if (repoA.checkUserExists(tbl1))
            {

                //String s = new String("false");
                return Ok(true);
                // return "false" ;
            }

            else
            {

                return "false";
                //Session["IdUsSS"] = tbl1.IdUs.ToString();
                //Session["UsernameSS"] = tbl1.UsernameUs.ToString();
                //Session["UserId"] = tbl1.IdUs.ToString();

                //return RedirectToAction("Index", "Home");
            }

        }
        public ActionResult<string> Login(string Username, string Password)
        {
            var checkLogin = _ticketDAL.TBLUserInfoes.Where(x => x.UsernameUs.Equals(Username) && x.PasswordUs.Equals(Password)).FirstOrDefault();
            if (checkLogin == null) { return "false"; }
            else { return "true"; }
        }




    }
}
