<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="QLgiaovien.aspx.cs" Inherits="WebApplication1.QLgiaovien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 345px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="table">
        <tr>
            <td class="auto-style1">Mã GV:</td>
            <td><asp:TextBox ID="txtmagv" runat="server" CssClass="form-control" required="required"></asp:TextBox></td>
        </tr>
        <tr>
             <td class="auto-style1">Họ GV:</td>
             <td><asp:TextBox ID="txtHo" runat="server"  CssClass="form-control"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="auto-style1">Tên GV:</td>
            <td><asp:TextBox ID="txtTen" runat="server" CssClass="form-control"></asp:TextBox></td>
        </tr>
         <tr>
            <td class="auto-style1">Địa chỉ:</td>
            <td><asp:TextBox ID="txtDiachi" runat="server" CssClass="form-control"></asp:TextBox></td>
 </tr>
        <tr>
   
            <td colspan="2"><asp:Button ID="btnThem" runat="server" Text="Thêm" OnClick="btnLogin_Click"/>
                <asp:Button ID="btnsua" runat="server" OnClick="Btnsua_Click" Text="Sửa" />
            </td>
        </tr>
    </table>

    <asp:TextBox ID="txttim" runat="server" Width="703px"> </asp:TextBox>  
    <asp:Button ID="bttim" runat="server" Text="Tìm" OnClick="bttim_Click"/>

    <h3>Danh sách giáo viên</h3>
    <asp:GridView ID="qlgv" runat="server" CssClass="table" DataKeyNames="MaGV" OnRowDeleting="qlgv_RowDeleting" OnSelectedIndexChanged="qlgv_SelectedIndexChanged">
        
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
