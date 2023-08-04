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
using ADS.WebApp.Models.Attractor;

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

        [HttpPost(nameof(DynamicSystemsController.CreateAttractor))]
        public string CreateAttractor(AttractorIn attractorIn)
        {
            var ourtype = typeof(DynamicSystem);
            var type = Assembly.GetAssembly(ourtype)
                .GetTypes()
                .Where(type => type.IsSubclassOf(ourtype))
                .Where(t => !CoreProgramm.GetIsHidden(t))
                .Where(t => CoreProgramm.GetDisplayNameAttribute(t) == attractorIn.DynamicSystemName)
                .FirstOrDefault();
            if (type == null) throw new Exception($"Не существует {attractorIn.DynamicSystemName} - динамической системы");
            var dynamicSystem = Activator.CreateInstance(type) as DynamicSystem;
            
            foreach(var parametr in attractorIn.Parametrs)
            {
                dynamicSystem[parametr.Key] = parametr.Value;
            }

            var mapParametr = new MapingParametr()
            {
                Width = attractorIn.Width,
                Height = attractorIn.Height,

                NameParametrWidth = default,
                StartParametrWidth = default,
                EndParametrWidth = default,

                NameParametrHeight = default,
                StartParametrHeight = default,
                EndParametrHeight = default,
            };

            var calculate = new AttractorCalculate(dynamicSystem);
            var result = calculate.GetResult(new AttractorParametr()
            {
                CountIteration = attractorIn.CountIteration
            });
            var mapintAttractor = new AttractorMaping();
            var matrix = mapintAttractor.GetResult(result, mapParametr);
            return new CreaterImg().GetBase64(matrix);
        }
    }
}
