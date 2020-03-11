<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yoneticitodo.aspx.cs" Inherits="WebApplication4.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Yönetici To Do</title>
    <link href="bootstrap-4.3.1-dist/bootstrap-4.3.1-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="bootstrap-4.3.1-dist/bootstrap-4.3.1-dist/js/bootstrap.min.js"></script>
    <style>
        .column {
            width: 170px;
            float: left;
            padding-bottom: 100px;
        }

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
    <form id="form1" runat="server" defaultbutton="Button1">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
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
                    <nav class="navbar navbar-expand-lg">
                        <div class="collapse navbar-collapse" id="navbarTogglerDemo01">
                            <ul class="navbar-nav mr-auto mt-2 mt-lg-0" style="padding-left: 400px;">
                                <li class="nav-item">
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Style="width: 400px;" placeholder="Görev" ValidateRequestMode="Disabled" TextMode="MultiLine"></asp:TextBox>
                                </li>
                                <li class="nav-item" style="padding-top: 10px;">
                                    <asp:DropDownList ID="DropDownList2" runat="server" DataTextField="type" Style="width: 200px; height: 38px;"></asp:DropDownList>
                                </li>
                                <li class="nav-item" style="padding-top: 10px;">
                                    <asp:Button ID="Button1" runat="server" Text="+" CssClass="btn btn-light" OnClick="Arti_Click" />
                                </li>
                            </ul>
                        </div>
                    </nav>

                    <div class="row" style="padding-top: 5px;">
                        <div class="col-sm-4" style="padding-top: 5px;">
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Button ID="Yapacagim" runat="server" CssClass="btn btn-danger btn-block" Style="background-color: cadetblue; width: 100%;" Text="Yapacağım" />
                                </div>
                            </div>
                            <div class="row">
                                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                    <ItemTemplate>
                                        <div class="col-md-12">
                                            <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" AutoCompleteType="Disabled" ValidateRequestMode="Disabled" TextMode="MultiLine" Text='<%#Eval("description") %>'>  </asp:TextBox>
                                            <asp:LinkButton ID="btnNext" runat="server" CssClass="btn spinbox-up btn-sm btn-white" CommandName="Next" Style="float: right; color: black;" CommandArgument='<%#Eval("id") %>'>—></asp:LinkButton>
                                            <asp:LinkButton ID="btnDown" runat="server" CssClass="btn spinbox-up btn-sm btn-white" CommandName="Down" Style="float: right; color: black;" CommandArgument='<%#Eval("id") %>'>Aşağı</asp:LinkButton>
                                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-sm btn-danger" CommandName="Delete" OnClientClick="return confirm('Silmek istediğinizden emin misiniz?');" Style="float: right;" CommandArgument='<%#Eval("id") %>'>Sil</asp:LinkButton>
                                            <asp:LinkButton ID="btnUp" runat="server" CssClass="btn spinbox-up btn-sm btn-white" CommandName="Up" Style="float: right; color: black;" CommandArgument='<%#Eval("id") %>'>Yukarı</asp:LinkButton>
                                            <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-sm btn-success" CommandName="Update" Style="float: right;" CommandArgument='<%#Eval("id") %>'>Güncelle</asp:LinkButton>
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
                                <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand">
                                    <ItemTemplate>
                                        <div class="col-md-12">
                                            <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" AutoCompleteType="Disabled" ValidateRequestMode="Disabled" TextMode="MultiLine" Text='<%#Eval("description") %>'>  </asp:TextBox>
                                            <asp:LinkButton ID="btnNext" runat="server" CssClass="btn spinbox-up btn-sm btn-white" CommandName="Next" Style="float: right; color: black;" CommandArgument='<%#Eval("id") %>'>—></asp:LinkButton>
                                            <asp:LinkButton ID="btnDown" runat="server" CssClass="btn spinbox-up btn-sm btn-white" CommandName="Down" Style="float: right; color: black;" CommandArgument='<%#Eval("id") %>'>Aşağı</asp:LinkButton>
                                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-sm btn-danger" CommandName="Delete" OnClientClick="return confirm('Silmek istediğinizden emin misiniz?');" Style="float: right;" CommandArgument='<%#Eval("id") %>'>Sil</asp:LinkButton>
                                            <asp:LinkButton ID="btnUp" runat="server" CssClass="btn spinbox-up btn-sm btn-white" CommandName="Up" Style="float: right; color: black;" CommandArgument='<%#Eval("id") %>'>Yukarı</asp:LinkButton>
                                            <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-sm btn-success" CommandName="Update" Style="float: right;" CommandArgument='<%#Eval("id") %>'>Güncelle</asp:LinkButton>
                                            <asp:LinkButton ID="btnBack" runat="server" CssClass="btn spinbox-up btn-sm btn-white" CommandName="Back" Style="float: right; color: black;" CommandArgument='<%#Eval("id") %>'><—</asp:LinkButton>
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
                                <asp:Repeater ID="Repeater3" runat="server" OnItemCommand="Repeater3_ItemCommand">
                                    <ItemTemplate>
                                        <div class="col-md-12">
                                            <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server" AutoCompleteType="Disabled" ValidateRequestMode="Disabled" TextMode="MultiLine" Text='<%#Eval("description") %>'>  </asp:TextBox>
                                            <asp:LinkButton ID="btnDown" runat="server" CssClass="btn spinbox-up btn-sm btn-white" CommandName="Down" Style="float: right; color: black;" CommandArgument='<%#Eval("id") %>'>Aşağı</asp:LinkButton>
                                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-sm btn-danger" CommandName="Delete" OnClientClick="return confirm('Silmek istediğinizden emin misiniz?');" Style="float: right;" CommandArgument='<%#Eval("id") %>'>Sil</asp:LinkButton>
                                            <asp:LinkButton ID="btnUp" runat="server" CssClass="btn spinbox-up btn-sm btn-white" CommandName="Up" Style="float: right; color: black;" CommandArgument='<%#Eval("id") %>'>Yukarı</asp:LinkButton>
                                            <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-sm btn-success" CommandName="Update" Style="float: right;" CommandArgument='<%#Eval("id") %>'>Güncelle</asp:LinkButton>
                                            <asp:LinkButton ID="btnBack" runat="server" CssClass="btn spinbox-up btn-sm btn-white" CommandName="Back" Style="float: right; color: black;" CommandArgument='<%#Eval("id") %>'><—</asp:LinkButton>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
