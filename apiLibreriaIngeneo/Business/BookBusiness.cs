using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class BookBusiness
    {
        public static Model.Response.BookResponse GetAll()
        {
            Model.Response.BookResponse response = new Model.Response.BookResponse();
            try
            {
                response = Data.BookData.GetAll();
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
        public static Model.Response.BookResponse GetBookById(Model.Request.BookRequest request)
        {
            Model.Response.BookResponse response = new Model.Response.BookResponse();
            try
            {
                if (ValidateRequest(request))
                {
                    response = Data.BookData.GetBookById(request);
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
        private static bool ValidateRequest(Model.Request.BookRequest request)
        {
            Model.Response.CodeResponse codeResponse = new Model.Response.CodeResponse();
            if (request.idBook < 0)
            {
                codeResponse.code = 101;
                codeResponse.message = "ID Number invalid";
                return false;
            }
            return true;
        }
        private static bool ValidateResponse(Model.Response.BookResponse response)
        {
            if (!string.IsNullOrEmpty(response.message))
            {
                return false;
            }
            return true;
        }
        
    }
}
