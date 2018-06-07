namespace TimeOff.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class Utilizador
    {
        public Utilizador()
        {
            Comentarios = new HashSet<Comentarios>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string NomeCompleto { get; set; }

        public DateTime DataNasc { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Sexo { get; set; }

        public string ImagemUtilizador { get; set; }
        
        public virtual ICollection<Comentarios> Comentarios { get; set; }
    }
}
