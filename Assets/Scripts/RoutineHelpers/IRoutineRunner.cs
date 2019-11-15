using System;
using System.Collections;
using UnityEngine;

namespace RoutineHelpers
{
    public interface IRoutineRunner
    {
        bool Paused { get; }
        bool Stopped { get; }
        void Run(IRoutineBuilder routine, Action<IRoutineResult> callback);
        void Pause();
        void Stop();
        void Continue();
        void Reset();
    }
}
