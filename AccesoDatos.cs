using System;
using MySql.Data.MySqlClient;
public class Class1
{
	public AccesoDatos()
	{

        MySql.Data.MySqlClient.MySqlConnection conn;
        string myConnectionString;

        myConnectionString = "server=localhost;uid=consulta;" +
            "pwd=consulta;database=basicas";

        try
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();
        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            Console.Write(ex.Message);
        }

        DataTable dt = new DataTable("basicas.demandaenergiasinhistoria");
        MySqlDataAdapter da = new MySqlDataAdapter("basicas.demandaenergiasinhistoria", myConnectionString);
        MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
        da.Fill(dt);

    }
}
