using HMS.Controls;
using HMS.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BetterEntry), typeof(BetterEntryRenderer))]
namespace HMS.iOS
{
    public class BetterEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.BorderStyle = UIKit.UITextBorderStyle.None;
                if (Element != null)
                {
                    Element.HeightRequest = 35;
                    Element.Margin = new Thickness(5, 0, 5, 0);
                }

                UITextField textField = (UITextField)Control;
                textField.Font = UIFont.FromName("AvenirLTStd Roman", 13);
            }
        }
    }
}
