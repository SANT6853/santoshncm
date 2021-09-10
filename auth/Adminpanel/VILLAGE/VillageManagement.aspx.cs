using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Runtime.InteropServices;
public partial class auth_Adminpanel_VILLAGE_VillageManagement : CrsfBase
{
    Village Vill_Obj = new Village();
    VillageEntity VillEntity_Obj = new VillageEntity();
    VillageDB VillDB = new VillageDB();
    public static ArrayList Files = new ArrayList();  
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindVillageDetail();
        }
    }
    protected void btnfamily_Click(object sender, EventArgs e)
    {

    }
    protected void btnNGO_Click(object sender, EventArgs e)
    {

    }
    public void  BindVillageDetail()
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
         // if (Page.IsValid)
        // {
        try
        {

            string hdnblank = ((HiddenField)this.Master.FindControl("hdnblank")).Value;
            string CurrentSessionId = Convert.ToString(Session["AntiForgeryToken"]);
            if (Session["CurrentRequestUrl"] != null && Convert.ToString(Session["CurrentRequestUrl"]).Equals(Convert.ToString(Request.ServerVariables["HTTP_REFERER"])))
            {
                if (CurrentSessionId == hdnblank)
                {

                    if (Page.IsValid)
                    {

                        //try
                        //{
                            if (FileUpload1.HasFile)  // that the FileUpload control contains a file.  
                            {
                                if (FileUpload1.PostedFile.ContentLength > 0) // Get the size of the upload file.  
                                {
                                    if (ListBox1.Items.Contains(new ListItem(System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName)))) // Get the name of the file to upload.  
                                    {
                                        Label1.Text = "File already in the list";
                                    }
                                    else
                                    {
                                        Files.Add(FileUpload1); ListBox1.Items.Add(System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName));
                                        Label1.Text = "Add another file or click Upload to save them all";
                                    }
                                }
                                else
                                {
                                    Label1.Text = "File size cannot be 0";
                                }
                            }
                            else
                            {
                                Label1.Text = "Please select a file to add";
                            }
                        //}
                        //catch (Exception ex)
                        //{
                        //}
                    }//}
                }
            }
        }
        catch
        {
            throw;
        }
        // }
    }
    
    protected void Button2_Click(object sender, EventArgs e)
    {
         // if (Page.IsValid)
        // {
        try
        {

            string hdnblank = ((HiddenField)this.Master.FindControl("hdnblank")).Value;
            string CurrentSessionId = Convert.ToString(Session["AntiForgeryToken"]);
            if (Session["CurrentRequestUrl"] != null && Convert.ToString(Session["CurrentRequestUrl"]).Equals(Convert.ToString(Request.ServerVariables["HTTP_REFERER"])))
            {
                if (CurrentSessionId == hdnblank)
                {

                    if (Page.IsValid)
                    {

                        if (ListBox1.Items.Count > 0)
                        {
                            if (ListBox1.SelectedIndex < 0)
                            {
                                Label1.Text = "Please select a file to remove";
                            }
                            else
                            {
                                Files.RemoveAt(ListBox1.SelectedIndex);
                                ListBox1.Items.Remove(ListBox1.SelectedItem.Text);
                                Label1.Text = "File removed";
                            }
                        }
                    }
                }
            }
        }
        catch
        {
            throw;
        }
        // }
    }
}