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
                    <asp:RequiredFieldValidator runat="server" 
                                                ID="reqName"
                                                ControlToValidate="txtName" 
                                                ErrorMessage="Car's name required" 
                                                EnableClientScript="true"
                                                ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <label>City: </label>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="drpCity">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Image: </label>
                </td>
                <td>
                    <asp:FileUpload runat="server" ID="fuImage" AllowMultiple="false"/>
                    <asp:RequiredFieldValidator runat="server" 
                                                ID="reqImage"
                                                ControlToValidate="fuImage" 
                                                EnableClientScript="true"
                                                ErrorMessage="Car's image required" 
                                                ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button runat="server" ID="btnRegister" Text="Register" OnClick="btnRegister_Click"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
