using CommunityToolkit.Mvvm.Input;
using SPV_Project.Models;
using SPV_Project.ViewModel;

namespace SPV_Project;

public partial class Profile : ContentPage
{

	private ProfileViewModel profileViewModel;

    public Profile(ProfileViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		profileViewModel = vm;
    }

    private void Edit_Clicked(object sender, EventArgs e)
    {
        profileViewModel.UpdateData(Ime.Text, Priimek.Text, UporabniskoIme.Text, Email.Text);
    }
}