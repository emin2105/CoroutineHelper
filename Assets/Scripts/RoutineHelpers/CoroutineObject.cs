using System;
using UnityEngine;

namespace RoutineHelpers
{
    public class CoroutineObject : ICoroutineObject
    {
        private IRoutineBuilder routine { get; set; }
        private IRoutineRunner runner { get; set; }
        private MonoBehaviour caller { get; set; }

        public CoroutineObject(IRoutineBuilder routine)
        {
            this.routine = routine;
        }


        public void Run(MonoBehaviour caller, Action<IRoutineResult> callback)
        {

            if (runner == null || this.caller != caller)
            {
                this.caller = caller;
                this.runner = new RoutineRunner(this.caller);
            }
            runner.Run(routine, callback);
        }


        public void Clear()
        {
            runner = null;
            caller = null;
        }

        public void Pause()
        {
            runner.Pause();
        }

        public void Stop()
        {
            runner.Stop();
        }

        public void Continue()
        {
            runner.Continue();
        }

        public void Reset()
        {
            runner.Reset();
        }
    }
}