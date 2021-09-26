using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QC.Repository
{
    public class ProjectSchedule
    {
        Lib.DataAccess dataacess = new Lib.DataAccess();

        public DataTable Get(string id)
        {
            return dataacess.GetDataTable("usp_ScheduleGet", id);
        }

    }
}
