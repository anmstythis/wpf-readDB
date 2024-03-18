using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;


namespace lab1
{
    /// <summary>
    /// Логика взаимодействия для EFWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        neoCorpEntities neodb = new neoCorpEntities();
        bool corpButtonOpened = false;
        bool staffButtonOpened = true;
        bool postButtonOpened = false;
        public MainWindow()
        {
            InitializeComponent();
            baseGrid.ItemsSource = neodb.staff.ToList();
            TextSource("Введите имя", "Введите фамилию", "Введите отчество", "Введите email");
            forKey.ItemsSource = neodb.staffpost.ToList();
            forKey.DisplayMemberPath = "postname";
        }
        private void TextSource(string one, string two, string three, string four)
        {
            txtbx.Text = one;
            txtbx1.Text = two;
            txtbx2.Text = three;
            txtbx3.Text = four;
        }
        private void staffButton_Click(object sender, RoutedEventArgs e)
        {
            baseGrid.ItemsSource = neodb.staff.ToList();
            TextSource("Введите имя", "Введите фамилию", "Введите отчество", "Введите email");
            corpButtonOpened = false;
            staffButtonOpened = true;
            postButtonOpened = false;
            forKey.IsEnabled = true;
            forKey.ItemsSource = neodb.staffpost.ToList();
            forKey.DisplayMemberPath = "postname";
        }

        private void postButton_Click(object sender, RoutedEventArgs e)
        {
            baseGrid.ItemsSource = neodb.staffpost.ToList();
            TextSource("Введите название должности", string.Empty, string.Empty, string.Empty);
            corpButtonOpened = false;
            staffButtonOpened = false;
            postButtonOpened = true;
            forKey.IsEnabled = true;
            forKey.ItemsSource = neodb.corpus.ToList();
            forKey.DisplayMemberPath = "title";
        }

        private void corpButton_Click(object sender, RoutedEventArgs e)
        {
            baseGrid.ItemsSource = neodb.corpus.ToList();
            TextSource("Введите название корпуса", "Введите описание специализации", string.Empty, string.Empty);
            corpButtonOpened = true;
            staffButtonOpened = false;
            postButtonOpened = false;
            forKey.IsEnabled = false;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (staffButtonOpened)
            {
                staff emp = new staff();
                emp.firstname = txtbx.Text;
                emp.surname = txtbx1.Text;
                if (txtbx2.Text == "Введите отчество")
                {
                    emp.middlename = string.Empty;
                }
                else
                {
                    emp.middlename = txtbx2.Text;
                }
                emp.email = txtbx3.Text;
                emp.post_ID = forKey.SelectedIndex + 1;

                neodb.staff.Add(emp);

                neodb.SaveChanges();

                baseGrid.ItemsSource = neodb.staff.ToList();
            }
            else if (postButtonOpened)
            {
                staffpost post = new staffpost();

                post.postname = txtbx.Text;
                post.corp_ID = forKey.SelectedIndex + 1;

                neodb.staffpost.Add(post);

                neodb.SaveChanges();

                baseGrid.ItemsSource = neodb.staffpost.ToList();
            }
            else if (corpButtonOpened)
            {
                corpus corp = new corpus();

                corp.title = txtbx.Text;
                corp.speciality = txtbx1.Text;

                neodb.corpus.Add(corp);
                neodb.SaveChanges();

                baseGrid.ItemsSource = neodb.corpus.ToList();
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (staffButtonOpened)
            {
                if (baseGrid.SelectedItem != null)
                {
                    neodb.staff.Remove(baseGrid.SelectedItem as staff);

                    neodb.SaveChanges();

                    baseGrid.ItemsSource = neodb.corpus.ToList();
                }
            }
            else if (postButtonOpened)
            {
                if (baseGrid.SelectedItem != null)
                {
                    neodb.staffpost.Remove(baseGrid.SelectedItem as staffpost);

                    neodb.SaveChanges();

                    baseGrid.ItemsSource = neodb.corpus.ToList();
                }
            }
            else if (corpButtonOpened)
            {
                if (baseGrid.SelectedItem != null)
                {
                    neodb.corpus.Remove(baseGrid.SelectedItem as corpus);

                    neodb.SaveChanges();

                    baseGrid.ItemsSource = neodb.corpus.ToList();
                }
            }
        }

        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            if (staffButtonOpened)
            {
                if (baseGrid.SelectedItem != null)
                {
                    var selected = baseGrid.SelectedItem as staff;
                    selected.post_ID = forKey.SelectedIndex + 1;

                    neodb.SaveChanges();

                    baseGrid.ItemsSource= neodb.staff.ToList();
                }
            }
            else if (postButtonOpened)
            {
                if (baseGrid.SelectedItem != null)
                {
                    neodb.staffpost.Remove(baseGrid.SelectedItem as staffpost);

                    neodb.SaveChanges();

                    baseGrid.ItemsSource = neodb.corpus.ToList();
                }
            }
            else if (corpButtonOpened)
            {
                if (baseGrid.SelectedItem != null)
                {
                    neodb.corpus.Remove(baseGrid.SelectedItem as corpus);

                    neodb.SaveChanges();

                    baseGrid.ItemsSource = neodb.corpus.ToList();
                }
            }
        }
    }
}
