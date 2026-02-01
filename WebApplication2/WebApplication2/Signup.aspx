<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="WebApplication2.Signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .autu-style1 {
            with: 259px
        }
        .auto-style1 {
            width: 267px;
        }
        .auto-style2 {
            width: 267px;
            height: 65px;
        }
        .auto-style3 {
            height: 65px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table">
        <tr>
            <td class="auto-style1">Username:</td>
            <td><asp:TextBox ID="txtusername" runat="server" CssClass="form-control"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style1">Password:</td>
            <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style2">Fullname:</td>
            <td class="auto-style3"><asp:TextBox ID="txtfullname" runat="server" CssClass="form-control"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style1">Avatar:</td>
            <td><asp:FileUpload ID="FileUpload1" runat="server" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
