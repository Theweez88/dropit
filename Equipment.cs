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
    public partial class Equipment : Form
    {
        public Equipment()
        {
            InitializeComponent();
        }

        private void equipmentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            //***ERROR HANDLING***
            try
            {
                this.Validate();
                this.equipmentBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.rockoDBDataSet);
            }
            catch (DataException ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
                equipmentBindingSource.CancelEdit();
            }//end tryCatch

        }//end save click event

        private void Equipment_Load(object sender, EventArgs e)
        {
            //***ERROR HANDLING***
            try
            {
                this.equipmentTableAdapter.Fill(this.rockoDBDataSet.Equipment);
            }
            catch (Exception ex)
            {
                //error string
                string errorMessage = "An error occurred when populating the data from the Equipment Table. \n" + "Error: " + ex.Message;

                //showing the message
                MessageBox.Show(errorMessage, "Database Error");

            }//end tryCatch

        }

       
        //event handler for return to home screen
        private void btnHomeE_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form homeForm = new Form1();
            homeForm.Show();
        }//end return home method

    }//end class
}//end name
