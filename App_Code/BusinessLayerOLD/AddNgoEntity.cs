using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Summary description for AddNgoEntity
/// </summary>
public class AddNgoEntity
{
   
    
    private string _NGONAME;
    public string NGONAME
    {
      get
    {
        return  _NGONAME;
    }
        set
        {
        _NGONAME = value;
        }
    }
    private string _NGOADDRES;
    public string NGOADDRES
    {
        get
        {
            return _NGOADDRES;
        }
        set
        {
            _NGOADDRES = value;
        }

    }
    private string _NGOPHONENO;
    public string NGOPHONENO
    {
        get
        {
            return _NGOPHONENO;
        }
        set
        {
            _NGOPHONENO = value;
        }
    }
    private string _NGOMOBILENO;
    public string NGOMOBILENO
    {
        get
        {
            return _NGOMOBILENO;
        }
        set
        {
            _NGOMOBILENO = value;
        }
    }
    private string _NGOREMARKS;
    public string NGOREMARKS
    {
        get
        {
            return _NGOREMARKS;
        }
        set
        {
            _NGOREMARKS = value;
        }
    }
    private Double _NGOAMOUNT;
    public Double NGOAMOUNT
    {
        get
        {
            return _NGOAMOUNT;
        }
        set
        {
            _NGOAMOUNT = value;
        }
    }
    private string _NGOFILENAME;
    public string NGOFILENAME
    {
        get
        {
            return _NGOFILENAME;
        }
        set
        {
            _NGOFILENAME = value;
        }

    }
    public int PermissionStateID { get; set; }
    private string _WORKDONE;
    public string WORKDONE
    {
        get
        {
            return _WORKDONE;
        }
        set
        {
            _WORKDONE = value;
        }

    }
    public int? SubmittedByUserID { get; set; }

}