using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Response
{
    public class LoginResponse : CodeResponse
    {
        public string accessToken { get; set; }
        public Model.Entities.UserEntity userEntity { get; set; }
    }
}
