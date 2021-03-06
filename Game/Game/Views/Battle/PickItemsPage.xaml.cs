﻿using Game.Models;
using Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    /// <summary>
    /// The Main Game Page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickItemsPage : ContentPage
    {
        // In our game, only one dropped item can be selected and assigned
        // to a single character per user choice
        public ItemModel selectedItem;
        public PlayerInfoModel selectedCharacter;

        /// <summary>
        /// Constructor
        /// </summary>
        public PickItemsPage()
        {
            InitializeComponent();

            Proceed.IsVisible = false; 

            DrawCharacterList();

            DrawUniqueDropList();

            DrawDropList();
        }

        /// <summary>
        /// Clear and Add the Characters that survived
        /// </summary>
        public void DrawCharacterList()
        {
            // Clear and Populate the Characters Remaining
            var FlexList = CharacterListFrame.Children.ToList();
            foreach (var data in FlexList)
            {
                CharacterListFrame.Children.Remove(data);
            }

            // Draw the Characters
            foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList)
            {
                CharacterListFrame.Children.Add(CreatePlayerDisplayBox(data));
            }
        }

        /// <summary>
        /// Add the Dropped Items to the Display
        /// </summary>
        public void DrawDropList()
        {
            // Clear and Populate the Dropped Items
            var FlexList = ItemListFoundFrame.Children.ToList();
            List<ItemModel> characterEquips = Game.GameRules.DefaultData.LoadData(new ItemModel());

            foreach (var data in FlexList)
            {
                ItemListFoundFrame.Children.Remove(data);
            }

            foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Distinct())
            {
                var item = ItemIndexViewModel.Instance.GetItem(data.Id);
                if (item != null)
                {
                    ItemListFoundFrame.Children.Add(GetItemToDisplay(data));
                }
            }

            if (BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Distinct().Count() == 0)
            {
                Proceed.IsVisible = true;
            }
        }

        /// <summary>
        /// Add unique item drops to the display
        /// </summary>
        public void DrawUniqueDropList()
        {
            // Clear and Populate the Dropped Items
            var FlexList = UniqueItemListFoundFrame.Children.ToList();
            List<ItemModel> characterEquips = new List<ItemModel>();

            foreach (var data in FlexList)
            {
                UniqueItemListFoundFrame.Children.Remove(data);
            }

            foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Distinct())
            {
                var item = ItemIndexViewModel.Instance.GetItem(data.Id);
                if (item == null && characterEquips.Find(c => c.Name.Equals(data.Name)) == null)
                {
                    characterEquips.Add(data);
                }
            }

            foreach(var item in characterEquips)
            {
                UniqueItemListFoundFrame.Children.Add(GetItemToDisplay(item));
            }
        }

        /// <summary>
        /// Look up the Item to Display
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public StackLayout GetItemToDisplay(ItemModel item)
        {
            if (item == null)
            {
                return new StackLayout();
            }

            if (string.IsNullOrEmpty(item.Id))
            {
                return new StackLayout();
            }

            // Defualt Image is the Plus
            var ClickableButton = true;

            // Hookup the Image Button to show the Item picture
            var ItemButton = new ImageButton
            {
                Style = (Style)Application.Current.Resources["ImageMediumStyle"],
                Source = item.ImageURI
            };

            if (ClickableButton)
            {
                ItemButton.Clicked += (sender, args) =>
                {
                    selectedItem = new ItemModel();
                    var FlexList = ItemListSelectedFrame.Children.ToList();

                    if (FlexList.Count > 0)
                    {
                        ItemListSelectedFrame.Children.Remove(FlexList.FirstOrDefault());
                    }

                    if (selectedCharacter != null)
                    {
                        Proceed.IsVisible = true;
                    }

                    selectedItem = item;
                    ItemListSelectedFrame.Children.Add(GetItemToDisplay(item));
                };
            }

            // Put the Image Button and Text inside a layout
            var ItemStack = new StackLayout
            {
                Padding = 3,
                Style = (Style)Application.Current.Resources["ItemImageBox"],
                HorizontalOptions = LayoutOptions.Center,
                Children = {
                    ItemButton,
                },
            };

            return ItemStack;
        }

       
        /// <summary>
        /// Return a stack layout with the Player information inside
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public StackLayout CreatePlayerDisplayBox(PlayerInfoModel data)
        {
            if (data == null)
            {
                data = new PlayerInfoModel();
            }

            var PlayerImageButton = new ImageButton
            {
                Style = (Style)Application.Current.Resources["ImageMediumStyle"],
                Source = data.ImageURI
            };

            PlayerImageButton.Clicked += (sender, args) =>
            {
                selectedCharacter = new PlayerInfoModel();
                selectedCharacter = data;
                ChosenCharacter.Text = data.Name;

                if (selectedItem != null)
                {
                    Proceed.IsVisible = true;
                }
            };

            // Add the Level
            var PlayerLevelLabel = new Label
            {
                Text = "Level : " + data.Level,
                Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = 0,
                LineBreakMode = LineBreakMode.TailTruncation,
                CharacterSpacing = 1,
                LineHeight = 1,
                MaxLines = 1,
            };

            // Add the HP
            var PlayerHPLabel = new Label
            {
                Text = "HP : " + data.GetCurrentHealthTotal,
                Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = 0,
                LineBreakMode = LineBreakMode.TailTruncation,
                CharacterSpacing = 1,
                LineHeight = 1,
                MaxLines = 1,
            };

            var PlayerNameLabel = new Label()
            {
                Text = data.Name,
                Style = (Style)Application.Current.Resources["ValueStyle"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = 0,
                LineBreakMode = LineBreakMode.TailTruncation,
                CharacterSpacing = 1,
                LineHeight = 1,
                MaxLines = 1,
            };

            // Put the Image Button and Text inside a layout
            var PlayerStack = new StackLayout
            {
                Style = (Style)Application.Current.Resources["PlayerInfoBox"],
                HorizontalOptions = LayoutOptions.Center,
                Padding = 0,
                Spacing = 0,
                Children = {
                    PlayerImageButton,
                    PlayerNameLabel,
                    PlayerLevelLabel,
                    PlayerHPLabel,
                },
            };



            return PlayerStack;
        }

        /// <summary>
        /// Closes the Round Over Popup
        /// 
        /// Launches the Next Round Popup
        /// 
        /// Resets the Game Round
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CloseButton_Clicked(object sender, EventArgs e)
        {
            if (BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Distinct().Count() == 0)
            {
          
                // Reset to a new Round

                // Reset to a new Round
                BattleEngineViewModel.Instance.Engine.Round.NewRound();

                // Show the New Round Screen
                ShowModalNewRoundPage();
            }
            
            if (selectedCharacter != null && selectedItem != null)
            {
                BattleEngineViewModel.Instance.Engine.Round.SwapCharacterItem(selectedCharacter, selectedItem.Location, selectedItem); ;
                // Reset to a new Round

                // Reset to a new Round
                BattleEngineViewModel.Instance.Engine.Round.NewRound();

                // Show the New Round Screen
                ShowModalNewRoundPage();
            }
        }

        /// <summary>
        /// Show the Page for New Round
        /// 
        /// Upcomming Monsters
        /// 
        /// </summary>
        public async void ShowModalNewRoundPage()
        {
            await Navigation.PopModalAsync();
        }
    }
}