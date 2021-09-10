<%@ Page Title="" Language="C#" MasterPageFile="~/Mainsite.master" AutoEventWireup="true" CodeFile="Maincontent.aspx.cs" Inherits="Maincontent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<style>
.hdng{
margin:0;
padding:6px;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    
    <div class=" container background-white" id="content">
        <div class="row">
            <!--<div class="col-md-12">
                <ol class="breadcrumb breadcrum-margin-top">
                    <asp:Literal ID="bradcrumb" runat="server"></asp:Literal>
                </ol>
                <a onclick="javascript: window.print()" title="Print" href="javascript: void(0)" class="pull-right">
                    <p class="glyphicon glyphicon-print  print">
                    </p>
                </a>
            </div>-->
        </div>
    </div>
    <!--end of breadcrum-->
    <div class=" container background-white">
        <div class="row">
            <div class="container mainct">
                <div class="row">
                    <asp:Literal ID="LtrLeftMenu" runat="server"></asp:Literal>
                
       
            <div class="col-md-9 content-area">
               
                <h2 class="hdng">
                    <asp:Label ID="lbltoshowh2" runat="server"></asp:Label>
                    <asp:Literal ID="litPageHead" runat="server"> </asp:Literal></h2>
					
                <asp:Label ID="lblshow4" runat="server" Text=""></asp:Label>
                <asp:Literal ID="LitDesc" runat="server"> </asp:Literal>
                <div id="divdetails"></div>
                 <asp:Image ID="imgdown" ImageUrl="~/images/dwn.png" runat="server" Width="40px" /><asp:HyperLink ID="hypfile" Target="_blank" Font-Underline="true" runat="server" ForeColor="blue"></asp:HyperLink>
                <div id="dvHTMLStripped"></div>
                <div class="pull-right pt15">
                    <asp:Literal ID="ltrlastupdated" runat="server" />
                </div>
            </div>
                    </div>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $('#3771 li a').bind('click', function (event) {
                var k = $(this).attr('id');


                $.ajax({
                    type: "POST",
                    url: "../facultylist.asmx/getRecordforeArchive",
                    data: JSON.stringify({ 'id': k }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        var data = JSON.parse(response.d);
                        $("#dvHTMLStripped").empty();
                        var ndata = data.Table.length;
                        if (ndata == 0) {
                            alert("Sorry No Record Find");
                        }
                        else {

                            $('#divdetails').append($.parseHTML(data.Table[0].Content));

                            $("#dvHTMLStripped").html($("#divdetails").text());
                            $('#divdetails').empty();

                            $('#3771').hide();

                        }

                    },
                    failure: function (request, error) {
                        // alert(" Can't do because: " );
                    },
                    error: function (xhr, errorType, exception) {
                        var responseText;
                        responseText = jQuery.parseJSON(xhr.responseText);
                        //alert("error");
                    }
                })

            });

        });

    </script>
</asp:Content>

