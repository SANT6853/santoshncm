<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AceesblityBar.ascx.cs" Inherits="UserControl_AceesblityBar" %>
    <!--Accessibility-->
	


	 <script type="text/javascript">

        function search() {


            var Search = document.getElementById('<%# txtsearch.ClientID %>').value;



                if (Search == "Enter Search text") {


                    alert("Please Enter search Text");
                    return false;

                }
                else if (Search == "अपने खोजशब्द दर्ज करें") {

                    alert("अपने खोजशब्द दर्ज करें.");



                    return (false);
                }

                if (Search === "") {

                    alert("Please Enter search Text");
                    return false;
                }

            }



            function getText() {
                var Search = document.getElementById('<%# txtsearch.ClientID %>');
                if (Search.value == '') {

                    if (("<%#  Resources.CRCL_Resource.Lang_Id %>") == 2) {
                        Search.value = 'अपने खोजशब्द दर्ज करें';
                    }
                    else {

                        Search.value = 'Enter Search text';
                    }



                }


            }

    </script>
<div id="accessibility">
    
      <div class="access-links">
        <ul class="pull-left">
         <li class="skip-links"><a href="#main" title="Skip to Main Content"><%= (Resources.CRCL_Resource.Lang_Id == "1") ? "Skip to Main Content" : " मुख्य सामग्री पर  जाएं  " %></a></li>
          <li class="screenreader"><a href='<%=ResolveUrl("~/ScreenReader.aspx") %>' title="Screen Reader Access "><%= (Resources.CRCL_Resource.Lang_Id == "1") ? "Screen Reader Access" : " स्क्रीन रीडर का उपयोग  " %></a></li>
          <li class="screenreader"><%if (Convert.ToInt16(Resources.CRCL_Resource.Lang_Id) == (int)Module_ID_Enum.Language_ID.English)
                  { %>
                <a  title ="This link shall take you to a CRCL Hindi version" href="<%=ResolveUrl("~/content/Hindi/index.aspx") %>" onclick="javascript:return confirm( 'This link shall take you to a CRCL Hindi version. Click OK to continue. Click Cancel to stop?')" target="_blank" >
                  हिन्दी </a>
                <%} %>
                <%else
                    { %>
                <a title ="This link shall take you to a CRCL English version" href="<%=ResolveUrl("~/index.aspx") %>" onclick="javascript:return confirm( 'This link shall take you to a CRCL English version. Click OK to continue. Click Cancel to stop?')" target="_blank">
                 English  </a>
                <%} %></li>
				
           </ul>
        <div class="clear"> </div>
  </div>
  
  
<div class="access-links-right-section">
<div class="search-part hidden-xs pull-left">
	<asp:Panel ID="pnlsearch" runat="server" DefaultButton="btnsearch">

		<asp:HiddenField ID="cx" Value="013280925726808751639:nsxdhmd1lxg" runat="server" />
		<asp:HiddenField ID="cof" Value="FORID:9" runat="server" />
		<asp:HiddenField ID="ie" Value="UTF-8" runat="server" />
		 <label for="<%= txtsearch.ClientID %>">
			<span id="text" style="visibility:hidden">Search</span>
		<asp:TextBox ID="txtsearch" autocomplete="off" runat="server" CssClass="input-bg" Text="Enter Search text" onfocus="javascript:if(this.value!=''){this.value=''}" onblur="getText()"></asp:TextBox>
			</label>
			<asp:Button ID="btnsearch" runat="server" ToolTip="Search"
			OnClick="btnsearch_Click" OnClientClick="return search()" />

	</asp:Panel>
</div>
        <ul class="pull-left">
		
          <li class="decerase-font">
              <asp:LinkButton ID="ibtnDecreaseFont" runat="server" OnClick="ibtnDecreaseFont_Click" ToolTip="Decrease Text Size" ><img alt="Decrease Text Size" width="19" height="14" src='<%= ResolveUrl("~/images/A-.png") %>' /></asp:LinkButton>
              <%--<asp:ImageButton ID="ibtnDecreaseFont" runat="server" 
                  ImageUrl="~/images/A-.png" width="19" height="14" 
                  onclick="ibtnDecreaseFont_Click"/>--%> </li>
          <li class="normal-text">
              <asp:LinkButton ID="ibtnNormalFont" runat="server" OnClick="ibtnNormalFont_Click" ToolTip="Normal Text Size"><img alt="Normal Text Size" width="19" height="14" src='<%= ResolveUrl("~/images/A.png") %>' /></asp:LinkButton>
             <%-- <asp:ImageButton ID="ibtnNormalFont" runat="server" 
                  ImageUrl="~/images/A.png" width="19" height="14" 
                  onclick="ibtnNormalFont_Click"/>--%>

          </li>
          <li class="increase-font"> 
              <asp:LinkButton ID="ibtnIncreaseFont" runat="server" OnClick="ibtnIncreaseFont_Click" ToolTip="Increase Text Size" ><img alt="Increase Text Size" width="19" height="14" src='<%= ResolveUrl("~/images/increase.png") %>' /></asp:LinkButton>
             <%-- <asp:ImageButton ID="ibtnIncreaseFont" runat="server" 
                  ImageUrl="~/images/increase.png" width="19" height="14"  onclick="ibtnIncreaseFont_Click" 
                 />--%>

          </li>
          <li class="high-contrast">
              <asp:LinkButton ID="ibtnHighTheme" runat="server" OnClick="ibtnHighTheme_Click" ToolTip="High Contract View" ><img alt="High Contract View" width="19" height="14" src='<%= ResolveUrl("~/images/high-contrast.png") %>' /></asp:LinkButton>
            <%--  <asp:ImageButton ID="ibtnHighTheme" runat="server" 
                  ImageUrl="~/images/high-contrast.png" width="19" height="14"  
                  onclick="ibtnHighTheme_Click"/> --%>

          </li>
          <li class="standard-contrast">
              <asp:LinkButton ID="ibtnStanderd" runat="server" OnClick="ibtnStanderd_Click" ToolTip="Standard View" ><img alt="Standard View" width="19" height="14" src='<%= ResolveUrl("~/images/standard-contrast.png") %>' /></asp:LinkButton>
         <%-- <asp:ImageButton ID="ibtnStanderd" runat="server" 
                  ImageUrl="~/images/standard-contrast.png" width="19" height="14" 
                  onclick="ibtnStanderd_Click"/>--%>
          </li>
          <li class="select-theme">Select Theme</li>  
          <li class="blue-theme"> 
               <asp:LinkButton ID="ibtnBlueTheme" runat="server" OnClick="ibtnBlueTheme_Click" ToolTip="Blue Theme" ><img alt="Blue Theme" width="19" height="14" src='<%= ResolveUrl("~/images/blue-theme.png") %>' /></asp:LinkButton>
             <%-- <asp:ImageButton ID="ibtnBlueTheme" runat="server" 
                  ImageUrl="~/images/blue-theme.png" width="12" height="14"  
                  onclick="ibtnBlueTheme_Click"/>--%> 

          </li>
          <li class="yellow-theme">
              <asp:LinkButton ID="ibtnYelloTheme" runat="server" OnClick="ibtnYelloTheme_Click" ToolTip="Red Theme" ><img alt="Red Theme" width="19" height="14" src='<%= ResolveUrl("~/images/orange.png") %>' /></asp:LinkButton>
             <%-- <asp:ImageButton ID="ibtnYelloTheme" runat="server" 
                  ImageUrl="~/images/orange.png" width="12" height="14" 
                  onclick="ibtnYelloTheme_Click"/>--%> 

          </li>
          <li class="green-theme"> 
              <asp:LinkButton ID="ibtnGreenTheme" runat="server" OnClick="ibtnGreenTheme_Click" ToolTip="Green Theme" ><img alt="Green Theme" width="19" height="14" src='<%= ResolveUrl("~/images/green.png") %>' /></asp:LinkButton>
           <%--   <asp:ImageButton ID="ibtnGreenTheme" runat="server" 
                  ImageUrl="~/images/green.png" width="12px" height="14px" 
                  onclick="ibtnGreenTheme_Click"/>--%>

          </li>
            <%-- <li class="green-theme">
            
                 </li>--%>
        </ul>
        <div class="clear"> </div>

  </div>
  
</div>