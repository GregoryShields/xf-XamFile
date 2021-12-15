using System.IO;

namespace XamFile.Droid.FileExperiments
{
	public static class FileStreamWriting
	{
		public static Stream GetFileStream(string filePath, bool write)
		{
			FileMode mode;
			FileAccess access;
			if (write)
			{
				// Create and write.
				mode = FileMode.Create;
				access = FileAccess.Write;
			}
			else
			{
				// Open and read.
				mode = FileMode.Open;
				access = FileAccess.Read;
			}

			return
				new FileStream(
					filePath,
					mode,
					access,
					FileShare.None);
		}

		public static void CreateFileStreamAndWriteToIt(string filePath)
		{
			// Create a file stream.
			using (
				// This method creates a file on disk and returns a StreamWriter.
				var streamWriter = File.CreateText(filePath)
			)
			{
				// Write to the stream and then close the writer.
				streamWriter.Write("Whatever");
				streamWriter.Close();
			}
		}
	}
}
