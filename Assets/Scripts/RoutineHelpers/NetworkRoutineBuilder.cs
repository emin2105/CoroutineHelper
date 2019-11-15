using System.Net;
using System.Collections;
using UnityEngine.Networking;

namespace RoutineHelpers
{
    public class NetworkRoutineObject : IRoutineBuilder
    {
        public bool IsRunning { get; private set; }

        public IRoutineResult Result { get; private set; } = new EmptyRoutineResult();

        UnityWebRequest request;


        public NetworkRoutineObject(UnityWebRequest request)
        {
            this.request = request;
        }

        public IEnumerator RunCoroutine(IRoutineRunner runner)
        {
            IsRunning = true;

            for (int i = 0; i < 1; i++)
            {
                if (runner.Stopped) break;
                if (runner.Paused)
                {
                    while (runner.Paused)
                    {
                        yield return null;
                    }
                }
                yield return request.SendWebRequest();
            }
            Result.Success = true;
            IsRunning = false;
        }
    }
}