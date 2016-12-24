using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Anime_Pics
{
    public sealed partial class AttentionBox : UserControl
    {
        public AttentionBox()
        {
            this.InitializeComponent();
        }

        public string Id { get; set; }
        public string Message { get; set; }
        public AttentionBoxButton[] Buttons { get; set; }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(3);
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey(Id))
            {
                (Parent as Panel).Children.Clear();
                return;
            }
            ApplicationData.Current.LocalSettings.Values.Add(Id, true);
            await Task.Delay(1000);
            messageBox.Text = Message != null ? Message : "" ;
            if(Buttons != null)
            foreach (var b in Buttons)
            {
                Button button = new Button() { HorizontalAlignment = HorizontalAlignment.Stretch, Content = b.Text };
                button.Click += (o, ea) => { b.OnClick.DynamicInvoke(); };
                buttonsPanel.Children.Add(button);
            }

            FadeInPopup.Begin();
        }
    }

    public class AttentionBoxButton
    {
        public string Text { get; set; }
        public Action OnClick { get; set; }
        
        public AttentionBoxButton(string text, Action onClick)
        {
            Text = text;
            OnClick = onClick;
        }
    }
}
