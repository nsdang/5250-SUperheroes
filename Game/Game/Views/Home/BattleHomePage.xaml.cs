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
		/// Jump to the Dungeon
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void AutobattleButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AutoBattlePage());
		}

		/// <summary>
		/// Jump to the about us page
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void AboutUsButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AboutPage());
		}

	}
}