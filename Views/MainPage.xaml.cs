using Weather.ViewModels;

namespace Weather.Views;

public partial class MainPage : ContentPage
{
	public MainPage(WeatherViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}