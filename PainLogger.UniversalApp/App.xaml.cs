using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MyToolkit.Controls;
using MyToolkit.Paging;
using MyToolkit.Paging.Animations;
using MyToolkit.UI;
using PainLogger.UniversalApp.Views;
using SampleUwpApp;
using SampleUwpApp.Views;

namespace PainLogger.UniversalApp
{
    sealed partial class App : MtApplication
    {
        private HamburgerFrameBuilder _hamburgerFrameBuilder;

        public App()
        {
            InitializeComponent();
        }

        public override Type StartPageType => typeof (SampleUwpApp.Views.MainPage);

        public override FrameworkElement CreateWindowContentElement()
        {
            _hamburgerFrameBuilder = new HamburgerFrameBuilder();

            SearchHamburgerItem searchItem = new SearchHamburgerItem
            {
                PlaceholderText = "Search"
            };
            searchItem.QuerySubmitted += async (sender, args) =>
            {
                await _hamburgerFrameBuilder.Frame.NavigateToExistingOrNewPageAsync(typeof (MedicinePage));
                MedicinePage medicinePage = (MedicinePage) _hamburgerFrameBuilder.Frame.CurrentPage.Page;
                medicinePage.Model.Filter = args.QueryText;
            };

            _hamburgerFrameBuilder.Hamburger.Header = new HamburgerHeader();
            _hamburgerFrameBuilder.Hamburger.TopItems = new ObservableCollection<HamburgerItem>
            {
                new PageHamburgerItem
                {
                    Content = "Home",
                    ContentIcon = new SymbolIcon(Symbol.Home),
                    Icon = new SymbolIcon(Symbol.Home),
                    PageType = typeof (SampleUwpApp.Views.MainPage)
                },
                searchItem,
                new PageHamburgerItem
                {
                    Content = "Movie",
                    ContentIcon = new SymbolIcon(Symbol.Video),
                    Icon = new SymbolIcon(Symbol.Video),
                    PageType = typeof (MoviePage)
                },
                new PageHamburgerItem
                {
                    Content = "Article",
                    ContentIcon = new SymbolIcon(Symbol.PreviewLink),
                    Icon = new SymbolIcon(Symbol.PreviewLink),
                    PageType = typeof (SampleListPage)
                },
                new PageHamburgerItem
                {
                    Content = "Medicine",
                    ContentIcon = new SymbolIcon(Symbol.Help),
                    Icon = new SymbolIcon(Symbol.Help),
                    PageType = typeof (MedicinePage)
                }
            };
            _hamburgerFrameBuilder.Hamburger.BottomItems = new ObservableCollection<HamburgerItem>
            {
                new PageHamburgerItem
                {
                    Content = "Settings",
                    ContentIcon = new SymbolIcon(Symbol.Setting),
                    Icon = new SymbolIcon(Symbol.Setting),
                    PageType = typeof (SettingsPage)
                }
            };
            _hamburgerFrameBuilder.Frame.PageAnimation = new ScalePageTransition();
            return _hamburgerFrameBuilder.Hamburger;
        }

        public override MtFrame GetFrame(UIElement windowContentElement)
        {
            return _hamburgerFrameBuilder.Frame;
        }

        public override async Task OnInitializedAsync(MtFrame frame, ApplicationExecutionState args)
        {
            //await HideStatusBarAsync();
        }

        //private async Task HideStatusBarAsync()
        //{
        //    if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
        //    {
        //        var statusBar = StatusBar.GetForCurrentView();
        //        await statusBar.HideAsync();
        //    }
        //}

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            base.OnLaunched(args);
            ApplicationViewUtilities.ConnectRootElementSizeToVisibleBounds();
        }
    }
}