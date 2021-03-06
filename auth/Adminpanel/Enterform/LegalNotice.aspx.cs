using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_Enterform_LegalNotice : CrsfBase
{
    LegalDocumentOB _LegalDocumentOB = new LegalDocumentOB();
    LegalDocumentBL _LegalDocumentBL = new LegalDocumentBL();
    Project_Variables pval = new Project_Variables();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
         
            Bind_LegalDocument();
        }
    }

    protected void ImgbtnSubmit_Click(object sender, EventArgs e)
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
                       // try
                       // {
                            Miscelleneous_BL miscelBL = new Miscelleneous_BL();

                            _LegalDocumentOB.Villageid = Convert.ToInt16(Request.QueryString["id"]);

                            _LegalDocumentOB.CTH_Notified = Convert.ToBoolean(DDLCTHNotified.SelectedValue);
                            _LegalDocumentOB.CTH_DateofNotification = TXTCTHDATEOFNOTIFICATION.Text.Trim() == "" ? (DateTime?)null : miscelBL.getDateFormat(TXTCTHDATEOFNOTIFICATION.Text);
                            _LegalDocumentOB.CTH_Area = Convert.ToDecimal(Txtctharea.Text);
                            _LegalDocumentOB.CTH_Compliance_of_section_38V = txtCompliance_ofsection38V.Text;
                            _LegalDocumentOB.BUffer_Peripheral_Area_Notified = Convert.ToBoolean(ddlbufferNotified.SelectedValue);
                            _LegalDocumentOB.BUffer_Peripheral_Area_DateofNotification = txtbufferdateofnotification.Text.Trim() == "" ? (DateTime?)null : miscelBL.getDateFormat(txtbufferdateofnotification.Text);
                            _LegalDocumentOB.BUffer_Peripheral_Area_Area = Convert.ToDecimal(txtbufferarea.Text);
                            _LegalDocumentOB.BUffer_Peripheral_Area_Expert_committee_Constituted = Convert.ToBoolean(ddlexpert_Constituted.SelectedValue);
                            _LegalDocumentOB.BUffer_Peripheral_Area_Expert_committee_Date_of_Constitution = expert_date_of_Constitution.Text.Trim() == "" ? (DateTime?)null : miscelBL.getDateFormat(expert_date_of_Constitution.Text);
                            _LegalDocumentOB.Consultation_With_Gram_Sabha = Convert.ToBoolean(ddlConsultation_With_Gram_Sabha.SelectedValue);
                            _LegalDocumentOB.Name_Gram_Sabha = txtnameofgramsabha.Text;
                            if (FUforiamge.HasFile)
                            {
                                string Ext = System.IO.Path.GetExtension(FUforiamge.PostedFile.FileName);
                                string filename = _LegalDocumentOB.Villageid + "_" + "1_Map" + Ext;
                                FUforiamge.SaveAs(Server.MapPath("~/WriteReadData/Legaldocument/" + filename));
                                _LegalDocumentOB.Map_of_CTH = filename;
                            }
                            else
                            {
                                _LegalDocumentOB.Map_of_CTH = hyddisplay.Value.Trim() == "" ? null : hyddisplay.Value.Trim();
                            }
                            if (FileUpload1.HasFile)
                            {
                                string Ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
                                string filename = _LegalDocumentOB.Villageid + "_" + "2_Map" + Ext;
                                FileUpload1.SaveAs(Server.MapPath("~/WriteReadData/Legaldocument/" + filename));
                                _LegalDocumentOB.Map_of_CTH1 = filename;
                            }
                            else
                            {
                                _LegalDocumentOB.Map_of_CTH1 = hydfile2.Value.Trim() == "" ? null : hydfile2.Value.Trim();
                            }
                            if (FileUpload2.HasFile)
                            {
                                string Ext = System.IO.Path.GetExtension(FileUpload2.PostedFile.FileName);
                                string filename = _LegalDocumentOB.Villageid + "_" + "3_Map" + Ext;
                                FileUpload2.SaveAs(Server.MapPath("~/WriteReadData/Legaldocument/" + filename));
                                _LegalDocumentOB.Map_of_CTH2 = filename;
                            }
                            else
                            {
                                _LegalDocumentOB.Map_of_CTH2 = hydfile3.Value.Trim() == "" ? null : hydfile3.Value.Trim();
                            }

                            _LegalDocumentOB.Dweller_Completed = Convert.ToBoolean(ddlForest_Dwellers_Completed.SelectedValue);
                            _LegalDocumentOB.Resettlefment_Provide = Convert.ToBoolean(ddl_Re_settlement_Provided.SelectedValue);
                            _LegalDocumentOB.Free_Informed_obtained = Convert.ToBoolean(ddlResettlement_Obtained.SelectedValue);
                            _LegalDocumentOB.Voluntry_constent_obtained = Convert.ToBoolean(ddlVoluntary_Obtained.SelectedValue);
                            _LegalDocumentOB.Facilities_Land_Allocation_Provided = Convert.ToBoolean(ddl_Facilities_Provided.SelectedValue);
                            _LegalDocumentOB.Sub_Divisional_Level_Committee_Constituted = Convert.ToInt32(ddlSub_DivisionalConstituted.SelectedValue);
                            _LegalDocumentOB.Sub_Divisional_Level_Committee_Date_of_constitution = txtSub_Divisional_Date_of_constitution.Text.Trim() == "" ? (DateTime?)null : miscelBL.getDateFormat(txtSub_Divisional_Date_of_constitution.Text);
                            _LegalDocumentOB.District_Level_Committee_Constituted = Convert.ToInt32(ddlDistrict_Level_Committee_Constituted.SelectedValue);
                            _LegalDocumentOB.District_Level_Committee_Date_of_constitution = txtDistrict_Level_Committee_Date_of_constitution.Text.Trim() == "" ? (DateTime?)null : miscelBL.getDateFormat(txtDistrict_Level_Committee_Date_of_constitution.Text);
                            _LegalDocumentOB.State_Level_Monitoring_Committee_Constituted = Convert.ToInt32(ddlState_Level_Monitoring_Committee_Constituted.SelectedValue);
                            _LegalDocumentOB.State_Level_Monitoring_Committee_Date_of_constitution = txtState_Level_Monitoring_Committee_Date_of_constitution.Text.Trim() == "" ? (DateTime?)null : miscelBL.getDateFormat(txtState_Level_Monitoring_Committee_Date_of_constitution.Text);
                            if (_LegalDocumentBL.InsertUpdateLegalDocoument(_LegalDocumentOB) > 0)
                            {
                                Session["msg"] = "Legal notice for village has been successfully added.";
                                Session["BackUrl"] = "~/auth/adminpanel/Enterform/LegalNotice.aspx";
                                Response.Redirect("~/auth/adminpanel/ConfirmationPage.aspx");
                            }

                        //}
                        //catch
                        //{
                        //    throw;
                        //}

                    }
                }
            }
        }
        //}

        catch
        {
            throw;
        }
       // }
    }
    

    protected void imgbtnreset_Click(object sender, EventArgs e)
    {

    }

    protected void btnback_Click(object sender, EventArgs e)
    {

    }
    private void Bind_LegalDocument()
    {
        pval.dSet = _LegalDocumentBL.Get_legalDocument(1);
        if(pval.dSet.Tables[0].Rows.Count>0)
        {
            DDLCTHNotified.SelectedValue = pval.dSet.Tables[0].Rows[0]["CTH_Notified"].ToString();
            TXTCTHDATEOFNOTIFICATION.Text = pval.dSet.Tables[0].Rows[0]["CTH_DateofNotification"].ToString();
            Txtctharea.Text = pval.dSet.Tables[0].Rows[0]["CTH_Area"].ToString();
            txtCompliance_ofsection38V.Text = pval.dSet.Tables[0].Rows[0]["CTH_Compliance_of_section_38V"].ToString();
            ddlbufferNotified.SelectedValue = pval.dSet.Tables[0].Rows[0]["BUffer_Peripheral_Area_Notified"].ToString();
            txtbufferdateofnotification.Text = pval.dSet.Tables[0].Rows[0]["BUffer_Peripheral_Area_DateofNotification"].ToString();
            txtbufferarea.Text = pval.dSet.Tables[0].Rows[0]["BUffer_Peripheral_Area_Area"].ToString();
            ddlexpert_Constituted.SelectedValue = pval.dSet.Tables[0].Rows[0]["BUffer_Peripheral_Area_Expert_committee_Constituted"].ToString();
            expert_date_of_Constitution.Text = pval.dSet.Tables[0].Rows[0]["BUffer_Peripheral_Area_Expert_committee_Date_of_Constitution"].ToString();
            ddlConsultation_With_Gram_Sabha.SelectedValue = pval.dSet.Tables[0].Rows[0]["Consultation_With_Gram_Sabha"].ToString();
            txtnameofgramsabha.Text= pval.dSet.Tables[0].Rows[0]["Name_Gram_Sabha"].ToString();
            lbldisplay.Text = pval.dSet.Tables[0].Rows[0]["Map_of_CTH"].ToString();
            lblfile2.Text = pval.dSet.Tables[0].Rows[0]["Map_of_CTH1"].ToString();
            lblfile3.Text = pval.dSet.Tables[0].Rows[0]["Map_of_CTH2"].ToString();
            ddlForest_Dwellers_Completed.SelectedValue = pval.dSet.Tables[0].Rows[0]["Dweller_Completed"].ToString();
            ddl_Re_settlement_Provided.SelectedValue = pval.dSet.Tables[0].Rows[0]["Resettlefment_Provide"].ToString();
            ddlResettlement_Obtained.SelectedValue = pval.dSet.Tables[0].Rows[0]["Free_Informed_obtained"].ToString();
            ddlVoluntary_Obtained.SelectedValue = pval.dSet.Tables[0].Rows[0]["Voluntry_constent_obtained"].ToString();
            ddl_Facilities_Provided.SelectedValue = pval.dSet.Tables[0].Rows[0]["Facilities_Land_Allocation_Provided"].ToString();
            ddlSub_DivisionalConstituted.SelectedValue = pval.dSet.Tables[0].Rows[0]["Sub_Divisional_Level_Committee_Constituted"].ToString();
            txtSub_Divisional_Date_of_constitution.Text = pval.dSet.Tables[0].Rows[0]["Sub_Divisional_Level_Committee_Date_of_constitution"].ToString();
            ddlDistrict_Level_Committee_Constituted.SelectedValue = pval.dSet.Tables[0].Rows[0]["District_Level_Committee_Constituted"].ToString();
            txtDistrict_Level_Committee_Date_of_constitution.Text = pval.dSet.Tables[0].Rows[0]["District_Level_Committee_Date_of_constitution"].ToString();
            ddlState_Level_Monitoring_Committee_Constituted.SelectedValue = pval.dSet.Tables[0].Rows[0]["State_Level_Monitoring_Committee_Constituted"].ToString();
            txtState_Level_Monitoring_Committee_Date_of_constitution.Text = pval.dSet.Tables[0].Rows[0]["State_Level_Monitoring_Committee_Date_of_constitution"].ToString();
        }
    }
}