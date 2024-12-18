//using System.Data.SqlClient;
//using System;
//using Dapper;
//using System.Data;
//public class BD{
//private static string _connectionString = @"Server=localhost; DataBase=TP_REBOOKING;Trusted_Connection=True;";
//
//    public static void ObtenerCategorias(Publicacion publi)
//    {
//        using(SqlConnection TP_REBOOKING = new SqlConnection(_connectionString))
//        {
//            string sql = "SELECT * FROM Publicacion";
//            TP_REBOOKING.Execute(sql, new{nombre = publi.id_libro, Preci = publi.precio}); 
//            List<Publicacion> listaCategorias = TP_REBOOKING.Query<Publicacion>(sql).ToList();
//        }
//     
//    }
//}