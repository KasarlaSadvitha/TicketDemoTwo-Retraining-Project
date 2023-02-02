using Microsoft.EntityFrameworkCore;
using TicketDemoCoreWebApi.DataAccessLayer;
using TicketDemoCoreWebApi.Models;

namespace TicketDemoCoreWebApi.Repository
{
    public class UserRepository:IUserRepository
    {
        public readonly TicketDALContext _ticketDAL;
        public UserRepository(TicketDALContext ticketDAL)
        {
            _ticketDAL = ticketDAL;
        }


        public bool AddAUser(TBLUserInfo user)
        {
            TBLUserInfo user1 = new TBLUserInfo
            {

                // IdUs = user.IdUs,
                UserRole = user.UserRole,
                Email = user.Email,
                MobileNumber = user.MobileNumber,
                UsernameUs = user.UsernameUs,
                PasswordUs = user.PasswordUs,
                RePasswordUs = user.RePasswordUs

            };


            _ticketDAL.TBLUserInfoes.Add(user1);

            _ticketDAL.SaveChanges();
            return true;
        }

        public DbSet<TBLUserInfo> GetAllUsers()
        {
            return _ticketDAL.TBLUserInfoes;
        }

        public TBLUserInfo GetUsersByName(string name)
        {
            //return _ticketDAL.TBLUserInfoes.Find(name);
            return _ticketDAL.TBLUserInfoes.FirstOrDefault((p) => p.UsernameUs == name);
        }
        public TBLUserInfo GetUsersById(int id)
        {
            return _ticketDAL.TBLUserInfoes.Find(id);
        }
    }
}
