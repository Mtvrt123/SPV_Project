namespace SPV_Project;

public partial class Forgot : ContentPage
{
	public Forgot()
	{
		InitializeComponent();
	}

    private void OnResetPasswordClicked(object sender, EventArgs e)
    {
        string enteredEmail = EmailEntry.Text;
        bool emailExists = App.Database.CheckIfEmailExists(enteredEmail); // replace this with your own logic to check if email exists in your database
        ErrorLabel.IsVisible = emailExists;
        
    }

}