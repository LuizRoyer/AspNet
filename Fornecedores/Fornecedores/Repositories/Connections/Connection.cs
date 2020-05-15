using System.Data.SqlClient;

namespace Fornecedores.Repositories.Connections
{
    public class Connection
    {
        const string connSQL = "Data Source=HP\\SQLEXPRESS;Initial Catalog=bd;Integrated Security=True;";

        public static SqlConnection ConnectionSQL()
        {
            return new SqlConnection(connSQL);
        }
    }
}
