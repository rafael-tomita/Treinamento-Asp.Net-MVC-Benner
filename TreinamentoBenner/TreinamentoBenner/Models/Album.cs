using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TreinamentoBenner.Resources;

namespace TreinamentoBenner.Models
{
    [MetadataType(typeof(AlbumMetadata))]
    public class Album : IValidatableObject
    {
        public int Id { get; set; }
        public int GeneroId { get; set; }
        public int ArtistaId { get; set; }
        public string Titulo { get; set; }
        public decimal Valor { get; set; }
        public string UrlArte { get; set; }
        public virtual Artista Artista { get; set; }
        public virtual Genero Genero { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (UrlArte != null && UrlArte.EndsWith("gif"))
                yield return new ValidationResult("Não é suportado tipo de imagem .gif", new[] {"UrlArte"});
        }
    }

    public class AlbumMetadata
    {
        [DisplayName("Artista")]
        public int ArtistaId { get; set; }

        [DisplayName("Gênero")]
        public int GeneroId { get; set; }

        [Required]
        [Display(ResourceType = typeof(AlbumResource), Name = "UrlArt")]
        [RegularExpression(@"^https?://[a-zA-Z0-9./-]{3,}[.](jpg|png|gif)$", 
            ErrorMessage = @"Url deve estar no seguinte formato: http://asd/la.jpg")]
        public int UrlArte { get; set; }

        [Display(ResourceType = typeof(AlbumResource), Name = "Title")]
        [StringLength(50, MinimumLength = 2)]
        public string Titulo { get; set; }

        [Display(ResourceType = typeof(AlbumResource), Name = "Value")]
        public string Valor { get; set; }
    }
}