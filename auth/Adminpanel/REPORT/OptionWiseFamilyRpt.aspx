<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="OptionWiseFamilyRpt.aspx.cs" Inherits="auth_Adminpanel_REPORT_OptionWiseFamilyRpt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
<style>
	.table-2 td {
		text-align: left;
		padding-bottom: 4px;
	}
	.form-horizontal .control-label {
		padding-top: 7px;
		margin-bottom: 0;
		text-align: left;
	}
</style>
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

        var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
        var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
        var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
        var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
        var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });


    </script>
    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
        <div class="inner-content-right">

            <table width="100%" align="center" cellpadding="3" cellspacing="1" class="table-2">
                <tr>
                    <td colspan="6" style="border-bottom: 3px solid #005529;">
                        <h3 style="color: #005529;">Family Management Page</h3>
                    </td>

                </tr>



                <tr>
                    <td colspan="4" align="center">
                        <asp:Label ID="lblMsg" runat="server" ForeColor="red">
                        </asp:Label>
                    </td>
                </tr>

                <%--<td width="7%" class="black-text" >
         Tiger
         Reserve Name</td>--%>
      
     
       </tr>
	
     <tr>
         <td><span class="black-text" align="center"></span></td>
         <%-- <td width="20%" align="center">
         
         <asp:DropDownList ID="ddlselectreserve" runat="server" CssClass ="textfield-drop" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="ddlselectreserve_SelectedIndexChanged">
         </asp:DropDownList>
     </td>--%>
     </tr>

            </table>
            <div class="form-horizontal">
            <div class="col-sm-12" style="padding-top: 20px;">
                 <%if (Session["UserType"].ToString().Equals("1"))
                          {%>
                <div class="col-md-6 col-sm-6 col-xs-12">
					<div class="form-group">
						<label class="col-sm-4 col-md-4 col-xs-12 control-label">State name:</label>
                        <div class="col-md-8 col-sm-8 col-xs-12">                      
                           <asp:DropDownList ID="DdlStateName" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DdlStateName_SelectedIndexChanged"></asp:DropDownList>
						</div>
					</div>
                </div>

                 <%} %>
                  <%if (Session["UserType"].ToString().Equals("1"))
                          {%>
                 <div class="col-md-6 col-sm-6 col-xs-12">
					<div class="form-group">
						<label class="col-sm-4 col-md-4 col-xs-12 control-label">Tiger Reserve Name</label>
                        <div class="col-md-8 col-sm-8 col-xs-12">                      
                            <asp:DropDownList ID="ddlselectreserve" runat="server"  CssClass="textfield-drop form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlselectreserve_SelectedIndexChanged">
                            </asp:DropDownList>
						</div>
					</div>
                </div>

                 <%} %>

                <div class="col-md-6 col-sm-6 col-xs-12">
					<div class="form-group">
						<label class="col-sm-4 col-md-4 col-xs-12 control-label">Village Name</label>
                        <div class="col-md-8 col-sm-8 col-xs-12"> 
                            <asp:DropDownList ID="ddlselectname" runat="server" CssClass="textfield-drop form-control" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
					<div class="form-group">
						<label class="col-sm-4 col-md-4 col-xs-12 control-label">Options</label>
                        <div class="col-md-8 col-sm-8 col-xs-12">
                            <asp:DropDownList ID="ddlselectscheme" runat="server" AutoPostBack="True" CssClass="textfield-drop form-control">
                                <asp:ListItem Value="0" Text="Select Option"></asp:ListItem>
                                <asp:ListItem Value="1" Text="I"></asp:ListItem>
                                <asp:ListItem Value="3" Text="II"></asp:ListItem>                               
                            </asp:DropDownList>
                        </div>
                       
                    </div>
                </div>
				<div class="col-sm-10">
                    <div class="form-group">
                        <div class="col-md-8 col-sm-8 col-xs-12">
                            <asp:Button ID="ImageButton1" runat="server" Text="Search" CssClass="btn btn-primary btn-add" CausesValidation="false" OnClick="ImageButton1_Click" />
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <!-- end of inner-content-right -->
        <div style="clear: both"></div>
    </div>
</asp:Content>

