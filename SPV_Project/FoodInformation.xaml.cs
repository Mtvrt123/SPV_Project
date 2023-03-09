using CommunityToolkit.Mvvm.Input;
using SPV_Project.Models;
using SPV_Project.ViewModel;

namespace SPV_Project;

public partial class FoodInformation : ContentPage
{
    private IzdelekViewModel izdelekViewModel;

    public FoodInformation(IzdelekViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
        izdelekViewModel = vm;
	}
}