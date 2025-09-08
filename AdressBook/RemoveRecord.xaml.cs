using System.Windows;

namespace AdressBook;

public partial class RemoveRecord : Window
{
    public RemoveRecord()
    {
        InitializeComponent();
    }
    private void ConfirmInput(object sender, RoutedEventArgs e)
    {
        if (IdInput.Text=="")
        {
            MessageBox.Show("All fields are required.");
        }
        else
        {
            this.Close();    
        }
        
    }
    public int Input
    {
        get {return Int32.Parse(IdInput.Text) ;}
    }
}