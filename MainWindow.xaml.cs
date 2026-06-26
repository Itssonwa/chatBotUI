using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace chatBotUI
{
    public partial class MainWindow : Window
    {
        private Chatbot bot = new Chatbot();
        private Quiz quiz = new Quiz();
        private bool quizRunning = false;

        private readonly AppDbContext db = new AppDbContext();

        public MainWindow()
        {
            InitializeComponent();

            db.Database.EnsureCreated();

            LoadTasks();
        }

        // QUIZ
        private void StartQuiz_Click(object sender, RoutedEventArgs e)
        {
            quizRunning = true;
            quiz.CurrentQuestion = 0;
            quiz.Score = 0;

            stackPanel1.Children.Clear();

            MessageBox.Show("The Cybersecurity Quiz is starting!");
            ActivityLog.Add("Started the cybersecurity quiz.");
            DisplayQuestion();
        }

        private void DisplayQuestion()
        {
            stackPanel1.Children.Clear();
            Question q = quiz.Questions[quiz.CurrentQuestion];
            Label lbl = new Label();
            lbl.Content =
                $"Question {quiz.CurrentQuestion + 1}\n\n" +
                $"{q.QuestionText}\n\n" +
                $"{q.OptionA}\n" +
                $"{q.OptionB}\n";

            if (!string.IsNullOrWhiteSpace(q.OptionC))
            lbl.Content += "\n" + q.OptionC;
            lbl.FontSize = 16;
            stackPanel1.Children.Add(lbl);
        }

        private void CheckAnswer(string answer)
        {
            Question current = quiz.Questions[quiz.CurrentQuestion];

            if (answer.Trim().ToLower() == current.Answer.ToLower())
            {
                MessageBox.Show("Correct!");
                quiz.Score++;
            }
            else
            {
                MessageBox.Show("Incorrect!\nCorrect Answer: " + current.Answer);
            }

            quiz.CurrentQuestion++;

            if (quiz.CurrentQuestion >= quiz.Questions.Count)
            {
                EndQuiz();
                return;
            }

            DisplayQuestion();
        }

        private void EndQuiz()
        {
            quizRunning = false;

            string message;

            if (quiz.Score >= 9)
                message = "Outstanding, partner! You're a cybersecurity sheriff!";
            else if (quiz.Score >= 7)
                message = "Great job, partner! You know your cybersecurity.";
            else if (quiz.Score >= 5)
                message = "Not bad, partner. Keep learning!";
            else
                message = "Looks like you need more practice on the cyber trail.";

            ActivityLog.Add("Finished the quiz with a score of "
    +           quiz.Score + "/" + quiz.Questions.Count);

            MessageBox.Show(
                "Final Score: " +
                quiz.Score +
                "/" +
                quiz.Questions.Count +
                "\n\n" +
                message);
        }

        // CHATBOT
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (quizRunning)
            {
                CheckAnswer(UserInputBox.Text);

                UserInputBox.Clear();

                return;
            }

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

        // TASK MANAGER
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

            Task task = new Task()
            {
                Title = txtTitle.Text,
                Description = txtDescription.Text,
                Reminder = dpReminder.SelectedDate,
                IsCompleted = false
            };

            db.Tasks.Add(task);

            db.SaveChanges();
            ActivityLog.Add("Added task: " + task.Title);
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
            ActivityLog.Add("Completed task: " + selectedTask.Title);
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
            ActivityLog.Add("Deleted task: " + selectedTask.Title);
            LoadTasks();
        }
     
        // OTHER
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}