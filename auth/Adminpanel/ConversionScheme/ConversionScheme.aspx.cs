using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_ConversionScheme_ConversionScheme : CrsfBase
{
    UserBL _Userbl = new UserBL();
    NtcaUserOB objntcauser = new NtcaUserOB();
    Project_Variables P_var = new Project_Variables();
    Content_ManagementBL obj_ContentBl = new Content_ManagementBL();
    ContentOB objContentOB = new ContentOB();
    TigerReserveBL _tigerReserverBl = new TigerReserveBL();
    TigerReserveOB _TigerReserveOB = new TigerReserveOB();
    string LoginUserid;
    int LoginUsertype;
    Commanfuction _commanfuction = new Commanfuction();
    NtcaUserOB _objNtcauser = new NtcaUserOB();
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
        if (!Page.IsPostBack)
        {
            LblMsg.Text = "";
            if (Request.QueryString["Chk"] != null)
            {
                LblMsg.Text = Request.QueryString["Chk"].ToString();
            }

            BindVillagename();
            Bind_COnversionScheme();
            
        }
    }
    void Bind_COnversionScheme()
    {
        string villageID=string.Empty;
        if (TxtSchemeName.Text != "")
        {
            _TigerReserveOB.SchemeName = TxtSchemeName.Text.Trim();
        }
        if(ddlselectname.SelectedValue=="0")
        {
            _TigerReserveOB.sVillageID = null;
        }
        else
        {
            _TigerReserveOB.sVillageID = ddlselectname.SelectedValue.Trim();
        }
        //  _TigerReserveOB.Status = 1;
        P_var.dSet = _tigerReserverBl.Get_ConvesionSchemList(_TigerReserveOB);

        grdtiger.DataSource = P_var.dSet;
        grdtiger.DataBind();
    }
    public void BindVillagename()
    {
        NtcaUserOB _objNtcauser = new NtcaUserOB();
        Project_Variables P_var = new Project_Variables();
        Commanfuction _commanfuction = new Commanfuction();
        _objNtcauser.VillageName = null;
        _objNtcauser.sAction = "ReserveID";

        //  _objNtcauser.TigerReserveName = ddlselectreserve.SelectedItem.Text;


        P_var.dSet = _commanfuction.BindVillagenameChart(_objNtcauser);
        if (P_var.dSet.Tables[2].Rows.Count > 0)
        {
            ddlselectname.DataSource = P_var.dSet.Tables[2];
            ddlselectname.DataTextField = "VILL_NM";
            ddlselectname.DataValueField = "VILL_ID";
            ddlselectname.DataBind();
            ddlselectname.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-Select-", "0"));
        }
        else
        {
            ddlselectname.Items.Clear();
            ddlselectname.Items.Insert(0, new System.Web.UI.WebControls.ListItem("No Record", "0"));
        }

    }
    protected void grdtiger_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdtiger.PageIndex = e.NewPageIndex;
        Bind_COnversionScheme();
    }
    protected void rdbtnSelect_CheckedChanged(object sender, EventArgs e)
    {
        int Index = 0;
        for (int i = 0; i < grdtiger.Rows.Count; i++)
        {
            RadioButton rb = default(RadioButton);
            rb = (RadioButton)grdtiger.Rows[i].FindControl("RadioButton1");


            if (rb.Checked == true)
            {
                // Response.Write("Your Selected index=" + Index.ToString());

            }
            else
            {
                Response.Write("<script>alert('Please check radio button.!!');</script>");
            }
            Index = Index + 1;
        }

    }
    protected void grdtiger_RowCommand(object sender, GridViewCommandEventArgs e)
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
                        int ConversionIDaa = Convert.ToInt32(e.CommandArgument);
                        bool Chk = false;
                        bool WrongCheck = false;
                        if (e.CommandName == "Edit")
                        {

                            for (int i = 0; i < grdtiger.Rows.Count; i++)
                            {

                                RadioButton rb = (RadioButton)grdtiger.Rows[i].Cells[0].FindControl("RadioButton1");
                                HiddenField hyd = (HiddenField)grdtiger.Rows[i].Cells[0].FindControl("HiddenField1");
                                if (rb.Checked != true)
                                {
                                    Chk = false;

                                }
                                else
                                {
                                    if (hyd.Value == ConversionIDaa.ToString())
                                    {
                                        Chk = true;
                                        break;
                                        //
                                    }


                                }

                            }

                            if (Chk == true)
                            {
                                Response.Redirect("~/auth/Adminpanel/ConversionScheme/AddConversionScheme.aspx?tid=" + ConversionIDaa);
                            }
                            else
                            {

                                Response.Redirect("~/auth/Adminpanel/ConversionScheme/ConversionScheme.aspx?Chk=" + "Please choose right Action!");

                            }


                        }

                        if (e.CommandName == "AD")
                        {
                            for (int i = 0; i < grdtiger.Rows.Count; i++)
                            {

                                RadioButton rb = (RadioButton)grdtiger.Rows[i].Cells[0].FindControl("RadioButton1");
                                HiddenField hyd = (HiddenField)grdtiger.Rows[i].Cells[0].FindControl("HiddenField1");
                                if (rb.Checked != true)
                                {
                                    Chk = false;

                                }
                                else
                                {
                                    if (hyd.Value == ConversionIDaa.ToString())
                                    {
                                        Chk = true;
                                        break;
                                        //
                                    }


                                }

                            }

                            if (Chk == true)
                            {
                                //Response.Redirect("~/auth/Adminpanel/ConversionScheme/AddConversionScheme.aspx?tid=" + ConversionIDaa);
                                objntcauser.ConversionID = ConversionIDaa;
                                int recordcount = _Userbl.UpdateActiveDeaActiveConvesionScheme(objntcauser);
                                Bind_COnversionScheme();
                            }
                            else
                            {

                                Response.Redirect("~/auth/Adminpanel/ConversionScheme/ConversionScheme.aspx?Chk=" + "Please choose right Action!");

                            }



                            //objntcauser.ConversionID = ConversionIDaa;
                            //int recordcount = _Userbl.UpdateActiveDeaActiveConvesionScheme(objntcauser);
                        }
                        // Bind_COnversionScheme();
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
//}

    protected void grdtiger_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkAd = (LinkButton)e.Row.FindControl("LnkActiveDeaActive");
            if (lnkAd.Text.Trim() == "1")
            {

                lnkAd.Text = "DeActive";
            }
            else
            {

                lnkAd.Text = "Active";
            }


            string username = e.Row.Cells[0].Text;
            string ActiveD = lnkAd.Text;
            lnkAd.OnClientClick = "return confirm('Are you sure want " + ActiveD + " " + username + " ');";
        }
    }
    protected void grdtiger_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        Bind_COnversionScheme();
    }
}