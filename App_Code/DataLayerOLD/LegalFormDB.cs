using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using NCM.DAL;

/// <summary>
/// Summary description for LegalForm
/// </summary>
public class LegalFormDB
{
	public LegalFormDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    NCMdbAccess ObjDB = new NCMdbAccess();
    public bool Add_LegalForm_I(Legalnfo_I_Entity LglI_ENT_Obj)
    {
        try
        {
            
            ObjDB.AddParameter("@DontDrpList1", LglI_ENT_Obj._DontDrpList1);
            ObjDB.AddParameter("@DontDrpList2", LglI_ENT_Obj._DontDrpList2);
            ObjDB.AddParameter("@DontDrpList3", LglI_ENT_Obj._DontDrpList3);
            ObjDB.AddParameter("@DontDrpList4", LglI_ENT_Obj._DontDrpList4);
            ObjDB.AddParameter("@DontDrpList5", LglI_ENT_Obj._DontDrpList5);
            ObjDB.AddParameter("@DontDrpList6", LglI_ENT_Obj._DontDrpList6);
            ObjDB.AddParameter("@DontDrpList7", LglI_ENT_Obj._DontDrpList7);
            ObjDB.AddParameter("@DontDrpList8", LglI_ENT_Obj._DontDrpList8);
            ObjDB.AddParameter("@DontDrpList9", LglI_ENT_Obj._DontDrpList9);
            ObjDB.AddParameter("@DontDrpList10", LglI_ENT_Obj._DontDrpList10);
            ObjDB.AddParameter("@DontDrpList11", LglI_ENT_Obj._DontDrpList11);
            ObjDB.AddParameter("@DontDrpList12", LglI_ENT_Obj._DontDrpList12);

            ObjDB.AddParameter("@txtdate1", LglI_ENT_Obj._txtdate1);
            ObjDB.AddParameter("@txtdate2", LglI_ENT_Obj._txtdate2);
            ObjDB.AddParameter("@txtdate3", LglI_ENT_Obj._txtdate3);
            ObjDB.AddParameter("@txtdate4", LglI_ENT_Obj._txtdate4);
            ObjDB.AddParameter("@txtdate5", LglI_ENT_Obj._txtdate5);
            ObjDB.AddParameter("@txtdate6", LglI_ENT_Obj._txtdate6);

            ObjDB.AddParameter("@textbox1", LglI_ENT_Obj._textbox1);
            ObjDB.AddParameter("@textbox2", LglI_ENT_Obj._textbox2);
            ObjDB.AddParameter("@textbox3", LglI_ENT_Obj._textbox3);
            ObjDB.AddParameter("@textbox4", LglI_ENT_Obj._textbox4);
            ObjDB.AddParameter("@textbox5", LglI_ENT_Obj._textbox5);

            ObjDB.AddParameter("@LGL_MAP_MG", LglI_ENT_Obj._LGL_MAP_MG);
            ObjDB.AddParameter("@LGL_MAP_SECOND",LglI_ENT_Obj._LEGL_MAP_SECOND);
            ObjDB.AddParameter("@LGL_MAP_THIRD", LglI_ENT_Obj._LEGL_MAP_THIRD);
            ObjDB.AddParameter("@VILL_ID", LglI_ENT_Obj._VILL_ID);

            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Insert_LegalInfoI_new");
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

     public bool Update_LegalForm(Legalnfo_I_Entity LglI_ENT_Obj)
    {
         try
        {
             
            
            ObjDB.AddParameter("@DontDrpList1", LglI_ENT_Obj._DontDrpList1);
            ObjDB.AddParameter("@DontDrpList2", LglI_ENT_Obj._DontDrpList2);
            ObjDB.AddParameter("@DontDrpList3", LglI_ENT_Obj._DontDrpList3);
            ObjDB.AddParameter("@DontDrpList4", LglI_ENT_Obj._DontDrpList4);
            ObjDB.AddParameter("@DontDrpList5", LglI_ENT_Obj._DontDrpList5);
            ObjDB.AddParameter("@DontDrpList6", LglI_ENT_Obj._DontDrpList6);
            ObjDB.AddParameter("@DontDrpList7", LglI_ENT_Obj._DontDrpList7);
            ObjDB.AddParameter("@DontDrpList8", LglI_ENT_Obj._DontDrpList8);
            ObjDB.AddParameter("@DontDrpList9", LglI_ENT_Obj._DontDrpList9);
            ObjDB.AddParameter("@DontDrpList10", LglI_ENT_Obj._DontDrpList10);
            ObjDB.AddParameter("@DontDrpList11", LglI_ENT_Obj._DontDrpList11);
            ObjDB.AddParameter("@DontDrpList12", LglI_ENT_Obj._DontDrpList12);

            ObjDB.AddParameter("@txtdate1", LglI_ENT_Obj._txtdate1);
            ObjDB.AddParameter("@txtdate2", LglI_ENT_Obj._txtdate2);
            ObjDB.AddParameter("@txtdate3", LglI_ENT_Obj._txtdate3);
            ObjDB.AddParameter("@txtdate4", LglI_ENT_Obj._txtdate4);
            ObjDB.AddParameter("@txtdate5", LglI_ENT_Obj._txtdate5);
            ObjDB.AddParameter("@txtdate6", LglI_ENT_Obj._txtdate6);

            ObjDB.AddParameter("@textbox1", LglI_ENT_Obj._textbox1);
            ObjDB.AddParameter("@textbox2", LglI_ENT_Obj._textbox2);
            ObjDB.AddParameter("@textbox3", LglI_ENT_Obj._textbox3);
            
            ObjDB.AddParameter("@textbox5", LglI_ENT_Obj._textbox5);

            ObjDB.AddParameter("@LGL_MAP_MG", LglI_ENT_Obj._LGL_MAP_MG);
            ObjDB.AddParameter("@LGL_MAP_SECOND", LglI_ENT_Obj._LEGL_MAP_SECOND);
            ObjDB.AddParameter("@LGL_MAP_THIRD", LglI_ENT_Obj._LEGL_MAP_THIRD);
           
            ObjDB.AddParameter("@VILL_ID", LglI_ENT_Obj._VILL_ID);

            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Update_LegalInfoI");
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


    public DataSet Edit_LegalForm(string  vilcode)
    {
        ObjDB.AddParameter("@VILL_ID", vilcode);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_LegalInfoI");
    
    }
      

   
}
