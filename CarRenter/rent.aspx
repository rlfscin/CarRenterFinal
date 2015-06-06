<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="rent.aspx.cs" Inherits="CarRenter.rent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:DropDownList ID="drpCar" runat="server" />
    </br>
    <asp:Calendar runat="server" ID="cldReturnDate"></asp:Calendar>
    </br>
    <asp:Button runat="server" ID="btnRent" OnClick="btnRent_Click" Text="Rent" />
</asp:Content>
