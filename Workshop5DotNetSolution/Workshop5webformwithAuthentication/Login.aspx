<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Workshop5webformwithAuthentication.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified">
    <tr>
        <td>&nbsp;</td>
        <td style="font-size: large"><strong>Log in</strong></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="font-size: small"><strong>Email</strong></td>
        <td>
            <asp:TextBox ID="txtEmail" runat="server" Font-Bold="True" ForeColor="Black" TextMode="Email" Width="249px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="rqfEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email field is required" Font-Bold="True" ForeColor="#CC0000"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="font-size: small; height: 28px"><strong>Password</strong></td>
        <td style="height: 28px">
            <asp:TextBox ID="txtPassword" runat="server" Font-Bold="True" ForeColor="Black" TextMode="Password" Width="250px"></asp:TextBox>
        </td>
        <td style="height: 28px">
            <asp:RequiredFieldValidator ID="rqfPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required" Font-Bold="True" ForeColor="#CC0000"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Button ID="btnLogin" runat="server" Font-Bold="True" ForeColor="Black" OnClick="btnLogin_Click" Text="Login" Width="145px" />
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
