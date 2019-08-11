namespace PriceApp.BusinessLogic.FileService
{
    #region Usings
    using System.IO;
    using PriceApp.BusinessLogic.Models;
    using System.Globalization;
    #endregion

    public static class ConfigurationFileHelper
    {
        private static string FolderPath = Directory.GetCurrentDirectory();
        private static string FileName = "ConfigurationSettings";
        private static FileExtension FileExtension = FileExtension.txt;

        public static bool IsCreated => File.Exists(FileModel.FullPath);

        public static void WriteConfigurationSettings(ConfigurationSettings configuration)
        {
            if (!IsCreated)
            {
                File.Create(FileModel.FullPath);
            }
            using (FileStream fs = new FileStream(FileModel.FullPath, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(configuration.Culture.ToString());
                    sw.WriteLine(configuration.FolderPath);
                    sw.WriteLine(configuration.Executor);
                    sw.WriteLine(configuration.RefinancingRate);
                }
            }
        }

        public static ConfigurationSettings ReadFromFileConfigurationSettings()
        {
            ConfigurationSettings configuration = new ConfigurationSettings();
            if (IsCreated)
            {
                using (FileStream fs = new FileStream(FileModel.FullPath, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        var firstLine = sr.ReadLine();
                        if (!string.IsNullOrWhiteSpace(firstLine))
                        {
                            configuration.Culture = new CultureInfo(firstLine);
                            configuration.FolderPath = sr.ReadLine();
                            configuration.Executor = sr.ReadLine();
                            configuration.RefinancingRate = double.Parse(sr.ReadLine());
                        }
                    }
                }
            }

            return configuration;
        }

        public static CultureInfo GetCulture()
        {
            if (File.Exists(FileModel.FullPath))
            {
                using (FileStream fs = new FileStream(FileModel.FullPath, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        var firstLine = sr.ReadLine();
                        if (!string.IsNullOrWhiteSpace(firstLine))
                        {
                            return new CultureInfo(firstLine);
                        }
                    }
                }
            }
            return null;
        }

        public static FileModel FileModel
        {
            get => new FileModel()
            {
                FolderPath = FolderPath,
                FileName = FileName,
                FileExtension = FileExtension
            };
        }
    }
}

