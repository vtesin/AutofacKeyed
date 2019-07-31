using System;
using AutofacKeyed.Model;
using AutofacKeyed.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Autofac.Features.Indexed;

namespace AutofacKeyed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ICommandWrapper<ITxnReq, ITxnRe> _commandWrapper;
        private readonly ICommandWrapper<ITxnReq, ITxnRe> _remoteWrapper;

        public ValuesController(IIndex<WrapperTypes, Func<ICommandWrapper<ITxnReq, ITxnRe>>> wrapperFactories)
        {
            _commandWrapper = wrapperFactories[WrapperTypes.DbWrapper]();
            _remoteWrapper = wrapperFactories[WrapperTypes.RemoteService]();
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
