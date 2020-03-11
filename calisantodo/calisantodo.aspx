<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="calisantodo.aspx.cs" Inherits="WebApplication4.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Çalışan To Do</title>
    <link href="bootstrap-4.3.1-dist/bootstrap-4.3.1-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="bootstrap-4.3.1-dist/bootstrap-4.3.1-dist/js/bootstrap.min.js"></script>
    <style>
        body {
            font-family:'Comic Sans MS';
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
    <form id="form1" runat="server">
        <div class="container-fluid">
            <nav class="navbar navbar-expand-lg ">
                <div class="collapse navbar-collapse" id="navbarTogglerDemo02">
                    <ul class="navbar-nav mr-auto mt-2 mt-lg-0">
                        <li class="nav-item active">
                            <asp:Button ID="ToDo" runat="server" CssClass="btn btn-danger btn-block" Style="background-color: cadetblue; width: 200px;" Text="To Do" OnClick="ToDo_Click" />
                        </li>
                        <li class="nav-item"></li>
                        <asp:Button ID="Calisan" runat="server" CssClass="btn btn-danger btn-block" Style="background-color: cadetblue; width: 120px;" Text="Çalışan To Do" OnClick="Calisan_Click" />
                        <li class="nav-item">
                            <asp:Button ID="Kayit" runat="server" CssClass="btn btn-danger btn-block" Style="background-color: cadetblue; width: 210px;" Text="Çalışan Kayıt-Güncelleme" OnClick="Kayit_Click" />
                        </li>
                    </ul>
                    <asp:Button ID="Cikis" runat="server" CssClass="btn btn-danger btn-block" Style="background-color: cadetblue; width: 60px; float: right" Text="Çıkış" OnClick="Cikis_Click" />
                </div>
            </nav>
            <div class="row" style="padding-top: 10px;">
                <div class="col-sm-12" style="padding-top: 5px;">
                    <asp:Label ID="Label1" CssClass="col-xs-10 col-sm-5" Style="width: 200px; background-color: white;" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="row" style="padding-top: 10px;">
                <div class="col-sm-6" style="padding-top: 5px;">
                    <asp:DropDownList ID="DropDownList2" DataTextField="fullname" AppendDataBoundItems="true" DataValueField="id" Style="width: 400px; height: 30px;" runat="server">
                        <asp:ListItem Text="-Çalışan Seçiniz-" Value="1"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="Bul" CssClass="btn btn-info btn-sm; ace-icon fa fa-key bigger-110" runat="server" Style="height: 40px; width: 50px;" Text="Bul" OnClick="Bul_Click" />
                </div>
            </div>
            <div class="row" style="padding-top: 5px;">
                <div class="col-sm-4" style="padding-top: 5px;">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button ID="Yapacagim" runat="server" CssClass="btn btn-danger btn-block" Style="background-color: cadetblue; width: 100%;" Text="Yapacağım" />
                        </div>
                    </div>
                    <div class="row">
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <div class="col-md-12">
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" Text='<%#Eval("description") %>'>  </asp:TextBox>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <div class="col-sm-4" style="padding-top: 5px;">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button ID="Yapiyoum" runat="server" CssClass="btn btn-danger btn-block" Style="background-color: cadetblue;" Text="Yapıyorum" />
                        </div>
                    </div>
                    <div class="row">
                        <asp:Repeater ID="Repeater2" runat="server">
                            <ItemTemplate>
                                <div class="col-md-12">
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" Text='<%#Eval("description") %>'>  </asp:TextBox>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <div class="col-sm-4" style="padding-top: 5px;">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button ID="Yaptim" runat="server" CssClass="btn btn-danger btn-block" Style="background-color: cadetblue;" Text="Yaptım" />
                        </div>
                    </div>
                    <div class="row">
                        <asp:Repeater ID="Repeater3" runat="server">
                            <ItemTemplate>
                                <div class="col-md-12">
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" Text='<%#Eval("description") %>'>  </asp:TextBox>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
