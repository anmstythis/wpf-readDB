using System.Linq;
using System.Windows;


namespace lab1
{
    /// <summary>
    /// Логика взаимодействия для EFWindow.xaml
    /// </summary>
    public partial class EFWindow : Window
    {
        neoCorpEntities neodb = new neoCorpEntities();
        public EFWindow()
        {
            InitializeComponent();
            baseGrid.ItemsSource = neodb.staff.ToList();
        }

        private void staffButton_Click(object sender, RoutedEventArgs e)
        {
            baseGrid.ItemsSource = neodb.staff.ToList();
        }

        private void postButton_Click(object sender, RoutedEventArgs e)
        {
            baseGrid.ItemsSource = neodb.staffpost.ToList();
        }

        private void corpButton_Click(object sender, RoutedEventArgs e)
        {
            baseGrid.ItemsSource = neodb.corpus.ToList();
        }
    }
}
