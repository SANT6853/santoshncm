using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.interopservices;


public partial class auth_Adminpanel_Familymanegment_family_welfare : CrsfBase
{
    string LoginUserid;
    int LoginUsertype;
    NtcaUserOB objntcauser = new NtcaUserOB();
    Commanfuction _commanfucation = new Commanfuction();
    Project_Variables p_Var = new Project_Variables();
    VillageBL _villageBl = new VillageBL();
    Miscelleneous_BL miscellBL = new Miscelleneous_BL();
    Commanfuction _commanfuction = new Commanfuction();
    FamilyBL _familybl = new FamilyBL();
    FamilyOB _familyOB = new FamilyOB();
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
            if (Request.QueryString["Fid"] == null)
            {
                Bind_State();


                Bind_TigerReserveUserAccess();
                BindDistrict();
                ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
                Initial_Animal(0);

            }
            else
            {
                Bind_State();
                Bind_Family_Edit(Convert.ToInt32(Request.QueryString["Fid"].ToString()));
            }
        }
    }
    protected void ImgbtnSubmitMember_Click(object sender, EventArgs e)
    {
        int count = 0;
        DataTable dtfamilymember = new DataTable();
        if (ViewState["familymember"] != null)
        {
            dtfamilymember = (DataTable)ViewState["familymember"];
            count = dtfamilymember.Rows.Count;
            DataRow dr = dtfamilymember.NewRow();

            dr["RowNumber"] = count + 1;
            dr["MemberID"] = 0;
            dr["Gender"] = ddlselectsex.SelectedValue;
            dr["maritalstatus"] = rdomarredstatus.SelectedValue == "" ? 0 : Convert.ToInt32(rdomarredstatus.SelectedValue);
            dr["familyid"] = Request.QueryString["Fid"] == null ? 0 : Convert.ToInt32(Request.QueryString["Fid"]);
            dr["MemberName"] = txtname.Text.Trim();
            dr["Relation"] = Convert.ToInt32(ddlselectrelation.SelectedValue);
            dr["Age"] = Convert.ToInt32(txtage.Text.Trim());
            dr["Year_Month"] = 1;//year
            dr["Castcategory"] = Convert.ToInt32(ddlselectcast.SelectedValue);
            dr["ValidCardName"] = txtvalidcardnumber.Text;
            dr["ValidCardNo"] = txtvoter.Text;
            dr["ContactNo"] = txtcontact.Text;
            dr["Education"] = txtedu.Text;
            dr["Occuption"] = Convert.ToInt32(ddlselectoccupation.SelectedValue);
            dr["AnualIncome"] = Convert.ToInt32(txtincome.Text.Trim());
            dtfamilymember.Rows.Add(dr);
            ViewState["familymember"] = dtfamilymember;
            mp1.Hide();
        }
        else
        {
            dtfamilymember.Columns.Add("RowNumber", typeof(Int64));
            dtfamilymember.Columns.Add("MemberID", typeof(int));
            dtfamilymember.Columns.Add("familyid", typeof(int));
            dtfamilymember.Columns.Add("MemberName", typeof(string));
            dtfamilymember.Columns.Add("maritalstatus", typeof(int));
            dtfamilymember.Columns.Add("Relation", typeof(int));
            dtfamilymember.Columns.Add("Age", typeof(int));
            dtfamilymember.Columns.Add("Year_Month", typeof(int));
            dtfamilymember.Columns.Add("Castcategory", typeof(int));
            dtfamilymember.Columns.Add("ValidCardName", typeof(string));
            dtfamilymember.Columns.Add("ValidCardNo", typeof(string));

            dtfamilymember.Columns.Add("Gender", typeof(string));




            dtfamilymember.Columns.Add("ContactNo", typeof(string));
            dtfamilymember.Columns.Add("Education", typeof(string));
            dtfamilymember.Columns.Add("Occuption", typeof(int));
            dtfamilymember.Columns.Add("AnualIncome", typeof(int));

            DataRow dr = dtfamilymember.NewRow();
            dr["RowNumber"] = count + 1;
            dr["maritalstatus"] = rdomarredstatus.SelectedValue == "" ? 0 : Convert.ToInt32(rdomarredstatus.SelectedValue);
            dr["MemberID"] = 0;
            dr["familyid"] = Request.QueryString["Fid"] == null ? 0 : Convert.ToInt32(Request.QueryString["Fid"]);
            dr["MemberName"] = txtname.Text.Trim();
            dr["Relation"] = Convert.ToInt32(ddlselectrelation.SelectedValue);
            dr["Age"] = Convert.ToInt32(txtage.Text.Trim());
            dr["Year_Month"] = 1;//year
            dr["Gender"] = ddlselectsex.SelectedValue;
            dr["Castcategory"] = Convert.ToInt32(ddlselectcast.SelectedValue);
            dr["ValidCardName"] = txtvalidcardnumber.Text;
            dr["ValidCardNo"] = txtvoter.Text;
            dr["ContactNo"] = txtcontact.Text;
            dr["Education"] = txtedu.Text;
            dr["Occuption"] = Convert.ToInt32(ddlselectoccupation.SelectedValue);
            dr["AnualIncome"] = Convert.ToInt32(txtincome.Text.Trim());
            dtfamilymember.Rows.Add(dr);
            ViewState["familymember"] = dtfamilymember;
            mp1.Hide();
        }
        grdmember.DataSource = dtfamilymember;
        grdmember.DataBind();
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTehshil();
    }
    protected void ddlTehshiil_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGramPanchayat();
    }
    protected void ddlGramPanchayat_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    void BindGramPanchayat()
    {

        objntcauser.TehshilID = Convert.ToInt32(ddlTehshiil.SelectedValue);
        p_Var.dSet = _commanfucation.GetGramPanchayat(objntcauser);
        ddlGramPanchayat.DataSource = p_Var.dSet;
        ddlGramPanchayat.DataTextField = "GramPanchayatName";
        ddlGramPanchayat.DataValueField = "GramPanchayatID";
        ddlGramPanchayat.DataBind();
        ddlGramPanchayat.Items.Insert(0, new ListItem("Select", "0"));
    }

    void BindTehshil()
    {

        objntcauser.Dist = Convert.ToInt32(ddlDistrict.SelectedValue);
        p_Var.dSet = _commanfucation.GetTehshil(objntcauser);
        ddlTehshiil.DataSource = p_Var.dSet;
        ddlTehshiil.DataTextField = "Tehsil_Name";
        ddlTehshiil.DataValueField = "Tehsil";
        ddlTehshiil.DataBind();
        ddlTehshiil.Items.Insert(0, new ListItem("Select", "0"));
    }
    void Bind_TigerReserveUserAccess()
    {

        // p_Var.dSet = _tigerReserverBl.GetTigerReserverByState(2, Convert.ToInt32(LoginUserid));
        objntcauser.UserType = LoginUsertype;
        objntcauser.UserID = Convert.ToInt32(LoginUserid);
        objntcauser.State = Convert.ToInt32(ddlstate.SelectedValue);
        p_Var.dSet = _commanfucation.Get_TigerReserve_state_Permission(objntcauser);
        ddltigerreserve.DataSource = p_Var.dSet;
        ddltigerreserve.DataTextField = "TigerReserveName";
        ddltigerreserve.DataValueField = "TigerReserveid";
        ddltigerreserve.DataBind();
        ddltigerreserve.Items.Insert(0, new ListItem("Select", "0"));
    }

    void Bind_State()
    {
        objntcauser.UserID = Convert.ToInt32(LoginUserid);
        p_Var.dSet = _commanfucation.StateListByUserAccess(objntcauser);
        ddlstate.DataSource = p_Var.dSet;
        ddlstate.DataTextField = "StateName";
        ddlstate.DataValueField = "id";
        ddlstate.DataBind();
        if (LoginUsertype == 1)
        {
            ddlstate.Items.Insert(0, new ListItem("Select State", "0"));

        }
    }

    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_TigerReserveUserAccess();
        BindDistrict();
    }
    void BindDistrict()
    {

        objntcauser.State = Convert.ToInt32(ddlstate.SelectedValue);
        p_Var.dSet = _commanfucation.GetDistrict(objntcauser);
        ddlDistrict.DataSource = p_Var.dSet;
        ddlDistrict.DataTextField = "DistName";
        ddlDistrict.DataValueField = "DistID";
        ddlDistrict.DataBind();
        ddlDistrict.Items.Insert(0, new ListItem("Select", "0"));
    }

    void Bind_VillageList()
    {
        p_Var.dSet = _villageBl.GetVillageByTigerReserverID(Convert.ToInt32(ddltigerreserve.SelectedValue));
        ddlvillage.DataSource = p_Var.dSet;
        ddlvillage.DataTextField = "Village_Name";
        ddlvillage.DataValueField = "TempVillageid";
        ddlvillage.DataBind();
        ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
    }



    protected void ddltigerreserve_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_VillageList();
    }
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
    }
    void Initial_Animal(int familyid)
    {
        DataTable dtanimal = new DataTable();
        if (ViewState["AnimalData"] == null)
        {
            p_Var.dSet = _familybl.Get_AnimalByfamily(familyid);
            dtanimal = p_Var.dSet.Tables[0];
            if (familyid > 0)
            {
                if (dtanimal.Rows.Count > 0)
                {
                    ViewState["AnimalData"] = dtanimal;
                }
            }
        }
        // dtanimal = (DataTable) ViewState["AnimalData"] ;
        if (dtanimal.Rows.Count == 0)
        {
            dtanimal.Rows.Add(dtanimal.NewRow());
            grdAnimal.DataSource = dtanimal;
            grdAnimal.DataBind();
            int columncount = grdAnimal.Rows[0].Cells.Count;
            grdAnimal.Rows[0].Cells.Clear();
            grdAnimal.Rows[0].Cells.Add(new TableCell());
            grdAnimal.Rows[0].Cells[0].ColumnSpan = columncount;
            grdAnimal.Rows[0].Cells[0].Text = "No Records Found";

        }
        else
        {
            grdAnimal.DataSource = p_Var.dSet;
            grdAnimal.DataBind();
        }
    }




    private void AddNewRowToGrid()
    {

        //if (Page.IsValid)
        //{

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
                       // if (Request.QueryString["TempLink_Id"] == null)
                       // {

                           // if (Request.QueryString["TempLink_Id"] == null)
                           // {

                                int count = 0;
                                DataTable dtanimal = new DataTable();
                                if (ViewState["AnimalData"] != null)
                                {
                                    dtanimal = (DataTable)ViewState["AnimalData"];
                                    count = dtanimal.Rows.Count;
                                    DataRow dr = dtanimal.NewRow();
                                    dr["RowNumber"] = count + 1;
                                    dr["ID"] = 0;
                                    if (Request.QueryString["Fid"] == null)
                                    {
                                        dr["Familyid"] = 0;
                                    }
                                    else
                                    {
                                        dr["Familyid"] = Convert.ToInt32(Request.QueryString["Fid"].ToString());
                                    }

                                    dr["AnimalType"] = Convert.ToInt32(((DropDownList)grdAnimal.FooterRow.FindControl("ddlAnimal")).SelectedValue);
                                    dr["NOofAnimal"] = ((TextBox)grdAnimal.FooterRow.FindControl("txtnoofanimal")).Text;
                                    dtanimal.Rows.Add(dr);


                                }
                                else
                                {
                                    dtanimal.Columns.Add("RowNumber", typeof(Int64));
                                    dtanimal.Columns.Add("ID", typeof(int));
                                    dtanimal.Columns.Add("Familyid", typeof(int));
                                    dtanimal.Columns.Add("AnimalType", typeof(int));
                                    dtanimal.Columns.Add("NOofAnimal", typeof(int));
                                    DataRow dr = dtanimal.NewRow();
                                    dr["RowNumber"] = count + 1;
                                    dr["ID"] = 0;
                                    if (Request.QueryString["Fid"] == null)
                                    {
                                        dr["Familyid"] = 0;
                                    }
                                    else
                                    {
                                        dr["Familyid"] = Convert.ToInt32(Request.QueryString["Fid"].ToString());
                                    }

                                    dr["AnimalType"] = Convert.ToInt32(((DropDownList)grdAnimal.FooterRow.FindControl("ddlAnimal")).SelectedValue);
                                    dr["NOofAnimal"] = ((TextBox)grdAnimal.FooterRow.FindControl("txtnoofanimal")).Text;
                                    dtanimal.Rows.Add(dr);

                                }
                                ViewState["AnimalData"] = dtanimal;
                                grdAnimal.DataSource = dtanimal;
                                grdAnimal.DataBind();
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


                    
     
protected void grdAnimal_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblanimal =
          (Label)e.Row.FindControl("lblanimal");
            HiddenField hydanimaltype = (HiddenField)e.Row.FindControl("hydanimaltype");
            if (hydanimaltype.Value.Trim() != "")
            {
                if (Convert.ToInt32(hydanimaltype.Value) == 1)
                {
                    lblanimal.Text = "Cow";
                }
                else if (Convert.ToInt32(hydanimaltype.Value) == 2)
                {
                    lblanimal.Text = "Sheep";
                }
                else if (Convert.ToInt32(hydanimaltype.Value) == 3)
                {
                    lblanimal.Text = "Goat";
                }
                else if (Convert.ToInt32(hydanimaltype.Value) == 4)
                {
                    lblanimal.Text = "Buffalo";
                }
                else if (Convert.ToInt32(hydanimaltype.Value) == 5)
                {
                    lblanimal.Text = "Others";
                }
            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            p_Var.dSetChildData = _commanfuction.GetAnimal();
            DropDownList ddlanimal =
            (DropDownList)e.Row.FindControl("ddlAnimal");
            ddlanimal.DataSource = p_Var.dSetChildData;
            ddlanimal.DataTextField = "Animal";
            ddlanimal.DataValueField = "AnimalID";
            ddlanimal.DataBind();
        }
    }

    protected void grdAnimal_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "removeRecord")
        {
            if (ViewState["AnimalData"] != null)
            {
                DataTable dtanimal = (DataTable)ViewState["AnimalData"];
                var query = dtanimal.AsEnumerable().Where(r => r.Field<Int64>("RowNumber") == Convert.ToInt64(e.CommandArgument.ToString()));

                foreach (var row in query.ToList())
                    row.Delete();
                dtanimal.AcceptChanges();
                int count = 0;
                foreach (DataRow dr in dtanimal.Rows)
                {
                    dr["RowNumber"] = count + 1;
                    count++;
                }
                if (dtanimal.Rows.Count == 0)
                {
                    dtanimal.Rows.Add(dtanimal.NewRow());
                    grdAnimal.DataSource = dtanimal;
                    grdAnimal.DataBind();
                    int columncount = grdAnimal.Rows[0].Cells.Count;
                    grdAnimal.Rows[0].Cells.Clear();
                    grdAnimal.Rows[0].Cells.Add(new TableCell());
                    grdAnimal.Rows[0].Cells[0].ColumnSpan = columncount;
                    grdAnimal.Rows[0].Cells[0].Text = "No Records Found";
                    ViewState["AnimalData"] = null;
                }
                else
                {
                    ViewState["AnimalData"] = dtanimal;

                    grdAnimal.DataSource = dtanimal;
                    grdAnimal.DataBind();
                }
            }

        }
    }


    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        //if (Page.IsValid)
        //{

        try
        {

            string hdnblank = ((HiddenField)this.Master.FindControl("hdnblank")).Value;
            string CurrentSessionId = Convert.ToString(Session["AntiForgeryToken"]);

            if (Session["CurrentRequestUrl"] != null && Convert.ToString(Session["CurrentRequestUrl"]).Equals(Convert.ToString(Request.ServerVariables["HTTP_REFERER"])))
            {
                if (CurrentSessionId == hdnblank)
                {


                    // if (Page.IsValid)
                    //{
                    if (Request.QueryString["TempLink_Id"] == null)
                    {

                        if (Page.IsValid)
                        {
                            if (Request.QueryString["Fid"] != null)
                            {
                                _familyOB.familyid = Convert.ToInt32(Request.QueryString["Fid"].ToString());
                            }
                            _familyOB.Stateid = Convert.ToInt32(ddlstate.SelectedValue);
                            _familyOB.TigerReserveid = Convert.ToInt32(ddltigerreserve.SelectedValue);
                            _familyOB.VillageID = Convert.ToInt32(ddlvillage.SelectedValue);
                            _familyOB.Head_Name = txtheadname.Text.Trim();
                            _familyOB.Agriculature_land = Convert.ToDecimal(txtagricultureland.Text.Trim());
                            _familyOB.Residential_Property = Convert.ToDecimal(txtresidentialPropery.Text.Trim());
                            _familyOB.Total_Livestock = Convert.ToInt32(txtlivestock.Text.Trim());
                            _familyOB.Other_assest = txtotherassest.Text;
                            _familyOB.Longitude = txtLongitudecurrent.Text;
                            _familyOB.Latitude = txtLatitudeCurrent.Text;
                            _familyOB.SanctionLeter = "";
                            _familyOB.Submitedby = Convert.ToInt32(LoginUserid);
                            _familyOB.IPAddress = miscellBL.IpAddress();



                            _familyOB.SurveryDate = miscellBL.getDateFormat(txtsurveydate.Text);
                            _familyOB.DistictID = Convert.ToInt32(ddlDistrict.SelectedValue);
                            _familyOB.Tehshilid = Convert.ToInt32(ddlTehshiil.SelectedValue);
                            _familyOB.GramPanchayat = Convert.ToInt32(ddlGramPanchayat.SelectedValue);
                            _familyOB.Area = Convert.ToInt32(ddlArea.SelectedValue); ;
                            _familyOB.StatusofResidence = Convert.ToInt32(ddlhousestatus.SelectedValue);
                            _familyOB.ReallocationPlace = txtreallocationPlace.Text;
                            _familyOB.Total_Well = Convert.ToInt32(txttotalwell.Text);
                            _familyOB.Total_Tree = Convert.ToInt32(txttree.Text);
                            _familyOB.Legalstatus = Convert.ToInt32(ddlLegalStatus.SelectedValue);
                            _familyOB.OptionSelected = Convert.ToInt32(ddloptionSelected.SelectedValue);

                            DataTable dtfamilymember = new DataTable();
                            if (ViewState["familymember"] != null)
                            {
                                dtfamilymember = (DataTable)ViewState["familymember"];
                            }
                            DataTable dtanimal = new DataTable();
                            if (ViewState["AnimalData"] != null)
                            {
                                dtanimal = (DataTable)ViewState["AnimalData"];
                            }
                            if (Request.QueryString["Fid"] == null)
                            {
                                _familybl.InsertFamilydetiails(_familyOB, dtanimal, dtfamilymember);
                                Session["msg"] = "Family Details has been submitted successfully.";
                                Session["Redirect"] = "~/Auth/AdminPanel/Familymanegment/ViewFamily.aspx";
                                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                            }
                            else
                            {

                                _familybl.Asp_Update_Family_Detials(_familyOB, dtanimal, dtfamilymember);
                                Session["msg"] = "Family Details has been updated successfully.";
                                Session["Redirect"] = "~/Auth/AdminPanel/Familymanegment/ViewFamily.aspx";
                                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                            }
                        }
                    }
                }
            }
        }
        //}
        catch
        {
            throw;
        }
    //}
}



    
    protected void ddlselectsex_SelectedIndexChanged(object sender, EventArgs e)
    {
        rdomarredstatus.Visible = ddlselectsex.SelectedValue == "F";
        //mp1.Show();
    }
    protected void ddlselectrelation_selectindexched(object sender, EventArgs e)
    {
        trfatherhusband.Visible = Convert.ToInt32(ddlselectrelation.SelectedValue) == 1;
    }
    void Bind_Family_Edit(int familyid)
    {
        p_Var.dSetChildData = _familybl.Asp_GetFamilyDetialsForEdit(familyid);
        ddlstate.SelectedValue = p_Var.dSetChildData.Tables[0].Rows[0]["Stateid"].ToString();
        Bind_TigerReserveUserAccess();
        ddltigerreserve.SelectedValue = p_Var.dSetChildData.Tables[0].Rows[0]["TigerReserveid"].ToString();

        Bind_VillageList();
        BindDistrict();
        
        ddlvillage.SelectedValue = p_Var.dSetChildData.Tables[0].Rows[0]["VillageID"].ToString();
        txtsurveydate.Text= p_Var.dSetChildData.Tables[0].Rows[0]["SurveryDate"].ToString();
        ddloptionSelected.SelectedValue = p_Var.dSetChildData.Tables[0].Rows[0]["OptionSelected"].ToString();
        ddlLegalStatus.SelectedValue = p_Var.dSetChildData.Tables[0].Rows[0]["LagalStatus"].ToString();
        ddlDistrict.SelectedValue = p_Var.dSetChildData.Tables[0].Rows[0]["DistictID"].ToString();
        BindTehshil();
        ddlTehshiil.SelectedValue = p_Var.dSetChildData.Tables[0].Rows[0]["Tehshilid"].ToString();
        BindGramPanchayat();
        ddlGramPanchayat.SelectedValue = p_Var.dSetChildData.Tables[0].Rows[0]["GramPanchayat"].ToString();
        txtheadname.Text = p_Var.dSetChildData.Tables[0].Rows[0]["Head_Name"].ToString();
        ddlArea.SelectedValue = p_Var.dSetChildData.Tables[0].Rows[0]["Area"].ToString();
          ddlhousestatus.SelectedValue = p_Var.dSetChildData.Tables[0].Rows[0]["StatusofResidence"].ToString();
        txtreallocationPlace.Text = p_Var.dSetChildData.Tables[0].Rows[0]["ReallocationPlace"].ToString();

        txttotalwell.Text = p_Var.dSetChildData.Tables[0].Rows[0]["Total_Well"].ToString();
        txttree.Text = p_Var.dSetChildData.Tables[0].Rows[0]["Total_Tree"].ToString();
        txtotherassest.Text = p_Var.dSetChildData.Tables[0].Rows[0]["Other_assest"].ToString();

        txtagricultureland.Text = p_Var.dSetChildData.Tables[0].Rows[0]["Agriculature_land"].ToString();
        txtresidentialPropery.Text = p_Var.dSetChildData.Tables[0].Rows[0]["Residential_Property"].ToString();
        txtlivestock.Text = p_Var.dSetChildData.Tables[0].Rows[0]["Total_Livestock"].ToString();
        txtLatitudeCurrent.Text = p_Var.dSetChildData.Tables[0].Rows[0]["Latitude"].ToString();
        txtLongitudecurrent.Text = p_Var.dSetChildData.Tables[0].Rows[0]["Longitude"].ToString();
        txtotherassest.Text = p_Var.dSetChildData.Tables[0].Rows[0]["Other_assest"].ToString();

      

        if(p_Var.dSetChildData.Tables[2].Rows.Count>0)
        {
            DataTable dtfamilymember = new DataTable();
           
            if (ViewState["familymember"] == null)
            {
               // p_Var.dSet = p_Var.dSetChildData.Tables[2];//_familybl.Get_AnimalByfamily(familyid);
                dtfamilymember = p_Var.dSetChildData.Tables[2];
                if (familyid > 0)
                {
                    if (dtfamilymember.Rows.Count > 0)
                    {
                        ViewState["familymember"] = dtfamilymember;
                    }
                }
            }
            // dtanimal = (DataTable) ViewState["AnimalData"] ;
            if (dtfamilymember.Rows.Count == 0)
            {
                dtfamilymember.Rows.Add(dtfamilymember.NewRow());

                grdmember.DataSource = dtfamilymember;
                grdmember.DataBind();
                int columncount = grdmember.Rows[0].Cells.Count;
                grdmember.Rows[0].Cells.Clear();
                grdmember.Rows[0].Cells.Add(new TableCell());
                grdmember.Rows[0].Cells[0].ColumnSpan = columncount;
                grdmember.Rows[0].Cells[0].Text = "No Records Found";

            }
            else
            {
                grdmember.DataSource = p_Var.dSetChildData.Tables[2];
                grdmember.DataBind();
            }
        }
        Initial_Animal(Convert.ToInt32(Request.QueryString["Fid"].ToString()));
    }

    protected void grdfamilymember_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblageyearmonth =
          (Label)e.Row.FindControl("lblageyearmonth");
            HiddenField hydageyearmonth = (HiddenField)e.Row.FindControl("hydageyearmonth");
            if (hydageyearmonth.Value.Trim() != "")
            {
                if (hydageyearmonth.Value == "Y")
                {
                    lblageyearmonth.Text = "Year";
                }
                else
                {
                    lblageyearmonth.Text = "Month";
                }

            }


            Label lblGender = (Label)e.Row.FindControl("lblGender");
            HiddenField hydgender = (HiddenField)e.Row.FindControl("hydgender");
            if (hydgender.Value == "M")
            {
                lblGender.Text = "Male";
            }
            else
            {
                lblGender.Text = "Female";
            }
            Label lblAadharCardFile = (Label)e.Row.FindControl("lblAadharCardFile");
            HiddenField hydaadharcardfile = (HiddenField)e.Row.FindControl("hydaadharcardfile");
            lblAadharCardFile.Text = "<a href='" + "../../../WriteReadData/Familyaadhar/" + hydaadharcardfile.Value + "' target='_blank'>View</a>";
        }
    }


    protected void ddlvillage_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}