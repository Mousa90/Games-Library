using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamesLibraryAPI.Models
{
    public class Games
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        [MaxLength(255)]
        public string CoverArt { get; set; }
        public Genre Genre { get; set; }

    }
    public enum Genre
    {
        Action,
        Horror,
        RPG,
        Fighting,
        FPS,
        Platformer,
        Sport,
        Racing
    }
}
