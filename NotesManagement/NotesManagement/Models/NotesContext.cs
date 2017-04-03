using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NotesManagement.Models
{
    public class NotesContext : DbContext
    {
        public NotesContext() : base("name=NotesContext")
        {

        }

        public System.Data.Entity.DbSet<NotesManagement.Models.Note> Notes { get; set; }
    }
}
