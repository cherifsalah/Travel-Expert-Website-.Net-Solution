<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="Workshop5webformwithAuthentication.Booking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified">
        <tr>
            <td style="height: 20px">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="White" Text="Traveler count"></asp:Label>
            </td>
            <td style="height: 20px">
                <asp:TextBox ID="tbTravelerCount" runat="server" Font-Bold="True" ForeColor="Black">1</asp:TextBox>
            </td>
            <td style="height: 20px">
                <asp:RangeValidator ID="rgvtravelerCount" runat="server" ControlToValidate="tbTravelerCount" ErrorMessage="Must be less than 150" Font-Bold="True" ForeColor="Red" MaximumValue="150" MinimumValue="1" Type="Integer" CssClass="text-danger" Display="Dynamic" SetFocusOnError="True"></asp:RangeValidator>
                <asp:RequiredFieldValidator ID="rfvTravelerCount" runat="server" ControlToValidate="tbTravelerCount" ErrorMessage="Traveler count must be entered " Font-Bold="True" ForeColor="Red" CssClass="text-danger" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="White" Text="Trip type"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlisttripType" runat="server" DataSourceID="SqlDataSource2" DataTextField="TTName" DataValueField="TripTypeId" Font-Bold="True" ForeColor="Black">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TravelExpertsConnectionString %>" SelectCommand="SELECT [TripTypeId], [TTName] FROM [TripTypes]"></asp:SqlDataSource>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="lblbokingConfirmation" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:GridView ID="GridViewBooking" runat="server" AutoGenerateColumns="False" BorderColor="White" BorderStyle="Double" DataKeyNames="PackageId" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridViewBooking_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="PkgName" HeaderText="PkgName" SortExpression="PkgName" />
            <asp:BoundField DataField="PkgStartDate" HeaderText="PkgStartDate" SortExpression="PkgStartDate" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="PkgEndDate" HeaderText="PkgEndDate" SortExpression="PkgEndDate" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="PkgDesc" HeaderText="PkgDesc" SortExpression="PkgDesc" />
            <asp:BoundField DataField="PkgBasePrice" HeaderText="PkgBasePrice" SortExpression="PkgBasePrice" DataFormatString="{0:C2}" />
            <asp:BoundField DataField="PkgAgencyCommission" HeaderText="PkgAgencyCommission" SortExpression="PkgAgencyCommission" DataFormatString="{0:C2}" />
            <asp:BoundField DataField="PackageId" HeaderText="PackageId" InsertVisible="False" ReadOnly="True" SortExpression="PackageId" />
            <asp:CommandField SelectText="Book Now" ShowSelectButton="True" />
            <asp:ImageField DataImageUrlField="Photo" ControlStyle-Height="100px" ControlStyle-Width="200">
<ControlStyle Height="100px" Width="200px"></ControlStyle>
            </asp:ImageField>
        </Columns>
    </asp:GridView>
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TravelExpertsConnectionString %>" SelectCommand="	SELECT [PkgStartDate], [PkgEndDate], [PkgDesc], [PkgBasePrice], [PkgAgencyCommission], [PkgName], [PackageId] ,
 concat ('Photos/', [PackageId],  '.jpg') as Photo
	FROM [Packages]"></asp:SqlDataSource>
</asp:Content>
