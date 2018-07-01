using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeOff.Models
{
    public class Ator
    {
        public Ator()
        {
            Filmes = new HashSet<Filme>();
        }
        //chave primária
        [Key]
        public int Id { get; set; }

        //Nome do ator obrigatória 
        [Required]
        public string Nome { get; set; }

        // especifica que um Ator tem vários Filmes
        public virtual ICollection<Filme> Filmes { get; set; }
    }
}