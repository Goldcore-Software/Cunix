using System;
using System.IO;

namespace Cunix.Programs
{
    public class csh : LLC.CSProgram.Base
    {
        private string cmd;
        private string[] cmdsplit;
        protected override void OnStart()
        {
            Name = "Cunix Shell";
        }
        public override void Loop()
        {
            Console.Write("csh$");
            cmd = Console.ReadLine();
            cmdsplit = cmd.Split(' ');
            switch (cmdsplit[0])
            {
                case "cls":
                    Console.Clear();
                    break;
                case "crash":
                    throw new Exception();
                case "exit":
                    State = LLC.CSProgram.ProcessState.Stop;
                    break;
                case "ls":
                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach (var item in Directory.GetDirectories(cmdsplit[1]))
                    {
                        Console.Write(item + " ");
                    }
                    foreach (var item in Directory.GetFiles(cmdsplit[1]))
                    {
                        Console.Write(item + " ");
                    }
                    break;
                case "ps":
                    
                    break;
                default:
                    break;
            }
        }
    }
}
