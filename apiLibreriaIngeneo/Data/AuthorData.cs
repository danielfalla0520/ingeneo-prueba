using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class AuthorData
    {
        public static Model.Response.AuthorResponse Create(Model.Entities.AuthorEntity request)
        {
            Model.Response.AuthorResponse response = new Model.Response.AuthorResponse();
            try
            {
                var dataservice = new Connection.DbContext();
                List<Model.Entities.AuthorEntity> listAuthors = dataservice.GetListByParameter<Model.Entities.AuthorEntity, object>("createAuthor_InsertCommand", request);
                response.authorEntity = listAuthors;
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.message = ex.Message;
            }
            return response;
        }
        public static Model.Response.AuthorResponse GetAll()
        {
            Model.Response.AuthorResponse response = new Model.Response.AuthorResponse();
            try
            {
                var dataservice = new Connection.DbContext();
                List<Model.Entities.AuthorEntity> listAuthors = dataservice.GetList<Model.Entities.AuthorEntity, object>("getAuthors_SelectCommand");
                response.authorEntity = listAuthors;
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
                var dataservice = new Connection.DbContext();
                List<Model.Entities.AuthorEntity> listAuthors = dataservice.GetListByParameter<Model.Entities.AuthorEntity, object>("getAuthorsById_SelectCommand", request);
                response.authorEntity = listAuthors;
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
