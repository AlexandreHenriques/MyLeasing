﻿using System.ComponentModel.DataAnnotations;

namespace MyLeasing.Web.Data.Entities
{
    public class Owner : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Document*")]
        public int Document { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "the field {0} can contain {1} characters length.")]
        [Display(Name = "First Name*")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "the field {0} can contain {1} characters length.")]
        [Display(Name = "Last Name*")]
        public string LastName { get; set; }

        [Display(Name = "Fixed Phone")]
        public string? FixedPhone { get; set; }

        [Display(Name = "Cell Phone")]
        public string? CellPhone { get; set; }

        [Display(Name = "Address")]
        public string? Address { get; set; }

        [Display(Name = "Image")]
        public string? ImageUrl { get; set; }

        public User User { get; set; }

        public string ImageFullPath
        {
            get
            {
                if(string.IsNullOrEmpty(ImageUrl))
                {
                    return null;
                }

                return $"https://localhost:44330{ImageUrl.Substring(1)}";
            }
        }

        [Display(Name = "Owner Name")]
        public string OwnerName { get { return $"{FirstName} {LastName}"; } }
    }
}
