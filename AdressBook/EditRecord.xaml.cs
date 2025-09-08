using System.Windows;

namespace AdressBook;

public partial class EditRecord : Window
{
    public EditRecord()
    {
        InitializeComponent();
    }
    private void ConfirmInput(object sender, RoutedEventArgs e)
    {
        if (Id.Text==""|Phone.Text == "" | Name.Text == "")
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
        get {return [Id.Text,Name.Text,Phone.Text];}
    }
}