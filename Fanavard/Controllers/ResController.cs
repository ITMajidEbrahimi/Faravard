using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fanavard.Controllers
{
    public class ResController : Controller
    {
        public ResController(Fanavard_DB.General.F_Interfaces.IDB _IDB )
        {
            _db = _IDB;            
        }
        private readonly Fanavard_DB.General.F_Interfaces.IDB _db;
        private readonly Dictionary<string, string> row = new Dictionary<string, string>();
        //[HttpPost]
        //[Route("PostAndGetResult")]
        [HttpPost]
        [Route("Res/PostAndGetResult")]
        public  async Task<JsonResult>  PostAndGetResult([FromBody] dynamic _Data)
        {
            dynamic Params = Newtonsoft.Json.JsonConvert.DeserializeObject(_Data.ToString());
            int P_M = (int)Params.P_M;
            int P_k = (int)Params.P_k;
            dynamic Qty = Params.Qty;
            string Qtystr = string.Join(",", Qty);
            Dapper.DynamicParameters parameters = new Dapper.DynamicParameters();
            parameters.Add("@P_M", P_M);
            parameters.Add("@P_k", P_k);
            parameters.Add("@Type_Kalas", Qtystr);
            int res = 0;
             res = await _db.QueryAsync("[SP_Mohasebeh]", parameters);

            row.Add("Res", res.ToString());
            //parameters = null;
            return Json(row);
        }

    }
}
