﻿using ADS.Core;
using ADS.Core.ConcritCalculate;
using ADS.Core.ConcritCalculate.Niding;
using ADS.Core.ConcritDynamicSystems;
using ADS.Core.ConcritMaping;
using ADS.Core.ConcritMaping.MapColor;
using ADS.Core.OtherCalculation;

var dynamicSystem = new LorenzDynamicSystem();
var mapParametr = new MapingParametr()
{
    Width = 600,
    Height = 600,
    
    NameParametrWidth = nameof(LorenzDynamicSystem.R),
    StartParametrWidth = 5,
    EndParametrWidth = 120,
    
    NameParametrHeight = nameof(LorenzDynamicSystem.Sigma),
    StartParametrHeight = 0,
    EndParametrHeight = 60,
};
var parametrs = new NidingParametr()
{
    Depth = 12,
    CountIteration = 100_000,
    Steap = 0.001f,
};
var attractorCalculate = new NidingCalculation(dynamicSystem);



var result = MapCalculate.GetMap(attractorCalculate, parametrs, mapParametr);
var mapintAttractor = new NidingMaping(new DefaultNidingMapColor());
var matrix = mapintAttractor.GetResult(result, mapParametr);
new CreaterImg().Create(matrix);