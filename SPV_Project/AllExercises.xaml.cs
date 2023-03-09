using SPV_Project.ViewModel;

namespace SPV_Project;

public partial class AllExercises : ContentPage
{
	public AllExercises(AllExercieseViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}