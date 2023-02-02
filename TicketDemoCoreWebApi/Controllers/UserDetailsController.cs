using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketDemoCoreWebApi.DataAccessLayer;
using TicketDemoCoreWebApi.Models;
using TicketDemoCoreWebApi.Repository;

namespace TicketDemoCoreWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        UserRepository repo;
        public UserDetailsController(TicketDALContext c)
        {
            repo = new UserRepository(c);
        }

        [HttpGet]
        public ActionResult<IEnumerable<TBLUserInfo>> GetUsers()
        {
            return repo.GetAllUsers().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<TBLUserInfo> GetUsersByID(int id)
        {
            TBLUserInfo user = repo.GetUsersById(id);
            return user;
        }

        [HttpGet("{name}")]
        //[HttpGet]
        public ActionResult<TBLUserInfo> GetUsersByNAME(string name)
        {
            TBLUserInfo user = repo.GetUsersByName(name);
            return user;
        }

        [HttpPost]
        public IActionResult AddUser(TBLUserInfo user)
        {
            return Ok(repo.AddAUser(user));
        }


    }
}
