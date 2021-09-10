using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_SurveyForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
  
    protected void RdbPanchayatOffice_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbPanchayatOffice.SelectedValue == "Yes")
        {
            TxtRdbPanchayatOffice.Visible = true;
        }
        else
        {
            TxtRdbPanchayatOffice.Visible = false;
        }
    }
    protected void RdbAnganwadi_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbAnganwadi.SelectedValue == "Yes")
        {
            TxtRdbAnganwadi.Visible = true;
        }
        else
        {
            TxtRdbAnganwadi.Visible = false;
        }
    }
    protected void RdbAllWeatherRoad_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbAllWeatherRoad.SelectedValue == "Yes")
        {
            TxtRdbAllWeatherRoad.Visible = true;
        }
        else
        {
            TxtRdbAllWeatherRoad.Visible = false;
        }
    }
    protected void RdbPostOffice_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbPostOffice.SelectedValue == "Yes")
        {
            TxtRdbPostOffice.Visible = true;
        }
        else
        {
            TxtRdbPostOffice.Visible = false;
        }
    }
    protected void RdbBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbBank.SelectedValue == "Yes")
        {
            TxtRdbBank.Visible = true;
        }
        else
        {
            TxtRdbBank.Visible = false;
        }
    }
    protected void RdbPDSShop_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbPDSShop.SelectedValue == "Yes")
        {
            TxtRdbPDSShop.Visible = true;
        }
        else
        {
            TxtRdbPDSShop.Visible = false;
        }
    }
    protected void RdbPublicTelephonePCo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbPublicTelephonePCo.SelectedValue == "Yes")
        {
            TxtRdbPublicTelephonePCo.Visible = true;
        }
        else
        {
            TxtRdbPublicTelephonePCo.Visible = false;
        }
    }
    protected void RdbMobileSignal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbMobileSignal.SelectedValue == "Yes")
        {
            TxtRdbMobileSignal.Visible = true;
        }
        else
        {
            TxtRdbMobileSignal.Visible = false;
        }
    }
    protected void RdbAccessibiliythealthCare_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbAccessibiliythealthCare.SelectedValue == "Yes")
        {
            TxtAccessibiliythealthCare.Visible = true;
        }
        else
        {
            TxtAccessibiliythealthCare.Visible = false;
        }
    }
    protected void RdbAccessibiliyRoad_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbAccessibiliyRoad.SelectedValue == "Yes")
        {
            TxtAccessibiliyRoad.Visible = true;
        }
        else
        {
            TxtAccessibiliyRoad.Visible = false;
        }
    }
    protected void RdbAccessbilitySchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbAccessbilitySchool.SelectedValue == "Yes")
        {

            TxtAccessbilitySchoolPrimary.Visible = true;
            TxtAccessbilitySchool_Secondary.Visible = true;
            TxtAccessbilitySchool_HighSchool.Visible = true;
            TxtAccessbilitySchool_College.Visible = true;
        }
        else
        {
            TxtAccessbilitySchoolPrimary.Visible = false;
            TxtAccessbilitySchool_Secondary.Visible = false;
            TxtAccessbilitySchool_HighSchool.Visible = false;
            TxtAccessbilitySchool_College.Visible = false;
        }
    }
    protected void RdbAccessbilityElectrif_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbAccessbilityElectrif.SelectedValue == "Yes")
        {
            TxtAccessbilityElectrif_DurationElectricityVillages.Visible = true;
           // TxtAccessbilityElectrif_households.Visible = true;
            lblRdbAccessbilityElectrif.Visible = true;
        }
        else
        {
            TxtAccessbilityElectrif_DurationElectricityVillages.Visible = false;
           // TxtAccessbilityElectrif_households.Visible = false;
            lblRdbAccessbilityElectrif.Visible = false;
        }
    }
    protected void RdbAccessiblityVeterinary_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbAccessiblityVeterinary.SelectedValue == "Yes")
        {
            TxtAccessiblityVeterinary.Visible = true;
           
        }
        else
        {
            TxtAccessiblityVeterinary.Visible = false;
           
        }
    }
    protected void RdbAvenuesEmployment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbAvenuesEmployment.SelectedValue == "Yes")
        {
            TxtAvenuesEmployment_Primary.Visible = true;
            TxtAvenuesEmployment_Secondary.Visible = true;
            lblRdbAvenuesEmployment1.Visible = true;
            lblRdbAvenuesEmployment2.Visible = true;
        }
        else
        {
            TxtAvenuesEmployment_Primary.Visible = false;
            TxtAvenuesEmployment_Secondary.Visible = false;
            lblRdbAvenuesEmployment1.Visible = false;
            lblRdbAvenuesEmployment2.Visible = false;
        }
    }
    protected void RdbHumanWildlifecon_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbHumanWildlifecon.SelectedValue == "Yes")
        {
            TxtRdbHumanWildlifecon.Visible = true;
            lblRdbHumanWildlifecon.Visible = true;
        }
        else
        {
            TxtRdbHumanWildlifecon.Visible = false;
            lblRdbHumanWildlifecon.Visible = false;
           
        }
    }
    protected void RdbAccessFireFodNwfps_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbAccessFireFodNwfps.SelectedValue == "Yes")
        {
            TXTAccessFireFodNwfps.Visible = true;
            lblRdbAccessFireFodNwfps.Visible = true;
        }
        else
        {
            TXTAccessFireFodNwfps.Visible = false;
            lblRdbAccessFireFodNwfps.Visible = false;

        }
    }
}