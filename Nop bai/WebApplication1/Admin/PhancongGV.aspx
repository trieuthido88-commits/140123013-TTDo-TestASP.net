<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PhancongGV.aspx.cs" Inherits="WebApplication1.Admin.PhancongGV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="page-title">Phân công giáo viên</h2>

    <div class="form-card">

        <table class="table">

            <tr>
                <td width="200">Mã GV</td>
                <td>
                    <asp:DropDownList ID="ddlGV" runat="server" Width="200px">
</asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>Mã MH</td>
                <td>
                    <asp:DropDownList ID="ddlMH" runat="server" Width="200px">
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>Ghi chú</td>
                <td>
                    <asp:TextBox ID="txtghichu" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>Username</td>
                <td>
                    <asp:TextBox ID="txtusername" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td></td>
                <td>

                    <asp:Button
                        ID="btnThem"
                        runat="server"
                        Text="➕ Thêm"
                        CssClass="btn-custom btn-add"
                        OnClick="btnLogin_Click" />

                    <asp:Button
                        ID="btnsua"
                        runat="server"
                        Text="✏ Sửa"
                        CssClass="btn-custom btn-edit"
                        OnClick="Btnsua_Click" />

                </td>
            </tr>

        </table>

    </div>



    <div class="form-card">

        <table class="table">

            <tr>

                <td width="150">

                    <asp:Button
                        ID="btntim"
                        runat="server"
                        Text="🔍 Tìm kiếm"
                        CssClass="btn-custom btn-search"
                        OnClick="btntim_Click" />

                </td>

                <td>

                    <asp:TextBox
                        ID="txttim"
                        runat="server"
                        CssClass="form-control">
                    </asp:TextBox>

                </td>

            </tr>

        </table>

    </div>



    <div class="table-card">

        <h4>Danh sách phân công giáo viên</h4>

        <asp:GridView
            ID="qlpcgv"
            runat="server"
            CssClass="table table-bordered table-hover"
            DataKeyNames="MaGV,MaMH,Username"
            OnRowDeleting="qlpcgv_RowDeleting"
OnSelectedIndexChanged="qlpcgv_SelectedIndexChanged">

            <Columns>

                <asp:CommandField
                    ShowSelectButton="True"
                    SelectText="Chọn" />

                <asp:CommandField
                    ShowDeleteButton="True"
                    DeleteText="Xóa" />

            </Columns>

        </asp:GridView>

    </div>

</asp:Content>
