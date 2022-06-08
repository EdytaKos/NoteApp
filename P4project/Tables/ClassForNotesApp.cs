using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4project.Model
{
    public class ClassForNotesApp
    {
        static void Main(string[] args)
        {
            using (var context = new NotesApp())
            {
                var subject = new Subject
                {
                    SubjectName = "Matematyka"
                };
                context.Subjects.Add(subject);
                context.SaveChanges();

            }
        }



        public partial class Subject

        {

            public Subject()
            {
                Notes = new HashSet<Note>();
            }
            [Key]
            public int SubjectID { get; set; }
            public string SubjectName { get; set; }

            public virtual ICollection<Note> Notes { get; set; }
        }



        public partial class Users
        {

            public Users()
            {
                Notes = new HashSet<Note>();
            }
            [Key]
            public int UserID { get; set; }

            [Required]
            public string UserName { get; set; }
            protected int UserPassword { get; set; }

            public virtual ICollection<Note> Notes { get; set; }
        }

     
        public class Note
        {
            public Note()
            {
                Category= new HashSet<Category>();
            }

            [Key]
            public int NoteID { get; set; }

            [ForeignKey("Subjects")]
            public int SubjectID { get; set; }

            [ForeignKey("Users")]
            public string UserName { get; set; }

            [ForeignKey("Categories")]
            public int CategoryID { get; set; }

            public string NoteText { get; set; }


            public virtual Users Users { get; set; }
            public virtual Category Categories { get; set; }
            public virtual Subject Subjects { get; set; }
            public HashSet<Category> Category { get; }
        }



     
        public partial class Category
        {

            public Category()
            {
                Notes = new HashSet<Note>();
            }
            [Key]
            public int CategoryID { get; set; }

            [Required]
            public string CategoryName { get; set; }


            public virtual ICollection<Note> Notes { get; set; }
        }

        internal class NotesApp : DbContext
        {
            public NotesApp() : base("Server=LAPTOP-I6T122HQ;Database=NotesApp;Trusted_Connection=True;") { }

            public DbSet<Note> Notes { get; set; }
            public DbSet<Users> Users { get; set; }
            public DbSet<Subject> Subjects { get; set; }
            public DbSet<Category> Categories { get; set; }

        }
    }
}
