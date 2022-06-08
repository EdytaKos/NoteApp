using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Windows.Documents;

namespace WpfLibrary1
{





    [Table("Subjects")]
    public partial class Subject

    {
        [Key]
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }


    [Table("Users")]
    public partial class Users
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string UserName { get; set; }
        protected int UserPassword { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }

    [Table("Notes")]
    public class Note
    {

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
    }



    [Table("Categories")]
    public partial class Category
    {
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


