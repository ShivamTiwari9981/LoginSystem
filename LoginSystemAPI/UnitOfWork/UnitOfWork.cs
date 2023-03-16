using LoginSystemAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Data.Common;

namespace LoginSystemAPI.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private LoginDbContext _repoContext;

        public UnitOfWork()
            : this(new LoginDbContext()) { }

        public UnitOfWork(LoginDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        #region Transaction

        public void SaveChanges()
        {
            _repoContext.SaveChanges();
        }

        private bool _beginTrans;
        public void BeginTransaction()
        {
            if (!_beginTrans)
            { 
                _repoContext.Database.BeginTransaction();
                _beginTrans = true;
            }
            else
            {
                _repoContext.Database.RollbackTransaction();
                _repoContext.Database.BeginTransaction();
                _beginTrans = true;
            }
        }

        public void CommitTransaction()
        {
            if (_beginTrans)
            {
                _repoContext.Database.CommitTransaction();
                _beginTrans = false;
            }
        }

        public void RollbackTransaction()
        {
            if (_beginTrans)
            {
                _repoContext.Database.RollbackTransaction();
                _beginTrans = false;
            }
        }

        public void CreateSavepoint(string name)
        {
            _repoContext.Database.CurrentTransaction.CreateSavepoint(name);
        }

        public void RollbackToSavepoint(string name)
        {
            _repoContext.Database.CurrentTransaction.RollbackToSavepoint(name);
        }

        public DbConnection GetConnection()
        {
            return _repoContext.Database.GetDbConnection();
            //return _repoContext.Database.CurrentTransaction?.GetDbTransaction().Connection;
        }

        public DbTransaction GetTransaction()
        {
            //return _repoContext.Database.CurrentTransaction;
            return _repoContext.Database.CurrentTransaction.GetDbTransaction();
        }

        private string GetConnectionString()
        {
            return _repoContext.Database.GetDbConnection().ConnectionString;
        }

        #endregion

        #region StoredProcedure

        public DataSet ExecuteStoredProcedure(string procedureName, IEnumerable<SqlParameter> parameters, DbConnection dbConnection, DbTransaction dbTransaction)
        {
            using (var cmd = dbConnection.CreateCommand())
            {
                cmd.Transaction = dbTransaction;
                cmd.CommandText = procedureName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                if (parameters != null && parameters.Any())
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }
                using (var da = DbProviderFactories.GetFactory(dbConnection).CreateDataAdapter())
                {
                    da.SelectCommand = cmd;
                    var ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }
        public DataSet ExecuteStoredProcedure(string procedureName, IEnumerable<SqlParameter> parameters, DbConnection dbConnection)
        {
            using (var cmd = dbConnection.CreateCommand())
            {
                cmd.CommandText = procedureName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                if (parameters != null && parameters.Any())
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }
                using (var da = DbProviderFactories.GetFactory(dbConnection).CreateDataAdapter())
                {
                    da.SelectCommand = cmd;
                    var ds = new DataSet();
                    da.Fill(ds);
                    if (dbConnection.State == ConnectionState.Open)
                        dbConnection.Close();
                    return ds;
                }
            }
        }
        public DataTable ExecuteFunctionProcedure(string functionName, IEnumerable<SqlParameter> parameters, DbConnection dbConnection)
        {
            using (var cmd = dbConnection.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM DBO." + functionName;
                if (parameters != null && parameters.Any())
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }
                using (var da = DbProviderFactories.GetFactory(dbConnection).CreateDataAdapter())
                {
                    da.SelectCommand = cmd;
                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public string ExecuteFunctionProcedureScalar(string functionName, IEnumerable<SqlParameter> parameters, DbConnection dbConnection)
        {
            using (var cmd = dbConnection.CreateCommand())
            {
                dbConnection.Open();
                cmd.CommandText = "SELECT DBO." + functionName;
                if (parameters != null && parameters.Any())
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }
                var result = cmd.ExecuteScalar().ToString();
                dbConnection.Close();
                return result;
            }
        }
        public string SqlBulkCopy(DataTable dataTable, DbConnection dbConnection, DbTransaction dbTransaction)
        {
            string result = string.Empty;
            var connectionString = dbConnection.ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    foreach (DataColumn c in dataTable.Columns)
                        bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);

                    bulkCopy.DestinationTableName = dataTable.TableName;
                    try
                    {
                        bulkCopy.WriteToServer(dataTable);
                        result = "S";
                    }
                    catch (Exception ex)
                    {
                        result = ex.Message;
                    }
                }
            }
            return result;
        }

        #endregion


    }
}