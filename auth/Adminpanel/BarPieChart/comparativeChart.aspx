<%@ Page Title="NTCA:Tiger Reserve Comparative Chart Report" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="comparativeChart.aspx.cs" Inherits="auth_Adminpanel_BarPieChart_comparativeChart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
.control-label {
    
    text-align: left;
}
</style>
     <%--<script type="text/javascript" src="https://www.google.com/jsapi"></script>--%>   
    <script src="<%#ResolveUrl("jsapi.js") %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
<div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background:#fff;">
    <div class="wrapper-content" style="padding-top:0px; padding-bottom:0px; min-height: 550px;">
    <div>
   
		<div class="box box-primary1" style="margin-bottom: 25px;">
						<div class="box-header with-border">
							<h3 class="box-title" style="color: #005529;">Chart Report</h3>
						</div>                    
					</div>
					<div class="row">
					<div class="col-md-8">
                        <div class="form-group">
                            <label class="col-sm-5 col-md-5 col-lg-3 control-label">Select Tiger reserve name:</label>
                            <div class="col-md-6">                               
                               <asp:DropDownList ID="DdTigerReserve" runat="server" CssClass="form-control"  ></asp:DropDownList>
                            </div>
                        </div>
                    </div>	
				</div>		
       <div class="row">
					<div class="col-md-8">
                        <div class="form-group">
                            <label class="col-sm-5 col-md-5 col-lg-3 control-label">Select status:</label>
                            <div class="col-md-6">                               
                               <asp:DropDownList ID="DDlStatus" runat="server" CssClass="form-control" >
                                   <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                   <asp:ListItem Text="Relocated" Value="1"></asp:ListItem>
                                   <asp:ListItem Text="Non-Relocated" Value="2"></asp:ListItem>
                                   <asp:ListItem Text="In-Progress" Value="3"></asp:ListItem>
                               </asp:DropDownList>
                            </div>
                        </div>
                    </div>	
				</div>	
        <div class="row">
					<div class="col-md-8">
                        <div class="form-group">
                             <label class="col-sm-5 col-md-5 col-lg-3 control-label"></label>
                            <div class="col-md-6">                            
                              <asp:Button ID="ImgbtnSubmit" runat="server" Text="Search" CssClass="btn btn-primary btn-add"  OnClick="ImgbtnSubmit_Click" />
                            </div>
                        </div>
                    </div>	
				</div>					
       
   </div>
     <div>
    <asp:Literal ID="lt" runat="server" ></asp:Literal>
   <div id="chart_div" style="width: 1000px; height: 400px;"></div>
    </div>
    </div>
    </div>
</asp:Content>

