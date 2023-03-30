using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_point_of_sales1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public double cost_of_Items()
        {
            Double sum = 0;
           
            for (int i = 0; i <(dataGridView1.Rows.Count); i++)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
            }
            return sum;
        }
        private void AddCost()
        {
            Double tax, q;
            tax = 0.3;
            if (dataGridView1.Rows.Count>0)
            {
                lblTax.Text = String.Format("{0:c2}",(((cost_of_Items()*tax)/100)));
                lblSubtotal.Text= String.Format("{0:c2}", (cost_of_Items() ));
                q = ((cost_of_Items() * tax) / 100);
                lblTotal.Text = String.Format("{0:c2}", (cost_of_Items() + q));
                lblBarCode.Text = Convert.ToString(q + cost_of_Items());
            }
          
        }
        private void Change()
        {
            Double tax, q, c;
            tax = 0.3;
            if (dataGridView1.Rows.Count > 0)
            {
                q = (((cost_of_Items() * tax) / 100)+cost_of_Items());
                c = Convert.ToInt32(lblCash.Text);
                lblChange.Text= String.Format("{0:c2}",c-q);


            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
        Bitmap bitmap;
        private void button38_Click(object sender, EventArgs e)
        {
            try {
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount* dataGridView1.RowTemplate.Height*2;
            bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0,dataGridView1.Width, dataGridView1.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            dataGridView1.Height = height;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            try
            {
                lblBarCode.Text = "";
                lblCash.Text = "";
                lblChange.Text = "";
                lblSubtotal.Text = "";
                lblTax.Text = "";
                lblTotal.Text = "";
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                cboPayment.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                e.Graphics.DrawImage(bitmap, 0, 0);

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboPayment.Items.Add("Cash");
            cboPayment.Items.Add("visa Cart");
            cboPayment.Items.Add("Master Card");

        }

        private void NumbersOnly(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (lblCash.Text=="")
            {
                lblCash.Text = "";
                lblCash.Text = b.Text;
            }
            else if (b.Text==".")
            {
                if (!lblCash.Text.Contains("."))
                {
                    lblCash.Text = lblCash.Text + b.Text;
                }

            }
            else
            {
                lblCash.Text = lblCash.Text + b.Text;
            }
          

        }

        private void button12_Click(object sender, EventArgs e)
        {
            lblCash.Text = "0";
        }

        private void Pay_Click(object sender, EventArgs e)
        {

            if (cboPayment.Text=="Cash")
            {
                Change();
            }else
            {
                lblChange.Text = "";
                lblCash.Text = "0";
            }

        }

        private void Remove_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
            AddCost();
            if (cboPayment.Text == "Cash")
            {
                Change();
            }
            else
            {
                lblChange.Text = "";
                lblCash.Text = "0";
            }
        }

        private void btn_1(object sender, EventArgs e)
        {
            Double CostofItem = 4.3;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value= "chickens_1"))
                {
                    row.Cells[1].Value = Double.Parse((String)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((String)row.Cells[1].Value ) * CostofItem;
                }
        
            }
            dataGridView1.Rows.Add("chickens_1", "1", CostofItem);
            AddCost();
        }

        private void btn_2(object sender, EventArgs e)
        {
               Double CostofItem = 4.3;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value= "chickens_1"))
                {
                    row.Cells[1].Value = Double.Parse((String)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((String)row.Cells[1].Value ) * CostofItem;
                }
             
            }
            dataGridView1.Rows.Add("chickens_1", "1", CostofItem);
            AddCost();
        }

        private void btn_3(object sender, EventArgs e)
        {
            Double CostofItem = 3.5;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "chickens_3"))
                {
                    row.Cells[1].Value = Double.Parse((String)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((String)row.Cells[1].Value) * CostofItem;
                }
     
            }
            dataGridView1.Rows.Add("chickens_3", "1", CostofItem);
            AddCost();
        }

        private void btn_4(object sender, EventArgs e)
        {
            Double CostofItem = 2.2;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "hamburger"))
                {
                    row.Cells[1].Value = Double.Parse((String)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((String)row.Cells[1].Value) * CostofItem;
                }
              
            }
            dataGridView1.Rows.Add("hamburger", "1", CostofItem);
            AddCost();
        }

        private void btn_5(object sender, EventArgs e)
        {
            Double CostofItem = 3.3;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "chickens_4"))
                {
                    row.Cells[1].Value = Double.Parse((String)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((String)row.Cells[1].Value) * CostofItem;
                }
        
            }
            dataGridView1.Rows.Add("chickens_4", "1", CostofItem);
            AddCost();
        }

        private void btn_6(object sender, EventArgs e)
        {
            Double CostofItem = 1.4;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "chickens_5"))
                {
                    row.Cells[1].Value = Double.Parse((String)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((String)row.Cells[1].Value) * CostofItem;
                }
               
            }
            dataGridView1.Rows.Add("chickens_5", "1", CostofItem);
            AddCost();
        }

        private void btn_7(object sender, EventArgs e)
        {
            Double CostofItem = 2.2;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "chickens_6"))
                {
                    row.Cells[1].Value = Double.Parse((String)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((String)row.Cells[1].Value) * CostofItem;
                }
    
            }
            dataGridView1.Rows.Add("chickens_6", "1", CostofItem);
            AddCost();
        }

        private void btn_8(object sender, EventArgs e)
        {
            Double CostofItem = 1.6;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "hamburger_2"))
                {
                    row.Cells[1].Value = Double.Parse((String)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((String)row.Cells[1].Value) * CostofItem;
                }
             
            }
            dataGridView1.Rows.Add("hamburger_2", "1", CostofItem);
            AddCost();
        }

        private void btn_9(object sender, EventArgs e)
        {
            Double CostofItem = 0.8;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "hamburger_3"))
                {
                    row.Cells[1].Value = Double.Parse((String)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((String)row.Cells[1].Value) * CostofItem;
                }
      
            }
            dataGridView1.Rows.Add("hamburger_3", "1", CostofItem);
            AddCost();
        }

        private void btn_10(object sender, EventArgs e)
        {
            Double CostofItem = 1.5;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "potato"))
                {
                    row.Cells[1].Value = Double.Parse((String)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((String)row.Cells[1].Value) * CostofItem;
                }

            }
            dataGridView1.Rows.Add("potato", "1", CostofItem);
            AddCost();
        }

        private void btn_11(object sender, EventArgs e)
        {
            Double CostofItem =0.7;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "chickens_7"))
                {
                    row.Cells[1].Value = Double.Parse((String)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((String)row.Cells[1].Value) * CostofItem;
                }

            }
            dataGridView1.Rows.Add("chickens_7", "1", CostofItem);
            AddCost();
        }

        private void btn_12(object sender, EventArgs e)
        {
            Double CostofItem = 2.1;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "chickens_8"))
                {
                    row.Cells[1].Value = Double.Parse((String)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((String)row.Cells[1].Value) * CostofItem;
                }

            }
            dataGridView1.Rows.Add("chickens_8", "1", CostofItem);
            AddCost();
        }

        private void lblTax_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_13(object sender, EventArgs e)
        {
            Double CostofItem =2.4;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "chickens_9"))
                {
                    row.Cells[1].Value = Double.Parse((String)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((String)row.Cells[1].Value) * CostofItem;
                }

            }
            dataGridView1.Rows.Add("chickens_9", "1", CostofItem);
            AddCost();
        }

        private void btn_14(object sender, EventArgs e)
        {
            Double CostofItem = 1.1;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "chickens_10"))
                {
                    row.Cells[1].Value = Double.Parse((String)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((String)row.Cells[1].Value) * CostofItem;
                }

            }
            dataGridView1.Rows.Add("chickens_10", "1", CostofItem);
            AddCost();
        }

        private void btn_15(object sender, EventArgs e)
        {
            Double CostofItem = 0.8;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "tomato"))
                {
                    row.Cells[1].Value = Double.Parse((String)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((String)row.Cells[1].Value) * CostofItem;
                }

            }
            dataGridView1.Rows.Add("tomato", "1", CostofItem);
            AddCost();
        }

        private void btn_16(object sender, EventArgs e)
        {
            Double CostofItem = 2.1;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "chickens_11"))
                {
                    row.Cells[1].Value = Double.Parse((String)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((String)row.Cells[1].Value) * CostofItem;
                }

            }
            dataGridView1.Rows.Add("chickens_11", "1", CostofItem);
            AddCost();
        }
    }
    }


