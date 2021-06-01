using System.Data;

namespace QC.Lib
{
    public interface IDBPersist
    {
        int PersistFromDatabase(IDataReader rdr);
    }
}
