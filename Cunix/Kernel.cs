using System;
using Sys = Cosmos.System;
using LLC;
using LLC.CSProgram;
using Cosmos.System.FileSystem;

namespace Cunix
{
    public class Kernel : Sys.Kernel
    {
        public const string _LLC_VERSION = "202308A.1";
        public const string _COSMOS_VERSION = "9d59ffa";
        public static bool exitdebug = true;
        private static Programs.csh pcsh = new Programs.csh();
        protected override void BeforeRun()
        {
            Console.WriteLine("Starting Cunix with LLC");
            try
            {
                CosmosVFS fs = new CosmosVFS();
                Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
                FsMananger.FSInit();
                
                ProcessManager.AddProcess(pcsh);
                Logger.Log("System started",LogType.ok);
            }
            catch (Exception e)
            {
                Panic(e);
            }
            
        }

        protected override void Run()
        {
            try
            {
                ProcessManager.Run();
                if (exitdebug)
                {
                    if (ProcessManager.ProcessesRunning == 0)
                    {
                        pcsh.Loop();
                    }
                }
            }
            catch (Exception e)
            {
                Panic(e);
            }
            
        }

        private static void Panic(Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("Kernel Panic - LLC Cunix");
            Console.WriteLine(e.ToString());
            Console.WriteLine("Cosmos Version: " + _COSMOS_VERSION);
            Console.WriteLine("Please contact eli310#9755 on Discord if you do not know what caused this error.");
            Console.WriteLine("Press CTRL to reboot.");
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);

                if (((int)cki.Modifiers) == 4)
                {
                    Sys.Power.Reboot();
                }
            }
        }
    }
}
