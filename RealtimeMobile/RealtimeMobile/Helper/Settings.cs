using System;
using System.Linq;
using Xamarin.Forms;

namespace RealtimeMobile.Helper
{
	public class Settings
	{
        static Settings _setting;
        public static Settings Instance
        {
            get
            {
                if (_setting == null)
                    _setting = new Settings();
                return _setting;
            }
        }

        public FlowDirection GetFlowDirection()
        {
            var lang = Manager.LanguageManager.Instance.GetLanguage();
            if (lang == "English")
            {
                return FlowDirection.LeftToRight;
            }
            else if (lang == "Arabic")
            {
                return FlowDirection.RightToLeft;
            }
            else
            {
                return FlowDirection.RightToLeft;
            }
        }

        public bool IsPopupStackContains()
        {
            if (Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopupStack.Any())
            {
                return true;
            }
            else
                return false;
        }
    }
}

