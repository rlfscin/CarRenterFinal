<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="rent.aspx.cs" Inherits="CarRenter.rent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:DropDownList ID="drpCar" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpCar_SelectedIndexChanged" />
    </br>
    <div class="car">
        <asp:Image runat="server" ID="imgCar" />
        <asp:Label runat="server" ID="lblCar"></asp:Label>
        <asp:Label runat="server" ID="lblStatus"></asp:Label>
    </div>
    </br>
    <asp:Calendar runat="server" ID="cldReturnDate"></asp:Calendar>
    </br>
    <asp:Button runat="server" ID="btnRent" OnClick="btnRent_Click" Text="Rent" />
</asp:Content>
