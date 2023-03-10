using Microsoft.Maui.ApplicationModel.Communication;

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

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        if (Pass1.Text == Pass2.Text)
        {
            AppShell.Instance.setTabs(App.Database.Registracija(Mail.Text, Pass1.Text));
        }
        
    }
}