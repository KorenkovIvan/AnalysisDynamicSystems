using ADS.Core;
using ADS.Core.ConcritCalculate.Attractor;
using ADS.Core.ConcritDynamicSystems;
using ADS.Core.ConcritMaping;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System;
using System.IO;

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
        public IEnumerable<string> GetCalculate()
        {
            var ourtype = typeof(DynamicSystem);
            var list = Assembly.GetAssembly(ourtype)
                .GetTypes()
                .Where(CoreProgramm.GetIsAdsResult)
                .Select(x => x.ToString());

            return list;
        }

        [HttpGet(nameof(DynamicSystemsController.GetDynamicSystemInfo))]
        public DynamicSystemInfo GetDynamicSystemInfo(string dynamicSystemName)
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
            var list = Assembly.GetAssembly(ourtype)
                .GetTypes()
                .Where(CoreProgramm.GetIsAdsResult)
                .Select(x => x.ToString())
                .ToList();

            return new DynamicSystemInfo
            {
                Name = dynamicSystemName,
                Parametrs = ds.GetParametrsWithValues(),
                ListCalculate = list,
            };
        }

        [HttpGet(nameof(DynamicSystemsController.CreateAttractor))]
        public string CreateAttractor(string dynamicSystemName)
        {
            var mapParametr = new MapingParametr()
            {
                Width = 400,
                Height = 400,

                NameParametrWidth = nameof(ShimizyMoriokaDynamicSystem.Lambda),
                StartParametrWidth = 0f,
                EndParametrWidth = 2f,

                NameParametrHeight = nameof(ShimizyMoriokaDynamicSystem.Alpha),
                StartParametrHeight = 0f,
                EndParametrHeight = 2f,
            };

            var dynamicSystem = new LorenzDynamicSystem();
            var calculate = new AttractorCalculate(dynamicSystem);
            var result = calculate.GetResult(new AttractorParametr()
            {
                CountIteration = 1_000_000
            });
            var mapintAttractor = new AttractorMaping();
            var matrix = mapintAttractor.GetResult(result, mapParametr);
            return new CreaterImg().GetBase64(matrix);
        }
    }
}
