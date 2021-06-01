using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QC.Repository
{
    public class Users
    {
        Lib.DataAccess dataacess = new Lib.DataAccess();

        public DataTable GetUsers()
        {
            return dataacess.GetDataTable("select * from users");
        }

        public DataTable CommunicationProject(string userid)
        {
            return dataacess.GetDataTable("select * from projects");
        }

        public string LoginUser(string username, string password)
        {
            return dataacess.ExecSQLScalarSP("usp_Login_user", username, password).ToString();
        }

    }
}
