using System.ComponentModel.DataAnnotations;

namespace BonosBackend.Models
{
    public class Bono
    {
        public int id { get; set; }
        public int valor { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
