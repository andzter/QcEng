using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QC.Repository
{
    public class ProjectBom
    {
        Lib.DataAccess dataacess = new Lib.DataAccess();

        public DataTable GetProjectBom()
        {
            return dataacess.GetDataTable("select a.ProjectId, a.ItemCode, b.description,b.unit,c.derivation, a.Length, a.Width, a.Depth,a.Thickness," +
                "a.NumFactor1, a.NumFactor2, a.NumFactor3, a.ADLength, a.ADWidth, a.ADThickness, a.ADNoofUnits, a.SectionalArea, "+
                "a.NoofUnits, a.WtMetricTon " +
                "from ProjectBom a " +
                "left join dupa b on " +
                "a.itemcode = b.itemcode " +
                "left join dupaderivation c on " +
                "a.itemcode = c.itemcode");
        }

        public DataRow SaveProjectBom(params object[] args)
        {
            return dataacess.GetDataRow("usp_ProjectBomSaveNew", args);
        }

        public DataRow GetProjectBombyId(string id)
        {
            return dataacess.GetDataRow("usp_ProjectBomGetbyId", id);
        }
    }
}
