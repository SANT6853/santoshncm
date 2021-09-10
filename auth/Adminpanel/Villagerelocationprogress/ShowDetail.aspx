<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowDetail.aspx.cs" Inherits="auth_Adminpanel_Villagerelocationprogress_ShowDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<link href="../CSS/style.css" rel="stylesheet" type="text/css" /><link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

     <style type="text/css">



.btn-mid

{

font-size:10px;
font-weight:bold;

width:auto;

float:none;

background-color:#ece9da;

border:#b2bf5d 1px solid;
color:#ffffff;

}




.Progress_table tr th{ border:1px solid #cccccc;   padding:5px; background:#E1E0C4;}
.Progress_table tr td{border:1px solid #eeeeee; padding:5px 10px;}


.btn-mid

{
	background:url(../imagesnew/search.png) repeat-x;
	/*height:50px;*/
	float:right;
	
}
.table-2 td{
padding:10px;
text-align:left;
width:23% !important;
}
.textfield{width:70%}
table tr td{
text-align:left;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
   <div class="container" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background:#fff;">
   <div class="wrapper-content" style="padding-top:0px;">	
    <table width="100%" border="0" cellspacing="0" cellpadding="0" Class= "Progress_table-2 table table-bordered" >
        <tr>
		    <td colspan="3" style="text-center; background:#005529"><h4 style="color:#fff; text-align:center; margin:3px;">Village Relocation Progress Report</h4></td>
            
          
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:Button 
                    ID="btnback" runat="server"  Text="Back" 
                    onclick="btnback_Click" class="btn btn-primary pull-right"/></td>
            
        </tr>
        <tr>
            
            <td width="48%" align="right">
               <lable id="dare"  > Report As on Date : </lable>
            </td>
            <td width="52%" align="left">
                <asp:TextBox ID="txtDate" ReadOnly="true" CssClass ="textfield form-control" runat="server"></asp:TextBox>
               
                 
                            
                           
            </td>
        </tr>
          <tr>
            <td align="right">
            
            <lable>Name of the State :</lable>
            </td>
            <td align="left">
         
                <asp:TextBox ID="txtDate0" ReadOnly="true" CssClass ="textfield form-control" runat="server"></asp:TextBox>
               
                 
                            
                           
            </td>
          
        </tr>
        <tr>
            <td align="right">
             
            <lable>Name of the Tiger Reserve :</lable>
            </td>
            <td align="left">
                
                <asp:TextBox ID="txtReserve" ReadOnly="true" CssClass ="textfield form-control" runat="server"></asp:TextBox> 
            </td>
            
        </tr>
        <tr>
            
            <td align="right">
           
            <lable>No. of the villages in the notified Core (CTH):</lable>
            </td>
            <td align="left">
                              
                
                <asp:TextBox ID="txtNovillage" ReadOnly="true"  CssClass ="textfield form-control" runat="server"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td align="right">
             
            <lable>No. of the families in the notified Core (CTH):</lable>
            </td>
            <td align="left">
              
                <asp:TextBox ID="txtNooffamily" ReadOnly="true" CssClass ="textfield form-control" runat="server"></asp:TextBox>
            </td>
          
        </tr>
        <tr>
            <td align="right">
           
            <lable>No. of villages Relocated from the notified<br />
&nbsp;Core (CTH) since the inception of the Project Tiger :</lable>
            </td>
            <td align="left">
             
                <asp:TextBox ID="txtnoofRelocatevillage" ReadOnly="true" CssClass ="textfield form-control" runat="server"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            
            <td align="right">
               
            <lable>No. of families Relocated from the notified 
                <br />
                core (CTH) since the inception of the Project Tiger :</lable>
            </td>
            <td align="left">
            
                <asp:TextBox ID="txtnoofRelocatedFamily" ReadOnly="true" CssClass ="textfield form-control" runat="server"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td align="right" style="">
               
            <lable>No. of villages remaining inside the core (CTH) :</lable>
            </td>
            <td align="left" style="">
             
                <asp:TextBox ID="txtnoofVilageremaining" ReadOnly="true" CssClass ="textfield form-control" runat="server" 
                    ></asp:TextBox>
                <br />
            </td>
          
        </tr>
        <tr>
            <td align="right">
              
            <lable>No.of families remaining inside the core (CTH) :</lable>
            </td>
            <td align="left">
            
                <asp:TextBox ID="txtnooffamilyreaming" ReadOnly="true" CssClass ="textfield form-control" runat="server"></asp:TextBox>
            </td>
            
        </tr>
       
          <tr>
            <td colspan="2" align="center">
            
            <b>Package with which no of Villages/families relocated :</b>

            </td>
          
        </tr>
        <tr>
            <td align="right">
          
            <lable align="right">10 Lakh per Family</lable>
            </td>
            <td align="left">

                <asp:TextBox ID="txtAmountperfamily" ReadOnly="true" CssClass ="textfield form-control" runat="server"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            
            <td align="right">
             
            <lable>Land Package</lable>
            </td>
            <td align="left">
           
                <asp:TextBox ID="txtlandpackage" ReadOnly="true" CssClass ="textfield form-control" runat="server"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td align="right"> 
              
            <lable>1 Lakh per Family & Land</lable>
            </td>
            <td align="left">
               
                <asp:TextBox ID="txtlandmoneyperfamily" ReadOnly="true" CssClass ="textfield form-control" runat="server"></asp:TextBox>
            </td>
          
        </tr>
        <tr>
            <td align="right">
           
            <lable>Villages Relocated with any other Package :</lable>
            </td>
            <td align="left">
              
                <asp:TextBox ID="txtvillageReAnyotherpackge" ReadOnly="true" CssClass ="textfield form-control" runat="server"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            
            <td align="right">
               <label> Remarks :</label>
            </td>
            <td align="left">
             
                <asp:TextBox ID="txtremarks" runat="server" ReadOnly="true" 
                    CssClass ="textfield form-control" TextMode="MultiLine"  ></asp:TextBox>
            </td>
     </tr>
          

   
    </table>
    </div>
	</div>
    </form>
</body>
</html>
