using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Coding4Fun.Phone.Controls;

namespace PushSDK.Controls
{
    public class PushNotificationMessage : MessagePrompt
    {
        public PushNotificationMessage(IDictionary<string, string> collection)
        {
            var stack = new StackPanel {VerticalAlignment = VerticalAlignment.Top, HorizontalAlignment = HorizontalAlignment.Center};
            Body = stack;

            stack.Children.Add(new TextBlock {Text = "Show push details?", FontSize = 24});

            if (collection.ContainsKey("wp:Text1"))
                stack.Children.Add(new TextBlock {Text = collection["wp:Text1"], FontSize = 20});

            if (collection.ContainsKey("wp:Text2"))
                stack.Children.Add(new TextBlock {Text = collection["wp:Text2"], FontSize = 18, TextWrapping = TextWrapping.Wrap});

            IsCancelVisible = true;
        }
    }
}