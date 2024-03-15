using System.Windows;
using System.Windows.Documents;


namespace lab1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PageFrame.Content = new DSStaff();
            EFWindow windEF = new EFWindow();
            windEF.Show();
        }

        private void staffButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new DSStaff();
        }

        private void postButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new DSPost();
        }

        private void corpButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new DSCorp();
        }
    }
}
