namespace XamFile.Droid
{
	public static class SystemPaths
	{
		public static string PersonalFolderPath =>
			System.Environment.GetFolderPath(
				System.Environment.SpecialFolder.Personal);

		/// <summary>
		/// This property gets...
		/// /storage/emulated/0/Android/data/com.gmsenterprises.xamfile/files
		/// 
		/// Android.App.Application
		/// ...is a class which contains a public static read-only property...
		/// Context
		/// ...which is an instance of the public abstract class...
		/// Android.Content.Context
		/// GetExternalFilesDir() is a method that references the public directory that is automatically created for every app.
		/// Passing null returns the root "files" directory.
		/// </summary>
		public static string ExternalFilesDirPath =>
			Android.App.Application
				.Context.GetExternalFilesDir(null).AbsolutePath; // Pass an argument of null to get the root directory.

		public static string MyDocumentsFolderPath =>
			System.Environment.GetFolderPath(
				System.Environment.SpecialFolder.MyDocuments);

		public static string ExternalStoragePublicDirectoryPath =>
			Android.OS.Environment.
				GetExternalStoragePublicDirectory(null).AbsolutePath;

		public static string DocumentsDirectoryPath =>
			Android.OS.Environment.
				GetExternalStoragePublicDirectory(
					Android.OS.Environment.DirectoryDocuments
				).AbsolutePath;

		public static string FilesDirPath =>
			Android.App.
				Application.Context.FilesDir.AbsolutePath;

		//if (!Directory.Exists(folderPath))
			//	Directory.CreateDirectory(folderPath);
	}
}
