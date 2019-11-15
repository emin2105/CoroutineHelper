using System.Collections;

namespace RoutineHelpers
{
    public interface IRoutineBuilder
    {
        bool IsRunning { get; }
        IEnumerator RunCoroutine(IRoutineRunner runner);
        IRoutineResult Result { get; }
    }
}