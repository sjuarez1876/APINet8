using System.ComponentModel.DataAnnotations;

namespace ApiPersonas.Models
{
    public class tbl_personas
    {
        [Key]
        public int id_persona { get; set; }
        public string Nombre { get; set; }
        public string Edad { get; set; } 
        public string Email { get; set; }
    }
}
