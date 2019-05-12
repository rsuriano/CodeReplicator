using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeReplicator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "CodeReplicator2019 v1.1 -  The \"Losha joins the party (and SQL)\" Update";
            tableList.DataSource = Classes.SQLConnection.GetTableNames();
            List<string> spList = Classes.SQLConnection.GetSPNames();
            foreach (string SP in spList)
            {
                checkedListBox1.Items.Insert(0, SP);
                dataGridView1.Rows.Add(new object[] {null, SP, null});
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            List<string> selectedSPs = new List<string>();
            List<bool> returnDT = new List<bool>();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(item.Cells[0].Value) == true)
                {
                    selectedSPs.Add(item.Cells[1].Value.ToString());
                    returnDT.Add(Convert.ToBoolean(item.Cells[2].Value));
                }
            }
            FileSpawner fs = new FileSpawner(layerTextbox.Text, tableList.Text, connectionNameTextbox.Text, PathDatasetTextbox.Text, FileNameTextbox.Text, selectedSPs, returnDT);
            label1.Text = fs.PathString;
            richTextBox1.Text = fs.EndGame;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileNameTextbox.Text = "Con_" + tableList.Text;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ( (e.ColumnIndex != 1) && (e.RowIndex >=0 && e.ColumnIndex >=0) )
            {
                dataGridView1[e.ColumnIndex, e.RowIndex].ReadOnly = false;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> SelectedSP = new List<string>();
            SelectedSP.Add("Get");
            SelectedSP.Add("Insert");
            SelectedSP.Add("Get");
            FileSpawner fs = new FileSpawner("Genesis", tableList.Text, SelectedSP);
            fs.EndGame;
        }
    }
}
