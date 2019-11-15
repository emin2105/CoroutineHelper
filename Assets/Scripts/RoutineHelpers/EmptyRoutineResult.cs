namespace RoutineHelpers
{
    public class EmptyRoutineResult : IRoutineResult
    {
        public EmptyRoutineResult()
        {
            Success = true;
            Data = null;
        }

        public bool Success { get; set; }
        public object Data { get; set; }
    }
}