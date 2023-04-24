using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealtimeMobile.Helper
{
        [ContentProperty("Text")]
        public class TranslateExtension : IMarkupExtension
        {
            const string ResourceId = "RealtimeMobile.AppResources";

            static readonly Lazy<ResourceManager> resmgr = new Lazy<ResourceManager>(() => new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly));

            public string Text { get; set; }

            public object ProvideValue(IServiceProvider serviceProvider)
            {
            try { 
                if (Text == null)
                    return "";

                CultureInfo ci = null;
                var lang = Manager.LanguageManager.Instance.GetLanguage();
                if (lang == "English")
                {
                    ci = new CultureInfo("en");
                }
                else if (lang == "Arabic")
                {
                    //ci = new CultureInfo("tr");
                    ci = new CultureInfo("ar");
                    ci.DateTimeFormat.Calendar = new System.Globalization.UmAlQuraCalendar();
                }

                var translation = resmgr.Value.GetString(Text, ci);

                if (translation == null)
                {

#if DEBUG
                    throw new ArgumentException(
                        String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, ci.Name), "Text");
#else
				translation = Text; // returns the key, which GETS DISPLAYED TO THE USER
#endif
                }
                return translation;
            }
            catch
            {
                return null;
            }
        }

        }
    }
