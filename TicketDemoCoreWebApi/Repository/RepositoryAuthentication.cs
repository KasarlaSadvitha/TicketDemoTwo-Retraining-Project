using TicketDemoCoreWebApi.DataAccessLayer;
using TicketDemoCoreWebApi.Models;

namespace TicketDemoCoreWebApi.Repository
{
    public class RepositoryAuthentication:IRepositoryAuthentication
    {

        public readonly TicketDALContext _ticketDAL;
        public RepositoryAuthentication(TicketDALContext ticketDAL)
        {
            _ticketDAL = ticketDAL;
        }
        public bool checkUserExists(TBLUserInfo tbl1)
        {
            if (_ticketDAL.TBLUserInfoes.Any(x => x.UsernameUs == tbl1.UsernameUs))
            {
                //String s = new String("false"); 
                return false;
            }

            else
            {
                _ticketDAL.TBLUserInfoes.Add(tbl1);
                _ticketDAL.SaveChanges();

                return true;

            }


        }

    }
}
