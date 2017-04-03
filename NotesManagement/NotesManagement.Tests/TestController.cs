using NotesManagement.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesManagement.Tests
{
    public class TestController : NotesController
    {
        public void ClearNotes()
        {
            db.Notes.RemoveRange(db.Notes);
        }
    }
}
