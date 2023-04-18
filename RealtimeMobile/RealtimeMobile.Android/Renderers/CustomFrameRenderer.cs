using System;
using AndroidX.Core.View;
using System.ComponentModel;
using RealtimeMobile.CustomControls;
using RealtimeMobile.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using Android.Graphics;

[assembly: ExportRenderer(typeof(Customframe), typeof(CustomFrameRenderer))]
namespace RealtimeMobile.Droid.Renderers
{
    public class CustomFrameRenderer : Xamarin.Forms.Platform.Android.AppCompat.FrameRenderer
    {
        public CustomFrameRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            CardElevation = 0;
            SetOutlineSpotShadowColor(Xamarin.Forms.Color.Transparent.ToAndroid());
            SetOutlineAmbientShadowColor(Xamarin.Forms.Color.Transparent.ToAndroid());
        }

    }
}

