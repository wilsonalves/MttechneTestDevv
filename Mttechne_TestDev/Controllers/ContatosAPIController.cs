using Mttechne_TestDev.DAL;
using Mttechne_TestDev.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mttechne_TestDev.Controllers
{
    public class ContatosAPIController : ApiController
    {

        public List<ContatosModel> Getrecord()

        {
            ContatosDAL contatosDAL = new ContatosDAL();

            DataSet ds = contatosDAL.Getrecord();

            List<ContatosModel> usuarios = new List<ContatosModel>();

            foreach (DataRow dr in ds.Tables[0].Rows)

            {

                usuarios.Add(new ContatosModel

                {
                    ID = Convert.ToInt32(dr["ID"]),
                    Nome = dr["Nome"].ToString(),
                    Telefone = dr["telefone"].ToString(),
                    Telefone2 = dr["telefone2"].ToString(),
                    Telefone3 = dr["telefone3"].ToString(),

                    Email = dr["Email"].ToString(),
                    Email2 = dr["Email2"].ToString(),
                    Email3 = dr["Email3"].ToString(),

                    Empresa = dr["Empresa"].ToString(),

                    Endereco = dr["Endereco"].ToString(),



                });



            }
            return usuarios.OrderBy(x => x.Nome).ToList();
        }


    }


}
