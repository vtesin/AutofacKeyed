using Autofac.Features.AttributeFilters;
using AutofacKeyed.Model;
using AutofacKeyed.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AutofacKeyed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ICommandWrapper<TxnReq, TxnRe> _commandWrapper;
        private readonly ICommandWrapper<TxnReq, TxnRe> _remoteWrapper;

        public ValuesController([KeyFilter(WrapperTypes.DbWrapper)]ICommandWrapper<TxnReq, TxnRe> commandWrapper,
            [KeyFilter(WrapperTypes.RemoteService)]ICommandWrapper<TxnReq, TxnRe> remoteCommandWrapper)
        {
            _commandWrapper = commandWrapper;
            _remoteWrapper = remoteCommandWrapper;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var req = new TxnReq { SeqId = 1, Reference = "123" };
            _commandWrapper.Execute(req);
            _remoteWrapper.Execute(req);

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
