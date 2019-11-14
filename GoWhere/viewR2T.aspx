<%@ Page Title="Tourist - View Ratings to Tours" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewR2T.aspx.cs" Inherits="viewR2T" Debug="true"%>

<asp:Content ID ="loginUser" ContentPlaceHolderID="loginUser" runat="server">
    Logged in: <b><u>Tourist</u></b>
</asp:Content> 

<asp:Content ID ="menubarViewR2T" ContentPlaceHolderID="menubar" runat="server">
    <ul>
       <li>
             <img src = "GoWhere/Images/back.png" height = "30" width = "30">
             <asp:HyperLink ID="backTGProfile" runat="server" NavigateUrl="~/viewRTR.aspx"> BACK </asp:HyperLink>    
       </li>
        <li>
             <img src = "GoWhere/Images/home.jpg" height = "30" width = "30">
             <asp:HyperLink ID="backHomeTourG" runat="server" NavigateUrl="~/homeTR.aspx"> HOME </asp:HyperLink>
       </li>
    </ul> 
</asp:Content>

<asp:Content ID="viewR2TRContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="viewR2TRTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="4"> 
                <b> VIEW MY RATINGS TO TOURS</b>
            </asp:TableCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="tID" runat="server" Text="Tour ID"></asp:Label>
             </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="BID" runat="server" Text="Booking ID"></asp:Label>
             </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="ID" runat="server" Text="Tour Guide ID"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="R" runat="server" Text="Ratings"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>





