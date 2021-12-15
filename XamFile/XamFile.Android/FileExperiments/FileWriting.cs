using System.IO;
using Android.App;
using Android.Content;
using Debug = System.Diagnostics.Debug;
using Environment = Android.OS.Environment;

namespace XamFile.Droid.FileExperiments
{
	public static class FileWriting
	{
		public static void EffectivelyRenameFile(string originalFilePath, string newFilePath)
		{
			// Read a file on disk into a byte array.
			var bytes = File.ReadAllBytes(originalFilePath);

			// Write the byte array to a different file on disk.
			File.WriteAllBytes(newFilePath, bytes);

			// Delete the original file.
			File.Delete(originalFilePath);
		}

		public static void OutputFileContents(string filePath)
		{
			if (File.Exists(filePath))
			{
				// The ---> causes a colored output because of the VSColorOutput plugin.
				Debug.WriteLine("---> File Start");

				foreach (var line in File.ReadLines(filePath))
					Debug.WriteLine(line);

				Debug.WriteLine("---> File End");
			}
		}

		/// <summary>
		/// Returns a string which can be one of many values such as...
		/// #MEDIA_MOUNTED
		/// #MEDIA_SHARED
		/// Hover over ExternalStorageState below to see a popup containing the possible values.
		/// </summary>
		static void Write_ExternalStorageState()
		{
			Debug.WriteLine(
				$"+++> Android.OS.Environment.ExternalStorageState == {Environment.ExternalStorageState}");
		}

		/// <summary>
		/// This method writes...
		/// /storage/emulated/0
		/// Since access to external directories is prohibited in Android 11 forward, the members of Environment
		/// used to access them are deprecated.
		/// </summary>
		static void Write_ExternalStorageDirectory_AbsolutePath()
		{
			var path = Environment.ExternalStorageDirectory.AbsolutePath;
			Debug.WriteLine(
				$"+++> Android.OS.Environment.ExternalStorageDirectory.AbsolutePath == {path}");
		}

		/// <summary>
		/// This method writes...
		/// storage/emulated/0/Download
		/// ...which is the same as the above with /Download appended.
		/// </summary>
		static void Write_ExternalStoragePublicDirectory_Download()
		{
			var path = Environment.GetExternalStoragePublicDirectory(Environment.DirectoryDownloads).AbsolutePath;
			Debug.WriteLine(
				$"+++> 1) Android.OS.Environment.DirectoryDownloads == {path}");

			path = Path.Combine(Environment.ExternalStorageDirectory.AbsolutePath, Environment.DirectoryDownloads);
			Debug.WriteLine(
				$"+++> 2) Android.OS.Environment.DirectoryDownloads == {path}");
		}

		/// <summary>
		/// Create a file in the user's Personal directory.
		/// </summary>
		static void CreateAFile()
		{
			const string fileName = "test_file.txt";

			var stream =
				Application.Context.OpenFileOutput(
					fileName,
					FileCreationMode.WorldReadable);
		}
	}
}
