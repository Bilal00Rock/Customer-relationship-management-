using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace CRMFinalProject
{
    public partial class CustomersForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
(
   int nLeftRect,     // x-coordinate of upper-left corner
   int nTopRect,      // y-coordinate of upper-left corner
   int nRightRect,    // x-coordinate of lower-right corner
   int nBottomRect,   // y-coordinate of lower-right corner
   int nWidthEllipse, // width of ellipse
   int nHeightEllipse // height of ellipse
);
        public CustomersForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }
        
        CustomerBLL bll = new CustomerBLL();
        int index;
        int id;
        void FillDataGrid()
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = bll.Read();
            dataGridViewX1.Columns["آیدی"].Visible = false;
            id = 0;//raf bug intekhab ghabli
        }
        void ClearTextBox()
        {
            id = 0;//raf bug intekhab ghabli
            textBoxX1.Text = "";
            textBoxX2.Text = "";
            textBoxX4.Text = "";

        }
        private void CustomersForm_Load(object sender, EventArgs e)
        {
            FillDataGrid();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Customer c = new Customer();
            c.Name = textBoxX1.Text;
            c.PhoneNumber = textBoxX2.Text;
            c.RegDate = DateTime.Now;
            if (label3.Text == "ثبت اطلاعات")
            {
                MessageBox.Show(bll.Create(c));
            }
            else
            {
                MessageBox.Show(bll.Update(id, c));
                label3.Text = "ثبت اطلاعات";
            }
            ClearTextBox();
            FillDataGrid();
        }
        
        private void textBoxX4_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked || !(checkBox1.Checked) && !(checkBox2.Checked))
            {
                index = 0;
            }
            else if (checkBox1.Checked)
            {
                index = 1;
            }
            else if (checkBox2.Checked)
            {
                index = 2;
            }
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = bll.Read(textBoxX4.Text , index);

        }

        

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            try //raf bug click ja khali 
            {

                id = Convert.ToInt32(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells["آیدی"].Value);
            }
            catch (Exception)
            {

            }
        }
        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == 0)//raf bug id intekhab nashode
            {
                MessageBox.Show("کاربر را انتخاب کنید!");
            }
            else
            {

                 Customer c = bll.Read(id);
                textBoxX1.Text = c.Name;
                textBoxX2.Text = c.PhoneNumber;
                label3.Text = "ویرایش اطلاعات";
            }
        }

        private void حدفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == 0)//raf bug id intekhab nashode
            {
                MessageBox.Show("کاربر را انتخاب کنید!");
            }
            else
            {
                Customer c = bll.Read(id);
                DialogResult dr = MessageBox.Show("آیا از حذف مشتری " + c.Name + " اطمینان دارید؟", "اخطار", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                   MessageBox.Show(bll.Delete(id));
                    FillDataGrid();
                }
            }
            
        }
    }
}
