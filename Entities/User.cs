using System.ComponentModel;

namespace Users.Entities
{
    public class User
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int Age { get; set; }
        public string? Mail { get; set; }
        [DisplayName("Image")]
        public string? ImageURL { get; set; }
    }
}
