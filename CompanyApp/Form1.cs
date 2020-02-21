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

        //Human Resources
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
                             $"   {reader["EmployeeSurname"]} ");
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
        private void Info_Button_Click(object sender, EventArgs e)
        {
            More_Info_Employee(connectionString, "HumanResources");
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
        private void More_Info_Employee(string connectionString, string tablename)
        {
            var connection = new SqlConnection(connectionString);


            using (connection = new SqlConnection(connectionString))
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    var comand = new SqlCommand($"Select * From {tablename} WHERE [Id_HumanResources]=@Id_HumanResources", connection);
                    comand.Parameters.AddWithValue("Id_HumanResources", textBox1.Text);

                    var reader = comand.ExecuteReader();
                    listBox1.Items.Clear();
                    while (reader.Read())
                    {
                        listBox_info.Items.Add($"{reader["Id_HumanResources"]}.{reader["EmployeeName"]}" +
                             $"   {reader["EmployeeSurname"]}    {reader["Age"]}    {reader["Position"]}    {reader["Salary"]}");
                    }
                }
            }
        }
        //It
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
        private void More_Info_It_Click(object sender, EventArgs e)
        {
            More_Info_Employee_It(connectionString, "It");
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
        private void More_Info_Employee_It(string connectionString, string tablename)
        {
            var connection = new SqlConnection(connectionString);


            using (connection = new SqlConnection(connectionString))
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    var comand = new SqlCommand($"Select * From {tablename} WHERE [Id_It]=@Id_It", connection);
                    comand.Parameters.AddWithValue("Id_It", textBox9.Text);

                    var reader = comand.ExecuteReader();
                    listBox1.Items.Clear();
                    while (reader.Read())
                    {
                        listBox_It_info.Items.Add($"{reader["Id_It"]}.{reader["EmployeeName"]}" +
                             $"   {reader["EmployeeSurname"]}    {reader["Age"]}    {reader["Position"]}    {reader["Salary"]}    {reader["Classification"]}");
                    }
                }
            }
        }
        //Marketing
        private void Add_MR_Click(object sender, EventArgs e)
        {
            InsertDbElements_MR(connectionString, "Marketing");
        }
        private void Update_MR_Click(object sender, EventArgs e)
        {
            UpdateDbElements_MR(connectionString, "Marketing");
        }
        private void Dlelete_MR_Click(object sender, EventArgs e)
        {
            DeleteEmployee_MR(connectionString, "Marketing");
        }
        private void MR_Staff_Click(object sender, EventArgs e)
        {
            var connection = new SqlConnection(connectionString);

            using (connection = new SqlConnection(connectionString))
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Select * From Marketing";

                    var reader = cmd.ExecuteReader();
                    listBox_MR.Items.Clear();
                    while (reader.Read())
                    {
                        listBox_MR.Items.Add($"{reader["Id_Marketing"]}.{reader["EmployeeName"]}" +
                              $"   {reader["EmployeeSurname"]} ");
                    }
                }
            }

        }
        private void MR_info_Click(object sender, EventArgs e)
        {
            More_Info_Employee_MR(connectionString, "Marketing");
        }
        private void InsertDbElements_MR(string connectionString, string tablename)
        {


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                var command = new SqlCommand($"INSERT INTO {tablename} (EmployeeName,EmployeeSurname, Age,Position,Salary) " +
                  $"VALUES (@EmployeeName,@EmployeeSurname,@Age,@Position,@Salary)", connection);
                command.Parameters.AddWithValue("EmployeeName", MR_Name.Text);
                command.Parameters.AddWithValue("EmployeeSurname", MR_Surname.Text);
                command.Parameters.AddWithValue("Age", MR_Age.Text);
                command.Parameters.AddWithValue("Position", MR_Position.Text);
                command.Parameters.AddWithValue("Salary", MR_Salary.Text);

                command.ExecuteNonQuery();
                MessageBox.Show($"Added objects");
            }
        }
        private void UpdateDbElements_MR(string connectionString, string tablename)
        {


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                var command = new SqlCommand($"Update {tablename} Set [EmployeeName] =@EmployeeName ,[EmployeeSurname] = @EmployeeSurname, [Age]=@Age,[Position]=@Position," +
                                             $"[Salary]=@Salary Where [Id_Marketing]=@Id_Marketing ", connection);
                command.Parameters.AddWithValue("Id_Marketing", MR_Id.Text);
                command.Parameters.AddWithValue("EmployeeName", MR_Name.Text);
                command.Parameters.AddWithValue("EmployeeSurname", MR_Surname.Text);
                command.Parameters.AddWithValue("Age", MR_Age.Text);
                command.Parameters.AddWithValue("Position", MR_Position.Text);
                command.Parameters.AddWithValue("Salary", MR_Salary.Text);

                int number = command.ExecuteNonQuery();
                MessageBox.Show("Updated objects");
            }
        }
        private void DeleteEmployee_MR(string connectionString, string tablename)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var comand = new SqlCommand($"DELETE  {tablename} WHERE [Id_Marketing]=@Id_Marketing", connection);
                comand.Parameters.AddWithValue("Id_Marketing", MR_Id.Text);
                comand.ExecuteNonQuery();
                MessageBox.Show($"Delete Eployes ");
            }
        }
        private void More_Info_Employee_MR(string connectionString, string tablename)
        {
            var connection = new SqlConnection(connectionString);


            using (connection = new SqlConnection(connectionString))
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    var comand = new SqlCommand($"Select * From {tablename} WHERE [Id_Marketing]=@Id_Marketing", connection);
                    comand.Parameters.AddWithValue("Id_Marketing", MR_Id.Text);

                    var reader = comand.ExecuteReader();
                    listBoxMR_Info.Items.Clear();
                    while (reader.Read())
                    {
                        listBoxMR_Info.Items.Add($"{reader["Id_Marketing"]}.{reader["EmployeeName"]}" +
                             $"   {reader["EmployeeSurname"]}    {reader["Age"]}    {reader["Position"]}    {reader["Salary"]}");
                    }
                }
            }
        }
        //Technical Support
        private void Add_TS_Click(object sender, EventArgs e)
        {
            InsertDbElements_TS(connectionString, "TechnicalSupport");
        }
        private void Update_TS_Click(object sender, EventArgs e)
        {
            UpdateDbElements_TS(connectionString, "TechnicalSupport");
        }
        private void Delete_TS_Click(object sender, EventArgs e)
        {
            DeleteEmployee_TS(connectionString, " TechnicalSupport");
        }
        private void TS_Staff_Click(object sender, EventArgs e)
        {
            var connection = new SqlConnection(connectionString);

            using (connection = new SqlConnection(connectionString))
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Select * From TechnicalSupport";

                    var reader = cmd.ExecuteReader();
                    listBox_TS_Staff.Items.Clear();
                    while (reader.Read())
                    {
                        listBox_TS_Staff.Items.Add($"{reader["Id_TechnicalSupport"]}.{reader["EmployeeName"]}" +
                              $"   {reader["EmployeeSurname"]} ");
                    }
                }
            }
        }
        private void TS_Info_Click(object sender, EventArgs e)
        {
            More_Info_Employee_TS(connectionString, "TechnicalSupport");
        }
        private void InsertDbElements_TS(string connectionString, string tablename)
        {


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                var command = new SqlCommand($"INSERT INTO {tablename} (EmployeeName,EmployeeSurname, Age,Position,Salary) " +
                  $"VALUES (@EmployeeName,@EmployeeSurname,@Age,@Position,@Salary)", connection);
                command.Parameters.AddWithValue("EmployeeName", TS_Name.Text);
                command.Parameters.AddWithValue("EmployeeSurname", TS_Surname.Text);
                command.Parameters.AddWithValue("Age", TS_Age.Text);
                command.Parameters.AddWithValue("Position", TS_Position.Text);
                command.Parameters.AddWithValue("Salary", TS_Salary.Text);

                command.ExecuteNonQuery();
                MessageBox.Show($"Added objects");
            }
        }
        private void UpdateDbElements_TS(string connectionString, string tablename)
        {


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                var command = new SqlCommand($"Update {tablename} Set [EmployeeName] =@EmployeeName ,[EmployeeSurname] = @EmployeeSurname, [Age]=@Age,[Position]=@Position," +
                                             $"[Salary]=@Salary Where [Id_TechnicalSupport]=@Id_TechnicalSupport ", connection);
                command.Parameters.AddWithValue("Id_TechnicalSupport", TS_Id.Text);
                command.Parameters.AddWithValue("EmployeeName", TS_Name.Text);
                command.Parameters.AddWithValue("EmployeeSurname", TS_Surname.Text);
                command.Parameters.AddWithValue("Age", TS_Age.Text);
                command.Parameters.AddWithValue("Position", TS_Position.Text);
                command.Parameters.AddWithValue("Salary", TS_Salary.Text);

                int number = command.ExecuteNonQuery();
                MessageBox.Show("Updated objects");
            }
        }
        private void DeleteEmployee_TS(string connectionString, string tablename)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var comand = new SqlCommand($"DELETE  {tablename} WHERE [Id_TechnicalSupport]=@Id_TechnicalSupport", connection);
                comand.Parameters.AddWithValue("Id_TechnicalSupport", TS_Id.Text);
                comand.ExecuteNonQuery();
                MessageBox.Show($"Delete Eployes ");
            }
        }
        private void More_Info_Employee_TS(string connectionString, string tablename)
        {
            var connection = new SqlConnection(connectionString);


            using (connection = new SqlConnection(connectionString))
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    var comand = new SqlCommand($"Select * From {tablename} WHERE [Id_TechnicalSupport]=@Id_TechnicalSupport", connection);
                    comand.Parameters.AddWithValue("Id_TechnicalSupport", TS_Id.Text);

                    var reader = comand.ExecuteReader();
                    listBox_TS_Info.Items.Clear();
                    while (reader.Read())
                    {
                        listBox_TS_Info.Items.Add($"{reader["Id_TechnicalSupport"]}.{reader["EmployeeName"]}" +
                             $"   {reader["EmployeeSurname"]}    {reader["Age"]}    {reader["Position"]}    {reader["Salary"]}");
                    }
                }
            }
        }

        private void Real_Salary_Click(object sender, EventArgs e)
        {
            Real_Salary1(connectionString, "HumanResources");
        }
        private void Real_Salary1(string connectionString, string tablename)
        {

            using (var connection = new SqlConnection(connectionString))
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                var command = new SqlCommand($"Select SUM(Salary-(Salary/100)*25) From {tablename} ", connection);
                var sum = command.ExecuteScalar();
                MessageBox.Show(Convert.ToString("RealSalary="+sum));
            }
        }

    }
}
