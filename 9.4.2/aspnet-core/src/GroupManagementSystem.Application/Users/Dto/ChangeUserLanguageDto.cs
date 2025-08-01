using System.ComponentModel.DataAnnotations;

namespace GroupManagementSystem.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}