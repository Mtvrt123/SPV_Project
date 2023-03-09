
namespace SPV_Project;

public partial class AppShell : Shell
{
	public static AppShell Instance { get; private set; }

	public AppShell()
	{
		InitializeComponent();

		Instance = this;
    }

    public void setTabs(bool OnlyLoginAndReg)
    {
        if (OnlyLoginAndReg != true)
        {
            //Profile.IsEnabled = false;
            Profile.IsVisible = false;

            //ExercisesHistory.IsEnabled = false;
            ExercisesHistory.IsVisible = false;

            //Scanner.IsEnabled = false;
            Scanner.IsVisible = false;

            //MyExercise.IsEnabled = false;
            MyExercise.IsVisible = false;

            //AllExercises.IsEnabled = false;
            AllExercises.IsVisible = false;

            //FoodInformation.IsEnabled = false;
            FoodInformation.IsVisible = false;

            //Login.IsEnabled = true;
            Login.IsVisible = true;

            //Registration.IsEnabled = true;
            Registration.IsVisible = true;

        }
        else
        {
            //Profile.IsEnabled = true;
            Profile.IsVisible = true;

            //ExercisesHistory.IsEnabled = true;
            ExercisesHistory.IsVisible = true;

            //Scanner.IsEnabled = true;
            Scanner.IsVisible = true;

            //MyExercise.IsEnabled = true;
            MyExercise.IsVisible = true;

            //AllExercises.IsEnabled = true;
            AllExercises.IsVisible = true;

            //FoodInformation.IsEnabled = true;
            FoodInformation.IsVisible = true;

            //Login.IsEnabled = false;
            Login.IsVisible = false;

            //Registration.IsEnabled = false;
            Registration.IsVisible = false;
        }

    }

}
