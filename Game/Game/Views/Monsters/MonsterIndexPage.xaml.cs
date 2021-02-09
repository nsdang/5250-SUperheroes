using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.Models;
using Game.ViewModels;

namespace Game.Views
{
    /// <summary>
    /// Index Page
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0019:Use pattern matching", Justification = "<Pending>")]
    [DesignTimeVisible(false)] 
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonsterIndexPage : ContentPage
    {
        // The view model, used for data binding
        readonly MonsterIndexViewModel ViewModel = MonsterIndexViewModel.Instance;

        // Empty Constructor for UTs
        public MonsterIndexPage(bool UnitTest) { }

        /// <summary>
        /// Constructor for Index Page
        /// 
        /// Get the MonsterIndexView Model
        /// </summary>
        public MonsterIndexPage()
        {
            InitializeComponent();

            BindingContext = ViewModel;
        }

        /// <summary>
        /// The image clicked by should show the corresponding monster read page. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void OnImageClicked(object sender, EventArgs e)
        {
            ImageButton img = sender as ImageButton;
            MonsterModel selected = img.BindingContext as MonsterModel;
            if (selected == null)
            {
                return;
            }

            // Open the Read Page
            await Navigation.PushAsync(new MonsterReadPage(new GenericViewModel<MonsterModel>(selected)));

        }


        /// <summary>
        /// if the trash icon is clicked, it should take the user to the delete page
        /// of that specific monster
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void OnImageDeleted(object sender, EventArgs e)
        {
            ImageButton img = sender as ImageButton;
            MonsterModel selected = img.BindingContext as MonsterModel;
            if (selected == null)
            {
                return;
            }

            await Navigation.PushModalAsync(new NavigationPage(new MonsterDeletePage(new GenericViewModel<MonsterModel>(selected))));
        }

        /// <summary>
        /// Call to Add a new record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void AddMonster_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MonsterCreatePage()));
        }

        /// <summary>
        /// Refresh the list on page appearing
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = null;

            // If no data, then set it for needing refresh
            if (ViewModel.Dataset.Count == 0)
            {
                ViewModel.SetNeedsRefresh(true);
            }

            // If the needs Refresh flag is set update it
            if (ViewModel.NeedsRefresh())
            {
                ViewModel.LoadDatasetCommand.Execute(null);
            }

            BindingContext = ViewModel;
        }
    }
}