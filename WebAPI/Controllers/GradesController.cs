using Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IDataAccess _dataAccess;

        public GradesController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        
        [HttpGet("statistics")]
        public async Task<ActionResult<StatisticsOverviewDto>> GetCourseStatisticAsync()
        {
            return await _dataAccess.GetStatisticsOverview();
        }
    }
}