using P4project.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace P4project.ViewModels
{
  public class NoteListViemModel
    {
      public List<NoteViwModel> Note { get; set; }
        public string NoteName { get; set; }
        public ICommand CreateNoteCommand { get { return new CreateNoteCommand(); }  }
    }
}
