<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewPackages.aspx.cs" Inherits="Workshop5webformwithAuthentication.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="gvCustomerPackages" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceCustomerPackages">
    <Columns>
        <asp:BoundField DataField="CostOfAllPackages" HeaderText="CostOfAllPackages" ReadOnly="True" SortExpression="CostOfAllPackages" />
        <asp:BoundField DataField="CountOfPackagesBought" HeaderText="CountOfPackagesBought" ReadOnly="True" SortExpression="CountOfPackagesBought" />
        <asp:BoundField DataField="PkgDesc" HeaderText="PkgDesc" SortExpression="PkgDesc" />
        <asp:BoundField DataField="PkgBasePrice" HeaderText="PkgBasePrice" SortExpression="PkgBasePrice" />
        <asp:BoundField DataField="PkgName" HeaderText="PkgName" SortExpression="PkgName" />
        <asp:BoundField DataField="CustFirstName" HeaderText="CustFirstName" SortExpression="CustFirstName" />
        <asp:BoundField DataField="CustLastName" HeaderText="CustLastName" SortExpression="CustLastName" />
        <asp:BoundField DataField="CustEmail" HeaderText="CustEmail" SortExpression="CustEmail" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSourceCustomerPackages" runat="server" ConnectionString="<%$ ConnectionStrings:TravelExpertsConnectionString %>" SelectCommand="SELECT SUM(P.PkgBasePrice) AS CostOfAllPackages, SUM(P.PkgBasePrice) / P.PkgBasePrice AS CountOfPackagesBought, P.PkgDesc, P.PkgBasePrice, P.PkgName, C.CustFirstName, C.CustLastName, C.CustEmail FROM Packages AS P INNER JOIN Bookings AS B ON P.PackageId = B.PackageId INNER JOIN Customers AS C ON C.CustomerId = B.CustomerId WHERE (C.CustEmail = @CustEmail) GROUP BY C.CustEmail, P.PkgName, P.PkgBasePrice, C.CustFirstName, C.CustLastName, P.PkgDesc" OnSelecting="SqlDataSourceCustomerPackages_Selecting">
    <SelectParameters>
        <asp:SessionParameter Name="CustEmail" SessionField="CustEmail" />
    </SelectParameters>
</asp:SqlDataSource>

    <asp:GridView ID="grvtotalowing" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourcetotalowing">
        <Columns>
            <asp:BoundField DataField="Total Owing:" HeaderText="Total Owing:" ReadOnly="True" SortExpression="Total Owing:" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSourcetotalowing" runat="server" ConnectionString="<%$ ConnectionStrings:TravelExpertsConnectionString2 %>" SelectCommand="	with x as (
	SELECT SUM(P.PkgBasePrice) AS CostOfAllPackages, 
	SUM(P.PkgBasePrice) / P.PkgBasePrice AS CountOfPackagesBought, 
	P.PkgDesc, P.PkgBasePrice, P.PkgName, C.CustFirstName, C.CustLastName, C.CustEmail 
	FROM Packages AS P INNER JOIN Bookings AS B ON P.PackageId = B.PackageId INNER JOIN Customers AS C 
	ON C.CustomerId = B.CustomerId WHERE (C.CustEmail = 'salah@aol.com') GROUP BY 
	C.CustEmail, P.PkgName, P.PkgBasePrice, C.CustFirstName, C.CustLastName, P.PkgDesc)
	select sum(CostOfAllPackages) as 'Total Owing:' from x"></asp:SqlDataSource>
    
    
</asp:Content>
