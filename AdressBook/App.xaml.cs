using System.Configuration;
using System.Data;
using System.Windows;

namespace AdressBook;

public partial class App : Application
{
    private void MainWindow_Startup(object sender, StartupEventArgs e)
    {
        using (var client = new BookContext())
        {
            client.Database.EnsureCreated();
        } 
    }
}