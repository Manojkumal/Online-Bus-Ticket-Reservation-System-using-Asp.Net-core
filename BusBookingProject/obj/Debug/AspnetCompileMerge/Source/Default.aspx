<%@ Page Title="" Language="C#" MasterPageFile="~/BusBookingMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BusBookingProject.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:6%">
        <div class="row">
            <div class="col-lg-12">
                <asp:Image ID="imgBus" ImageAlign="AbsMiddle" ImageUrl="~/img/banner-home-1.jpg" style="width:100%" runat="server" />
            </div>
            <div class="col-lg-12" style="margin-top:2%">
                <div class="panel panel-default">
                    <div class="panel-heading">
                         <div class=" panel-title">
                        <h3>Introduction About Online Bus Booking</h3>
                    </div>
                       </div>
                    <div class="panel-body">
                        <p style="font-size:large">
                            Online Bus Booking System is Web Based application,That works with in centralised network,It Provides facility to 
                            reserved seats,different type of enquiry which need an instant and quick reservation.
                            Buses may be used for scheduled bus transport, scheduled coach transport, school transport, private hire, 
                            or tourism; promotional buses may be used for political campaigns and others are privately operated for a wide range of purposes, 
                            including rock and pop band tour vehicles.
                        </p>
                    </div>
                </div>
            </div>
             <div class="col-lg-12" style="margin-top:2%">
                <div class="panel panel-default">
                    <div class="panel-heading">
                         <div class=" panel-title">
                        <h3>Why Online Bus Booking is Important?</h3>
                    </div>
                       </div>
                    <div class="panel-body" style="font-size:large">
                           <ul>
                               <li>
                               Fast & Easy Online bus booking.
                               </li>
                               <li>
                                   Zero booking fees No Extra Charges for online booking.
                               </li>
                               <li>
                                   100 % Secure to book your bus tickets with Online Bus Booking System.
                               </li>
                               <li>
                                   All Credit/Debit/Internet Banking Accepted.
                               </li>
                               <li>
                                   Get tickets to your mobile.
                               </li>
                               <li>
                                   Online cancellation and phone support available.
                               </li>
                               <li>
                                   The fastest way to book bus tickets.
                               </li>
                               <li>
                                   Book bus tickets online for Major routes across India.
                               </li>
                           </ul>
                       
                    </div>
                </div>
            </div>
            <div class="col-lg-12" style="margin-top:2%">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">
                            <h3>Available Buses</h3>
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="col-lg-3">
                            <asp:Image ID="Image0" runat="server" Width="200" ImageUrl="~/img/Bus1.png" />
                        </div>
                         <div class="col-lg-3">
                               <asp:Image ID="Image1" Width="200" runat="server" ImageUrl="~/img/Bus2.jpg" />
                        </div>
                         <div class="col-lg-3">
                               <asp:Image ID="Image2" Width="200" runat="server" ImageUrl="~/img/Bus3.jpg" />
                        </div>
                         <div class="col-lg-3">
                               <asp:Image ID="Image3" Width="200" runat="server" ImageUrl="~/img/Bus4.jpg" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
