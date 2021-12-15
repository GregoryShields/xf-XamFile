using System;
using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Google.Android.Material.Snackbar;

namespace XamFile.Droid
{
	[Activity(
		Label = "XamFile",
		Icon = "@mipmap/icon",
		Theme = "@style/MainTheme",
		MainLauncher = true,
		ConfigurationChanges =
			ConfigChanges.ScreenSize |
			ConfigChanges.Orientation |
			ConfigChanges.UiMode |
			ConfigChanges.ScreenLayout |
			ConfigChanges.SmallestScreenSize)
	]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		const int RequestId = 0;

		readonly string[] _locationPermissions =
		{
			Manifest.Permission.ReadExternalStorage,
			Manifest.Permission.WriteExternalStorage
		};

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// This should be commented out when not experimenting.
			FileExperiments.FileWritingTest.DoFileStuff();
			FileExperiments.OutputSystemPaths.Output_ExternalFilesDir();

			Xamarin.Essentials.Platform.Init(this, savedInstanceState);
			global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

			// https://docs.microsoft.com/en-us/answers/questions/454560/access-to-the-path-is-denied-xamarin-forms.html
			// https://docs.microsoft.com/en-us/answers/questions/622020/how-to-request-manage-external-storage-permission.html
			// Set our view from the "main" layout resource.
			//SetContentView(Resource.Layout.activity_main);

			// Need a new phone to test this.
			if (Build.VERSION.SdkInt >= BuildVersionCodes.R) // API level 30 (R), is Android version 11. My S8 is stuck on Android version 9.
			{
				// If your app doesn't have access to external storage, then you can take the user to a page where they can allow it.
				if (!Android.OS.Environment.IsExternalStorageManager)
				{
					Snackbar.Make(
						FindViewById(Android.Resource.Id.Content),
						"Permission needed!",
						Snackbar.LengthIndefinite)
							.SetAction(
								"Settings",
								new MyClickHandler(this)
							)
							.Show();
				}
			}
			LoadApplication(new App());
		}

		protected override void OnStart()
		{
			base.OnStart();

			if (Build.VERSION.SdkInt >= BuildVersionCodes.M) // API Level 23, Version 6.0, Marshmallow
			{
				if (
					CheckSelfPermission(Manifest.Permission.AccessFineLocation) != Permission.Granted
				)
					RequestPermissions(_locationPermissions, RequestId);
			}
		}

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
		{
			Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

			if (requestCode == RequestId)
			{
				if (
					grantResults.Length == 1 &&
					grantResults[0] == Permission.Granted
				)
				{
					// Premission granted by user
				}
				else
				{
					// Permission denied by user
				}
			}
			else
			{
				base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
			}
		}
	}

	class MyClickHandler : Java.Lang.Object, Android.Views.View.IOnClickListener
	{
		readonly MainActivity _mainActivity;

		public MyClickHandler()
		{
		}

		public MyClickHandler(MainActivity mainActivity)
		{
			_mainActivity = mainActivity;
		}

		public void OnClick(Android.Views.View v)
		{
			try
			{
				Android.Net.Uri uri =
					Android.Net.Uri.Parse(
						"package:" + Application.Context.ApplicationInfo.PackageName
					);

				Android.Content.Intent intent =
					new Android.Content.Intent(
						Android.Provider.Settings.ActionManageAppAllFilesAccessPermission,
						uri
					);

				_mainActivity.StartActivity(intent);
			}
			catch (Exception)
			{
				Android.Content.Intent intent = new Android.Content.Intent();

				intent.SetAction(
					Android.Provider.Settings.ActionManageAppAllFilesAccessPermission
				);

				_mainActivity.StartActivity(intent);
			}
		}
	}
}
