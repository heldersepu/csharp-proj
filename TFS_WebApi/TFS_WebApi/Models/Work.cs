namespace TFS_WebApi.Models
{
    public class Work
    {
        public double Original = 0;
        public double Remaining = 0;
        public double Completed = 0;

        public Work(double o, double r, double c)
        {
            Original = o;
            Remaining = r;
            Completed = c;
        }

        public void Inc(double o, double r, double c)
        {
            Original += o;
            Remaining += r;
            Completed += c;
        }
    }
}