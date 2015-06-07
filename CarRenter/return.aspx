<%@ Page Title="Return Car" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="return.aspx.cs" Inherits="CarRenter._return" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="style/return.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:Panel runat="server" ID="pnlCars" Visible="true">>
        <table>
        <tr>
            <td><h2>Car: </h2></td>
            <td><h2>Car Detail: </h2></td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="drpCar" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpCar_SelectedIndexChanged" />
            </td>
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
                <asp:Button runat="server" ID="btnReturn" Text="Return" OnClick="btnReturn_Click" />
            </td>
        </tr>

        </table>
    </asp:Panel>

    <asp:Panel runat="server" ID="pnlMessage" Visible="false">
        <asp:Label runat="server" ID="lblMessage"></asp:Label>
    </asp:Panel>
</asp:Content>
