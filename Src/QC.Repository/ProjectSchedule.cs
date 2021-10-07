using ChoETL;
using QC.Lib;
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


        public int Save(string projectId, string dupaId, int day, double qty)
        {
            return dataacess.ExecSQLScalarSP("usp_SchedSave", projectId, dupaId, day, qty, Lib.Global.UserId()).ToString().ToInt();
        }


    }
}
