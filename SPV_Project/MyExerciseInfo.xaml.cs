namespace SPV_Project;

public partial class MyExerciseInfo : ContentPage
{
	public MyExerciseInfo(string sportnaOprema,string TipVadbe,string ObremenjeneMisice,string TezavnostVadbe,int st_ponovitev, string poskodbe)
	{
		InitializeComponent();

        List<string> vaje = new List<string>();
        vaje = App.Database.PolniVaje(sportnaOprema, ObremenjeneMisice, TezavnostVadbe, poskodbe);





        for (int i = 0; i < vaje.Count; i++)
        {
            // Create a new instance of the Frame control
            Frame newFrame = new Frame();
            newFrame.Background = new SolidColorBrush(Colors.Gray);

            // Create a new Label control
            Label label = new Label();
            label.Text = vaje[i];

            // Add the Label control to the Content property of the Frame
            newFrame.Content = label;

            // Add the new frame to your layout
            Vajnik.Children.Add(newFrame);
        }






    }
    public MyExerciseInfo()
    {
        InitializeComponent();




    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        this.Navigation.PushAsync(new MyExercise());
    }
}