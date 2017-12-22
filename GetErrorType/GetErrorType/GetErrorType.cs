using System.ComponentModel;

namespace GetErrorType
{
    public class GetErrorType
    {
        public static string WithIf(ErrorType _errorType)
        {
            //Get setting name by passing error type
            if (_errorType == ErrorType.Low)
                return Constants.LogErrorTypeLow;
            else if (_errorType == ErrorType.Medium)
                return Constants.LogErrorTypeMedium;
            else if (_errorType == ErrorType.Critical)
                return Constants.LogErrorTypeCritical;
            else
                return Constants.LogErrorTypeHigh;
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

        public static string WithArray(ErrorType _errorType)
        {
            return Constants.names[(int)_errorType];
        }

        public static string WithToString(ErrorType _errorType)
        {
            return "LogErrorType" + _errorType;
        }

        public static string WithDescription(ErrorType _errorType)
        {
            return GetEnumDescription(_errorType);
        }

        public static string GetEnumDescription(ErrorType value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }



    public enum ErrorType
    {
        [Description("LogErrorTypeHigh")]
        High = 0,

        [Description("LogErrorTypeCritical")]
        Critical = 1,

        [Description("LogErrorTypeMedium")]
        Medium = 2,

        [Description("LogErrorTypeLow")]
        Low = 3
    }

    public class Constants
    {
        public const string LogErrorTypeLow = "LogErrorTypeLow";
        public const string LogErrorTypeMedium = "LogErrorTypeMedium";
        public const string LogErrorTypeHigh = "LogErrorTypeHigh";
        public const string LogErrorTypeCritical = "LogErrorTypeCritical";
        public static readonly string[] names = new[] {
            "LogErrorTypeHigh",
            "LogErrorTypeCritical",
            "LogErrorTypeMedium",
            "LogErrorTypeLow" };

    }
}
