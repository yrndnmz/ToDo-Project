<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kayitekrani.aspx.cs" Inherits="WebApplication4.kayitekrani" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Çalışan Kayıt-Güncelleme</title>
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
</head>
<body>
    <form id="form1" runat="server" defaultbutton="Button1">
        <div class="container-fluid">
            <nav class="navbar navbar-expand-lg">
                <div class="collapse navbar-collapse" id="navbarTogglerDemo02">
                    <ul class="navbar-nav mr-auto mt-2 mt-lg-0">
                        <li class="nav-item active">
                            <asp:Button ID="ToDo" runat="server" CssClass="btn btn-danger btn-block" Style="background-color: cadetblue; width: 200px;" Text="To Do" OnClick="ToDo_Click" />
                        </li>
                        <li class="nav-item">
                            <asp:Button ID="Calisan" runat="server" CssClass="btn btn-danger btn-block" Style="background-color: cadetblue; width: 120px;" Text="Çalışan To Do" OnClick="Calisan_Click" />
                        </li>
                        <li class="nav-item">
                            <asp:Button ID="Kayit" runat="server" CssClass="btn btn-danger btn-block" Style="background-color: cadetblue; width: 210px;" Text="Çalışan Kayıt-Güncelleme" OnClick="Kayit_Click" />
                        </li>
                    </ul>
                    <asp:Button ID="Cikis" runat="server" CssClass="btn btn-danger btn-block" Style="background-color: cadetblue; width: 60px; float: right;" Text="Çıkış" OnClick="Cikis_Click" />
                </div>
            </nav>
            <div class="row" style="height: 50px;">
                <div class="col-sm-6" style="padding-top: 50px;">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-danger btn-block" Style="background-color: cadetblue; width: 100%;" Text="Kayıt Güncelleme" />
                </div>
                <div class="col-sm-6" style="padding-top: 50px;">
                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-danger btn-block" Style="background-color: cadetblue; width: 100%;" Text="Kayıt Alma" />
                </div>
            </div>
            <div class="row" style="height: 50px;">
                <div class="col-sm-6" style="padding-top: 50px;">
                    <div style="padding-top: 20px; text-align: center;">
                        <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="true" DataTextField="fullname" DataValueField="id" Style="width: 400px; height: 30px;">
                            <asp:ListItem Text="-Çalışan Listesi-" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="Bul" CssClass="btn btn-info btn-sm; ace-icon fa fa-key bigger-110" runat="server" Style="height: 40px; width: 60px;" Text="Bul" OnClick="Bul_Click" />
                    </div>
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
                        <asp:Button ID="Sil" CssClass="ace-icon fa fa-key bigger-110" runat="server" Text="Kullanıcı Sil" OnClick="Sil_Click" OnClientClick="return confirm('Silmek istediğinizden emin misiniz?');"/>
                        <asp:Button ID="BilgiGuncelle" CssClass="ace-icon fa fa-key bigger-110" runat="server" Text="Güncelle" OnClick="BilgiGuncelle_Click" />
                    </div>
                </div>
                <div class="col-sm-6" style="padding-top: 50px;">
                    <div style="padding-top: 50px; text-align: center;">
                        <asp:TextBox ID="adi" runat="server" placeholder="Ad" CssClass="col-xs-10 col-sm-5" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                    <div style="padding-top: 50px; text-align: center;">
                        <asp:TextBox ID="soyadi" runat="server" placeholder="Soyad" CssClass="col-xs-10 col-sm-5" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                    <div style="padding-top: 50px; text-align: center;">
                        <asp:TextBox ID="kullaniciadi" runat="server" placeholder="Kullanıcı Adı" CssClass="col-xs-10 col-sm-5" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                    <div style="padding-top: 50px; text-align: center;">
                        <asp:TextBox ID="sifre" runat="server" TextMode="Password" placeholder="Şifre" CssClass="col-xs-10 col-sm-5" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                    <div style="padding-top: 50px; text-align: center;">
                        <asp:Button ID="Kayitbutonu" CssClass="ace-icon fa fa-key bigger-110" runat="server" Text="Kayıt Ol" OnClick="Kayitbutonu_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
