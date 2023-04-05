namespace MaterialsManagement.DAL.DbContext
{
    public class ConnectionStringOptions
    {
        public const string Section = "ConnectionStrings";
        public string SqlConnection { get; set; }
        public string PostgreSqlConnection { get; set; }
    }
}
