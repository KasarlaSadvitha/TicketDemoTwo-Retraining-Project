using TicketDemoCoreWebApi.Models;

namespace TicketDemoCoreWebApi.Repository
{
    public interface IRepositoryAuthentication
    {
        bool checkUserExists(TBLUserInfo tbl1);

    }
}
