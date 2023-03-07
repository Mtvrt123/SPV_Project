using SPV_Project.Models;

namespace SPV_Project;

public partial class App : Application
{
	public static Database Database{ get; private set; }

	public App()
	{
		InitializeComponent();

        MainPage = new AppShell();	
		Database = new Database();
    }
}
