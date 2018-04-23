using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mttechne_TestDev.Models
{
    public class ContatosModel
    {
        public int ID { get; set; }

        [StringLength(50), Required(ErrorMessage = "O campo {0} é obrigatorio !!")]
        [DisplayName("Nome")]
     
        public string Nome { get; set; }

        [StringLength(50), Required(ErrorMessage = "O campo {0} é obrigatorio !!")]
        [DisplayName("Telefone")]
        public string Telefone { get; set; }


        [DisplayName("Telefone (casa)")]
        public string Telefone2 { get; set; }

        [DisplayName("Telefone (trabalho/outros)")]
        public string Telefone3 { get; set; }

        [DisplayName("Email ")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Email (trabalho)")]
        [DataType(DataType.EmailAddress)]
        public string Email2 { get; set; }

        [DisplayName("Email (outros)")]
        [DataType(DataType.EmailAddress)]
        public string Email3 { get; set; }



        [DisplayName("Empresa")]
        public string Empresa { get; set; }
        [DisplayName("Endereco")]
        public string Endereco { get; set; }

    }
}