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
/// Summary description for Realocation_AreaDB
/// </summary>
public class Realocation_AreaDB
{
    NCMdbAccess ObjDB = new NCMdbAccess();
    public bool Add_Relocation_Site(Realocation_AreaEntiry RELO_ENT_Obj)
    {
        try
        {

            ObjDB.AddParameter("@ST_NM", RELO_ENT_Obj._ST_NM);
            ObjDB.AddParameter("@DT_NM", RELO_ENT_Obj._DT_NM);
            ObjDB.AddParameter("@TH_NM", RELO_ENT_Obj._TH_NM);
            ObjDB.AddParameter("@GP_NM", RELO_ENT_Obj._GP_NM);
            ObjDB.AddParameter("@VILL_NM", RELO_ENT_Obj._VILL_NM);
            ObjDB.AddParameter("@COMMENT", RELO_ENT_Obj._COMMENT);
            ObjDB.AddParameter("@RELOC_SITE_ADD", RELO_ENT_Obj._RELOC_SITE_ADD);
            ObjDB.AddParameter("@VILL_ID", RELO_ENT_Obj._VILL_ID);
            ObjDB.AddParameter("@UserID", RELO_ENT_Obj.Userid);

            ObjDB.AddParameter("@Latitude", RELO_ENT_Obj.Latitude);
            ObjDB.AddParameter("@Longitude", RELO_ENT_Obj.Longitude);
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Insert_Info_Relocation_Area");
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
    public bool Delete_Relocation_Site(int id)
    {
        ObjDB.AddParameter("@RELOC_AREA_ID", id);
        int i = ObjDB.ExecuteNonQuery("Delete_Relocation_Site");
        if (i > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
       
    }
    public DataSet Display_All_Relocation_Area(Realocation_AreaEntiry RELO_ENT_Obj, string Relo_id)
    {
        ObjDB.AddParameter("@VILL_ID", RELO_ENT_Obj._VILL_ID);
    ObjDB.AddParameter("@RELOC_AREA_ID", Relo_id);
    ObjDB.AddParameter("@UserID", RELO_ENT_Obj.Userid);

    return ObjDB.ExecuteDataSet("Proc_Tiger_Display_Relocation_Area");
    }
    public DataSet Display_All_Relocation_AreaTo(Realocation_AreaEntiry RELO_ENT_Obj, string Relo_id)
    {
        ObjDB.AddParameter("@VILL_ID", RELO_ENT_Obj._VILL_ID);
        ObjDB.AddParameter("@RELOC_AREA_ID", Relo_id);
        ObjDB.AddParameter("@UserID", RELO_ENT_Obj.Userid);

        return ObjDB.ExecuteDataSet("GetRelocationDetailTo");
    }
    public DataSet Display_All_Relocation_AreaNew(Realocation_AreaEntiry RELO_ENT_Obj, string Relo_id)
    {
        ObjDB.AddParameter("@VILL_ID", RELO_ENT_Obj._VILL_ID);
        ObjDB.AddParameter("@RELOC_AREA_ID", Relo_id);
        ObjDB.AddParameter("@UserID", RELO_ENT_Obj.Userid);

        return ObjDB.ExecuteDataSet("SpGetRelocationDetails");
    }

    
    public bool Update_Relocation_Site(Realocation_AreaEntiry RELO_ENT_Obj)
    {
        try
        {
            ObjDB.AddParameter("@RELOC_AREA_ID", RELO_ENT_Obj._RELOC_AREA_ID);
            ObjDB.AddParameter("@ST_NM", RELO_ENT_Obj._ST_NM);
            ObjDB.AddParameter("@DT_NM", RELO_ENT_Obj._DT_NM);
            ObjDB.AddParameter("@TH_NM", RELO_ENT_Obj._TH_NM);
            ObjDB.AddParameter("@GP_NM", RELO_ENT_Obj._GP_NM);
            ObjDB.AddParameter("@VILL_NM", RELO_ENT_Obj._VILL_NM);
            ObjDB.AddParameter("@COMMENT", RELO_ENT_Obj._COMMENT);
            ObjDB.AddParameter("@RELOC_SITE_ADD", RELO_ENT_Obj._RELOC_SITE_ADD);
            ObjDB.AddParameter("@VILL_ID", RELO_ENT_Obj._VILL_ID);

            ObjDB.AddParameter("@Latitude", RELO_ENT_Obj.Latitude);
            ObjDB.AddParameter("@Longitude", RELO_ENT_Obj.Longitude);
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Update_Info_Relocation_Area");
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

    public DataSet CheckVillid(string villid)
    {
        ObjDB.AddParameter("@VILL_ID", villid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_CheckVillid");


    }

    public bool Add_Relocation_Site_For_IB(Realocation_AreaEntiry RELO_ENT_Obj,string famid)
    {
        try
        {

            ObjDB.AddParameter("@ST_NM", RELO_ENT_Obj._ST_NM);
            ObjDB.AddParameter("@DT_NM", RELO_ENT_Obj._DT_NM);
            ObjDB.AddParameter("@TH_NM", RELO_ENT_Obj._TH_NM);
            ObjDB.AddParameter("@GP_NM", RELO_ENT_Obj._GP_NM);
            ObjDB.AddParameter("@VILL_NM", RELO_ENT_Obj._VILL_NM);
            ObjDB.AddParameter("@COMMENT", RELO_ENT_Obj._COMMENT);
            ObjDB.AddParameter("@RELOC_SITE_ADD", RELO_ENT_Obj._RELOC_SITE_ADD);
            ObjDB.AddParameter("@VILL_ID", RELO_ENT_Obj._VILL_ID);
            ObjDB.AddParameter("@FMLY_ID", famid);
            ObjDB.AddParameter("@KHASRA_NO", RELO_ENT_Obj._KHASRA_NO);


          
            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Insert_Info_Relocation_Area_For_IB");
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
    public bool Update_Relocation_Site_For_IB(Realocation_AreaEntiry RELO_ENT_Obj,string familyid)
    {
        try
        {
           
            ObjDB.AddParameter("@ST_NM", RELO_ENT_Obj._ST_NM);
            ObjDB.AddParameter("@DT_NM", RELO_ENT_Obj._DT_NM);
            ObjDB.AddParameter("@TH_NM", RELO_ENT_Obj._TH_NM);
            ObjDB.AddParameter("@GP_NM", RELO_ENT_Obj._GP_NM);
            ObjDB.AddParameter("@VILL_NM", RELO_ENT_Obj._VILL_NM);
            ObjDB.AddParameter("@COMMENT", RELO_ENT_Obj._COMMENT);
            ObjDB.AddParameter("@RELOC_SITE_ADD", RELO_ENT_Obj._RELOC_SITE_ADD);
            ObjDB.AddParameter("@FMLY_ID", familyid);
            ObjDB.AddParameter("@KHASRA_NO", RELO_ENT_Obj._KHASRA_NO);

            int i = ObjDB.ExecuteNonQuery("Proc_Tiger_Update_Info_Relocation_Area_For_IB");
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
    public DataSet CheckForRelocationDetails(string famid)
    {
        ObjDB.AddParameter("@FMLY_ID", famid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_CheckForRelocationDetails");


    }
    public DataSet Display_All_Relocation_Area_For_IB(string famid)
    {
       
        ObjDB.AddParameter("@FMLY_ID", famid);

        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_All_Relocation_Area_For_IB");
    }
    public DataSet Display_All_Relocation_Area_For_State(Realocation_AreaEntiry RELO_ENT_Obj, string Relo_id)
    {
        ObjDB.AddParameter("@VILL_ID", RELO_ENT_Obj._VILL_ID);
    ObjDB.AddParameter("@RELOC_AREA_ID", Relo_id);
    ObjDB.AddParameter("@ST_NM", RELO_ENT_Obj._ST_NM);

    return ObjDB.ExecuteDataSet("Proc_Tiger_Display_All_Relocation_Area_For_State");
    }
    public static void ExportToExcel(ref Panel GridView1, string reportname)
    {
        HttpContext.Current.Response.Clear();

        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + reportname + ".xls");

        HttpContext.Current.Response.Charset = "";

        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";

        System.IO.StringWriter StringWriter = new System.IO.StringWriter();

        HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
        HtmlTextWriter.WriteLine("<h1 style=\"text-align:center;\">Relocation Site Report</h1>");
        HtmlTextWriter.WriteLine("<br>");

        GridView1.RenderControl(HtmlTextWriter);
        string style = @"<style> .textmode { }  .RelocationHeader { background-color: #f0ad4e; width: 160px;color: black;padding: 15px;margin-left: 400px;}
#contentbody_gvforVillages{border-collapse: collapse;}#contentbody_gvforVillages,#contentbody_gvforVillages th,#contentbody_gvforVillages td {border: 1px solid black;}</style>";
        HttpContext.Current.Response.Write(style);

        HttpContext.Current.Response.Write(StringWriter.ToString());

        HttpContext.Current.Response.End();
    }
    public DataSet relocation_site_report(Realocation_AreaEntiry RELO_ENT_Obj)
    {
        ObjDB.AddParameter("@villageid", RELO_ENT_Obj._VILL_ID);
        ObjDB.AddParameter("@TigerReserveName", RELO_ENT_Obj.TigerReserveName);
        return ObjDB.ExecuteDataSet("relocation_site_report");
    }
    public DataSet relocation_site_reportNew(Realocation_AreaEntiry RELO_ENT_Obj)
    {
        ObjDB.AddParameter("@villageid", RELO_ENT_Obj._VILL_ID);
        ObjDB.AddParameter("@TigerReserveName", RELO_ENT_Obj.TigerReserveName);
        return ObjDB.ExecuteDataSet("SpGetRelocationDetailsReportNew");
    }
}
