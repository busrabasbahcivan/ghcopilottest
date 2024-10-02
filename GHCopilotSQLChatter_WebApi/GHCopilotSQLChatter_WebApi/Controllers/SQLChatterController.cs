using GHCopilotSQLChatter_WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using static GHCopilotSQLChatter_WebApi.Repositories.SQLChatterRepository;

namespace GHCopilotSQLChatter_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SQLChatterController : ControllerBase
    {
        private readonly SQLChatterRepository _SQLChatterRepository;

        public SQLChatterController(SQLChatterRepository sqlChatterRepository)
        {
            _SQLChatterRepository = sqlChatterRepository;
        }

        //https://localhost:7029/SQLChatter/execute-query
        [HttpPost("execute-query")]
        public ActionResult<QueryResult> ExecuteQuery([FromBody] string query)
        {
            var result = _SQLChatterRepository.ExecuteQuery(query);

            if (!string.IsNullOrEmpty(result.ErrorMessage))
            {
                return BadRequest(new { Error = result.ErrorMessage });
            }

            return Ok(result);
        }
    }
}
