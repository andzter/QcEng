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

        public DataTable GetAllProjects()
        {
            return dataacess.GetDataTable("select * from projects");
        }

        public DataTable CommunicationProject(string userid)
        {
            return dataacess.GetDataTable("select id,ReferenceNo, Project as Subject, DocDate, RoutedTo, Remarks  from projects");
        }

        public DataTable MyList(string userid)
        {
            return dataacess.GetDataTable("usp_GetMyProject", userid);
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
            return dataacess.GetDataTable("GetProjectInspectionList", userId);
        }

        public DataTable GetProjectHistory(string id)
        {
            return dataacess.GetDataTable("GetProjectHistory", id);
        }


        public void SaveRoute(params object[] args)
        {
            dataacess.ExecuteNonQuery("usp_ProjectSaveRoute", args);
        }


    }
}
