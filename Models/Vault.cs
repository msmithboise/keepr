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

        public int UserId { get; set; }


        [Required]
        [MinLength(6)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }



        public Vault(string name, string description, bool isPrivate, int keeps, int shares, int views)
        {
            Name = name;
            Description = description;
            Keeps = keeps;
            Shares = shares;
            Views = views;
            IsPrivate = isPrivate;


        }


    }





}