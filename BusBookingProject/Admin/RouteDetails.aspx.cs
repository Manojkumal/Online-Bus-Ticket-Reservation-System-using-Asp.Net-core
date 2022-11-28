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
    
    public partial class RouteDetails : System.Web.UI.Page
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
                    bindBoardingDetails();
                }
                else
                {
                    Response.Write("AdminLogin.aspx");
                }
            }
        }

        private void bindBoardingDetails()
        {
            DataSet dsGetData = new DataSet();
            SqlCommand sqlCmd = new SqlCommand();
            if (connString.State == ConnectionState.Closed)
            {
                connString.Open();
            }
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "ispGetRouteDetails";
            sqlCmd.Connection = connString;
            SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
            sda.Fill(dsGetData);
            if (dsGetData.Tables[0].Rows.Count > 0)
            {
                gdRouteDetails.DataSource = dsGetData.Tables[0];
                gdRouteDetails.DataBind();
            }
            else
            {
                gdRouteDetails.DataSource = null;
                gdRouteDetails.EmptyDataText = "No Records Found";
                gdRouteDetails.DataBind();
            }
        }
        protected void gdRouteDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink klnikUpdate = (HyperLink)e.Row.FindControl("hlinkBoarding");
                HiddenField hdnBusID = (HiddenField)e.Row.FindControl("hdnBusID");
                HiddenField hdnRouteID = (HiddenField)e.Row.FindControl("hdnRouteID");
                klnikUpdate.NavigateUrl = "BoardingDetails.aspx?BusID=" + hdnBusID.Value + "&RouteID=" + hdnRouteID.Value;
            }
        }
    }
}