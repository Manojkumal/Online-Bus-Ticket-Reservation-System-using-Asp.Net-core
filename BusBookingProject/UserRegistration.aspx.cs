using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusBookingProject
{
    public partial class UserRegistration : System.Web.UI.Page
    {
        #region Global Variable
        SqlConnection connString = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineBusBookingConnectionString"].ToString());
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }
      
        private int Regitration()
        {
            try
            {
                int ResultCout = 0;
                SqlCommand sqlCmd = new SqlCommand();
                if (connString.State == ConnectionState.Closed)
                {
                    connString.Open();
                }
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@FName", Convert.ToString(txtFirstName.Text));
                sqlCmd.Parameters.AddWithValue("@LName", Convert.ToString(txtLastName.Text));
                sqlCmd.Parameters.AddWithValue("@EmailId", Convert.ToString(txtEmailID.Text));
                sqlCmd.Parameters.AddWithValue("@Address", Convert.ToString(txtAddress.Text));
                sqlCmd.Parameters.AddWithValue("@City", Convert.ToString(txtCity.Text));
                sqlCmd.Parameters.AddWithValue("@PinCode", Convert.ToString(txtPincode.Text));
                sqlCmd.Parameters.AddWithValue("@ContactNo", Convert.ToString(txtMobileNo.Text));
                sqlCmd.Parameters.AddWithValue("@Password", Convert.ToString(txtPassword.Text));
                sqlCmd.Parameters.AddWithValue("@Ret_Val", SqlDbType.BigInt);
                sqlCmd.Parameters["@Ret_Val"].Direction = ParameterDirection.Output;
                sqlCmd.CommandText = "ispUserRegistration";
                sqlCmd.Connection = connString;
                sqlCmd.ExecuteNonQuery();
                ResultCout = Convert.ToInt32(sqlCmd.Parameters["@Ret_Val"].Value);
                return ResultCout;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int RegistrationStatuis = 0;
            RegistrationStatuis = Regitration();
            if(RegistrationStatuis>0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User Registration has been done successfully')", true); 
            }
            else if(RegistrationStatuis==-1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Mobile No already exist please try with another mobile no')", true); 
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error Occur Please contact your system Administrator')", true); 
            }
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAddress.Text = "";
            txtMobileNo.Text = "";
            txtPincode.Text = "";
            txtCity.Text = "";
            txtPassword.Text = "";
            txtEmailID.Text = "";
        }
    }
}