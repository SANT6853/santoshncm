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
using System.Net.Mail;
using System.Net;


//using System.Net.Mail;



 
/// <summary>
/// Summary description for DBOPERATION 
/// </summary>
public class DBOPERATION
{
    private SqlConnection con;
    private SqlCommand cmd;
    private SqlDataAdapter adp;
    private DataTable dt;
    private String constr= ConfigurationManager.ConnectionStrings["csConnectionString"].ConnectionString;
   // private SqlDataReader dr;
    private DataSet ds;
    
    public bool ExecuteNonQueryDB(string StoredProc, SqlParameter[]  SqlParam) 
    {
       bool Flag = false;
        try 
        { 
            con = new SqlConnection(constr);
            cmd = new SqlCommand(StoredProc,con); 
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(SqlParam);
            cmd.ExecuteNonQuery();
            con.Close();
            Flag = true;
        }
        catch(Exception ex)
        {
            Flag = true;
               System.Web.HttpContext.Current.Response.Write(ex.Message);
        }
        return Flag;
    }
    public bool ExecuteNonQuery(string StoredProc, string SqlParam,string Param)
    {
        bool Flag = false;
        try
        {
            con = new SqlConnection(constr);
            cmd = new SqlCommand(StoredProc, con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(SqlParam, Param);
            cmd.ExecuteNonQuery();
            con.Close();
            Flag = true;
        }
        catch (Exception ex)
        {
            Flag = true;
            System.Web.HttpContext.Current.Response.Write(ex.Message);
        }
        return Flag;
    }

    //public List <string> DataList(string StoredProc, string SqlParam, string Param)
    //{
    //   // //bool Flag = false;
    //   // //try
    //   // //{
    //   // //    int i = 0;
    //   // //    List<string> ddlist = new List<string>();

    //   // //    con = new SqlConnection(constr);
    //   // //    cmd = new SqlCommand(StoredProc, con);
    //   // //    con.Open();
    //   // //    cmd.CommandType = CommandType.StoredProcedure;
    //   // //    cmd.Parameters.AddWithValue(SqlParam,Param);
    //   // //    dr=cmd.ExecuteQuery();
    //   // //    con.Close();
    //   // //    while (dr.Read())
    //   // //    {
    //   // //        ddlist.Add(dr[i].ToString());

    //   // //    }

    //   // }
    //   // catch (Exception ex)
    //   // {
          
    //   //     System.Web.HttpContext.Current.Response.Write(ex.Message);
    //   // }
    //   //// return ddlist;
    //}
    public DataTable GetDataTable(String StoredProcedure, String SqlParam, String Param)
    {
        con = new SqlConnection(constr);
        cmd = new SqlCommand(StoredProcedure, con);        
        cmd.Parameters.AddWithValue(SqlParam, Param);        
        cmd.CommandType = CommandType.StoredProcedure;
        //Create new dataadaptor
        adp = new SqlDataAdapter(cmd);
        //Create a new datatable
        dt = new DataTable();
        //open the connection
        con.Open();
        //fill the datatable from adapter
        adp.Fill(dt);
        //Close the connection 
        con.Close();
        //return datatable
        // GetDataTable = dt;

        //destroy the objects
        finalise();
        return dt;
    }
  
    public DataTable GetDataTable(String StoredProcedure)
    {
        con = new SqlConnection(constr);
        cmd = new SqlCommand(StoredProcedure, con);

        //cmd.Parameters.AddWithValue(SqlParam, Param);

        //--Needed--//cmd.CommandType = CommandType.StoredProcedure;
        //Create new dataadaptor
        adp = new SqlDataAdapter(cmd);
        //Create a new datatable
        dt = new DataTable();
        //open the connection
        con.Open();
        //fill the datatable from adapter
        adp.Fill(dt);
        //Close the connection 
        con.Close();
        //return datatable
        // GetDataTable = dt;

        //destroy the objects
        finalise();
        return dt;
    }

    public DataTable GetDataTable(String StoredProcedure,SqlParameter[] param )
    {
        con = new SqlConnection(constr);
        cmd = new SqlCommand(StoredProcedure, con);
        cmd.Parameters.Clear();
        cmd.Parameters.AddRange(param);
        cmd.CommandType = CommandType.StoredProcedure;
        //Create new dataadaptor
        adp = new SqlDataAdapter(cmd);
        //Create a new datatable
        dt = new DataTable();
        //open the connection
        con.Open();
        //fill the datatable from adapter
        adp.Fill(dt);
        //Close the connection 
        con.Close();
        //return datatable
        // GetDataTable = dt;

        //destroy the objects
        finalise();
        return dt;
    }
    public DataSet GetDataSet(String StoredProcedure, SqlParameter[] param)
    {
        con = new SqlConnection(constr);
        cmd = new SqlCommand(StoredProcedure, con);
        cmd.Parameters.Clear();
        cmd.Parameters.AddRange(param);
        cmd.CommandType = CommandType.StoredProcedure;
        //Create new dataadaptor
        adp = new SqlDataAdapter(cmd);
        //Create a new datatable
        ds = new DataSet();
        //open the connection
        con.Open();
        //fill the datatable from adapter
        adp.Fill(ds);
        //Close the connection 
        con.Close();
        //return datatable
        // GetDataTable = dt;

        //destroy the objects
        finalise();
        return ds;
    }
    public DataTable GetDataTable(string StoredProcedure, bool Parameter, string SqlParam, Int64 Param)
    {
        DataTable functionReturnValue = null;

        //Create new connection to database
        con = new SqlConnection(constr);

        //Create new sql command
        cmd = new SqlCommand(StoredProcedure, con);
        if (Parameter == true)
        {
            cmd.Parameters.AddWithValue(SqlParam, Param);
        }
        cmd.CommandType = CommandType.StoredProcedure;
        //Create new dataadaptor
        adp = new SqlDataAdapter(cmd);
        //Create a new datatable
        dt = new DataTable();
        //open the connection
        con.Open();
        //fill the datatable from adapter
        adp.Fill(dt);
        //Close the connection 
        con.Close();
        //return datatable
        functionReturnValue = dt;

        //destroy the objects
        adp = null;
        cmd = null;
        con = null;
        return functionReturnValue;

    }

    //public DataTable GetDataTable(string StoredProcedure, bool Parameter, string SqlParam, Int64 Param)
    //{
    //    DataTable functionReturnValue = null;

    //    //Create new connection to database
    //    con = new SqlConnection(constr);

    //    //Create new sql command
    //    cmd = new SqlCommand(StoredProcedure, con);
    //    if (Parameter == true)
    //    {
    //        cmd.Parameters.AddWithValue(SqlParam, Param);
    //    }
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    //Create new dataadaptor
    //    adp = new SqlDataAdapter(cmd);
    //    //Create a new datatable
    //    dt = new DataTable();
    //    //open the connection
    //    con.Open();
    //    //fill the datatable from adapter
    //    adp.Fill(dt);
    //    //Close the connection 
    //    con.Close();
    //    //return datatable
    //    functionReturnValue = dt;

    //    //destroy the objects
    //    adp = null;
    //    cmd = null;
    //    con = null;
    //    return functionReturnValue;

    //}


    public DataTable GetDataTable(string StoredProcedure, bool Parameter, string SqlParam, string Param)
    {
        DataTable functionReturnValue = null;

        //Create new connection to database
        con = new SqlConnection(constr);

        //Create new sql command
        cmd = new SqlCommand(StoredProcedure, con);
        if (Parameter == true)
        {
            cmd.Parameters.AddWithValue(SqlParam, Param);
        }
        cmd.CommandType = CommandType.StoredProcedure;
        //Create new dataadaptor
        adp = new SqlDataAdapter(cmd);
        //Create a new datatable
        dt = new DataTable();
        //open the connection
        con.Open();
        //fill the datatable from adapter
        adp.Fill(dt);
        //Close the connection 
        con.Close();
        //return datatable
        functionReturnValue = dt;

        //destroy the objects
        adp = null;
        cmd = null;
        con = null;
        return functionReturnValue;

    }
    public void finalise()
    {
        adp = null;
        cmd = null;
        con = null;

    }
    //public DBOPERATION()
    //{
	
    //}
  //public bool SendEmail( string From, string Msg)// send mail 
  //{   
  //    SmtpClient smtpClient = new SmtpClient();
     

  //    try
  //    {
  //        MailAddress fromAddress = new MailAddress(From, Msg);
  //        MailMessage message = new System.Net.Mail.MailMessage();
  //        // You can specify the host name or ipaddress of your server
  //        // Default in IIS will be localhost 
  //        smtpClient.Host = "localhost";

  //        //Default port will be 25
  //        smtpClient.Port = 25;

  //        //From address will be given as a MailAddress Object
  //        message.From = fromAddress;

  //        // To address collection of MailAddress
  //        message.To.Add("mayank.mishra@netcreativemin.co.in");
  //        message.Subject = "Feedback";

  //        // CC and BCC optional
  //        // MailAddressCollection class is used to send the email to various users
  //        // You can specify Address as new MailAddress("admin1@yoursite.com")
  //        //message.CC.Add("admin1@yoursite.com");
  //        //message.CC.Add("admin2@yoursite.com");

  //        // You can specify Address directly as string
  //      //  message.Bcc.Add(new MailAddress("admin3@yoursite.com"));
  //       // message.Bcc.Add(new MailAddress("admin4@yoursite.com"));

  //        //Body can be Html or text format
  //        //Specify true if it  is html message
  //        message.IsBodyHtml = false;

  //        // Message body content
  //        message.Body = msg;

  //        // Send SMTP mail
  //        smtpClient.Send(message);

  //        //lblStatus.Text = "Email successfully sent.";
  //    }
  //    catch (Exception ex)
  //    {
  //       // lblStatus.Text = "Send Email Failed." + ex.Message;
  //    }

  // //    MailMessage objMail = new MailMessage();
  // //    objMail.To = To;
  // //  //  objMail.Cc = Cc;
  // //   //objMail.Bcc = Bcc;
  // //   //objMail.Subject = Subject;
  // //   if (From != string.Empty)
  // //   {
  // //      objMail.From = From;
  // //  }
  // //    else
  // // //    {
  // // //        objMail.From = "mani.bhushan@netcreativemind.co.in";
  // // //    }
  // //objMail.BodyFormat = MailFormat.Html;
  // // objMail.Body = Msg;
  // //     System.Web.Mail.SmtpMail.SmtpServer = "netcreativemind.co.in";// server name 
  // //   SmtpMail.Send(objMail);
  //     return true;

  // }


    //public bool SendEmailDB(string Too, string From, string Msg)// send mail 
    //{    
    //    MailMessage objMail = new MailMessage();
    //    //MailMessage objMail = new MailMessage();
       
    //    objMail.To = Too;
    //    //objMail.Cc = Cc;
    //    //objMail.Bcc = Bcc;
    //    //objMail.Subject = Subject;
    //    if (From != string.Empty)
    //    {
    //        objMail.From = From;
    //    }
    //    else
    //    {
    //       // objMail.From = "mani.bhushan@netcreativemind.co.in";
    //    }
    //    objMail.BodyFormat = MailFormat.Html;
    //    objMail.Body = Msg;

    //    System.Web.Mail.SmtpMail.SmtpServer = "netcreativemind.co.in";// server name 

    //    SmtpMail.Send(objMail);
    //    return true;

    //}
 
    //public bool SendEmailDB(string too, string From1, string Msg)// send mail 
//    public bool SendEmailDB(FeedBackEntity fdEntityObj)
//{
//       // MailMessage objMail = new MailMessage();

//        MailMessage objFMail = new MailMessage();
//        //objFMail.To.Add(too);
//        objFMail.To.Add(fdEntityObj._rec_email);
//       // objFMail.CC.Add(Cc);
//       // objFMail.Bcc.Add(Bcc);
//       // objFMail.Subject(Subject);
//        if (fdEntityObj._feeder_email != string.Empty)
//        //if (From1 != string.Empty)
//        {
//            objFMail.From = new MailAddress(fdEntityObj._feeder_email);
//        }
//        else
//        {
//           // objFMail.From =new MailMessage( "mayank.mishra@netcreativemind.co.in");
//        }
//        objFMail.IsBodyHtml = true;
//        objFMail.Body = fdEntityObj._feeder_message;

//        SmtpClient smtp = new SmtpClient();
//        smtp.Host = "netcreativemind.co.in";
//        smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
//        objFMail.Priority = MailPriority.High;
//        smtp.Credentials = new NetworkCredential(" ashish.kumar", "123456");
//        smtp.Send(objFMail);
//        //System.Web.Mail.SmtpMail.SmtpServer = "netcreativemind.co.in";// server name 

//         smtp.Send(objFMail);
//        return true;

//    }
}
