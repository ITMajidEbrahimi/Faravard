


namespace Fanavard_DB.General.F_Interfaces
{
    public interface IDB
    {
        public System.Threading.Tasks.Task<int> QueryAsync(string SP_Name, Dapper.DynamicParameters param = null);
    }
}
