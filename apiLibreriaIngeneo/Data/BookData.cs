using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class BookData
    {
        public static Model.Response.BookResponse Create(Model.Entities.BookEntity request)
        {
            Model.Response.BookResponse response = new Model.Response.BookResponse();
            try
            {
                var dataservice = new Connection.DbContext();
                List<Model.Entities.BookEntity> listBooks = dataservice.GetListByParameter<Model.Entities.BookEntity, object>("createBook_InsertCommand", request);
                response.bookEntity = listBooks;
            }
            catch (Exception ex)
            {
                response.code = 500;
                response.message = ex.Message;
            }
            return response;
        }
        public static Model.Response.BookResponse GetAll()
        {
            Model.Response.BookResponse response = new Model.Response.BookResponse();
            try
            {
                var dataservice = new Connection.DbContext();
                List<Model.Entities.BookEntity> listBooks = dataservice.GetList<Model.Entities.BookEntity, object>("getBooks_SelectCommand");
                response.bookEntity = listBooks;
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
                var dataservice = new Connection.DbContext();
                List<Model.Entities.BookEntity> listBooks = dataservice.GetListByParameter<Model.Entities.BookEntity, object>("getBooksById_SelectCommand" , request);
                response.bookEntity = listBooks;
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
