namespace capaEntidad
{
    public class ceCliente
    {
        /*
         * public UserControl(bool isAdmin, string email, string password)
        {

            this.Email = email;
            this.Password = password;
            this.isAdmin = isAdmin;
        }
        */
        public string Email { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }

        public override string ToString()
        {
            return "Email: " + this.Email + ", Password: " + this.Password;
        }
    }
}