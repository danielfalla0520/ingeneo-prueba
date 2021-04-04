using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Response
{
    public class UserResponse : CodeResponse
    {
        public Model.Entities.UserEntity userEntity { get; set; }
    }
}
