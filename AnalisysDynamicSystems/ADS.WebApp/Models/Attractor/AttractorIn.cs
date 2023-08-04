namespace ADS.WebApp.Models.Attractor
{
    public class AttractorIn
    {
        public string DynamicSystemName { get; set; }
        public uint Width { get; set; } = 400;
        public uint Height { get; set; } = 400;
        public uint CountIteration { get; set; } = 1_000_000;
        public Dictionary<string, float> Parametrs { get; set; } = new();
    }
}
