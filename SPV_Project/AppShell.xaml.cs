
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
        if (OnlyLoginAndReg == true)
        {
        
            Profile.IsVisible = false;

            ExercisesHistory.IsVisible = false;

            Scanner.IsVisible = false;

            MyExercise.IsVisible = false;

           
            AllExercises.IsVisible = false;

            FoodInformation.IsVisible = false;

            Login.IsVisible = true;

           
            Registration.IsVisible = true;
            
        }
        else
        {
            
            Profile.IsVisible = true;

            
            ExercisesHistory.IsVisible = true;

            
            Scanner.IsVisible = true;

            
            MyExercise.IsVisible = true;

            
            AllExercises.IsVisible = true;

            
            FoodInformation.IsVisible = true;

            
            Login.IsVisible = false;

            
            Registration.IsVisible = false;

            
        }

    }

}
