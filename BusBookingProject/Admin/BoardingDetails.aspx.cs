using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusBookingProject.Admin
{
    public partial class BoardingDetails : System.Web.UI.Page
    {
        #region Global Variable
        SqlConnection connString = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineBusBookingConnectionString"].ToString());
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["UserName"] !=null)
                {

                }
                else
                {
                    Response.Redirect("AdminLogin.aspx");
                }
            }
        }

        private int AddBoardingDetails()
        {
            int ResultCout = 0;
            SqlCommand sqlCmd = new SqlCommand();
            if (connString.State == ConnectionState.Closed)
            {
                connString.Open();
            }
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@RouteID", Convert.ToInt32(Request.QueryString["RouteID"]));
            sqlCmd.Parameters.AddWithValue("@PlaceName", Convert.ToString(txtPlace.Text));
            sqlCmd.Parameters.AddWithValue("@PlaceTime", Convert.ToString(txtArrival.Text));
            sqlCmd.Parameters.AddWithValue("@BusID", Convert.ToInt32(Request.QueryString["BusID"]));
            sqlCmd.CommandText = "addBordingDetails";
            sqlCmd.Connection = connString;
            ResultCout = sqlCmd.ExecuteNonQuery(); ;
            return ResultCout;
        }
        protected void btnAddBoardingDetails_Click(object sender, EventArgs e)
        {
            int result = AddBoardingDetails();
            if (result == -1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Boarding Details has been added successfully')", true);
                txtArrival.Text = "";
                txtPlace.Text = "";
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error occur please contact your system administrator')", true);
            }
        }
    }
}