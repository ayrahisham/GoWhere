<%@ Page Title="Tourist - View Tours By Date" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewTourListByDate.aspx.cs" Inherits="viewTourListByDate" Debug ="true" %>

<asp:Content ID ="loginUser" ContentPlaceHolderID="loginUser" runat="server">
    Logged in as <b><u>Tourist</u></b>
</asp:Content> 

<asp:Content ID ="menubarConnectTG" ContentPlaceHolderID="menubar" runat="server">
    <ul>
       <li>
             <img src = "GoWhere/Images/back.png" height = "30" width = "30">
             <asp:HyperLink ID="backUpTour" runat="server" NavigateUrl="~/viewT.aspx"> BACK </asp:HyperLink>    
       </li>
        <li>
             <img src = "GoWhere/Images/home.jpg" height = "30" width = "30">
             <asp:HyperLink ID="backHomeTourG" runat="server" NavigateUrl="~/homeTR.aspx"> HOME </asp:HyperLink>
       </li>
    </ul> 
</asp:Content>
<asp:Content ID="viewToursContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="viewTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="5"> <b> Tour Information List</b></asp:TableCell>
        </asp:TableHeaderRow>
    </asp:Table>

    <asp:Table ID="showTable" runat="server"></asp:Table>
</asp:Content>
