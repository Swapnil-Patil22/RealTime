using System;
using RealtimeMobile.CustomControls;
using RealtimeMobile.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace RealtimeMobile.iOS.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                //Control.BackgroundColor =  UIColor.FromRGB(255, 255, 255);
                Control.BorderStyle = UITextBorderStyle.None;
            }
        }
    }
}
