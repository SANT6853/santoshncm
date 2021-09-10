using NCM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for LegalDocumentDL
/// </summary>
public class LegalDocumentDL
{
    NCMdbAccess ncmdbObject = new NCMdbAccess();
    Project_Variables p_Val = new Project_Variables();

    public LegalDocumentDL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataSet Get_legalDocument(int _VillageId)
    {
        try
        {

            ncmdbObject.AddParameter("@VillageId", _VillageId);

            return ncmdbObject.ExecuteDataSet("Get_legal_document");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    public int InsertUpdateLegalDocoument(LegalDocumentOB _LegalDocumentOB)
    {
        try
        {
            ncmdbObject.AddParameter("@Villageid", _LegalDocumentOB.Villageid);
            ncmdbObject.AddParameter("@CTH_Notified", _LegalDocumentOB.CTH_Notified);
            ncmdbObject.AddParameter("@CTH_DateofNotification", _LegalDocumentOB.CTH_DateofNotification);
            ncmdbObject.AddParameter("@CTH_Area", _LegalDocumentOB.CTH_Area);
            ncmdbObject.AddParameter("@CTH_Compliance_of_section_38V", _LegalDocumentOB.CTH_Compliance_of_section_38V);
            ncmdbObject.AddParameter("@BUffer_Peripheral_Area_Notified", _LegalDocumentOB.BUffer_Peripheral_Area_Notified);
            ncmdbObject.AddParameter("@BUffer_Peripheral_Area_DateofNotification", _LegalDocumentOB.BUffer_Peripheral_Area_DateofNotification);
            ncmdbObject.AddParameter("@BUffer_Peripheral_Area_Area", _LegalDocumentOB.BUffer_Peripheral_Area_Area);
            ncmdbObject.AddParameter("@BUffer_Peripheral_Area_Expert_committee_Constituted", _LegalDocumentOB.BUffer_Peripheral_Area_Expert_committee_Constituted);
            ncmdbObject.AddParameter("@BUffer_Peripheral_Area_Expert_committee_Date_of_Constitution", _LegalDocumentOB.BUffer_Peripheral_Area_Expert_committee_Date_of_Constitution);
            ncmdbObject.AddParameter("@Consultation_With_Gram_Sabha", _LegalDocumentOB.Consultation_With_Gram_Sabha);
            ncmdbObject.AddParameter("@Name_Gram_Sabha", _LegalDocumentOB.Name_Gram_Sabha);
            ncmdbObject.AddParameter("@Map_of_CTH", _LegalDocumentOB.Map_of_CTH);
            ncmdbObject.AddParameter("@Map_of_CTH1", _LegalDocumentOB.Map_of_CTH1);
            ncmdbObject.AddParameter("@Map_of_CTH2", _LegalDocumentOB.Map_of_CTH2);
            ncmdbObject.AddParameter("@Dweller_Completed", _LegalDocumentOB.Dweller_Completed);
            ncmdbObject.AddParameter("@Resettlefment_Provide", _LegalDocumentOB.Resettlefment_Provide);
            ncmdbObject.AddParameter("@Free_Informed_obtained", _LegalDocumentOB.Free_Informed_obtained);
            ncmdbObject.AddParameter("@Voluntry_constent_obtained", _LegalDocumentOB.Voluntry_constent_obtained);
            ncmdbObject.AddParameter("@Facilities_Land_Allocation_Provided", _LegalDocumentOB.Facilities_Land_Allocation_Provided);
            ncmdbObject.AddParameter("@Sub_Divisional_Level_Committee_Constituted", _LegalDocumentOB.Sub_Divisional_Level_Committee_Constituted);
            ncmdbObject.AddParameter("@Sub_Divisional_Level_Committee_Date_of_constitution", _LegalDocumentOB.Sub_Divisional_Level_Committee_Date_of_constitution);
            ncmdbObject.AddParameter("@District_Level_Committee_Constituted", _LegalDocumentOB.District_Level_Committee_Constituted);
            ncmdbObject.AddParameter("@District_Level_Committee_Date_of_constitution", _LegalDocumentOB.District_Level_Committee_Date_of_constitution);
            ncmdbObject.AddParameter("@State_Level_Monitoring_Committee_Constituted", _LegalDocumentOB.State_Level_Monitoring_Committee_Constituted);
            ncmdbObject.AddParameter("@State_Level_Monitoring_Committee_Date_of_constitution", _LegalDocumentOB.State_Level_Monitoring_Committee_Date_of_constitution);

            return ncmdbObject.ExecuteNonQuery("Insert_Update_LegalDocument");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
}