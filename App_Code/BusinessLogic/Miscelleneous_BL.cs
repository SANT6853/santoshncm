using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

public class Miscelleneous_BL
{
    #region Default constructor zone

    public Miscelleneous_BL()
	{

    }

    #endregion

    #region Data declaration zone

    Miscelleneous_DL miscellDL = new Miscelleneous_DL();

    #endregion

    #region Function to get date in mm/dd/yyyy format

    public DateTime getDateFormat(string mydate)
    {
        try
        {
            return miscellDL.getDateFormat(mydate);
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
            return miscellDL.getDateFormatddMMYYYY(mydate);
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
            miscellDL.MakeDirectoryIfExists(NewDirectory);
        }
        catch
        {
            throw;
        }
    }

    #endregion

    #region function to check File existance during uploading

    public string getUniqueFileName(string filname, string filepath, string fileNameWithoutExt, string ext)
    {
        try
        {
            return miscellDL.getUniqueFileName(filname, filepath, fileNameWithoutExt, ext);
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
            return miscellDL.getStatusType();
        }
        catch
        {
            throw;
        }
        
    }

    #endregion 

    #region Function to get Language

    public DataSet getLanguage(NtcaUserOB usrObject)
    {
        try
        {
            return miscellDL.getLanguage(usrObject);
        }
        catch
        {
            throw;
        }
      
    }

    #endregion


    public static void RedirectPermanent(string newPath)
    {

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Status = "301 Moved Permanently";
        HttpContext.Current.Response.AddHeader("Location", newPath);
        // HttpContext.Current.Response.Headers.Remove("Location");
        HttpContext.Current.Response.End();

    }

    #region Function to limit string length upto 40 characters

    public static string FixCharacters(object Desc, int length)
    {
        try
        {
            return FixCharacters(Desc, length);
        }
        catch
        {
            throw;
        }
    }

    #endregion

    #region Function to fix on cs page string length upto given characters

    public string FixGivenCharacters(string Desc, int length)
    {
        try
        {
            Miscelleneous_DL myMiscDL = new Miscelleneous_DL();
            return myMiscDL.FixGivenCharacters(Desc, length);
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
            return miscellDL.Get_Category_ForBanner();
        }
        catch
        {
            throw;
        }
    }
    #endregion 

    #region function to check file extension

    public bool CheckImageFileExtension(string extension)
    {
        try
        {
            return miscellDL.CheckImageFileExtension(extension);
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
            return miscellDL.ASP_Master_Module_Get_Module();
        }
        catch
        {
            throw;
        }
    }

    #endregion


    //Function to get actual file type

    public  bool GetActualFileType(Stream stream)
    {

        try
        {
            Miscelleneous_DL myMiscDL = new Miscelleneous_DL();
            return myMiscDL.GetActualFileType(stream);
        }

        catch 
        {

            throw;

        }

    }
    public bool GetActualFileTypeImage(string code)
    {

        try
        {
            Miscelleneous_DL myMiscDL = new Miscelleneous_DL();
            return myMiscDL.GetFileTypeByCode(code);
        }

        catch
        {

            throw;

        }

    }

    public bool GetActualFileType_pdf(Stream stream)
    {

        try
        {
            Miscelleneous_DL myMiscDL = new Miscelleneous_DL();
            return myMiscDL.GetActualFileType_pdf(stream);
        }

        catch
        {

            throw;

        }

    }

    public bool SendEmail(string To, string Cc, string Bcc, string Subject, string From, string Msg)// send mail 
    {
        try
        {
            Miscelleneous_DL myMiscDL = new Miscelleneous_DL();
            return myMiscDL.SendEmail(To, Cc, Bcc, Subject, From, Msg);
        }
        catch
        {
            throw;
        }
    }




    #region Function to find IP Address

    public string IpAddress()
    {
        try
        {

            return miscellDL.IpAddress();
        }
        catch
        {
            throw;
        }
    }

    #endregion

    #region Function to remove XXS(Cross-site scripting)

    public string strip_dangerous_tags(string text_with_tags)
    {
        return miscellDL.strip_dangerous_tags(text_with_tags);
    }

    #endregion

    public string RemoveFCKEditorTagHtml(string html)
    {

        return miscellDL.RemoveFCKEditorTagHtml(html);

    }

    //End

    public string Division_characters(string text, int length)
    {
        return miscellDL.Division_characters(text, length);

        // End
    }

    public string RemoveUnnecessaryHtmlTagHtml(string html)
    {
        return miscellDL.RemoveUnnecessaryHtmlTagHtml(html);
    }

}
