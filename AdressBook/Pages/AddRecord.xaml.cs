using System.Windows;
using System.Windows.Automation;
using System.ComponentModel;
namespace AdressBook;

public partial class AddRecord : Window
{
    public AddRecord()
    {
        InitializeComponent();
    }

    private void ConfirmInput(object sender, RoutedEventArgs e)
    {
        if (Phone.Text == "" | Name.Text == "")
        {
            MessageBox.Show("All fields are required.");
        }
        else
        {
            this.Close();    
        }
        
    }

    public List<String> Input
    {
        get {return [Name.Text,Phone.Text];}
    }
}