<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="signIn.aspx.cs" Inherits="CarRenter.signIn" %>
<%@ MasterType VirtualPath="~/Header.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="style/sign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div id="box">
        <table>
            <tr>
                <td>
                    <label for="Content_txtName">Name: </label>

                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="Content_txtPassword">Password: </label>

                </td>
                <td>
                   <asp:TextBox TextMode="Password" runat="server" ID="txtPassword"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button runat="server" ID="btnLogin" Text="Login" OnClick="btnLogin_Click" />
                </td>
            </tr>
            <tr>
                <td id="error"></td>
            </tr>
        </table>
    </div>
</asp:Content>
