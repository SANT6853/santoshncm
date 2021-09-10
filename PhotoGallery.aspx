<%@ Page Title="" Language="C#" MasterPageFile="~/FrontPage.master" AutoEventWireup="true" CodeFile="PhotoGallery.aspx.cs" Inherits="PhotoGallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="<%=ResolveUrl("~/css/lightgallery.css") %>" rel="stylesheet" type="text/css" />
    
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contentMainContent" runat="Server">

    <div class="demo-gallery">
        <ul id="lightgallery" class="list-unstyled row">
            <asp:Literal ID="ltrlgalleryname" runat="server" />
           <%-- <li class="col-xs-6 col-sm-4 col-md-3" data-responsive="images/gallery/1-375.jpg 375, images/gallery/1-480.jpg 480, images/gallery/1.jpg 800" data-src="images/gallery/1-1600.jpg" data-sub-html="<h4>Fading Light</h4><p>Classic view from Rigwood Jetty.</p>">
                <a href="">
                    <img class="img-responsive" src="images/gallery/thumb-1.jpg">
                </a>
            </li>
            <li class="col-xs-6 col-sm-4 col-md-3" data-responsive="images/gallery/2-375.jpg 375, images/gallery/2-480.jpg 480, images/gallery/2.jpg 800" data-src="images/gallery/2-1600.jpg" data-sub-html="<h4>Bowness Bay</h4><p>A beautiful Sunrise this morning taken En-route right time.</p>">
                <a href="">
                    <img class="img-responsive" src="images/gallery/thumb-2.jpg">
                </a>
            </li>
            <li class="col-xs-6 col-sm-4 col-md-3" data-responsive="images/gallery/13-375.jpg 375, images/gallery/13-480.jpg 480, images/gallery/13.jpg 800" data-src="images/gallery/13-1600.jpg" data-sub-html="<h4>Bowness Bay</h4><p>A beautiful Sunrise this morning taken En-route to Keswick.</p>">
                <a href="">
                    <img class="img-responsive" src="images/gallery/thumb-13.jpg">
                </a>
            </li>
            <li class="col-xs-6 col-sm-4 col-md-3" data-responsive="images/gallery/4-375.jpg 375, images/gallery/4-480.jpg 480, images/gallery/4.jpg 800" data-src="images/gallery/4-1600.jpg" data-sub-html="<h4>Bowness Bay</h4><p>A beautiful Sunrise this morning taken En-route to Keswick not one as planned.</p>">
                <a href="">
                    <img class="img-responsive" src="images/gallery/thumb-4.jpg">
                </a>
            </li>--%>
        </ul>
    </div>

<!--Light Box-->
<script type="text/javascript">
$(document).ready(function () {
    $('#lightgallery').lightGallery();
});
</script>
<script src="https://cdn.jsdelivr.net/picturefill/2.3.1/picturefill.min.js"></script>
<script src="<%=ResolveUrl("~/js/lightgallery-all.min.js") %>" type="text/javascript"></script>
<script src="<%=ResolveUrl("~/js/jquery.mousewheel.min.js") %>" type="text/javascript"></script>





</asp:Content>

