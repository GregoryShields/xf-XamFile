using Android.App;
using Debug = System.Diagnostics.Debug;

namespace XamFile.Droid.FileExperiments
{
	public static class OutputSystemPaths
	{
		public static void Output_ExternalFilesDir()
		{
			Debug.WriteLine(
				$"+++> Android.App.Application.Context.GetExternalFilesDir == {SystemPaths.ExternalFilesDirPath}");
		}

		/// <summary>
		/// This method writes...
		/// /data/user/0/com.bkep.droid.bluelink/files
		/// </summary>
		public static void Output_FilesDir()
		{
			Debug.WriteLine(
				$"+++> Android.App.Application.Context.FilesDir.AbsolutePath == {SystemPaths.FilesDirPath}");

			// This returns the same path as the above, but we don't have to worry about it possibly being null.
			Debug.WriteLine(
				$"+++> System.Environment.SpecialFolder.Personal == {SystemPaths.PersonalFolderPath}");
			Debug.WriteLine(
				$"+++> System.Environment.SpecialFolder.Personal == {System.Environment.SpecialFolder.Personal}");
		}
	}
}
