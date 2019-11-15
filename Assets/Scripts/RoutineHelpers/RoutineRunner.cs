using System.Runtime.InteropServices.ComTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoutineHelpers
{
    public class RoutineRunner : IRoutineRunner
    {
        private MonoBehaviour caller;
        private IRoutineBuilder routine;
        private Action<IRoutineResult> callback;
        public RoutineRunner(MonoBehaviour caller)
        {
            this.caller = caller;
        }

        public bool Paused { get; private set; }

        public bool Stopped { get; private set; }

        public void Run(IRoutineBuilder routine, Action<IRoutineResult> callback)
        {
            this.routine = routine;
            this.callback = callback;
            try
            {
                caller.StartCoroutine(Run());
            }
            catch (Exception e)
            {
                Debug.LogError($"{e.Message} {e.InnerException?.Message}");
            }
        }

        private IEnumerator Run()
        {
            Reset();
            caller.StartCoroutine(routine.RunCoroutine(this));
            do
            {
                yield return null;
            } while (routine != null && routine.IsRunning);

            callback?.Invoke(routine.Result);
            this.routine = null;
            this.callback = null;
        }

        public void Pause()
        {
            Paused = true;
        }
        public void Stop()
        {
            Stopped = true;
        }
        public void Continue()
        {
            if (!Stopped)
            {
                Paused = false;
            }
        }

        public void Reset()
        {
            Paused = false;
            Stopped = false;
        }

    }
}

