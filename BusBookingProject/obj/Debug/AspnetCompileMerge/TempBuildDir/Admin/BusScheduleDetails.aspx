<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="BusScheduleDetails.aspx.cs" Inherits="BusBookingProject.Admin.BusScheduleDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container" style="margin-top: 5%">
    </div>
    <div class="row centered-form" style="margin-top: 5%">
        <div class="col-lg-8 col-sm-8 col-md-2 col-sm-offset-2 col-md-offset-2">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Add Bus Schedule</h3>
                </div>
                <div class="panel-body">
                    <asp:ValidationSummary ID="vsRegister" runat="server" CssClass="alert alert-danger" ShowSummary="true" ValidationGroup="vgRegister" />
                    <div id="divMessage" runat="server" />
                    <div class="col-xs-6 col-sm-6 col-md-6">
                        <div class="form-group">
                            <asp:Label ID="lblFirstName" runat="server" Text="Available Date" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txtDate" runat="server" placeholder="DD/MM/YYYY Format" class="form-control input-sm floatlabel"/>
                             <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDate" Display="None" ID="rfvFirstName" ValidationGroup="vgRegister"
                                    CssClass="text-danger" ErrorMessage="Date is required." /><br />
                        </div>
                       <div class="form-group">
                            <asp:Label ID="lblUserName" runat="server" Text="Fare" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txtFare" runat="server" class="form-control input-sm floatlabel" />
                             <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFare" Display="None" ID="rfVMobileNo" ValidationGroup="vgRegister"
                                    CssClass="text-danger" ErrorMessage="Fare  is required." /><br />
                        </div>
                    </div>
                    <div class="col-xs-6 col-sm-6 col-md-6">
                        <div class="form-group">
                            <asp:Label ID="lblLastName" runat="server" Text="Total Travelling Time" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txtTravelTime" runat="server" placeholder="00hr00Mints Format" class="form-control input-sm floatlabel"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTravelTime" Display="None" ID="rfVLastName" ValidationGroup="vgRegister"
                                    CssClass="text-danger" ErrorMessage="Total Travel Time is required." /><br />
                        </div>
                        
                        <div class="form-group">
                            <asp:Label ID="lblPassword" runat="server" Text="Arrival Time" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txtArrival" runat="server" placeholder="00:00 AM/PM Format" class="form-control input-sm floatlabel"  />
                             <asp:RequiredFieldValidator runat="server" ControlToValidate="txtArrival" Display="None" ID="rfvPassword" ValidationGroup="vgRegister"
                                    CssClass="text-danger" ErrorMessage="Arrival Time  is required." /><br />
                        </div>
                    </div>
                    <div class="col-xs-6 col-sm-6 col-md-6">
                        <div class="form-group">
                            <asp:Label ID="lblEmail" runat="server" Text="Departure Time" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txtDeparture" placeholder="00:00 AM/PM Format"  runat="server" class="form-control input-sm floatlabel" />
                             <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDeparture" Display="None" ID="rfVEmail" ValidationGroup="vgRegister"
                                    CssClass="text-danger" ErrorMessage="Departure Time  is required." /><br />
                        </div>
                    </div>
                    <div class="col-xs-6 col-sm-6 col-md-6">
                        <div class="form-group">
                            <asp:Button ID="btnSaveSchedule" runat="server" Text="Save Bus Schedule" style="margin-top:20px;"  OnClick="btnSaveSchedule_Click" class="btn btn-info " ValidationGroup="vgRegister"  CausesValidation="True" ViewStateMode="Inherit" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
