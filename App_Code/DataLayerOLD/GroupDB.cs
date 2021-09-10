using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NCM.DAL;

/// <summary>
/// Summary description for GroupDB
/// </summary>
public class GroupDB
{
    NCMdbAccess ObjDB = new NCMdbAccess();
    public bool Add_Group(GroupEntity GRPENT_Obj)
    {
        try
        {

            ObjDB.AddParameter("@GRP_NM", GRPENT_Obj._GRP_NM);
            ObjDB.AddParameter("@VILL_ID", GRPENT_Obj._VILL_ID);
            ObjDB.AddParameter("@SCHM_ID", GRPENT_Obj._SCHM_ID);
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Insert_Info_Group");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public DataSet CheckDuplicacyForGroup(string grpname,string villid)
    {
        ObjDB.AddParameter("@GRP_NM", grpname);
        ObjDB.AddParameter("@VILL_ID", villid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Check_Duplicacy_ForGroup");

    }
    public DataSet DislpayGroupByGroupID(string grpid)
    {
        ObjDB.AddParameter("@GRP_ID", grpid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_DislpayGroupByGroupID");

    }

    
    public DataSet Display_All_GroupDB( string villid)
    {
        ObjDB.AddParameter("@VILL_ID", villid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_Info_Groups");

    }
    //public bool Update_Group_For_Family(string grpid, string fid)
    //{
    //    try
    //    {
    //        ObjDB.AddParameter("@GRP_ID", grpid);
    //        ObjDB.AddParameter("@FMLY_ID", fid);

    //        int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Update_Group_For_Family");
    //        if (i > 0)
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //    catch (Exception e)
    //    {
    //        return false;
    //    }
    //}
    public bool UpdateGroup(string name, string grpid)
    {
        try
        {

            ObjDB.AddParameter("@GRP_NM", name);
            ObjDB.AddParameter("@GRP_ID", grpid);
          
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Update_Info_Group");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }
	
}
