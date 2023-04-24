using System;
using Xamarin.Forms;

namespace RealtimeMobile.CustomControls
{
    public class StrokeLabel : Label
    {
        public static readonly BindableProperty StrokeColorProperty = BindableProperty.Create(nameof(StrokeColor), typeof(Color), typeof(StrokeLabel), Color.Transparent);
        public Color StrokeColor
        {
            get { return (Color)base.GetValue(StrokeColorProperty); }
            set { base.SetValue(StrokeColorProperty, value); }
        }

        public static readonly BindableProperty StrokeThicknessProperty = BindableProperty.CreateAttached("StrokeThickness", typeof(int), typeof(StrokeLabel), 0);
        public int StrokeThickness
        {
            get { return (int)base.GetValue(StrokeThicknessProperty); }
            set { base.SetValue(StrokeThicknessProperty, value); }
        }

        public static readonly BindableProperty CustomFontSizeProperty = BindableProperty.CreateAttached("CustomFontSize", typeof(int), typeof(StrokeLabel), 0);
        public int CustomFontSize
        {
            get { return (int)base.GetValue(CustomFontSizeProperty); }
            set { base.SetValue(CustomFontSizeProperty, value); }
        }
    }
}