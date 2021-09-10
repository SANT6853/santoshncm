using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NgoBL
/// </summary>
public class NgoBL
{
    #region Data declaration zone

    NgoDL ngoDL = new NgoDL();

    #endregion
    public NgoBL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region Fucntion to insert and update NGO details

    public int InsertUpdateNGODetails(NgoOB ngoObject)
    {
        try
        {
            return ngoDL.InsertUpdateNGODetails(ngoObject);
        }
        catch
        {
            throw;
        }
    }

    #endregion

    #region Funciton to display all photos

    public DataSet NGODetailsDisplay(NgoOB ngoObject, out int Catvalue)
    {
        try
        {
            return ngoDL.NGODetailsDisplay(ngoObject,out Catvalue);
        }
        catch
        {
            throw;
        }
        

    }

    #endregion

    #region Function to insert ngo details in final table

    public int InsertUpdateNGOInFinal(NgoOB ngoObject)
    {
        try
        {
            return ngoDL.InsertUpdateNGOInFinal(ngoObject);
        }
        catch
        {
            throw;
        }
       
    }

    #endregion

    #region Function to display ngo for updation

    public DataSet DisplayNGODetailsinEdit(NgoOB ngoObject)
    {
        try
        {

            return ngoDL.DisplayNGODetailsinEdit(ngoObject);

        }
        catch
        {
            throw;
        }
       
    }

    #endregion

    #region Function to compare category of gallery

    public DataSet NGOIDForComparison(NgoOB ngoObject)
    {
        try
        {
            return ngoDL.NGOIDForComparison(ngoObject);
        }
        catch
        {
            throw;
        }
    }


    #endregion
    #region Function for get NGO DETAIL 
    public DataSet NGODetails(NgoOB ngoObject)
    {
        try
        {
            return ngoDL.NGODetails(ngoObject);
        }
        catch
        {
            throw;
        }
    }
    #endregion 
    #region Function for get NGO DETAIL
    public DataSet workperform(NgoOB ngoObject)
    {
        try
        {
            return ngoDL.workperform(ngoObject);
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for  Get Scheme Detail
    public DataSet GetSchemeDetail(NgoOB ngoObject)
    {
        try
        {
            return ngoDL.GetSchemeDetail(ngoObject);
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for Delete NGO DeleteFund
    public int DeleteNGO(NgoOB ngoObject)
    {
        try
        {
            return ngoDL.DeleteNGO(ngoObject);
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for Delete Excutive
    public int DeleteExcutive(NgoOB ngoObject)
    {
        try
        {
            return ngoDL.DeleteExcutive(ngoObject);
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for Delete Excutive
    public int DeleteScheme(NgoOB ngoObject)
    {
        try
        {
            return ngoDL.DeleteScheme(ngoObject);
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for Delete FUND 
    public int DeleteFund(NgoOB ngoObject)
    {
        try
        {
            return ngoDL.DeleteFund(ngoObject);
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for get Fund DETAIL
    public DataSet FundDetails(NgoOB ngoObject)
    {
        try
        {
            return ngoDL.FundDetails(ngoObject);
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for Delete Post NGO DeleteFund
    public int DeletePostNGO(NgoOB ngoObject)
    {
        try
        {
            return ngoDL.DeletePostNGO(ngoObject);
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for get NGO DETAIL
    public DataSet getPostNGODetails(NgoOB ngoObject)
    {
        try
        {
            return ngoDL.getPostNGODetails(ngoObject);
        }
        catch
        {
            throw;
        }
    }
    #endregion 
    #region Function for Scheme Detail
    public DataSet GetScheme(NgoOB ngoObject)
    {
        try
        {
            return ngoDL.GetScheme(ngoObject);
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for Save Work Perform Detail 
    public int SaveMultipleScheme(TigerReserveOB _TigerReserveOB)
    {
        try
        {
            return ngoDL.SaveMultipleScheme(_TigerReserveOB);
        }
        catch
        {
            throw;
        }
    }
    #endregion 
    #region Function for Scheme History 
    public DataSet ConverSionScheme_History(NgoOB ngoObject)
    {
        try
        {
            return ngoDL.ConverSionScheme_History(ngoObject);
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for Save Work Perform History 
    public int SaveworkPerformHistory(TigerReserveOB _TigerReserveOB)
    {
        try
        {
            return ngoDL.SaveworkPerformHistory(_TigerReserveOB);
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for Work Name
    public DataSet GetWorkName(NgoOB ngoObject)
    {
        try
        {
            return ngoDL.GetWorkName(ngoObject);
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for Scheme History 
    public DataSet workperform_History(NgoOB ngoObject)
    {
        try
        {
            return ngoDL.workperform_History(ngoObject);
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for Save NGO HISTORY
    public int SavePostNgoHistory(TigerReserveOB _TigerReserveOB)
    {
        try
        {
            return ngoDL.SavePostNgoHistory(_TigerReserveOB);
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region function for NGO Name
    public DataSet NGONAME(int ID)
    {
        try
        {
            return ngoDL.NGONAME(ID);
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for Post NGO HISTORY
    public DataSet POSTNGO_History(NgoOB ngoObject)
    {
        try
        {
            return ngoDL.POSTNGO_History(ngoObject);
        }
        catch
        {
            throw;
        }
    }
    #endregion
	 #region Function for Save NGO HISTORY
    public int SavePreNgoHistory(TigerReserveOB _TigerReserveOB)
    {
        try
        {
            return ngoDL.SavePreNgoHistory(_TigerReserveOB);
        }
        catch
        {
            throw;
        }
    }
    #endregion
    #region Function for Pre NGO HISTORY
    public DataSet PRENGO_History(NgoOB ngoObject)
    {
        try
        {
            return ngoDL.PRENGO_History(ngoObject);
        }
        catch
        {
            throw;
        }
    }
    #endregion
}