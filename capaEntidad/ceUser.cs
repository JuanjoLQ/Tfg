namespace capaEntidad
{
    public class ceUser
    {
        public ceUser()
        {

        }
        public ceUser(int isAdmin, string email, string password)
        {
            this.Email = email;
            this.Password = password;
            this.isAdmin = isAdmin;
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public int isAdmin { get; set; }

        public override string ToString()
        {
            return "Email: " + this.Email + ", Password: " + this.Password;
        }
    }
}

//
//
//
/*
parsear tipos de datos a este objeto
user.Id = (int) txtId.Value;

user.Nombre = tbNombre.Text;;

user.Foto = picFoto.ImageLocation;



*/