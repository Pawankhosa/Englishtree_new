using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;
using System.Globalization;
using System.Data;
public partial class Auth_inquiry : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    Helper help = new Helper();
    public static string inquiry = "", formatdate,next;
    public static TimeZoneInfo INDIAN_ZONE;
    public DateTime indianTime = new DateTime();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            DateFormat();
            bind();
            inquiry= GenerateInquiry();
            if (Request.QueryString["id"] != null)
            {
                Binddata();
            }
        }
       
       
    }
    protected void bind()
    {
       // help.BindDropDownList("select * from course", "coursename", "courseid", ddlcourse);
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        
        using (TransactionScope ts = new TransactionScope())
        {
            if (Request.QueryString["id"] != null)
            {
                int i = objsql.ExecuteNonQuery1("update tblinquiry set name='" + txtname.Text + "',fname='" + txtfname.Text + "',contact='" + txtcontact.Text + "',address='" + txtaddress.Text
                   + "',referedBy='" + txtref.Text + "',course='" + ddlcourse.SelectedItem.Value + "' where inquiryid='"+Request.QueryString["id"]+"' ");
                if (i > 0)
                {
                    // objsql.ExecuteNonQuery("update FranchiseeDetails Set inquiryid='" + txtInquiry.Text + "' where UniqueCode='" + Code + "' ");

                    Page.RegisterStartupScript("kk", "<script language = JavaScript>alert('Inquiry Updated Successfully..')</script>");
                }
                else
                {
                    Page.RegisterStartupScript("kk", "<script language = JavaScript>alert('Inquiry Not Updated ..')</script>");
                }
                if (ddltype.SelectedItem.Text == "Days")
                {


                    next = System.DateTime.Now.AddDays(Convert.ToInt32(txtdays.Text)).ToString("MM/dd/yyyy");
                }

                objsql.ExecuteNonQuery("update tblfeedback set feedback='" + txtfeed.Text + "',days='" + txtdays.Text + "',type='" + ddltype.SelectedItem.Text + "',nextfollow='" + next + "',status='" + ddlstatus.SelectedItem.Text + "' where inquiryid='" + Request.QueryString["id"] + "' ");
            }
            else
            {
                int i = objsql.ExecuteNonQuery1("insert into tblinquiry (inquiryid,name,fname,contact,address,referedBy,course,date,centercode,status) values('" + inquiry + "','" + txtname.Text + "','" + txtfname.Text + "','" + txtcontact.Text + "','" + txtaddress.Text
                    + "','" + txtref.Text + "','" + ddlcourse.SelectedItem.Value + "','" + formatdate + "','" + Session["code"] + "','1')");
                if (i > 0)
                {
                    // objsql.ExecuteNonQuery("update FranchiseeDetails Set inquiryid='" + txtInquiry.Text + "' where UniqueCode='" + Code + "' ");

                    Page.RegisterStartupScript("kk", "<script language = JavaScript>alert('Inquiry Saved Successfully..')</script>");
                }
                else
                {
                    Page.RegisterStartupScript("kk", "<script language = JavaScript>alert('Inquiry Not Saved ..')</script>");
                }
                if (ddltype.SelectedItem.Text == "Days")
                {


                    next = System.DateTime.Now.AddDays(Convert.ToInt32(txtdays.Text)).ToString("MM/dd/yyyy");
                }

                objsql.ExecuteNonQuery("insert into tblfeedback (inquiryid,date,feedback,days,type,nextfollow,status) values ('" + inquiry + "','" + formatdate + "','" + txtfeed.Text + "','" + txtdays.Text + "','" + ddltype.SelectedItem.Text + "','" + next + "','" + ddlstatus.SelectedItem.Text + "')");
            }
            ts.Complete();
            clear();
            ts.Dispose();
        }
        Response.Redirect("Inquiry-List.aspx");
    }

    private void DateFormat()
    {
        INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
        formatdate = indianTime.ToString("MM/dd/yyyy");

        txtdate.Text = indianTime.ToString("dd/MM/yyyy");
        //DateTime date = new DateTime();
        //date = DateTime.ParseExact(txtdate.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //formatdate = date.ToString("MM/dd/yyyy");
    }
    protected void clear()
    {
        txtname.Text = "";
        txtfname.Text = "";
        txtaddress.Text = "";
        txtfeed.Text = "";
        txtcontact.Text = "";
        ddlcourse.SelectedIndex = 0;
        txtref.Text = "";
        ddltype.SelectedIndex = 0;
        txtdays.Text = "";
        
    }
    protected string GenerateInquiry()
    {
        string LeadNo = "";

        string id = objsql.GetSingleValue("select max(id) from tblinquiry ").ToString();
        if (id == "")
        {
            return "I_101";
        }
        else
        {
            LeadNo = objsql.GetSingleValue("select inquiryid from tblinquiry where id=" + id).ToString();
            Int64 oldlead = Convert.ToInt64(LeadNo.Replace("I_", "0"));
            oldlead += 1;

            return "I_" + oldlead.ToString();

        }




    }

    public void Binddata()
    {
        DataTable dt = new DataTable();
        dt = objsql.GetTable("select i.inquiryid,i.name,i.fname,i.contact,i.address,i.referedby,i.date,i.course,i.CenterCode,f.status,f.feedback,f.days,f.type,f.nextfollow from tblinquiry i  join tblfeedback f on i.inquiryid=f.inquiryid and i.inquiryid='" + Request.QueryString["id"] + "'");
        if(dt.Rows.Count>0)
        {
            txtdate.Text = dt.Rows[0]["date"].ToString();
            txtaddress.Text= dt.Rows[0]["address"].ToString();
            txtcontact.Text= dt.Rows[0]["contact"].ToString();
            txtdays.Text=dt.Rows[0]["days"].ToString();
            txtfeed.Text= dt.Rows[0]["feedback"].ToString();
            txtfname.Text= dt.Rows[0]["fname"].ToString();
            txtname.Text= dt.Rows[0]["name"].ToString();
            txtref.Text= dt.Rows[0]["referedBy"].ToString();
            ddlcourse.SelectedItem.Text= dt.Rows[0]["course"].ToString();
            ddlstatus.SelectedItem.Text= dt.Rows[0]["status"].ToString();
            ddltype.SelectedItem.Text= dt.Rows[0]["type"].ToString();

        }
    }

}