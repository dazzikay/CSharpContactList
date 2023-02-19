
namespace contacts
{
  internal class Contact
  {
        private string name;
        private string phone;
        private string email;

    public Contact(string name, string phone, string email)
            {
                this.name = name;
                this.phone = phone;
                this.email = email;
            }

        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }

        public override string ToString()
       {
            return $"Name: {name}, {phone}, {email}";
       }


    }


}


