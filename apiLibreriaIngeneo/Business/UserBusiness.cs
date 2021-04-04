using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class UserBusiness
    {
        public static Model.Response.UserResponse Create (Model.Request.UserRequest request)
        {
            Model.Response.UserResponse response = new Model.Response.UserResponse();
            try
            {
                if (ValidateRequest(request))
                {
                    response = Data.UserData.Create(request);
                    if(ValidateResponse(response))
                    {
                        response.code = 100;
                        response.message = "Success";
                    }
                }
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.message = ex.Message;
            }
            return response;
        }
        private static bool ValidateRequest(Model.Request.UserRequest request)
        {
            Model.Response.CodeResponse codeResponse = new Model.Response.CodeResponse();
            if (string.IsNullOrEmpty(request.email))
            {
                codeResponse.code = 101;
                codeResponse.message = "Email invalid";
                return false;
            }
            if (string.IsNullOrEmpty(request.password))
            {
                codeResponse.code = 102;
                codeResponse.message = "password invalid";
                return false;
            }
            return true;
        }
        private static bool ValidateResponse(Model.Response.UserResponse response)
        {
            if (!string.IsNullOrEmpty(response.message))
            {
                return false;
            }
            return true;
        }
    }
}
