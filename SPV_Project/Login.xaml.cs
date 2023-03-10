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

    private void Button_Clicked_2(object sender, EventArgs e)
    {
        Database a = new Database();
        if (a.Login1(User.Text.ToString(),Pass.Text.ToString()) == true)
        {

            
            

            this.Navigation.PushAsync(new Profile());
            

        }
    }
}