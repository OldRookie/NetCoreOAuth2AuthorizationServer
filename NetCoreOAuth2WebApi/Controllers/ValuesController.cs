using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreOAuth2WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //this is a basic code snippet to validate the scope inside the API
            bool userHasRightScope = User.HasClaim("scope", AuthServerConfig.SCOPE_READ);
            if (userHasRightScope == false)
            {
                throw new Exception("Invalid scope");
            }
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            //this is a basic code snippet to validate the scope inside the API
            bool userHasRightScope = User.HasClaim("scope", AuthServerConfig.SCOPE_READ);
            if (userHasRightScope == false)
            {
                throw new Exception("Invalid scope");
            }
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            //this is a basic code snippet to validate the scope inside the API
            bool userHasRightScope = User.HasClaim("scope", AuthServerConfig.SCOPE_WRITE);
            if (userHasRightScope == false)
            {
                throw new Exception("Invalid scope");
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            //this is a basic code snippet to validate the scope inside the API
            bool userHasRightScope = User.HasClaim("scope", AuthServerConfig.SCOPE_WRITE);
            if (userHasRightScope == false)
            {
                throw new Exception("Invalid scope");
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //this is a basic code snippet to validate the scope inside the API
            bool userHasRightScope = User.HasClaim("scope", AuthServerConfig.SCOPE_WRITE);
            if (userHasRightScope == false)
            {
                throw new Exception("Invalid scope");
            }
        }
    }
}
