using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_User_View_Users : CrsfBase
{
    UserBL _userBl = new UserBL();
    UserBL _Userbl = new UserBL();
    NtcaUserOB objntcauser = new NtcaUserOB();
    NtcaUserOB _objNtcauser = new NtcaUserOB();
    Project_Variables P_var = new Project_Variables();
    Commanfuction _commanfuction = new Commanfuction();
     
    string LoginUserid;
    int LoginUsertype;

    protected void Page_Load(object sender, EventArgs e)
    {
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
            Bind_state();
           
            Bind_grid(); 
            
        }

    }

    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_grid();
    }

    void Bind_grid()
    {
        LblMsg.Text = string.Empty;
        _objNtcauser.StateID = ddlstate.SelectedValue == "0" ? null : (int?)Convert.ToInt32(ddlstate.SelectedValue);

        P_var.dSet = _userBl.Get_UserList(_objNtcauser);
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            grduser.DataSource = P_var.dSet;
            grduser.DataBind();
        }
        else
        {
            grduser.DataSource = null;
            grduser.DataBind();
            //Response.Write("<script>alert('No Record is found!.');</script>");
            LblMsg.Text = "No Record is found!.";
            LblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }

    void Bind_state()
    {

        // objContentOB.LangID = 1;
        // P_var.dSet = obj_ContentBl.getStateName(objContentOB);
        _objNtcauser.UserID = Convert.ToInt32(LoginUserid);
        P_var.dSet = _commanfuction.StateListByUserAccess(_objNtcauser);
        ddlstate.DataSource = P_var.dSet;
        ddlstate.DataTextField = "StateName";
        ddlstate.DataValueField = "id";
        ddlstate.DataBind();
        if (LoginUsertype == 1)
        {
            ddlstate.Items.Insert(0, new ListItem("Select State", "0"));
        }

    }
    protected void grduser_RowDataBound(object sender, GridViewRowEventArgs e)
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

                    if (Page.IsValid)
                    {
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            //naren7june
                            GridViewRow grv = (GridViewRow)e.Row;

                            HiddenField lbl1 = (HiddenField)grv.FindControl("Hyd");
                            if (lbl1.Value == "Data entry operator user")
                            {
                                e.Row.Cells[0].Text = "Deputy Director/DFO user";
                            }
                            //
                            if (Session["UserType"].ToString() == "2" || Session["UserType"].ToString() == "1")
                            {
                                if (e.Row.Cells[0].Text == "State user")
                                {
                                    HtmlAnchor haPermission = (HtmlAnchor)e.Row.FindControl("aPermission");
                                    haPermission.Visible = false;


                                }
                                if (e.Row.Cells[0].Text == "Deputy Director/DFO user")
                                {//Data entry operator user
                                    HtmlAnchor haPermission = (HtmlAnchor)e.Row.FindControl("aPermission");
                                    haPermission.Visible = false;
                                    e.Row.Visible = false;

                                }

                                HtmlAnchor haPermission1 = (HtmlAnchor)e.Row.FindControl("aPermissionDataOperator");
                                haPermission1.Visible = false;
                            }
                            if (Session["UserType"].ToString() == "3")
                            {
                                HtmlAnchor haPermission = (HtmlAnchor)e.Row.FindControl("aPermission");
                                haPermission.Visible = false;

                            }
                            LinkButton lnkAd = (LinkButton)e.Row.FindControl("LnkActiveDeaActive");
                            if (lnkAd.Text.Trim() == "1")
                            {

                                lnkAd.Text = "Active";
                            }
                            else
                            {

                                lnkAd.Text = "Deactive";
                            }


                            string username = e.Row.Cells[2].Text;
                            //  string ActiveD = lnkAd.Text;
                            string ActiveD = string.Empty;
                            if (lnkAd.Text == "Active")
                            {
                                ActiveD = "Deactive";
                            }
                            if (lnkAd.Text == "Deactive")
                            {
                                ActiveD = "Active";
                            }
                            lnkAd.OnClientClick = "return confirm('Are you sure want " + ActiveD + " ');";
                            // lnkAd.OnClientClick = "return confirm('Are you sure want " + ActiveD + " " + username + " ');";

                            if (Session["UserType"].ToString() == "1")
                            {
                                // e.Row.Cells[5].Visible = false;
                                this.grduser.Columns[7].Visible = false;
                            }
                            if (Session["UserType"].ToString() == "2")
                            {
                                // e.Row.Cells[5].Visible = false;
                                this.grduser.Columns[7].Visible = false;
                            }
                            if (Session["UserType"].ToString() == "3")
                            {
                                // e.Row.Cells[5].Visible = false;
                                // grduser.Columns[0].HeaderText = "text Here";
                                //this.grduser.Columns[0].HeaderText = "Permission";
                                this.grduser.Columns[6].Visible = false;

                            }
                        }
                    }
                }
            }
        }
        catch
        {
            throw;
        }
       // }
    }
    
    protected void grduser_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grduser.PageIndex = e.NewPageIndex;
        Bind_grid();

    }
    protected void grduser_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void grduser_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int UserID = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "AD")
        {
            objntcauser.UserID = UserID;
            int recordcount = _Userbl.UpdateActiveDeaActiveUsers(objntcauser);
        }
        Bind_grid();
    }

    protected void LnksendDetails_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);
        int userid = Convert.ToInt32(btn.CommandArgument);
        objntcauser.UserID = userid;
        P_var.dSet = _Userbl.Get_UserDetials(objntcauser);
        if(P_var.dSet.Tables.Count>0)        {
            
            string emailid = HttpUtility.HtmlEncode(P_var.dSet.Tables[0].Rows[0]["EmailID"].ToString());
            //string password = HttpUtility.HtmlEncode(P_var.dSet.Tables[0].Rows[0]["Password"].ToString());
            string strMSG = @"UserName:" + P_var.dSet.Tables[0].Rows[0]["UserName"].ToString().Trim() + "<br/> Password:admin@123";
            try
            {
                Miscelleneous_BL ObjMiscel_mail = new Miscelleneous_BL();
                if (ObjMiscel_mail.SendEmail(emailid, "", "", "User Credentials of NTCA", System.Configuration.ConfigurationManager.AppSettings["ADMINMAIL"].ToString(), strMSG))
                {
                    Page.ClientScript.RegisterStartupScript(Type.GetType("System.String"), "ALERT", "alert('Thank you, Your reset password link has been sent on your email. check your mail to reset password');", true);



                }
                else
                {

                    Page.ClientScript.RegisterStartupScript(Type.GetType("System.String"), "ALERT", "alert('Email id does not exist.!');", true);



                }
            }
            catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(Type.GetType("System.String"), "ALERT", "alert('An error has been occured.Please configure your mail server!');", true);
            }

        }

    }
}