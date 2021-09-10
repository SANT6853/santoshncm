using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

public partial class feedback : BasePage
{
    UserBL _Userbl = new UserBL();
    NtcaUserOB objntcauser = new NtcaUserOB();
    Project_Variables Pvar = new Project_Variables();
    Commanfuction _commanfucation = new Commanfuction();
    ContentOB contentObject = new ContentOB();
    FeedBackBL objfeedBackBL = new FeedBackBL();
    string LoginUserid;
    int LoginUsertype;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            Page.Title = "Feedback:NTCA";
            Bind_State();
        }
    }
    void Bind_State()
    {
        objntcauser.UserID = Convert.ToInt32(LoginUserid);
        Pvar.dSet = _commanfucation.StateListByUserAccess(objntcauser);
        ddlstate.DataSource = Pvar.dSet;
        ddlstate.DataTextField = "StateName";
        ddlstate.DataValueField = "id";
        ddlstate.DataBind();
       
            ddlstate.Items.Insert(0, new ListItem("Select State", "0"));

    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        LblMsg.Text = "";
        if (Page.IsValid)
        {
            recaptcha.ValidateCaptcha(txtcaptcha.Text);
            if (recaptcha.UserValidated)
            {
                string hostName = Dns.GetHostName();
                string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();  

                contentObject.Name = HttpUtility.HtmlEncode(TxtName.Text.Trim());
                contentObject.EmailID = HttpUtility.HtmlEncode(TxtEmail.Text.Trim());
                contentObject.Phone = HttpUtility.HtmlEncode(TxtPhone.Text.Trim());
               // contentObject.Address = HttpUtility.HtmlEncode(TxtAddress.Text.Trim());
                contentObject.Address = HttpUtility.HtmlEncode(TxtAddress.InnerText.Trim());
                contentObject.StateID = Convert.ToInt32(ddlstate.SelectedValue);
                contentObject.StateName = ddlstate.SelectedItem.Text;
               // contentObject.details = HttpUtility.HtmlEncode(TxtMessage.Text.Trim());
                contentObject.details = HttpUtility.HtmlEncode(TxtMessage.InnerText.Trim());
                contentObject.IpAddress = myIP;
                contentObject.ModuleID = Convert.ToInt16(Module_ID_Enum.Project_Module_ID.FeedBackNTCA);
                contentObject.FeedBackFrom = Convert.ToInt32(DdlFeedBackFrom.SelectedValue);
                int insertdata = objfeedBackBL.insertFeedBack(contentObject);
                if (insertdata > 0)
                {
                    Response.Redirect("~/FeedBackThankYou.aspx");
                }


            }
            else
            {
                LblMsg.Text = "Entered captcha code is incorrect!.";
              //  Response.Write("<script>alert('Entered captcha code is incorrect!!');</script>");
            }
        }
    }

}