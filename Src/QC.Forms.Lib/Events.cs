using System;
using Telerik.WinControls.UI;

namespace QC.Forms.Lib
{
    public class SearchEventArgs : EventArgs
    {
        // add local member variable to hold text
        private string mquerycond;
        private string mquerydisp;

        // class constructor
        public SearchEventArgs(string querycond, string querydisp)
        {
            mquerycond = querycond;
            mquerydisp = querydisp;
        }

        // Properties - Accessible by the listener

        public string QueryCond
        {
            get
            {
                return mquerycond;
            }
        }

        public string QueryDisplay
        {
            get
            {
                return mquerydisp;
            }
        }

    }

    public class FindUpdateEventArgs : EventArgs
    {
        // add local member variable to hold text
        private readonly string mselectedvalue;
        private readonly GridViewRowInfo mrow;

        // class constructor
        public FindUpdateEventArgs(string selectedvalue)
        {
            mselectedvalue = selectedvalue;
            mrow = null;
        }

        // class constructor
        public FindUpdateEventArgs(string selectedvalue, GridViewRowInfo rowinfo)
        {
            mselectedvalue = selectedvalue;
            mrow = rowinfo;
        }



        // Properties - Accessible by the listener

        public string SelectedValue
        {
            get
            {
                return mselectedvalue;
            }
        }

        public GridViewRowInfo SelectedRow
        {
            get
            {
                return mrow;
            }
        }
    }

    public class FileGenEventArgs : EventArgs
    {
        // add local member variable to hold text
        private int mpercent;


        // class constructor
        public FileGenEventArgs(int percent)
        {
            this.mpercent = percent;
        }

        // Properties - Accessible by the listener

        public int Percent
        {
            get
            {
                return mpercent;
            }
        }


    }
}
