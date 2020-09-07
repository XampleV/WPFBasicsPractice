using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;

namespace WPFBasicsPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool checkFields()
        {
            string fullNameVar = fullName.Text;
            string phoneVar = phoneNum.Text;
            string dobVar = dob.Text;
            string addNotesVar = addNotes.Text;

            if (fullNameVar == "" || phoneVar == "" || dobVar == "")
            {
                return false;
            }

            return true;
        }
        private void SubmitClickFunction(object sender, RoutedEventArgs e)
        {
            // now we can execute functions
            if (checkFields() == false)
            {
                MessageBox.Show("Please input all required fields.", "Error");
                return;
            }
            
            // here is true, we can insert into local db
            
        }
    }
}
