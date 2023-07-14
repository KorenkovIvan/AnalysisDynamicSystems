// See https://aka.ms/new-console-template for more information

using ADS.Core;
using ADS.Core.ConcritCalculate;
using ADS.Core.ConcritDynamicSystems;
using ADS.Core.ConcritMaping;

var dynamicSystem = new LorenzDynamicSystem();
var parametrs = new AttractorParametr()
{
    CountIteration = 100_000,
    Steap = 0.001f,
};
var attractorCalculate = new AttractorCalculate(dynamicSystem);



var result = attractorCalculate.GetResult(parametrs);
var mapintAttractor = new AttractorMaping();
var matrix = mapintAttractor.GetResult(result, new MapingParametr());
new CreaterImg().Create(matrix);