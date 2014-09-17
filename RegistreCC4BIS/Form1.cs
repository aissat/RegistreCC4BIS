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
using System.Reflection;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

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
			FillRedacteur();
			FillCommun();
			dateTimePicker1.Enabled = false;
			dateTimePicker2.Enabled = false;
			dateTimePicker3.Enabled = false;
			dateTimePicker4.Enabled = false;
		   // dataGridView1.Visible = false;
			radioButton1.Checked = false;
			radioButton2.Checked = false;
			radioButton3.Checked = false;
			btnAjuter.Enabled = false;
			btnModifier.Enabled = false;
			btnSupp.Enabled = false;
			btnPdf.Visible = false;
		 //   groupBox4.Visible = false;
		   
			
		
		}
		private void InitInterface()
		{
			txtNumIlot.Clear();
			txtNumordre.Clear();
			txtNumLivrejuurnal.Clear();
			txtNumLot.Clear();
			txtNumSection.Clear();
			txtNvxIlot.Clear();
			txtProprInscrit.Clear();
			comboBox1.Text = "";
			comboBox2.Text = "";
			dateTimePicker1.ResetText();
			dateTimePicker2.ResetText();
			dateTimePicker3.ResetText();
			dateTimePicker3.ResetText();
		}

	  
		private void FillCommun()
		{
			Cn.Open();
			OleDbCommand command = new OleDbCommand();
			command.Connection = Cn;
			string query = "select * from TableCom ";
			command.CommandText = query;
			OleDbDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				comboBox1.Items.Add(reader["Commune"].ToString());
			}
			Cn.Close();
		}
		private void FillRedacteur()
		{
			Cn.Open();
			OleDbCommand command = new OleDbCommand();
			command.Connection = Cn;
			string query = "select * from TableRedact ";
			command.CommandText = query;
			OleDbDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				comboBox2.Items.Add(reader["Le_Rédacteur_acte"].ToString());
			}
			Cn.Close();
		}
		void FillDatagridView()
		{
			Dt.Clear();
			Da = new OleDbDataAdapter("Select * From TableReg", Cn);
			Da.Fill(Dt);
			dataGridView1.DataSource = Dt;
		}
		
		private void button1_Click(object sender, EventArgs e)
		{
			string a,a1,a2,a3 ;
		   
			a = a1 = a2 = a3 = "NULL";
			
			if (checkBox1.Checked == true)
			{
				a = "'" + dateTimePicker1.Value.ToString() + "'";
			}
			 if (checkBox2.Checked == true)
			{
				a1 = "'" + dateTimePicker2.Value.ToString() + "'";

			}
			 if (checkBox3.Checked == true)
			{
				a2 = "'" + dateTimePicker3.Value.ToString() + "'";

			}
			 if (checkBox4.Checked == true)
			{
				a3 = "'" + dateTimePicker4.Value.ToString()+"'";

			}
			try
			{
				Cmd = new OleDbCommand("Insert Into TableReg (Commune,NumSection,NumIlot,NvxIlot,NumLot,PropriétaireInscrit,Redacteur,NumLivre,DateEdition,DateRéception,DateApplication,DateRemise) Values('" + comboBox1.Text + "', " + Convert.ToInt32(txtNumSection.Text) + ", " + Convert.ToInt32(txtNumIlot.Text) + "," + Convert.ToInt32(txtNvxIlot.Text) + ", " + Convert.ToInt32(txtNumLot.Text) + ",'" + txtProprInscrit.Text + "','" + comboBox2.Text + "'," + Convert.ToInt32(txtNumLivrejuurnal.Text) + ","+a+" ," +a1+ "," +a2+ "," + a3 + ")", Cn);
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
			//btnAjuter.Click += 
			button4_Click(sender, e);
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{

				Cmd = new OleDbCommand("Update TableReg Set Commune='" + comboBox1.Text + "',NumSection=" + Convert.ToInt32(txtNumSection.Text) + ",NumIlot=" + Convert.ToInt32(txtNumIlot.Text) + ",NvxIlot=" + Convert.ToInt32(txtNvxIlot.Text) + ",NumLot=" + Convert.ToInt32(txtNumLot.Text) + ",PropriétaireInscrit='" + txtProprInscrit.Text + "',Redacteur='" + comboBox2.Text + "',NumLivre=" + Convert.ToInt32(txtNumLivrejuurnal.Text) + ",DateEdition='" + dateTimePicker1.Value + "',DateRéception='" + dateTimePicker2.Value + "',DateApplication='" + dateTimePicker3.Value + "',DateRemise='" + dateTimePicker4.Value + "' where NumOrdre=" + Convert.ToInt32(txtNumordre.Text) + " ", Cn);
				Cn.Open();
				Cmd.ExecuteNonQuery();
				Cn.Close();
				MessageBox.Show("updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
				InitInterface();
			}
			catch (OleDbException err)
			{
				MessageBox.Show(err.Message, "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			} 
		}

		private void button3_Click(object sender, EventArgs e)
		{
			try
			{

				Cmd = new OleDbCommand("Delete From TableReg WHERE NumOrdre= " + Convert.ToInt32(txtNumordre.Text) + " ", Cn);
				Cn.Open();
				Cmd.ExecuteNonQuery();
				FillDatagridView();
				Cn.Close();
				MessageBox.Show("Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
				InitInterface();
			}
			catch (OleDbException err)
			{
				MessageBox.Show(err.Message, "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			} 

		}

	  

		

		private void button7_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void fichierToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void button4_Click(object sender, EventArgs e)
		{
			dataGridView1.Visible = true;
			btnPdf.Visible = true;
			FillDatagridView();
		}
		

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			txtNumordre.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
			comboBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
			txtNumSection.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
			txtNumIlot.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
			txtNvxIlot.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
			txtNumLot.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
			txtProprInscrit.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
			comboBox2.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
			txtNumLivrejuurnal.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
			dateTimePicker1.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString();
			dateTimePicker2.Text = this.dataGridView1.CurrentRow.Cells[10].Value.ToString();
			dateTimePicker3.Text = this.dataGridView1.CurrentRow.Cells[11].Value.ToString();
			dateTimePicker4.Text = this.dataGridView1.CurrentRow.Cells[12].Value.ToString();
			dateTimePicker3.Enabled = true;
			dateTimePicker4.Enabled = true;

		}

		private void txtNumordre_TextChanged(object sender, EventArgs e)
		{

		}

		private void radioButton1_Click(object sender, EventArgs e)
		{
			
			
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton1.Checked == true) { btnAjuter.Enabled = true; txtNumordre.Enabled = false; }
			else { btnAjuter.Enabled = false; txtNumordre.Enabled = true; }
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton2.Checked == true) { btnModifier.Enabled = true;  }
			else { btnModifier.Enabled = false; }
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton3.Checked == true) { btnSupp.Enabled = true; }
			else { btnSupp.Enabled = false; }

		}

		private void chercherToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//groupBox4.Visible = true;
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			
		   
		  
		}

		private void toolStripStatusLabel1_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
			PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Test.pdf", FileMode.Create));
			doc.Open();

			//Creating iTextSharp Table from the DataTable data
			PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);

			
			for (int j = 0; j < dataGridView1.Columns.Count;j++ )
			{
				pdfTable.AddCell(new Phrase(dataGridView1.Columns[j].HeaderText));
			}
			pdfTable.HeaderRows = 1;
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				for (int k = 0; k < dataGridView1.Columns.Count; k++) 
				{
					if (dataGridView1[k, i].Value != null )
					{
						pdfTable.AddCell(new Phrase(dataGridView1[k,i].Value.ToString()));

					}
				}
			}
			doc.Add(pdfTable);
			doc.Close();
			System.Diagnostics.Process.Start("C:\\Users\\User\\Desktop\\RegistreCC4BIS-master\\RegistreCC4BIS-master\\RegistreCC4BIS\\bin\\Debug\\Test.pdf");
		}

		public string k { get; set; }

		public int i { get; set; }

	   

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked == true) { dateTimePicker1.Enabled = true; }
			else dateTimePicker1.Enabled = false;
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox2.Checked == true) { dateTimePicker2.Enabled = true; }
			else dateTimePicker2.Enabled = false;
		}

		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox3.Checked == true) { dateTimePicker3.Enabled = true; }
			else dateTimePicker3.Enabled = false;
		}

		private void checkBox4_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox4.Checked == true) { dateTimePicker4.Enabled = true; }
			else dateTimePicker4.Enabled = false;
		}
	}
}
