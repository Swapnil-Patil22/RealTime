using System;
namespace RealtimeMobile.Manager
{
    public class LanguageManager
    {
        static LanguageManager _manager;
        public static LanguageManager Instance
        {
            get
            {
                if (_manager == null)
                    _manager = new LanguageManager();

                return _manager;
            }
        }

        public void SetLanguage(string language)
        {
            //if (Application.Current.Properties.ContainsKey("Lang"))
            //Application.Current.Properties["Lang"] = language;
            Xamarin.Essentials.Preferences.Set("Lang", language);
            //else
            //    Application.Current.Properties.Add("Lang", language);
        }

        public string GetLanguage()
        {
            var lang = Xamarin.Essentials.Preferences.Get("Lang", "Arabic");
            //if (Application.Current.Properties.ContainsKey("Lang"))
            //    return Application.Current.Properties["Lang"].ToString();
            return lang;
        }
    }
}
