<%@ Page Title="Home" Language="C#"  MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="CarRenter.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="style/home.css" rel="stylesheet" />
    <script src="scripts/home.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:DropDownList ID="ddCity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddCity_SelectedIndexChanged" />
    <asp:Repeater runat="server" ID="lstCars">
        <HeaderTemplate><ul></HeaderTemplate>
        <ItemTemplate>
            <li class="car">
                <a href="rent.aspx?carId=<%#Eval("CarId")%>">
                    <img class="imgHomeCar" src="<%#Eval("Image") %>"/>
                    <span> <%#Eval("Name") %></span>
                    <span class="info"><%#Eval("Available") %></span>
                </a>
            </li>
        </ItemTemplate>
        <FooterTemplate></ul></FooterTemplate>
    </asp:Repeater>
</asp:Content>