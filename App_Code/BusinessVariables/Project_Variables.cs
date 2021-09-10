﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;



public class Project_Variables
{
    #region default constructor zone

    public Project_Variables()
    {

    }

    #endregion

    #region variables declaration zone
    //highChart properties naren

    //end naren
    //Area for boolean type variables 

    public bool draft, review, publish, Edit, Delete, repeald, Hindi, English, flag;
    public bool uploadStatus = true;

    //End

    //Area for all ADO type variables 

    public DataSet dSet = new DataSet();
    public DataSet dSetCompare = new DataSet();
    public DataSet dSetChildData = new DataSet();
    public DataSet dsFileName = new DataSet();
    public DataTable dt = new DataTable();

    //End

    //Area for all string type variables

    public string langid = string.Empty;
    public string IpAddress = string.Empty;
    public string Path = string.Empty;
    public string stringTypeID = string.Empty;
    public string strPopupID = string.Empty;
    public string imageUrl = string.Empty;
    public string videoUrl = string.Empty;
    public string thumbnailUrl = string.Empty;
    public string targetpath = string.Empty;
    public string ImageName = string.Empty;
    public string Imagenamewithout_Ext = string.Empty;
    public string url = string.Empty;
    public string Filename = string.Empty;
    public string FilenameUrl = string.Empty;
    public string filenamewithout_Ext = string.Empty;
    public string ext = string.Empty;
    public string strDate = string.Empty;
    public string email = string.Empty;
    public string reply = string.Empty;
    public string strTextSize = string.Empty;
    public string strTheme = string.Empty;
    public string str = string.Empty;
    public string menu_name = string.Empty;
    public string urlname = string.Empty;
    public string PageID = string.Empty;
    public string parentID = string.Empty;
    public string parentName = string.Empty;
    public string metadescription = string.Empty;
    public string metakeywords = string.Empty;
    public string pagetitle = string.Empty;
    public string msg = string.Empty;
    public string galleryID = string.Empty;
    public string categoryID = string.Empty;
    public string categoryName = string.Empty;
    public string id = string.Empty;
    public string TigerReserveName = string.Empty;
    public string stateID = string.Empty;
    public string StateName = string.Empty;
    public string Latitude = string.Empty;
    public string Logitude = string.Empty;
    public StringBuilder sbuilder = new StringBuilder();
    public StringBuilder sbuildertmp = new StringBuilder();
    public string tempVideo = string.Empty;
    public string Breadcrumb = string.Empty;
    public string[] commandArgs = new string[5];
    public string pro_number = string.Empty;
    public string rp_number = string.Empty;
    public string pa_number = string.Empty;

    //End

    //Area for all integer type variables

    public Int32 Result,Result1;

    public int dataKeyID, moduleid, pageIndex, CurrentPage, position, menuid, LanguageID;
    public int i, j, k, linkid,count=0;

  

    public int petition_id, rp_id,rtiid, pa_id, status_id;

    //End

    //Area for all datetime type variables

    public DateTime date;

    //End

    #endregion
}
