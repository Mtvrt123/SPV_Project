namespace SPV_Project;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        this.Navigation.PushAsync(new Registration());
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        this.Navigation.PushAsync(new Forgot());
    }

    private void Button_Login(object sender, EventArgs e)
    {
        AppShell.Instance.setTabs(App.Database.Login(Username.Text, Password.Text));

    }
}