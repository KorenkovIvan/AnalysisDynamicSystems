using ADS.Core;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Runtime.CompilerServices;

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

        [HttpGet(nameof(DynamicSystemsController.GetDynamicSystems))]
        public IEnumerable<string> GetDynamicSystems()
        {
            var ourtype = typeof(DynamicSystem);
            var list = Assembly.GetAssembly(ourtype)
                .GetTypes()
                .Where(type => type.IsSubclassOf(ourtype))
                .Where(t => !CoreProgramm.GetIsHidden(t))
                .Select(CoreProgramm.GetDisplayNameAttribute);

            return list;
        }

        [HttpGet(nameof(DynamicSystemsController.GetParametrsDynamicSystems))]
        public IEnumerable<string> GetParametrsDynamicSystems(string dynamicSystemName)
        {
            var ourtype = typeof(DynamicSystem);
            var type = Assembly.GetAssembly(ourtype)
                .GetTypes()
                .Where(type => type.IsSubclassOf(ourtype))
                .Where(t => !CoreProgramm.GetIsHidden(t))
                .Where(t => CoreProgramm.GetDisplayNameAttribute(t) == dynamicSystemName)
                .FirstOrDefault();
            if (type == null) throw new Exception($"Не существует {dynamicSystemName} - динамической системы");
            var ds = Activator.CreateInstance(type) as DynamicSystem;
            return ds.GetParametrs();
        }

        [HttpGet(nameof(DynamicSystemsController.GetCalculate))]
        public IEnumerable<string> GetCalculate(string dynamicSystemName)
        {
            var ourtype = typeof(Calculate<dynamic, dynamic>);
            var list = Assembly.GetAssembly(ourtype)
                .GetTypes()
                .Where(type => type.IsSubclassOf(ourtype))
                .Where(t => !CoreProgramm.GetIsHidden(t))
                .Select(CoreProgramm.GetDisplayNameAttribute);

            return list;
        }
    }
}
