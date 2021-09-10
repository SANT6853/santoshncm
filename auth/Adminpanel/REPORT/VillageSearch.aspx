<%@ Page Title="NTCA:Total Villages Report for a Reserves" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="VillageSearch.aspx.cs" Inherits="auth_Adminpanel_REPORT_VillageSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
    <script type="text/javascript">

        var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
        var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
        var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
        var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
        var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });


</script>
   <script language="javascript" type="text/javascript">
       function IMG1_onclick() {

       }


       /****************************************************
           
       ****************************************************/
       var win = null;
       function NewWindow(mypage, myname, w, h, scroll, pos) {
           if (pos == "random") { LeftPosition = (screen.availWidth) ? Math.floor(Math.random() * (screen.availWidth - w)) : 50; TopPosition = (screen.availHeight) ? Math.floor(Math.random() * ((screen.availHeight - h) - 75)) : 50; }
           if (pos == "center") { LeftPosition = (screen.availWidth) ? (screen.availWidth - w) / 2 : 50; TopPosition = (screen.availHeight) ? (screen.availHeight - h) / 2 : 50; }
           if (pos == "default") { LeftPosition = 50; TopPosition = 50 }
           else if ((pos != "center" && pos != "random" && pos != "default") || pos == null) { LeftPosition = 0; TopPosition = 20 }
           settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',location=no,directories=no,status=no,menubar=no,toolbar=no,resizable=yes';
           win = window.open(mypage, myname, settings);
           if (win.focus) { win.focus(); }
       }
       function IMG1_onclick() {

       }
</script>
 
 <script type="text/javascript">
<!--
    function MM_openBrWindow(theURL, winName, features) { //v2.0

        window.open(theURL, winName, features);
    }
    //-->
    </script>  
<div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background:#fff;">	
<div class="inner-content-right">
        <table width="99%" border="0" align="center" cellpadding="3" cellspacing="1" class="table-2">
           <tr>
		   <td colspan="3" style="border-bottom: 3px solid #005529; "><h3 style="color: #005529;">Total Villages Report for a Reserves</h3></td>
		   
    
  </tr>
  
  
   
            <tr >
                <td width="33%" class="black-text" align="left" style="padding-top:20px; font-size:initial;">
                 <span  >
                    <asp:LinkButton ID="lnlbtn" runat="server" OnClick="lnlbtn_Click" ForeColor="#3F5E1B">Click Here To View Report</asp:LinkButton>
                    </span>
                </td>
                <td width="33%"  align="center" >
                    &nbsp;<asp:Label ID="lblnodatafound" runat ="server" ForeColor="red" ></asp:Label>
                </td>
                <td width="33%" align="right" >
                
                </td>
            </tr>
			<tr>
				<td width="33%" align="" style="padding-top:15px; font-size:initial;">
                <span  >
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" ForeColor="#3F5E1B" >Click Here To View Dynamic Report</asp:LinkButton></span>
                </td>
                
			</tr>
         
            
        </table>
     <br />
    <asp:Button ID="BtnBackConsoldateReport" Visible="false" runat="server" Text="Back" CssClass="btn btn-primary btn-add"
                                        OnClick="BtnBackConsoldateReport_Click" />
    </div>
   
	</div>
</asp:Content>

