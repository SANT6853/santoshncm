using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using NCM.DAL;
using System.IO;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Net.Configuration;
using System.Text.RegularExpressions;
using System.Linq;
using System.Diagnostics;
using System.Collections;


public class Miscelleneous_DL
{
    #region  Default constructor zone

    public Miscelleneous_DL()
    {

    }

    #endregion

    #region Default data declaration zone

    NCMdbAccess ncmdbObject = new NCMdbAccess();
    Project_Variables p_Val = new Project_Variables();
   
    #endregion

    #region Function to get date in mm/dd/yyyy format

    public DateTime getDateFormat(string mydate)
    {
        try
        {
            //Code to convert date format from dd/mm/yyyy to mm/dd/yyyy

            p_Val.date = DateTime.ParseExact(mydate, "dd/mm/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            return (p_Val.date);

            //End of conversion of date format
        }
        catch
        {
            throw;
        }

    }

    #endregion

    #region Function to get date in dd/mm/yyyy format

    public string getDateFormatddMMYYYY(string mydate)
    {
        try
        {
            p_Val.date = DateTime.ParseExact(mydate, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            p_Val.strDate = p_Val.date.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            return (p_Val.strDate);
        }
        catch
        {
            throw;
        }

    }

    #endregion

    #region code to Create Directory

    public void MakeDirectoryIfExists(string NewDirectory)
    {
        try
        {
            // Check if directory exists
            if (!Directory.Exists(HttpContext.Current.Request.MapPath(NewDirectory)))
            {
                // Create the directory.
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(NewDirectory));
            }
        }
        catch (IOException _ex)
        {
            System.Web.HttpContext.Current.Response.Write(_ex.Message);
        }
    }

    #endregion

    #region function to check File existance during uploading

    public string getUniqueFileName(string filname, string filepath, string fileNameWithoutExt, string ext)
    {
        int DotPosition = filname.IndexOf(".");
        string NewFileName = filname;
        int Counter = 0;
        // int FullPath = 0;
        try
        {
            if ((System.IO.File.Exists(filepath + "/" + NewFileName)))
            {
                while (((System.IO.File.Exists(filepath + "/" + NewFileName))))
                {
                    Counter = Counter + 1;
                    NewFileName = fileNameWithoutExt + "(" + Counter + ")";
                    NewFileName = NewFileName + ext;
                }
            }
            else
            {
                NewFileName = fileNameWithoutExt + ext;
            }
            return NewFileName;
        }
        catch
        {
            throw;
        }
    }

    #endregion

    #region Function to get status

    public DataSet getStatusType()
    {
        try
        {
            return ncmdbObject.ExecuteDataSet("MST_Get_Status");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }

    #endregion

    #region Function to get Language

    public DataSet getLanguage(NtcaUserOB usrObject)
    {
        try
        {
            ncmdbObject.Parameters.Add(new SqlParameter("@Lang_Id", usrObject.LangId));
            return ncmdbObject.ExecuteDataSet("MST_Get_Language");
        }
        catch
        {
            throw;
        }
        finally
        {
            ncmdbObject.Dispose();
        }
    }
    #endregion

    #region Function to find IP Address

    public string IpAddress()
    {
        try
        {
            p_Val.IpAddress = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (p_Val.IpAddress == null || p_Val.IpAddress == "")
            {
                p_Val.IpAddress = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            return p_Val.IpAddress;
        }
        catch
        {
            throw;
        }
    }

    #endregion


    #region Function to get Status according to permission

   

    #endregion

    #region Function to get Language  as per given permission

   
    #endregion

    #region Function to limit string length upto 40 characters

    public static string FixCharacters(object Desc, int length)
    {
       
        try
        {
            Project_Variables p_Val_Temp = new Project_Variables();

            p_Val_Temp.sbuilder.Insert(0, Desc.ToString());

            if (p_Val_Temp.sbuilder.Length > length)
                return p_Val_Temp.sbuilder.ToString().Substring(0, length) + "...";
            else return p_Val_Temp.sbuilder.ToString();
        }
        catch
        {
            throw;
        }
    }

    #endregion

    #region Function to fix on cs page string length upto given characters(For cs page)

    public string FixGivenCharacters(string Desc, int length)
    {
        try
        {
           
            p_Val.sbuilder.Insert(0, Desc.ToString());

            if (p_Val.sbuilder.Length > length)
                return p_Val.sbuilder.ToString().Substring(0, length) + "...";
            else return p_Val.sbuilder.ToString();
        }
        catch
        {
            throw;
        }
    }

    #endregion

    #region Function to get Categoty For Banner Mgmt
    public  DataSet Get_Category_ForBanner()
    {
        try
        {
            return ncmdbObject.ExecuteDataSet("ASP_Category_Master_Category_Type");
        }
        catch
        {
            throw;
        }
         finally
        {
            ncmdbObject.Dispose();
        }
    }
    #endregion 

    #region function to check file extension

    public  bool CheckImageFileExtension(string extension)
    {
        try
        {
            List<string> listExtension = new List<string>() { ".jpg", ".jpeg", ".png", ".gif" };
            return listExtension.Contains(extension.ToLower());
        }
        catch
        {
            throw;
        }
       
    }

    #endregion

    #region Function to get the module Information
    public DataSet ASP_Master_Module_Get_Module()
    {
        try
        {
            return ncmdbObject.ExecuteDataSet("ASP_Master_Module_Get_Module");
        }
        catch
        {
            throw;
        }
    }

    #endregion

    //New Function to check actual file type

    public  bool GetActualFileType(Stream stream)
    {

        try
        {

            BinaryReader sr = new BinaryReader(stream);

            byte[] header = new byte[16];

            sr.Read(header, 0, 16);

            StringBuilder hexString = new StringBuilder(header.Length);

            for (p_Val.i = 0; p_Val.i < header.Length - 1; p_Val.i++)
            {

                hexString.Append(header[p_Val.i].ToString("x2"));

            }

            Miscelleneous_DL com = new Miscelleneous_DL();

            return com.GetFileTypeByCode(hexString.ToString());

        }

        catch (Exception e2)
        {

            return false;

        }

    }


    public bool GetFileTypeByCode(string code)
    {

        p_Val.flag = false;

        // here sis starting bit of wmv,wav

        //if (code.StartsWith("3026b") || code.StartsWith("52494"))

        //{

        // here sis starting bit of jpg or jpeg, png,gif and bmp respectively

        if (code.StartsWith("ffd8") | code.StartsWith("0000") | code.StartsWith("8950") | code.StartsWith("4749") | code.StartsWith("d0cf11e0a")  | code.StartsWith("504b0304"))
        {

            //43575307 swf

            //47494638 gif

            //FFD8 jpg

            //424d bmp

            //D0CF11E0A1B11AE10000000000000000 - doc

            //D0CF11E0A1B11AE10000000000000000 - xls

            //504B03041400060008000000210030C9 - docx 

            //504B030414000600080000002100710E - xlsx

            //504B030414000000080060624E3E6267 - zip

            //526172211A0700CF907300000D000000 - rar

            //255044462D312E330D0A25E2E3CFD30D - pdf

            //255044462D312E330D25E2E3CFD30D0A - pdf

            //435753074C130200789CECB875545B6D - swf

            //3026B2758E66CF11A6D900AA0062CE6C - wmv

            //52494646EA40000057415645666D7420 - wav

            //524946463A0B000057415645666D7420 - wav

            ///52494646A44D000057415645666D7420 - wav

            p_Val.flag = true;


        }

        else
        {

            p_Val.flag = false;

        }

        return p_Val.flag;

    }

         //public bool SendEmail(string To, string Cc, string Bcc, string Subject, string From, string Msg)// send mail 
    //{
    //    MailMessage objMail = new MailMessage();
    //    objMail.To.Add(new MailAddress(To));
    //    objMail.Subject = Subject;
    //    if (From != string.Empty)
    //    {
    //        objMail.From = new MailAddress(From);
    //    }
    //    else
    //    {
    //        objMail.From = new MailAddress("");
    //    }
    //    objMail.IsBodyHtml = true;
    //    objMail.Body = Msg;
    //    objMail.Priority = MailPriority.High;
    //    SmtpClient smtp = new SmtpClient();
    //    smtp.Host = "smtp.gmail.com";
    //    smtp.EnableSsl = true;
    //    NetworkCredential NetworkCred = new NetworkCredential("fameindiascheme@gmail.com", "Admin@1234");
    //    smtp.UseDefaultCredentials = true;
    //    smtp.Credentials = NetworkCred;
    //    smtp.Port = 587;
    //    //System.Web.Mail.SmtpMail.SmtpServer = "100.100.7.4";// server name 
    //    smtp.Send(objMail);
    //    return true;
    //}   


    public bool SendEmail(string To, string Cc, string Bcc, string Subject, string From, string Msg)// send mail 
    {
        MailMessage objMail = new MailMessage();
        objMail.To.Add(new MailAddress(To));
        objMail.Subject = Subject;
        if (From != string.Empty)
        {
            objMail.From = new MailAddress(From);
        }
        else
        {
            objMail.From = new MailAddress("");
        }
       // objMail.IsBodyHtml = true;
       // objMail.Body = Msg;
       // objMail.Priority = MailPriority.High;
       // SmtpClient smtp = new SmtpClient();
       // smtp.Host = "smtp.gmail.com";
       // smtp.EnableSsl = true;
       // NetworkCredential NetworkCred = new NetworkCredential("fameindiascheme@gmail.com", "Admin@1234");
       // smtp.UseDefaultCredentials = true;
       // smtp.Credentials = NetworkCred;
       // smtp.Port = 587;
       // //System.Web.Mail.SmtpMail.SmtpServer = "100.100.7.4";// server name 
       // smtp.Send(objMail);
       //return true;

       objMail.IsBodyHtml = true;
       objMail.Body = Msg;
       objMail.Priority = MailPriority.High;
       SmtpClient smtp = new SmtpClient();
       smtp.Host = ConfigurationManager.AppSettings["SMTP_Server"].ToString();
       smtp.Port = 587;
       smtp.UseDefaultCredentials = false;
       smtp.Credentials = new System.Net.NetworkCredential("netcreativemind94@gmail.com", "Admin@1234");
       // smtp.Credentials = new System.Net.NetworkCredential("preeti.chawla@netcreativemind.com", "preeti@123");



       smtp.EnableSsl = true;

       //System.Web.Mail.SmtpMail.SmtpServer = "100.100.7.3";// server name 
       smtp.Send(objMail);
       return true;
    }
    public bool SendFeedBackEmail(string[] tolist, string[] Cclist, string[] Bcclist, string Subject, string From, string Msg)// send mail 
    {
        MailMessage objMail = new MailMessage();

        MailAddressCollection m = new MailAddressCollection();
        MailAddressCollection c = new MailAddressCollection();
        MailAddressCollection b = new MailAddressCollection();

        //Add this
        foreach (string to in tolist)
        {
           m.Add(to);
        }
        foreach (MailAddress ma in m)
        {
            objMail.To.Add(ma);
        }


        foreach (string cc in Cclist)
        {
            c.Add(cc);
        }
        foreach (MailAddress ma in c)
        {
            objMail.CC.Add(ma);
        }


        foreach (string bcc in Bcclist)
        {
            b.Add(bcc);
        }
        foreach (MailAddress ma in b)
        {
            objMail.Bcc.Add(ma);
        }


       // objMail.To.Add(new MailAddress(To));
        objMail.Subject = Subject;
        if (From != string.Empty)
        {
            objMail.From = new MailAddress(From);
        }
        else
        {
            objMail.From = new MailAddress("");
        }
        objMail.IsBodyHtml = true;
        objMail.Body = Msg;
        objMail.Priority = MailPriority.High;
        SmtpClient smtp = new SmtpClient();
        smtp.Host = ConfigurationManager.AppSettings["SMTP_Server"].ToString();
        //System.Web.Mail.SmtpMail.SmtpServer = "100.100.7.3";// server name 
        smtp.Send(objMail);
        return true;
    }

   


    public bool GetActualFileType_pdf(Stream stream)
    {

        try
        {

            BinaryReader sr = new BinaryReader(stream);

            byte[] header = new byte[16];

            sr.Read(header, 0, 16);

            StringBuilder hexString = new StringBuilder(header.Length);

            for (p_Val.i = 0; p_Val.i < header.Length - 1; p_Val.i++)
            {

                hexString.Append(header[p_Val.i].ToString("x2"));

            }

            Miscelleneous_DL com = new Miscelleneous_DL();

            return com.GetFileTypeByCode_pdf(hexString.ToString());

        }

        catch (Exception e2)
        {

            return false;

        }

    }


    public bool GetFileTypeByCode_pdf(string code)
    {

        p_Val.flag = false;

        // here sis starting bit of wmv,wav

        //if (code.StartsWith("3026b") || code.StartsWith("52494"))

        //{

        // here sis starting bit of jpg or jpeg, png,gif and bmp respectively

       // if (code.StartsWith("255044462"))
         if (code.StartsWith("255044462") || code.StartsWith("2030206") || code.StartsWith("32203020") || code.StartsWith("00000000"))
        {

            //43575307 swf

            //47494638 gif

            //FFD8 jpg

            //424d bmp

            //D0CF11E0A1B11AE10000000000000000 - doc

            //D0CF11E0A1B11AE10000000000000000 - xls

            //504B03041400060008000000210030C9 - docx 

            //504B030414000600080000002100710E - xlsx

            //504B030414000000080060624E3E6267 - zip

            //526172211A0700CF907300000D000000 - rar

            //255044462D312E330D0A25E2E3CFD30D - pdf

            //255044462D312E330D25E2E3CFD30D0A - pdf

            //435753074C130200789CECB875545B6D - swf

            //3026B2758E66CF11A6D900AA0062CE6C - wmv

            //52494646EA40000057415645666D7420 - wav

            //524946463A0B000057415645666D7420 - wav

            ///52494646A44D000057415645666D7420 - wav

            p_Val.flag = true;


        }

        else
        {

            p_Val.flag = false;

        }

        return p_Val.flag;

    }

    #region Function to remove XXS(Cross-site scripting)

    public string strip_dangerous_tags(string text_with_tags)
    {
        string s = Regex.Replace(text_with_tags, @"<script", "<scrSAFEipt", RegexOptions.IgnoreCase);
        s = Regex.Replace(s, @"</script", "</scrSAFEipt", RegexOptions.IgnoreCase);
        //s = Regex.Replace(s, @"<iframe", "</iframe", RegexOptions.IgnoreCase);
        s = Regex.Replace(s, @"<frameset", "</<frameset", RegexOptions.IgnoreCase);
        s = Regex.Replace(s, @"<frame", "</<frame", RegexOptions.IgnoreCase);
        //s = Regex.Replace(s, @"<iframe", "</iframe", RegexOptions.IgnoreCase);
        s = Regex.Replace(s, @"<object", "</objSAFEct", RegexOptions.IgnoreCase);
        s = Regex.Replace(s, @"</object", "</obSAFEct", RegexOptions.IgnoreCase);
        // ADDED AFTER THIS QUESTION WAS POSTED
        s = Regex.Replace(s, @"javascript", "javaSAFEscript", RegexOptions.IgnoreCase);

        s = Regex.Replace(s, @"onabort", "onSAFEabort", RegexOptions.IgnoreCase);
        s = Regex.Replace(s, @"onblur", "onSAFEblur", RegexOptions.IgnoreCase);
        s = Regex.Replace(s, @"onchange", "onSAFEchange", RegexOptions.IgnoreCase);
        s = Regex.Replace(s, @"onclick", "onSAFEclick", RegexOptions.IgnoreCase);
        s = Regex.Replace(s, @"ondblclick", "onSAFEdblclick", RegexOptions.IgnoreCase);
        s = Regex.Replace(s, @"onerror", "onSAFEerror", RegexOptions.IgnoreCase);
        s = Regex.Replace(s, @"onfocus", "onSAFEfocus", RegexOptions.IgnoreCase);

        s = Regex.Replace(s, @"onkeydown", "onSAFEkeydown", RegexOptions.IgnoreCase);
        s = Regex.Replace(s, @"onkeypress", "onSAFEkeypress", RegexOptions.IgnoreCase);
        s = Regex.Replace(s, @"onkeyup", "onSAFEkeyup", RegexOptions.IgnoreCase);

        s = Regex.Replace(s, @"onload", "onSAFEload", RegexOptions.IgnoreCase);

        s = Regex.Replace(s, @"onmousedown", "onSAFEmousedown", RegexOptions.IgnoreCase);
        s = Regex.Replace(s, @"onmousemove", "onSAFEmousemove", RegexOptions.IgnoreCase);
        s = Regex.Replace(s, @"onmouseout", "onSAFEmouseout", RegexOptions.IgnoreCase);
        s = Regex.Replace(s, @"onmouseup", "onSAFEmouseup", RegexOptions.IgnoreCase);
        s = Regex.Replace(s, @"onmouseup", "onSAFEmouseup", RegexOptions.IgnoreCase);

        s = Regex.Replace(s, @"onreset", "onSAFEresetK", RegexOptions.IgnoreCase);
        s = Regex.Replace(s, @"onresize", "onSAFEresize", RegexOptions.IgnoreCase);
        s = Regex.Replace(s, @"onselect", "onSAFEselect", RegexOptions.IgnoreCase);
        s = Regex.Replace(s, @"onsubmit", "onSAFEsubmit", RegexOptions.IgnoreCase);
        s = Regex.Replace(s, @"onunload", "onSAFEunload", RegexOptions.IgnoreCase);

        return s;
    }

    #endregion

    public string RemoveFCKEditorTagHtml(string html)
    {
        string s = Regex.Replace(html, @"&lt;", "<", RegexOptions.IgnoreCase);
        s = Regex.Replace(s, @"&gt;", ">", RegexOptions.IgnoreCase);

        return s;
    }



    #region function to make gridview control accessible

    public void MakeAccessible(GridView grid)
    {
        if (grid.Rows.Count > 0)
        {
            //This replaces <td> with <th> and add the scope attribute
            grid.UseAccessibleHeader = true;

            //This will add the <thead> and <tbody> elements
            grid.HeaderRow.TableSection = TableRowSection.TableHeader;


            //This is add the <tfoot> element. Remove if you don't have a footer row
            grid.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    #endregion 

    // Division of characters start from here
    public string Division_characters(string text,int length )
    {
        
        string newString = string.Empty;
        char[] input = text.ToCharArray();
        //int increment = length;

        int start = 0;

        int end = input.Count() / length;
        Enumerable

       .Range(start, end + 1).ToList().ForEach(i => newString += input.Skip(i * length).Take(length).Aggregate("", (a, b) => a + b) + Environment.NewLine);
        text = newString;
        return text;

        
    }

    public static string RemoveHtmlEvent(string htm)
    {
        string removableEvent = "onblur|ondatabinding|ondblclick|ondisposed|onfocus|oninit|onkeydown|onkeypress|onkeyup|onload|onmousedown|onmousemover|onmouseout|onmouseover|onmouseup|onprerender|onserverclick|onunload|document.getElementById()|document.getElementsByName()|document.documentElement()|document.createComment()|document.createDocumentFragment()|document.createElement()|document.createTextNode()|document.writeln()|document.write()|alert()|script";
        return Regex.Replace(htm, removableEvent, "");
    }
    public string RemoveUnnecessaryHtmlTagHtml(string html)
    {
        string html1 = RemoveHtmlEvent(html);
        string method = "onblur|ondatabinding|ondblclick|ondisposed|onfocus|oninit|onkeydown|onkeypress|onkeyup|onload|onmousedown|onmousemove|onmouseout|onmouseover|onmouseup|onprerender|onserverclick|onunload|document.getElementById()|document.getElementsByName()|document.documentElement()|document.createComment()|document.createDocumentFragment()|document.createElement()|document.createTextNode()|document.writeln()|document.write()|alert()";
        string acceptable = "map|strong|b|u|sup|sub|ol|ul|li|br|h2|h3|h4|h5|h6|head|hr|link|p|table|tbody|tr|td|tfoot|th|thead|title|id|style|class|span|div|p|a|img|blockquote|center|col|font|map";
        string stringPattern = "</?(?(?=" + acceptable + ")notag|[a-zA-Z0-9]+)(?:\\s[a-zA-Z0-9\\-]+=?(?:([\",']?).*?\\1?)?)*\\s*/?>|(?=" + method + ")";
        return Regex.Replace(html1, stringPattern, "");

        // return  HttpContext.Current.Server.HtmlDecode(html1);
    }


    public static bool Upload_Image(ref string fileName, string folderName, System.Web.UI.WebControls.FileUpload flvPdf)
    {

        bool uploadStatus = false;
        Project_Variables p_var = new Project_Variables();
        if (flvPdf.PostedFile.FileName != "")
        {
            try
            {
                p_var.videoUrl = ConfigurationManager.AppSettings["WriteReadData"].ToString() + "/" + ConfigurationManager.AppSettings["Videofile"].ToString() + "/";
                p_var.thumbnailUrl = ConfigurationManager.AppSettings["WriteReadData"].ToString() + "/"  + ConfigurationManager.AppSettings["VideoThumbnail"].ToString() + "/";


                fileName = string.Concat(DateTime.Now.ToString("yyyyMMddhhmmssfffffff"), System.IO.Path.GetFileName(flvPdf.PostedFile.FileName).Replace(" ", ""));
                flvPdf.PostedFile.SaveAs(HttpContext.Current.Server.MapPath("~/") + ConfigurationManager.AppSettings["WriteReadData"].ToString() + "/" + ConfigurationManager.AppSettings["Videofile"].ToString() + "/" + fileName);

                Process ffmpeg;

                string photo;
                string thumb;
                string video;
                string mpg;

                if (folderName != "/WatchToday")
                {
                    string getextension = System.IO.Path.GetExtension(flvPdf.PostedFile.FileName).ToLower();
                    if (getextension == ".png" || getextension == ".jpeg" || getextension == ".jpg" || getextension == ".bmp" || getextension == ".gif")
                    {
                        HttpContext.Current.Session["Image"] = string.Concat(DateTime.Now.ToString("yyyyMMddhhmmssfffffff"), System.IO.Path.GetFileName(flvPdf.PostedFile.FileName).Replace(" ", ""));
                        flvPdf.PostedFile.SaveAs(HttpContext.Current.Server.MapPath("~/") + ConfigurationManager.AppSettings["WriteReadData"].ToString() + "/" + ConfigurationManager.AppSettings["Videofile"].ToString() + "/images/" + fileName);
                        DeleteFile(fileName, folderName);
                        uploadStatus = true;
                        return uploadStatus;
                    }
                    else
                    {
                        photo = HttpContext.Current.Server.MapPath("~/") + ConfigurationManager.AppSettings["WriteReadData"].ToString() + "/" + ConfigurationManager.AppSettings["Videofile"].ToString() + "/" + fileName; // setting video input name with path


                        HttpContext.Current.Session["Image"] = string.Concat(DateTime.Now.ToString("yyyyMMddhhmmssfffffff"), ".jpeg");
                        thumb = HttpContext.Current.Server.MapPath("~/") + p_var.thumbnailUrl + HttpContext.Current.Session["Image"].ToString(); // thumb name with path !


                        ffmpeg = new Process();

                        ffmpeg.StartInfo.Arguments = " -i \"" + photo + "\" -s 200*200  -vframes 15 -f image2 -vcodec mjpeg \"" + thumb + "\""; // arguments !


                        ffmpeg.StartInfo.FileName = HttpContext.Current.Server.MapPath("~/Bin/") + "ffmpeg.exe";
                        ffmpeg.Start(); // start !
                        ffmpeg.Close();

                    }
                }

                video = HttpContext.Current.Server.MapPath("~/") + ConfigurationManager.AppSettings["WriteReadData"].ToString() + "/" + ConfigurationManager.AppSettings["Videofile"].ToString() + "/" + fileName; // setting video input name with path



           
                //mpg = HttpContext.Current.Server.MapPath("~/") + p_var.videoUrl +  string.Concat(DateTime.Now.ToString("yyyyMMddhhmmssfffffff"), ".flv"); // thumb name with path !
                mpg = HttpContext.Current.Server.MapPath("~/") + p_var.videoUrl + string.Concat(DateTime.Now.ToString("yyyyMMddhhmmssfffffff"), System.IO.Path.GetExtension(flvPdf.PostedFile.FileName).ToLower()); // thumb name with path !
               // HttpContext.Current.Session["Video"] = string.Concat(DateTime.Now.ToString("yyyyMMddhhmmssfffffff"), ".flv");
                HttpContext.Current.Session["Video"] = fileName;
                ffmpeg = new Process();

                ffmpeg.StartInfo.Arguments = " -i \"" + video + "\" -vcodec flv \"" + mpg + "\"";


                ffmpeg.StartInfo.FileName = HttpContext.Current.Server.MapPath("~/Bin/") + "ffmpeg.exe";




                ffmpeg.Start(); // start ! 
                ffmpeg.WaitForExit();
                // TimeSpan ts = ffmpeg.UserProcessorTime;

                // System.Threading.Thread.Sleep(ts.Seconds );


                ffmpeg.Close();

                uploadStatus = true;







            }
            catch
            {
                uploadStatus = false;
            }
            finally
            {
                DeleteFile(fileName, folderName);

            }
        }
        else
        {
            uploadStatus = true;

        }


        return uploadStatus;
    }

 

    //End

    public static void DeleteFile(string fileName, string folderName)
    {
        System.IO.FileInfo fileInfo = new System.IO.FileInfo(HttpContext.Current.Server.MapPath("~/") + ConfigurationManager.AppSettings["WriteReadData"].ToString() + "/" + folderName + "/" + fileName);
        if (fileInfo.Exists)
            fileInfo.Delete();
    }
    public System.Globalization.DateTimeFormatInfo dateConverson()
    {
        System.Globalization.DateTimeFormatInfo info = new System.Globalization.DateTimeFormatInfo();
        info.ShortDatePattern = "dd/MM/yyyy";
        return info;
    }


    public string fileSizeForContentPage(double sizeInBytes)
    {

        const long Terabyte = 1099511627776;
        const long Gigabyte = 1073741824;
        const long Megabyte = 1048576;
        const long Kilobyte = 1024;

        string result = string.Empty;
        long the_size = 0;
        string units = string.Empty;

        if (sizeInBytes >= Terabyte)
        {
            //the_size = Math.Round(sizeInBytes / Terabyte, 2);
            the_size = Convert.ToInt64(sizeInBytes / Terabyte);
            units = " Tb";
        }
        else
        {
            if (sizeInBytes >= Gigabyte)
            {
                // the_size = Math.Round(sizeInBytes / Gigabyte, 2);
                the_size = Convert.ToInt64(sizeInBytes / Gigabyte);
                units = " Gb";
            }
            else
            {
                if (sizeInBytes >= Megabyte)
                {
                    //the_size = Math.Round(sizeInBytes / Megabyte, 2);
                    the_size = Convert.ToInt64(sizeInBytes / Megabyte);
                    units = " Mb";
                }
                else
                {
                    if (sizeInBytes >= Kilobyte)
                    {
                        the_size = Convert.ToInt64(sizeInBytes / Kilobyte);
                        units = " Kb";
                    }
                    else
                    {
                        the_size = Convert.ToInt64(sizeInBytes);
                        units = " bytes";
                    }
                }
            }
        }

        if (units != "bytes")
        {
            result = the_size.ToString() + " " + units;
            if (result.Length < 7)
            {
                StringBuilder str = new StringBuilder();
                int count = 7 - result.Length;
                for (int i = 0; i < count; i++)
                {
                    str.Append(" ");
                }
                result = str.ToString() + result;
            }

        }
        else
        {
            result = the_size.ToString() + "" + units;
            if (result.Length < 7)
            {
                StringBuilder str = new StringBuilder();
                int count = 7 - result.Length;
                for (int i = 0; i < count; i++)
                {
                    str.Append(" ");
                }
                result = str.ToString() + result;
            }

        }
        return result;
    }


    public string geticonAndsSize( string StringDetail)
    {
        StringBuilder strpdfPath = new StringBuilder();
        StringBuilder value = new StringBuilder();
        string[] filenameSplit = { };
      
        string type = "";


        string[] arr1 = StringDetail.ToString().Split('<');

            for (int i = 0; i < arr1.Length; i++)
            {

                string srt = arr1[i];
                if (srt.StartsWith("/a>"))
                {
                    string pdf = arr1[i - 1];
                    string[] pdfSplit = pdf.Split('=');
                    for (int j = 0; j < pdfSplit.Length; j++)
                    {
                        if (pdfSplit[j].Contains(".pdf"))
                        {
                            string url = pdfSplit[j];

                            string filename = url.Replace("%20", " ");
                            filenameSplit = filename.Split('.');
                            //Get_FileSize(filenameSplit[0]);
                            type = "pdf";
                        }
                        else if (pdfSplit[j].Contains(".doc"))
                        {
                            string url = pdfSplit[j];

                            string filename = url.Replace("%20", " ");
                            filenameSplit = filename.Split('.');
                            type = "doc";
                        }
                        else if (pdfSplit[j].Contains(".docx"))
                        {
                            string url = pdfSplit[j];

                            string filename = url.Replace("%20", " ");
                            filenameSplit = filename.Split('.');
                            type = "docx";
                        }
                        else if (pdfSplit[j].Contains(".xls"))
                        {
                            string url = pdfSplit[j];

                            string filename = url;
                            filenameSplit = filename.Split('.');
                            type = "xls";
                        }
                        else if (pdfSplit[j].Contains(".xlsx"))
                        {
                            string url = pdfSplit[j];

                            string filename = url;
                            filenameSplit = filename.Split('.');
                            type = "xlsx";
                        }
                        else
                        {
                            strpdfPath.Append(pdfSplit[j]);
                        }
                    }
                    if (filenameSplit.Length > 0)
                    {
                        //string size = Get_FileSize(strpdfPath.ToString(), filenameSplit[0]);
                        ////if (arr1[i - 1].Contains(".pdf"))
                        ////{
                        //string[] pdffilname1 = filenameSplit[0].Split ("/");
                        string contentValue = filenameSplit[0].ToString();
                        string[] content = contentValue.Split('/');
                        string fn = content[content.Length - 1].ToString().Replace("\r\n", " ").Replace("%20", " ");
                        if (content.Length > 0)
                        {
                            FileInfo finfo1 = new FileInfo(HttpContext.Current.Server.MapPath("~/WriteReadData/userfiles/file/") + fn + "." + type);
                            string filesize = "0";
                            if (finfo1.Exists)
                            {
                                double FileInBytes = finfo1.Length;
                                filesize = fileSizeForContentPage(FileInBytes);

                            }
                            string strTest = "";

                            if (type == "pdf")
                            {
                                strTest = "<img width='15' alt='View Document' height=\"15\"    src=\"" + VirtualPathUtility.ToAbsolute("~/images/pdf.png") + "\" />" + filesize.ToString();
                            }
                            else if (type == "doc")
                            {
                                strTest = "<img width='15' alt='View Document' height=\"15\"    src=\"" + VirtualPathUtility.ToAbsolute("~/images/word.png") + "\" />" + filesize.ToString();
                            }
                            else if (type == "docx")
                            {
                                strTest = "<img width='15' alt='View Document' height=\"15\"    src=\"" + VirtualPathUtility.ToAbsolute("~/images/word.png") + "\" />" + filesize.ToString();
                            }

                            else if (type == "xls")
                            {
                                strTest = "<img width='15' alt='View Document' height=\"15\"   src=\"" + VirtualPathUtility.ToAbsolute("~/images/excel.png") + "\" />" + filesize.ToString();
                            }

                            else if (type == "xlsx")
                            {
                                strTest = "<img width='15' alt='View Document' height=\"15\"    src=\"" + VirtualPathUtility.ToAbsolute("~/images/excel.png") + "\" />" + filesize.ToString();
                            }

                            srt = srt.ToString() + strTest;
                        }
                    }
                    //}


                }
                if (i > 0)
                {
                    value.Append("<");
                }
                value.Append(srt);
            }

            return value.ToString();

    }
    public static bool CheckFileExtensionWord(string extension)
    {
        List<string> listExtension = new List<string>() { ".doc", ".docx" };
        return listExtension.Contains(extension.ToLower());
    }
    public static bool CheckFileExtensionExcel(string extension)
    {
        List<string> listExtension = new List<string>() { ".xlsx", ".xls" };
        return listExtension.Contains(extension.ToLower());
    }
    public static bool CheckFileExtensionPDF(string extension)
    {
        List<string> listExtension = new List<string>() { ".pdf" };
        return listExtension.Contains(extension.ToLower());
    }
   
    public static bool Upload_Image_Or_Documents(ref string fileName, System.Web.UI.WebControls.FileUpload ImgUploader, string folder)
    {
        bool uploadStatus = true;
        try
        {
            fileName = string.Concat(DateTime.Now.ToString("yyyyMMddhhmmssfffffff"), ImgUploader.PostedFile.FileName.Replace(" ", ""));
            ImgUploader.PostedFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath("~" + ConfigurationManager.AppSettings["WRITEREADDATA"].ToString() + @"/" + folder + "/" + fileName));
        }
        catch (Exception e)
        {
            uploadStatus = false;
        }
        return uploadStatus;
    }
    #region Function to get Status according to permission

   
    #endregion


    #region  Bind Dropdown
    public void Bind_dropdownYear(DropDownList ddl, int startvalue, int endvalue, string strdisplaytext, string selectedvalue = null)
    {
        ArrayList arrdata = new ArrayList();
        for (int i = endvalue; i >= startvalue; i--)
        {
            arrdata.Add(i);
        }
        ddl.DataSource = arrdata;
        ddl.DataBind();
        if (strdisplaytext != null)
        {
            ddl.Items.Insert(0, new ListItem(strdisplaytext, "0"));
        }
        if (selectedvalue != null)
        {
           
            ddl.SelectedValue = selectedvalue;
        }
    }
    #endregion

    public static string ReplaceSpecialCharecter(string strfile)
    {
       return strfile.Replace("&", "_").Replace("$", "_").Replace("%", "_").Replace("@", "_").Replace("#", "_").Replace("*", "_").Replace("^", "_").Replace(" ", "").Replace("'", ""); ;
    }

    public static void RedirectPermanent(string newPath)
    {

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Status = "301 Moved Permanently";
        HttpContext.Current.Response.AddHeader("Location", newPath);
        // HttpContext.Current.Response.Headers.Remove("Location");
        HttpContext.Current.Response.End();

    }
}
