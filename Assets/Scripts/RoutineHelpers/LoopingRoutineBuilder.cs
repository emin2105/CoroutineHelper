using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RoutineHelpers
{
    public class LoopingRoutineObject : IRoutineBuilder
    {
        private Action action;
        private int performTimes;
        private YieldInstruction yieldInstruction;
        public bool IsRunning { get; private set; }
        Func<IRoutineResult> resultFunction;
        public IRoutineResult Result { get; private set; }


        public LoopingRoutineObject(Action action, YieldInstruction yieldInstruction = null, int performTimes = 1)
        {
            this.action = action;
            this.performTimes = performTimes;
            this.yieldInstruction = yieldInstruction;
        }
        public LoopingRoutineObject(Action action, Func<IRoutineResult> resultFunction, YieldInstruction yieldInstruction = null, int performTimes = 1)
        {
            this.action = action;
            this.performTimes = performTimes;
            this.yieldInstruction = yieldInstruction;
            this.resultFunction = resultFunction;
        }

        public IEnumerator RunCoroutine(IRoutineRunner runner)
        {
            IsRunning = true;
            for (int i = 0; i < performTimes; i++)
            {
                if (runner.Stopped) break;
                if (runner.Paused)
                {
                    while (runner.Paused)
                    { yield return null; }
                }
                action.Invoke();
                yield return yieldInstruction;
            }
            if (resultFunction != null)
            {
                Result = resultFunction.Invoke();
            }
            else
            {
                Result = new EmptyRoutineResult();
            }
            IsRunning = false;
        }

    }
}
