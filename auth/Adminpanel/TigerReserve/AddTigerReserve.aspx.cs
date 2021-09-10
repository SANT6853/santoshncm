using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_TigerReserve_AddTigerReserve : CrsfBase
{
    Project_Variables P_var = new Project_Variables();
    Content_ManagementBL obj_ContentBl = new Content_ManagementBL();
    ContentOB objContentOB = new ContentOB();
    TigerReserveBL _tigerReserverBl = new TigerReserveBL();
    TigerReserveOB _TigerReserveOB = new TigerReserveOB();
    string LoginUserid;
    int LoginUsertype;
    Commanfuction _commanfuction = new Commanfuction();
    NtcaUserOB _objNtcauser = new NtcaUserOB();
    public static string HeaderTitle = string.Empty;
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
        if (!Page.IsPostBack)
        {
            Bind_state();


            if (Request.QueryString["tid"] != null)
            {
                HeaderTitle = "Edit Tiger Reserve";
                Page.Title = "NTCA:Edit Tiger Reserve";
                BindDetials();
                btnsave.Text = "Update";
                BtnBack.Visible = true;
            }
            else
            {
                BtnBack.Visible = false;
                HeaderTitle = "Add Tiger Reserve";
                Page.Title = "NTCA:Add Tiger Reserve";
                //ddlcity.Items.Insert(0, new ListItem("Select", "0"));

            }
        }
    }
    void Bind_state()
    {

        // objContentOB.LangID = 1;
        // P_var.dSet = obj_ContentBl.getStateName(objContentOB);
        ddlstate.Items.Clear();
        _objNtcauser.UserID = Convert.ToInt32(LoginUserid);
        P_var.dSet = _commanfuction.StateListByUserAccess(_objNtcauser);
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            ddlstate.DataSource = P_var.dSet;
            ddlstate.DataTextField = "StateName";
            ddlstate.DataValueField = "id";
            ddlstate.DataBind();
            if (LoginUsertype == 1)
            {
                ddlstate.Items.Insert(0, new ListItem("Select State", "0"));
            }
        }
        else
        {
            ddlstate.Items.Insert(0, new ListItem("No Record is found", "0"));
        }
        Bind_Dist(Convert.ToInt32(ddlstate.SelectedValue));
    }

    void Bind_Dist(int stateid)
    {
       // DataSet Ds = new DataSet();
      //  Ds = tigerReserverBl.GetDist(stateid);
        ddldist.Items.Clear();
        P_var.dSet = _tigerReserverBl.GetDist(stateid);
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            ddldist.DataSource = _tigerReserverBl.GetDist(stateid);
            ddldist.DataTextField = "DistName";
            ddldist.DataValueField = "DistID";
            ddldist.DataBind();
            ddldist.Items.Insert(0, new ListItem("Select District", "0"));
        }
        else
        {
            ddldist.Items.Insert(0, new ListItem("No Record is found", "0"));
        }
    }
    void Bind_City(int distid)
    {
        //  ddlcity.DataSource = _tigerReserverBl.GetCity(distid);
        //ddlcity.DataTextField = "CityName";
        //ddlcity.DataValueField = "CityID";

        //ddlcity.DataBind();
        //ddlcity.Items.Insert(0, new ListItem("Select City", "0"));
    }
    protected void ddldist_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Bind_City(Convert.ToInt32(ddldist.SelectedValue));
    }

    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstate.SelectedIndex != 0)
        {
            Bind_Dist(Convert.ToInt32(ddlstate.SelectedValue));
        }
        else
        {

        }
    }
    bool check()
    {
        if (ddlstate.SelectedItem.Text == "Select State")
        {
            Label1.Text = "Please select state";
            return false;
        }
        if (ddldist.SelectedItem.Text == "Select District")
        {
            Label1.Text = "Please select District";
            return false;
        }
        return true;
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

                    if (Page.IsValid)
                    {

                        Label1.Text = string.Empty;
                        if (Page.IsValid)
                        {
                            bool chk = check();

                            if (Request.QueryString["tid"] != null)
                            {
                                _TigerReserveOB.TigerReserveid = Convert.ToInt32(Request.QueryString["tid"].ToString());


                                #region collapse
                                if (chk == true)
                                {
                                    bool ChkDuplicateTigerReserveEnglish = updateChkDuplicacyTigerReserveEnglish();
                                    bool ChkDuplicateTigerReserveHindi = updateChkDuplicacyTigerReserveHindi();
                                    if (ChkDuplicateTigerReserveEnglish == false)
                                    {
                                        if (ChkDuplicateTigerReserveHindi == false)
                                        {
                                            _TigerReserveOB.TigerReserveName = HttpUtility.HtmlEncode(txttigerreservename.Text.Trim());
                                            _TigerReserveOB.TigerReserveNameHindi = HttpUtility.HtmlEncode(txttigerreservenamehindi.Text.Trim());
                                            _TigerReserveOB.NoofVillages = Convert.ToInt32(txtnoofvillage.Text.Trim());
                                            _TigerReserveOB.StateID = Convert.ToInt32(ddlstate.SelectedValue);
                                            _TigerReserveOB.Dist = Convert.ToInt32(ddldist.SelectedValue);
                                            _TigerReserveOB.City = 0;// Convert.ToInt32(ddlcity.SelectedValue);
                                            _TigerReserveOB.TigerReserveMap = "";
                                            _TigerReserveOB.CoreArea = txtcorearea.Text.Trim();
                                            _TigerReserveOB.BufferArea = txtbufferarea.Text.Trim();
                                            _TigerReserveOB.longitude = txtLongitude.Text.Trim();
                                            _TigerReserveOB.latitude = txtLatitude.Text.Trim();
                                            _TigerReserveOB.CreatedBy = Convert.ToInt32(LoginUserid);
                                            _TigerReserveOB.Status = 1;// 5 For Aprrover Details from Mst_Status
                                            _tigerReserverBl.Insert_UpdateTigerReserver(_TigerReserveOB);

                                            if (Request.QueryString["tid"] != null)
                                            {
                                                Session["msg"] = "Tiger Reserve has been Updated successfully.";
                                            }
                                            else
                                            {
                                                Session["msg"] = "Tiger Reserve has been added successfully.";
                                            }
                                            Session["BackUrl"] = "~/Auth/AdminPanel/TigerReserve/ViewTigerReserver.aspx?ModuleID=" + Convert.ToInt16(Request.QueryString["ModuleID"]);
                                            Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                                        }
                                        else
                                        {
                                            Response.Write("<script>alert('Already exist Tiger Reserve Name(Hindi)!');</script>");
                                        }
                                    }
                                    else
                                    {
                                        Response.Write("<script>alert('Already exist Tiger Reserve Name!');</script>");
                                    }
                                }//end chk
                                #endregion

                            }
                            else
                            {
                                var StateDistOnlySingle = ChkTigerReserSingleInStateDistrict();

                                if (StateDistOnlySingle == true)
                                {
                                    Label1.Text = "Already single record has exist in state in district multiple not allow!";
                                    Label1.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    #region collapse
                                    if (chk == true)
                                    {
                                        bool ChkDuplicateTigerReserveEnglish = ChkDuplicacyTigerReserveEnglish();
                                        bool ChkDuplicateTigerReserveHindi = ChkDuplicacyTigerReserveHindi();
                                        if (ChkDuplicateTigerReserveEnglish == false)
                                        {
                                            if (ChkDuplicateTigerReserveHindi == false)
                                            {
                                                _TigerReserveOB.TigerReserveName = HttpUtility.HtmlEncode(txttigerreservename.Text.Trim());
                                                _TigerReserveOB.TigerReserveNameHindi = HttpUtility.HtmlEncode(txttigerreservenamehindi.Text.Trim());
                                                _TigerReserveOB.NoofVillages = Convert.ToInt32(txtnoofvillage.Text.Trim());
                                                _TigerReserveOB.StateID = Convert.ToInt32(ddlstate.SelectedValue);
                                                _TigerReserveOB.Dist = Convert.ToInt32(ddldist.SelectedValue);
                                                _TigerReserveOB.City = 0;// Convert.ToInt32(ddlcity.SelectedValue);
                                                _TigerReserveOB.TigerReserveMap = "";
                                                _TigerReserveOB.CoreArea = txtcorearea.Text.Trim();
                                                _TigerReserveOB.BufferArea = txtbufferarea.Text.Trim();
                                                _TigerReserveOB.longitude = txtLongitude.Text.Trim();
                                                _TigerReserveOB.latitude = txtLatitude.Text.Trim();
                                                _TigerReserveOB.CreatedBy = Convert.ToInt32(LoginUserid);
                                                _TigerReserveOB.Status = 1;// 5 For Aprrover Details from Mst_Status
                                                _tigerReserverBl.Insert_UpdateTigerReserver(_TigerReserveOB);

                                                if (Request.QueryString["tid"] != null)
                                                {
                                                    Session["msg"] = "Tiger Reserve has been Updated successfully.";
                                                }
                                                else
                                                {
                                                    Session["msg"] = "Tiger Reserve has been added successfully.";
                                                }
                                                Session["BackUrl"] = "~/Auth/AdminPanel/TigerReserve/ViewTigerReserver.aspx?ModuleID=" + Convert.ToInt16(Request.QueryString["ModuleID"]);
                                                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                                            }
                                            else
                                            {
                                                Response.Write("<script>alert('Already exist Tiger Reserve Name(Hindi)!');</script>");
                                            }
                                        }
                                        else
                                        {
                                            Response.Write("<script>alert('Already exist Tiger Reserve Name!');</script>");
                                        }
                                    }//end chk
                                    #endregion
                                }

                            }


                        }
                    }
                }
                //}
            }
        }
        catch
        {
            throw;
        }
        // }
    }
    
    void BindDetials()
    {
        TigerReserveOB tob = new TigerReserveOB();
        tob.TigerReserveid = Convert.ToInt32(Request.QueryString["tid"].ToString());
        P_var.dSetChildData = _tigerReserverBl.Get_TigerReservationDetials(tob);
        if (P_var.dSetChildData.Tables[0].Rows.Count > 0)
        {
            txttigerreservename.Text = P_var.dSetChildData.Tables[0].Rows[0]["TigerReserveName"].ToString();
            txttigerreservenamehindi.Text = P_var.dSetChildData.Tables[0].Rows[0]["TigerReserveNameHindi"].ToString();
            txtnoofvillage.Text = P_var.dSetChildData.Tables[0].Rows[0]["NoofVillages"].ToString();
            ddlstate.SelectedValue = P_var.dSetChildData.Tables[0].Rows[0]["StateID"].ToString();
            Bind_Dist(Convert.ToInt32(ddlstate.SelectedValue));
            ddldist.SelectedValue = P_var.dSetChildData.Tables[0].Rows[0]["Dist"].ToString();
            // Bind_City(Convert.ToInt32(ddldist.SelectedValue));
            // ddlcity.SelectedValue = P_var.dSetChildData.Tables[0].Rows[0]["City"].ToString();
            lblmap.Text = P_var.dSetChildData.Tables[0].Rows[0]["TigerReserveMap"].ToString();
            txtcorearea.Text = P_var.dSetChildData.Tables[0].Rows[0]["CoreArea"].ToString();
            txtbufferarea.Text = P_var.dSetChildData.Tables[0].Rows[0]["BufferArea"].ToString();
            txtLongitude.Text = P_var.dSetChildData.Tables[0].Rows[0]["longitude"].ToString();
            txtLatitude.Text = P_var.dSetChildData.Tables[0].Rows[0]["latitude"].ToString();
        }
    }
    bool ChkTigerReserSingleInStateDistrict()
    {
        P_var.dSetChildData = null;
        bool Chk = false;
        TigerReserveOB tob = new TigerReserveOB();

        tob.StateID = Convert.ToInt32(ddlstate.SelectedValue);
        tob.Dist = Convert.ToInt32(ddldist.SelectedValue);

        P_var.dSetChildData = _tigerReserverBl.CheckTigerReserSingleInStateDistrictDal(tob);
        if (P_var.dSetChildData.Tables[0].Rows.Count > 0)
        {
            Chk = true;
        }

        return Chk;
    }
    bool ChkDuplicacyTigerReserveEnglish()
    {
        P_var.dSetChildData = null;
        bool Chk = false;
        TigerReserveOB tob = new TigerReserveOB();
        tob.TigerReserveName = txttigerreservename.Text.Trim();
        tob.StateID = Convert.ToInt32(ddlstate.SelectedValue);
        tob.Dist = Convert.ToInt32(ddldist.SelectedValue);

        P_var.dSetChildData = _tigerReserverBl.CheckDuplicateTigerReserve(tob);
        if (P_var.dSetChildData.Tables[0].Rows.Count > 0)
        {
            Chk = true;
        }

        return Chk;
    }
    bool updateChkDuplicacyTigerReserveEnglish()
    {
        P_var.dSetChildData = null;
        bool Chk = false;
        TigerReserveOB tob = new TigerReserveOB();
        tob.TigerReserveid = Convert.ToInt32(Request.QueryString["tid"].ToString());
        tob.TigerReserveName = txttigerreservename.Text.Trim();
        tob.StateID = Convert.ToInt32(ddlstate.SelectedValue);
        tob.Dist = Convert.ToInt32(ddldist.SelectedValue);

        P_var.dSetChildData = _tigerReserverBl.updateCheckDuplicateTigerReserve(tob);
        if (P_var.dSetChildData.Tables[0].Rows.Count > 0)
        {
            Chk = true;
        }

        return Chk;
    }
    bool ChkDuplicacyTigerReserveHindi()
    {
        P_var.dSetChildData = null;
        bool Chk = false;
        TigerReserveOB tob = new TigerReserveOB();
        tob.TigerReserveNameHindi = txttigerreservenamehindi.Text.Trim();
        tob.StateID = Convert.ToInt32(ddlstate.SelectedValue);
        tob.Dist = Convert.ToInt32(ddldist.SelectedValue);
        P_var.dSetChildData = _tigerReserverBl.CheckDuplicateTigerReserve(tob);

        if (P_var.dSetChildData.Tables[1].Rows.Count > 0)
        {
            Chk = true;
        }
        return Chk;
    }
    bool updateChkDuplicacyTigerReserveHindi()
    {
        P_var.dSetChildData = null;
        bool Chk = false;
        TigerReserveOB tob = new TigerReserveOB();
        tob.TigerReserveid = Convert.ToInt32(Request.QueryString["tid"].ToString());
        tob.TigerReserveNameHindi = txttigerreservenamehindi.Text.Trim();
        tob.StateID = Convert.ToInt32(ddlstate.SelectedValue);
        tob.Dist = Convert.ToInt32(ddldist.SelectedValue);
        P_var.dSetChildData = _tigerReserverBl.updateCheckDuplicateTigerReserve(tob);

        if (P_var.dSetChildData.Tables[1].Rows.Count > 0)
        {
            Chk = true;
        }
        return Chk;
    }
    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/adminpanel/TigerReserve/ViewTigerReserver.aspx?Moduleid=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.TigerReserve));
    }
}