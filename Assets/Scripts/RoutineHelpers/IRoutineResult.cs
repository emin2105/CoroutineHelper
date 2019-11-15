namespace RoutineHelpers
{
    public interface IRoutineResult
    {
        bool Success { get; set; }
        object Data { get; set; }
    }
}

