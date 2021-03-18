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
                MonsterName.BackgroundColor = Color.Red;
                return;
            }

            // If the job is not selected, display the alert
            if (ViewModel.Data.Job == CharacterJobEnum.Unknown)
            {
                LocationPicker.BackgroundColor = Color.Red;
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
        /// Change and assign value on slider value change
        /// </summary>
        /// <param name="stat_str"></param>
        /// <returns></returns>
        public void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            if (sender == Attack_Slider)
            {
                Attack_Value.Text = String.Format("{0:00}", (int)args.NewValue);
                ViewModel.Data.Attack = (int)args.NewValue;
            }
            if (sender == Defense_Slider)
            {
                Defense_Value.Text = String.Format("{0:00}", (int)args.NewValue);
                ViewModel.Data.Defense = (int)args.NewValue;
            }
            if (sender == Speed_Slider)
            {
                Speed_Value.Text = String.Format("{0:00}", (int)args.NewValue);
                ViewModel.Data.Speed = (int)args.NewValue;
            }

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