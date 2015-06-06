<%@ Page Title="Return Car" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="return.aspx.cs" Inherits="CarRenter._return" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="style/return.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <table>
        <tr>
            <td><h2>Car: </h2></td>
            <td><h2>Car Detail: </h2></td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="drpCar" runat="server" AutoPostBack="true" />
            </td>
            <td>
                <div class="car">
                    <asp:Image runat="server" ID="Image1" CssClass="imgHomeCar"/>
                    <asp:Label runat="server" ID="Label1"></asp:Label>
                    <asp:Label runat="server" ID="Label2"></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" ID="lblPrice">Price: </asp:Label>
            </td>
            <td>
                <asp:Button runat="server" ID="btnRent" Text="Rent" />
            </td>
        </tr>

    </table>
</asp:Content>
