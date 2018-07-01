namespace TimeOff.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Categorias
    {
        public Categorias()
        {
            Filmes = new HashSet<Filme>();
        }
        //chave primária
        [Key]
        public int Id { get; set; }

        //Nome da categoria obrigatória 
        [Required]
        public string Nome { get; set; }

        // especifica que uma Categoria tem vários Filmes
        public virtual ICollection<Filme> Filmes { get; set; }
    }
}
