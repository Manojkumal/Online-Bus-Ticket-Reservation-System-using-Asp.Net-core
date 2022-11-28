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
    public partial class Login : System.Web.UI.Page
    {
         #region Global Variable
        SqlConnection connString = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineBusBookingConnectionString"].ToString());
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        private DataSet getUserData()
        {
            DataSet dsGetData = new DataSet();
            SqlCommand sqlCmd = new SqlCommand();
            if(connString.State==ConnectionState.Closed)
            {
                connString.Open();
            }
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@MobileNo", Convert.ToString(txtUserId.Text));
            sqlCmd.Parameters.AddWithValue("@Password",Convert.ToString(txtPassword.Text));
            sqlCmd.CommandText = "ispUserLogin";
            sqlCmd.Connection = connString;
            SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
            sda.Fill(dsGetData);
            return dsGetData;

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DataSet dsLogin = getUserData();
            if(dsLogin.Tables[0].Rows.Count>0)
            {
                Session["UserID"] = Convert.ToInt32(dsLogin.Tables[0].Rows[0]["regId"]);
                Session["FName"] = Convert.ToString(dsLogin.Tables[0].Rows[0]["Fname"]);
                Session["MobileNo"] = Convert.ToString(dsLogin.Tables[0].Rows[0]["Contact"]);
                if(Request.QueryString["BusID"]!=null)
                {
                    Response.Redirect("PassengerDetailsInfo.aspx?BusID=" + Request.QueryString["BusID"] + "&SeatNo=" + Request.QueryString["SeatNo"] + "&TravelDate=" + Request.QueryString["TravelDate"] +
                  "&Origin=" + Request.QueryString["Origin"] + "&Destination=" + Request.QueryString["Destination"] + "&BoardingID=" + Request.QueryString["BoardingID"] + "&Fare=" + Request.QueryString["Fare"]);
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
                
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Credentials Passed,Please check your username and Password')", true); 
            }
        }
    }
}