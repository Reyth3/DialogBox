        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if(categoriesGrid.ItemsSource == null)
                categoriesGrid.ItemsSource = Base.CategoriesCollection;
            var updateNotice = new AttentionBox();
            updateNotice.Message = "{The Update Changelog}";
            updateNotice.Id = "SummerUpdateNotice";
            updateNotice.Buttons = new List<AttentionBoxButton>()
            {
                new AttentionBoxButton("Visit /r/XYZApps", async () => { await Launcher.LaunchUriAsync(new Uri("http://www.reddit.com/r/XYZApps")); }),
                new AttentionBoxButton("Download XYZ Anime Player EX", async () => { await Launcher.LaunchUriAsync(new Uri("https://www.microsoft.com/store/apps/9nblggh6d375")); }),
                new AttentionBoxButton("Close & Never Show Again", () => { popupGrid.Children.Clear(); }),
            }.ToArray();
            popupGrid.Children.Add(updateNotice);
        }