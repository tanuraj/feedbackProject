using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Threading;

namespace Proj_Feedback
{
    public partial class FeedbackReport : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataInteraction oDal = new DataInteraction();
                DataTable dt = oDal.GetFeedbackDetail();
                DataTable dt1 = oDal.GetFeedbackDetailtest();
                ViewState["dt"] = dt;
                ViewState["dt1"] = dt1;
                if (dt.Rows.Count > 0)
                {
                    BindGrid(GvDetail);

                }
                else
                {
                    GvDetail.EmptyDataText = "No Records Found";
                }

            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        private void BindGrid(GridView gv)
        {
            gv.DataSource = ViewState["dt"];
            gv.DataBind();


        }

        protected void GvDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindGrid(GvDetail);
            GvDetail.PageIndex = e.NewPageIndex;
            GvDetail.DataBind();
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            GenerateExcel((DataTable)ViewState["dt"]);

        }

        public void GenerateExcel(DataTable ds)
        {
            try
            {


                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);


                Panel pnl = new Panel();

                DataTable dtHeader = new DataTable();
                dtHeader.Columns.Add(new DataColumn("Report:"));
                dtHeader.Columns.Add(new DataColumn("Feedback Report"));



                DataRow drEMpty = dtHeader.NewRow();
                drEMpty[0] = "";
                drEMpty[1] = "";
                dtHeader.Rows.Add(drEMpty);

                GridView gvwHeader = new GridView();
                gvwHeader.AutoGenerateColumns = false;
                gvwHeader.BackColor = System.Drawing.Color.LightCyan;
                gvwHeader.HeaderStyle.Font.Bold = true;
                gvwHeader.HeaderStyle.BackColor = System.Drawing.Color.LightBlue;
                gvwHeader.BorderStyle = BorderStyle.Solid;
                gvwHeader.ShowHeader = true;
                gvwHeader.HeaderStyle.Font.Bold = true;
                gvwHeader.RowStyle.Font.Bold = true;
                gvwHeader.BorderWidth = Unit.Point(10);

                foreach (DataColumn dc in dtHeader.Columns)
                {
                    BoundField b = new BoundField();
                    b.DataField = dc.ColumnName;
                    b.HeaderText = dc.ColumnName;
                    b.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    gvwHeader.Columns.Add(b);
                }

                gvwHeader.DataSource = dtHeader;
                gvwHeader.DataBind();

                Literal l = new Literal();
                l.Text = ".";

                GridView GridView1 = new GridView();
                GridView1.AutoGenerateColumns = false;

                foreach (DataColumn dc in ds.Columns)
                {
                    BoundField b = new BoundField();
                    b.DataField = dc.ColumnName;
                    b.HeaderText = dc.ColumnName;
                    GridView1.Columns.Add(b);
                }

                GridView1.DataSource = ds;
                GridView1.DataBind();

                GridView1.GridLines = GridLines.Both;
                gvwHeader.HeaderRow.HorizontalAlign = HorizontalAlign.Left;
                GridView1.HeaderStyle.Font.Bold = true;
                GridView1.HeaderStyle.BackColor = System.Drawing.Color.LightGray;
                GridView1.HeaderStyle.Font.Bold = true;

                foreach (GridViewRow row in GridView1.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {

                            //  "'" + row.Cells[i].;
                            // GridViewRow row=                        grdErrorRecords.Rows[i];
                            row.Cells[i].Attributes.Add("class", "text");
                        }
                    }
                }
                string style = @" .text{ mso-number-format:\@; } ";
                string FileName = "FeedbackReport" + ".xls";

                pnl.Controls.Add(gvwHeader);
                pnl.Controls.Add(new Literal() { Text = "." });
                pnl.Controls.Add(GridView1);

                ExportControlToExcel(pnl, FileName);

            }
            catch (Exception ex)
            {
                //
            }

        }

        public static void ExportControlToExcel(WebControl Control, string FileName)
        {
            try
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Buffer = true;
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ClearHeaders();
                HttpContext.Current.Response.Charset = "";
                StringWriter strwritter = new StringWriter();
                HtmlTextWriter HtmlTextWrtter = new HtmlTextWriter(strwritter);
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                HttpContext.Current.Response.ContentType = "application /ms-excel";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                Control.RenderControl(HtmlTextWrtter);
                string style = @"<style>td{
vertical-align:text-top;
} .number {mso-number-format:\@;text-align:right;} </style>";

                HttpContext.Current.Response.Write(style);
                HttpContext.Current.Response.Write("<style>.text { mso-number-format:\\@; } </style>");
                HttpContext.Current.Response.Write(strwritter.ToString());
                HttpContext.Current.Response.End();

            }
            catch (System.Threading.ThreadAbortException ex)
            { }


        }

        protected void btnForm_Click(object sender, EventArgs e)
        {
            GvDetail.DataSource = null;
            GvDetail.DataBind();
            Response.Redirect("Feedback_Form.aspx");
        }
    }
}

