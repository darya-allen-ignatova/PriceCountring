namespace PriceApp.UI.Settings
{
    #region Usings
    using System;
    using System.Globalization;
    using System.Windows;
    using Caliburn.Micro;
    using PriceApp.UI.Configuration;
    #endregion

    public class SettingsViewModel : Screen
    {
        public SettingsViewModel()
        {
            LocalizationSettings.LanguageChanged += LanguageChanged;

            CultureInfo currLang = LocalizationSettings.Language;

            //Заполняем меню смены языка:
            menuLanguage.Items.Clear();
            foreach (var lang in LocalizationSettings.Languages)
            {
                MenuItem menuLang = new MenuItem();
                menuLang.Header = lang.DisplayName;
                menuLang.Tag = lang;
                menuLang.IsChecked = lang.Equals(currLang);
                menuLang.Click += ChangeLanguageClick;
                menuLanguage.Items.Add(menuLang);
            }
        }

        private void LanguageChanged(Object sender, EventArgs e)
        {
            CultureInfo currLang = LocalizationSettings.Language;

            //Отмечаем нужный пункт смены языка как выбранный язык
            foreach (MenuItem i in menuLanguage.Items)
            {
                CultureInfo ci = i.Tag as CultureInfo;
                i.IsChecked = ci != null && ci.Equals(currLang);
            }
        }

        private void ChangeLanguageClick(Object sender, EventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            if (mi != null)
            {
                CultureInfo lang = mi.Tag as CultureInfo;
                if (lang != null)
                {
                    LocalizationSettings.Language = lang;
                }
            }

        }

    }
}
