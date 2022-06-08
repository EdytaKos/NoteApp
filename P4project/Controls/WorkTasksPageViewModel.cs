using P4project.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
namespace P4project.Pages
{
    public class WorkTasksPageViewModel
    {
        public class WorkTasksPageViewModels
        {
            
            public ObservableCollection<WorkTaskViewModel> WorkTasksList { get; set; } = new ObservableCollection<WorkTaskViewModel>();
            public string NewWorkTasksTitle { get; set; }
            public string NewWorkTaskDescription { get; set; }
            public ICommand AddNewTaskCommand { get; set; }

            public WorkTasksPageViewModels()
            {
                AddNewTaskCommand = new RelayCommand(AddNewTasks);

            }

            public void AddNewTasks()
            {
                var newTask = new WorkTaskViewModel
                {
                    Title = NewWorkTasksTitle,
                    Description = NewWorkTaskDescription,
                    CreatedDate = DateTime.Now,
                };

                WorkTasksList.Add(newTask);
            }

           
        }
    }
}
