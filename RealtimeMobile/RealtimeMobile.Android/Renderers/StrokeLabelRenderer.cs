using System;
using Android.Content;
using Android.Graphics;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using RealtimeMobile.CustomControls;
using RealtimeMobile.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.FastRenderers;
using static System.Net.Mime.MediaTypeNames;

[assembly: ExportRenderer(typeof(StrokeLabel), typeof(StrokeLabelRenderer))]
namespace RealtimeMobile.Droid.Renderers
{
    public class StrokeLabelRenderer : Xamarin.Forms.Platform.Android.LabelRenderer
    {
        Context context;
        public StrokeLabelRenderer(Context context) : base(context)
        {
            this.context = context;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                StrokeTextView strokeTextView = new StrokeTextView(context);
                strokeTextView.Text = e.NewElement.Text;
                strokeTextView.SetTextColor(e.NewElement.TextColor.ToAndroid());
                strokeTextView.SetTextSize(ComplexUnitType.Pt, (float)e.NewElement.FontSize);
                SetNativeControl(strokeTextView);
            }
        }
    }

    class StrokeTextView : TextView
    {
        private TextView borderText = null;

        public StrokeTextView(Context context) : base(context)
        {
            borderText = new TextView(context);

            init();
        }
        public StrokeTextView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            borderText = new TextView(context, attrs);
            init();
        }
        public StrokeTextView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
            borderText = new TextView(context, attrs, defStyle);
            init();
        }



        public void init()
        {
            TextPaint tp1 = borderText.Paint;
            tp1.StrokeWidth = 5;         // sets the stroke width                        
            tp1.SetStyle(Android.Graphics.Paint.Style.Stroke);
            borderText.SetTextColor(Android.Graphics.Color.Black);  // set the stroke color
            borderText.Gravity = GravityFlags.CenterVertical;

        }


        public override ViewGroup.LayoutParams LayoutParameters { get => base.LayoutParameters; set => base.LayoutParameters = value; }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            string tt = borderText.Text;


            if (tt == null || !tt.Equals(this.Text))
            {
                borderText.Text = Text;
                this.PostInvalidate();
            }

            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
            borderText.Measure(widthMeasureSpec, heightMeasureSpec);
        }

        protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
        {
            base.OnLayout(changed, left, top, right, bottom);
            borderText.Layout(left, top, right, bottom);
        }

        protected override void OnDraw(Canvas canvas)
        {
            borderText.Draw(canvas);
            base.OnDraw(canvas);
        }
    }
}