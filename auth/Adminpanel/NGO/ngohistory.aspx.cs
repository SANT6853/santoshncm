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

public partial class auth_Adminpanel_NGO_ngohistory : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                Session["ID"] = null;
                NGORecord();
                Session["ID"] = Convert.ToInt32(Request.QueryString["h"]);

            }
        }

    }
    public void NGORecord()
    {

        Project_Variables p_Var = new Project_Variables();
        NgoBL ngBL = new NgoBL();
        TigerReserveOB _TigerReserveOB = new TigerReserveOB();
        int Vill_ID = Convert.ToInt32(Request.QueryString["h"]);
        p_Var.dSet = ngBL.NGONAME(Vill_ID);
        if (p_Var.dSet.Tables[1].Rows.Count > 0)
        {
            txtNGO.Text = p_Var.dSet.Tables[1].Rows[0]["NGO_NAME"].ToString();

        }

    }
    public class customers
    {
        public string State { get; set; }
        public string TigerReserve { get; set; }
        public string District { get; set; }
        public string Village { get; set; }

    }
    [WebMethod]
    public static string SaveRecord(string NGORECORD)
    {
        string response = "";
        if (Convert.ToInt32(HttpContext.Current.Session["ID"]) != null)
        {

            NgoBL ngBL = new NgoBL();
            TigerReserveBL _tigerReserverBl = new TigerReserveBL();
            TigerReserveOB _TigerReserveOB = new TigerReserveOB();
            Project_Variables p_Var = new Project_Variables();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string NGODETAIL = NGORECORD.Replace("}\",\"{", "},{").Replace("[\"", "[").Replace("\"]", "]");
            List<RootObject> datalist = JsonConvert.DeserializeObject<List<RootObject>>(NGODETAIL);


            int i = 0;
            DataTable NGO = new DataTable();
            NGO.Columns.Add("ApplicantName", typeof(string));
            NGO.Columns.Add("Address", typeof(string));
            NGO.Columns.Add("Mobile", typeof(string));
            NGO.Columns.Add("WorkDone", typeof(string));
            NGO.Columns.Add("Remark", typeof(string));
            NGO.Columns.Add("file", typeof(string));
            // p_Var.url =HttpContext ResolveUrl("~/") + ConfigurationManager.AppSettings["WriteReadData"].ToString() + "/VILLAGE" + "/";
            string folderPath = HttpContext.Current.Server.MapPath("~/WriteReadData/NgoFiles"); //+ ConfigurationManager("~/WriteReadData/NGOAttachments");
            foreach (var a in datalist)
            {
                int index = a.fileupload.ToString().LastIndexOf("\\") + 1;
                int length = a.fileupload.ToString().Length;
                int lengthdiff = length - index;
                string strFile = a.fileupload.ToString().Substring(index, lengthdiff);
                DataRow dr = NGO.NewRow();
                dr["ApplicantName"] = a.Name;
                dr["Address"] = a.Address;
                dr["Mobile"] = a.Mobile;
                dr["WorkDone"] = a.WorkDone;
                dr["Remark"] = a.Remark;
                dr["file"] = strFile;
                NGO.Rows.Add(dr);
            }
            int itemid = 0;

            itemid = Convert.ToInt32(Convert.ToInt32(HttpContext.Current.Session["ID"]));
            _TigerReserveOB.CreatedByUserID = Convert.ToInt32(HttpContext.Current.Session["User_Id"].ToString());
            _TigerReserveOB.NGODetail = NGO;
            _TigerReserveOB.VillageID = itemid;
            int Result = ngBL.SavePreNgoHistory(_TigerReserveOB);
            string name = Convert.ToString(Result);
            response = JsonConvert.SerializeObject(name);
        }

        return Convert.ToString(response);
    }
    public class RootObject
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string WorkDone { get; set; }
        public string Remark { get; set; }
        public string fileupload { get; set; }
    }
}
   