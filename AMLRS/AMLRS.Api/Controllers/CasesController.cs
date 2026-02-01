using AMLRS.Application.DTOs;
using AMLRS.Application.Interfaces;
using AMLRS.Application.Interfaces.Services;
using AMLRS.Core.QueryModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMLRS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasesController : ControllerBase
    {
        private readonly ICaseService _service;

        public CasesController(ICaseService service)
        {
            _service = service;
        }

        //[HttpGet]
        //[ProducesResponseType(typeof(IEnumerable<EntityDataDto>), StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetAllCases([FromQuery] CaseQueryParams query)
        //{
        //    var result = await _service.GetAllCasesAsync(query);
        //    return Ok(result);
        //}
    }
}
