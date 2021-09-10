using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_EditProfile : System.Web.UI.Page
{
    UserBL _Userbl = new UserBL();
    NtcaUserOB objntcauser = new NtcaUserOB();
    Project_Variables Pvar = new Project_Variables();
    Commanfuction _commanfucation = new Commanfuction();
    string LoginUserid;
    int LoginUsertype;
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Header.DataBind();
        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/auth/Adminpanel/login.aspx");
        }
        MyCustomPrincipal m = new MyCustomPrincipal(HttpContext.Current.User.Identity.Name);
        m = (MyCustomPrincipal)HttpContext.Current.User;
        if (!IsPostBack)
        {
            BindProfile();
        }
    }
    void BindProfile()
    {
      
        Pvar.dSet = null;
        objntcauser.UserID = Convert.ToInt32(Session["User_Id"]);
        objntcauser.Action = 1;
        Pvar.dSet = _commanfucation.BindProfile(objntcauser);
        if (Pvar.dSet.Tables[0].Rows.Count > 0)
        {
            TxtUsername.Text = Pvar.dSet.Tables[0].Rows[0]["UserName"].ToString();
            TxtUsername.Enabled = false;
            TxtEmail.Text = Pvar.dSet.Tables[0].Rows[0]["EmailID"].ToString();
            TxtMobile.Text = Pvar.dSet.Tables[0].Rows[0]["Mobile"].ToString();
            TxtFName.Text = Pvar.dSet.Tables[0].Rows[0]["FirstName"].ToString();
            TxtLastName.Text = Pvar.dSet.Tables[0].Rows[0]["LastName"].ToString();
            TxtAddress1.Text = Pvar.dSet.Tables[0].Rows[0]["Address1"].ToString();
            TxtAddress2.Text = Pvar.dSet.Tables[0].Rows[0]["Address2"].ToString();
            TxtPincode.Text = Pvar.dSet.Tables[0].Rows[0]["pincode"].ToString();
            TxtLandline.Text = Pvar.dSet.Tables[0].Rows[0]["Landline"].ToString();
            TxtAreaCode.Text = Pvar.dSet.Tables[0].Rows[0]["AreaCode"].ToString().Trim();
        }
    }
   
    protected void btnupdate_Click(object sender, EventArgs e)
    { 
        LblPincodeMsg.Text = string.Empty;
        if (Page.IsValid)
        {
            //if (TxtPincode.Text != "0000")
            //{
                objntcauser.UserID = Convert.ToInt32(Session["User_Id"]);

                //objntcauser.UserName = txtUserName.Text.Trim();
                objntcauser.FirstName = TxtFName.Text.Trim();
                objntcauser.LastName = TxtLastName.Text.Trim();


                objntcauser.EmailID = TxtEmail.Text.Trim();
                objntcauser.Address1 = TxtAddress1.Text.Trim();
                objntcauser.Address2 = TxtAddress2.Text.Trim();

                objntcauser.pincode = TxtPincode.Text.Trim();
                objntcauser.Landline = TxtLandline.Text.Trim();
                objntcauser.AreaCode = TxtAreaCode.Text.Trim(); 
                objntcauser.Mobile = TxtMobile.Text.Trim();
                objntcauser.Action = 2;
                int recordcount = _Userbl.UpdateProfile(objntcauser);
                if (recordcount > 0)
                {

                    Session["msg"] = "User profile has been Updated successfully.";
                    Session["BackUrl"] = "~/Auth/AdminPanel/EditProfile.aspx";
                    Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                }
           // }
            //else
            //{
            //    LblPincodeMsg.Text = "Your pincode is not valid!.";
            //}
        }

    }
   void Reset()
    {

        TxtEmail.Text = string.Empty;
        TxtFName.Text = string.Empty;
        TxtMobile.Text = string.Empty;
        TxtLandline.Text = string.Empty;
        TxtAddress1.Text = string.Empty;
        TxtAddress2.Text = string.Empty;
        TxtPincode.Text = string.Empty;
        TxtAreaCode.Text = string.Empty;
    }
   protected void BtnReset_Click(object sender, EventArgs e)
   {
       BindProfile();
   }
}