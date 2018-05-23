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

        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public virtual ICollection<Filme> Filmes { get; set; }
    }
}