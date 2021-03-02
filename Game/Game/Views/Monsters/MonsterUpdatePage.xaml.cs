using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.ViewModels;
using Game.Models;

namespace Game.Views
{
    /// <summary>
    /// Item Update Page
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonsterUpdatePage : ContentPage
    {
        // Constants for monster stat input
        private const int MAX_VALUE_STAT = 10;
        private const int MIN_VALUE_STAT = 0;

        // View Model for Item
        public readonly GenericViewModel<MonsterModel> ViewModel;

        // Empty Constructor for Tests
        public MonsterUpdatePage(bool UnitTest){ }

        /// <summary>
        /// Constructor that takes and existing data item
        /// </summary>
        public MonsterUpdatePage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Update " + data.Title;

        }

        /// <summary>
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            // If the name in the data box is empty, display the alert
            if (string.IsNullOrEmpty(ViewModel.Data.Name) || string.IsNullOrWhiteSpace(ViewModel.Data.Name))
            {
                return;
            }

            MessagingCenter.Send(this, "Update", ViewModel.Data);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancel and close this page
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
            else if (sender == Defense_Slider)
            {
                Defense_Value.Text = String.Format("{0:00}", (int)args.NewValue);
                ViewModel.Data.Defense = (int)args.NewValue;
            }
            else if (sender == Speed_Slider)
            {
                Speed_Value.Text = String.Format("{0:00}", (int)args.NewValue);
                ViewModel.Data.Speed = (int)args.NewValue;
            }

        }
    }
}