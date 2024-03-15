using System.Windows.Controls;
using lab1.neoCorpDataSetTableAdapters;


namespace lab1
{
    /// <summary>
    /// Логика взаимодействия для DSPost.xaml
    /// </summary>
    public partial class DSPost : Page
    {
        staffpostTableAdapter post = new staffpostTableAdapter();
        public DSPost()
        {
            InitializeComponent();
            postGrid.ItemsSource = post.GetData();
        }
    }
}
