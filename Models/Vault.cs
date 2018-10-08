using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
    public class Vault
    {

        public bool IsPrivate { get; set; }
        public int Keeps { get; set; }
        public int Shares { get; set; }
        public int Views { get; set; }

        public string Id { get; set; }

        public string UserId { get; set; }


        [Required]
        [MinLength(6)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }






    }





}