﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication2.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div id="Form1">
    <div class="rg_layout">
		<div class="rg_center">
            <div class="rg_form">
                <div class="word">
        <table>
             <tr>
                  <td colspan="2" class="td_center"><h3>Login Page</h3></td>
             </tr>
             <tr>
                 <td class="td_left"><asp:Label ID= "Label1" runat ="server" Text=" Email: "></asp:Label></td>
                 <td class="td_right"><asp:TextBox  ID="email" runat ="server"></asp:TextBox></td>
            </tr>
            <tr>
                 <td class="td_left"><asp:Label ID= "Label2" runat ="server" Text=" Password: "></asp:Label></td>
                 <td class="td_right"><asp:TextBox  ID="password" runat ="server"></asp:TextBox></td>
            </tr>

            <tr>
                 <td colspan="2" align="center"><asp:Button ID="Login_Button" runat="server" Text="Login" OnClick="Login_Button_Click" />
            </tr>
        </table>
                </div>
            </div>
        </div>
    </div>
 </div>
</asp:Content>