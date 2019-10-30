<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PackageSelection.aspx.cs" Inherits="Workshop5webformwithAuthentication.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gvPackages" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataKeyNames="PackageId" DataSourceID="SqlDataSource2" ForeColor="Black">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="PackageId" HeaderText="PackageId" InsertVisible="False" ReadOnly="True" SortExpression="PackageId" />
            <asp:BoundField DataField="PkgName" HeaderText="PkgName" SortExpression="PkgName" />
            <asp:BoundField DataField="PkgStartDate" HeaderText="PkgStartDate" SortExpression="PkgStartDate" />
            <asp:BoundField DataField="PkgEndDate" HeaderText="PkgEndDate" SortExpression="PkgEndDate" />
            <asp:BoundField DataField="PkgDesc" HeaderText="PkgDesc" SortExpression="PkgDesc" />
            <asp:BoundField DataField="PkgBasePrice" HeaderText="PkgBasePrice" SortExpression="PkgBasePrice" />
            <asp:BoundField DataField="PkgAgencyCommission" HeaderText="PkgAgencyCommission" SortExpression="PkgAgencyCommission" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TravelExpertsConnectionString %>" SelectCommand="select * from packages"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
</asp:Content>
