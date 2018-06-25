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
        //chave primária
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [RegularExpression("[A-ZÍÉÂÁ][a-záéíóúàèìòùâêîôûäëïöüãõç]+(( |'|-| dos | da | de | e | d')[A-ZÍÉÂÁ][a-záéíóúàèìòùâêîôûäëïöüãõç]+){1,3}",
           ErrorMessage = "O {0} apenas pode conter letras e espaços em branco. Cada palavra começa em Maiúscula, seguida de minúsculas...")]
        public string NomeCompleto { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode =true)]//formata a data para aparecer Ano/Mês/Dia
        public DateTime DataNasc { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Sexo { get; set; }

        public string ImagemUtilizador { get; set; }

        // especifica que um Utilizador pode fazer vários Comentários
        public virtual ICollection<Comentarios> Comentarios { get; set; }
    }
}
