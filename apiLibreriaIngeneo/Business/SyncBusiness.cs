using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class SyncBusiness
    {
        public static Model.Response.CodeResponse Sync()
        {
            Model.Response.CodeResponse response = new Model.Response.CodeResponse();
            try
            {
                response = SyncBooks();
                if (!ValidateResponse(response))
                {
                    return response;
                }
                response = SyncAuthors();
                if (!ValidateResponse(response))
                {
                    return response;
                }
                response.code = 100;
                response.message = "Success";
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.message = ex.Message;
            }
            return response;
        }
        private static Model.Response.CodeResponse SyncBooks()
        {
            string urlApiIngeneo = Data.Util.ConfigReader.GetValue("urlApiIngeneo");
            string methodBooks = Data.Util.ConfigReader.GetValue("methodSyncBooks");
            Model.Response.CodeResponse response = new Model.Response.CodeResponse();
            try
            {
                string urlComplete = urlApiIngeneo + methodBooks;
                string typeMethod = "GET";
                string json = string.Empty;
                string answer = Util.SendRequestAPI.Request(urlComplete, typeMethod, json);

                List<Model.Entities.BookEntity> listBooks = new List<Model.Entities.BookEntity>();
                listBooks = JsonConvert.DeserializeObject<List<Model.Entities.BookEntity>>(answer);
                foreach (Model.Entities.BookEntity book in listBooks)
                {
                    response = Data.BookData.Create(book);
                    if (!ValidateResponse(response))
                    {
                        return response;
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
        private static Model.Response.CodeResponse SyncAuthors()
        {
            string urlApiIngeneo = Data.Util.ConfigReader.GetValue("urlApiIngeneo");
            string methodAuthor = Data.Util.ConfigReader.GetValue("methodSyncAuthors");
            Model.Response.CodeResponse response = new Model.Response.CodeResponse();
            try
            {
                string urlComplete = urlApiIngeneo + methodAuthor;
                string typeMethod = "GET";
                string json = string.Empty;
                string answer = Util.SendRequestAPI.Request(urlComplete, typeMethod, json);

                List<Model.Entities.AuthorEntity> listAuthors = new List<Model.Entities.AuthorEntity>();
                listAuthors = JsonConvert.DeserializeObject<List<Model.Entities.AuthorEntity>>(answer);
                foreach (Model.Entities.AuthorEntity author in listAuthors)
                {
                    response = Data.AuthorData.Create(author);
                    if (!ValidateResponse(response))
                    {
                        return response;
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
        private static bool ValidateResponse(Model.Response.CodeResponse response)
        {
            if (!string.IsNullOrEmpty(response.message))
            {
                return false;
            }
            return true;
        }
    }
}
