namespace Blog.ViewModel.Bo
{
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel: BaseViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsRemember { get; set; }
    }
}
