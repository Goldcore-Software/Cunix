using System.IO;

namespace LLC
{
    public class FsMananger
    {
        public static string RootDevice = @"0:\";
        public static void FSInit()
        {
            if (!File.Exists(RootDevice + "boot"))
            {
                Logger.Log("Folder structure does not exist, creating folder structure",LogType.warn);
                Directory.CreateDirectory(@"0:\boot");
                Directory.CreateDirectory(@"0:\home");
                Directory.CreateDirectory(@"0:\sbin");
                Directory.CreateDirectory(@"0:\bin");
                Directory.CreateDirectory(@"0:\etc");
                Directory.CreateDirectory(@"0:\home");
                Directory.CreateDirectory(@"0:\usr");
                Directory.CreateDirectory(@"0:\lib");
                Directory.CreateDirectory(@"0:\srv");
            }
            Logger.Log("Filesystem initialized",LogType.ok);
            
        }
    }
}
