using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QC.Repository
{
    public class EquipmentCost
    {
        Lib.DataAccess dataacess = new Lib.DataAccess();

        public DataTable GetEquipmentCost()
        {
            return dataacess.GetDataTable("select id, Description, Model, FlyWheelHP, " +
                " Output, RentalHour1 as [Rental Hour1]," +
                " RentalHour2 as [Rental Hour2], Remarks from EquipmentCost");
        }

        public DataRow SaveEquipmentCost(params object[] args)
        {
            return dataacess.GetDataRow("usp_EquipmentCostSave", args);
        }

        public DataRow GetEquipmentCostbyId(string id)
        {
            return dataacess.GetDataRow("usp_EquipmentCostGetbyId", id);
        }
    }
}
