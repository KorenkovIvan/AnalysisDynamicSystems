using ADS.Core;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ADS.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DynamicSystemsController : Controller
    {
        private readonly ILogger<DynamicSystemsController> _logger;

        public DynamicSystemsController(ILogger<DynamicSystemsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetDynamicSystems")]
        public IEnumerable<string> GetDynamicSystems()
        {
            Type ourtype = typeof(DynamicSystem);
            IEnumerable<string> list = Assembly.GetAssembly(ourtype)
                .GetTypes()
                .Where(type => type.IsSubclassOf(ourtype))
                .Where(t => !CoreProgramm.GetIsHidden(t))
                .Select(CoreProgramm.GetDisplayNameAttribute);

            return list;
        }
    }
}
