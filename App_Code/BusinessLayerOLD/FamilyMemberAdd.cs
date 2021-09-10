using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;


/// <summary>
/// Summary description for FamilyMemberAdd
/// </summary>
public class FamilyMemberAdd
{
    public DataTable GetByID(long sno, string Path)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds.ReadXml(Path + "/WriteReadData/XMLFILE/FamilyMembers.xml");

        DataTable dt_ret = ds.Tables[0];
        int a = 0;
        int b = 0;
        for (b = 0; b <= dt_ret.Rows.Count - 1; b++)
        {
            if (sno ==Convert.ToInt32(dt_ret.Rows[b]["sno"]))
            {
                DataRow dr = null;
                dt.Columns.Add("sno");
                dt.Columns.Add("name");
                dt.Columns.Add("relation");
                dt.Columns.Add("fathername");
                dt.Columns.Add("age");
                dt.Columns.Add("sex");
                dt.Columns.Add("cast");
                dt.Columns.Add("voterno");
                dt.Columns.Add("contactno");
                dt.Columns.Add("education");
                dt.Columns.Add("occupation");
                dt.Columns.Add("income"); 
                
                dr = dt.NewRow();
                dr["sno"] = dt_ret.Rows[b]["sno"];
                dr["name"] = dt_ret.Rows[b]["name"];
                dr["relation"] = dt_ret.Rows[b]["relation"];
                dr["fathername"] = dt_ret.Rows[b]["fathername"];
                dr["age"] = dt_ret.Rows[b]["age"];
                dr["sex"] = dt_ret.Rows[b]["sex"];
                dr["cast"] = dt_ret.Rows[b]["cast"];
                dr["voterno"] = dt_ret.Rows[b]["voterno"];
                dr["contactno"] = dt_ret.Rows[b]["contactno"];
                dr["education"] = dt_ret.Rows[b]["education"];
                dr["occupation"] = dt_ret.Rows[b]["occupation"];
                dr["income"] = dt_ret.Rows[b]["income"];
                dt.Rows.Add(dr);
                return dt;
            }
        }
        return dt;
    }
    public DataTable GetAll(string Path)
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        ds.ReadXml(Path + "/WriteReadData/XMLFILE/FamilyMembers.xml");
        DataTable dt_ret = ds.Tables[0];
        return dt_ret;

    }


    public int Insert(string name, string relation, string fathername, string age, string sex, string cast, string voterno, string contactno, string edu, string occu, string income, string Path)
    {
        try
        {
            DataRow dr = null;
            DataSet ds = new DataSet();
            ds.ReadXml(Path + "/WriteReadData/XMLFILE/FamilyMembers.xml");
          
            dr = ds.Tables[0].NewRow();
            if (ds.Tables[0].Rows.Count > 0)
            {
                dr["sno"] = Convert.ToInt32(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["sno"]) + 1;
            }
            else
            {
                dr["sno"] = 1;
            }
            dr["name"] = name;
            dr["relation"] = relation;
            dr["fathername"] = fathername;
            dr["age"] = age;
            dr["sex"] = sex;
            dr["cast"] = cast;
            dr["voterno"] = voterno;
            dr["contactno"] = contactno;
            dr["education"] = edu;
            dr["occupation"] = occu;
            dr["income"] = income;
            ds.Tables[0].Rows.Add(dr);
            ds.WriteXml(Path + "/WriteReadData/XMLFILE/FamilyMembers.xml", XmlWriteMode.WriteSchema);
            return 1;
        }
        catch (Exception ex)
        {
            return 0;
        }

    }

    public int Update(int sno, string name, string relation, string fathername, string age, string sex, string cast, string voterno, string contactno, string edu, string occu, string income, string Path)
    {
        try
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Path + "/WriteReadData/XMLFILE/FamilyMembers.xml");
            DataRow dr = null;
            dr = ds.Tables[0].NewRow();
            int a = 0;
            int b = 0;
            for (b = 0; b <= ds.Tables[0].Rows.Count - 1; b++)
            {

                if (sno ==Convert.ToInt32( ds.Tables[0].Rows[b]["sno"]))
                {

                    ds.Tables[0].Rows[b]["sno"] = sno;
                    ds.Tables[0].Rows[b]["name"] = name;
                    ds.Tables[0].Rows[b]["relation"] = relation;
                    ds.Tables[0].Rows[b]["fathername"] = fathername;
                    ds.Tables[0].Rows[b]["age"] = age;
                    ds.Tables[0].Rows[b]["cast"] = cast;
                    ds.Tables[0].Rows[b]["voterno"] = voterno;
                    ds.Tables[0].Rows[b]["contactno"] = contactno;
                    ds.Tables[0].Rows[b]["education"] = edu;
                    ds.Tables[0].Rows[b]["occupation"] = occu;
                    ds.Tables[0].Rows[b]["income"] = income;
                }
            }
            return 1;
        }
        catch (Exception ex)
        {
            return 0;
        }

    }
}
