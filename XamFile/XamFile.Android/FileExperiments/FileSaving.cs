using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Environment = Android.OS.Environment;

/*
 Lookie here!
 https://stackoverflow.com/questions/66469608/xamarin-forms-how-to-create-folder-and-a-file-in-device-external-storage
*/

namespace XamFile.Droid.FileExperiments
{
	public static class FileSaving
	{
		public static async Task SaveAndView(string fileName, string contentType, MemoryStream memStream)
		{
			try
			{
				// Get the root path of the Android device.
				string root;
				if (Environment.IsExternalStorageEmulated)
					root = Environment.ExternalStorageDirectory.ToString();
				else
					root = 
						System.Environment.GetFolderPath(
							System.Environment.SpecialFolder.MyDocuments);

				// Create the directory and the file.
				var myDir = new Java.IO.File(root + "/penisenvy");
				myDir.Mkdir();

				var file = new Java.IO.File(myDir, fileName);

				// Remove the file if it exists.
				if (file.Exists()) file.Delete();

				// Write the stream into the file.
				var outStream = new Java.IO.FileOutputStream(file);
				await outStream.WriteAsync(memStream.ToArray());

				outStream.Flush();
				outStream.Close();
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"---> {ex.Message}");
			}
		}

		static void SaveFileToExternalStorage(string url, string text)
		{
			var path = Environment.GetExternalStoragePublicDirectory(Environment.DirectoryDownloads).AbsolutePath;
			File.WriteAllText(path, text);

			// Java...
			//Url(url).OpenStream().Use { input ->
			//    FileOutputStream(target).use { output ->
			//        input.copyTo(output)
			//    }
			//}
		}
	}
}
