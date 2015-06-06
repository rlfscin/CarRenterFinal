<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="registerCar.aspx.cs" Inherits="CarRenter.registerCar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="style/sign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div id="box">
        <table>
            <tr>
                <td colspan="2">
                    <h2>Register a car</h2>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Name: </label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label>City: </label>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlCity">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Image: </label>
                </td>
                <td>
                    <asp:FileUpload runat="server" ID="fuImage"/>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button runat="server" ID="btnRegister" Text="Register"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
