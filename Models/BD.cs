using Microsoft.Data.SqlClient;
using System;
using Dapper;
using System.Data;
public class BD{
private static string _connectionString = @"Server=localhost; DataBase=PUMPCO;Trusted_Connection=True;";
    public static List<string> _listaNombreProductos = new List<string>();
    public static List<string> ListaBusquedaNombProdu(int tipoBusqueda, string textoBusqueda, string codigo)
    {
        switch (tipoBusqueda)
        {
            case 1:
                using(SqlConnection PUMPCO = new SqlConnection(_connectionString))
                {
                    string sql = "select concat(CAST(STMPDH_DESCRP AS NVARCHAR(MAX)),'- ', STMPDH_TIPPRO ,'- ', CAST(STMPDH_ARTCOD AS NVARCHAR(MAX))) AS Nombre from STMPDH where (STMPDH_DESCRP  IS NOT NULL) And ((STMPDH_DESCRP COLLATE Latin1_General_CI_AI Like '%@TextoBusqueda%' )  or ( USR_STMPDH_NOTTEC  COLLATE Latin1_General_CI_AI Like '%@TextoBusqueda%' ))  ORDER BY CAST( STMPDH_DESCRP  AS NVARCHAR(MAX)) ASC ";
                    PUMPCO.Execute(sql, new{TextoBusqueda = textoBusqueda}); 
                    _listaNombreProductos = PUMPCO.Query<string>(sql).ToList();
                }
            break;

            case 2:
                using(SqlConnection PUMPCO = new SqlConnection(_connectionString))
                {
                    string sql = "select concat(STMPDH_TIPPRO ,'- ', CAST(STMPDH_ARTCOD AS NVARCHAR(MAX))) AS Nombre from STMPDH where (STMPDH_ARTCOD  IS NOT NULL)AND STMPDH_TIPPRO = '@Codigo' And (replace(replace ((STMPDH_ARTCOD COLLATE Latin1_General_CI_AI),'/',''),'-','' )Like '%@TextoBusqueda%' )  ORDER BY CAST( STMPDH_ARTCOD  AS NVARCHAR(MAX)) ASC ";
                    PUMPCO.Execute(sql, new{Codigo = codigo, TextoBusqueda = textoBusqueda}); 
                    _listaNombreProductos = PUMPCO.Query<string>(sql).ToList();
                }
            break;

            case 3:
                using(SqlConnection PUMPCO = new SqlConnection(_connectionString))
                {
                    string sql = "select concat(CAST(STMPDH_INDCOD AS NVARCHAR(MAX)),'- ', STMPDH_TIPPRO ,'- ', CAST(STMPDH_ARTCOD AS NVARCHAR(MAX))) AS Nombre from STMPDH where (STMPDH_INDCOD  IS NOT NULL) And (STMPDH_INDCOD COLLATE Latin1_General_CI_AI Like '%@TextoBusqueda%' )  ORDER BY CAST( STMPDH_INDCOD  AS NVARCHAR(MAX)) ASC ";
                    PUMPCO.Execute(sql, new{TextoBusqueda = textoBusqueda}); 
                    _listaNombreProductos = PUMPCO.Query<string>(sql).ToList();
                }
            break;

            case 4:
                using(SqlConnection PUMPCO = new SqlConnection(_connectionString))
                {
                    string sql = "select concat(CAST(USR_STMPDH_CODFAB AS NVARCHAR(MAX)),'- ', STMPDH_TIPPRO ,'- ', CAST(STMPDH_ARTCOD AS NVARCHAR(MAX))) AS Nombre from STMPDH where (USR_STMPDH_CODFAB  IS NOT NULL) And (USR_STMPDH_CODFAB COLLATE Latin1_General_CI_AI Like '%@TextoBusqueda%' )  ORDER BY CAST( USR_STMPDH_CODFAB  AS NVARCHAR(MAX)) ASC ";
                    PUMPCO.Execute(sql, new{TextoBusqueda = textoBusqueda}); 
                    _listaNombreProductos = PUMPCO.Query<string>(sql).ToList();
                }
            break;

            case 5:
                using(SqlConnection PUMPCO = new SqlConnection(_connectionString))
                {
                    string sql = "select concat(USR_CODFAB_DESCRI ,'- ', CAST(STMPDH_DESCRP AS NVARCHAR(MAX)) ,'- ', STMPDH_TIPPRO ,'- ', CAST(STMPDH_ARTCOD AS NVARCHAR(MAX))) AS Nombre from STMPDH inner join USR_CODFAB  on USR_STMPDH_FABRIC = USR_CODFAB_CODIGO  where (USR_CODFAB_DESCRI  IS NOT NULL) And (USR_CODFAB_DESCRI COLLATE Latin1_General_CI_AI Like '%@TextoBusqueda%' )  ORDER BY CAST( USR_CODFAB_DESCRI  AS NVARCHAR(MAX)) ASC";
                    PUMPCO.Execute(sql, new{TextoBusqueda = textoBusqueda}); 
                    _listaNombreProductos = PUMPCO.Query<string>(sql).ToList();
                }
            break;
        }
        return _listaNombreProductos;
    }
    public static List<SeguimeintoFormula> _listaSeguimeintoFromula = new List<SeguimeintoFormula>();
    //public static List<SeguimeintoFormula> SeguimeintoFormula()
    //{
    //    using(SqlConnection PUMPCO = new SqlConnection(_connectionString))
    //    {
    //        string sql = "select concat(STMPDH_TIPPRO ,'- ', CAST(STMPDH_ARTCOD AS NVARCHAR(MAX))) AS Nombre from STMPDH where (STMPDH_ARTCOD  IS NOT NULL)AND STMPDH_TIPPRO = '@Codigo' And (replace(replace ((STMPDH_ARTCOD COLLATE Latin1_General_CI_AI),'/',''),'-','' )Like '%@TextoBusqueda%' )  ORDER BY CAST( STMPDH_ARTCOD  AS NVARCHAR(MAX)) ASC ";
    //        PUMPCO.Execute(sql, new{Codigo = codigo, TextoBusqueda = textoBusqueda}); 
    //        _listaNombreProductos = PUMPCO.Query<string>(sql).ToList();
    //    }
    //    return _listaSeguimeintoFromula;
    //}

    public static List<string> _listaCharTipoCod = new List<string>();
    public static List<string> ObtenerListaCodigos()
    {
        using(SqlConnection PUMPCO = new SqlConnection(_connectionString))
        {
            string sql = "select STMPDH_TIPPRO as Nombre from STMPDH group by STMPDH_TIPPRO order by STMPDH_TIPPRO";
            _listaCharTipoCod = PUMPCO.Query<string>(sql).ToList();
        }
        return _listaCharTipoCod;
    }
}