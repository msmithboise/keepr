using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{

    public class Keep
    {

        public int Id { get; set; }

        public string UserId { get; set; }

        [Required]
        [MinLength(6)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        public string ImgUrl { get; set; }



        public Keep() { }

        public Keep(string name, string description, string imgUrl)
        {
            Name = name;
            Description = description;
            ImgUrl = imgUrl;

        }


    }
}