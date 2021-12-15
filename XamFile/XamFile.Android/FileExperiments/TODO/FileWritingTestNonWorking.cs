namespace XamFile.Droid.FileExperiments
{
	public class FileWritingTestNonWorking
	{
		// This looks promising...
		/*public void InsertIntoMediaStore(string filePath, string fileName)
		{
			string fileNameWithoutExt = Path.ChangeExtension(fileName, null);

			int fileSize = (int)new FileInfo(filePath).Length;
			byte[] buffer = null;

			var values = new ContentValues();

			values.Put(Android.Provider.MediaStore.IMediaColumns.Title, fileNameWithoutExt);
			values.Put(Android.Provider.MediaStore.IMediaColumns.MimeType, "image/jpg");
			values.Put(Android.Provider.MediaStore.IMediaColumns.Size, fileSize);
			values.Put(Android.Provider.MediaStore.Downloads.InterfaceConsts.DisplayName, fileNameWithoutExt);

			var contentResolver = Application.Context.ContentResolver;
			Android.Net.Uri newUri =
				contentResolver.Insert(Android.Provider.MediaStore.Downloads.ExternalContentUri, values);

			try
			{
				buffer = new byte[1024];
				var save = contentResolver.OpenOutputStream(newUri);

				Android.Content.Res.AssetManager assets = Platform.CurrentActivity.Assets;
				Android.Content.Res.AssetFileDescriptor descriptor = Application.Context.Assets.OpenFd(fileName);
				Stream inputstream = descriptor.CreateInputStream();

				CopyFile //inputstream, save);
				//File.Copy(inputstream, save);
			}

			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}*/

		// https://stackoverflow.com/questions/51393561/xamarin-essentials-filesystem-can-you-save-async
		/*
		void CopyFile()
		{
			IFile file = FileSystem.Current.GetFileFromPathAsync(src).Result;
			IFolder rootFolder = FileSystem.Current.GetFolderFromPathAsync(dest).Result;
			IFolder folder = rootFolder.CreateFolderAsync("MySubFolder", CreationCollisionOption.OpenIfExists).Result;
			IFile newFile = folder.CreateFileAsync("TodoItem.db3", CreationCollisionOption.GenerateUniqueName).Result;

			Stream str = file.OpenAsync(FileAccess.ReadAndWrite).Result;
			Stream newStr = newFile.OpenAsync(FileAccess.ReadAndWrite).Result;

			byte[] buffer = new byte[str.Length];
			int n;
			while ((n = str.Read(buffer, 0, buffer.Length)) != 0)
				newStr.Write(buffer, 0, n);
			str.Dispose();
			newStr.Dispose();
		}
		*/

		// Java
		/*SaveFileUsingMediaStore(Context context, string url, string fileName)
		{
		    val contentValues = ContentValues().apply {
		        put(MediaStore.MediaColumns.DISPLAY_NAME, fileName)
		        put(MediaStore.MediaColumns.MIME_TYPE, your_mime_type)
		        put(MediaStore.MediaColumns.RELATIVE_PATH, Environment.DIRECTORY_DOWNLOADS)
		    }
		    val resolver = context.contentResolver
		    val uri = resolver.insert(MediaStore.Downloads.EXTERNAL_CONTENT_URI, contentValues)
		    if (uri != null) {
		        URL(url).openStream().use { input ->
		            resolver.openOutputStream(uri).use { output ->
		                input.copyTo(output!!, DEFAULT_BUFFER_SIZE)
		            }
		        }
		    }
		}*/
		
	}
}