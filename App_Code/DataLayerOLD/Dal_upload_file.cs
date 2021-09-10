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
using System.Data.SqlClient;

/// <summary>
/// Summary description for Dal_upload_file
/// </summary>
public class Dal_upload_file
{
    NCMdbAccess Ncm = new NCMdbAccess();
	public Dal_upload_file()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int upload_files(uploadfileentity entity)
    {
        Ncm.AddParameter("@v_id", entity._v_id);
        Ncm.AddParameter("@file_type", entity._type);
        Ncm.AddParameter("@title", entity._title);
        Ncm.AddParameter("@description", entity._description);
        Ncm.AddParameter("@file_name", entity._filename);
        return Ncm.ExecuteNonQuery("upload_files");
    }

    public int fundprogress(uploadfileentity entity)
    {
        Ncm.AddParameter("@v_id", entity._v_id);
        Ncm.AddParameter("@option", entity._option);
        Ncm.AddParameter("@fund", entity._fund);
        Ncm.AddParameter("@year", entity._year);
        return Ncm.ExecuteNonQuery("fundprogress");
    }



    public DataSet show_imeges(int village_id, string filetype, string TigerReserveName)
    {
        Ncm.AddParameter("@file_type", filetype);
        Ncm.AddParameter("@village_id", village_id);
        Ncm.AddParameter("@TigerReserveName", TigerReserveName);
        return Ncm.ExecuteDataSet("show_imeges");
    }
    //public DataSet show_imeges(int village_id)@TigerReserveName
    //{
    //    Ncm.AddParameter("@village_id", village_id);
    //    return Ncm.ExecuteDataSet("show_imeges");
    //}
    public string delete_file(int id)
    {
        Ncm.AddParameter("@id", id);
        SqlParameter filename = new SqlParameter("@filename",SqlDbType.VarChar,500);
        Ncm.AddParameter(filename);
        filename.Direction = ParameterDirection.Output;
      int val=  Ncm.ExecuteNonQuery("delete_file");
      if (val > 0)
      {
          return filename.Value.ToString();
      }
      else
      {
          return "";
      }
       
        
         
    }
    public DataSet select_file_for_update(int fid)
    {
        Ncm.AddParameter("@id",fid);
        return Ncm.ExecuteDataSet("select_file_for_update");
    }

    public int update_related_file(uploadfileentity entity,int id)
    {
        Ncm.AddParameter("@id", id);
        Ncm.AddParameter("@v_id", entity._v_id);
        Ncm.AddParameter("@file_name", entity._filename);
        Ncm.AddParameter("@file_type", entity._type);
        Ncm.AddParameter("@title", entity._title);
        Ncm.AddParameter("@description", entity._description);
        return Ncm.ExecuteNonQuery("update_related_file");
    }
}
