using System;

namespace LLC.CSProgram
{
    abstract public class Base
    {
        public string Name = "Placeholder";
        public ProcessState State = ProcessState.Standby;
        public bool Started { get; private set; } = false;

        public void Start()
        {
            Started = true;
            OnStart();
            if (State == ProcessState.Running)
            {
                Loop();
            }
        }

        protected virtual void OnStart()
        {
            Console.WriteLine("This program has no code!");
        }

        public virtual void Loop()
        {

        }

        public Base()
        {

        }
    }
}
