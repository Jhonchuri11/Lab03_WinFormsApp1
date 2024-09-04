using System.Data;
using System.Data.SqlClient;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)

        // Para usar dataTable
        {
            try
            {
                // probando cadena de conexion
                string cadena = "Server=DEV\\SQLEXPRESS; Database=Lab03DB; Integrated Security=True";

                SqlConnection conextion = new SqlConnection(cadena);

                // Abriendo conexion
                conextion.Open();

                SqlCommand command = new SqlCommand("Select * from Students", conextion);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;

               // MessageBox.Show("Conexion exitosa");


            }
            catch (Exception)
            {
                MessageBox.Show("Error de conexion");
                throw;
            }
        }

        // Para usar Data Reade

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // probando cadena de conexion
                string cadena = "Server=DEV\\SQLEXPRESS; Database=Lab03DB; Integrated Security=True";

                SqlConnection conextion = new SqlConnection(cadena);

                // Abriendo conexion
                conextion.Open();

                SqlCommand command = new SqlCommand("Select * from Students", conextion);

                List<Student> listStudents = new List<Student>();

                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    conextion.Close();

                    Student student = new Student();
                    student.StudentId = Convert.ToInt32(reader["studentid"]);
                    student.FirstName = reader["firstname"].ToString();
                    student.LastName = reader["Llastname"].ToString();
                    listStudents.Add(student);
                }

                dataGridView1.DataSource = listStudents;

            } catch (Exception)
            {
                MessageBox.Show("Error de conexion");
                throw;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
