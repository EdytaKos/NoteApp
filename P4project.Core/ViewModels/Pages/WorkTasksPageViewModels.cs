using P4project.Core.ViewModels.Controls;
using P4project.Helpers;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace P4project.Core.ViewModels.Pages
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
