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
/// Summary description for NgoDB
/// </summary>
public class NgoDB
{
    NCMdbAccess ObjDB = new NCMdbAccess();
    NgoEntity NE = new NgoEntity();
    public NgoDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    //  public bool AddNgo()
    // {
    //  //    try
    //  //    {

    //  //        ObjDB.AddParameter("@NGO_Vill_ID", Obj_NgoEnt._NGO_Vill_ID);

    //  //        ObjDB.AddParameter("@CDP_TOT_ALLTD_AMT", Obj_NgoEnt._NGO_NAME);
    //  //        ObjDB.AddParameter("@CDP_TOT_AMT_USD", INFOEnt_Obj._CDP_AMT_USD);
    //  //        ObjDB.AddParameter("@CDP_WORK", INFOEnt_Obj._CDP_WORK);
    //  //        ObjDB.AddParameter("@CDP_EXECUTION_AGENCY", INFOEnt_Obj._CDP_EXECUTION_AGENCY);
    //  //        ObjDB.AddParameter("@COMMENT", INFOEnt_Obj._COMMENT);
    //  //        ObjDB.AddParameter("@RELOCATION_ID", INFOEnt_Obj._CDP_RELOCATION_ID);

    //  //        int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Insert_Info_CDP");
    //  //        if (i > 0)
    //  //        {
    //  //            return true;
    //  //        }
    //  //        else
    //  //        {
    //  //            return false;
    //  //        }
    //  //    }
    //  //    catch (Exception e)
    //  //    {
    //  //        return false;
    //  //    }
    //}
    public DataSet Proc_DisplayNGODetail(string v_id)
    {
        ObjDB.AddParameter("@VILL_ID", v_id);
        return ObjDB.ExecuteDataSet("fech_ngo_with_village");

    }
    public DataSet Proc_DisplayNGODetailByNGOID(string ngoid)
    {
        ObjDB.AddParameter("@NGO_ID", ngoid);
        return ObjDB.ExecuteDataSet("Proc_DisplayNGODetailByNGOID");

    }
   
    public bool Proc_UpdateNGODetail(NgoEntity NE)
    {
        try
        {
            ObjDB.AddParameter("@NGO_ID", NE._NGO_ID);
            ObjDB.AddParameter("@NGO_NAME", NE._NGO_NAME);
            ObjDB.AddParameter("@NGO_Amount", NE._NGO_Amount);
            ObjDB.AddParameter("@NGO_Work", NE._NGO_Work);

            int i = ObjDB.ExecuteNonQuery("Proc_UpdateNGODetail");
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
    public bool AddIn_Ngo_Info(NgoEntity Obj_NgoEnt,long viilid)
    {
        try
        {


            ObjDB.AddParameter("@VILL_ID", viilid);
            ObjDB.AddParameter("@NGO_NAME", Obj_NgoEnt._NGO_NAME);
            ObjDB.AddParameter("@NGO_Amount", Obj_NgoEnt._NGO_Amount);
            ObjDB.AddParameter("@NGO_Work", Obj_NgoEnt._NGO_Work);

            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Insert_Ngo_Info");
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