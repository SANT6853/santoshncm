using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FamilyBL
/// </summary>
public class FamilyBL
{
    FamilyDL _familydl = new FamilyDL();
    public FamilyBL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet Get_AnimalByfamily(int Familyid)
    {
       return _familydl.Get_AnimalByfamily(Familyid);
    }

    public DataSet Get_FamilyMemeberList(int familyid)
    {
        return _familydl.Get_FamilyMemeberList(familyid);
    }
    public int InsertFamilydetiails(FamilyOB _familyOb, DataTable dtfamilyanimal, DataTable dtfamilymember)
    {
        return _familydl.InsertFamilydetiails(_familyOb, dtfamilyanimal, dtfamilymember);
    }
    public int Asp_Update_Family_Detials(FamilyOB _familyOb, DataTable dtfamilyanimal, DataTable dtfamilymember)
    {
        return _familydl.Asp_Update_Family_Detials(_familyOb, dtfamilyanimal, dtfamilymember);
    }
    public DataSet get_FamilyList(FamilyOB _familyOb)
    {
        return _familydl.get_FamilyList(_familyOb);
    }
    public DataSet Asp_GetFamilyDetialsForEdit(int familyid)
    {
        return _familydl.Asp_GetFamilyDetialsForEdit(familyid);
    }
}