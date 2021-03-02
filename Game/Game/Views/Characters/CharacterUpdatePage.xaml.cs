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
            if (sender == Level_Slider)
            {
                Level_Value.Text = String.Format("{0:00}", (int)args.NewValue);
                ViewModel.Data.Level = (int)args.NewValue;
            }
            else if (sender == Health_Slider)
            {
                Health_Value.Text = String.Format("{0:00}", (int)args.NewValue);
                ViewModel.Data.MaxHealth = (int)args.NewValue;
            }
            else if (sender == Attack_Slider)
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