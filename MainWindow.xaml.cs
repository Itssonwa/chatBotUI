using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace chatBotUI
{
    public partial class MainWindow : Window
    {
        private Chatbot bot = new Chatbot();

        public MainWindow()
        {
            InitializeComponent();
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

           Label userLabel = new Label();
            userLabel.Content = "You: " + userMessage;
            userLabel.Foreground = Brushes.Black;
            userLabel.FontSize = 16;
            userLabel.HorizontalAlignment = HorizontalAlignment.Right;

          
            Label botLabel = new Label();
            botLabel.Content = response;
            botLabel.Foreground = Brushes.Blue;
            botLabel.FontSize = 16;
            botLabel.HorizontalAlignment = HorizontalAlignment.Left;

           
            stackPanel1.Children.Add(userLabel);
            stackPanel1.Children.Add(botLabel);
            chatScroller.ScrollToEnd();

            UserInputBox.Clear();
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