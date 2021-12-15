using System;
using System.IO;
using Xamarin.Forms;
using XamFile.PlatformServices;

// https://www.xamarinhelp.com/dot-net-standard-pcl-xamarin-forms/
//? Since our *shared* XamFile project is a .NET Standard library, not a PCL, we can use File.Copy right inside it!
//! That way we don't have to worry about platform-specific implementations!!!!!!!!
//? System.IO.File class documentation...
// https://docs.microsoft.com/en-us/dotnet/api/system.io.file?view=net-5.0

namespace XamFile
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			NavigationPage.SetHasNavigationBar(
				this,
				true);

			Title = "XamFile";
		}

		async void BtnSave_Clicked(object sender, EventArgs e)
		{
			// I moved this block of code outside the try/catch block.
			if (string.IsNullOrWhiteSpace(TxtFileName.Text))
			{
				await DisplayAlert(
					"Error",
					"Please enter file name",
					"Ok");

				return;
			}

			try
			{
				string path;

				// We could use the Personal folder in Android too, but we're choosing not to.
				if (Device.RuntimePlatform == Device.Android)
					path =
						DependencyService
							.Get<IFileWriter>()
							.GetPath() + "/CustomDirectory";
				else // iOS
					path =
						Environment.GetFolderPath(
							Environment.SpecialFolder.Personal);

				var pathAndFileName =
					Path.Combine(
						path,
						TxtFileName.Text);

				File.WriteAllText(
					pathAndFileName,
					TxtFileText.Text);

				await DisplayAlert(
					"File saved to:",
					Path.Combine(path, TxtFileName.Text),
					"Ok");
			}
			catch (Exception ex)
			{
				await DisplayAlert(
					"Error:",
					ex.Message,
					"Ok");
			}
		}
	}
}

// Kind of a shitty article, but it's the source for this app.
// https://parallelcodes.com/xamarin-forms-create-and-write-text-file/

// External Storage documentation
// https://docs.microsoft.com/en-us/xamarin/android/platform/files/external-storage?tabs=windows

// Good info here.
// https://stackoverflow.com/questions/28427267/how-do-i-get-the-external-storages-path#28427506

// MediaStore work-around.
// https://medium.com/@thuat26/how-to-save-file-to-external-storage-in-android-10-and-above-a644f9293df2

// Cray-cray!
// https://csharp.hotexamples.com/examples/Xamarin.Forms/StreamImageSource/-/php-streamimagesource-class-examples.html


