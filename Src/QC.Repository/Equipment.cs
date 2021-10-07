using QC.Lib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QC.Repository
{
    public class Equipment
    {
        Lib.DataAccess dataacess = new Lib.DataAccess();

        public DataTable Get(params object[] args)
        {
            return dataacess.GetDataTable("usp_ProjectEquipmentGet", args);
        }

        public DataTable GetList(params object[] args)
        {
            return dataacess.GetDataTable("usp_ProjectEquipmentGetList", args);
        }

        public DataRow Save(params object[] args)
        {
            // @id [nvarchar](50),   @ProjectId[nvarchar](50), @Order[Int],	@Equipment[nvarchar](500),	@UnitNo[nvarchar](50),	@user[nvarchar](50)
            return dataacess.GetDataRow("usp_ProjectEquipmentSave", args);
        }


        public int Delete(params object[] args)
        {
            return dataacess.ExecSQLScalarSP("usp_ProjectEquipmentDelete", args).ToString().ToInt();
        }
    }
}
