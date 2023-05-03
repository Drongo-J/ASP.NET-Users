using Newtonsoft.Json;
using Users.Entities;

namespace Users.Helpers
{
    public static class FileHelpers
    {
        public static List<User> ReadUsers()
        {
            using (StreamReader r = new StreamReader($"Files/{Constants.UsersFileName}"))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<User>>(json); ;
            }
        }
    }
}
