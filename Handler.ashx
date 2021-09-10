<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

public class Handler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        //Check if Request is to Upload the File.
        if (context.Request.Files.Count > 0)
        {
            for (int i = 0; i <= context.Request.Files.Count; i++)
            {
                HttpPostedFile postedFile = context.Request.Files[i];
                string folderPath = HttpContext.Current.Server.MapPath("~/WriteReadData/NGOAttachments/");
                string fileName = Path.GetFileName(postedFile.FileName);
                if(fileName !="")
                {
                    postedFile.SaveAs(folderPath + fileName);
                    string json = new JavaScriptSerializer().Serialize(
                        new
                        {
                            name = fileName
                        });
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                
                }
               
            }
        }
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}