namespace GetErrorType
{
    public class GetErrorType
    {
        public static string WithIf(ErrorType _errorType)
        {
            //Get setting name by passing error type
            string _eType = string.Empty;
            if (_errorType == ErrorType.Low)
                _eType = Constants.LogErrorTypeLow;
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

        public static string WithSwitch(ErrorType _errorType)
        {
            switch (_errorType)
            {
                case ErrorType.High: return Constants.LogErrorTypeHigh;
                case ErrorType.Critical: return Constants.LogErrorTypeCritical;
                case ErrorType.Medium: return Constants.LogErrorTypeMedium;
                default: return Constants.LogErrorTypeLow;
            }
        }

        public static string WithToString(ErrorType _errorType)
        {
            return "LogErrorType" + _errorType;
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
