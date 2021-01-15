using Dapper;
namespace Fanavard_DB.General.F_Classes
{
    public class DB : Fanavard_DB.General.F_Interfaces.IDB
    {
        private readonly string ConnectionString = "User Id=sa;Password=123!@#asdASD;Server=DESKTOP-3449LHC\\ME;Database=Fanavard_DB;";
        public async System.Threading.Tasks.Task<int> QueryAsync(string SP_Name, Dapper.DynamicParameters param = null)
        {
            using (System.Data.IDbConnection db = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                if (db.State == System.Data.ConnectionState.Closed)
                {
                    db.Open();
                }
                DynamicParameters parameters = new DynamicParameters();
                parameters.AddDynamicParams(param);
                parameters.Add("@Result", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);
                await db.QueryAsync<int>(SP_Name, parameters, commandType: System.Data.CommandType.StoredProcedure);
                int result = parameters.Get<int>("@Result");
                db.Dispose();
                return result;
            }
        }
    }
}