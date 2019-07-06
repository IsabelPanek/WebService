using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    [Table("Cidades")]
    public class Cidade
    {
        [Key]
        public int CidadeId { get; set; }
        public String Cep {get; set;}
        public String Logradouro { get; set; }
        public String Complemento { get; set; }
        public String Bairro { get; set; }

    }
}
