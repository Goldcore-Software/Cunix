using System.Collections.Generic;

namespace LLC.CSProgram
{
    public class ProcessManager
    {
        private static Dictionary<uint, Base> processes = new Dictionary<uint, Base>();
        public static uint ProcessesRunning { get; private set; } = 0;

        public static void Run()
        {
            foreach (var item in processes)
            {
                var proc = item.Value;
                proc.State = ProcessState.Running;
                if (!proc.Started)
                {
                    proc.Start();
                }
                else
                {
                    proc.Loop();
                }
                if (proc.State == ProcessState.Stop)
                {
                    processes.Remove(item.Key);
                    ProcessesRunning -= 1;
                }
                proc.State = ProcessState.Standby;
            }
        }

        public static void AddProcess(Base proc)
        {
            uint nid = ProcessesRunning + 1;
            processes[nid] = proc;
        }
    }
    public enum ProcessState
    {
        Running,
        Standby,
        Stop,
        Suspended,
    }
}
