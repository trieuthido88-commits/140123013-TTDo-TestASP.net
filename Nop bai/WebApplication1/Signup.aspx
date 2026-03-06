<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="WebApplication1.Signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 259px
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table">
        <tr>
            <td class="auto-style1">Username:</td>
            <td><asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox></td>
        </tr>
        <tr>
             <td class="auto-style1">Password:</td>
             <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style1">Fullname:</td>
            <td><asp:TextBox ID="txtFullname" runat="server" CssClass="form-control"></asp:TextBox></td>
        </tr>
         <tr>
            <td class="auto-style1">Avatar:</td>
            <td><asp:FileUpload ID="FileUpload" runat="server" /></td>
 </tr>
        <tr>
   
            <td colspan="2"><asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"/></td>
        </tr>
    </table>
</asp:Content>
