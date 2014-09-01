using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace RegistreCC4BIS
{
    public partial class Form1 : Form
    {

        OleDbConnection Cn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Registre.mdb");
        OleDbDataAdapter Da;
        DataTable Dt = new DataTable();
        OleDbCommand Cmd;
        public Form1()
        {



            InitializeComponent();
         
            dateTimePicker3.Enabled = false;

            dateTimePicker4.Enabled = false;
        
        }
        private void InitInterface()
        {
            txtNumIlot.Clear();
            txtNumLivrejuurnal.Clear();
            txtNumLot.Clear();
            txtNumSection.Clear();
            txtNvxIlot.Clear();
            txtProprInscrit.Clear();
            comboBox1.Refresh();
            comboBox2.Refresh();
            dateTimePicker1.Refresh();
            dateTimePicker2.Refresh();
            dateTimePicker3.Refresh();
            dateTimePicker3.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                /*
                Cmd = new OleDbCommand("Insert Into Table_Reg Values('" + comboBox1.Text + "', " + Convert.ToInt32(txtNumSection.Text) + ", " + Convert.ToInt32(txtNumIlot.Text) + "," + Convert.ToInt32(txtNvxIlot.Text) + ", " + Convert.ToInt32(txtNumLot.Text) + ",'" + txtProprInscrit.Text + "','" + comboBox2.Text + "'," + Convert.ToInt32(txtNumLivrejuurnal.Text) + ",'" + dateTimePicker1.ToString() + "',,'" + dateTimePicker2.ToString() + "',,'" + dateTimePicker3.ToString() + "',,'" + dateTimePicker4.ToString() + "')", Cn);
                 Cn.Open();
                 Cmd.ExecuteNonQuery();
                 Cn.Close();

                 MessageBox.Show("Added Successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 InitInterface();
                 */
                //
                //Cmd = new OleDbCommand("Insert Into Table_Reg (NumOrdre,Commune,NumSection,NumIlot,NvxIlot,NumLot,PropriétaireInscrit,Redacteur,NumLivre,DateEdition,DateRéception,DateApplication,DateRemise) Values(10,'ssat', 2, 30,5, 52,'abdou','google',25,'02/07/1989','2/2/2014','2/3/2014','3/3/2014')", Cn);

                Cmd = new OleDbCommand("Insert Into Table_Reg  Values(0,'ssat', 2, 30,5, 52,'abdou','google',25,'02/07/1989','2/2/2014','2/3/2014','3/3/2014')", Cn);
                Cn.Open();
                Cmd.ExecuteNonQuery();
                Cn.Close();
                MessageBox.Show("Added Successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                InitInterface();
            }
            catch (OleDbException err)
            {
                MessageBox.Show(err.Message, "Add", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* try
             {
                 Cmd = new OleDbCommand("Update Table1 Set  gggggggggggg='" + textBox2.Text + "', vvvvvvvvvvvvvvv='" + textBox3.Text + "',zzzz='" + textBox4.Text + "',dfddd='" + textBox5.Text + "' where hhhhhhhhhh='" + textBox1.Text + "'", Cn);
                 Cn.Open();
                 Cmd.ExecuteNonQuery();
                 Cn.Close();
                 FillDatagridView();
                 MessageBox.Show("Edited Successfully", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);

             }
             catch
             {
                 MessageBox.Show("Please select the student to Edit from list !", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }
             */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /* try
             {

                 Cmd = new OleDbCommand("Delete From Table1 WHERE hhhhhhhhhh='" + textBox1.Text + "'", Cn);
                 Cn.Open();
                 Cmd.ExecuteNonQuery();
                 Cn.Close();
                 FillDatagridView();
                 MessageBox.Show("Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             catch
             {
                 MessageBox.Show("Please select the student to delete from list !", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }
         }
             */

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dateTimePicker3.Enabled = true;
            button5.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dateTimePicker4.Enabled = true;
            button6.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fichierToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
