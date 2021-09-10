using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GloballyStaticVariable
/// </summary>
public static class GloballyStaticVariable
{
    public static int SuperAdminUserID = 1;
    public static string SuperAdminUserName = "superadmin";
    public static int SuperAdminRole = 1;
    // 1) ProcessingStatus

    //a tiger reserve)
    public static int ProcessingID_FrwdByTigerReserve = 1;
    public static string ProcessingName_FrwdByTigerReserve = "Forwarded by TIGER RESERVE user send to STATE user only";

    // b state user)
    public static int ProcessingID_RtrnByStateUser = 2;
    public static string ProcessingName_RtrnByStateUser = "Return by STATE user send to TIGER RESERVE user only";

    public static int ProcessingID_FrwdByStateUser = 3;
    public static string ProcessingName_FrwdByStateUser = "Forwarded by STATE user send to NTCA user only";
    // --
    // c ntca user)
    public static int ProcessingID_AprveByNtcaUser = 4;
    public static string ProcessingName_AprveByNtcaUser = "Approve by NTCA user send to STATE user only";

    public static int ProcessingID_RtrnByNtcaUser = 5;
    public static string ProcessingName_RtrnByNtcaUser = "Return by NTCA user send to STATE user only";
    static GloballyStaticVariable()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}