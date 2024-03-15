using lab1.neoCorpDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace lab1
{
    /// <summary>
    /// Логика взаимодействия для DSStaff.xaml
    /// </summary>
    public partial class DSStaff : Page
    {
        staffTableAdapter staff = new staffTableAdapter();
        public DSStaff()
        {
            InitializeComponent();
            baseGrid.ItemsSource = staff.GetData();
        }
    }
}
