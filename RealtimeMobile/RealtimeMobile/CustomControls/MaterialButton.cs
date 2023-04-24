using System;
using Xamarin.Forms;

namespace RealtimeMobile.CustomControls
{
	public class MaterialButton : Button
    {
        public static BindableProperty ElevationProperty = BindableProperty.Create(nameof(Elevation), typeof(float), typeof(MaterialButton), 4.0f);

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

        public static BindableProperty ShadowColorProperty = BindableProperty.Create(nameof(ShadowColor), typeof(Color), typeof(MaterialButton), Color.Transparent);

        public Color ShadowColor
        {
            get
            {
                return (Color)GetValue(ShadowColorProperty);
            }
            set
            {
                SetValue(ShadowColorProperty, value);
            }
        }
    }
}