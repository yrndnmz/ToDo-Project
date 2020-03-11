<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="guncelleme.aspx.cs" Inherits="WebApplication4.güncelleme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Bilgi Güncelleme</title>
    <link href="bootstrap-4.3.1-dist/bootstrap-4.3.1-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="bootstrap-4.3.1-dist/bootstrap-4.3.1-dist/js/bootstrap.min.js"></script>
    <style>
        body {
            font-family: 'Comic Sans MS';
            background-image: url("todo1.jpg");
            background-repeat: no-repeat;
            background-attachment: fixed;
            background-position: center;
            background-size: 1536px 760px;
        }
    </style>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="BilgiGuncelle">
        <div class="container-fluid">
            <nav class="navbar navbar-expand-lg">
                <div class="collapse navbar-collapse" id="navbarTogglerDemo01">
                    <ul class="navbar-nav mr-auto mt-2 mt-lg-0" style="padding-left:0px;">
                        <li class="nav-item">
                            <asp:Button ID="ToDo" runat="server" Text="To Do" CssClass="btn  btn-danger btn-warning btn-block" Style="background-color: cadetblue; width: 200px;" OnClick="ToDo_Click" />
                        </li>
                        <li class="nav-item active">
                            <asp:Button ID="Guncelleme" runat="server" Text="Bilgi Güncelleme" CssClass="btn  btn-danger btn-warning btn-block" Style="background-color: cadetblue; width: 150px; float: left;" OnClick="Guncelleme_Click" />
                        </li>
                        <li class="nav-item" style="padding-left:1080px;" >
                            <asp:Button ID="Cikis" runat="server" Text="Çıkış" CssClass="btn  btn-danger btn-warning btn-block" Style="background-color: cadetblue; width: 60px; " OnClick="Cikis_Click" />
                        </li>
                    </ul>
                </div>
            </nav>
            <div class="row" style="height: 50px;">
                <div class="col-sm-4" style="padding-top: 50px;"></div>
                <div class="col-sm-4" style="padding-top: 50px;">
                    <div style="padding-top: 50px; text-align: center;">
                        <asp:TextBox ID="GuncelAdi" runat="server" placeholder="Ad" CssClass="col-xs-10 col-sm-5" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                    <div style="padding-top: 50px; text-align: center;">
                        <asp:TextBox ID="GuncelSoyadi" runat="server" placeholder="Soyad" CssClass="col-xs-10 col-sm-5" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>

                    <div style="padding-top: 50px; text-align: center;">
                        <asp:TextBox ID="GuncelKullaniciAdi" runat="server" placeholder="Kullanıcı Adı" CssClass="col-xs-10 col-sm-5" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>

                    <div style="padding-top: 50px; text-align: center;">
                        <asp:TextBox ID="GuncelSifre" runat="server" TextMode="Password" placeholder="Şifre" CssClass="col-xs-10 col-sm-5" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                    <div style="padding-top: 50px; text-align: center;">
                        <asp:Button ID="BilgiGuncelle" CssClass="ace-icon fa fa-key bigger-110" runat="server" Text="Güncelle" OnClick="BilgiGuncelle_Click" />
                    </div>
                </div>
                <div class="col-sm-4" style="padding-top: 50px;"></div>
            </div>
        </div>
    </form>
</body>
</html>