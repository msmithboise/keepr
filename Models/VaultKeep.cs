using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
    public class VaultKeep
    {


        public int Id { get; set; }

        public int UserId { get; set; }


        [Required]
        [MinLength(6)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }



        public VaultKeep(string name, string description)
        {
            Name = name;
            Description = description;

        }


    }





}