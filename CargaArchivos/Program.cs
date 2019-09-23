using MySql.Data.MySqlClient;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;


namespace CargaArchivos
{

    class Program
    {
        
        static string path, query;
        static SLDocument sl;
        static int iRow,iCol;
        static MySql.Data.MySqlClient.MySqlConnection conn;
       // MySql.Data.MySqlClient.MySqlConnection conn;
       // string myConnectionString;
       
        static string myConnectionString;
        [STAThread]
        static void Main(string[] args)
        {

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new DatosCargasArchivos());

            // Form Forma = new DatosCargasArchivos();

            //  Precios();
            //Aportes();
            //  DemandaEnergia();
            // AportesFaltantes();
            MessageBox.Show("Cambio");
            //DemandaPotencia();
        }

        static DateTime FechaMaxima(string query1)
        {

            
            DateTime fec=Convert.ToDateTime("1900-01-01");
            try
            {

                MySqlCommand cmd = new MySqlCommand(query1, conn);
                cmd.ExecuteNonQuery();
                MySqlDataReader Reader = cmd.ExecuteReader();
                while (Reader.Read()) fec =  Convert.ToDateTime(Reader[0]);
                Reader.Close();
               


            }

            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }
            return fec;
           
        }
static void DemandaEnergia()
        {
            SLDocument sl;
            int iRow;
            DateTime FecMaxima;
           

            myConnectionString = "server=localhost;uid=root;" + "pwd=Mariajose;database=basicas";


            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }


            var Años = new List<int> { 2019 };

            query = string.Format("SELECT MAX(demandaenergiasinhistoria.Fecha) FROM basicas.demandaenergiasinhistoria");

            FecMaxima=FechaMaxima(query);
           

            iRow = FecMaxima.DayOfYear + 5;

            foreach (int element in Años)
            {
                path = @"D:\Edgar\BDright\Demanda\Demanda_Energia_SIN_" + Convert.ToString(element) + ".xlsx";
                sl = new SLDocument(path);

              //  iRow = 5;

                //DataTable dt = new DataTable("basicas.demandaenergiasinhistoria");
                //MySqlDataAdapter da = new MySqlDataAdapter("basicas.demandaenergiasinhistoria", myConnectionString);
                //MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                //da.Fill(dt);


                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
                {
                    DateTime Fecha1 = sl.GetCellValueAsDateTime(iRow, 1);
                    var mes = Fecha1.Month;
                    var dia = Fecha1.Day;
                    var año = Fecha1.Year;
                    var fec = año + "/" + mes + "/" + dia;
                    String Fecha2 = fec;
                    Fecha2 = "'" + Fecha2 + "'";



                    double Demanda = sl.GetCellValueAsDouble(iRow, 2);
                    double Generacion = sl.GetCellValueAsDouble(iRow, 3);
                    double DemandaNA = sl.GetCellValueAsDouble(iRow, 4);
                    double Expotaciones = sl.GetCellValueAsDouble(iRow, 5);
                    double Importaciones = sl.GetCellValueAsDouble(iRow, 6);

                    if (Fecha2 == "2000-12-31")
                    {

                        Console.Write("Mensaje");
                    }


                    query = string.Format("INSERT INTO `basicas`.`demandaenergiasinhistoria` (`Fecha`,`Demanda`,`Generacion`,`Exportaciones`,`Importaciones`,`DemandaNoAtendida`)VALUES" +
                                                           "({0},{1},{2},{3},{4},{5})", Fecha2, Demanda, Generacion, Expotaciones, Importaciones, DemandaNA);

                    try
                    {

                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                        //MySqlDataReader Reader = cmd.ExecuteReader();


                    }

                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        Console.Write(ex.Message);
                    }


                    //var oMiExcel = new miexcel();
                    //oMiExcel.codigo = codigo;
                    //    oMiExcel.nombre = nombre;
                    //    oMiExcel.edad = edad;

                    //    db.miexcel.Add(oMiExcel);
                    //    db.SaveChanges();

                    iRow++;

                }

            }
            conn.Close();

        }



        /// <summary>
        /// /////////////////
        /// </summary>
        /// 
        static void DemandaPotencia()
        {
            SLDocument sl;
            int iRow;
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;" + "pwd=Mariajose;database=basicas";


            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }


            var Años = new List<int> {2019 };


            foreach (int element in Años)
            {

                //  path = @"D:\Edgar\BDright\Demanda\Demanda_Energia_SIN_" + Convert.ToString(element) + ".xlsx";
                path = @"D:\Edgar\BDright\Demanda\Demanda_Maxima_De_Potencia_" + Convert.ToString(element) + ".xlsx";


                sl = new SLDocument(path);

                iRow = 5;

                //DataTable dt = new DataTable("basicas.demandaenergiasinhistoria");
                //MySqlDataAdapter da = new MySqlDataAdapter("basicas.demandaenergiasinhistoria", myConnectionString);
                //MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                //da.Fill(dt);


                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
                {
                    DateTime Fecha1 = sl.GetCellValueAsDateTime(iRow, 1);
                    var mes = Fecha1.Month;
                    var dia = Fecha1.Day;
                    var año = Fecha1.Year;
                    var fec = año + "/" + mes + "/" + dia;
                    String Fecha2 = fec;
                    Fecha2 = "'" + Fecha2 + "'";



                    double Demanda = sl.GetCellValueAsDouble(iRow, 2);
                  

                    if (Fecha2 == "2000-12-31")
                    {

                        Console.Write("Mensaje");
                    }


                    query = string.Format("INSERT INTO `basicas`.`demandapotenciahistoria` (`Fecha`,`Demanda`)VALUES" +
                                                           "({0},{1})", Fecha2, Demanda);

                    try
                    {

                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                        //MySqlDataReader Reader = cmd.ExecuteReader();


                    }

                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        Console.Write(ex.Message);
                    }


                    //var oMiExcel = new miexcel();
                    //oMiExcel.codigo = codigo;
                    //    oMiExcel.nombre = nombre;
                    //    oMiExcel.edad = edad;

                    //    db.miexcel.Add(oMiExcel);
                    //    db.SaveChanges();

                    iRow++;

                }

            }
            conn.Close();

        }





        static void Aportes()
        {

            DateTime FecMaxima;
            myConnectionString = "server=localhost;uid=root;" + "pwd=Mariajose;database=basicas";


            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }


           // var Años = new List<int> { 2000, 2001, 2002, 2003, 2004, 2005,2006, 2007, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019 };

            var Años = new List<int> {2019 };

            query = string.Format("SELECT MAX(aportesdiarioshistoria.Fecha) FROM basicas.aportesdiarioshistoria");

            FecMaxima = FechaMaxima(query);


            iRow = FecMaxima.DayOfYear + 5;

           

            foreach (int element in Años)
            {

                path = @"D:\Edgar\BDright\Aportes\Aportes_Diario_" + Convert.ToString(element) + ".xlsx";
              
                sl = new SLDocument(path);

                //using (var db = new pruebaEntities())
                //{

              //  iRow = 5;

                string query;

                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 2)))
                {

                    string Fecha1 = sl.GetCellValueAsString(iRow, 2);
                    Fecha1 = "'" + Fecha1 + "'";
                    DateTime Fecha2= sl.GetCellValueAsDateTime(iRow, 2);


                    if (Fecha2 > FecMaxima)
                    {

                        string Region = "'" + sl.GetCellValueAsString(iRow, 3) + "'";
                        string Rio = "'" + sl.GetCellValueAsString(iRow, 4) + "'";
                        double Aportecau = sl.GetCellValueAsDouble(iRow, 5);
                        double Aportesene = sl.GetCellValueAsDouble(iRow, 6) / 1000;
                        double Aportespor = sl.GetCellValueAsDouble(iRow, 7);



                        query = string.Format("INSERT INTO basicas.aportesdiarioshistoria (Fecha,RegionHidrologica,Nombrerio,Aportescaudalm3,Aportesenergiakw,AportesPorcentaje) VALUES" +
                                                    "({0},{1},{2},{3},{4},{5})", Fecha1, Region, Rio, Aportecau, Aportesene, Aportespor);

                        try
                        {

                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.ExecuteNonQuery();
                            //MySqlDataReader Reader = cmd.ExecuteReader();

                        }

                        catch (MySql.Data.MySqlClient.MySqlException ex)
                        {
                            Console.Write(ex.Message);
                        }
                    }
                    //else
                    //    break;
                    iRow++;
                }
            }

            conn.Close();
            Console.Write("Proceso Terminado");
        }




        static void AportesFaltantes()
        {
            SLDocument sl;
            int iRow,iCol;
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;" + "pwd=Mariajose;database=basicas";


            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }


            var Años = new List<int> { 2019 };


            foreach (int element in Años)
            {

                //  path = @"D:\Edgar\BDright\Demanda\Demanda_Energia_SIN_" + Convert.ToString(element) + ".xlsx";
                path = @"D:\Edgar\BDright\Aportes\caudalesHistoricosMensuales_sddp_abril2019" + ".xlsx";


                sl = new SLDocument(path);

                iRow = 2;
                iCol = 2;
                //DataTable dt = new DataTable("basicas.demandaenergiasinhistoria");
                //MySqlDataAdapter da = new MySqlDataAdapter("basicas.demandaenergiasinhistoria", myConnectionString);
                //MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                //da.Fill(dt);


                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
                {
                   
                    string Rio = sl.GetCellValueAsString(iRow-1, iCol);
                    Rio = "'" + Rio + "'";
                    int Mapeo = sl.GetCellValueAsInt32(iRow , iCol);

                    while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, iCol)))
                    {
                        DateTime Fecha1 = sl.GetCellValueAsDateTime(iRow + 1, 1);
                        var mes = Fecha1.Month;
                        var dia = Fecha1.Day;
                        var año = Fecha1.Year;
                        var fec = año + "/" + mes + "/" + dia;
                        String Fecha2 = fec;
                        Fecha2 = "'" + Fecha2 + "'";

                        double Aportecau = sl.GetCellValueAsDouble(iRow+1, iCol);


                        if (Fecha2 == "2000-12-31")
                        {

                            Console.Write("Mensaje");
                        }



                        query = string.Format("INSERT INTO basicas.aportesdiarioshistoria_riosfaltan (Fecha,RegionHidrologica,Nombrerio,Aportescaudalm3,Aportesenergiakw,AportesPorcentaje) VALUES" +
                                                    "({0},{1},{2},{3},{4},{5})", Fecha2, Mapeo, Rio, Aportecau, 0, 0);

                        try
                        {

                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.ExecuteNonQuery();
                            //MySqlDataReader Reader = cmd.ExecuteReader();


                        }

                        catch (MySql.Data.MySqlClient.MySqlException ex)
                        {
                            Console.Write(ex.Message);
                        }


                        //var oMiExcel = new miexcel();
                        //oMiExcel.codigo = codigo;
                        //    oMiExcel.nombre = nombre;
                        //    oMiExcel.edad = edad;

                        //    db.miexcel.Add(oMiExcel);
                        //    db.SaveChanges();
                        iRow++;
                    }
                    iCol++;
                    iRow = 2;

                }

            }
            conn.Close();

        }





        static void Precios()
        {

            myConnectionString = "server=localhost;uid=root;" + "pwd=Mariajose;database=basicas";            
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }

            path = @"D:\Edgar\BDright\CostosCombustible\Anexos_Proyeccion_Precios_VF_2018.xlsx";
            sl = new SLDocument(path);
            var hojas = sl.GetWorksheetNames();
            string query;
            int regid = 0;
            int incrementoramal = 0;
            int inicioramal = 2;
            int incrementorecurso = 2;
            int filarecurso = 5;
            int inccolumna = 2;
            int escenarios = 1;
            string Ramal;
            int filaRamal = 4;
            int Linearamal=0;
            int incrementoramalxhoja = 0;
            string encabezado, encabezado2;
            iRow = 0;
           

            foreach (var name in sl.GetWorksheetNames())  /// ciclo para las hojas del libro
            {
                //sl.MoveWorksheet(name, 1);


                sl.SelectWorksheet(name);

                if (name == "GAS NATURAL")
                {
                    inicioramal = 2;
                    incrementorecurso = 2;
                    inccolumna = 2;
                    escenarios = 1;
                    incrementoramal = 0;
                    iRow = 6;
                    filaRamal = 4;
                    filarecurso = 5;
                    incrementoramalxhoja = 2;
                }

                if (name == "Precios Térmicas Diesel")
                {
                    inicioramal = 2;
                    incrementorecurso = 2;
                    inccolumna = 2;
                    escenarios = 1;
                    incrementoramal = 0;
                    iRow = 6;
                    filaRamal = 4;
                    filarecurso = 5;
                    incrementoramalxhoja = 3;

                }

                if (name == "Precios Térmicas Jet")
                {
                    inicioramal = 2;
                    incrementorecurso = 2;
                    inccolumna = 2;
                    escenarios = 1;
                    incrementoramal = 0;
                    iRow = 5;
                    filaRamal = 3;
                    filarecurso = 4;
                    incrementoramalxhoja = 3;
                    Linearamal = 3;
                }

                if (name == "FUEL OIL")
                {
                    inicioramal = 2;
                    incrementorecurso = 2;
                    inccolumna = 2;
                    escenarios = 1;
                    incrementoramal = 0;
                    iRow = 5;
                    filaRamal = 3;
                    filarecurso = 4;
                    incrementoramalxhoja = 3;
                    Linearamal = 3;
                }

                if (name == "CARBÓN")
                {
                    inicioramal = 2;
                    incrementorecurso = 2;
                    inccolumna = 2;
                    escenarios = 1;
                    incrementoramal = 0;
                    iRow = 7;
                    filaRamal = 5;
                    filarecurso = 6;
                    incrementoramalxhoja = 3;
                    Linearamal = 5;
                }


                encabezado = (sl.GetCellValueAsString(filaRamal, inccolumna));
                encabezado2 = (sl.GetCellValueAsString(filaRamal, inccolumna + incrementoramalxhoja));
                while ((!string.IsNullOrEmpty(sl.GetCellValueAsString(filaRamal, inccolumna))) || (!string.IsNullOrEmpty(sl.GetCellValueAsString(filaRamal, inccolumna + incrementoramalxhoja)))) // ciclo para los ramales
                {

                    if ((!string.IsNullOrEmpty(sl.GetCellValueAsString(filaRamal, inccolumna + incrementoramalxhoja))))
                    {
                        if (name == "Precios Térmicas Jet")
                        {
                            incrementoramal = 1;
                            incrementorecurso++;
                            inccolumna++;
                            iRow = 5;
                        }


                        if ((string.IsNullOrEmpty(sl.GetCellValueAsString(filaRamal, inccolumna))))
                        {
                            incrementorecurso = incrementorecurso + 2;
                            incrementoramal = incrementoramal + 2;
                            inccolumna = inccolumna + 2;
                        }
                    }

                    encabezado = (sl.GetCellValueAsString(filaRamal, inccolumna));
                    encabezado2 = (sl.GetCellValueAsString(filaRamal, inccolumna + 2));

                    while (!string.IsNullOrEmpty(sl.GetCellValueAsString(filarecurso, incrementorecurso)))
                    {
                        if ((escenarios % 4) == 0)
                        {
                            incrementoramal = incrementoramal + 3;
                            Ramal = "'" + sl.GetCellValueAsString(filaRamal, inicioramal + incrementoramal) + "'";
                            escenarios++;
                        }
                        else
                        {
                            Ramal = "'" + sl.GetCellValueAsString(filaRamal, inicioramal + incrementoramal) + "'";
                        }
                        while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
                        {

                            DateTime Fecha1 = sl.GetCellValueAsDateTime(iRow, 1);
                            var mes = Fecha1.Month;
                            var dia = Fecha1.Day;
                            var año = Fecha1.Year;
                            var fec = año + "/" + mes + "/" + dia;
                            String Fecha2 = fec;
                            Fecha2 = "'" + Fecha2 + "'";

                            string Recurso = "'" + sl.GetCellValueAsString(filarecurso, incrementorecurso) + "'"; // recurso referencia
                            string Centroscombustible = "'" + name + "'";
                            double Valorcostocombustible = sl.GetCellValueAsDouble(iRow, inccolumna);
                            regid++;

                            query = string.Format("INSERT INTO `basicas`.`costoscombustiblesbasica` (`Idcostoscombustibles`,`Fecha`,`Ramal`,`Recurso`,`Valorcostocombustible`,`Centroscombustible`)VALUES" +
                                                        "({0},{1},{2},{3},{4},{5})", regid, Fecha2, Ramal, Recurso, Valorcostocombustible, Centroscombustible);
                            try
                            {
                                MySqlCommand cmd = new MySqlCommand(query, conn);
                                cmd.ExecuteNonQuery();
                                MySqlDataReader Reader = cmd.ExecuteReader();

                            }

                            catch (MySql.Data.MySqlClient.MySqlException ex)
                            {
                                Console.Write(ex.Message);
                            }

                            iRow++;
                        }

                        if ((name == "GAS NATURAL") || (name == "Precios Térmicas Diesel"))
                        {
                            iRow = 6;

                        }
                        else if ((name == "Precios Térmicas Jet") || (name == "FUEL OIL"))
                        {
                            iRow = 5;


                        }
                        else
                            iRow = 7;


                        incrementorecurso = incrementorecurso + 1;
                        inccolumna++;
                        escenarios++;

                    }
                }
            }
            conn.Close();
            Console.Write("Proceso Terminado");
        }
    }
}

      