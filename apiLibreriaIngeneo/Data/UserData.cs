using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserData
    {
        public static Model.Response.UserResponse Create (Model.Request.UserRequest request)
        {
            Model.Response.UserResponse response = new Model.Response.UserResponse();
            try
            {
                var dataservice = new Connection.DbContext();
                List<Model.Entities.UserEntity> userEntity = dataservice.GetListByParameter<Model.Entities.UserEntity, object>("createUser_InsertCommand", request);
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
