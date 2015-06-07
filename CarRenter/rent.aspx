<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="rent.aspx.cs" Inherits="CarRenter.rent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="style/rent.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:Panel runat="server" ID="pnlCars"> 
        <table>
        <tr>
            <td><h2>Car: </h2></td>
            <td><h2>Return date: </h2></td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="drpCar" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpCar_SelectedIndexChanged" />
            </td>
            <td>
                <asp:Calendar runat="server" ID="cldReturnDate"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td>
                <div class="car">
                    <asp:Image runat="server" ID="imgCar" CssClass="imgHomeCar"/>
                    <asp:Label runat="server" ID="lblCar"></asp:Label>
                    <asp:Label runat="server" ID="lblStatus"></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button runat="server" ID="btnRent" OnClick="btnRent_Click" Text="Rent" />
            </td>
        </tr>

        </table>
    </asp:Panel>
    
    <asp:Panel runat="server" ID="pnlMessage" Visible="false">
        <asp:Label runat="server" ID="lblMessage"></asp:Label>
    </asp:Panel>
</asp:Content>
