using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TimeOff.Models
{
    public class Imagens
    {
        [Key]
        public int Id { get; set; }

        public string Imagem { get; set; }

        [ForeignKey("Filmes")]
        public int FilmeId { get; set; }

        public virtual Filme Filmes { get; set; }
    }
}