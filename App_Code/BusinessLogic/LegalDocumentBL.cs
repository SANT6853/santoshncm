using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LegalDocumentBL
/// </summary>
public class LegalDocumentBL
{
    LegalDocumentDL _LegalDocumentDL = new LegalDocumentDL();
    public LegalDocumentBL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataSet Get_legalDocument(int _VillageId)
    {
        return _LegalDocumentDL.Get_legalDocument(_VillageId);
    }
    public int InsertUpdateLegalDocoument(LegalDocumentOB _LegalDocumentOB)
    {
        return _LegalDocumentDL.InsertUpdateLegalDocoument(_LegalDocumentOB);
    }
}