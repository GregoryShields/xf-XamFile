using System.Diagnostics;
using System.IO;

namespace XamFile.Droid.Logging
{
	public static class DebugFileWriter
	{
		public static void CreateDebugFileWriter()
		{
			var debugFilePath = DebugFilePath;

			if (File.Exists(debugFilePath))
			{
				OutputFileContents(debugFilePath);
				File.Delete(debugFilePath);
			}
			else
			{
				                                                          var debugFile = File.Create(debugFilePath);
				                var debugWriter = new TextWriterTraceListener(debugFile);
				Debug.Listeners.Add(debugWriter);
				//Trace.Listeners.Add(debugWriter);

				// Tell the listener to flush the buffer after every write operation.
				Debug.AutoFlush = true;

				Debug.WriteLine("+++> Testing 1, 2, 3");
			}
			//CreateWriteClose(debugFilePath);
		}

		static void OutputFileContents(string debugFilePath)
		{
			// The ---> causes a colored output because of the VSColorOutput plugin.
			Debug.WriteLine("---> File Start");

			//var text = File.ReadAllText(debugFilePath);
			foreach (var line in File.ReadLines(debugFilePath))
				Debug.WriteLine(line);

			Debug.WriteLine("---> File End");
		}

		static void CreateWriteClose(string debugFilePath)
		{
			// Some basic text file writing code as an alternative to the above.
			var writer = File.CreateText(debugFilePath);
			writer.Write("Whatever");
			writer.Close();
		}

		static string DebugFilePath => Path.Combine(SystemPaths.PersonalFolderPath, "debug_file.txt");
	}
}