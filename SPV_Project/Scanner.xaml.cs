namespace SPV_Project;

public partial class Scanner : ContentPage
{
	public Scanner()
	{
		InitializeComponent();
	}

    async void TakePhoto_Clicked(object sender, EventArgs e)
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo != null)
            {
                // save the file into local storage
                string localFilePath = System.IO.Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                using Stream sourceStream = await photo.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(localFilePath);

                await sourceStream.CopyToAsync(localFileStream);

                var stream = await photo.OpenReadAsync();
                PhotoImage.Source = ImageSource.FromStream(() => stream);

            }
        }
    }
}