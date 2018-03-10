using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RockosGym
{
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
        }

        private void staffBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            //***ERROR HANDLING***
            try
            {
                this.Validate();
                this.staffBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.rockoDBDataSet);
            }
            catch (DataException ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
                staffBindingSource.CancelEdit();
            }//end tryCatch

        }//end save method

        private void Staff_Load(object sender, EventArgs e)
        {
            //***ERROR HANDLING***
            try
            {
                this.staffTableAdapter.Fill(this.rockoDBDataSet.Staff);
            }catch (Exception ex)
            {
                //error message
                string errorMessage = "An error occurred when populating the data from the Staff Table. \n" + "Error: " + ex.Message;

                //show in a dialog box
                MessageBox.Show(errorMessage, "Database Error");
            }//end tryCATCH

        }//end load

        //***ERROR HANDLING***
        private void propertyDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            int row = e.RowIndex + 1;
            string errorMessage = "A data error occurred.\n" + "Row: " + row + "\n" + "Error: " + e.Exception.Message;
            MessageBox.Show(errorMessage, "Data Error");

        }//end error method


        //event handler for return to home
        private void btnHomeS_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form homeForm = new Form1();
            homeForm.Show();
        }//end click home return

    }//end class
}//end name
