using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


public class Module_ID_Enum
{
    //Area for the constructors declaration

    #region default contructor zone

    public Module_ID_Enum()
	{

    }

    #endregion

    //End

    //Area for the enum declaration

    #region enum declaration for Project modules id

    public enum Project_Module_ID : int
    {
        user=1,
        cms=2,
        Banner=3,
        TigerReserve=4,
        PhotoGallery=5,
         //start 22marc2018
        MiddleContent=6,
        BottomThumnail=7,
        //end 22march2018
		NGO=8,
        FeedBackNTCA=9,   
        HomePage=10,
        FeedBackTigerReserve=11,
       LogoBanner=12,
        TigerReserveMap=18
       
    }

    #endregion

    #region enum declaration for action types
 
    public enum Project_Action_Type : int
    {
        insert = 1,
        update = 2,
        delete = 3
    }

    #endregion

   

    #region enum declaration for module permission type

    public enum Module_Status_ID : int
    {
        draft = 3,
        review = 4,
        Approved = 5,
        Delete = 6,
    }

    #endregion

    public enum Language_ID : int
    {
        English = 1,
        Hindi = 2,
    }
   
    public enum Menu_Position : int
    {
        top = 1,
        footer = 2,
        left = 3,
        right_top = 4,
       
    }

    public enum Link_parentID_Footer : int
    {
        parent_Footer = 0
    }

    public enum LinkTypeId : int
    {
        content = 1,
        link = 2
        
    }
    public enum HomePageEnum : int
    {
        Home = 6,
        HomeHindi = 7

    }

    public enum UserType : int
    {
        StateUser=2,
        TigerReserveUser=3,
        SuperAdmin = 1
    }
    public enum FundStatus : int
    {
        SaveAsDraft=1,
        SendForRequest=2,
    }
}
