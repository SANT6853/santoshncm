using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
/// <summary>
/// Summary description for UploadFile
/// </summary>
public class UploadFile
{
    public static bool GetActualFileType(Stream stream)
    {
        try
        {
            BinaryReader sr = new BinaryReader(stream);
            byte[] header = new byte[16];
            sr.Read(header, 0, 16);
            StringBuilder hexString = new StringBuilder(header.Length);
            for (int i = 0; i < header.Length - 1; i++)
            {
                hexString.Append(header[i].ToString("x2"));
            }
            UploadFile com = new UploadFile();
            return com.GetFileTypeByCode(hexString.ToString());

        }
        catch (Exception e2)
        {

            return false;
        }
    }


    private bool GetFileTypeByCode(string code)
    {
        bool flag = false;

        // here sis starting bit of  ms-2000, pdf and ms-2007 respectively
        //if (code.StartsWith("d0cf11e0a") | code.StartsWith("255044462") | code.StartsWith("504b0304"))
        if (code.StartsWith("255044462") || code.StartsWith("ffd8"))
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
            flag = true;


        }
        else
        {
            flag = false;

        }

        return flag;

    }

}
