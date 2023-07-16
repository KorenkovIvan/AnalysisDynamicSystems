using ADS.Core;
using ADS.Core.ConcritCalculate;
using ADS.Core.ConcritCalculate.Niding;
using ADS.Core.ConcritDynamicSystems;
using ADS.Core.ConcritMaping;
using ADS.Core.ConcritMaping.MapColor;
using ADS.Core.ConsoleWriter;
using ADS.Core.OtherCalculation;

var dynamicSystem = new ShimizyMoriokaDynamicSystem();
var mapParametr = new MapingParametr()
{
    Width = 100,
    Height = 100,
    
    NameParametrWidth = nameof(ShimizyMoriokaDynamicSystem.Lambda),
    StartParametrWidth = 0f,
    EndParametrWidth = 2f,
    
    NameParametrHeight = nameof(ShimizyMoriokaDynamicSystem.Alpha),
    StartParametrHeight = 0f,
    EndParametrHeight = 2f,
};
var parametrs = new NidingParametr()
{
    Depth = 12,
    CountIteration = 1_000_000,
    Steap = 0.01f,
};
var attractorCalculate = new NidingCalculation(dynamicSystem);

var _consoleWriter = new DefaultConsoleWriter();
ParallelMapCalculate.OnCloseRow += _consoleWriter.Write;
var result = ParallelMapCalculate.GetMap(attractorCalculate, parametrs, mapParametr);
var mapintAttractor = new NidingMaping(new DefaultNidingMapColor());
var matrix = mapintAttractor.GetResult(result, mapParametr);
new CreaterImg().Create(matrix);