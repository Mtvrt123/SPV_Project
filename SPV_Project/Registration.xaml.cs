namespace SPV_Project;

public partial class Registration : ContentPage
{
	public Registration()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        this.Navigation.PushAsync(new Login());
    }
}