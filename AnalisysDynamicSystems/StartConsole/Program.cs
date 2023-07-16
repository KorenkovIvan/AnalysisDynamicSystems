using ADS.Core;
using ADS.Core.ConcritCalculate;
using ADS.Core.ConcritCalculate.Niding;
using ADS.Core.ConcritDynamicSystems;
using ADS.Core.ConcritMaping;
using ADS.Core.ConcritMaping.MapColor;
using ADS.Core.OtherCalculation;

var dynamicSystem = new ShimizyMoriokaDynamicSystem();
var mapParametr = new MapingParametr()
{
    Width = 400,
    Height = 400,
    
    NameParametrWidth = nameof(ShimizyMoriokaDynamicSystem.Lambda),
    StartParametrWidth = 0,
    EndParametrWidth = 2,
    
    NameParametrHeight = nameof(ShimizyMoriokaDynamicSystem.Alpha),
    StartParametrHeight = 0,
    EndParametrHeight = 2,
};
var parametrs = new NidingParametr()
{
    Depth = 12,
    CountIteration = 1_000_000,
    Steap = 0.01f,
};
var attractorCalculate = new NidingCalculation(dynamicSystem);



var result = ParallelMapCalculate.GetMap(attractorCalculate, parametrs, mapParametr);
var mapintAttractor = new NidingMaping(new DefaultNidingMapColor());
var matrix = mapintAttractor.GetResult(result, mapParametr);
new CreaterImg().Create(matrix);