using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_Post_AddConversionScheme : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Id"] == null || Session["User_Id"].ToString() == "0" || Session["User_Id"].ToString() == "")
        {
            Session.Abandon();
            Response.Redirect("~/Home.aspx");
        }
        else
        {
            Session["ID"] = null;
            ConversionRecord();
            Session["ID"] = Convert.ToInt32(Request.QueryString["id"]);
        }

       
    }
    public void ConversionRecord()
    {

        Project_Variables p_Var = new Project_Variables();
        TigerReserveBL _tigerReserverBl = new TigerReserveBL();
        TigerReserveOB _TigerReserveOB = new TigerReserveOB();
        int Vill_ID = Convert.ToInt32(Request.QueryString["id"]);
        p_Var.dSet = _tigerReserverBl.BindPostStates(Vill_ID);
        if (p_Var.dSet.Tables[0].Rows.Count > 0)
        {
            txtStateName.Text = p_Var.dSet.Tables[0].Rows[0]["StateName"].ToString();
            txtTigerReserve.Text = p_Var.dSet.Tables[0].Rows[0]["TigerReserveName"].ToString();
            txtDistrict.Text = p_Var.dSet.Tables[0].Rows[0]["DistName"].ToString();
            txtVillage.Text = p_Var.dSet.Tables[0].Rows[0]["VILL_NM"].ToString();
        }

    }
    [WebMethod]
    public static string SaveRecord(string WorkPerform)
    {
        string response = "";
        if (Convert.ToInt32(HttpContext.Current.Session["ID"]) != null)
        {


            TigerReserveBL _tigerReserverBl = new TigerReserveBL();
            TigerReserveOB _TigerReserveOB = new TigerReserveOB();
            Project_Variables p_Var = new Project_Variables();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string NGODETAIL = WorkPerform.Replace("}\",\"{", "},{").Replace("[\"", "[").Replace("\"]", "]");
            List<RootObject> datalist = JsonConvert.DeserializeObject<List<RootObject>>(NGODETAIL);


            int i = 0;
            DataTable NGO = new DataTable();
            NGO.Columns.Add("ID", typeof(string));
            NGO.Columns.Add("SchemeName", typeof(string));
            NGO.Columns.Add("Central", typeof(string));
            NGO.Columns.Add("BenefitsExtended", typeof(string));
            NGO.Columns.Add("AmountSpent", typeof(string));
            NGO.Columns.Add("Remark", typeof(string));

            foreach (var a in datalist)
            {
                DataRow dr = NGO.NewRow();
                dr["ID"] = i;
                dr["SchemeName"] = a.Name;
                dr["Central"] = a.Central;
                dr["BenefitsExtended"] = a.BenefitsExtended;
                dr["AmountSpent"] = a.AmountSpent;
                dr["Remark"] = a.Remark;
                NGO.Rows.Add(dr);
            }
            int itemid = 0;
            itemid = Convert.ToInt32(Convert.ToInt32(HttpContext.Current.Session["ID"]));
            _TigerReserveOB.CreatedByUserID = Convert.ToInt32(HttpContext.Current.Session["User_Id"].ToString());
            _TigerReserveOB.NGODetail = NGO;
            _TigerReserveOB.VillageID = itemid;
            int Result = _tigerReserverBl.SaveConversionScheme(_TigerReserveOB);
            string name = Convert.ToString(Result);
            response = JsonConvert.SerializeObject(name);
        }

        return Convert.ToString(response);
    }
    public class RootObject
    {
        public string Name { get; set; }
        public string AmountSpent { get; set; }
        public string Central { get; set; }
        public string WorkDone { get; set; }
        public string BenefitsExtended { get; set; }
        public string Remark { get; set; }
    }
}