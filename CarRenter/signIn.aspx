<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="signIn.aspx.cs" Inherits="CarRenter.signIn" %>
<%@ MasterType VirtualPath="~/Header.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div id="box">
        <label for="Content_txtName">Name: </label>
        <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
        <label for="Content_txtPassword">Password: </label>
        <asp:TextBox TextMode="Password" runat="server" ID="txtPassword"></asp:TextBox>
        <asp:Button runat="server" ID="btnLogin" Text="Login" OnClick="btnLogin_Click" />
    </div>
</asp:Content>
