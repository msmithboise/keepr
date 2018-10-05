using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{

    public class Keep
    {

        [Required]
        [MinLength(6)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public string Url { get; set; }

        public Keep() { }

        public Keep(string name, string description, string url)
        {
            Name = name;
            Description = description;
            Url = url;
        }


    }
}