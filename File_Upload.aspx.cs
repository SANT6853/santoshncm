using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Xml.Schema;
using System.Runtime.InteropServices;  



public partial class aa : System.Web.UI.Page
{

    dataLayer dl = new dataLayer();
    string TblHolder = "";
    string QuoteHolder = "";
    string Quote_chk = "";

    String Quote_for_Query = "";
    String User_Val = "";
    String toFile = "";
    String Ret_Data = "";

    String File_Name = "";
    ArrayList items = new ArrayList();
    ArrayList myList = new ArrayList();
    protected void Page_Load(object sender, EventArgs e)
    {


    }



    static string GetXmlString(string strFile)
    {
        // Load the xml file into XmlDocument object.
        XmlDocument xmlDoc = new XmlDocument();
        try
        {
            xmlDoc.Load(strFile);
        }
        catch (XmlException e)
        {
            Console.WriteLine(e.Message);
        }
        // Now create StringWriter object to get data from xml document.
        StringWriter sw = new StringWriter();
        XmlTextWriter xw = new XmlTextWriter(sw);
        xmlDoc.WriteTo(xw);
        return sw.ToString();
    }

    [DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
    private extern static System.UInt32 FindMimeFromData(System.UInt32 pBC, [MarshalAs(UnmanagedType.LPStr)] System.String pwzUrl, [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer, System.UInt32 cbSize, [MarshalAs(UnmanagedType.LPStr)] System.String pwzMimeProposed, System.UInt32 dwMimeFlags, out System.UInt32 ppwzMimeOut, System.UInt32 dwReserverd);


    protected void Button1_Click(object sender, EventArgs e)
    {



        if (FileUpload1.HasFile)
            try
            {
                HttpPostedFile file = FileUpload1.PostedFile;
                byte[] document = new byte[file.ContentLength];
                file.InputStream.Read(document, 0, file.ContentLength);
                System.UInt32 mimetype;
                FindMimeFromData(0, null, document, 256, null, 0, out mimetype, 0);
                System.IntPtr mimeTypePtr = new IntPtr(mimetype);
                string mime = Marshal.PtrToStringUni(mimeTypePtr);
                Marshal.FreeCoTaskMem(mimeTypePtr);



                bool validFile = true;
                switch (mime)
                {
                    case "application/vnd.ms-word":
                        validFile = true;
                        break;
                    case "application/vnd.ms-excel":
                        validFile = true;
                        break;
                    case "application/octet-stream":
                        validFile = true;
                        break;
                    case "image/pjpeg":
                        validFile = true;
                        break;
                    case "image/x-png":
                        validFile = true;
                        break;
                    case "image/gif":
                        validFile = true;
                        break;
                    case "application/pdf":
                        validFile = true;
                        break;
                    case "text/xml":
                        validFile = true;
                        break;

                    case "text/plain":
                        validFile = true;
                        break;


                    case "image/bmp":
                        validFile = true;
                        break;
                    default:
                        validFile = false;
                        break;
                }
                if (validFile == false)
                {
                    Message.InnerHtml = "Not a valid file";
                    return;
                }


                Cso_Statecode.Text = "";
                Cso_Towncode.Text = "";
                //Cso_Quotation.Text = "";
                Total_Recd.Text = "";
                tot_Err_recdd.Text = "";



                User_Val = Session["Username"].ToString();
                toFile = Server.MapPath("..\\writereaddata\\Uploads\\" + FileUpload1.FileName);
                //File_Name = FileUpload1.PostedFile.FileName.ToString();// FileUpload1.FileName;
                FileInfo TheFile = new FileInfo(toFile);
                //Session["File_Name"] = toFile;


                // items.Item[0] = toFile;
                // items.Add(toFile);



                if (TheFile.Exists)
                {

                    File.Delete(toFile);

                }




                FileUpload1.SaveAs(toFile);



                Ret_Data = GetXmlString(toFile);

               // Response.Write(Ret_Data);

                //Ret_Data = Ret_Data.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;");
                Ret_Data = Regex.Replace(Ret_Data, "'", "");
                //Ret_Data = Regex.Replace(Ret_Data, "\\", "");
                Ret_Data = Regex.Replace(Ret_Data, "&", "");



                Ret_Data = Regex.Replace(Ret_Data, "PTemp", "PTEMP");
                Ret_Data = Regex.Replace(Ret_Data, "ptemp", "PTEMP");

               

                Ret_Data = Encoding.ASCII.GetString(Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding(Encoding.ASCII.EncodingName, new EncoderReplacementFallback(string.Empty), new DecoderExceptionFallback()), Encoding.UTF8.GetBytes(Ret_Data)));

                Ret_Data = Ret_Data.Replace("\r", "");
                Ret_Data = Ret_Data.Replace("\n", "");
                Ret_Data = Ret_Data.Replace("\t", "");


                TblHolder = "<table id='dgSiteStatus' style='BORDER-RIGHT: 2px solid; BORDER-TOP: 2px solid; FONT-WEIGHT: normal; FONT-SIZE: smaller; BORDER-LEFT: 2px solid; WIDTH: 100%; BORDER-BOTTOM: 2px solid; FONT-FAMILY: Verdana; BORDER-COLLAPSE: collapse; BACKGROUND-COLOR: whitesmoke' cellSpacing='0' rules='all' align='center' border='1'>";


                TblHolder = TblHolder + "<tr style='FONT-WEIGHT: bold; COLOR: red; BACKGROUND-COLOR: #D5D5FF'>";
                TblHolder = TblHolder + "<td align='center' colspan='8'>Invalid Items Detail</td>";
                TblHolder = TblHolder + "</tr>";


                TblHolder = TblHolder + "<tr style='BORDER-RIGHT: 2px solid; COLOR: black; BACKGROUND-COLOR: #D5D5FF'>";
                TblHolder = TblHolder + "<td width='13%' align='middle'><b>Sl.No.</b></td>";
                //TblHolder = TblHolder + "<td align='middle'>State</td>";




                //TblHolder = TblHolder + "<td width='13%'  align='middle'>StateCode</td>";
                //TblHolder = TblHolder + "<td width='13%'  align='middle'>TownCode</td>";
                TblHolder = TblHolder + "<td  width='13%' align='middle'><b>Quotation</b></td>";
                TblHolder = TblHolder + "<td width='13%'  align='middle'><b>ItemCode</b></td>";
                TblHolder = TblHolder + "<td width='13%'  align='middle'><b>Item Desc</b></td>";
                TblHolder = TblHolder + "<td width='13%'  align='middle'><b>Error Desc</b></td>";
                TblHolder = TblHolder + "</tr>";


                string abc = Ret_Data.ToString();

               // Response.Write("exec Upload_XMLData '" + Ret_Data + "','" + User_Val + "','chk'");
                DataSet ds_val = dl.returnDSforGrid("exec Upload_XMLData '" + Ret_Data + "','" + User_Val + "','chk'");
                int Sl_cnt = 1;






                // Display Label Value In The Page From TEMP Table


                if (ds_val.Tables[0].Rows.Count > 0)
                {

                    Cso_Statecode.Text = ds_val.Tables[0].Rows[0]["Cso_Statecode"].ToString();
                    Cso_Towncode.Text = ds_val.Tables[0].Rows[0]["Cso_Towncode"].ToString();
                    //Cso_Quotation.Text = ds_val.Tables[0].Rows[0]["Quotation_Code"].ToString();
                    Total_Recd.Text = ds_val.Tables[0].Rows[0]["Tot_recds"].ToString();
                    tot_Err_recdd.Text = ds_val.Tables[0].Rows[0]["Err_Tot_recds"].ToString();
                    lbl_month.Text = ds_val.Tables[0].Rows[0]["MM"].ToString();
                    lbl_year.Text = ds_val.Tables[0].Rows[0]["YY"].ToString();
                    lbl_week.Text = ds_val.Tables[0].Rows[0]["Week"].ToString();


                }


                QuoteHolder = " <table style=width: 259px border=1>";
                QuoteHolder = QuoteHolder + "<tr>";
                QuoteHolder = QuoteHolder + "<td align='center' ForeColor=Black>Quote No.</td>";
                QuoteHolder = QuoteHolder + "<td align='center' ForeColor=Black>No. of Items</td>";
                QuoteHolder = QuoteHolder + "</tr>";











                //ds_val.Tables[0].Rows[0]["Err_Status"].ToString()

                foreach (DataRow dr_val in ds_val.Tables[0].Rows)
                {

                    if (dr_val["Valid_Recds"].ToString() == "N")
                    {

                        TblHolder = TblHolder + "<tr>";
                        TblHolder = TblHolder + "<td align='middle'>" + Sl_cnt + " </td>";
                        //TblHolder = TblHolder + "<td align='middle'>" + dr_val["Cso_StateCode"].ToString() + "</td>";
                        //TblHolder = TblHolder + "<td align='middle'>" + dr_val["Cso_TownCode"].ToString() + "</td>";
                        TblHolder = TblHolder + "<td align='middle'>" + dr_val["Quotation_Code"].ToString() + "</td>";
                        TblHolder = TblHolder + "<td align='middle'>" + dr_val["Item_Code"].ToString() + "</td>";
                        TblHolder = TblHolder + "<td align='middle'>" + dr_val["Item_Desc"].ToString() + "</td>";
                        TblHolder = TblHolder + "<td align='middle'>" + dr_val["Err_Status"].ToString() + "</td>";

                        TblHolder = TblHolder + "</tr>";

                        Sl_cnt = Sl_cnt + 1;
                    }


                    if (Quote_chk != dr_val["Quotation_code"].ToString())
                    {
                        QuoteHolder = QuoteHolder + "<tr>";
                        QuoteHolder = QuoteHolder + "<td align='center'  ><Font ForeColor=Blue>" + dr_val["Quotation_code"].ToString() + "</font></td>";
                        QuoteHolder = QuoteHolder + "<td align='center' ForeColor=Blue>" + dr_val["Quote_Wise_No_Item"].ToString() + "</td>";
                        QuoteHolder = QuoteHolder + "</tr>";


                        Quote_chk = dr_val["Quotation_code"].ToString();

                        if (Quote_for_Query == "")
                        {
                            Quote_for_Query = Quote_for_Query + Quote_chk;
                        }
                        else
                        {
                            Quote_for_Query = Quote_for_Query + "," + Quote_chk;
                        }
                    }

                }

                Quote_Query.Value = Quote_for_Query;

                QuoteHolder = QuoteHolder + "</table";
                TblHolder = TblHolder + "</table>";

                lbl_quote_no.Text = QuoteHolder;
                Label1.Text = TblHolder;



                Upload_Data.Enabled = true;
                Cancel_Data.Enabled = true;

                lbl_xml_file_select.Text = FileUpload1.FileName;
                FileUpload1.Visible = false;
                Button1.Visible = false;

                if (ds_val.Tables[0].Rows[0]["Err_Status"].ToString() != "All Valid")
                    Label2.Text = "Item Displayed Below Contains Some Error Please Rectify it and Upload. If you want to upload the rest items please click upload button.";

                else if (ds_val.Tables[0].Rows[0]["Err_Status"].ToString() == "All Valid")
                    Label2.Text = "All Records are valid. To upload please click on upload button.";
                ds_val.Dispose();
                dl.CloseConnection();


            }
            catch (Exception ex)
            {
               // Label1.Text = "ERROR: " + ex.Message.ToString();
                //Label1.Text = "Please Upload Only XML files";
            }
        else
        {
            Label1.Text = "You have not specified a file.";
        }
    }

    // Summary:
    //     Specifies the Month of the year.
    [Serializable]
    public enum MonthOfYear
    {
        // Summary:
        //     Indicates January.
        Jan = 1,
        //
        // Summary:
        //     Indicates February.
        Feb = 2,
        //
        // Summary:
        //     Indicates March.
        Mar = 3,
        //
        // Summary:
        //     Indicates April.
        Apr = 4,
        //
        // Summary:
        //     Indicates May.
        May = 5,
        //
        // Summary:
        //     Indicates June.
        June = 6,
        //
        // Summary:
        //     Indicates July.
        July = 7,
        //
        // Summary:
        //     Indicates August.
        Aug = 8,
        //
        // Summary:
        //     Indicates September.
        Sep = 9,
        //
        // Summary:
        //     Indicates October.
        Oct = 10,
        //
        // Summary:
        //     Indicates November.
        Nov = 11,
        //
        // Summary:
        //     Indicates December.
        Dec = 12
    }


    private string MonthName(int iMonth)
    {
        MonthOfYear month = (MonthOfYear)iMonth;
        return month.ToString();
    }

    protected void Upload_Data_Click(object sender, EventArgs e)
    {
        int Cur_Yr = Convert.ToInt32(DateTime.Now.Year.ToString());

        String Sel_Date_val = "01" + "/" + MonthName(Int32.Parse(lbl_month.Text)) + "/" + lbl_year.Text;
        String Cur_Date_val = "01" + "/" + DateTime.Now.ToString("MMMM") + "/" + Cur_Yr;

        String Str = "exec GetmonVal_chk '" + Sel_Date_val + "','" + Cur_Date_val + "'";
        //Response.Write(Str);
        DataSet ds = dl.returnDSforGrid(Str);

        String Mon_val = ds.Tables[0].Rows[0]["Mon_val"].ToString();


       

        //Mon_val = "valid";
        if (Mon_val != "valid") // For Next Year
        {

            Message.InnerHtml = "The Monthly Price Data Entry is Closed for Selected Month and Year.Please Select the Current Month and Year. ";
            Message.Style["color"] = "red";

        }
        else
        {

         
           

            if (lbl_xml_file_select.Text != "")
            {
 try{
                User_Val = Session["Username"].ToString();
                String Filename = Server.MapPath("..\\writereaddata\\Uploads\\" + lbl_xml_file_select.Text);
                Ret_Data = GetXmlString(Filename);
                Ret_Data = Regex.Replace(Ret_Data, "'", "");
                Ret_Data = Regex.Replace(Ret_Data, "&", "");

                Ret_Data = Regex.Replace(Ret_Data, "PTemp", "PTEMP");
                Ret_Data = Regex.Replace(Ret_Data, "ptemp", "PTEMP");

                Ret_Data = Encoding.ASCII.GetString(Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding(Encoding.ASCII.EncodingName, new EncoderReplacementFallback(string.Empty), new DecoderExceptionFallback()), Encoding.UTF8.GetBytes(Ret_Data)));



                Ret_Data = Ret_Data.Replace("\r", "");
                Ret_Data = Ret_Data.Replace("\n", "");
                Ret_Data = Ret_Data.Replace("\t", "");



               // Response.Write(Ret_Data);
                
               // dl.cmdExecuteNonQuery("Insert into Test values(exec Upload_XMLData '" + Ret_Data + "','" + User_Val + "','')");
                //String myval="exec Upload_XMLData '" + Ret_Data + "','" + User_Val + "',''";

                //String myval = "exec Upload_XMLData '" + Ret_Data + "','" + User_Val + "',''";
               // dl.cmdExecuteNonQuery("Insert into Test values('" + myval + "')");


     /*
                dl.cmdExecuteNonQuery("Insert into Test values('" + Ret_Data + "')");
                Response.Write("exec Upload_XMLData '" + Ret_Data + "','" + User_Val + "',''");
                Response.End();
      
      */ 

                DataSet ds_Upload = dl.returnDSforGrid("exec Upload_XMLData '" + Ret_Data + "','" + User_Val + "',''");

                
                String Chk_Status = ds_Upload.Tables[0].Rows[0]["Message_val"].ToString();

                //if (Chk_Status != "Error")
                Label2.Text = "Total Number of Records Successfully Uploaded- " + Chk_Status;

                //else
                //Label2.Text = "You cant Upload the Data.Please Check Tha Data.";


                Label2.ForeColor = System.Drawing.Color.Green;

                File.Delete(Filename);
                Upload_Data.Enabled = false;
                Show_data.Enabled = true;

                ds_Upload.Dispose();
                dl.CloseConnection();


            }catch (Exception ex){
                //Response.Write(e1.Message.ToString());
                //ErrorLog.WriteErrorLog(ex.Message);
            }

            }
            else
            {

                Message.InnerHtml = "Please First Verify The  XML File Then Click Upload.";
                Message.Style["color"] = "red";

            }
        }


    }
    protected void Cancel_Data_Click(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx");
    }
    protected void Show_data_Click(object sender, EventArgs e)
    {

        Label1.Visible = false;
        string csostatecode = "";
        string csotowncode = "";
        string csoquoteno = "";
        string mm = "";
        string week = "";

        if (Cso_Statecode.Text.StartsWith("0"))
            csostatecode = Cso_Statecode.Text.Replace("0", "");
        else
            csostatecode = Cso_Statecode.Text;
        if (Cso_Towncode.Text.StartsWith("0"))
            csotowncode = Cso_Towncode.Text.Replace("0", "");
        else
            csotowncode = Cso_Towncode.Text;
        if (lbl_month.Text.StartsWith("0"))
            mm = lbl_month.Text.Replace("0", "");
        else
            mm = lbl_month.Text;

        week = lbl_week.Text;
        String str_sql = "select * from monthly_price where cso_statecode='" + csostatecode + "' and cso_towncode='" + csotowncode + "'  and mon_val_new='" + mm + "' and year_val='" + lbl_year.Text + "' and cso_quote_no in (" + Quote_Query.Value + ")";


        DataSet ds = dl.returnDSforGrid(str_sql);
        ds.Dispose();
        dl.CloseConnection();
        dgshow.DataSource = ds.Tables[0].DefaultView;
        if (ds.Tables[0].Rows.Count > 0)
        {
            panelshow.Visible = true;
            if (dgshow.Visible == false)
                dgshow.Visible = true;
            dgshow.DataBind();

        }
        else
        {
            if (dgshow.Visible == true)
                dgshow.Visible = false;
            Message.InnerHtml = "No Entry Found";
            Message.Style["color"] = "red";
            panelshow.Visible = false;
        }

    }
}
