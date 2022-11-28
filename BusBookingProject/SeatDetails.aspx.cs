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
    public partial class SeatDetails : System.Web.UI.Page
    {
        #region Global Variable
        SqlConnection connString = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineBusBookingConnectionString"].ToString());
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblForm.Text = Convert.ToString(Request.QueryString["Origin"]);
                lblTo.Text = Convert.ToString(Request.QueryString["Destination"]);
                DateTime dtNEw = DateTime.ParseExact(Convert.ToString(Request.QueryString["TravelDate"]), "dd/MM/yyyy", null);
                lbldate.Text = String.Format("{0:ddd,d MMM,yyyy}", dtNEw);
                bingBoardigPoints();
                string bookedSeatNo = "";
                DataTable dt = getBookedSeat();
                foreach (DataRow dr in dt.Rows)
                {
                    bookedSeatNo += Convert.ToString(dr["SeatNo"]) + ",";
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "paramFN1", "getSeatLayout('" + Convert.ToInt32(Request.QueryString["Row"]) + "','" + Convert.ToInt32(Request.QueryString["Column"]) + "','" + bookedSeatNo + "','" + Convert.ToDecimal(Request.QueryString["Fare"]) + "');", true);
            }
        }


        private void bingBoardigPoints()
        {
            DataTable dsGetData = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            if (connString.State == ConnectionState.Closed)
            {
                connString.Open();
            }
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@BusID", Convert.ToInt32(Request.QueryString["BusID"]));
            sqlCmd.CommandText = "ispGetBoardingPoints";
            sqlCmd.Connection = connString;
            SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
            sda.Fill(dsGetData);
            if (dsGetData.Rows.Count > 0)
            {
                dsGetData.Columns.Add(new DataColumn("Value", System.Type.GetType("System.String"), "PlaceName + ' - ' + PlaceTime"));
                ddlBoardingpoints.DataSource = dsGetData;
                ddlBoardingpoints.DataTextField = "Value";
                ddlBoardingpoints.DataValueField = "StandId";
                ddlBoardingpoints.DataBind();
            }
            ddlBoardingpoints.Items.Insert(0, new ListItem("Select Boarding Points", "0"));
        }

        private DataTable getBookedSeat()
        {
            DataTable dt = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            if (connString.State == ConnectionState.Closed)
            {
                connString.Open();
            }
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@BusID", Convert.ToInt32(Request.QueryString["BusID"]));
            sqlCmd.Parameters.AddWithValue("@TravelDate", Convert.ToString(Request.QueryString["TravelDate"]));
            sqlCmd.CommandText = "ispGetBookedSeatNo";
            sqlCmd.Connection = connString;
            SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
            sda.Fill(dt);
            return dt;
        }

        protected void btnPayment_Click(object sender, EventArgs e)
        {
            lblSelectedSeat.Text = Request.Form[hdnSeatNo.UniqueID];
            lblPerSeat.Text = Request.Form[hdnFare.UniqueID];
            if (Session["UserID"] != null)
            {
                Response.Redirect("PassengerDetailsInfo.aspx?BusID=" + Request.QueryString["BusID"] + "&SeatNo=" + lblSelectedSeat.Text + "&TravelDate=" + Request.QueryString["TravelDate"] +
                "&Origin=" + Request.QueryString["Origin"] + "&Destination=" + Request.QueryString["Destination"] + "&BoardingID=" + ddlBoardingpoints.SelectedValue + "&Fare=" + lblPerSeat.Text);
            }
            else
            {
                Response.Redirect("Login.aspx?BusID=" + Request.QueryString["BusID"] + "&SeatNo=" + lblSelectedSeat.Text + "&TravelDate=" + Request.QueryString["TravelDate"] +
                "&Origin=" + Request.QueryString["Origin"] + "&Destination=" + Request.QueryString["Destination"] + "&BoardingID=" + ddlBoardingpoints.SelectedValue + "&Fare=" + lblPerSeat.Text);
            }

        }
    }
}