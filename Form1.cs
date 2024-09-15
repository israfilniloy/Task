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

namespace CrudOperation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=NILOY\\SQLEXPRESS02;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into UserTab values(@ID,@Name,@Age)", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Age", double.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Successfully Saved");

        }

        private void button2_Click(object sender, EventArgs e)
        {
          SqlConnection con = new SqlConnection("Data Source=NILOY\\SQLEXPRESS02;Integrated Security=True");
                con.Open();

                SqlCommand cmd = new SqlCommand("UPDATE UserTab SET Name=@Name, Age=@Age WHERE ID=@ID", con);

                cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Age", double.Parse(textBox3.Text));

                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Successfully Updated");
                }
                else
                {
                    MessageBox.Show("Update Failed. Record Not Found.");
                }
            }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=NILOY\\SQLEXPRESS02;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM UserTab WHERE ID=@ID", con);

            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));

            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Successfully Deleted");
            }
            else
            {
                MessageBox.Show("Delete Failed. Record Not Found.");
            }
        }
    }
}