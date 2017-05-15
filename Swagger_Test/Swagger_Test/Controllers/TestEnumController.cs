using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class TestEnumController : ApiController
    {
        public enum CustomEnum
        {
            Text = 1,
            Numeric = 2,
            Date = 4,
            Numeric_Function = 8,
            Dropdown_List = 16,
            Checkbox = 32
        }

        public CustomEnum Get(CustomEnum value)
        {
            return value;
        }

        public CustomEnum Post(CustomEnum value)
        {
            return value;
        }
    }
}
