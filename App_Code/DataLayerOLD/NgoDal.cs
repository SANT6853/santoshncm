using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using NCM.DAL;

/// <summary>
/// Summary description for NgoDal
/// </summary>
public class NgoDal
{
    NCMdbAccess Obj_Ncm = new NCMdbAccess();
	public NgoDal()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Addngo(AddNgoEntity Entity)
    {
       

        Obj_Ncm.AddParameter("@name",Entity.NGONAME);
        Obj_Ncm.AddParameter("@address",Entity.NGOADDRES);
        Obj_Ncm.AddParameter("@mobileno", Entity.NGOMOBILENO);
        Obj_Ncm.AddParameter("@phoneno", Entity.NGOPHONENO);
        Obj_Ncm.AddParameter("@amount", Entity.NGOAMOUNT);
        Obj_Ncm.AddParameter("@remarks", Entity.NGOREMARKS);
        Obj_Ncm.AddParameter("@attchment", Entity.NGOFILENAME);
        Obj_Ncm.AddParameter("@workdone", Entity.WORKDONE);
        Obj_Ncm.AddParameter("@SubmittedByUserID", Entity.SubmittedByUserID);
        Obj_Ncm.AddParameter("@StateID", Entity.PermissionStateID);
        return  Obj_Ncm.ExecuteNonQuery("Add_Ngo");

    }
    public DataSet Showrecord()
    {
        Obj_Ncm.AddParameter("@SubmittedByUserID", Convert.ToInt32(HttpContext.Current.Session["User_Id"]
));
        DataSet ds = Obj_Ncm.ExecuteDataSet("fech_ngo_information");
        return ds;
    }
    public DataSet Showrecord1()
    {
        Obj_Ncm.AddParameter("@userid", Convert.ToInt32(HttpContext.Current.Session["User_Id"]));
        Obj_Ncm.AddParameter("@StateID", Convert.ToInt32(HttpContext.Current.Session["PermissionState"]));
        // DataSet ds = Obj_Ncm.ExecuteDataSet("fech_ngo_informationNEW");
        DataSet ds = Obj_Ncm.ExecuteDataSet("fech_ngo_informationNEWAdd");
        
        return ds;
    }
    public DataSet PostShowrecord1()
    {
        Obj_Ncm.AddParameter("@userid", Convert.ToInt32(HttpContext.Current.Session["User_Id"]));
        Obj_Ncm.AddParameter("@StateID", Convert.ToInt32(HttpContext.Current.Session["PermissionState"]));
        DataSet ds = Obj_Ncm.ExecuteDataSet("NTCA_POST_NGOReport");
        return ds;
    }
    public DataSet Showrecord13()
    {
        Obj_Ncm.AddParameter("@StateID", Convert.ToInt32(HttpContext.Current.Session["PermissionState"]));
        DataSet ds = Obj_Ncm.ExecuteDataSet("fech_ngo_informationNEW");
        return ds;
    }
    public DataSet Showrecord11(int TigerReserveid)
    {
        Obj_Ncm.AddParameter("@TigerReserveid",TigerReserveid);
        DataSet ds = Obj_Ncm.ExecuteDataSet("fech_ngo_informationNEW1");
        return ds;
    }
    public DataSet PostShowrecord11(int TigerReserveid)
    {
        Obj_Ncm.AddParameter("@TigerReserveid", TigerReserveid);
        DataSet ds = Obj_Ncm.ExecuteDataSet("fech_ngo_post_informationNEW1");
        return ds;
    }
    public DataSet fech_ngo_by_id( int id)
    {
        Obj_Ncm.AddParameter("@id",id);
        DataSet ds = Obj_Ncm.ExecuteDataSet("fech_ngo_by_id");
        return ds;
    }
    public int updatengo_information(AddNgoEntity Entity,int id)
    {
        Obj_Ncm.AddParameter("@id", id);
        Obj_Ncm.AddParameter("@name", Entity.NGONAME);
        Obj_Ncm.AddParameter("@address", Entity.NGOADDRES);
        Obj_Ncm.AddParameter("@mobileno", Entity.NGOMOBILENO);
        Obj_Ncm.AddParameter("@phoneno", Entity.NGOPHONENO);
        Obj_Ncm.AddParameter("@amount", Entity.NGOAMOUNT);
        Obj_Ncm.AddParameter("@remarks", Entity.NGOREMARKS);
        Obj_Ncm.AddParameter("@attchment", Entity.NGOFILENAME);
        Obj_Ncm.AddParameter("@workdone", Entity.WORKDONE);
        Obj_Ncm.AddParameter("@SubmittedByUserID", Entity.SubmittedByUserID);
        return Obj_Ncm.ExecuteNonQuery("updatengo_information");

    }
    public static DataTable binddropedownngo(int StateID)
    {
        using (NCMdbAccess obj = new NCMdbAccess())
        {
            obj.AddParameter("@StateID", StateID);
            DataSet ds = obj.ExecuteDataSet("select_ngo_for_dropedownlist");
            DataTable dt = ds.Tables[0];
            return dt;
        }

    }
    #region Function for Bind NGO  bindworkperform
    public static DataTable bindNGO(int StateID)
    {
        using (NCMdbAccess obj = new NCMdbAccess())
        {
            obj.AddParameter("@StateID", StateID);
            DataSet ds = obj.ExecuteDataSet("GETNGO");
            DataTable dt = ds.Tables[0];
            return dt;
        }

    }
    #endregion
    #region Function for Bind Excutive   
    public static DataTable bindworkperform(int StateID)
    {
        using (NCMdbAccess obj = new NCMdbAccess())
        {
            obj.AddParameter("@VillageID", StateID);
            DataSet ds = obj.ExecuteDataSet("GETWORKPERFORM");
            DataTable dt = ds.Tables[0];
            return dt;
        }

    }
    #endregion
    #region Function for Bind Excutive   
    public static DataTable bindScheme(int StateID)
    {
        using (NCMdbAccess obj = new NCMdbAccess())
        {
            obj.AddParameter("@VillageID", StateID);
            DataSet ds = obj.ExecuteDataSet("GETSCHEME");
            DataTable dt = ds.Tables[0];
            return dt;
        }

    }
    #endregion
    public static DataTable adminNgo()
    {
        using (NCMdbAccess obj = new NCMdbAccess())
        {
          //  obj.AddParameter("@StateID", StateID);
            DataSet ds = obj.ExecuteDataSet("SpGetngo");
            DataTable dt = ds.Tables[0];
            return dt;
        }

    }
    public static DataTable Proc_Get_All_Villages(int userid)
    {

        using (NCMdbAccess obj = new NCMdbAccess())
        {
            obj.AddParameter("@UserID", userid);
            DataSet ds = obj.ExecuteDataSet("Proc_Get_All_Villages");
            DataTable dt = ds.Tables[0];
            return dt;
        }

    }
    public static DataTable Proc_Get_All_Villagesnew(int userid)
    {

        using (NCMdbAccess obj = new NCMdbAccess())
        {
            obj.AddParameter("@UserID", userid);
            DataSet ds = obj.ExecuteDataSet("Proc_Get_All_Villages");
            DataTable dt = ds.Tables[1];
            return dt;
        }

    }
    public static DataTable GetAdminVillageAll()
    {

        using (NCMdbAccess obj = new NCMdbAccess())
        {
           // obj.AddParameter("@UserID", userid);
            DataSet ds = obj.ExecuteDataSet("SpAdminVillage");
            DataTable dt = ds.Tables[0];
            return dt;
        }

    }
    public static DataTable Proc_Get_All_Villages3(int userid)
    {

        using (NCMdbAccess obj = new NCMdbAccess())
        {
            obj.AddParameter("@CmnTigerReserveUserID", Convert.ToInt32(HttpContext.Current.Session["User_Id"]));
            DataSet ds = obj.ExecuteDataSet("Proc_Get_All_Villages3");
            DataTable dt = ds.Tables[0];
            return dt;
        }

    }
    public static DataTable Proc_Get_All_Villagesnew3(int userid)
    {

        using (NCMdbAccess obj = new NCMdbAccess())
        {
            obj.AddParameter("@CmnTigerReserveUserID", Convert.ToInt32(HttpContext.Current.Session["User_Id"]));
            DataSet ds = obj.ExecuteDataSet("Proc_Get_All_Villages3");
            DataTable dt = ds.Tables[1];
            return dt;
        }

    }
    public static DataTable Proc_Get_All_Villages2(int userid)
    {

        using (NCMdbAccess obj = new NCMdbAccess())
        {
            obj.AddParameter("@CmnStateUserID", Convert.ToInt32(HttpContext.Current.Session["User_Id"]));
            DataSet ds = obj.ExecuteDataSet("Proc_Get_All_Villages2");
            DataTable dt = ds.Tables[0];
            return dt;
        }

    }
    public static DataTable Proc_Get_All_Villagesnew2(int userid)
    {

        using (NCMdbAccess obj = new NCMdbAccess())
        {
            obj.AddParameter("@CmnStateUserID", Convert.ToInt32(HttpContext.Current.Session["User_Id"]));
            DataSet ds = obj.ExecuteDataSet("Proc_Get_All_Villages2");
            DataTable dt = ds.Tables[1];
            return dt;
        }

    }
    public static DataTable Get_All_Villages2(int Tiger)
    {

        using (NCMdbAccess obj = new NCMdbAccess())
        {
            obj.AddParameter("@CmnStateUserID", Tiger);
            DataSet ds = obj.ExecuteDataSet("Sp_Get_All_Villages2");
            DataTable dt = ds.Tables[0];
            return dt;
        }

    }
    public static DataTable Proc_Get_All_Villages1(int userid)
    {

        using (NCMdbAccess obj = new NCMdbAccess())
        {
            obj.AddParameter("@CmnStateUserID", Convert.ToInt32(HttpContext.Current.Session["User_Id"]));
            DataSet ds = obj.ExecuteDataSet("Proc_Get_AllVillages");
            DataTable dt = ds.Tables[0];
            return dt;
        }

    }
    public static DataTable Proc_Get_All_Villagesnew1(int userid)
    {

        using (NCMdbAccess obj = new NCMdbAccess())
        {
            obj.AddParameter("@CmnStateUserID", Convert.ToInt32(HttpContext.Current.Session["User_Id"]));
            DataSet ds = obj.ExecuteDataSet("Proc_Get_AllVillages");
            DataTable dt = ds.Tables[1];
            return dt;
        }

    }
    public static DataTable Proc_Get_AllVillages1(int id)
    {

        using (NCMdbAccess obj = new NCMdbAccess())
        {
            obj.AddParameter("@CmnStateUserID", id);
            DataSet ds = obj.ExecuteDataSet("Proc_Get_AllVillages");
            DataTable dt = ds.Tables[0];
            return dt;
        }

    }
    //Added By Deepak
    public static DataTable Get_Villages(int TigerReserve)
    {

        using (NCMdbAccess obj = new NCMdbAccess())
        {
            obj.AddParameter("@TigerReserve", TigerReserve);
            DataSet ds = obj.ExecuteDataSet("Sp_Get_All_Villages");
            DataTable dt = ds.Tables[0];
            return dt;
        }

    }
    public int Associate_Village(Associate_Village entity)
    {
        Obj_Ncm.AddParameter("@UserID", entity.UserID);
        Obj_Ncm.AddParameter("@village_id", entity.villageid);
        Obj_Ncm.AddParameter("@ngo_id", entity.ngoid);
        Obj_Ncm.AddParameter("@amount", entity.amount);
        Obj_Ncm.AddParameter("@work_done_for_village", entity.work_done_by_ngo);
        int i;
        return i = Obj_Ncm.ExecuteNonQuery("Associate_Village");
    }
    public static DataSet village_ngo_deatil(int id,string stateName)
    {
        using (NCMdbAccess obj = new NCMdbAccess())
        {
            obj.AddParameter("@village_id", id);
            obj.AddParameter("@stateName", stateName);
            DataSet ds = obj.ExecuteDataSet("village_ngo_deatil");
            return ds;
        }
    }
    public DataSet select_associate_village_deatil(int id)
    {
        Obj_Ncm.AddParameter("@id", id);
        DataSet ds = Obj_Ncm.ExecuteDataSet("select_associate_village_deatil");
        return ds;

    }

    public int update_associate_village_deatil(int id, double amount, string workdone,int ngoid)
    {
        Obj_Ncm.AddParameter("@id", id);
        Obj_Ncm.AddParameter("@amount", amount);
        Obj_Ncm.AddParameter("@work_done_fore_village", workdone);
        Obj_Ncm.AddParameter("@ngo_id", ngoid);
        int i = Obj_Ncm.ExecuteNonQuery("update_associate_village_deatil");
        return i;

    }
    public int update_associate_village_deatilnew(int id, double amount, string workdone)
    {
        Obj_Ncm.AddParameter("@id", id);
        Obj_Ncm.AddParameter("@amount", amount);
        Obj_Ncm.AddParameter("@work_done_fore_village", workdone);
        Obj_Ncm.AddParameter("@re_up_by_userID", Convert.ToInt32(HttpContext.Current.Session["User_Id"]));
        int i = Obj_Ncm.ExecuteNonQuery("update_associate_village_deatilnew");
        return i;

    }
    public DataSet select_village_record(int id, string TigerReserveName)
    {
        Obj_Ncm.AddParameter("@villagecode", id);
        Obj_Ncm.AddParameter("@TigerReserveName", TigerReserveName);
        DataSet ds = Obj_Ncm.ExecuteDataSet("serch_village_record");
        return ds;
    }
    public DataSet select_village_family(int id)
    {
        Obj_Ncm.AddParameter("@village_id", id);
        DataSet ds = Obj_Ncm.ExecuteDataSet("serch_village_family");
        return ds;
    }
    public int Delete_ngo_work(int id)
    {
        Obj_Ncm.AddParameter("@id", id);
        return Obj_Ncm.ExecuteNonQuery("delete_ngo_work");
    }

    public int Delete_Ngo(int ngoid)
    {
        Obj_Ncm.AddParameter("@ngoid", ngoid);
        return Obj_Ncm.ExecuteNonQuery("ngo_delete");
    }
    public DataSet ngo_associated_village(int ngoid, string TigerReserveName)
    {
        Obj_Ncm.AddParameter("@id", ngoid);
        Obj_Ncm.AddParameter("@TigerReserveName", TigerReserveName);
        return Obj_Ncm.ExecuteDataSet("ngo_associated");
    }
    #region Function for Bind Post NGO  
    public DataSet BindPostNGO(int StateID)
    {
        try
        {
            Obj_Ncm.AddParameter("@VillageID", StateID);
            return Obj_Ncm.ExecuteDataSet("BINDPOSTNGO");
        }
        catch
        {
            throw;
        }
       
    }
    #endregion
    #region Function for Bind Pre Map
    public DataSet PreMapDetail(int Vill_ID)
    {
        try
        {
            Obj_Ncm.AddParameter("@VillageID", Vill_ID);
            return Obj_Ncm.ExecuteDataSet("sp_PreMapDetail");
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for Bind Pre Map
    public DataSet PostMapDetail(int Vill_ID)
    {
        try
        {
            Obj_Ncm.AddParameter("@VillageID", Vill_ID);
            return Obj_Ncm.ExecuteDataSet("sp_PostMapDetail");
        }
        catch
        {
            throw;
        }
    }
    #endregion
}
