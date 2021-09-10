<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMaster.master" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" %>
<%@ Register Src="~/UserControl/commonLeftMenu.ascx" TagName="CommonLeftMenu" TagPrefix="LeftMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
   
    <div id="mid">
    
        <div class="mid-left">
         <div class="left-menu">
            	<h2><asp:Literal ID="litleftheading" runat="server"> </asp:Literal></h2>
                <ul>
                 <asp:Literal ID="LtrLeftMenu" runat="server"> </asp:Literal>
                 
                </ul>
            </div><!--end of left-menu-->
            <LeftMenu:CommonLeftMenu ID="Commonleftmenu1" runat="server" />
        </div>
        <div class="mid-right">
            <div class="title-head-left">
            </div>
               <h2> 
            <asp:Label ID="lbltoshowh2" runat="server"></asp:Label></h2>
            <!--we used above lebvel to remove accessbility issue to follow h1,h2,h3,h4,h5-->
            <div class="title-head-mid">
                <h3><% =Resources.Resource.Error%></h3>
            </div>
            <div class="title-head-right">
            </div>
            <div class="content-box">
            <ul>
            
             <%if (Resources.Resource.Lang_Id == "1") %>
	    <%{ %>
         <li>  Please check the url</li>
        <li>The page you requested might have removed</li>
       <%} %>
	    <%else  %>
	    <% {%>

       <li> यूआरएल की जांच करें</li>
          <li>आप का अनुरोध पृष्ठ हटा दिया गया हो सकता है</li>
        <%}%>

         
            </ul>
   <%if (Resources.Resource.Lang_Id == "1") %>
	    <%{ %>
     <a href='<%=ResolveUrl("~/index.aspx") %>'>Go to <%=Resources.Resource.Home %></a>
       <%} %>
	    <%else  %>
	    <% {%>


      <a href='<%=ResolveUrl("~/content/Hindi/index.aspx") %>'><%=Resources.Resource.Home %>पर जाने के लिए यहां क्लिक करें</a>
        <%}%>

            </div>
        </div>
    </div>
</asp:Content>

