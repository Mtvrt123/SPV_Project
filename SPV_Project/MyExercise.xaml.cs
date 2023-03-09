namespace SPV_Project;

public partial class MyExercise : ContentPage
{
	public MyExercise()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        this.Navigation.PushAsync(new MyExerciseInfo());

    }
}