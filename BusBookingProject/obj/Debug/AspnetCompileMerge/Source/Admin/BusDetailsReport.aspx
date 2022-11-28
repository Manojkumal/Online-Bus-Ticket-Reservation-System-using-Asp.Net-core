<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="BusDetailsReport.aspx.cs" Inherits="BusBookingProject.Admin.BusDetailsReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:6%">
        <asp:GridView ID="gdBusDetails" runat="server" EmptyDataText="No Record Found...." AutoGenerateColumns="False" AllowPaging="true" PageSize="20" CssClass="table table-hover table-bordered"
                    Width="100%" Font-Size="12" OnRowDataBound="gdBusDetails_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.No">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField >
                       <asp:TemplateField HeaderText="Bus ID">
                           <ItemTemplate>
                               <asp:Label ID="lblBusID" runat="server" Text='<%# Eval("BusId") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                         <asp:TemplateField HeaderText="Bus No">
                           <ItemTemplate>
                               <asp:Label ID="lblBusNo" runat="server" Text='<%# Eval("BusNo") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                          <asp:TemplateField HeaderText="Bus Name">
                           <ItemTemplate>
                               <asp:Label ID="lblBusName" runat="server" Text='<%# Eval("BusName") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                         <asp:TemplateField HeaderText="Bus Type">
                           <ItemTemplate>
                               <asp:Label ID="lblBusType" runat="server" Text='<%# Eval("BustType") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                         <asp:TemplateField HeaderText="Seat Columns">
                           <ItemTemplate>
                               <asp:Label ID="lblSeatCol" runat="server" Text='<%# Eval("SeatColumn") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                         <asp:TemplateField HeaderText="Seat Row">
                           <ItemTemplate>
                               <asp:Label ID="lblSeatRow" runat="server" Text='<%# Eval("SeatRow") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                         <asp:TemplateField HeaderText="Origin">
                           <ItemTemplate>
                               <asp:Label ID="lblOrigin" runat="server" Text='<%# Eval("Origin") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                         <asp:TemplateField HeaderText="Destination">
                           <ItemTemplate>
                               <asp:Label ID="lblDestination" runat="server" Text='<%# Eval("Destination") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlinkUpdate" runat="server" >Update Details</asp:HyperLink>
                                 <asp:HyperLink ID="hlinkAddSchedule" runat="server" >Add Bus Schedule</asp:HyperLink>
                                <asp:HiddenField ID="hdnPNRNo" runat="server" Value='<%# Eval("BusId") %>' />
                                 <asp:HiddenField ID="hdnRouteID" runat="server" Value='<%# Eval("RouteID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
    </div>
</asp:Content>
