using Microsoft.EntityFrameworkCore;
using TicketDemoCoreWebApi.Models;

namespace TicketDemoCoreWebApi.Repository
{
    public interface IUserRepository
    {
        DbSet<TBLUserInfo> GetAllUsers();
        TBLUserInfo GetUsersById(int UserId);
        TBLUserInfo GetUsersByName(string name);

        bool AddAUser(TBLUserInfo user);
    }
}
