using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcmePortal.Business.Interfaces;
using AcmePortal.Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcmePortal.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AcmeActivityController : ControllerBase
    {
        private IAcmeActivityManager _acmeActivityManager;
        public AcmeActivityController(IAcmeActivityManager acmeActivityManager)
        {
            _acmeActivityManager = acmeActivityManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<VAcmeActivity> result = _acmeActivityManager.GetAllRecords();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewRecord([FromBody] VAcmeActivity act)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int returnCode = await _acmeActivityManager.AddNewRecord(act);
            return Ok(returnCode);
        }
    }
}
