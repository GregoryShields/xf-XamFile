using System;
using System.IO;
using XamFile.Droid.Logging;
using Environment = Android.OS.Environment;

namespace XamFile.Droid.FileExperiments
{
	public static class FileWritingTest
	{
		public static void DoFileStuff()
		{
			// External storage must be mounted in order to access it.
			if (Environment.ExternalStorageState != Environment.MediaMounted)
				throw new IOException("External storage not mounted");

			// TODO: Check into the FileStream class and get back to this.
			//CreateWriteRead();

			var originalFilePath = Path.Combine(SystemPaths.PersonalFolderPath, "original_file.txt");
			var newFilePath = Path.Combine(SystemPaths.PersonalFolderPath, "new_file.txt");

			FileStreamWriting.CreateFileStreamAndWriteToIt(originalFilePath);
			FileWriting.EffectivelyRenameFile(originalFilePath, newFilePath);

			FileWriting.OutputFileContents(newFilePath);

			var documentsFilePath = Path.Combine(SystemPaths.DocumentsDirectoryPath, "documents_file.txt");

			FileWriting.OutputFileContents(documentsFilePath);
			File.Delete(documentsFilePath);

			DebugFileWriter.CreateDebugFileWriter();
		}

		static void CreateWriteRead()
		{
			var filePath =
				Path.Combine(
					SystemPaths.PersonalFolderPath,
					"test_file.txt");

			if (!File.Exists(filePath))
			{
				var fileStream =
					FileStreamWriting.GetFileStream(
						filePath,
						true);

				byte[] bytes = {
					Convert.ToByte('H'),
					Convert.ToByte('e'),
					Convert.ToByte('l'),
					Convert.ToByte('l'),
					Convert.ToByte('o')
				};

				fileStream.Write(bytes);
			}

			var openAndReadFileStream =
				FileStreamWriting.GetFileStream(
					filePath,
					false);

			File.Delete(filePath);
		}
	}
}
