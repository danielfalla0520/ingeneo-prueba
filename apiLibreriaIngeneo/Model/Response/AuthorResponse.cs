using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Response
{
    public class AuthorResponse : CodeResponse
    {
        public List<Model.Entities.AuthorEntity> authorEntity { get; set; }
    }
}
