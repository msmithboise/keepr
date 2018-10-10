using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
    public class Vault
    {

        public bool IsPrivate { get; set; }
        public int Keeps { get; set; }
        public int Shares { get; set; }
        public int Views { get; set; }

        public int Id { get; set; }

        public string UserId { get; set; }


        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }






    }





}