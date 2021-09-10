using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NtcaUser
/// </summary>
public class NtcaUserOB
{
    public NtcaUserOB()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int ? UserID { get; set; }
    public string SchemeName { get; set; }
    public string SNo { get; set; }
    public int? ConversionID { get; set; }
    public int? TigerReserveid { get; set; }
    public int? FeedBackFormID { get; set; }
    public int? StateID { get; set; }//userType
    public int? FromVill_ID { get; set; }
    public string UserName { get; set; }
    public string TigerReserveName { get; set; }
    public string StateName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public int? UserType { get; set; }
    public string EmailID { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public int? State { get; set; }
    public int? Dist { get; set; }
    public int? TehshilID { get; set; }
    public int? DataOperatorParentUserID { get; set; }
    public string pincode { get; set; }
    public string Landline { get; set; }
    public string AreaCode { get; set; }
    public string Mobile { get; set; }
    public Boolean Status { get; set; }

    public string LangId { get; set; }
    public string ModuleID { get; set; }
    public string VillageName { get; set; }
    //naren
    public int? ParentTigerReserveUserID { get; set; }
    public int? DataOperatorUserID { get; set; }
    public int? TigerReserveID { get; set; }
    public int? Action { get; set; }
   // public string sAction { get; set; }
    //public int? TigerReserveID { get; set; }
    public string sAction { get; set; }
    //----------------------
    public string StateIDParameters { get; set; }
    public string TigerReseveIDParameters { get; set; }
    public string VillId { get; set; }
    public string FamilyHeadID { get; set; }
    public string FamilyMemeberID { get; set; }
    public string FamilyHeadPlusFamilyMemeberID { get; set; }
}