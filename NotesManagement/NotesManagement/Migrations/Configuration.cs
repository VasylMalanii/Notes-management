namespace NotesManagement.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NotesManagement.Models.NotesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NotesManagement.Models.NotesContext context)
        {
            context.Notes.AddOrUpdate(
              n => n.NoteId,
              new Models.Note() { Title = "Title1", Text = "Text1", Category = "Category1" },
              new Models.Note() { Title = "Title2", Text = "Text2", Category = "Category2" },
              new Models.Note() { Title = "Title3", Text = "Text3", Category = "Category3" }
            );
        }
    }
}
