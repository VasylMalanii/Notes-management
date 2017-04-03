using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotesManagement.Controllers;
using NotesManagement.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Linq;

namespace NotesManagement.Tests
{
    [TestClass]
    public class TestNotesController
    {
        [TestMethod]
        public void AddNote()
        {
            Note note = new Note() { NoteId = 1, Text = "TestText1", Title = "TestTitle1", Category = "TestCategory1" };
            TestController controller = new TestController();
            controller.ClearNotes();
            controller.PostNote(note);
            List<Note> result = controller.GetNotes().ToList();
            Assert.AreEqual(note, result.Last());
        }

        [TestMethod]
        public void DeleteNote()
        {
            Note note = new Note() { NoteId = 1, Text = "TestText1", Title = "TestTitle1", Category = "TestCategory1" };
            TestController controller = new TestController();
            controller.ClearNotes();
            controller.PostNote(note);
            controller.DeleteNote(controller.GetNotes().ToList().Last().NoteId);
            List<Note> result = controller.GetNotes().ToList();
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetNote()
        {
            List<Note> notes = new List<Note>() {
                new Note() { NoteId = 1, Text = "TestText1", Title = "TestTitle1", Category = "TestCategory1" },
                new Note() { NoteId = 2, Text = "TestText2", Title = "TestTitle2", Category = "TestCategory2" }
            };
            TestController controller = new TestController();
            controller.ClearNotes();
            foreach (var n in notes)
                controller.PostNote(n);
            List<Note> result = controller.GetNotes().ToList();
            Assert.AreEqual(notes[0], result[0]);
            Assert.AreEqual(notes[1], result[1]);
        }

        [TestMethod]
        public void PutNote()
        {
            Note note = new Note() { NoteId = 1, Text = "TestText1", Title = "TestTitle1", Category = "TestCategory1" };
            TestController controller = new TestController();
            controller.ClearNotes();
            controller.PostNote(note);
            Note n = controller.GetNotes().Last();
            n.Text = "TestText2";
            controller.PutNote(controller.GetNotes().Last().NoteId, n);
            List<Note> result = controller.GetNotes().ToList();
            Assert.AreEqual("TestText2", result[0].Text);
        }
    }
}
