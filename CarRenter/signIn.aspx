<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="signIn.aspx.cs" Inherits="CarRenter.signIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div id="box">
        <label for="Content_txtName">Name: </label>
        <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
        <label for="Content_txtPassword">Password: </label>
        <asp:TextBox TextMode="Password" runat="server" ID="txtPassword"></asp:TextBox>
    </div>
</asp:Content>
