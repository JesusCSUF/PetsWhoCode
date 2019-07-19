namespace PetVision.Web.Models
{
    public class Owner
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public Group Group { get; set; }

        public Origin Origin { get; set; }
    }
}