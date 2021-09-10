using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NCM.DAL;

/// <summary>
/// Summary description for Relocation_InstallmentDB
/// </summary>
public class Relocation_InstallmentDB
{
    NCMdbAccess ObjDB = new NCMdbAccess();

    public Relocation_InstallmentDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataSet Proc_SubInst(string scm_id, string fam_id)
    {
        ObjDB.AddParameter("@SCHM_ID", scm_id);
        ObjDB.AddParameter("@FMLY_ID", fam_id);
        return ObjDB.ExecuteDataSet("Proc_SubInst");

    }
    public DataSet Proc_SubInst_For_Report(string scm_id, string fam_id)
    {
        ObjDB.AddParameter("@SCHM_ID", scm_id);
        ObjDB.AddParameter("@FMLY_ID", fam_id);
        return ObjDB.ExecuteDataSet("Proc_SubInst_For_Report");

    }

    
    public DataSet ProcCheckSchemeNo(string scm_id, string fam_id)
    {
        ObjDB.AddParameter("@SCHM_ID", scm_id);
        ObjDB.AddParameter("@FMLY_ID", fam_id);
        return ObjDB.ExecuteDataSet("ProcCheckSchemeNo");

    }
    public DataSet Proc_Check_SellerDetail(string fam_id)
    {
        ObjDB.AddParameter("@FMLY_ID", fam_id);
        return ObjDB.ExecuteDataSet("Proc_Check_SellerDetail");

    }
    public bool Proc_Insert_IScheme(Relocation_InstallmentEntity RI_ENT_Obj, string fam_id, string scheme_id)
    {
        try
        {
            ObjDB.AddParameter("@FMLY_ID", fam_id);
            ObjDB.AddParameter("@SCHM_ID", scheme_id);
            ObjDB.AddParameter("@INST_ISCM_CHK_NO", RI_ENT_Obj._INST_ISCM_CHK_NO);
            ObjDB.AddParameter("@INST_ISCM_NO", 1);
            ObjDB.AddParameter("@INST_ISCM_CHK_DT", RI_ENT_Obj._INST_ISCM_CHK_DT);
            ObjDB.AddParameter("@BANK_NAME", RI_ENT_Obj._BANK_NAME);
            ObjDB.AddParameter("@BRANCH_NAME", RI_ENT_Obj._BRANCH_NAME);
            ObjDB.AddParameter("@INST_ISCM_AMT", RI_ENT_Obj._INST_ISCM_AMT);
            ObjDB.AddParameter("@INST_ISCM_HOLD_NM", RI_ENT_Obj._INST_ISCM_HOLD_NM);
            ObjDB.AddParameter("@ACCOUNT_NO", RI_ENT_Obj._ACCOUNT_NO);
            ObjDB.AddParameter("@CHK_BANK_NM", RI_ENT_Obj._CHK_BANK_NM);
            ObjDB.AddParameter("@CHK_BRANCH_NM", RI_ENT_Obj._CHK_BRANCH_NM);

            int i = ObjDB.ExecuteNonQuery("Proc_Insert_IScheme");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public bool Proc_Update_IScheme_For_Others(Relocation_InstallmentEntity RI_ENT_Obj, string fam_id, string scheme_id)
    {
        try
        {
            ObjDB.AddParameter("@FMLY_ID", fam_id);
            ObjDB.AddParameter("@INST_ISCM_ID", RI_ENT_Obj._INST_ISCM_ID);
            ObjDB.AddParameter("@INST_ISCM_CHK_NO", RI_ENT_Obj._INST_ISCM_CHK_NO);
            ObjDB.AddParameter("@INST_ISCM_CHK_DT", RI_ENT_Obj._INST_ISCM_CHK_DT);
            ObjDB.AddParameter("@BANK_NAME", RI_ENT_Obj._BANK_NAME);
            ObjDB.AddParameter("@BRANCH_NAME", RI_ENT_Obj._BRANCH_NAME);
            ObjDB.AddParameter("@INST_ISCM_AMT", RI_ENT_Obj._INST_ISCM_AMT);
            ObjDB.AddParameter("@INST_ISCM_HOLD_NM", RI_ENT_Obj._INST_ISCM_HOLD_NM);
            ObjDB.AddParameter("@ACCOUNT_NO", RI_ENT_Obj._ACCOUNT_NO);
            ObjDB.AddParameter("@CHK_BANK_NM", RI_ENT_Obj._CHK_BANK_NM);
            ObjDB.AddParameter("@CHK_BRANCH_NM", RI_ENT_Obj._CHK_BRANCH_NM);

            int i = ObjDB.ExecuteNonQuery("Proc_Update_IScheme_For_Others");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public bool Proc_Update_IScheme_For_II(Relocation_InstallmentEntity RI_ENT_Obj, string fam_id, string scheme_id)
    {
        try
        {
            ObjDB.AddParameter("@FMLY_ID", fam_id);
            ObjDB.AddParameter("@INST_ISCM_ID", RI_ENT_Obj._INST_ISCM_ID);
            ObjDB.AddParameter("@INST_ISCM_CHK_NO", RI_ENT_Obj._INST_ISCM_CHK_NO);
            ObjDB.AddParameter("@INST_ISCM_CHK_DT", RI_ENT_Obj._INST_ISCM_CHK_DT);
            ObjDB.AddParameter("@BANK_NAME", RI_ENT_Obj._BANK_NAME);
            ObjDB.AddParameter("@BRANCH_NAME", RI_ENT_Obj._BRANCH_NAME);
            ObjDB.AddParameter("@INST_ISCM_AMT", RI_ENT_Obj._INST_ISCM_AMT);
            ObjDB.AddParameter("@INST_ISCM_HOLD_NM", RI_ENT_Obj._INST_ISCM_HOLD_NM);
            ObjDB.AddParameter("@ACCOUNT_NO", RI_ENT_Obj._ACCOUNT_NO);
            ObjDB.AddParameter("@CHK_BANK_NM", RI_ENT_Obj._CHK_BANK_NM);
            ObjDB.AddParameter("@CHK_BRANCH_NM", RI_ENT_Obj._CHK_BRANCH_NM);

            int i = ObjDB.ExecuteNonQuery("Proc_Update_IScheme_For_II");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public bool Proc_Insert_IIIScheme(Relocation_InstallmentEntity RI_ENT_Obj, string fam_id, string scheme_id)
    {
        try
        {
            ObjDB.AddParameter("@FMLY_ID", fam_id);
            ObjDB.AddParameter("@SCHM_ID", scheme_id);
            ObjDB.AddParameter("@INST_ISCM_CHK_NO", RI_ENT_Obj._INST_ISCM_CHK_NO);
            ObjDB.AddParameter("@INST_ISCM_NO", 3);
            ObjDB.AddParameter("@INST_ISCM_CHK_DT", RI_ENT_Obj._INST_ISCM_CHK_DT);
            ObjDB.AddParameter("@BANK_NAME", RI_ENT_Obj._BANK_NAME);
            ObjDB.AddParameter("@BRANCH_NAME", RI_ENT_Obj._BRANCH_NAME);
            ObjDB.AddParameter("@INST_ISCM_AMT", RI_ENT_Obj._INST_ISCM_AMT);
            ObjDB.AddParameter("@INST_ISCM_HOLD_NM", RI_ENT_Obj._INST_ISCM_HOLD_NM);
            ObjDB.AddParameter("@ACCOUNT_NO", RI_ENT_Obj._ACCOUNT_NO);
            ObjDB.AddParameter("@CHK_BANK_NM", RI_ENT_Obj._CHK_BANK_NM);
            ObjDB.AddParameter("@CHK_BRANCH_NM", RI_ENT_Obj._CHK_BRANCH_NM);


            int i = ObjDB.ExecuteNonQuery("Proc_Insert_IScheme");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public bool Proc_Insert_Infra_Amount(Relocation_InstallmentEntity RI_ENT_Obj, string fam_id, string scheme_id)
    {
        try
        {
            ObjDB.AddParameter("@FMLY_ID", fam_id);
            ObjDB.AddParameter("@SCHM_ID", scheme_id);
            ObjDB.AddParameter("@INFRA_AMT", RI_ENT_Obj._INFRA_AMT);
            int i = ObjDB.ExecuteNonQuery("Proc_Insert_Infra_Amount");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool Proc_Insert_IIScheme(Relocation_InstallmentEntity RI_ENT_Obj, string fam_id, string scheme_id)
    {
        try
        {
            ObjDB.AddParameter("@FMLY_ID", fam_id);
            ObjDB.AddParameter("@SCHM_ID", scheme_id);
            ObjDB.AddParameter("@INST_ISCM_CHK_NO", RI_ENT_Obj._INST_ISCM_CHK_NO);
            ObjDB.AddParameter("@INST_IISCM_NO", RI_ENT_Obj._SUB_INST_ISCM_NO);
            ObjDB.AddParameter("@INST_ISCM_CHK_DT", RI_ENT_Obj._INST_ISCM_CHK_DT);
            ObjDB.AddParameter("@BANK_NAME", RI_ENT_Obj._BANK_NAME);
            ObjDB.AddParameter("@BRANCH_NAME", RI_ENT_Obj._BRANCH_NAME);
            ObjDB.AddParameter("@INST_ISCM_AMT", RI_ENT_Obj._INST_ISCM_AMT);
            ObjDB.AddParameter("@INST_ISCM_HOLD_NM", RI_ENT_Obj._INST_ISCM_HOLD_NM);
            ObjDB.AddParameter("@ACCOUNT_NO", RI_ENT_Obj._ACCOUNT_NO);
            ObjDB.AddParameter("@INST_ISCM_NO", RI_ENT_Obj._INST_ISCM_NO);
            ObjDB.AddParameter("@CHK_BANK_NM", RI_ENT_Obj._CHK_BANK_NM);
            ObjDB.AddParameter("@CHK_BRANCH_NM", RI_ENT_Obj._CHK_BRANCH_NM);


            int i = ObjDB.ExecuteNonQuery("Proc_Insert_IIScheme");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public bool Proc_SellerDetail(SellerEntity SE_obj, string fam_id, string scheme_id)
    {
        try
        {
            ObjDB.AddParameter("@FMLY_ID", fam_id);
            ObjDB.AddParameter("@SCHM_ID", scheme_id);
            ObjDB.AddParameter("@SELR_NM", SE_obj._SELR_NM);
            ObjDB.AddParameter("@SELR_PARNT", SE_obj._SELR_PARNT);
            ObjDB.AddParameter("@SELR_VILL_NM", SE_obj._SELR_VILL_NM);
            ObjDB.AddParameter("@SELR_TH_NM", SE_obj._SELR_TH_NM);
            ObjDB.AddParameter("@KHASRA_NO", SE_obj._KHASRA_NO);
            ObjDB.AddParameter("@SELR_LAND_AREA", SE_obj._SELR_LAND_AREA);
            ObjDB.AddParameter("@SELR_DT", SE_obj._SELR_DT);
            ObjDB.AddParameter("@SEL_AGRMT_DTL", SE_obj._SEL_AGRMT_DTL);
            ObjDB.AddParameter("@SELR_DISTRICT", SE_obj._SELR_DISTRICT);
            ObjDB.AddParameter("@FILE_NAME", SE_obj._FILE_NAME);
            ObjDB.AddParameter("@SELR_FUL_ADD", SE_obj._SELR_FUL_ADD);
            ObjDB.AddParameter("@ST_NAME", SE_obj._ST_NAME);
            ObjDB.AddParameter("@GP_NAME", SE_obj._GP_NAME);
            ObjDB.AddParameter("@DISTANCE", SE_obj._DISTANCE);



            int i = ObjDB.ExecuteNonQuery("Proc_SellerDetail");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public bool Proc_Insert_FDDetail(FD_DetailEntity fd_obj, string fam_id, string scheme_id)
    {
        try
        {
            ObjDB.AddParameter("@FAMILY_ID", fam_id);
            ObjDB.AddParameter("@SCHM_ID", scheme_id);
            ObjDB.AddParameter("@FD_AMT", fd_obj._FD_AMT);
            ObjDB.AddParameter("@FD_NO", fd_obj._FD_NO);
            ObjDB.AddParameter("@FD_DATE_OF_DT", fd_obj._FD_DATE_OF_DT);
            ObjDB.AddParameter("@FD_DATE_MTRTY_DT", fd_obj._FD_DATE_MTRTY_DT);
            ObjDB.AddParameter("@ACC_NO", fd_obj._ACC_NO);
            ObjDB.AddParameter("@FD_HOLD_NM", fd_obj._FD_HOLD_NM);
            //ObjDB.AddParameter("@OCCUPATION", fd_obj._OCCUPATION);
            ObjDB.AddParameter("@BANK_NAME", fd_obj._BANK_NAME);
            ObjDB.AddParameter("@BRANCH_NAME", fd_obj._BRANCH_NAME);
            ObjDB.AddParameter("@HOUSE_CONS", fd_obj._HOUSE_CONS);




            int i = ObjDB.ExecuteNonQuery("Proc_Insert_FDDetail");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public bool Proc_Insert_IIIAScheme(Relocation_InstallmentEntity RI_ENT_Obj, string fam_id, string scheme_id)
    {
        try
        {
            ObjDB.AddParameter("@FMLY_ID", fam_id);
            ObjDB.AddParameter("@SCHM_ID", scheme_id);
            ObjDB.AddParameter("@INST_ISCM_CHK_NO", RI_ENT_Obj._INST_ISCM_CHK_NO);
            ObjDB.AddParameter("@INST_ISCM_NO", 2.1);
            ObjDB.AddParameter("@INST_ISCM_CHK_DT", RI_ENT_Obj._INST_ISCM_CHK_DT);
            ObjDB.AddParameter("@BANK_NAME", RI_ENT_Obj._BANK_NAME);
            ObjDB.AddParameter("@INST_ISCM_AMT", RI_ENT_Obj._INST_ISCM_AMT);
            ObjDB.AddParameter("@INST_ISCM_HOLD_NM", RI_ENT_Obj._INST_ISCM_HOLD_NM);
            ObjDB.AddParameter("@ACCOUNT_NO", RI_ENT_Obj._ACCOUNT_NO);

            int i = ObjDB.ExecuteNonQuery("Proc_Insert_IScheme");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public bool Proc_Insert_AdhikarPatraDetail(AdhikarPatra_Entity AE_obj, string fam_id, string scheme_id)
    {
        try
        {
            ObjDB.AddParameter("@FMLY_ID", fam_id);
            ObjDB.AddParameter("@SCHM_ID", scheme_id);
            ObjDB.AddParameter("@HOLDER_NAME", AE_obj._HOLDER_NAME);
            ObjDB.AddParameter("@REL_RES_AREA", AE_obj._REL_RES_AREA);
            ObjDB.AddParameter("@REL_AGR_AREA", AE_obj._REL_AGR_AREA);
            ObjDB.AddParameter("@REL_KHSRA_NO ", AE_obj._REL_KHSRA_NO);
            ObjDB.AddParameter("@REL_ADDRESS", AE_obj._REL_ADDRESS);
            ObjDB.AddParameter("@DATE_OF_ISSUE", AE_obj._DATE_OF_ISSUE);
            ObjDB.AddParameter("@RELOC_AREA_ID", AE_obj._RELOC_AREA_ID);



            int i = ObjDB.ExecuteNonQuery("Proc_Insert_AdhikarPatraDetail");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool Proc_update_IScheme(Relocation_InstallmentEntity RI_ENT_Obj)
    {
        try
        {

            ObjDB.AddParameter("@INST_ISCM_ID", RI_ENT_Obj._INST_ISCM_ID);
            ObjDB.AddParameter("@INST_ISCM_CHK_NO", RI_ENT_Obj._INST_ISCM_CHK_NO);
            ObjDB.AddParameter("@INST_ISCM_CHK_DT", RI_ENT_Obj._INST_ISCM_CHK_DT);
            ObjDB.AddParameter("@BANK_NAME", RI_ENT_Obj._BANK_NAME);
            ObjDB.AddParameter("@BRANCH_NAME", RI_ENT_Obj._BRANCH_NAME);
            ObjDB.AddParameter("@INST_ISCM_AMT", RI_ENT_Obj._INST_ISCM_AMT);
            ObjDB.AddParameter("@INST_ISCM_HOLD_NM", RI_ENT_Obj._INST_ISCM_HOLD_NM);
            ObjDB.AddParameter("@ACCOUNT_NO", RI_ENT_Obj._ACCOUNT_NO);
            ObjDB.AddParameter("@CHK_BANK_NM", RI_ENT_Obj._CHK_BANK_NM);
            ObjDB.AddParameter("@CHK_BRANCH_NM", RI_ENT_Obj._CHK_BRANCH_NM);



            int i = ObjDB.ExecuteNonQuery("Proc_Update_IScheme");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public bool Proc_update_FDDetail(FD_DetailEntity fd_obj, string fdid, string instid)
    {
        try
        {
            ObjDB.AddParameter("@INST_ISCM_ID", instid);
            ObjDB.AddParameter("@FD_ID", fdid);
            ObjDB.AddParameter("@FD_AMT", fd_obj._FD_AMT);
            ObjDB.AddParameter("@FD_NO", fd_obj._FD_NO);
            ObjDB.AddParameter("@FD_DATE_OF_DT", fd_obj._FD_DATE_OF_DT);
            ObjDB.AddParameter("@FD_DATE_MTRTY_DT", fd_obj._FD_DATE_MTRTY_DT);
            ObjDB.AddParameter("@ACC_NO", fd_obj._ACC_NO);
            ObjDB.AddParameter("@FD_HOLD_NM", fd_obj._FD_HOLD_NM);
            //ObjDB.AddParameter("@OCCUPATION", fd_obj._OCCUPATION);
            ObjDB.AddParameter("@BANK_NAME", fd_obj._BANK_NAME);
            ObjDB.AddParameter("@BRANCH_NAME", fd_obj._BRANCH_NAME);
            ObjDB.AddParameter("@HOUSE_CONS", fd_obj._HOUSE_CONS);





            int i = ObjDB.ExecuteNonQuery("Proc_update_FDDetail");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }



    //changes by jitin 13-07-2011

    public DataSet DisplayDatainPOPUP(int famid, int instno)
    {


        ObjDB.AddParameter("@FMLY_ID", famid);
        ObjDB.AddParameter("@INST_ISCM_NO", instno);
        return ObjDB.ExecuteDataSet("Proc_Tiger_DisplayDatainPOPUP");

    }
    public DataSet ShowSellerData(int famid)
    {

        ObjDB.AddParameter("@FMLY_ID", famid);
        return ObjDB.ExecuteDataSet("Proc_Tiger_ShowSellerData");

    }
    public bool Proc_Update_SellerDetail(SellerEntity SE_obj, string fam_id)
    {
        try
        {
            ObjDB.AddParameter("@FMLY_ID", fam_id);
            ObjDB.AddParameter("@SELR_NM", SE_obj._SELR_NM);
            ObjDB.AddParameter("@SELR_PARNT", SE_obj._SELR_PARNT);
            ObjDB.AddParameter("@SELR_VILL_NM", SE_obj._SELR_VILL_NM);
            ObjDB.AddParameter("@SELR_TH_NM", SE_obj._SELR_TH_NM);
            ObjDB.AddParameter("@KHASRA_NO", SE_obj._KHASRA_NO);
            ObjDB.AddParameter("@SELR_LAND_AREA", SE_obj._SELR_LAND_AREA);
            ObjDB.AddParameter("@SELR_DT", SE_obj._SELR_DT);
            ObjDB.AddParameter("@SEL_AGRMT_DTL", SE_obj._SEL_AGRMT_DTL);
            ObjDB.AddParameter("@SELR_DISTRICT", SE_obj._SELR_DISTRICT);
            ObjDB.AddParameter("@FILE_NAME", SE_obj._FILE_NAME);
            ObjDB.AddParameter("@SELR_FUL_ADD", SE_obj._SELR_FUL_ADD);
            ObjDB.AddParameter("@ST_NAME", SE_obj._ST_NAME);
            ObjDB.AddParameter("@GP_NAME", SE_obj._GP_NAME);
            ObjDB.AddParameter("@DISTANCE", SE_obj._DISTANCE);


            int i = ObjDB.ExecuteNonQuery("Proc_Update_SellerDetail");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }


    public DataSet Proc_CheckInstallment(string fam_id)
    {
        ObjDB.AddParameter("@FMLY_ID", fam_id);
        return ObjDB.ExecuteDataSet("Proc_CheckInstallment");

    }
    public DataSet Proc_CheckInstallment_For_Infar(int fam_id)
    {
        ObjDB.AddParameter("@FMLY_ID", fam_id);
        return ObjDB.ExecuteDataSet("Proc_CheckInstallment_For_Infar");

    }


    public bool Proc_update_AdhikarPatraDetail(AdhikarPatra_Entity AE_obj, string fam_id)
    {
        try
        {
            ObjDB.AddParameter("@FMLY_ID", fam_id);
            ObjDB.AddParameter("@HOLDER_NAME", AE_obj._HOLDER_NAME);
            ObjDB.AddParameter("@REL_RES_AREA", AE_obj._REL_RES_AREA);
            ObjDB.AddParameter("@REL_AGR_AREA", AE_obj._REL_AGR_AREA);
            ObjDB.AddParameter("@REL_KHSRA_NO ", AE_obj._REL_KHSRA_NO);
            ObjDB.AddParameter("@REL_ADDRESS", AE_obj._REL_ADDRESS);
            ObjDB.AddParameter("@DATE_OF_ISSUE", AE_obj._DATE_OF_ISSUE);




            int i = ObjDB.ExecuteNonQuery("Proc_update_AdhikarPatraDetail");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public DataSet Display_Details_AdhikarPatra(string fam_id)
    {
        ObjDB.AddParameter("@FMLY_ID", fam_id);
        return ObjDB.ExecuteDataSet("Proc_Tiger_Display_Details_AdhikarPatra");

    }
    public DataSet Proc_Display_InstallmentINFO(string scm_id, string fam_id)
    {
        ObjDB.AddParameter("@SCHM_ID", scm_id);
        ObjDB.AddParameter("@FMLY_ID", fam_id);
        return ObjDB.ExecuteDataSet("Proc_Display_InstallmentINFO");


    }
    public DataSet Proc_CheckInstallment_For_Infar_Edit(int fam_id, double SUB_INST_ISCM_NO)
    {
        ObjDB.AddParameter("@FMLY_ID", fam_id);
        ObjDB.AddParameter("@SUB_INST_ISCM_NO", SUB_INST_ISCM_NO);
        return ObjDB.ExecuteDataSet("Proc_CheckInstallment_For_Infar_Edit");

    }

    public DataSet Proc_CheckInstallment_For_Infar_Edit_1stIns(int fam_id, double SUB_INST_ISCM_NO)
    {
        ObjDB.AddParameter("@FMLY_ID", fam_id);
        ObjDB.AddParameter("@SUB_INST_ISCM_NO", SUB_INST_ISCM_NO);
        return ObjDB.ExecuteDataSet("Proc_CheckInstallment_For_Infar_Edit_1stIns");

    }

    public bool Proc_update_Infra_Amount(Relocation_InstallmentEntity RI_Entity_obj, string fam_id, string schemeid)
    {
        try
        {
            ObjDB.AddParameter("@FMLY_ID", fam_id);
            ObjDB.AddParameter("@INFRA_AMT", RI_Entity_obj._INFRA_AMT);
            ObjDB.AddParameter("@SCHM_ID", "3");
            int i = ObjDB.ExecuteNonQuery("Proc_update_Infra_Amount");
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public DataSet CalculateValueforland(int viilid1)
    {
        ObjDB.AddParameter("@VILL_ID", viilid1);
        return ObjDB.ExecuteDataSet("Proc_CalculateValueforland");

    }

    public DataSet Proc_CheckDate_For_Option1A(string fid, string iid, string sid)
    {
        ObjDB.AddParameter("@FMLY_ID", fid);
        ObjDB.AddParameter("@INST_ISCM_NO", iid);
        ObjDB.AddParameter("@SCHM_ID", sid);
        return ObjDB.ExecuteDataSet("Proc_CheckDate_For_Option1A");


    }
    public DataSet Proc_CheckDate_For_Option1B(string fid, string iid, string sid)
    {
        ObjDB.AddParameter("@FMLY_ID", fid);
        ObjDB.AddParameter("@SUB_INST_ISCM_NO", iid);
        ObjDB.AddParameter("@SCHM_ID", sid);
        return ObjDB.ExecuteDataSet("Proc_CheckDate_For_Option1B");

    }


    public DataSet Proc_CheckInstallmentupdated(string fam_id)
    {
        ObjDB.AddParameter("@FMLY_ID", fam_id);
        return ObjDB.ExecuteDataSet("Proc_CheckInstallmentupdated");

    }



}



