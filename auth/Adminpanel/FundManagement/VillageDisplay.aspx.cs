using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Data;
public partial class auth_Adminpanel_FundManagement_VillageDisplay : System.Web.UI.Page
{
    FunbDL _funbDL = new FunbDL();
    Project_Variables p_var = new Project_Variables();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_VillageDetails(Convert.ToInt32(Request.QueryString["vid"]));
        }
    }
    void Bind_VillageDetails(int villageid)
    {
        p_var.dSet = _funbDL.Get_VillageDetailsForDisplay_FundSenction(villageid);
        if (p_var.dSet.Tables[0].Rows.Count > 0)
        {
            lblstate.Text = p_var.dSet.Tables[0].Rows[0]["StateName"].ToString();
            lbltigerReserves.Text = p_var.dSet.Tables[0].Rows[0]["TigerReserveName"].ToString();
            LblDistrict.Text = p_var.dSet.Tables[0].Rows[0]["DistName"].ToString();
            lblTehshil.Text = p_var.dSet.Tables[0].Rows[0]["Tehsil_Name"].ToString();
            lblGramPanchayat.Text = p_var.dSet.Tables[0].Rows[0]["GramPanchayatName"].ToString();
            lblVillageName.Text = p_var.dSet.Tables[0].Rows[0]["Village_Name"].ToString();
            lblLegalStatus.Text = p_var.dSet.Tables[0].Rows[0]["LegalStatus"].ToString();
            lblStatus.Text = p_var.dSet.Tables[0].Rows[0]["RelocationStatusID"].ToString();
            lblArea.Text = p_var.dSet.Tables[0].Rows[0]["AreaType"].ToString();
            lblDateofsurvey.Text = p_var.dSet.Tables[0].Rows[0]["DateofSurvey"].ToString();
            lblDateofConsenment.Text = p_var.dSet.Tables[0].Rows[0]["DateofConcenment"].ToString();
            lblAgricultureLand.Text = p_var.dSet.Tables[0].Rows[0]["Agriculture_Land"].ToString();
            lblResidentialproperty.Text = p_var.dSet.Tables[0].Rows[0]["Residential_property"].ToString();
            lblTotalStandingTrees.Text = p_var.dSet.Tables[0].Rows[0]["Total_Standing_Trees"].ToString();
            lblTotalLivestock.Text = p_var.dSet.Tables[0].Rows[0]["Total_Livestock"].ToString();
            lblTotalwell.Text = p_var.dSet.Tables[0].Rows[0]["Total_well"].ToString();
            lblRelocatedfrom.Text = p_var.dSet.Tables[0].Rows[0]["Relocated_from"].ToString();
            lblRelocatedplace.Text = p_var.dSet.Tables[0].Rows[0]["Relocated_place"].ToString();
            lblGPScoordinatesofCurrentlocationlat.Text = p_var.dSet.Tables[0].Rows[0]["Current_location_Latitude"].ToString();
            lblGPScoordinatesofCurrentlocationplacelag.Text = p_var.dSet.Tables[0].Rows[0]["Current_location_Longitude"].ToString();
            lblGPScoordinatesofRelocatedFromlag.Text = p_var.dSet.Tables[0].Rows[0]["location_Latitude_From"].ToString();
            lblGPScoordinatesofRelocatedFromlat.Text = p_var.dSet.Tables[0].Rows[0]["location_Longitude_From"].ToString();
            lbtother.Text = p_var.dSet.Tables[0].Rows[0]["Other_Assets"].ToString();

            StringBuilder sbfamily=new StringBuilder();
           


              if( p_var.dSet.Tables[1].Rows.Count>0)
              {
                  sbfamily.Append("<table class='table tabbable-line'>");
                    sbfamily.Append("<tr>");
                        sbfamily.Append("<td>Familyid</td>");
                  sbfamily.Append("<td>Head Name</td>");
                  sbfamily.Append("<td>Agriculature land</td>");
                  sbfamily.Append("<td>Total Livestock</td>");
                  sbfamily.Append("<td>Total Tree</td>");
                  sbfamily.Append("<td>Total Well</td>");
                  sbfamily.Append("<td>Total Family</td>");
                        sbfamily.Append("</tr>");
                  foreach(DataRow dr in p_var.dSet.Tables[1].Rows)
                  {
                      sbfamily.Append("<tr>");
                        sbfamily.Append("<td>"+dr["familyid"].ToString()+"</td>");
                   sbfamily.Append("<td>"+dr["Head_Name"].ToString()+"</td>");
                   sbfamily.Append("<td>"+dr["Agriculature_land"].ToString()+"</td>");
                   sbfamily.Append("<td>"+dr["Total_Livestock"].ToString()+"</td>");
                   sbfamily.Append("<td>"+dr["Total_Tree"].ToString()+"</td>");
                   sbfamily.Append("<td>"+dr["Total_Well"].ToString()+"</td>");
                   sbfamily.Append("<td>"+dr["TotalFamily"].ToString()+"</td>");
                        sbfamily.Append("</tr>");
                  }
              }
            ltrfamilytable.Text=sbfamily.ToString();
           // grdfamily.DataSource = p_var.dSet.Tables[1];
          //  grdfamily.DataBind();
        }
    }
}