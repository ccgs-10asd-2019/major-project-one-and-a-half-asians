using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HayStack
{
    public partial class ToDoReal : Page, INotifyPropertyChanged
    {
        public EventHandler ladder;

        public void ClimbLadder()
        {
            ladder(this, EventArgs.Empty);
        }

        private void Todo_Return(object sender, RoutedEventArgs e)
        {
            ClimbLadder();
        }

        public static string fileName = "tasks.bin";

        private ObservableCollection<TaskManager> tasks;

        private ObservableCollection<TaskManager> subject;

        public ObservableCollection<TaskManager> Tasks
        {
            get { return tasks; }
            set
            {
                if (value != tasks)
                {
                    tasks = value;
                    OnPropertyChanged("Tasks");
                }
            }
        }

        public ObservableCollection<TaskManager> Subject
        {
            get { return subject; }
            set
            {
                if (value != subject)
                {
                    subject = value;
                    OnPropertyChanged("Subject");
                }
            }
        }

        private TaskManager selectedTask;
        public TaskManager SelectedTask
        {
            get { return selectedTask; }
            set
            {
                if (value != selectedTask)
                {
                    selectedTask = value;
                    OnPropertyChanged("SelectedTask");
                }
            }
        }

        private TaskManager selectedSubject;
        public TaskManager SelectedSubject
        {
            get { return selectedSubject; }
            set
            {
                if (value != selectedSubject)
                {
                    selectedSubject = value;
                    OnPropertyChanged("SelectedSubject");
                }
            }
        }

        public ToDoReal()
        {
            InitializeComponent();
            Tasks = new ObservableCollection<TaskManager>();
            Subject = new ObservableCollection<TaskManager>();
            SelectedTask = null;
            SelectedSubject = null;
            DataContext = this;
            deserializeTasks();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            Tasks.Add(new TaskManager(textBox.Text));
            Subject.Add(new TaskManager(SubjectChooser.Text));
            textBox.Text = "";
            SubjectChooser.Text = "";
            serializeTasks();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTask != null)
            {
                int index = -1;
                for (int i = 0; i < Tasks.Count; i++)
                {
                    if (Tasks[i].task.Equals(SelectedTask.task))
                    {
                        index = i;
                    }
                }
                if (index != -1)
                {
                    Tasks.RemoveAt(index);
                    OnPropertyChanged("Tasks");
                    OnPropertyChanged("Subjects");
                    serializeTasks();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void serializeTasks()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            try
            {
                stream = File.Open("tasks.bin", FileMode.OpenOrCreate);
                formatter.Serialize(stream, Tasks);
            }
            catch
            {
                throw new DriveNotFoundException();
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
            }


            try
            {
                stream = File.Open("subjects.bin", FileMode.OpenOrCreate);
                formatter.Serialize(stream, Subject);
            }
            catch
            {
                throw new DriveNotFoundException();
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
            }
        }

        public void deserializeTasks()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            if (File.Exists(fileName))
            {
                try
                {
                    stream = File.Open(fileName, FileMode.Open);
                    Tasks = (ObservableCollection<TaskManager>)formatter.Deserialize(stream);

                }
                catch
                {
                    throw new FileNotFoundException();
                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }

            }
        }

        public void ToDoInfoButtonClick(object sender, RoutedEventArgs e)
        {
            ToDoInfoStackPanel.Visibility = Visibility.Visible;
        }

        public void ToDoInfoExitButtonClick(object sender, RoutedEventArgs e)
        {
            ToDoInfoStackPanel.Visibility = Visibility.Collapsed;
        }
    }
}
