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

public partial class auth_Adminpanel_Post_Addscheme : System.Web.UI.Page
{
    NgoOB ngObj = new NgoOB();
    NgoBL ngBL = new NgoBL();
    Project_Variables p_Val = new Project_Variables();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Id"] == null || Session["User_Id"].ToString() == "0" || Session["User_Id"].ToString() == "")
        {
            Session.Abandon();
            Response.Redirect("~/Home.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                BindScheme();
                Session["ID"] = null;
                Session["ID"] = Convert.ToInt32(Request.QueryString["id"]);
            }
        }
    }
    public void  BindScheme()
    {
        if (Request.QueryString["id"] != null)
        {
            ngObj.SchemeID = Convert.ToInt32(Request.QueryString["id"]);
            p_Val.dSet = ngBL.GetScheme(ngObj);
            if(p_Val.dSet.Tables[0].Rows.Count>0)
            {
                txtScheme.Text = p_Val.dSet.Tables[0].Rows[0]["SchemeName"].ToString();
            }
        }
    }
    [WebMethod]
    public static string SaveRecord(string WorkPerform)
    {
        string response = "";
        if (Convert.ToInt32(HttpContext.Current.Session["ID"]) != null)
        {

            NgoBL ngBL = new NgoBL();
            TigerReserveBL _tigerReserverBl = new TigerReserveBL();
            TigerReserveOB _TigerReserveOB = new TigerReserveOB();
            Project_Variables p_Var = new Project_Variables();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string NGODETAIL = WorkPerform.Replace("}\",\"{", "},{").Replace("[\"", "[").Replace("\"]", "]");
            List<RootObject> datalist = JsonConvert.DeserializeObject<List<RootObject>>(NGODETAIL);


            int i = 0;
            DataTable NGO = new DataTable();
            NGO.Columns.Add("SchemeName", typeof(string));
            NGO.Columns.Add("Central", typeof(string));
            NGO.Columns.Add("BenefitsExtended", typeof(string));
            NGO.Columns.Add("AmountSpent", typeof(string));
            NGO.Columns.Add("Remark", typeof(string));

            foreach (var a in datalist)
            {
                DataRow dr = NGO.NewRow();
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
            int Result = ngBL.SaveMultipleScheme(_TigerReserveOB);
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