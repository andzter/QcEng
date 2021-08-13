using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QC.Repository
{
    public class Project
    {

        Lib.DataAccess dataacess = new Lib.DataAccess();


        public DataTable GetAllCommunications()
        {
            return dataacess.GetDataTable("select * from vw_Communication");
        }

        public DataTable GetAllProjects()
        {
            return dataacess.GetDataTable("select * from projects");
        }

     
        public DataTable MyTask(string userid)
        {
            return dataacess.GetDataTable("usp_GetMyTask", userid);
        }

        public DataRow SaveNewProject(params object[] args)
        {
            return dataacess.GetDataRow("usp_ProjectSaveNew", args);
        }

        public DataRow GetProjectbyId(string id)
        {
            return dataacess.GetDataRow("usp_ProjectGetbyId", id);
        }

        public DataTable GetProjectDesignList(string userId)
        {
            return dataacess.GetDataTable("usp_ProjectDesignList", userId);
        }

        public DataTable GetProjectFoldersList(string userId)
        {
            return dataacess.GetDataTable("usp_ProjectFolderList", userId);
        }

        public DataTable GetProjectInspectionList(string userId)
        {
            return dataacess.GetDataTable("usp_GetProjectInspectionList", userId);
        }

        public DataTable GetProjectHistory(string id)
        {
            return dataacess.GetDataTable("GetProjectHistory", id);
        }


        public void SaveRoute(params object[] args)
        {
            dataacess.ExecuteNonQuery("usp_ProjectSaveRoute", args);
        }

        public DataTable GetDataTable(string sql)
        {
            return dataacess.GetDataTable(sql);
        }


    }
}

