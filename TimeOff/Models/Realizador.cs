namespace TimeOff.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

   
    public partial class Realizador
    {
        public Realizador()
        {
            Filmes = new HashSet<Filme>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public DateTime DataNasc { get; set; }

        public String Biografia { get; set; }
        
        public virtual ICollection<Filme> Filmes { get; set; }
    }
}
