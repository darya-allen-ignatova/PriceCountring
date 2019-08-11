namespace PriceApp.BusinessLogic.Models
{
    using System.Globalization;

    public class ConfigurationSettings
    {
        public CultureInfo Culture { get; set; }
        public string FolderPath { get; set; }
        public string Executor { get; set; }
        public double RefinancingRate { get; set; }
    }
}
