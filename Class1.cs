using System;

public class Class1
{
    public Class1()
    {

        string path;
        SLDocument sl;
        MySql.Data.MySqlClient.MySqlConnection conn;
        string myConnectionString;

        myConnectionString = "server=localhost;uid=consulta;" + "pwd=consulta;database=basicas";

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


        path = @"D:\Demanda_Energia_SIN_2000.xlsx";
        SLDocument sl = new SLDocument(path);

        int iRow = 5;

        while (!string.IsNullOrEmpty(sl.GetCellValueAsDateTime(iRow, 1).ToString("yyyy/mm/dd")))
        {
            DateTime Fecha = sl.GetCellValueAsDateTime(iRow, 1);
            double Demanda = sl.GetCellValueAsDouble(iRow, 2);
            double Generacion = sl.GetCellValueAsDouble(iRow, 3);
            double DemandaNA = sl.GetCellValueAsDouble(iRow, 4);
            double Expotaciones = sl.GetCellValueAsDouble(iRow, 5);
            double Importaciones = sl.GetCellValueAsDouble(iRow, 6);


            //var oMiExcel = new miexcel();
            //oMiExcel.codigo = codigo;
            //    oMiExcel.nombre = nombre;
            //    oMiExcel.edad = edad;

            //    db.miexcel.Add(oMiExcel);
            //    db.SaveChanges();

            iRow++;
            //}

        }






        path = @"D:\Edgar\BDright\Aportes\Aportes_Diario_2000.xlsx";
        SLDocument sl = new SLDocument(path);

        //using (var db = new pruebaEntities())
        //{

        int iRow = 5;

        string query;

        while (!string.IsNullOrEmpty(sl.GetCellValueAsDateTime(iRow, 1).ToString("yyyy/mm/dd")))
        {
            DateTime Fecha = sl.GetCellValueAsDateTime(iRow, 1);
            string Region = sl.GetCellValueAsString(iRow, 2);
            string Rio = sl.GetCellValueAsString(iRow, 3);
            double Aportecau = sl.GetCellValueAsDouble(iRow, 4);
            double Aportesene = sl.GetCellValueAsDouble(iRow, 5);
            double Aportespor = sl.GetCellValueAsDouble(iRow, 6);



            query = string.Format("INSERT INTO basicas.aportesdiarioshistoria (Fecha,RegionHidrologica,Nombrerio,Aportescaudalm3,Aportesenergiakw,AportesPorcentaje) VALUES" +
                                        "({0},{1},{2},{3},{4},{5})", Fecha, Region, Rio, Aportecau, Aportesene, Aportespor);

            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader Reader = cmd.ExecuteReader();
            iRow++;
        }

    }
