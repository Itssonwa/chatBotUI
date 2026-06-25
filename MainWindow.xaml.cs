using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace chatBotUI
{
    public partial class MainWindow : Window
    {
        private Chatbot bot = new Chatbot();

        private readonly AppDbContext db = new AppDbContext();

        public MainWindow()
        {
            InitializeComponent();
            db.Database.EnsureCreated();
            LoadTasks();
        }

 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = UserInputBox.Text;

            if (string.IsNullOrWhiteSpace(userMessage))
            {
                MessageBox.Show("Ya gotta type something first partner!");
                return;
            }

            string response = bot.Respond(userMessage);
       
            db.ChatHistory.Add(new ChatHistory
            {
                UserMessage = userMessage,
                BotReply = response
            });
            db.SaveChanges();

            Label userLabel = new Label();
            userLabel.Content = "You: " + userMessage;
            userLabel.Foreground = Brushes.Black;
            userLabel.FontSize = 12;
            userLabel.HorizontalAlignment = HorizontalAlignment.Right;
      
            Label botLabel = new Label();
            botLabel.Content = response;
            botLabel.Foreground = Brushes.DarkBlue;
            botLabel.FontSize = 12;
            botLabel.HorizontalAlignment = HorizontalAlignment.Left;

            stackPanel1.Children.Add(userLabel);
            stackPanel1.Children.Add(botLabel);
            chatScroller.ScrollToEnd();
            UserInputBox.Clear();
          }

        private void LoadTasks()
        {
            TaskList.ItemsSource = null;
            TaskList.ItemsSource = db.Tasks.ToList();
          }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter a task title.");
                return;
              }

            Task task = new Task
            {
                Title = txtTitle.Text,
                Description = txtDescription.Text,
                Reminder = dpReminder.SelectedDate,
                IsCompleted = false
              };

            db.Tasks.Add(task);

            db.SaveChanges();

            LoadTasks();

            txtTitle.Clear();
            txtDescription.Clear();
            dpReminder.SelectedDate = null;
        }

        private void CompleteTask_Click(object sender, RoutedEventArgs e)
        {
            Task selectedTask = TaskList.SelectedItem as Task;

            if (selectedTask == null)
            {
                MessageBox.Show("Select a task first.");
                return;
              }

            selectedTask.IsCompleted = true;

            db.Tasks.Update(selectedTask);

            db.SaveChanges();

            LoadTasks();
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            Task selectedTask = TaskList.SelectedItem as Task;

            if (selectedTask == null)
            {
                MessageBox.Show("Select a task first.");
                return;
              }

            db.Tasks.Remove(selectedTask);

            db.SaveChanges();

            LoadTasks();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
          }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}