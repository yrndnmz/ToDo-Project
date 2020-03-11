<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="giris.aspx.cs" Inherits="WebApplication4.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Giriş</title>
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
    <form id="form1" runat="server" defaultbutton="Girisbutonu">
        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-4">
                </div>
                <div class="col-sm-4" style="padding-top: 330px; text-align:center;">
                    <div>
                        <asp:TextBox ID="Kullaniciadi" CssClass="input-small" runat="server" placeholder="Kullanıcı Adı" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                    <div style="padding-top: 50px;">
                        <asp:TextBox ID="Sifre" CssClass="input-small" TextMode="Password" runat="server" placeholder="Şifre" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                    <div style="padding-top: 50px;">
                        <asp:Button ID="Girisbutonu" CssClass="ace-icon fa fa-check" style="background-color:cadetblue; width:70px;" runat="server" Text="Giriş" OnClick="Girisbutonu_Click" />
                    </div>
                </div>
                <div class="col-sm-4">
                </div>
            </div>
        </div>
    </form>
</body>
</html>
