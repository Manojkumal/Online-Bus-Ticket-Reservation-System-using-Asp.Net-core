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
    public partial class BusDetails : System.Web.UI.Page
    {
        #region Global Variable
        SqlConnection connString = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineBusBookingConnectionString"].ToString());
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["UserName"]!=null)
                {
                    if(Request.QueryString["BusID"]!=null)
                    {
                        int BusID = Convert.ToInt32(Request.QueryString["BusID"]);
                        FillData(BusID);
                        btnSave.Text = "Update";
                    }
                    else
                    {
                        btnSave.Text="Insert";
                    }
                }
                else
                {
                    Response.Redirect("AdminLogin.aspx");
                }
            }
        }

        private int UpdateData()
        {
            int ResultCout = 0;
            SqlCommand sqlCmd = new SqlCommand();
            if (connString.State == ConnectionState.Closed)
            {
                connString.Open();
            }
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@BusID", Convert.ToInt32(Request.QueryString["BusID"]));
            sqlCmd.Parameters.AddWithValue("@BusNo", Convert.ToString(txtBusNo.Text));
            sqlCmd.Parameters.AddWithValue("@BusName", Convert.ToString(txtBusName.Text));
            sqlCmd.Parameters.AddWithValue("@BusType", Convert.ToString(ddlBusType.SelectedItem.Text));
            sqlCmd.Parameters.AddWithValue("@seatColumn", Convert.ToInt32(txtSeatColumn.Text));
            sqlCmd.Parameters.AddWithValue("@SeatRow", Convert.ToInt32(txtSeatRows.Text));
            sqlCmd.Parameters.AddWithValue("@Origin", Convert.ToString(txtOrigin.Text));
            sqlCmd.Parameters.AddWithValue("@Destination", Convert.ToString(txtDetination.Text));
            sqlCmd.CommandText = "ispUpdateBusData";
            sqlCmd.Connection = connString;
            ResultCout = sqlCmd.ExecuteNonQuery(); ;
            return ResultCout;
        }
        private void FillData(int BusID)
        {
            DataSet dsGetData = new DataSet();
            SqlCommand sqlCmd = new SqlCommand();
            if (connString.State == ConnectionState.Closed)
            {
                connString.Open();
            }
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@BusID", BusID);
            sqlCmd.CommandText = "ispGetBusDataByBusID";
            sqlCmd.Connection = connString;
            SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
            sda.Fill(dsGetData);
            if(dsGetData.Tables[0].Rows.Count>0)
            {
                txtBusName.Text = Convert.ToString(dsGetData.Tables[0].Rows[0]["BusName"]);
                txtBusNo.Text = Convert.ToString(dsGetData.Tables[0].Rows[0]["BusNo"]);
                ddlBusType.SelectedItem.Text = Convert.ToString(dsGetData.Tables[0].Rows[0]["BustType"]);
                txtSeatRows.Text = Convert.ToString(dsGetData.Tables[0].Rows[0]["SeatRow"]);
                txtSeatColumn.Text = Convert.ToString(dsGetData.Tables[0].Rows[0]["SeatColumn"]);
                txtOrigin.Text = Convert.ToString(dsGetData.Tables[0].Rows[0]["Origin"]);
                txtDetination.Text = Convert.ToString(dsGetData.Tables[0].Rows[0]["Destination"]);
            }
        }
        private int AddBusDetails()
        {
            int ResultCout = 0;
            SqlCommand sqlCmd = new SqlCommand();
            if (connString.State == ConnectionState.Closed)
            {
                connString.Open();
            }
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@BusNo", Convert.ToString(txtBusNo.Text));
            sqlCmd.Parameters.AddWithValue("@BusName", Convert.ToString(txtBusName.Text));
            sqlCmd.Parameters.AddWithValue("@BustType", Convert.ToString(ddlBusType.SelectedItem.Text));
            sqlCmd.Parameters.AddWithValue("@SeatColumn", Convert.ToInt32(txtSeatColumn.Text));
            sqlCmd.Parameters.AddWithValue("@SeatRow", Convert.ToInt32(txtSeatRows.Text));
            sqlCmd.Parameters.AddWithValue("@Origin", Convert.ToString(txtOrigin.Text));
            sqlCmd.Parameters.AddWithValue("@Destination", Convert.ToString(txtDetination.Text));
            sqlCmd.CommandText = "ispAddBusDetails";
            sqlCmd.Connection = connString;
            ResultCout = sqlCmd.ExecuteNonQuery(); ;
            return ResultCout;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
           if(btnSave.Text=="Insert")
           {
               int result = AddBusDetails();
               if (result == -1)
               {
                   ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bus Details has been added successfully')", true);
                   txtDetination.Text = "";
                   ddlBusType.SelectedValue = "0";
                   txtOrigin.Text = "";
                   txtBusNo.Text = "";
                   txtSeatColumn.Text = "";
                   txtSeatRows.Text = "";
                   txtBusName.Text = "";
               }
               else
               {
                   ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error occur please contact your system administrator')", true);
               }
           }
           else
           {
               int result = UpdateData();
               if (result == -1)
               {
                   Response.Redirect("BusDetailsReport.aspx");
                   //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bus Details has been Updated successfully')", true);
               }
               else
               {
                   ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Updation Failed please contact your system administrator')", true);
               }
           }
            
          
        }
    }
}