<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="CarRenter.search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <table>
        <tr>
            <td>
                Car:
                <asp:DropDownList runat="server" ID="drpCar"></asp:DropDownList>
            </td>
            <td>
                <div class="car">
                    <asp:Image runat="server" ID="Image1" CssClass="imgHomeCar"/>
                    <asp:Label runat="server" ID="Label1"></asp:Label>
                    <asp:Label runat="server" ID="Label2"></asp:Label>
                </div>
            </td>
        </tr>
    </table>
    <asp:Repeater runat="server" ID="lstRents">
        <HeaderTemplate><table>
            <tr>
                <td>City</td>
                <td>Rent Date</td>
                <td>Return Date</td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# CityId.Name %></td>
                <td><%# RentDate %></td>
                <td><%# ReturnDate %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>
</asp:Content>
