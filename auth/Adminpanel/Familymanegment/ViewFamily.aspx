<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="ViewFamily.aspx.cs" Inherits="auth_Adminpanel_Familymanegment_ViewFamily" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">

    <div class="row">

        <!-- Column Chart-->

        <!-- <div class="col-lg-12 top15">
          <div class="ibox float-e-margins ">
            <div class="ibox-content top10" id="demo2">
              <div class="demo-container">
                <div>
                  <canvas id="barChart"></canvas>
                </div>
              </div>
            </div>
          </div>
        </div> -->
        <div class="clearfix"></div>

        <!-- tabs -->
        <div class="col-lg-12 top20 bottom30">
            <div class="tabs-container">
                <div class="bg_white">
                <div class="col-md-12">
                    <h2>View Family</h2>
                    </div>

                    <div class="col-md-6">

                        <label class="col-sm-4 control-label" for="exampleFormControlSelect1">Select State</label>
                        <div class="form-group col-md-8">
                            <asp:DropDownList ID="ddlstate" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="reqstate" Display="Dynamic" CssClass="help-block" ForeColor="Red" InitialValue="0" ControlToValidate="ddlstate" SetFocusOnError="true" ValidationGroup="val"
                                ErrorMessage="Select State" />
                        </div>
                    </div>
                    <div class="col-md-6">

                        <label class="col-sm-4 control-label" for="exampleFormControlSelect1">Select Tiger Reserves</label>
                        <div class="form-group col-md-8">

                            <asp:DropDownList ID="ddltigerreserve" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddltigerreserve_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="reqddltiger" Display="Dynamic" ForeColor="Red" CssClass="help-block" InitialValue="0" SetFocusOnError="true" ControlToValidate="ddltigerreserve" ValidationGroup="val"
                                ErrorMessage="Select Tiger Reserve" />
                        </div>
                    </div>
                    <div class="col-md-6">

                        <label class="col-sm-4 control-label" for="exampleFormControlSelect1">Select Village Name</label>
                        <div class="form-group col-md-8">
                            <asp:DropDownList ID="ddlvillage" CssClass="form-control" runat="server" />
                            <asp:RequiredFieldValidator ID="reqddlvillage" runat="server" Display="Dynamic" CssClass="help-block" InitialValue="0"
                                SetFocusOnError="true" ControlToValidate="ddlvillage" ForeColor="Red" ValidationGroup="val"
                                ErrorMessage="Select Village" />

                        </div>
                    </div>


                    <div class="clearfix"></div>



                     
                    <div class="col-md-5 text-center hit">

                        <asp:Button ID="btnsubmit" runat="server" Text="Search" ValidationGroup="val" CssClass="btn btn-primary btn-add" OnClick="btnsubmit_Click" />
                    </div>
                    
                    <div class="clearfix"></div>
                     <div class="col-md-12">

                         <asp:GridView ID="grdfamily" CssClass="table tabbable-line" GridLines="None" runat="server" AutoGenerateColumns="false">
                             <Columns>
                                 <asp:TemplateField HeaderText="S.no">
                                     <ItemTemplate>
                                         <%# Container.DataItemIndex+1 %>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Head Name">
                                     <ItemTemplate>
                                     <%# Eval("Head_Name") %>
                                         </ItemTemplate>
                                 </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Agriculature Land">
                                     <ItemTemplate>
                                     <%# Eval("Agriculature_land") %> (Ha)
                                         </ItemTemplate>
                                 </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Residential Property">
                                     <ItemTemplate>
                                     <%# Eval("Residential_Property") %> (Ha)
                                         </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Total Livestock">
                                     <ItemTemplate>
                                     <%# Eval("Total_Livestock") %>
                                         </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Longitude">
                                     <ItemTemplate>
                                     <%# Eval("Longitude") %>
                                         </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Latitude">
                                     <ItemTemplate>
                                     <%# Eval("Latitude") %>
                                         </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Edit">
                                     <ItemTemplate>
                                         <a href='family-welfare.aspx?Fid=<%# Eval("familyid") %>'>
                                         <asp:Image ID="imgedit" runat="server" ImageUrl="~/auth/Adminpanel/images/edit.gif" /></a>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                             </Columns>
                         </asp:GridView>
                     </div>
                    <div id="divPager" class="col-md-12" runat="server" visible="false">

                                    <asp:Repeater ID="rptPager" runat="server">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                                Enabled='<%# Eval("Enabled") %>' OnClick="lnkPage_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="form-control" Width="70px" AutoPostBack="true" OnSelectedIndexChanged="OnSelectedIndexChanged_PageSizeChanged">
                                        <asp:ListItem Text="12" Value="12" />
                                        <asp:ListItem Text="24" Value="24" />
                                        <asp:ListItem Text="36" Value="36" />
                                        <asp:ListItem Text="48" Value="48" />
                                        <asp:ListItem Text="60" Value="60" />
                                        <asp:ListItem Text="120" Value="120" />
                                    </asp:DropDownList>
                                </div>
                    <!-- <div class="col-md-6">
  <div class="form-group">
    <label for="exampleFormControlSelect2">Example multiple select</label>
    <select multiple class="form-control" id="exampleFormControlSelect2">
      <option>1</option>
      <option>2</option>
      <option>3</option>
      <option>4</option>
      <option>5</option>
    </select>
  </div>
  </div> -->




                </div>
            </div>
        </div>
        <!-- tabs -->

        <!-- start footer -->
        <div class="footer">
            <div class="pull-right">
                <ul class="list-inline">
                    <li><a title="" href="index.html">Dashboard</a></li>
                    <li><a title="" href="#">Privacy Policy </a></li>
                    <li><a title="" href="#">Blog</a></li>
                    <li><a title="" href="#">Contacts</a></li>
                </ul>
            </div>
            <div><strong>Copyright</strong> NTCA &copy;  2017 </div>
        </div>
    </div>

    <script src="../assets/js/vendor/jquery.min.js"></script>

</asp:Content>

