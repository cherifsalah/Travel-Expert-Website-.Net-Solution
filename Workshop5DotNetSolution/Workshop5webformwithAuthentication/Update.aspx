<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Workshop5webformwithAuthentication.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-left:40px">

    <div style="margin-left:40px">
    <table style="width: 35%">
        <tr>
            <td colspan="2">Enter your Personal Details</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 20px">
                <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
            </td>
            <td style="height: 20px">
                <asp:TextBox ID="tbFirstName" runat="server" ForeColor="Black" MaxLength="25" ></asp:TextBox>
            </td>
            <td style="height: 20px">
                <asp:RequiredFieldValidator ID="rqvfirstname" runat="server" ControlToValidate="tbFirstName" ErrorMessage="First name required" Font-Bold="True" ForeColor="Red" CssClass="text-danger" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rgxvFristName" runat="server" ControlToValidate="tbFirstName" CssClass="text-danger" Display="Dynamic" ErrorMessage="First name not valid" SetFocusOnError="True" ValidationExpression="^[a-zA-Z'.\s]{1,25}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbLastName" runat="server" ForeColor="Black" MaxLength="25"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rqvlastname" runat="server" ControlToValidate="tbLastName" ErrorMessage="Last name required" Font-Bold="True" ForeColor="Red" CssClass="text-danger" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rgxvLastName" runat="server" ControlToValidate="tbLastName" CssClass="text-danger" Display="Dynamic" ErrorMessage="Last name not valid" SetFocusOnError="True" ValidationExpression="^[a-zA-Z'.\s]{1,25}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbAddress" runat="server" ForeColor="Black" MaxLength="75"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rqvAdress" runat="server" ControlToValidate="tbAddress" ErrorMessage="Adress is required" Font-Bold="True" ForeColor="Red" CssClass="text-danger" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbCity" runat="server" ForeColor="Black" MaxLength="50"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rqvCity" runat="server" ControlToValidate="tbCity" ErrorMessage="City is required" Font-Bold="True" ForeColor="Red" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revCity" runat="server" ControlToValidate="tbCity" CssClass="text-danger" Display="Dynamic" ErrorMessage="City is not valid" ValidationExpression="^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblProvince" runat="server" Text="Province"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlProvince" runat="server" ForeColor="Black">
                    <asp:ListItem Value="AB">Alberta</asp:ListItem>
                    <asp:ListItem Value="PE">Prince Edward Island</asp:ListItem>
                    <asp:ListItem Value="NS">Nova Scotia</asp:ListItem>
                    <asp:ListItem Value="NB">New Brunswick</asp:ListItem>
                    <asp:ListItem Value="QC">Quebec</asp:ListItem>
                    <asp:ListItem Value="ON">Ontario</asp:ListItem>
                    <asp:ListItem Value="MB">Manitoba</asp:ListItem>
                    <asp:ListItem Value="SK">Saskatchewan</asp:ListItem>
                    <asp:ListItem Value="BC">British Columbia</asp:ListItem>
                    <asp:ListItem Value="YT">Yukon</asp:ListItem>
                    <asp:ListItem Value="NT	">Northwest Territories	</asp:ListItem>
                    <asp:ListItem Value="NU">Nunavut</asp:ListItem>
                    <asp:ListItem Value="NL">Newfoundland and Labrador</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPostCode" runat="server" Text="PostCode"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbPostCode" runat="server" ForeColor="Black" MaxLength="7"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rqvPostCode" runat="server" ControlToValidate="tbPostCode" ErrorMessage="Postal Code required" Font-Bold="True" ForeColor="Red" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revPostCode" runat="server" ControlToValidate="tbPostCode" CssClass="text-danger" Display="Dynamic" ErrorMessage="Postal code not valid" SetFocusOnError="True" ValidationExpression="^[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ][\s][0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCountry" runat="server" Text="Country"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbCountry" runat="server" ForeColor="Black" MaxLength="25"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="revCountry" runat="server" ControlToValidate="tbCountry" CssClass="text-danger" Display="Dynamic" ErrorMessage="Country is not valid" SetFocusOnError="True" ValidationExpression="^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblHomePhone" runat="server" Text="Home Phone"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbHomePhone" runat="server" ForeColor="Black" TextMode="Phone" MaxLength="20"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblBusPhone" runat="server" Text="Business Phone"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbBusPhone" runat="server" ForeColor="Black" TextMode="Phone" MaxLength="20"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rqvBusphone" runat="server" ControlToValidate="tbBusPhone" ErrorMessage="Business Phone required" Font-Bold="True" ForeColor="Red" CssClass="text-danger" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbEmail" runat="server" ForeColor="Black" TextMode="Email" MaxLength="50"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rqvEmail" runat="server" ControlToValidate="tbEmail" ErrorMessage="Email is required" Font-Bold="True" ForeColor="Red" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAgentID" runat="server" Text="AgentID"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlAgent" runat="server" DataSourceID="SqlDataSource1" DataTextField="AgtFirstName" DataValueField="AgentId" ForeColor="Black">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TravelExpertsConnectionString2 %>" SelectCommand="SELECT [AgentId], [AgtFirstName] FROM [Agents]"></asp:SqlDataSource>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 22px">
                <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
            </td>
            <td style="height: 22px">
                <asp:TextBox ID="tbPassword" runat="server" ForeColor="Black" TextMode="Password" MaxLength="20"></asp:TextBox>
            </td>
            <td style="height: 22px">
                <asp:RequiredFieldValidator ID="rqvPassword" runat="server" ControlToValidate="tbPassword" ErrorMessage="Password is Required" Font-Bold="True" ForeColor="Red" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="ConfirmPassword" runat="server" Text="Confirm Password"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbConfirmPassword" runat="server" ForeColor="Black" TextMode="Password" MaxLength="20"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rqvConfirmPassword" runat="server" ControlToValidate="tbConfirmPassword" ErrorMessage="Confirm Password field is required" Font-Bold="True" ForeColor="Red" CssClass="text-danger" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cmpvalidatorPassword" runat="server" ControlToCompare="tbPassword" ControlToValidate="tbConfirmPassword" CssClass="text-danger" Display="Dynamic" ErrorMessage="Password and Confirm Password should be the same" SetFocusOnError="True"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnUpdate" runat="server" Text="Update" BackColor="#666699" OnClick="btnUpdate_Click" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="lblErrorMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
        </div>

    </div>
</asp:Content>
