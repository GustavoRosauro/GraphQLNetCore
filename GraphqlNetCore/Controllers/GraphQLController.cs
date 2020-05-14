using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphqlNetCore.Querys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GraphqlNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GraphQLController : ControllerBase
    {
        private readonly BlogSchema _schema;
        public GraphQLController(BlogSchema schema)
        {
            _schema = schema;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();
            using (var schema = _schema)
            {
                var result = await new DocumentExecuter().ExecuteAsync(_ =>
                {
                    _.Schema = schema;
                    _.Query = query.Query;
                    _.OperationName = query.OperationName;
                    _.Inputs = inputs;
                }).ConfigureAwait(false);
                if (result.Errors?.Count > 0)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
        }
    }
}
