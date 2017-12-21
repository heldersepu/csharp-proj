namespace CountingCars
{
    public class Test
    {
        private static string GetErrorType(ErrorType _errorType)
        {
            //Get setting name by passing error type
            string _eType = string.Empty;
            if (_errorType == ErrorType.Low)
            {
                _eType = Constants.LogErrorTypeLow;
            }
            else if (_errorType == ErrorType.Medium)
            {
                _eType = Constants.LogErrorTypeMedium;
            }
            else if (_errorType == ErrorType.Critical)
            {
                _eType = Constants.LogErrorTypeCritical;
            }
            else if (_errorType == ErrorType.High)
            {
                _eType = Constants.LogErrorTypeHigh;
            }

            return _eType;
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
