

// https://stackoverflow.com/questions/41707205/xamarin-forms-image-to-stream#41728728

namespace XamFile.Droid.FileExperiments
{
	public class FileTestImage
	{
		/*
		public void DoImage()
		{
			string imagePath = "NameOfProject.Assets.applicationIcon.png";
			Assembly assembly = typeof(FileTestImage).GetTypeInfo().Assembly;

			using (Stream stream = assembly.GetManifestResourceStream(imagePath))
			{
				var buffer = new byte[stream.Length];
				stream.Read(buffer, 0, (int)stream.Length);

				var storeragePath = await iStorageService.SaveBinaryObjectToStorageAsync(string.Format(FileNames.ApplicationIcon, app.ApplicationId), buffer);

				app.IconURLLocal = storeragePath;
			}
		}

		/// <summary>
		/// Using the CrossMedia plugin works if you have a path.
		/// If you don't have a path, you can use the Assembly class like the above method above.
		/// </summary>
		public void OtherCodeSamePage()
		{
			if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
	        {
	            await App.CurrentApp.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
	            return;
	        }

	        _mediaFile = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
	        {
	            Directory = "Sample",
	            Name = "test.jpg"
	        });

	        if (_mediaFile == null)
	            return;

	        //ViewModel.StoreImageUrl(file.Path);

	        await App.CurrentApp.MainPage.DisplayAlert("Snap", "Your photo has been added to your collection.", "OK");

	        ImageSource = ImageSource.FromStream(() =>
	        {
	            var stream = _mediaFile.GetStream();
	            _mediaFile.Dispose();
	            return stream;
	        });
		}
		*/
	}
}


