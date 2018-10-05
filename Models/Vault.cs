using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
    public class Vault
    {


        [Required]
        [MinLength(6)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }



        public Vault(string name, string description)
        {
            Name = name;
            Description = description;

        }


    }





}