using System.ComponentModel;
using System.Text;
using Android.Content;
using Android.Text;
using Android.Text.Style;
using breath.Droid.Renderers;
using Breathe2.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static Android.Widget.TextView;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]
namespace breath.Droid.Renderers
{
    public class CustomLabelRenderer : LabelRenderer
    {
        public CustomLabelRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var cLabel = Element as CustomLabel;
                ApplyKerning(cLabel.Kerning);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var cLabel = Element as CustomLabel;
            if (CustomLabel.KerningProperty.PropertyName == e.PropertyName)
            {
                Control.Text = cLabel.Text;
                ApplyKerning(cLabel.Kerning);
            }
            else if (Label.TextProperty.PropertyName == e.PropertyName)
            {
                Control.Text = cLabel.Text;
                ApplyKerning(cLabel.Kerning);
            }
        }
        void ApplyKerning(float mKerningFactor)
        {
            if (Control.Text == null)
            {
                return;
            }
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Control.Text.Length; i++)
            {
                builder.Append(Control.Text[i]);
                if (i + 1 < Control.Text.Length)
                {
                    builder.Append("\u00A0");
                }
            }
            SpannableString finalText = new SpannableString(builder.ToString());
            if (builder.ToString().Length > 1)
            {
                for (int i = 1; i < builder.ToString().Length; i += 2)
                {
                    finalText.SetSpan(new ScaleXSpan((mKerningFactor) / 6), i, i + 1, SpanTypes.ExclusiveExclusive);
                }
            }
            Control.SetText(finalText, BufferType.Spannable);
        }

    }
}