<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DemoVerify.aspx.cs" Inherits="VerifyWS_ASPNET.DemoVerify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Verify-Street Master</title>
</head>
<body bgcolor="#E6E6FA">
    <form id="DemoVerify" runat="server">
        <div style="border: groove; border-color: #336600; width: 482px;">

            <table border="0" cellpadding="2" cellspacing="2">
                <tr>
                    <th colspan="2">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo-street-master.png" />
                        <br />
                        <font size="5">VERIFY</font></th>
                </tr>
                <tr>
                    <td>Key
                    </td>
                    <td>
                        <asp:TextBox ID="txtKey" Autocomplete="off" Width="400px" runat="server" Text="Specificare una chiave per il servizio Verify" />
                    </td
                </tr>
                <tr>
                    <td>Provincia</td>
                    <td>
                        <asp:TextBox ID="txtProv" Autocomplete="off" Width="30px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Comune</td>
                    <td>
                        <asp:TextBox ID="txtComune" autocomplete="off" Width="400px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Cap</td>
                    <td>
                        <asp:TextBox ID="txtCap" autocomplete="off" Width="50px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Frazione</td>
                    <td>
                        <asp:TextBox ID="txtFrazione" autocomplete="off" Width="400px" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Indirizzo</td>
                    <td>
                        <asp:TextBox ID="txtIndirizzo" autocomplete="off" Width="400px" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <p>
            <asp:Button ID="btnCallVerify" runat="server" OnClick="btnCallVerify_Click" Text="Call Verify" />
        </p>
        <div id="outArea" runat="server" style="width: 482px;" />
    </form>
</body>
</html>
