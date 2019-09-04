using System;
using Xamarin.Forms;

namespace Breathe2.Controls
{
    public class CustomLabel: Label
    {
        public CustomLabel()
        {
        }

        public static readonly BindableProperty KerningProperty = BindableProperty.Create(
            propertyName: nameof(Kerning),
            returnType: typeof(float),
            declaringType: typeof(CustomLabel),
            defaultValue: 0.0f,
            defaultBindingMode: BindingMode.TwoWay);

        public float Kerning
        {
            get { return (float)GetValue(KerningProperty); }
            set { SetValue(KerningProperty, value); }
        }
    }
}