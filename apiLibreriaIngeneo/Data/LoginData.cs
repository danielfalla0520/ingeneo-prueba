
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Data
{
    public class LoginData
    {
        public static Model.Response.LoginResponse Login(Model.Request.LoginRequest request)
        {
            Model.Response.LoginResponse response = new Model.Response.LoginResponse();
            try
            {
                var dataservice = new Connection.DbContext();
                List<Model.Entities.UserEntity> userEntity = dataservice.GetListByParameter<Model.Entities.UserEntity, object>("loginUser", request);
                response.userEntity = userEntity[0];
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.message = ex.Message;
            }
            return response;            
        }
    }
}
