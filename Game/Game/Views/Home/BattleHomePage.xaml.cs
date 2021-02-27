using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BattleHomePage : ContentPage
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public BattleHomePage ()
		{
            InitializeComponent();
		}

		/// <summary>
		/// Jump to the Battle Page
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        public async void BattlePageButton_Clicked(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new BattlePage());
		}

		/// <summary>
		/// Jump to the New Round page
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void NewRoundButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewRoundPage());
		}

		/// <summary>
		/// Jump to the Pick Characters page
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void PickCharactersButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new PickCharactersPage());
		}

		/// <summary>
		/// Jump to the PickItems page
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void PickItemsButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new PickItemsPage());
		}

		/// <summary>
		/// Jump to the RoundOver page
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void RoundOverButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new RoundOverPage());
		}

		/// <summary>
		/// Jump to the Score page
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void ScorePageButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ScorePage());
		}

	}
}