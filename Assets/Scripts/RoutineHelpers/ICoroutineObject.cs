using System;
using UnityEngine;
namespace RoutineHelpers
{
    public interface ICoroutineObject
    {
        void Run(MonoBehaviour caller, Action<IRoutineResult> callback);
        void Clear();
        void Pause();
        void Stop();
        void Continue();
        void Reset();

    }
}