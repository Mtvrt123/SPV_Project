using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace SPV_Project;

public partial class MyExercise : ContentPage
{

    public MyExercise()
	{
        
        InitializeComponent();
        Database db = new Database();
        var sportnaOpremaUnikatneVrednostiList = db.GetVseSportneOpreme();
        var tipVadbeUnikatneVrednostiList = db.GetVseTipeVadbe();
        var obremenjeneMisiceUnikatneVrednostiList = db.GetVseObremenjeneDeleTelesa();
        var tezavnostVadbeUnikatneVrednostiList = db.GetVseTezavnostiVaje();
        var poskodbeUnikatneVrednostiList = db.GetVsePoskodbe();


        SportnaOprema.ItemsSource = sportnaOpremaUnikatneVrednostiList;
        TipVadbe.ItemsSource = tipVadbeUnikatneVrednostiList;
        ObremenjeneMisice.ItemsSource = obremenjeneMisiceUnikatneVrednostiList;
        TezavnostVadbe.ItemsSource = tezavnostVadbeUnikatneVrednostiList;
        Poskodbe.ItemsSource = poskodbeUnikatneVrednostiList;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

       
        this.Navigation.PushAsync(new MyExerciseInfo(SportnaOprema.SelectedItem.ToString(), TipVadbe.SelectedItem.ToString(), ObremenjeneMisice.SelectedItem.ToString(), TezavnostVadbe.SelectedItem.ToString(), int.Parse(st_ponovitev.Text), Poskodbe.SelectedItem.ToString()));

    }
}