using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusBookingProject
{
    public partial class BookingReport : System.Web.UI.Page
    {
        #region Global Variable
        SqlConnection connString = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineBusBookingConnectionString"].ToString());
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["UserID"]!=null)
                {
                    bindPnrDetails();
                    //Request.QueryString["Message"] = "";
                    if (Request.QueryString["Msg"] != null)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + Convert.ToString(Request.QueryString["Msg"]) + "')", true);
                        PropertyInfo isreadonly =
                         typeof(System.Collections.Specialized.NameValueCollection).GetProperty(
                         "IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                        // make collection editable
                        isreadonly.SetValue(this.Request.QueryString, false, null);
                        // remove
                        this.Request.QueryString.Clear();
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }


        private void bindPnrDetails()
        {
            DataSet dsGetData = new DataSet();
            SqlCommand sqlCmd = new SqlCommand();
            if (connString.State == ConnectionState.Closed)
            {
                connString.Open();
            }
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@UserID",Convert.ToInt32(Session["UserID"]));
            sqlCmd.CommandText = "ispGetPNRDetails";
            sqlCmd.Connection = connString;
            SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
            sda.Fill(dsGetData);
            if (dsGetData.Tables != null)
            {
                gdTicketReport.DataSource = dsGetData.Tables[0];
                gdTicketReport.DataBind();
            }
            else
            {
                gdTicketReport.DataSource = null;
                gdTicketReport.EmptyDataText = "No Records Found";
                gdTicketReport.DataBind();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /*Tell the compiler that the control is rendered
             * explicitly by overriding the VerifyRenderingInServerForm event.*/
        }

        private void printTicket(string transactionNo)
        {
            ticket.Visible = true;
            DataSet dsGetData = new DataSet();
            SqlCommand sqlCmd = new SqlCommand();
            if (connString.State == ConnectionState.Closed)
            {
                connString.Open();
            }
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@PNRNo", transactionNo);
            sqlCmd.CommandText = "GetPassengerDetails";
            sqlCmd.Connection = connString;
            SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
            sda.Fill(dsGetData);
            gdPaxDetails.DataSource = dsGetData.Tables[0];
            gdPaxDetails.DataBind();
            lblTransactionNo.Text = Convert.ToString(dsGetData.Tables[1].Rows[0]["PNRNo"]);
            lblBusName.Text = Convert.ToString(dsGetData.Tables[1].Rows[0]["BusName"]);
            //lblDepartureTime.Text = Convert.ToString(dsGetData.Tables[1].Rows[0]["DeptTime"]);
            lblTotalAmount.Text = Convert.ToString(dsGetData.Tables[1].Rows[0]["Amount"]);
            lblTotalTickets.Text = Convert.ToString(dsGetData.Tables[1].Rows[0]["TotalTickets"]);
                        using (StringWriter sw = new StringWriter())
                        {
                            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                            {
                                StringBuilder sb = new StringBuilder();
                                //generate header
                                //export html string as a pdf
                                ticket.RenderControl(hw);
                                //tbtPNR.RenderControl(hw);
                                // gdPaxDetails.RenderControl(hw);
                                StringReader sr = new StringReader(sw.ToString());
                                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0);
                                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                                pdfDoc.Open();
                                pdfDoc.NewPage();
                                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                                pdfDoc.Close();
                                Response.ContentType = "application/pdf";
                                Response.AddHeader("content-disposition", "attachement;filename=Ticket" + ".pdf");
                                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                                Response.Write(pdfDoc);
                                Response.End();
                            }
                        }

                    }
        

        protected void gdTicketReport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download Ticket")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gdTicketReport.Rows[index];
                printTicket(row.Cells[1].Text);
            }
        }
    }
}