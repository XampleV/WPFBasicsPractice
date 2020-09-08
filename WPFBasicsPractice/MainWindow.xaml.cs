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
        private SQLiteConnection sqlite_conn;
        private SQLiteCommand sqlite_cmd;


        public string fullNameVar { get; private set; }
        public string phoneVar { get; private set; }
        public string dobVar { get; private set; }
        public string addNotesVar { get; private set; }

        public MainWindow()
        {
            createConnection();
            InitializeComponent();
        }

        private bool checkFields()
        {
            fullNameVar = fullName.Text;
            phoneVar = phoneNum.Text;
            dobVar = dob.Text;
            addNotesVar = addNotes.Text;

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
            insertIntoDatabase(fullNameVar, phoneVar, dobVar, addNotesVar);

            
        }
        private bool insertIntoDatabase(string name, string phone, string dob, string notes)
        {
            try
            {
                sqlite_cmd.CommandText = "INSERT INTO Clients (name, phone, dob, notes) VALUES(@name, @phone, @dob, @notes)";
                sqlite_cmd.Parameters.AddWithValue("@name", name);
                sqlite_cmd.Parameters.AddWithValue("@phone", phone);
                sqlite_cmd.Parameters.AddWithValue("@dob", dob);
                sqlite_cmd.Parameters.AddWithValue("@notes", notes);

                sqlite_cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully inserted client.", "Success");
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show($"Failed to insert user.\nError: {err}", "Error");
                return false;
            }

        }
        private void createConnection()
        {
            if (System.IO.File.Exists("database.db"))
            {
                sqlite_conn = new SQLiteConnection("DataSource=database.db;Version=3;");
                sqlite_conn.Open();
                sqlite_cmd = sqlite_conn.CreateCommand();
            }
            else
            {
                sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");
                sqlite_conn.Open();
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "CREATE TABLE Clients (name string primary key, phone string, dob string, notes string)";
                sqlite_cmd.ExecuteNonQuery();
                MessageBox.Show("Database was successfully created.", "Success");
            }
        
        }
    }
}
