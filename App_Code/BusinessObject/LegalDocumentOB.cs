using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LegalDocumentOB
/// </summary>
public class LegalDocumentOB
{
    public LegalDocumentOB()
    {
        //
        // TODO: Add constructor logic here
        //
    }
public int? Legal_id { get; set; }
public int? Villageid { get; set; }
    public Boolean ? CTH_Notified { get; set; }
    public DateTime ? CTH_DateofNotification { get; set; }
    public decimal ? CTH_Area { get; set; }
    public string CTH_Compliance_of_section_38V { get; set; }
    public Boolean? BUffer_Peripheral_Area_Notified { get; set; }
    public DateTime ? BUffer_Peripheral_Area_DateofNotification { get; set; }
    public decimal? BUffer_Peripheral_Area_Area { get; set; }
    public Boolean? BUffer_Peripheral_Area_Expert_committee_Constituted { get; set; }
    public DateTime? BUffer_Peripheral_Area_Expert_committee_Date_of_Constitution { get; set; }
    public Boolean? Consultation_With_Gram_Sabha { get; set; }
    public string Name_Gram_Sabha { get; set; }
    public string Map_of_CTH { get; set; }
    public string Map_of_CTH1 { get; set; }
    public string Map_of_CTH2 { get; set; }
    public Boolean? Dweller_Completed { get; set; }
    public Boolean? Resettlefment_Provide { get; set; }
    public Boolean? Free_Informed_obtained { get; set; }
    public Boolean? Voluntry_constent_obtained { get; set; }
    public Boolean? Facilities_Land_Allocation_Provided { get; set; }
    public int? Sub_Divisional_Level_Committee_Constituted { get; set; }
    public DateTime? Sub_Divisional_Level_Committee_Date_of_constitution { get; set; }

    public int? District_Level_Committee_Constituted { get; set; }
    public DateTime? District_Level_Committee_Date_of_constitution { get; set; }

    public int? State_Level_Monitoring_Committee_Constituted { get; set; }
    public DateTime? State_Level_Monitoring_Committee_Date_of_constitution { get; set; }

}