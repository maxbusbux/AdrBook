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
using Microsoft.EntityFrameworkCore;
namespace AdressBook;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void RefreshTable()
    {
        var db = new BookContext();
        var data = db.Books.ToList();
        AdressTable.ItemsSource=data;
    }
    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        RefreshTable();
    }

    private void Refresh_Click(object sender, RoutedEventArgs e)
    {
        RefreshTable();
    }

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        using (var db = new BookContext())
        {
            var win = new AddRecord();
            win.ShowDialog();
            db.Add(new Book() { Name = $"{win.Input[0]}", Phone = $"{win.Input[1]}" });
            db.SaveChanges();
            RefreshTable();
        }
    }

    private void Remove_Click(object sender, RoutedEventArgs e)
    {
        using (var db = new BookContext())
        {
            var win = new RemoveRecord();
            win.ShowDialog();
            var record = db.Books.Find(win.Input);
            if (record != null)
            {
                db.Books.Remove(record);
                db.SaveChanges();
            }
            RefreshTable();
        }
    }

    private void Edit_Click(object sender, RoutedEventArgs e)
    {
        using (var db = new BookContext())
        {
            var win = new EditRecord();
            win.ShowDialog();
            var record = db.Books.Find(Int32.Parse(win.Input[0]));
            if (record != null)
            {
                record.Name = $"{win.Input[1]}";
                record.Phone = $"{win.Input[2]}";
                db.SaveChanges();
            }
            RefreshTable();
        }
    }
    
}