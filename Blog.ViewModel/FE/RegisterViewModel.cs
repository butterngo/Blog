namespace Blog.ViewModel.FE
{
    using System;

    public class RegisterViewModel: BaseViewModel
    {
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvataUrl { get; set; }
        public DateTime Birthday { get; set; }
    }
}
