using Game.Models;
using Game.ViewModels;

using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    /// <summary>
    /// Create Item
    /// </summary>
    [DesignTimeVisible(false)] 
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonsterCreatePage : ContentPage
    {
        // Constants for monster stat input
        private const int MAX_VALUE_STAT = 10;
        private const int MIN_VALUE_STAT = 0;

        // The Monster to create
        public GenericViewModel<MonsterModel> ViewModel = new GenericViewModel<MonsterModel>();

        // Empty Constructor for UTs
        public MonsterCreatePage(bool UnitTest){}

        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public MonsterCreatePage()
        {
            InitializeComponent();

            this.ViewModel.Data = new MonsterModel();

            BindingContext = this.ViewModel;

            this.ViewModel.Title = "Monster Create";

        }

        /// <summary>
        /// Save by calling for Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            // If the name in the data box is empty, display the alert
            if (string.IsNullOrEmpty(ViewModel.Data.Name) || string.IsNullOrWhiteSpace(ViewModel.Data.Name))
            {
                await DisplayAlert("Invalid Input!", "Please enter a valid name.", "Return");
                return;
            }

            // If the job is not selected, display the alert
            if (ViewModel.Data.Job == CharacterJobEnum.Unknown)
            {
                await DisplayAlert("Missing Information!", "Please choose a Class for the person.", "Return");
                return;
            }

            // If the character's stats in the data box is invalid, display the alert
            if (!Is_Stat_Valid(Attack_Value.Text) ||
                !Is_Stat_Valid(Defense_Value.Text) ||
                !Is_Stat_Valid(Speed_Value.Text))
            {
                await DisplayAlert("Invalid Input!", "Please enter a valid value for character's stats. The input must be integers and between 0 and 10.", "Okay");
                return;
            }

            MessagingCenter.Send(this, "Create", ViewModel.Data);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancel the Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Check if the inputs for stat is valid or not
        /// </summary>
        /// <param name="stat_str"></param>
        /// <returns></returns>
        public bool Is_Stat_Valid(string stat_str)
        {
            if (int.TryParse(stat_str, out int stat))
            {
                if (stat >= MIN_VALUE_STAT && stat <= MAX_VALUE_STAT)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Change the displayed image on Class Picker change
        /// </summary>
        public void Image_OnPickerSourceChange(object sender, System.EventArgs e)
        {
            string imageURI = ViewModel.Data.Job.ToString().ToLower() + ".png";

            ViewModel.Data.ImageURI = imageURI;

            MonsterImage.Source = ViewModel.Data.ImageURI;
        }
    }
}