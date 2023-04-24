using System;
using CoreGraphics;
using Foundation;
using RealtimeMobile.CustomControls;
using RealtimeMobile.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(StrokeLabel), typeof(StrokeLabelRenderer))]
namespace RealtimeMobile.iOS.Renderers
{
	public class StrokeLabelRenderer : LabelRenderer
    {
        //protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        //{
        //    base.OnElementChanged(e);

        //    StrokeLabel myCustomLabel = Element as StrokeLabel;
        //    if (Control != null)
        //    {
        //        UIStringAttributes strokeTextAttributes = new UIStringAttributes();
        //        // Here is set the StrokeColor
        //        strokeTextAttributes.StrokeColor = myCustomLabel.StrokeColor.ToUIColor();
        //        //Here is set the StrokeThickness, IOS is diferert from the android, it border is set to the inside the font.
        //        strokeTextAttributes.StrokeWidth = -1 * myCustomLabel.StrokeThickness;

        //        Control.AttributedText = new NSAttributedString(Control.Text, strokeTextAttributes);
        //        //Control.TextColor = UIColor.Black;
        //    }
        //}
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            StrokeLabel myCustomLabel = Element as StrokeLabel;
            OutLineLabel outLineLabel = new OutLineLabel(Element.Text, myCustomLabel.StrokeColor, myCustomLabel.TextColor, myCustomLabel.StrokeThickness, myCustomLabel.CustomFontSize);
            SetNativeControl(outLineLabel);
        }
    }
}

public class OutLineLabel : UILabel
{
    UIColor strokecolor, textcolor;
    int strokethickness;

    public OutLineLabel(string text, Color StrokeColor, Color TextColor, int StrokeThickness, float customfontsize)
    {
        this.Text = text;
        strokecolor = StrokeColor.ToUIColor();
        textcolor = TextColor.ToUIColor();
        strokethickness = StrokeThickness;
        LineBreakMode = UILineBreakMode.WordWrap;
        Lines = 0;
        TextAlignment = UITextAlignment.Center;
        this.Font = Font.WithSize(customfontsize);
    }
    public override void DrawText(CGRect rect)
    {

        CGSize shadowOffset = this.ShadowOffset;
        UIColor textColor = textcolor;  //the text color


        CGContext c = UIGraphics.GetCurrentContext();
        c.SetLineWidth(2);
        c.SetLineJoin(CGLineJoin.Round);
        c.SetTextDrawingMode(CGTextDrawingMode.Stroke);
        this.TextColor = strokecolor;    //the outline border color
        base.DrawText(rect);

        c.SetTextDrawingMode(CGTextDrawingMode.Fill);
        this.TextColor = textColor;
        this.ShadowOffset = new CGSize(0, 0);
        base.DrawText(rect);
        this.ShadowOffset = shadowOffset;
    }
}
