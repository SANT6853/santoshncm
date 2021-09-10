using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_HeadingControl : System.Web.UI.UserControl
{
     private string _Heading = string.Empty;
    public string Heading

    {

        get { return _Heading; }

        set { _Heading = value; }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ltrheading.Text = Heading;
    }
}