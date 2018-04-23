using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Mttechne_TestDev.DAL
{


    public class ContatosDAL
    {

        public string Conexao
        {
            get
            {
                return ConfigurationManager.
              ConnectionStrings["BancoAgenda"].ConnectionString;
            }
        }


        public DataSet Getrecord()
        {
            DataTable contatosTable = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(Conexao))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM UsuarioAgenda", sqlCon);
                sqlDa.Fill(contatosTable);
                DataSet ds = new DataSet();
                sqlDa.Fill(ds);
                return ds;
            }

        }
    }
}
    

