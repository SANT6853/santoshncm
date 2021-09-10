using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for VillageBL
/// </summary>
public class VillageBL
{
    VillageDL villageDL = new VillageDL();

    public VillageBL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int Insert_VillageDetails(VillageOB obj_village)
    {
        try
        {
            return villageDL.Insert_VillageDetails(obj_village);
        }
        catch
        {
            throw;
        }

    }

    #region function to get village list 
    public DataSet getVillageList(VillageOB obj_village)
    {
        try
        {
            return villageDL.getVillageList(obj_village);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetStateUserTigerReserveUserDataOperatorUser(VillageOB obj_village)
    {
        try
        {
            return villageDL.GetStateUserTigerReserveUserDataOperatorUser(obj_village);
        }
        catch
        {
            throw;
        }

    }
    public DataSet GetUserNameOfStateReserveDfoDAL(VillageOB obj_village)
    {
        try
        {
            return villageDL.GetUserNameOfStateReserveDfoDAL(obj_village);
        }
        catch
        {
            throw;
        }

    }
    public DataSet DashBoardCounter(VillageOB obj_village)
    {
        try
        {
            return villageDL.DashBoardCounter(obj_village);
        }
        catch
        {
            throw;
        }

    }
    public DataSet NGoDashBoardCounter(VillageOB obj_village)
    {
        try
        {
            return villageDL.NGoDashBoardCounter(obj_village);
        }
        catch
        {
            throw;
        }

    }
    //NGoDashBoardCounter
    public DataSet DashBoardCounterNTCA(VillageOB obj_village)
    {
        try
        {
            return villageDL.DashBoardCounterNTCA(obj_village);
        }
        catch
        {
            throw;
        }

    }
    public DataSet getVillageListNTCA(VillageOB obj_village)
    {
        try
        {
            return villageDL.getVillageListNTCA(obj_village);
        }
        catch
        {
            throw;
        }

    }
    public DataSet getTigerReserveListNTCA(VillageOB obj_village)
    {
        try
        {
            return villageDL.getTigerReserveListNTCA(obj_village);
        }
        catch
        {
            throw;
        }

    }
    public DataSet getVillageListTigerUser(VillageOB obj_village)
    {
        try
        {
            return villageDL.getVillageListTigerUser(obj_village);
        }
        catch
        {
            throw;
        }

    }
    public DataSet getVillageListStateUser(VillageOB obj_village)
    {
        try
        {
            return villageDL.getVillageListStateUser(obj_village);
        }
        catch
        {
            throw;
        }

    }
    #endregion 
    public DataSet Get_VillageDetialsForEdit(VillageOB obj_village)
    {
        try
        {
            return villageDL.Get_VillageDetialsForEdit(obj_village);
        }
        catch
        {
            throw;
        }
    }
    public DataSet Get_Animal_By_Village_ForEdit(VillageOB obj_village)
    {
        try
        {
            return villageDL.Get_Animal_By_Village_ForEdit(obj_village);
        }
        catch
        {
            throw;
        }
    }
    public int Update_VillageDetails(VillageOB obj_village)
    {
        try
        {
            return villageDL.Update_VillageDetails(obj_village);
        }
        catch
        {
            throw;
        }
    }

    #region Function to insert photo category in final table

    public int InsertVillageDetailsInWeb(VillageOB obj_village)
    {
        try
        {
            return villageDL.InsertVillageDetailsInWeb(obj_village);
        }
        catch
        {
            throw;
        }
       
    }

    #endregion

    #region Function to compare category of gallery

    public DataSet VillageIDForComparison(VillageOB villageObject)
    {
        try
        {
            return villageDL.VillageIDForComparison(villageObject);
        }
        catch
        {
            throw;
        }
        
    }

    public DataSet GetVillageByTigerReserverID(int TigerReserveid)
    {
        try
        {
            return villageDL.GetVillageByTigerReserverID(TigerReserveid);
        }
        catch
        {
            throw;
        }
    }
    #endregion

    #region Function to insert-update village associate with NGO

    public int InsertUpdateAssociateNGO(VillageOB villageObject)
    {

        try
        {
            return villageDL.InsertUpdateAssociateNGO(villageObject);

        }
        catch
        {
            throw;
        }
       
    }

    #endregion

    #region Function to get village name

    public DataSet getVillageName(VillageOB villageObject)
    {
        try
        {
            return villageDL.getVillageName(villageObject);
        }
        catch
        {
            throw;
        }
    }

    #endregion

    #region Function to get NGO name

    public DataSet getNGOName()
    {
        try
        {
            return villageDL.getNGOName();
        }
        catch
        {
            throw;
        }
       
    }

    #endregion

    public DataSet getAssociatedNGOList(VillageOB obj_village)
    {
        try
        {
            return villageDL.getAssociatedNGOList(obj_village);
        }
        catch
        {
            throw;
        }
      
    }

    //date 13-01-2018

    public DataSet Get_VillageDetailsCDP(VillageOB obj_village)
    {
        try
        {
            return villageDL.Get_VillageDetailsCDP(obj_village);
        }
        catch
        {
            throw;
        }
    }
    public DataSet TestJquery(VillageOB obj_village)
    {
        try
        {
            return villageDL.TestJquery(obj_village);
        }
        catch
        {
            throw;
        }
    }

    public DataSet Get_VillageDetailsForDisplay(int villageid)
    {
        try
        {
            return villageDL.Get_VillageDetailsForDisplay(villageid);
        }
        catch
        {
            throw;
        }

    }
    //End
}