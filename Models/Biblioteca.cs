using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBiblioteca.Models
{
    [Table("LIBROS")]
    public class Biblioteca
    {
        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_LIBROS")]
        public int IdLibro { get; set; }
        [Column("TITULO")]
        public String Titulo { get; set; }
        [Column("AUTOR")]
        public String Autor { get; set; }
        [Column("TEMATICA")]
        public String Tematica { get; set; }
        [Column("URL_DESCARGA")]
        public String UrlDescarga { get; set; }
        [Column("IMAGEN_PORTADA")]
        public String ImagenPortada { get; set; }
    }

}