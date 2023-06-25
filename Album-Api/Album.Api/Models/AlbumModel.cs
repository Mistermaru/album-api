using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Album.Api.Models
{
    public class AlbumModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "AlbumName")]
        public string Name { get; set; }
        [Display(Name = "Artist")]
        public string Artist { get; set; }
        [Display(Name = "ImageUrl")]
        public string ImageUrl { get; set; }

    }
}
