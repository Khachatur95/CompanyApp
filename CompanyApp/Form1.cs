using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyApp
{
    public partial class Form1 : Form
    {
        static string connectionString = @"Data Source=DESKTOP-2JCI7CD;Initial Catalog=CompanyDb;Integrated Security=True;
                                        Connect Timeout=3;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            var connection = new SqlConnection(connectionString);


            using (connection = new SqlConnection(connectionString))
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Select * From HumanResources";

                    var reader = cmd.ExecuteReader();
                    listBox1.Items.Clear();
                    while (reader.Read())
                    {
                        listBox1.Items.Add($"{reader["Id_HumanResources"]}.{reader["EmployeeName"]}" +
                             $"   {reader["EmployeeSurname"]}    {reader["Age"]}    {reader["Position"]}    {reader["Salary"]}");
                    }
                }
            }


        }
        private void Button10_Click(object sender, EventArgs e)
        {

            var connection = new SqlConnection(connectionString);


            using (connection = new SqlConnection(connectionString))
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Select * From It";

                    var reader = cmd.ExecuteReader();
                    listBox2.Items.Clear();
                    while (reader.Read())
                    {
                        listBox2.Items.Add($"{reader["Id_It"]}.{reader["EmployeeName"]}" +
                             $"   {reader["EmployeeSurname"]}    {reader["Age"]}    {reader["Position"]}     {reader["Classification"]}    {reader["Salary"]}");
                    }
                }
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            InsertDbElements(connectionString, "HumanResources");
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            UpdateDbElements(connectionString, "HumanResources");
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            DeleteEmployee(connectionString, "HumanResources");
        }

        private void InsertDbElements(string connectionString, string tablename)
        {


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                var command = new SqlCommand($"INSERT INTO {tablename} (EmployeeName,EmployeeSurname, Age,Position,Salary) " +
                  $"VALUES (@EmployeeName,@EmployeeSurname,@Age,@Position,@Salary)", connection);
                command.Parameters.AddWithValue("EmployeeName", textBox2.Text);
                command.Parameters.AddWithValue("EmployeeSurname", textBox3.Text);
                command.Parameters.AddWithValue("Age", textBox4.Text);
                command.Parameters.AddWithValue("Position", textBox5.Text);
                command.Parameters.AddWithValue("Salary", textBox6.Text);

                command.ExecuteNonQuery();
                MessageBox.Show($"Added objects");
            }
        }
        private void UpdateDbElements(string connectionString, string tablename)
        {


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                var command = new SqlCommand($"Update {tablename} Set [EmployeeName] =@EmployeeName ,[EmployeeSurname] = @EmployeeSurname, [Age]=@Age,[Position]=@Position," +
                                             $"[Salary]=@Salary Where [Id_HumanResources]=@Id_HumanResources ", connection);
                command.Parameters.AddWithValue("Id_HumanResources", textBox1.Text);
                command.Parameters.AddWithValue("EmployeeName", textBox2.Text);
                command.Parameters.AddWithValue("EmployeeSurname", textBox3.Text);
                command.Parameters.AddWithValue("Age", textBox4.Text);
                command.Parameters.AddWithValue("Position", textBox5.Text);
                command.Parameters.AddWithValue("Salary", textBox6.Text);

                int number = command.ExecuteNonQuery();
                MessageBox.Show("Updated objects");
            }
        }
        private void DeleteEmployee(string connectionString, string tablename)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var comand = new SqlCommand($"DELETE  {tablename} WHERE [Id_HumanResources]=@Id_HumanResources", connection);
                comand.Parameters.AddWithValue("Id_HumanResources", textBox1.Text);
                comand.ExecuteNonQuery();
                MessageBox.Show($"Delete Eployes ");
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            InsertDbElements_It(connectionString, "It");
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            UpdateDbElements_It(connectionString, "It");
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            DeleteEmployee_It(connectionString, "It");
        }

        private void InsertDbElements_It(string connectionString, string tablename)
        {


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                var command = new SqlCommand($"INSERT INTO {tablename} (EmployeeName,EmployeeSurname, Age,Position,Salary,Classification) " +
                  $"VALUES (@EmployeeName,@EmployeeSurname,@Age,@Position,@Salary,@Classification)", connection);
                command.Parameters.AddWithValue("EmployeeName", textBox10.Text);
                command.Parameters.AddWithValue("EmployeeSurname", textBox11.Text);
                command.Parameters.AddWithValue("Age", textBox12.Text);
                command.Parameters.AddWithValue("Position", textBox8.Text);
                command.Parameters.AddWithValue("Salary", textBox7.Text);
                command.Parameters.AddWithValue("Classification", textBox13.Text);

                command.ExecuteNonQuery();
                MessageBox.Show($"Added objects");
            }
        }

        private void DeleteEmployee_It(string connectionString, string tablename)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var comand = new SqlCommand($"DELETE  {tablename} WHERE [Id_It]=@Id_It", connection);
                comand.Parameters.AddWithValue("Id_It", textBox9.Text);
                comand.ExecuteNonQuery();
                MessageBox.Show($"Delete Eployes ");
            }
        }
        private void UpdateDbElements_It(string connectionString, string tablename)
        {


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                var command = new SqlCommand($"Update {tablename} Set [EmployeeName] =@EmployeeName ,[EmployeeSurname] = @EmployeeSurname, [Age]=@Age,[Position]=@Position," +
                                             $"[Salary]=@Salary Where [Id_It]=@Id_It ", connection);
                command.Parameters.AddWithValue("Id_It", textBox9.Text);
                command.Parameters.AddWithValue("EmployeeName", textBox10.Text);
                command.Parameters.AddWithValue("EmployeeSurname", textBox11.Text);
                command.Parameters.AddWithValue("Age", textBox12.Text);
                command.Parameters.AddWithValue("Position", textBox8.Text);
                command.Parameters.AddWithValue("Salary", textBox7.Text);
                command.Parameters.AddWithValue("Classification", textBox13.Text);

                int number = command.ExecuteNonQuery();
                MessageBox.Show("Updated objects");
            }
        }

    }
}
