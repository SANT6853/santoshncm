<%@ Page Language="C#" AutoEventWireup="true" CodeFile="villagedetails.aspx.cs" Inherits="auth_Adminpanel_Enterform_villagedetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>NTCA Admin</title>
    <!-- Bootstrap -->
 
</head>
<body class="page-header-fixed ">
   

        <div class="clearfix"></div>
        <div class="page-container">
            <!-- Start page sidebar wrapper -->

            <!-- End page sidebar wrapper -->
            <!-- Start page content wrapper -->
            <div class="page-content-wrapper animated fadeInRight">
                <div>

                   <%-- <div class="wrapper-content1">--%>
                        <div class="row">
                            <div class="col-lg-12 clrr">
                                <div class="widgets-container">


                                    <div class="form-group">
                                        <label for="lblstate" class="col-sm-2 control-label">State</label>
                                        <div class="col-sm-4">
                                            <asp:Label ID="lblstate" runat="server"></asp:Label>

                                        </div>
                                        <label for="inputEmail3" class="col-sm-2 control-label">Tiger Reserves</label>
                                        <div class="col-sm-2">
                                            <asp:Label ID="lbltigerReserves" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                
                                <div class="widgets-container">
                                    <div class="form-group">
                                        <label for="lblstate" class="col-sm-2 control-label">District</label>
                                        <div class="col-sm-4">
                                            <asp:Label ID="LblDistrict" runat="server"></asp:Label>

                                        </div>
                                        <label for="inputEmail3" class="col-sm-2 control-label">Tehshil</label>
                                        <div class="col-sm-4">
                                            <asp:Label ID="lblTehshil" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                
                                <div class="widgets-container">
                                    <div class="form-group">
                                        <label for="lblGramPanchayat" class="col-sm-2 control-label">GramPanchayat</label>
                                        <div class="col-sm-4">
                                            <asp:Label ID="lblGramPanchayat" runat="server"></asp:Label>

                                        </div>
                                        <label for="lblVillageName" class="col-sm-2 control-label">Village Name</label>
                                        <div class="col-sm-4">
                                            <asp:Label ID="lblVillageName" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                
                                <div class="widgets-container">
                                    <div class="form-group">
                                        <label for="lblLegalStatus" class="col-sm-2 control-label">Legal Status</label>
                                        <div class="col-sm-4">
                                            <asp:Label ID="lblLegalStatus" runat="server"></asp:Label>

                                        </div>
                                        <label for="lblStatus" class="col-sm-2 control-label">Status</label>
                                        <div class="col-sm-4">
                                            <asp:Label ID="lblStatus" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                
                                <div class="widgets-container">
                                    <div class="form-group">
                                        <label for="lblArea" class="col-sm-2 control-label">Area</label>
                                        <div class="col-sm-4">
                                            <asp:Label ID="lblArea" runat="server"></asp:Label>

                                        </div>
                                        <label for="lblDateofsurvey" class="col-sm-2 control-label">Date of survey</label>
                                        <div class="col-sm-4">
                                            <asp:Label ID="lblDateofsurvey" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                
                            </div>
                        </div>

                        

                         

                     
                        

                        <div class="row">
                            <div class="col-lg-12">
                                <div class="widgets-container">
                                    <div class="form-group">
                                        <label for="lblDateofConsenment" class="col-sm-2 control-label">Date of Consenment</label>
                                        <div class="col-sm-4">
                                            <asp:Label ID="lblDateofConsenment" runat="server"></asp:Label>

                                        </div>
                                        <label for="lblAgricultureLand" class="col-sm-2 control-label">Agriculture Land (Ha)</label>
                                        <div class="col-sm-4">
                                            <asp:Label ID="lblAgricultureLand" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-12 clrr">
                                <div class="widgets-container">
                                    <div class="form-group">
                                        <label for="lblDateofConsenment" class="col-sm-2 control-label">Residential property (Ha)</label>
                                        <div class="col-sm-4">
                                            <asp:Label ID="lblResidentialproperty" runat="server"></asp:Label>

                                        </div>
                                        
                                    </div>
                                </div>
                                
                                <div class="widgets-container">
                                    <div class="form-group">
                                        <label for="lblTotalStandingTrees" class="col-sm-2 control-label">Total Standing Trees</label>
                                        <div class="col-sm-4">
                                            <asp:Label ID="lblTotalStandingTrees" runat="server"></asp:Label>

                                        </div>
                                        <label for="lblTotalLivestock" class="col-sm-2 control-label">Total Livestock</label>
                                        <div class="col-sm-4">
                                            <asp:Label ID="lblTotalLivestock" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                
                                <div class="widgets-container">
                                    <div class="form-group">
                                        <label for="lblRelocatedfrom" class="col-sm-2 control-label">Relocated from</label>
                                        <div class="col-sm-4">
                                            <asp:Label ID="lblRelocatedfrom" runat="server"></asp:Label>

                                        </div>
                                        <label for="lblRelocatedplace" class="col-sm-2 control-label">Relocated place</label>
                                        <div class="col-sm-4">
                                            <asp:Label ID="lblRelocatedplace" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                
                                <div class="widgets-container">
                                    <div class="form-group">
                                        <label for="lblTotalwell" class="col-sm-2 control-label">Total well</label>
                                        <div class="col-sm-4">
                                            <asp:Label ID="lblTotalwell" runat="server"></asp:Label>

                                        </div>
                                        
                                    </div>
                                </div>
                                
                                <div class="widgets-container">
                                    <div class="form-group">
                                        <label for="lblGPScoordinatesofCurrentlocationlat" class="col-sm-2 control-label">GPS coordinates of Current location</label>
                                        <div class="col-sm-4">
                                            <asp:Label ID="lblGPScoordinatesofCurrentlocationlat" runat="server"></asp:Label>

                                        </div>
                                        <label for="lblGPScoordinatesofCurrentlocationplacelag" class="col-sm-2 control-label">GPS coordinates of Current location place</label>
                                        <div class="col-sm-4">
                                            <asp:Label ID="lblGPScoordinatesofCurrentlocationplacelag" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                
                                <div class="widgets-container">
                                    <div class="form-group">
                                        <label for="lblGPScoordinatesofRelocatedFromlat" class="col-sm-2 control-label">GPS coordinates of Relocated From</label>
                                        <div class="col-sm-4">
                                            <asp:Label ID="lblGPScoordinatesofRelocatedFromlat" runat="server"></asp:Label>

                                        </div>
                                        <label for="lblGPScoordinatesofRelocatedFromlag" class="col-sm-2 control-label">GPS coordinates of Relocated From</label>
                                        <div class="col-sm-4">
                                            <asp:Label ID="lblGPScoordinatesofRelocatedFromlag" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                
                                <div class="widgets-container">
                                    <div class="form-group">
                                        <label for="lbtother" class="col-sm-2 control-label">Ohters</label>
                                        <div class="col-sm-10">
                                            <asp:Label ID="lbtother" runat="server"></asp:Label>

                                        </div>
                                        
                                    </div>
                                </div>
                                
                                
                                
                            </div>
                        </div>

                        
                    </div>
                    <!-- start footer -->

                </div>
            </div>
       <%-- </div>--%>
        <!-- Go top -->

   
</body>
</html>
