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
/// Summary description for StateDB
/// </summary>
public class StateDB
{
    NCMdbAccess ObjDB = new NCMdbAccess();
    public bool InsertDistrict(string stid, string name, string id, string code)
    {
        try
        {
            ObjDB.AddParameter("@ST_ID", stid);
            ObjDB.AddParameter("@name", name);
            ObjDB.AddParameter("@reserveid", id);
            ObjDB.AddParameter("@code", code);
            ObjDB.AddParameter("@stdtcode", stid + code);
        
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Insert_Info_District");
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
