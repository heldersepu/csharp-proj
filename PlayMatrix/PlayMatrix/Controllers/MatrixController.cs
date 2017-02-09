using System.Web.Http;

namespace PlayMatrix.Controllers
{
    public class MatrixController : ApiController
    {
        static private Matrix matrix = new Matrix();

        // GET: api/Matrix/Create
        [HttpGet]
        public Matrix Create(int max)
        {
            if (max > matrix.Count)
                for (int i = matrix.Count; i < max; i++)
                    matrix.Add();
            return matrix;
        }

        // GET: api/Matrix/Get
        [HttpGet]
        public Matrix Get()
        {
            return matrix;
        }
    }
}
