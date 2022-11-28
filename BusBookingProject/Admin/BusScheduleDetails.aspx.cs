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
    public partial class BusScheduleDetails : System.Web.UI.Page
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

        private int addBusScheduleData()
        {
            int ResultCout = 0;
            SqlCommand sqlCmd = new SqlCommand();
            if (connString.State == ConnectionState.Closed)
            {
                connString.Open();
            }
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Date", Convert.ToString(txtDate.Text));
            sqlCmd.Parameters.AddWithValue("@BusID", Convert.ToInt32(Request.QueryString["BusID"]));
            sqlCmd.Parameters.AddWithValue("@Fare", Convert.ToDecimal(txtFare.Text));
            sqlCmd.Parameters.AddWithValue("@EstimatdTime", Convert.ToString(txtTravelTime.Text));
            sqlCmd.Parameters.AddWithValue("@ArrivalTime", Convert.ToString(txtArrival.Text));
            sqlCmd.Parameters.AddWithValue("@DepartureTime", Convert.ToString(txtDeparture.Text));
            sqlCmd.Parameters.AddWithValue("@RouteID", Convert.ToInt32(Request.QueryString["RouteID"]));
            sqlCmd.CommandText = "ispAddBusSchedule";
            sqlCmd.Connection = connString;
            ResultCout = sqlCmd.ExecuteNonQuery(); ;
            return ResultCout;
        }
        protected void btnSaveSchedule_Click(object sender, EventArgs e)
        {
            int result = addBusScheduleData();
            if (result == -1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bus Schedule Details has been added successfully')", true);
                txtDeparture.Text = "";
                txtDate.Text = "";
                txtArrival.Text = "";
                txtFare.Text = "";
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error occur please contact your system administrator')", true);
            }
        }
    }
}