// See https://aka.ms/new-console-template for more information

using ADS.Core;
using ADS.Core.ConcritCalculate;
using ADS.Core.ConcritCalculate.Niding;
using ADS.Core.ConcritDynamicSystems;
using ADS.Core.ConcritMaping;
using ADS.Core.OtherCalculation;

var dynamicSystem = new LorenzDynamicSystem();
var mapParametr = new MapingParametr();
var parametrs = new NidingParametr()
{
    Depth = 2,
    CountIteration = 100_000,
    Steap = 0.001f,
};
var attractorCalculate = new NidingCalculation(dynamicSystem);



var result = MapCalculate.GetMap(attractorCalculate, parametrs, mapParametr);
var mapintAttractor = new NidingMaping();
var matrix = mapintAttractor.GetResult(result, mapParametr);
new CreaterImg().Create(matrix);