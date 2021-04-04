using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class AuthorBusiness
    {
        public static Model.Response.AuthorResponse GetAll()
        {
            Model.Response.AuthorResponse response = new Model.Response.AuthorResponse();
            try
            {
                response = Data.AuthorData.GetAll();
                if (ValidateResponse(response))
                {
                    response.code = 100;
                    response.message = "Success";
                }
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.message = ex.Message;
            }
            return response;
        }
        public static Model.Response.AuthorResponse GetAuthorById(Model.Request.AuthorRequest request)
        {
            Model.Response.AuthorResponse response = new Model.Response.AuthorResponse();
            try
            {
                if (ValidateRequest(request))
                {
                    response = Data.AuthorData.GetAuthorById(request);
                    if (ValidateResponse(response))
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
        private static bool ValidateRequest(Model.Request.AuthorRequest request)
        {
            Model.Response.CodeResponse codeResponse = new Model.Response.CodeResponse();
            if (request.idAuthor < 0)
            {
                codeResponse.code = 101;
                codeResponse.message = "ID Number invalid";
                return false;
            }
            return true;
        }
        private static bool ValidateResponse(Model.Response.AuthorResponse response)
        {
            if (!string.IsNullOrEmpty(response.message))
            {
                return false;
            }
            return true;
        }
    }
}
