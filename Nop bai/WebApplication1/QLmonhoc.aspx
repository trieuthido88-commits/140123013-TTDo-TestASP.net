<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="QLmonhoc.aspx.cs" Inherits="WebApplication1.QLmonhoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 264px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <table class="table">
       <tr>
           <td class="auto-style1">Mã MH:</td>
           <td><asp:TextBox ID="txtmamh" runat="server" CssClass="form-control"></asp:TextBox></td>
       </tr>
       <tr>
            <td class="auto-style1">Tên MH:</td>
            <td><asp:TextBox ID="txttenmh" runat="server"  CssClass="form-control"></asp:TextBox></td>
       </tr>
       <tr>
           <td class="auto-style1">Số tiết:</td>
           <td><asp:TextBox ID="txtsotiet" runat="server" CssClass="form-control"></asp:TextBox></td>
       </tr>
        <tr>
           <td class="auto-style1">Học Phí:</td>
           <td><asp:TextBox ID="txthocphi" runat="server" CssClass="form-control"></asp:TextBox></td>
</tr>
       <tr>
  
           <td colspan="2"><asp:Button ID="btnThemMH" runat="server" Text="Thêm Môn Học" OnClick="btnLogin_Click"/></td>
       </tr>
   </table>
    <h3>Danh sách Môn Học</h3>
    <asp:GridView ID="qlmh" runat="server">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
