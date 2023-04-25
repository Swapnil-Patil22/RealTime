using System;
using Xamarin.Forms;

namespace RealtimeMobile.CustomControls
{
    public class MaterialFrame : Frame
    {
        public MaterialFrame()
        {
        }

        public static BindableProperty ElevationProperty = BindableProperty.Create(nameof(Elevation), typeof(float), typeof(MaterialFrame), 4.0f);

        public float Elevation
        {
            get
            {
                return (float)GetValue(ElevationProperty);
            }
            set
            {
                SetValue(ElevationProperty, value);
            }
        }

        public static BindableProperty BorderThicknessProperty = BindableProperty.Create(nameof(BorderThickness), typeof(float), typeof(MaterialFrame), 0.0f);

        public float BorderThickness
        {
            get
            {
                return (float)GetValue(BorderThicknessProperty);
            }
            set
            {
                SetValue(BorderThicknessProperty, value);
            }
        }
    }
}