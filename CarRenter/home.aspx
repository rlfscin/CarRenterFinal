<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="CarRenter.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Car Renter</title>
    <link href="style/header.css" rel="stylesheet" />
    <link href="style/home.css" rel="stylesheet" />
    <script src="//ajax.googleapis.com/ajax/libs/jquery/2.1.0/jquery.min.js"></script>
    <script src="scripts/menu.js"></script>
    <script src="scripts/home.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="headerExtended">
        <section id="body">
            <header>
                <div id="header">
                    <img id="imgLogo" src="img/logo.png" />
                    <h1 id="txtLogo">Car Renter</h1>
                    <ol id="menu">
                        <asp:Panel runat="server" ID="loggedSpace"></asp:Panel>
                        <li id="liHome"><a href="home.aspx"><div class="dropMenu">HOME</div></a></li>
                        <asp:Panel runat="server" ID="logged">
                        <li id="liCar">
                            <div class="dropMenu">
                                CARS
                                <div class="hide">
                                    <a href="registerCar.aspx">Register</a>
                                </div>
                            </div>
                        </li>
                        <li id="liRents">
                            <div class="dropMenu">
                                RENTS<div class="hide">
                                    <a href="rentCar.aspx">Rent</a>
                                    <a href="reternCar.aspx">Return</a>
                                </div>
                            </div>
                        </li>
                        </asp:Panel>
                        <li id="liLogin">
                            <div class="dropMenu">
                                LOG IN<div class="hide">
                                    <asp:Panel runat="server" ID="singIn">
                                        <a href="singIn.aspx">Sign In</a>
                                    </asp:Panel>
                                    <asp:Panel runat="server" ID="singOut">
                                        <a href="home.aspx">Sign Out</a>
                                    </asp:Panel>
                                    <a href="singUp.aspx">Sign Up</a>
                                </div>
                            </div>
                        </li>
                    </ol>
                </div>
            </header>
            <section id="home" class="content">

                <asp:DropDownList ID="ddCity" runat="server">
                </asp:DropDownList>
                <asp:Repeater runat="server" ID="lstCars">
                    <HeaderTemplate><ul></HeaderTemplate>
                    <ItemTemplate>
                        <li class="car">
                            <a href="cars.apsx?carId=<%#Eval("CarId")%>">
                                <img class="imgHomeCar" src="<%#Eval("Image") %>"/>
                                <span> <%#Eval("Name") %></span>
                                <span class="info"><%#Eval("Available") %></span>
                            </a>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate></ul></FooterTemplate>
                </asp:Repeater>
                <ol>
                    <li class="car">
                        <a href="#">
                            <img class="imgHomeCar" src="car/ferrari.jpg" />
                            <span>Ferrari</span>
                            <span class="info">Engine: 1.0</span>
                            <span class="info">Avalible</span>
                        </a>
                    </li>
                    <li class="car">
                        <a href="#">
                            <img class="imgHomeCar" src="car/ferrari.jpg" />
                            <span>Ferrari</span>
                            <span class="info">Engine: 1.0</span>
                            <span class="info">Avalible</span>
                        </a>
                    </li>
                    <li class="car">
                        <a href="#">
                            <img class="imgHomeCar" src="car/ferrari.jpg" />
                            <span>Ferrari</span>
                            <span class="info">Engine: 1.0</span>
                            <span class="info">Avalible</span>
                        </a>
                    </li>
                </ol>
            </section>
        </section>
        
    </div>
    </form>
</body>
</html>
