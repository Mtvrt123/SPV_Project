using SPV_Project.Models;

namespace SPV_Project;

public partial class App : Application
{
	public static Uporabnik Uporabnik { get; private set; }

	public App()
	{
		InitializeComponent();

        MainPage = new AppShell();

		// db call za uporabnika
		Uporabnik = new Uporabnik(1,"ImeTest", "PriimekTest", "USERNAME", "EMAIL", "GESLO");
    }
}
