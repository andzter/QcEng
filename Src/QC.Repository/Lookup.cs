using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QC.Repository
{
    public class Lookup
    {

        Lib.DataAccess dataacess = new Lib.DataAccess();

        public DataTable GetUsers()
        {
            return dataacess.GetDataTable("select * from vw_userlookup");
        }

        public DataTable GetUnits()
        {
            return dataacess.GetDataTable("select * from Units order by unit");
        }

        public DataTable GetClassifications()
        {
            return dataacess.GetDataTable("select * from LaborClassification order by classification");


        }

        public DataTable GetLaborCostCombo()
        {
            return dataacess.GetDataTable("select id, Description from LaborCost order by Description");
        }

        public DataTable GetEquipmentCostCombo()
        {
            return dataacess.GetDataTable("select id, Description from EquipmentCost order by Description");
        }

        public DataTable GetMaterialCostCombo()
        {
            return dataacess.GetDataTable("select id, Description from MaterialCost order by Description");
        }

        public DataTable GetTeams()
        {
            return dataacess.GetDataTable("exec usp_teamslookup");
        }
    }
}
