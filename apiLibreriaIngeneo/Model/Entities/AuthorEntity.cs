using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class AuthorEntity
    {
        public int id { get; set; }
        public int idBook { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
    }
}
