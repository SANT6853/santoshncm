using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for UserEntity
/// </summary>
public class UserEntity
{
    public int LOG_ID{get;set;}
    public int ActionType { get; set; }
    public string USERNAME{get;set;}
    public string PASSWORD{get;set;}
    public string First_Name{get;set;}
    public string Last_Name{get;set;}
    public string Email{get;set;}
    public string Al_Email{get;set;}
    public int Role_Id { get; set; }
    public Int64 Contact_No{get;set;}
    public string Address{get;set;}
    public bool APPRV_STATUS{get;set;}
    public DateTime REC_INSERT_DATE{get;set;}
    public Int64 ID{get;set;}
    public string MAILTIME{get;set;}
    public string IsPasswordChanged{get;set;}
    public string RANDOMID{get;set;}
    public string USER_TYPE{get;set;}
    public string NewPassword { get; set; }
    public string Con_NewPassword { get; set; }
}
