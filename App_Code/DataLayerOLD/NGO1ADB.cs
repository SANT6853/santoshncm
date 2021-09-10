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
/// Summary description for NGO1ADB
/// </summary>
public class NGO1ADB
{
    NCMdbAccess ObjDB = new NCMdbAccess();
    public DataSet Proc_DisplayNGODetail(string R_id)
    {
        ObjDB.AddParameter("@RSRV_ID", R_id);
        return ObjDB.ExecuteDataSet("Proc_DisplayNGODetailFor1A");

    }
    public DataSet Proc_DisplayNGODetailByNGOID(string ngoid)
    {
        ObjDB.AddParameter("@ID", ngoid);
        return ObjDB.ExecuteDataSet("Proc_DisplayNGODetailByNGOID_For1A");

    }

    public bool AddIn_Ngo_Info(NGO_1A_ENTITY Obj_NgoEnt)
    {
        try
        {


            ObjDB.AddParameter("@RSRV_ID", Obj_NgoEnt._RSRV_ID);
            ObjDB.AddParameter("@NAME", Obj_NgoEnt._NAME);
            ObjDB.AddParameter("@ADDRESS", Obj_NgoEnt._ADDRESS);
            ObjDB.AddParameter("@CONTACT_NO", Obj_NgoEnt._CONTACT_NO);
            ObjDB.AddParameter("@PERSONS", Obj_NgoEnt._PERSONS);
            int i = ObjDB.ExecuteNonQuery("[Proc_Tiger_Insert_Ngo_Info_For1A]");
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
    public bool Proc_UpdateNGODetail_For1A(NGO_1A_ENTITY Obj_NgoEnt)
    {
        try
        {
            ObjDB.AddParameter("@ID", Obj_NgoEnt._ID);
            ObjDB.AddParameter("@NAME", Obj_NgoEnt._NAME);
            ObjDB.AddParameter("@ADDRESS", Obj_NgoEnt._ADDRESS);
            ObjDB.AddParameter("@CONTACT_NO", Obj_NgoEnt._CONTACT_NO);
            ObjDB.AddParameter("@PERSONS", Obj_NgoEnt._PERSONS);
            int i = ObjDB.ExecuteNonQuery("Proc_UpdateNGODetail_For1A");
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
    public bool Add_ngo_work_info(NGO_1A_Work_Entity Obj_NgoEnt,string familyid,string familycode)
    {
        try
        {


            ObjDB.AddParameter("@NGO_ID", Obj_NgoEnt._NGO_ID);
            ObjDB.AddParameter("@FMLY_ID", familyid);
            ObjDB.AddParameter("@FMLY_REG_CD", familycode);
            ObjDB.AddParameter("@DESCRIPTION", Obj_NgoEnt._DESCRIPTION);
            ObjDB.AddParameter("@REMARK", Obj_NgoEnt._REMARK);
            ObjDB.AddParameter("@WORK_ID", Obj_NgoEnt._WORK_ID);
            ObjDB.AddParameter("@VILL_ID", Obj_NgoEnt._VILL_ID);
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Add_ngo_work_info");
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

    public bool Proc_UpdateNGO_work(NGO_1A_Work_Entity Obj_NgoEnt)
    {
        try
        {
            ObjDB.AddParameter("@ID", Obj_NgoEnt._ID);
            ObjDB.AddParameter("@DESCRIPTION", Obj_NgoEnt._DESCRIPTION);
            ObjDB.AddParameter("@REMARK", Obj_NgoEnt._REMARK);
            int i = ObjDB.ExecuteNonQuery("Proc_UpdateNGO_work");
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
    public DataSet Proc_DisplayNGOWorkDetailByID(string id)
    {
        ObjDB.AddParameter("@ID", id);
        return ObjDB.ExecuteDataSet("Proc_DisplayNGOWorkDetailByID");

    }
    public DataSet DISPLAY_FAMILY_FOR_NGO1A(string ngo, string villid, string workid )
    {
        ObjDB.AddParameter("@NGOID", ngo);
        ObjDB.AddParameter("@VILL_ID", villid);
        ObjDB.AddParameter("@WORK_ID", workid);
        return ObjDB.ExecuteDataSet("PROC_DISPLAY_FAMILY_FOR_NGO1A");

    }
    public DataSet DISPLAY_FAMILY_FOR_NGO1A_For_View(string wid)
    {
        ObjDB.AddParameter("@WORK_1A_ID", wid);
     
        return ObjDB.ExecuteDataSet("PROC_DISPLAY_FAMILY_FOR_NGO1A_For_View");

    }

    public bool Delete_family_For_NGO_1A(string wid)
    {
        try
        {
            ObjDB.AddParameter("@ID", wid);

            int i = ObjDB.ExecuteNonQuery("Proc_Delete_family_For_NGO_1A");
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
    public DataSet Proc_Display_NGO_1A_For_Report(string vid)
    {
        ObjDB.AddParameter("@VILL_ID", vid);

        return ObjDB.ExecuteDataSet("Proc_Display_NGO_1A_For_Report");

    }
    public DataSet Proc_Display_NGO_1A_For_Report2(string vid, string nid, string wid)
    {
        ObjDB.AddParameter("@VILL_ID", vid);
        ObjDB.AddParameter("@WORK_ID", wid);
        ObjDB.AddParameter("@NGOID",nid );

        return ObjDB.ExecuteDataSet("Proc_Display_NGO_1A_For_Report2");

    }

}
