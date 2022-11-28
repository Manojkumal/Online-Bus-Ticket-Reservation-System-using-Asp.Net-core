<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="RouteDetails.aspx.cs" Inherits="BusBookingProject.Admin.RouteDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container" style="margin-top: 8%">
         <asp:GridView ID="gdRouteDetails" runat="server" EmptyDataText="No Record Found...." AutoGenerateColumns="False" AllowPaging="true" PageSize="20" CssClass="table table-hover table-bordered"
                    Width="100%" Font-Size="12" OnRowDataBound="gdRouteDetails_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr.No">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField >
                         <asp:TemplateField HeaderText="Route ID">
                           <ItemTemplate>
                               <asp:Label ID="lblBusNo" runat="server" Text='<%# Eval("RouteID") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                          <asp:TemplateField HeaderText="Origin">
                           <ItemTemplate>
                               <asp:Label ID="lblBusName" runat="server" Text='<%# Eval("Origin") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                         <asp:TemplateField HeaderText="Destination">
                           <ItemTemplate>
                               <asp:Label ID="lblBusType" runat="server" Text='<%# Eval("Destination") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlinkBoarding" runat="server" >Add Boarding Points</asp:HyperLink>
                                 <asp:HiddenField ID="hdnRouteID" runat="server" Value='<%# Eval("RouteID") %>' />
                                 <asp:HiddenField ID="hdnBusID" runat="server" Value='<%# Eval("BusId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
    </div>
</asp:Content>
