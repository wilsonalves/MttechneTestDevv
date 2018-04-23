using Mttechne_TestDev.DAL;
using Mttechne_TestDev.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Mttechne_TestDev.Controllers
{
    public class ContatosController : Controller
    {
        ContatosDAL contatosDAL = new ContatosDAL();


        [HttpGet]

        public ActionResult Index(ContatosModel contatosModel)
        {



            DataTable tbluser = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(contatosDAL.Conexao))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("select * from UsuarioAgenda", sqlCon);
                sqlDa.Fill(tbluser);
            }
            return View(tbluser);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ContatosModel());
        }

        //
        // POST: /Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "ID,Nome,telefone,telefone2,telefone3,Email,Email2,Email3,Empresa,Endereco")] ContatosModel contatosModel)
        {

            using (SqlConnection sqlCon = new SqlConnection(contatosDAL.Conexao))
            {
                sqlCon.Open();
                string query = "INSERT INTO UsuarioAgenda VALUES(@Nome,@telefone,@telefone2,@telefone3,@Email,@Email2,@Email3,@Empresa,@Endereco)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Nome", contatosModel.Nome);
                sqlCmd.Parameters.AddWithValue("@telefone", contatosModel.Telefone);


                sqlCmd.Parameters.AddWithValue("@telefone2",
                 ((object)contatosModel.Telefone2) ?? DBNull.Value);

                sqlCmd.Parameters.AddWithValue("@telefone3",
                ((object)contatosModel.Telefone3) ?? DBNull.Value);

                sqlCmd.Parameters.AddWithValue("@Email",
                 ((object)contatosModel.Email) ?? DBNull.Value);

                sqlCmd.Parameters.AddWithValue("@Email2",
                ((object)contatosModel.Email2) ?? DBNull.Value);

                sqlCmd.Parameters.AddWithValue("@Email3",
                ((object)contatosModel.Email3) ?? DBNull.Value);

                sqlCmd.Parameters.AddWithValue("@Empresa",
                ((object)contatosModel.Empresa) ?? DBNull.Value);

                sqlCmd.Parameters.AddWithValue("@Endereco",
                ((object)contatosModel.Endereco) ?? DBNull.Value);




                sqlCmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }
        [HttpGet]


        //
        // GET: /Product/Edit/5
        public ActionResult Edit(int id)
        {
            ContatosModel usuarios = new ContatosModel();
            DataTable dataUsuario = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(contatosDAL.Conexao))
            {
                sqlCon.Open();
                string query = "SELECT * FROM UsuarioAgenda Where ID = @ID";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@ID", id);
                sqlDa.Fill(dataUsuario);
            }
            if (dataUsuario.Rows.Count == 1)
            {
                usuarios.ID = Convert.ToInt32(dataUsuario.Rows[0][0].ToString());
                usuarios.Nome = dataUsuario.Rows[0][1].ToString();
                usuarios.Telefone = dataUsuario.Rows[0][2].ToString();
                usuarios.Telefone2 = dataUsuario.Rows[0][3].ToString();
                usuarios.Telefone3 = dataUsuario.Rows[0][4].ToString();
                usuarios.Email = dataUsuario.Rows[0][5].ToString();
                usuarios.Email2 = dataUsuario.Rows[0][6].ToString();
                usuarios.Email3 = dataUsuario.Rows[0][7].ToString();


                usuarios.Empresa = dataUsuario.Rows[0][8].ToString();

                usuarios.Endereco = dataUsuario.Rows[0][9].ToString();

                return View(usuarios);
            }
            else
                return RedirectToAction("Index");
        }

        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ContatosModel usuarios = new ContatosModel();
            DataTable dataUsuario = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(contatosDAL.Conexao))
            {
                sqlCon.Open();
                string query = "SELECT * FROM UsuarioAgenda Where ID = @ID";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@ID", id);
                sqlDa.Fill(dataUsuario);
            }
            if (dataUsuario.Rows.Count == 1)
            {
                usuarios.ID = Convert.ToInt32(dataUsuario.Rows[0][0].ToString());
                usuarios.Nome = dataUsuario.Rows[0][1].ToString();
                usuarios.Telefone = dataUsuario.Rows[0][2].ToString();
                usuarios.Telefone2 = dataUsuario.Rows[0][3].ToString();
                usuarios.Telefone3 = dataUsuario.Rows[0][4].ToString();
                usuarios.Email = dataUsuario.Rows[0][5].ToString();
                usuarios.Email2 = dataUsuario.Rows[0][6].ToString();
                usuarios.Email3 = dataUsuario.Rows[0][7].ToString();


                usuarios.Empresa = dataUsuario.Rows[0][8].ToString();

                usuarios.Endereco = dataUsuario.Rows[0][9].ToString();

                return View(usuarios);
            }
            else
                return RedirectToAction("Index");
        }

        //
        // POST: /Product/Edit/5
        [HttpPost]
        public ActionResult Edit(ContatosModel contatosModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(contatosDAL.Conexao))
            {
                sqlCon.Open();
                string query = "UPDATE UsuarioAgenda SET Nome = @Nome ,telefone=@telefone,telefone2=@telefone2,telefone3=@telefone3, Email = @Email,Email2 = @Email2,Email3 = @Email3,Empresa=@Empresa,Endereco=@Endereco WHere ID = @ID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@ID", contatosModel.ID);
                sqlCmd.Parameters.AddWithValue("@Nome", contatosModel.Nome);

                sqlCmd.Parameters.AddWithValue("@telefone",
               ((object)contatosModel.Telefone) ?? DBNull.Value);

                sqlCmd.Parameters.AddWithValue("@telefone2",
                 ((object)contatosModel.Telefone2) ?? DBNull.Value);

                sqlCmd.Parameters.AddWithValue("@telefone3",
                ((object)contatosModel.Telefone3) ?? DBNull.Value);

                sqlCmd.Parameters.AddWithValue("@Email",
                 ((object)contatosModel.Email) ?? DBNull.Value);

                sqlCmd.Parameters.AddWithValue("@Email2",
                ((object)contatosModel.Email2) ?? DBNull.Value);

                sqlCmd.Parameters.AddWithValue("@Email3",
                ((object)contatosModel.Email3) ?? DBNull.Value);

                sqlCmd.Parameters.AddWithValue("@Empresa",
                ((object)contatosModel.Empresa) ?? DBNull.Value);

                sqlCmd.Parameters.AddWithValue("@Endereco",
                ((object)contatosModel.Endereco) ?? DBNull.Value);

                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        //
        // GET: /Product/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(contatosDAL.Conexao))
            {
                sqlCon.Open();
                string query = "DELETE FROM UsuarioAgenda WHere ID = @ID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

    }
}
