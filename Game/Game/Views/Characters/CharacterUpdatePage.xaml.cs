using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.ViewModels;
using Game.Models;
using System.Collections.Generic;

namespace Game.Views
{
    /// <summary>
    /// Item Update Page
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterUpdatePage : ContentPage
    {
        // Constants for character stat input
        private const int MAX_VALUE_STAT = 10;
        private const int MIN_VALUE_STAT = 0;

        // View Model for Character
        public readonly GenericViewModel<CharacterModel> ViewModel;

        // Empty Constructor for Tests
        public CharacterUpdatePage(bool UnitTest){ }

        /// <summary>
        /// Constructor that takes and existing data item
        /// </summary>
        public CharacterUpdatePage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();

            data.HandItemList = Get_Item_List_BasedOn_Location("Hand");
            data.HeadItemList = Get_Item_List_BasedOn_Location("Head");
            data.FingerItemList = Get_Item_List_BasedOn_Location("Finger");

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
                await DisplayAlert("Invalid Input!", "Please enter a valid name.", "Return");
                return;
            }

            // If the character's stats in the data box is invalid, display the alert
            if (!Is_Stat_Valid(Health_Value.Text) ||
                !Is_Stat_Valid(Attack_Value.Text) ||
                !Is_Stat_Valid(Defense_Value.Text) ||
                !Is_Stat_Valid(Speed_Value.Text))
            {
                await DisplayAlert("Invalid Input!", "Please enter a valid value for character's stats. The input must be integers and between 0 and 10.", "Okay");
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
        /// Get all the items for a set location
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public List<string> Get_Item_List_BasedOn_Location(string location)
        {
            ItemIndexViewModel ItemList = ItemIndexViewModel.Instance;
            List<string> result = new List<string>();
            if (location == "Hand")
            {
                foreach (var item in ItemList.GetLocationItems(ItemLocationEnum.PrimaryHand))
                {
                    result.Add(item.Name);
                }
            }
            else if (location == "Head")
            {
                foreach (var item in ItemList.GetLocationItems(ItemLocationEnum.Head))
                {
                    result.Add(item.Name);
                }
            }
            else if (location == "Finger")
            {
                foreach (var item in ItemList.GetLocationItems(ItemLocationEnum.Finger))
                {
                    result.Add(item.Name);
                }
            }

            return result;
        }
    }
}