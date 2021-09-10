<%@ Page Title="NTCA:Relocation Site Report" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="Relocation_Site_Report.aspx.cs" Inherits="auth_Adminpanel_RelocationSite_Relocation_Site_Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
<style>
.table-2 td {
	text-align: left;
	padding-bottom: 4px;
}
.container-fluid {
	margin-bottom: 80px !important;
}
.HeadkkkerRow {
	background-color:yellow;
}
</style>
<style type="text/css">
.form-horizontal .control-label {
    padding-top: 7px;
    margin-bottom: 0;
    text-align: left;
}
@media print {
a[href]:after {
	content: none !important;
}
img[src]:after {
	content: none !important;
}
* {
	font-size: 10px !important;
}
strong {
	font-weight: 400 !important;
}
#contentbody_btnprint, .page-sidebar, .page-heading, #contentbody_btnexporttoexel {
	display: none;
}

table {
}
th, td {
}
 @page {
 size: portrait;
}
.container-fluid {
	margin-top: 0 !important;
}
#contentbody_gvwork {
	width: 100%;
}
}
</style>
<script type="text/javascript">
	var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
	var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
	var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
	var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
	var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });
</script>
<div class="container-fluid" style="margin-bottom: 62px; background:#fff;">
  <div class="wrapper-content">
    <div class="inner-content-right">
      <div class="box box-primary1" style="margin-bottom: 25px;">
        <div class="box-header with-border">
          <h3 class="box-title" style="color: #005529;">Relocation Site Report</h3>
        </div>
      </div>
	  <div class="form-horizontal">
      <p>
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
      </p>
      <%if (Session["UserType"].ToString().Equals("1"))
                      {%>
      <div class="col-md-6 col-sm-6 col-xs-12">
        <div class="form-group">
          <label class="control-label col-md-4 col-sm-4 col-xs-12">Select state name :</label>
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
          <label class="control-label col-md-4 col-sm-4 col-xs-12">Tiger Reserve Name :</label>
          <div class="col-md-8 col-sm-8 col-xs-12">
            <asp:DropDownList ID="ddlselectreserve" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlselectreserve_SelectedIndexChanged" AutoPostBack="True"> </asp:DropDownList>
          </div>
        </div>
      </div>
      <%} %>
      <div class="col-md-6 col-sm-6 col-xs-12">
        <div class="form-group">
          <label class="control-label col-md-4 col-sm-4 col-xs-12">Village name :</label>
          <div class="col-md-8 col-sm-8 col-xs-12">
            <asp:DropDownList ID="ddlselectname" runat="server" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectname_SelectedIndexChanged1"> </asp:DropDownList>
          </div>
        </div>
      </div>
      <div class="col-md-12 col-sm-12 col-xs-12">
        <asp:Button ID="BtnBackConsoldateReport" Visible="false" runat="server" Text="Back" CssClass="btn btn-primary btn-add"
                                        OnClick="BtnBackConsoldateReport_Click" />
        <asp:Button ID="ImgbtnSubmit" runat="server" CssClass="btn btn-primary btn-add" Text="Search" OnClick="ImgbtnSubmit_Click" />
      </div>
      <br />
      <div class="col-md-12" id="imgscr" style="overflow-x:auto">
        <asp:Panel ID="panel" runat="server">
          <table width="100%" id="t1" runat="server" border="0" cellspacing="0" cellpadding="0" class="">
            <tr>
              <td></td>
              <%--(<%=Session["sStateName"] %>)--%>
              <td align="center" style="width: 41%; padding: 2px;" class="RelocationHeader" ><h3 style=" background-color:#f0ad4e;width:160px;color:black; padding:15px;">Relocation From</h3></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td align="center" style="width: 48%; padding: 2px;" class="RelocationHeader"><h3 style=" background-color:#f0ad4e; width:160px; color:black; padding:15px;">Relocated To</h3></td>
            </tr>
            <tr>
              <td colspan="13" align="center"><asp:GridView ID="gvforVillages" runat="server" AllowPaging="True" OnPageIndexChanging="gvforVillages_PageIndexChanging"
                                    PageSize="15" AutoGenerateColumns="False" bgColor="#FCF8ED"
                                    CellPadding="3" Width="100%"
                                    RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="mGrid table table-bordered table-striped" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
                  <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                  <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="mGrid table table-bordered table-striped" BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                  <RowStyle CssClass="drow" BackColor="#FFF7E7" ForeColor="#8C4510" />
                  <AlternatingRowStyle CssClass="alt" />
                  <PagerStyle CssClass="pgr" HorizontalAlign="Center" ForeColor="#8C4510" />
                  <Columns>
                  <asp:TemplateField  HeaderText="S No.">
                    <ItemStyle HorizontalAlign="Center" BackColor="#ffffff" />
                    <ItemTemplate>
                      <div>
                        <asp:Label ID="lblSno" runat="server" Width="28" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                      </div>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Tiger Reserve name">
                    <ItemStyle HorizontalAlign="Center" BackColor="#ffffff" />
                    <ItemTemplate>
                      <div> <%#DataBinder.Eval(Container.DataItem, "TigerReserveName")%> </div>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="State">
                    <ItemStyle HorizontalAlign="Center" BackColor="#ffffff" />
                    <ItemTemplate>
                      <div> <%#DataBinder.Eval(Container.DataItem, "statename")%> </div>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Village Name ">
                    <ItemStyle HorizontalAlign="Center" BackColor="#ffffff" />
                    <ItemTemplate>
                      <div>
                        <asp:Label ID="lblstname" runat="server" Text='<%#Eval("tvillage") %>'></asp:Label>
                      </div>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <%-- <asp:TemplateField HeaderText="State">
                     <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                    <strong>
                        <asp:Label ID="lbldtname" runat="server" Text='<%#Eval("tvstate") %>' ></asp:Label>
                        </strong>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                  <asp:TemplateField HeaderText="District">
                    <ItemStyle HorizontalAlign="Center" BackColor="#ffffff" />
                    <ItemTemplate>
                      <div> <%#DataBinder.Eval(Container.DataItem, "District_name")%> </div>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <%-- <asp:TemplateField HeaderText="Tiger Reserve Name">
                   <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                    <strong>
                    
                     <%#DataBinder.Eval(Container.DataItem, "RSRV_AREA_NM")%>
                    
                     </strong>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                  <asp:TemplateField HeaderText="Tehsil" Visible="false">
                    <ItemStyle HorizontalAlign="Center" BackColor="#ffffff" />
                    <ItemTemplate>
                      <div> <%#DataBinder.Eval(Container.DataItem, "FromTehSilName")%> </div>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Gram panchayat">
                    <ItemStyle HorizontalAlign="Center" BackColor="#ffffff"/>
                    <ItemTemplate>
                      <div> <%#DataBinder.Eval(Container.DataItem, "FromGrampanChyatname")%> </div>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Address">
                    <ItemStyle HorizontalAlign="Center" BackColor="#ffffff"/>
                    <ItemTemplate>
                      <div> State:<%#DataBinder.Eval(Container.DataItem, "statename")%><br />
                        District: <%#DataBinder.Eval(Container.DataItem, "District_name")%><br />
                        Tehsil: <%#DataBinder.Eval(Container.DataItem, "FromTehSilName")%><br />
                        Gram panchayat:<%#DataBinder.Eval(Container.DataItem, "FromGrampanChyatname")%> </div>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center"  Width="80px" BackColor="#ffcc00"/>
                    <ItemTemplate> <strong>
                      <%--<img src="http://localhost:7352/images/arrow_li1.png"  />--%>
                      <img src="http://45.115.99.199/ntca_mis/images/arrow_li1.png" style="cursor: pointer;" />
                      <%--<asp:Image ID="Img" runat="server" Width="50px" ImageUrl="~/images/FromTo.jpg" />--%>
                      </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Tiger Reserve name">
                    <ItemStyle HorizontalAlign="Center" BackColor="#ffffff"/>
                    <ItemTemplate>
                      <div> <%#DataBinder.Eval(Container.DataItem, "TigerReserveName")%> </div>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="State">
                    <ItemStyle HorizontalAlign="Center" BackColor="#ffffff"/>
                    <ItemTemplate>
                      <div> <%#DataBinder.Eval(Container.DataItem, "Statename")%> </div>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Village Name ">
                    <ItemStyle HorizontalAlign="Center" BackColor="#ffffff"/>
                    <ItemTemplate>
                      <div> <%#DataBinder.Eval(Container.DataItem, "ToVillage")%> </div>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="District">
                    <ItemStyle HorizontalAlign="Center" BackColor="#ffffff"/>
                    <ItemTemplate>
                      <div> <%#DataBinder.Eval(Container.DataItem, "ToDisticname")%> </div>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Tehsil" Visible="false">
                    <ItemStyle HorizontalAlign="Center" BackColor="#ffffff"/>
                    <ItemTemplate>
                      <div>
                        <%--ToTehSilName
                                                    <%#DataBinder.Eval(Container.DataItem, "")%>--%>
                      </div>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Gram panchayat">
                    <ItemStyle HorizontalAlign="Center" BackColor="#ffffff"/>
                    <ItemTemplate>
                      <div> <%#DataBinder.Eval(Container.DataItem, "ToGrampanChyatname")%> </div>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Address">
                    <ItemStyle HorizontalAlign="Center" BackColor="#ffffff"/>
                    <ItemTemplate>
                      <div style="white-space: nowrap;">
                        <div> State:<%#DataBinder.Eval(Container.DataItem, "statename")%><br />
                          District: <%#DataBinder.Eval(Container.DataItem, "ToDisticname")%><br />
                          Gram panchayat:<%#DataBinder.Eval(Container.DataItem, "ToGrampanChyatname")%> </div>
                      </div>
                    </ItemTemplate>
                  </asp:TemplateField>
                  </Columns>
                  <PagerSettings Mode="Numeric" />
                  <PagerStyle BackColor="#FDF4C9" CssClass="white-text" Font-Bold="True" ForeColor="black"
                                        HorizontalAlign="Center" />
                  <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                  <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                  <SortedAscendingCellStyle BackColor="#FFF1D4" />
                  <SortedAscendingHeaderStyle BackColor="#B95C30" />
                  <SortedDescendingCellStyle BackColor="#F1E5CE" />
                  <SortedDescendingHeaderStyle BackColor="#93451F" />
                </asp:GridView></td>
            </tr>
            <tr>
              <td align="center" colspan="2"><%--<h4> <span style="color:Red;">*</span>  &nbsp; source from <%= Session["sTigerReserveName"].ToString()%> </h4>--%></td>
            </tr>
          </table>
        </asp:Panel>
      </div>
      <br />
      <div>
        <center>
          <asp:Button ID="btnprint" runat="server" CssClass="btn btn-primary btn-add" Text="Print" 
          onclick="btnprint_Click" />
          <asp:Button ID="btnexporttoexel"
          runat="server" CssClass="btn btn-primary btn-add" Text="Export to Excel" 
          onclick="btnexporttoexel_Click" />
          <asp:Button ID="BtnPdfExport" runat="server" Text="Export to Pdf" CssClass="btn btn-warning" OnClick="BtnPdfExport_Click"  />
        </center>
      </div>
    </div>
  </div>
  </div>
</div>
<script>
        $(document).ready(function () {
            $('#contentbody_gvforVillages').on('click', 'img', function () {
                document.getElementById("imgscr").scrollLeft += 100;
            });

        });
    </script>
</asp:Content>
