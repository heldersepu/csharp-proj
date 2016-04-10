namespace EmployeesApp.Framework.Interfaces
{
    using DbSchema;
    public interface IBenefits
    {
        double Deduction(Employee employee);
        double Discount(string name);
    }
}
