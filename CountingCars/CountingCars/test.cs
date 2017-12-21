namespace CountingCars
{
    public class Test
    {
        private static string GetErrorType(ErrorType _errorType)
        {
            switch (_errorType)
            {
                case ErrorType.High: return Constants.LogErrorTypeHigh;
                case ErrorType.Critical: return Constants.LogErrorTypeCritical;
                case ErrorType.Medium: return Constants.LogErrorTypeMedium;
                default: return Constants.LogErrorTypeLow;
            }
        }
    }

    public enum ErrorType
    {
        High = 0,
        Critical = 1,
        Medium = 2,
        Low = 3
    }

    public class Constants
    {
        public const string LogErrorTypeLow = "LogErrorTypeLow";
        public const string LogErrorTypeMedium = "LogErrorTypeMedium";
        public const string LogErrorTypeHigh = "LogErrorTypeHigh";
        public const string LogErrorTypeCritical = "LogErrorTypeCritical";
    }
}
