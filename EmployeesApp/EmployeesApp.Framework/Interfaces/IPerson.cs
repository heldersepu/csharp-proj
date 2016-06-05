namespace EmployeesApp.Framework.DbSchema
{
    public interface IPerson
    {
        string Name { get; set; }
        string Email { get; set; }
        int? Age { get; set; }
    }
}
