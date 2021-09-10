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
/// Summary description for FeedbackEntity
/// </summary>
public class FeedbackEntity
{
	public FeedbackEntity()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private Int64  Feedback_Id;
    public Int64 _Feedback_Id
    {
        get
        {
            return Feedback_Id;
        }
        set
        {
            Feedback_Id = value;
        }
    }
    private string  Feedback_Username;
    public string  _Feedback_Username
    {
        get
        {
            return Feedback_Username;
        }
        set
        {
            Feedback_Username = value;
        }
    }
    private string feedback_useremail;
    public string  _feedback_useremail
    {
        get
        {
            return feedback_useremail;
        }
        set
        {
            feedback_useremail = value;
        }
    }
    private string feedback_mobile;
    public string  _feedback_mobile
    {
        get
        {
            return feedback_mobile;
        }
        set
        {
            feedback_mobile = value;
        }
    }
    private string feedback_teliphone;
    public string  _feedback_teliphone
    {
        get
        {
            return feedback_teliphone;
        }
        set
        {
            feedback_teliphone = value;
        }
    }
    private string feedback_Address;
    public string  _feedback_Address
    {
        get
        {
            return feedback_Address;
        }
        set
        {
            feedback_Address = value;
        }
    }

    private string feedback_state;
    public string  _feedback_state
    {
        get
        {
            return feedback_state;
        }
        set
        {
            feedback_state = value;
        }
    }
    private string feedback_message;
    public string  _feedback_message
    {
        get
        {
            return feedback_message;
        }
        set
        {
            feedback_message = value;
        }
    }
    private DateTime feedback_date;
    public DateTime _feedback_date
    {
        get
        {
            return feedback_date;
        }
        set
        {
            feedback_date = value;
        }
    }
}
