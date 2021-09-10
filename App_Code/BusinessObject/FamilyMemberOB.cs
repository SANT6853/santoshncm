using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FamilyMemberOB
/// </summary>
public class FamilyMemberOB
{
    public FamilyMemberOB()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int? MemberID { get; set; }


    public int? familyid { get; set; }
    public string MemberName { get; set; }


    public int? maritalstatus { get; set; }

    public int? Relation { get; set; }
    public int? Age { get; set; }

    public int? Year_Month { get; set; }

    public int? Castcategory { get; set; }
    public string ValidCardName { get; set; }
    public string ValidCardNo { get; set; }
    public string Gender { get; set; }
    public string ContactNo { get; set; }
    public string Education { get; set; }
    public int? Occupation { get; set; }

    public decimal AnualIncome { get; set; }

}