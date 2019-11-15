using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RoutineHelpers
{
    public class ConditionalRoutineObject : IRoutineBuilder
    {
        private Action action;
        private Func<bool> loopCondition;
        Func<IRoutineResult> resultFunction;
        private YieldInstruction yieldInstruction;
        public bool IsRunning { get; private set; }
        private IRoutineRunner Runner { get; set; }
        public IRoutineResult Result { get; private set; }
        public ConditionalRoutineObject(Action action, Func<bool> loopCondition, YieldInstruction yieldInstruction = null)
        {
            this.action = action;
            this.loopCondition = loopCondition;
            this.yieldInstruction = yieldInstruction;
        }
        public ConditionalRoutineObject(Action action, Func<IRoutineResult> resultFunction, Func<bool> loopCondition, YieldInstruction yieldInstruction = null)
        {
            this.action = action;
            this.loopCondition = loopCondition;
            this.yieldInstruction = yieldInstruction;
            this.resultFunction = resultFunction;
        }

        public IEnumerator RunCoroutine(IRoutineRunner runner)
        {
            Result = new ObjectRoutineResult();
            IsRunning = true;

            do
            {
                if (runner.Stopped) break;
                if (runner.Paused)
                {
                    while (runner.Paused)
                    { yield return null; }

                }
                else
                {
                    action.Invoke();
                    yield return yieldInstruction;
                }
            } while (loopCondition.Invoke());
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