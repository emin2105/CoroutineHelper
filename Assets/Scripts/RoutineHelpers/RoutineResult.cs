namespace RoutineHelpers
{
    public class ObjectRoutineResult : IRoutineResult
    {
        public bool Success { get; set; }
        public object Data { get; set; }
    }
}