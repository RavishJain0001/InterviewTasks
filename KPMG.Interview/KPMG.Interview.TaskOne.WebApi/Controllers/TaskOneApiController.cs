using Microsoft.AspNetCore.Mvc;

namespace KPMG.Interview.TaskOne.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskOneApiController : ControllerBase
    {
        private ILogger<TaskOneApiController> logger;
        private IConfiguration configuration;

        public TaskOneApiController(ILogger<TaskOneApiController> logger,IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
        }

        [HttpGet]
        public string Get()
        {
            var dbRepository = new DbRepository.DbRepository(configuration);
            var webApiResponse = "Hello From WebApi." + dbRepository.GetData();
            return webApiResponse;
        }
    }
}