using CoreGraphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CoreAnimation;
using System.Drawing;
using System.ComponentModel;
using Foundation;
using RealtimeMobile.CustomControls;
using RealtimeMobile.iOS.Renderers;

[assembly: ExportRenderer(typeof(MaterialFrame), typeof(MaterialFrameRenderer))]
namespace RealtimeMobile.iOS.Renderers
{
    public class MaterialFrameRenderer : VisualElementRenderer<Frame>
    {

        [Xamarin.Forms.Internals.Preserve(Conditional = true)]
        public MaterialFrameRenderer()
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            var elem = (MaterialFrame)this.Element;
            if (elem != null)
            {
                // Border
                this.Layer.CornerRadius = 10;
                //this.Layer.Bounds.Inset((int)elem.BorderThickness, (int)elem.BorderThickness);
                Layer.BorderColor = elem.BorderColor.ToCGColor();
                Layer.BorderWidth = (float)elem.BorderThickness;
            }
        }
    }
}