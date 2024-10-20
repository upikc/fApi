using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TestApi.Model;

namespace Api.entity
{
    public partial class UserDTO
    {
        public int Id { get; set; }
        public string login { get; set; }

        internal UserDTO(User user)
        {
            Id = user.Id;
            login = user.Login;
        }
    }

}
