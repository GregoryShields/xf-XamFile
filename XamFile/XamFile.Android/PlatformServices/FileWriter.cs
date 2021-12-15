using XamFile.Droid.PlatformServices;
using XamFile.PlatformServices;

[assembly: Xamarin.Forms.Dependency(typeof(FileWriter))]
namespace XamFile.Droid.PlatformServices
{
	public class FileWriter : IFileWriter
	{
        public string GetPath()
        {
	        return
		        SystemPaths.ExternalFilesDirPath;
        }
	}
}
