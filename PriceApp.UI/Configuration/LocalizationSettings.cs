namespace PriceApp.UI.Configuration
{
    #region Usings
    using System.Windows;
    using System.Collections.Generic;
    using System.Globalization;
    using System;
    using System.Threading;
    using System.Linq;
    using PriceApp.BusinessLogic.FileService;
    #endregion

    public partial class LocalizationSettings : Application
    {
        private static List<CultureInfo> cultures = new List<CultureInfo>();

        public static List<CultureInfo> Cultures => cultures;

        static LocalizationSettings()
        {
            cultures.Clear();
            cultures.AddRange(new List<CultureInfo>()
            {
                new CultureInfo("ru-RU"),
                new CultureInfo("en-US")
            });
            var culture = ConfigurationFileHelper.GetCulture();
            if (culture != null)
            {
                Culture = culture;
            }
        }

        public static CultureInfo Culture
        {
            get => Thread.CurrentThread.CurrentUICulture;
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                if (value == System.Threading.Thread.CurrentThread.CurrentUICulture) return;

                System.Threading.Thread.CurrentThread.CurrentUICulture = value;

                ResourceDictionary dictionary = new ResourceDictionary();
                switch (value.Name)
                {
                    case "ru-RU":
                        dictionary.Source = new Uri("Resources/lang.xaml", UriKind.Relative);
                        break;
                    default:
                        dictionary.Source = new Uri($"Resources/lang.{value.Name}.xaml", UriKind.Relative);
                        break;
                }

                ResourceDictionary oldDictionary = 
                    (from d in Current.Resources.MergedDictionaries
                     where d.Source != null && d.Source.OriginalString.StartsWith("Resources/lang.")
                     select d).First();
                if (oldDictionary != null)
                {
                    int indexOfOldDictionary = Current.Resources.MergedDictionaries.IndexOf(oldDictionary);
                    Current.Resources.MergedDictionaries.Remove(oldDictionary);
                    Current.Resources.MergedDictionaries.Insert(indexOfOldDictionary, dictionary);
                }
                else
                {
                    Current.Resources.MergedDictionaries.Add(dictionary);
                }
            }
        }
    }
}

