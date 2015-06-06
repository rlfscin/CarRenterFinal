<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="singUp.aspx.cs" Inherits="CarRenter.singUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="style/sign.css" rel="stylesheet" />
    <script src="scripts/sign.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div id="box">
        <table>
            <tr>
                <td colspan="2">
                    <h2>Sign UP</h2>
                </td>
            </tr>
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
                <td>
                    <label for="Content_city">City: </label>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="drpCity"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox runat="server" Text="Other City" ID="chkOtherCity"/>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtOtherCity"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button runat="server" ID="btnRegister" Text="Register" OnClick="btnRegister_Click"/>
                </td>
            </tr>
            <tr>
                <td id="error"></td>
            </tr>
        </table>
    </div>
</asp:Content>
