using System.Windows.Controls;
using lab1.neoCorpDataSetTableAdapters;

namespace lab1
{
    /// <summary>
    /// Логика взаимодействия для DSCorp.xaml
    /// </summary>
    public partial class DSCorp : Page
    {
        corpusTableAdapter corp = new corpusTableAdapter();
        public DSCorp()
        {
            InitializeComponent();
            corpGrid.ItemsSource = corp.GetData();
        }
    }
}
