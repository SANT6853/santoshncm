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
/// Summary description for NgoEntity
/// </summary>
public class NgoEntity
{
	public NgoEntity()
	{
		//
		// TODO: Add constructor logic here
		//
	}




    private Int64  NGO_ID;
    public Int64  _NGO_ID
    {
        get
        {
            return NGO_ID;
        }
        set
        {
           NGO_ID = value;
        }
    }
    private string NGO_NAME;
    public string _NGO_NAME
    {
        get
        {
            return NGO_NAME;
        }
        set
        {
            NGO_NAME = value;
        }
    }
    private Double    NGO_Amount;
    public Double  _NGO_Amount
    {
        get
        {
            return  NGO_Amount;
        }
        set
        {
             NGO_Amount= value;
        }
    }

    private string   NGO_Vill_ID;
    public string _NGO_Vill_ID
    {
        get
        {
            return  NGO_Vill_ID;
        }
        set
        {
             NGO_Vill_ID= value;
        }
    }
    private string   NGO_Work;
    public string _NGO_Work
    {
        get
        {
            return  NGO_Work;
        }
        set
        {
            NGO_Work= value;
        }
    }

}
