using ADS.Core;
using ADS.Core.ConcritCalculate;
using ADS.Core.ConcritCalculate.Attractor;
using ADS.Core.ConcritCalculate.Niding;
using ADS.Core.ConcritDynamicSystems;
using ADS.Core.ConcritMaping;
using ADS.Core.ConcritMaping.MapColor;
using ADS.Core.ConsoleWriter;
using ADS.Core.OtherCalculation;

var mapParametr = new MapingParametr()
{
    Width = 800,
    Height = 800,

    NameParametrWidth = nameof(ShimizyMoriokaDynamicSystem.Lambda),
    StartParametrWidth = 0f,
    EndParametrWidth = 2f,

    NameParametrHeight = nameof(ShimizyMoriokaDynamicSystem.Alpha),
    StartParametrHeight = 0f,
    EndParametrHeight = 2f,

    
};

var dynamicSystem = new LorenzDynamicSystem();
var calculate = new LyapynovAttractorCalculate(dynamicSystem);
var maper = new AttractorLyapynovMaping();
var result = calculate.GetResult(new AttractorParametr()
{
    CountIteration = 1_000_000,
    Steap = 0.001f,
});
var matrix = maper.GetResult(result, mapParametr);
new CreaterImg().Create(matrix);

//var dynamicSystem = new ShimizyMoriokaDynamicSystem();

//var parametrs = new NidingParametr()
//{
//    Depth = 12,
//    CountIteration = 1_000_000,
//    Steap = 0.01f,
//};
//var attractorCalculate = new NidingCalculation(dynamicSystem);

//var _consoleWriter = new DefaultConsoleWriter();
//ParallelMapCalculate.OnCloseRow += _consoleWriter.Write;
//var result = ParallelMapCalculate.GetMap(attractorCalculate, parametrs, mapParametr);
//var mapintAttractor = new NidingMaping(new DefaultNidingMapColor());
//var matrix = mapintAttractor.GetResult(result, mapParametr);
//new CreaterImg().Create(matrix);