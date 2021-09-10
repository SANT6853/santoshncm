using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Reserve
/// </summary>
public class Reserve
{
    ReserveDB RSVRDB_Obj = new ReserveDB();

    public bool AddReserve(Reserve_Entity objReserve_Entity, StateEntity Obj_StateEntity)
    {
        bool  check = RSVRDB_Obj.AddReserveDB(objReserve_Entity, Obj_StateEntity);// Calling of Data layer function
        if (check == true)
            return true;
        else
            return false;
        
    }
    public bool UpdateReserve(Reserve_Entity objReserve_Entity,string reserveid)
    {
        bool check = RSVRDB_Obj.UpdateReserveDB(objReserve_Entity, reserveid);// Calling of Data layer function
        if (check == true)
            return true;
        else
            return false;
        
    }

}
