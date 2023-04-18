using System;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using Xamarin.Forms;
using RealtimeMobile.CustomControls;
using RealtimeMobile.Droid.Renderers;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(EntryRendererAndroid))]
namespace RealtimeMobile.Droid.Renderers
{
    public class EntryRendererAndroid : EntryRenderer
    {
        public EntryRendererAndroid(Context context) : base(context) { }
        public static void Init()
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Background = null;
                //Control.TextSize = 10;
                Control.LongClickable = false;
                Control.SetHintTextColor(Android.Graphics.Color.LightGray);
            }
        }
    }
}

