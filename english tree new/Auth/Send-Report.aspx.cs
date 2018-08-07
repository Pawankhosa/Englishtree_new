using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using iTextSharp.text.html.simpleparser;

public partial class Auth_Send_Report : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public static DataTable dt = new DataTable();
    public static string email;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            bind();
        }
    }
    protected void bind()
    {
       // objsql.BindDropDownList2("select * from schooldetail", "schoolname", "id",ddlschool);
       // objsql.BindDropDownList2("select * from tblclass", "class", "id", ddlclass);
      
        
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        //select date, totalstudent,present,absent,name as Lesson ,excellent,vgood,good,average,discription,remarks from tblclasswise where school='"+ddlschool.SelectedItem.Value+"' and class='"+ddlclass.SelectedItem.Text+"' and section='"+ddlsection.SelectedItem.Text+"' and date ='"+txtdate.Text+"'
        dt = objsql.GetTable("select distinct class from tblclasswise where school='"+ddlschool.SelectedItem.Value+"' and date ='"+txtdate.Text+"'");
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
            // email = Common.Get(objsql.GetSingleValue("select email from schooldetail where id='" + ddlschool.SelectedItem.Value + "'"));
           // if (email != "")
           // {
               
           // }
        }

     
    }
    private void SendPDFEmail(DataTable dt)
    {
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                //foreach (ListViewItem gg in GridView1.Items)
                //{

                    //string companyName = ddlsection.SelectedItem.Text;
                    //string orderNo = ddlclass.SelectedItem.Text;
                    //StringBuilder sb = new StringBuilder();
                    //sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                    //sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>" + ddlschool.SelectedItem.Text + "</b></td></tr>");
                    //sb.Append("<tr><td colspan = '2'></td></tr>");
                    //sb.Append("<tr><td><b>Class:</b>");
                    //sb.Append(orderNo);
                    //sb.Append("</td><td><b>Date: </b>");
                    //sb.Append(txtdate.Text);
                    //sb.Append(" </td></tr>");
                    //sb.Append("<tr><td colspan = '2'><b>Section :</b> ");
                    //sb.Append(companyName);
                    //sb.Append("</td></tr>");
                    //sb.Append("</table>");
                    //sb.Append("<br />");
                    //sb.Append("<table border = '1'>");
                    //sb.Append("<tr>");
                    //foreach (DataColumn column in dt.Columns)
                    //{
                    //    sb.Append("<th style = 'background-color: #D20B0C;color:#ffffff'>");
                    //    sb.Append(column.ColumnName);
                    //    sb.Append("</th>");
                    //}
                    //sb.Append("</tr>");
                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    sb.Append("<tr>");
                    //    foreach (DataColumn column in dt.Columns)
                    //    {
                    //        sb.Append("<td>");
                    //        sb.Append(row[column]);
                    //        sb.Append("</td>");
                    //    }
                    //    sb.Append("</tr>");
                    //}
                    //sb.Append("</table>");
                    //StringReader sr = new StringReader(sb.ToString());

                    //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    //using (MemoryStream memoryStream = new MemoryStream())
                    //{
                    //    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                    //    pdfDoc.Open();
                    //    htmlparser.Parse(sr);
                    //    pdfDoc.Close();
                    //    byte[] bytes = memoryStream.ToArray();
                    //    memoryStream.Close();

                    //    MailMessage mm = new MailMessage(email, email);

                    //    mm.Subject = "Class Wise Report";
                    //    mm.Body = "PDF Attachment";
                    //    mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "Report.pdf"));
                    //    mm.IsBodyHtml = true;
                    //    SmtpClient smtp = new SmtpClient();
                    //    smtp.Host = "smtp.gmail.com";
                    //    smtp.EnableSsl = true;
                    //    NetworkCredential NetworkCred = new NetworkCredential("offsolut@gmail.com", "passiong");
                    //    smtp.UseDefaultCredentials = true;
                    //    smtp.Credentials = NetworkCred;

                    //    smtp.Port = 587;
                    //    smtp.Send(mm);
                    //}
                GridView1.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                MailMessage mm = new MailMessage("offsolut@gmail.com", email);
                mm.Subject = "Report";
                mm.Body = "Daily Report:<hr />" + sw.ToString(); ;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "offsolut@gmail.com";
                NetworkCred.Password = "passiong";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
                }
           // }
        }
    }
    protected void btnemail_Click(object sender, EventArgs e)
    {
        SendPDFEmail(dt);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Send Email Sucessfully')", true);

        dt.Clear();
    }
    protected void GridView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            Label id = (Label)e.Item.FindControl("lblclass");
            GridView gr = (GridView)e.Item.FindControl("GridView2");
            dt = objsql.GetTable("select date, totalstudent,present,absent,name as Lesson ,excellent,vgood,good,average,discription,remarks from tblclasswise where class='" + id.Text + "'");
            if (dt.Rows.Count > 0)
            {
                gr.DataSource = dt;
                gr.DataBind();
            }
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
}