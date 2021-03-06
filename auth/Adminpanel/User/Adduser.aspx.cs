using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;  

public partial class auth_Adminpanel_User_Adduser : CrsfBase
{
    UserBL _Userbl = new UserBL();
    NtcaUserOB objntcauser = new NtcaUserOB();
    Project_Variables Pvar = new Project_Variables();
    Commanfuction _commanfucation = new Commanfuction();
   public static string HeaderTitle = string.Empty;
    string LoginUserid;
    int LoginUsertype;
    public static int BrowserTitle = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Header.DataBind();
        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/auth/Adminpanel/login.aspx");
        }
        MyCustomPrincipal m = new MyCustomPrincipal(HttpContext.Current.User.Identity.Name);
        m = (MyCustomPrincipal)HttpContext.Current.User;

        LoginUserid = m.Id;
        LoginUsertype = m.UserType;
        if (!IsPostBack)
        {
          
            Bind_State();
            if (Request.QueryString["uid"] != null)
            {
                Page.Title = "Edit User:NTCA";
                HeaderTitle = "Edit users";
                txtUserName.Enabled = false;
                ddlUsertype.Enabled = false;
                ddlstate.Enabled = false;
                BrowserTitle = 1;
                objntcauser.UserID = Convert.ToInt32(Request.QueryString["uid"].ToString());
                Bind_userDetials(objntcauser);
                btnsave.Text = "Update";

            }
            else
            {
                BrowserTitle = 0;
                Page.Title = "Add User:NTCA"; HeaderTitle = "Add users"; 
            }
            if (LoginUsertype == Convert.ToInt32(Module_ID_Enum.UserType.StateUser) || LoginUsertype == Convert.ToInt32(Module_ID_Enum.UserType.TigerReserveUser))
            {
                ddlUsertype.Items.RemoveAt(1);
            }
            if (Session["UserType"].ToString() == "3")
            {
                ddlUsertype.Items.Remove(ddlUsertype.Items.FindByValue("2"));
                ddlUsertype.Items.Remove(ddlUsertype.Items.FindByValue("3"));

            }
            else
            {
                ddlUsertype.Items.Remove(ddlUsertype.Items.FindByValue("4"));
            }
        }



    }
    bool  CheckDuplicateUser()
    {
        bool UserExist = false;
        if (Request.QueryString["uid"] == null)
        {
            Pvar.dSet = null;
            objntcauser.Action = 1;
            objntcauser.UserName = txtUserName.Text.Trim();
            Pvar.dSet = _commanfucation.UserExistanceCheck(objntcauser);
            if (Pvar.dSet.Tables[0].Rows.Count > 0)
            {
                UserExist = true;
            }

        }
        return UserExist;
    }
    bool MustBeStateUserEntrySingleCheck()
    {
        bool UserExist = false;
        Pvar.dSet = null;
        objntcauser.Action = 2;
        objntcauser.StateID =Convert.ToInt32(ddlstate.SelectedValue);
        Pvar.dSet = _commanfucation.MustBeStateUserEntrySingleCheckds(objntcauser);
        if (Pvar.dSet.Tables[0].Rows.Count > 0)
        {
            UserExist = true;
        }
        return UserExist;
    }
    bool OnlySingleStateUserInParticularState()
    {
        bool UserExist = false;
        Pvar.dSet = null;
        objntcauser.Action = 3;
        objntcauser.StateID = Convert.ToInt32(ddlstate.SelectedValue);
        Pvar.dSet = _commanfucation.OnlySingleStateUserInParticularStateds(objntcauser);
        if (Pvar.dSet.Tables[0].Rows.Count > 0)
        {
            UserExist = true;
        }
        return UserExist;
    }
    void Bind_State()
    {
        objntcauser.UserID = Convert.ToInt32(LoginUserid);
        Pvar.dSet = _commanfucation.StateListByUserAccess(objntcauser);
        ddlstate.DataSource = Pvar.dSet;
        ddlstate.DataTextField = "StateName";
        ddlstate.DataValueField = "id";
        ddlstate.DataBind();
        if (LoginUsertype == 1)
        {
            ddlstate.Items.Insert(0, new ListItem("Select State", "0"));

        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
     // if (Page.IsValid)
      // {

           try
           {

               string hdnblank = ((HiddenField)this.Master.FindControl("hdnblank")).Value;
               string CurrentSessionId = Convert.ToString(Session["AntiForgeryToken"]);

               if (Session["CurrentRequestUrl"] != null && Convert.ToString(Session["CurrentRequestUrl"]).Equals(Convert.ToString(Request.ServerVariables["HTTP_REFERER"])))
               {
                   if (CurrentSessionId == hdnblank)
                   {


                       //if (Page.IsValid)
                       // {
                       LblMSg.Text = string.Empty;
                       LblPincodeMsg.Text = string.Empty;
                       if (Page.IsValid)
                       {
                           if (Request.QueryString["uid"] != null)
                           {
                               if (txtpincode.Text != "000000")
                               {
                                   UpdateUser();
                               }
                               else
                               {
                                   LblPincodeMsg.Text = "Your pincode is not valid!.";
                               }
                           }
                           else
                           {
                               if (txtpincode.Text != "000000")
                               {
                                   if (CheckDuplicateUser() == true)
                                   {
                                       Session["msg"] = "Already exist this UserName in our database.please create new!";
                                       Session["BackUrl"] = "~/Auth/AdminPanel/User/View_Users.aspx?ModuleID=" + Convert.ToInt16(Request.QueryString["ModuleID"]);
                                       Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                                   }
                                   else
                                   {
                                       if (ddlUsertype.SelectedValue == "2")
                                       {
                                           if (MustBeStateUserEntrySingleCheck() == true)
                                           {
                                               LblMSg.Text = "Already StateUser has created please check it!";
                                           }
                                           else
                                           {
                                               functionUserCreate();
                                           }
                                       }
                                       if (ddlUsertype.SelectedValue == "3")
                                       {
                                           if (MustBeStateUserEntrySingleCheck() == false)
                                           {
                                               LblMSg.Text = "Please create first StateUser then other user you can create!";
                                           }
                                           else
                                           {
                                               functionUserCreate();
                                           }
                                       }

                                       if (ddlUsertype.SelectedValue == "4")
                                       {
                                           functionUserCreate();
                                       }
                                   }
                               }
                               else
                               {
                                   LblPincodeMsg.Text = "Your pincode is not valid!.";
                               }
                           }
                       }
                       // }
                   }
               }
           }

           catch
           {
               throw;
           }
                
        //}
    }
    
    
    public void functionUserCreate()
    {
        #region functionStartEnd
        if (Request.QueryString["uid"] != null)
        {
            objntcauser.UserID = Convert.ToInt32(Request.QueryString["uid"].ToString());
        }
        objntcauser.UserName = txtUserName.Text.Trim();
        objntcauser.FirstName = txtfirstname.Text.Trim();
        objntcauser.LastName = txtlastname.Text.Trim();
        objntcauser.Password = hfpwd.Value;
        objntcauser.UserType = Convert.ToInt32(ddlUsertype.SelectedValue);
        objntcauser.EmailID = txtemail.Text;
        objntcauser.Address1 = txtaddress1.Text;
        objntcauser.Address2 = txtaddress2.Text;
        objntcauser.State = Convert.ToInt32(ddlstate.SelectedValue);
        objntcauser.pincode = txtpincode.Text;
        objntcauser.Landline = txtlandlineno.Text;
        objntcauser.AreaCode = txtareacode.Text;
        objntcauser.Mobile = txtmobileno.Text;
        objntcauser.DataOperatorParentUserID = Convert.ToInt32(Session["User_Id"]);
        if (objntcauser.UserID == null)
        {
            int recordcount = _Userbl.AddNewUser(objntcauser);
            if (recordcount > 0)
            {

                Session["msg"] = "Already exist this state of user in our database.please create new!";
            }
            else
            {
                
                if (Request.QueryString["uid"] != null)
                {
                    Session["msg"] = "User has been Updated successfully.";
                }                
                else
                {
                    Session["msg"] = "User has been added successfully.";
                }
            }
        }
        else
        {
            _Userbl.AddNewUser(objntcauser);

            if (Request.QueryString["uid"] != null)
            {
                Session["msg"] = "User has been Updated successfully.";
            }
            else
            {
                Session["msg"] = "User has been added successfully.";
            }
        }
        Session["BackUrl"] = "~/Auth/AdminPanel/User/View_Users.aspx?ModuleID=" + Convert.ToInt16(Request.QueryString["ModuleID"]);
        Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");

        #endregion
    }
    public void UpdateUser()
    {
        #region functionStartEnd    
        objntcauser.UserID = Convert.ToInt32(Request.QueryString["uid"].ToString());       
        objntcauser.UserName = txtUserName.Text.Trim();
        objntcauser.FirstName = txtfirstname.Text.Trim();
        objntcauser.LastName = txtlastname.Text.Trim();
        objntcauser.Password = hfpwd.Value;
        objntcauser.UserType = Convert.ToInt32(ddlUsertype.SelectedValue);
        objntcauser.EmailID = txtemail.Text;
        objntcauser.Address1 = txtaddress1.Text;
        objntcauser.Address2 = txtaddress2.Text;
        objntcauser.State = Convert.ToInt32(ddlstate.SelectedValue);
        objntcauser.pincode = txtpincode.Text;
        objntcauser.Landline = txtlandlineno.Text;
        objntcauser.AreaCode = txtareacode.Text;
        objntcauser.Mobile = txtmobileno.Text;
        objntcauser.DataOperatorParentUserID = Convert.ToInt32(Session["User_Id"]);
        _Userbl.UpdateUsersDal(objntcauser);           
         Session["msg"] = "User has been Updated successfully.";       
        Session["BackUrl"] = "~/Auth/AdminPanel/User/View_Users.aspx?ModuleID=" + Convert.ToInt16(Request.QueryString["ModuleID"]);
        Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
        #endregion
    }
    public void Bind_userDetials(NtcaUserOB obj)
    {
        Pvar.dSet = _Userbl.Get_UserDetials(obj);
        if (Pvar.dSet.Tables[0].Rows.Count > 0)
        {
            txtUserName.Text = Pvar.dSet.Tables[0].Rows[0]["UserName"].ToString().Trim();
            txtfirstname.Text = Pvar.dSet.Tables[0].Rows[0]["FirstName"].ToString().Trim();
            txtlastname.Text = Pvar.dSet.Tables[0].Rows[0]["LastName"].ToString().Trim();
            ddlUsertype.SelectedValue = Pvar.dSet.Tables[0].Rows[0]["UserType"].ToString().Trim();
            txtemail.Text = Pvar.dSet.Tables[0].Rows[0]["EmailID"].ToString().Trim();
            txtaddress1.Text = Pvar.dSet.Tables[0].Rows[0]["Address1"].ToString().Trim();
            txtaddress2.Text = Pvar.dSet.Tables[0].Rows[0]["Address2"].ToString().Trim();
            ddlstate.SelectedValue = Pvar.dSet.Tables[0].Rows[0]["PermissionState"].ToString().Trim();
            txtpincode.Text = Pvar.dSet.Tables[0].Rows[0]["pincode"].ToString().Trim();
            txtareacode.Text = Pvar.dSet.Tables[0].Rows[0]["AreaCode"].ToString().Trim();
            txtlandlineno.Text = Pvar.dSet.Tables[0].Rows[0]["Landline"].ToString().Trim();
            txtmobileno.Text = Pvar.dSet.Tables[0].Rows[0]["Mobile"].ToString().Trim();
        }
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        Bind_State();
        if (Request.QueryString["uid"] != null)
        {
            Page.Title = "Edit User:NTCA";
            HeaderTitle = "Edit users";
            txtUserName.Enabled = false;
            ddlUsertype.Enabled = false;
            ddlstate.Enabled = false;
            objntcauser.UserID = Convert.ToInt32(Request.QueryString["uid"].ToString());
            Bind_userDetials(objntcauser);
            btnsave.Text = "Update";

        }
        else
        {
            Page.Title = "Add User:NTCA"; HeaderTitle = "Add users";
        }
        //if (Request.QueryString["uid"] != null)
        //{
        //    //txtUserName.Text = string.Empty;
        //    txtfirstname.Text = string.Empty;
        //   // ddlUsertype.SelectedIndex = 0;
        //   // ddlstate.SelectedItem.Text = "Select State";
        //    txtemail.Text = string.Empty;
        //    txtaddress1.Text = string.Empty;
        //    txtaddress2.Text = string.Empty;
        //    txtpincode.Text = string.Empty;
        //    txtareacode.Text = string.Empty;
        //    txtlandlineno.Text = string.Empty;
        //    txtmobileno.Text = string.Empty;
        //}
        //else
        //{
        //    txtUserName.Text = string.Empty;
        //    txtfirstname.Text = string.Empty;
        //    ddlUsertype.SelectedIndex = 0;
        //    ddlstate.SelectedItem.Text = "Select State";
        //    txtemail.Text = string.Empty;
        //    txtaddress1.Text = string.Empty;
        //    txtaddress2.Text = string.Empty;
        //    txtpincode.Text = string.Empty;
        //    txtareacode.Text = string.Empty;
        //    txtlandlineno.Text = string.Empty;
        //    txtmobileno.Text = string.Empty;

        //}
    }
}