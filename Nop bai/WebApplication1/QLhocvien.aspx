<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="QLhocvien.aspx.cs" Inherits="WebApplication1.QLhocvien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 258px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <table class="table">
       <tr>
           <td class="auto-style1">Mã HV:</td>
           <td><asp:TextBox ID="txtmahv" runat="server" CssClass="form-control"></asp:TextBox></td>
       </tr>
       <tr>
            <td class="auto-style1">Họ HV:</td>
            <td><asp:TextBox ID="txtHohv" runat="server"  CssClass="form-control"></asp:TextBox></td>
       </tr>
       <tr>
           <td class="auto-style1">Tên HV:</td>
           <td><asp:TextBox ID="txtTenhv" runat="server" CssClass="form-control"></asp:TextBox></td>
       </tr>
        <tr>
           <td class="auto-style1">Địa chỉ:</td>
           <td><asp:TextBox ID="txtDiachi" runat="server" CssClass="form-control"></asp:TextBox></td>
</tr>
       <tr>
  
           <td colspan="2"><asp:Button ID="btnThem" runat="server" Text="Thêm học viên" OnClick="btnLogin_Click"/></td>
       </tr>
   </table>
   <h3>Danh sách Học viên</h3>
    <asp:GridView ID="qlhv" runat="server">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
