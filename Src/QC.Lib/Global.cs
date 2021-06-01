using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QC.Lib
{
    public class Global
    {
        public static string UserId()
        {
            return Settings.GetSetting("userid");
        }

        public static string UserName()
        {
            return Settings.GetSetting("username");
        }
    }
}
