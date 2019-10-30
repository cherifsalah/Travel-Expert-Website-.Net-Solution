<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewUserRegistration.aspx.cs" Inherits="Workshop5webformwithAuthentication.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table style="width: 35%">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbFirstName" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbLastName" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbAddress" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbCity" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblProvince" runat="server" Text="Province"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbProvince" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPostCode" runat="server" Text="PostCode"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbPostCode" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCountry" runat="server" Text="Country"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbCountry" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblHomePhone" runat="server" Text="Home Phone"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbHomePhone" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblBusPhone" runat="server" Text="Business Phone"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbBusPhone" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAgentID" runat="server" Text="AgentID"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbAgentID" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="ConfirmPassword" runat="server" Text="Confirm Password"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbConfirmPassword" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Button" />
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Button" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>
