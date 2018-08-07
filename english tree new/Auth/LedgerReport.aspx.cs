using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_LedgerReport : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public static string Code = "", id = "", Rep_Name = "", Date = "";
    public double Total = 0.00;
    public DataTable dtexpense = new DataTable();
    public DataTable dtstdfees = new DataTable();
    public DataTable dtoCharge = new DataTable();
    public DataTable dtlpu = new DataTable();
    public DataTable dtNew1 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFromDate.Attributes.Add("readonly", "readonly");
            txtToDate.Attributes.Add("readonly", "readonly");
        }
    }
    protected void BtnLoadReport_Click(object sender, EventArgs e)
    {
        bindReport();
    }
    protected void bindReport()
    {
        string fromdate = "";
        string todate = "";
        string[] alldatevalues = new string[3];
      
        if (txtFromDate.Text != "")
        {
            alldatevalues = txtFromDate.Text.Split("/".ToCharArray());
        }

        if (alldatevalues.Length >= 3)
        {
            fromdate = alldatevalues[1].Trim() + "/" + alldatevalues[0].Trim() + "/" + alldatevalues[2].Trim();
        }
        if (txtToDate.Text != "")
        {
            alldatevalues = txtToDate.Text.Split("/".ToCharArray());
        }

        if (alldatevalues.Length >= 3)
        {
            todate = alldatevalues[1].Trim() + "/" + alldatevalues[0].Trim() + "/" + alldatevalues[2].Trim();
        }


        if (txtFromDate.Text != "" && txtToDate.Text != "")
        {
            
            dtstdfees = objsql.GetTable("Select rd.TokenNo,rd.Date,sf.TodayPaidFee,sf.CourseId,sf.Rollno,sd.name,cc.CourseName From Recipt_Details rd join Student_Fee sf on sf.Token=rd.TokenNo join  tblstudentdata sd on sd.rollno=sf.RollNo join Course cc on cc.CourseId=sf.CourseId and convert(datetime, rd.[Date], 120) >= " + "convert(datetime, '" + fromdate + "', 120) and convert(datetime, rd.[Date], 120) <= " + "convert(datetime, '" + todate + "', 120) and sf.TodayPaidFee!='0' order by sf.CourseId");
            if (dtstdfees.Rows.Count > 0)
            {
                gridPaymentinfo.DataSource = dtstdfees;
                gridPaymentinfo.DataBind();
            }

        }

        //gridPaymentinfo.DataSource = dtstdfees;
        //gridPaymentinfo.DataBind();
     
        //Total = totalIncome - total_expense;
    }
  

    protected void btnExporttoexcel_Click(object sender, EventArgs e)
    {

        bindReport();
        DataSet dsreg = new DataSet("table");
        dsreg.Tables.Add(dtNew1);

        string filenam = "filename.xls";

        Response.Clear();
        Response.ClearContent();
        Response.ContentType = "application/excel";
        Response.AppendHeader("content-disposition", "attachment; filename=Registrantslist_" + filenam);

        gridPaymentinfo.AllowSorting = false;
        gridPaymentinfo.AllowPaging = false;

        gridPaymentinfo.DataSource = dtNew1;
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);


        gridPaymentinfo.DataBind();
        gridPaymentinfo.RenderControl(hw);

        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    protected void gridPaymentinfo_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) ||
             (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            string[] alldatevalues = new string[3];
            Label lbldate = (Label)e.Item.FindControl("lbldate");
            if (lbldate.Text != "")
            {
                alldatevalues = lbldate.Text.Split("/".ToCharArray());
            }

            if (lbldate.Text.Length >= 3)
            {
                lbldate.Text = alldatevalues[1].Trim() + "/" + alldatevalues[0].Trim() + "/" + alldatevalues[2].Trim();
            }

            Label lblpaid = (Label)e.Item.FindControl("lblpaid");
            if (lblpaid.Text != null)
            {
                Total += Convert.ToDouble(lblpaid.Text);
            }
        }
    }
}