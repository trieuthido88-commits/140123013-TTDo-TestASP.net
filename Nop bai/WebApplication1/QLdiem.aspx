<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="QLdiem.aspx.cs" Inherits="WebApplication1.QLdiem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2>Quản Lý Điểm</h2>
        <hr />
        
        <div class="row mb-3">
            <div class="col-md-3">
                Mã số học viên: <asp:TextBox ID="txtmahv" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                Môn học: <asp:TextBox ID="txtMamh" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                Điểm: <asp:TextBox ID="txtDiem" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                Username: <asp:TextBox ID="TextUsername" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        
        <div class="mb-4">
            <asp:Button ID="btnThem" runat="server" Text="Thêm" OnClick="btnThem_Click" CssClass="btn btn-primary" />
            <asp:Button ID="btnsua" runat="server" Text="Sửa" OnClick="btnsua_Click" CssClass="btn btn-warning" />
        </div>

        <input class="form-control" id="myInput" type="text" placeholder="Search..">
        <br />

        <asp:Repeater runat="server" ID="rpKQ">
            <HeaderTemplate>
                <table class="table table-bordered table-striped">
                    <thead>
                        <tr>
                            <th>Mã số học viên</th>
                            <th>Môn học</th>
                            <th>Điểm</th>
                            <th>Username</th>
                            <th>Thao tác</th>
                        </tr>
                    </thead>
                    <tbody id="myTable">
            </HeaderTemplate>
            
            <ItemTemplate>
                <tr>
                    <td><%# Eval("MaHV") %></td>
                    <td><%# Eval("MaMH") %></td>
                    <td><%# Eval("Diem") %></td>
                    <td><%# Eval("Username") %></td>
                    <td>
                        <a href='QLdiem.aspx?mahvs=<%# Eval("MaHV") %>' class="btn btn-sm btn-info">Sửa</a>
                        &nbsp;
                        <a href='QLdiem.aspx?mahvx=<%# Eval("MaHV") %>' 
                           onclick="return confirm('Bạn có chắc chắn muốn xóa?')" 
                           class="btn btn-sm btn-danger">Xóa</a>
                    </td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
                    </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>

    <script>
        $(document).ready(function(){
          $("#myInput").on("keyup", function() {
            var value = $(this).val().toLowerCase();
            $("#myTable tr").filter(function() {
              $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
            });
          });
        });
    </script>
</asp:Content>