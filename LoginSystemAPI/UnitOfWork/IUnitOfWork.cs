using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace LoginSystemAPI.UnitOfWork
{
    public interface IUnitOfWork 
    {
        #region Transaction

        void SaveChanges();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void CreateSavepoint(string name);
        void RollbackToSavepoint(string name);
        DbConnection GetConnection();
        DbTransaction GetTransaction();

        #endregion

        #region StoredProcedure

        public DataSet ExecuteStoredProcedure(string procedureName, IEnumerable<SqlParameter> parameters, DbConnection dbConnection, DbTransaction dbTransaction);
        public DataSet ExecuteStoredProcedure(string procedureName, IEnumerable<SqlParameter> parameters, DbConnection dbConnection);
        public DataTable ExecuteFunctionProcedure(string functionName, IEnumerable<SqlParameter> parameters, DbConnection dbConnection);
        public string ExecuteFunctionProcedureScalar(string functionName, IEnumerable<SqlParameter> parameters, DbConnection dbConnection);
        public string SqlBulkCopy(DataTable dataTable, DbConnection dbConnection, DbTransaction dbTransaction);

        #endregion
    }
}