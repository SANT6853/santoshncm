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
/// Summary description for BankDB
/// </summary>
public class BankDB
{
    NCMdbAccess ObjDB = new NCMdbAccess();
    public bool AddBankDB(Bank_Entity BNKENT_Obj,StateEntity STENT_Obj,DistrictEntity DTENT_Obj)
    {
        try
        {
            ObjDB.AddParameter("@BANK_CD", BNKENT_Obj._BANK_CD);
            ObjDB.AddParameter("@BANK_NAME", BNKENT_Obj._BANK_NAME);
            ObjDB.AddParameter("@BANK_ADDRESS", BNKENT_Obj._BANK_ADDRESS);
            ObjDB.AddParameter("@ST_ID", STENT_Obj._ST_ID);
            ObjDB.AddParameter("@DT_ID", DTENT_Obj._DT_ID);
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Insert_Info_Bank");
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
    
    public DataSet Display_All_Bank(Bank_Entity BNKENT_Obj)
    {
        ObjDB.AddParameter("@BANK_ID", BNKENT_Obj._BANK_ID);
        ObjDB.AddParameter("@BANK_CD", BNKENT_Obj._BANK_CD);
        ObjDB.AddParameter("@BANK_NAME", BNKENT_Obj._BANK_NAME);
         
         return ObjDB.ExecuteDataSet("Proc_Tiger_Display_Info_Bank");

    }
    public bool Delete_Bank_By_ID(string bankid)
    {
        try
        {
            ObjDB.AddParameter("@BANK_ID", bankid);
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Delete_Info_Bank");
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
    public bool UpdateBankDB(Bank_Entity BNKENT_Obj, StateEntity STENT_Obj, DistrictEntity DTENT_Obj)
    {
        try
        {
            ObjDB.AddParameter("@BANK_ID", BNKENT_Obj._BANK_ID);
            ObjDB.AddParameter("@BANK_CD", BNKENT_Obj._BANK_CD);
            ObjDB.AddParameter("@BANK_NAME", BNKENT_Obj._BANK_NAME);
            ObjDB.AddParameter("@BANK_ADDRESS", BNKENT_Obj._BANK_ADDRESS);
            ObjDB.AddParameter("@ST_ID", STENT_Obj._ST_ID);
            ObjDB.AddParameter("@DT_ID", DTENT_Obj._DT_ID);
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Update_Info_Bank");
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
