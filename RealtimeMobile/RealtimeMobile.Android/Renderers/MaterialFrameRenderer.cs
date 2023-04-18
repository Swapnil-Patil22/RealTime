using System;
using AndroidX.Core.View;
using System.ComponentModel;
using RealtimeMobile.CustomControls;
using RealtimeMobile.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content;


[assembly: ExportRenderer(typeof(MaterialFrame), typeof(MaterialFrameRenderer))]
namespace RealtimeMobile.Droid.Renderers
{
    public class MaterialFrameRenderer : Xamarin.Forms.Platform.Android.AppCompat.FrameRenderer
    {
        public MaterialFrameRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            var element = e.NewElement as MaterialFrame;
            if (element == null) return;
            if (element.HasShadow)
            {
                CardElevation = 50;
                SetOutlineSpotShadowColor(Xamarin.Forms.Color.Black.ToAndroid());
                SetOutlineAmbientShadowColor(Xamarin.Forms.Color.Black.ToAndroid());
            }
        }

    }
}

