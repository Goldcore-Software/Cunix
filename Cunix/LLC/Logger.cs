using System;

namespace LLC
{
    public class Logger
    {
        public static void Log(string message,LogType type)
        {
            switch (type)
            {
                case LogType.info:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("INFO");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("] ");
                    Console.WriteLine(message);
                    break;
                case LogType.ok:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("OK");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("] ");
                    Console.WriteLine(message);
                    break;
                case LogType.fail:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("FAIL");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("] ");
                    Console.WriteLine(message);
                    break;
                case LogType.warn:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("WARN");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("] ");
                    Console.WriteLine(message);
                    break;
                default:
                    break;
            }
        }
    }
    public enum LogType
    {
        info,
        ok,
        fail,
        warn
    }
}
