using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWebAppAssesmentApi_4August.Model
{
    public class Books
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "Varchar(50)")]
        public string? BookName { get; set; }
        [Required]
        [Column(TypeName = "Varchar(20)")]
        public string? Zoner { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "DateTime")]
        public DateTime? ReleaseDate { get; set; }
        [Required]
        public float Cost { get; set; }



    }
}
