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
    public partial class Classes : Form
    {
        public Classes()
        {
            InitializeComponent();
        }

        private void classBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            //***ERROR HANDLING***
            try
            {
                this.Validate();
                this.classBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.rockoDBDataSet);
            }
            catch (DataException ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
                classBindingSource.CancelEdit();
            }//end tryCatch

        }//end save method

        private void Classes_Load(object sender, EventArgs e)
        {
            //***ERROR HANDLING***
            try
            {
                this.classTableAdapter.Fill(this.rockoDBDataSet.Class);
            }
            catch (Exception ex)
            {
                //error string
                string errorMessage = "An error occurred when populating the data from the Class Table. \n" + "Error: " + ex.Message;

                //showing the message
                MessageBox.Show(errorMessage, "Database Error");

            }//end tryCatch

        }

        
        //event handler for button click to return home
        private void btnHomeC_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form homeForm = new Form1();
            homeForm.Show();
        }//end return home method

    }//end class
}//end namespace
