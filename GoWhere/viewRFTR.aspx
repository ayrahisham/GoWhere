<%@ Page Title="Tour Guide - View Ratings from Tourists" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewRFTR.aspx.cs" Inherits="viewRFTR" Debug ="true" %>


<asp:Content ID ="loginUser" ContentPlaceHolderID="loginUser" runat="server">
    Logged in: <b><u>Tour Guide</u></b>
</asp:Content> 

<asp:Content ID ="menubarViewRFTR" ContentPlaceHolderID="menubar" runat="server">
    <ul>
       <li>
             <img src = "GoWhere/Images/back.png" height = "30" width = "30">
             <asp:HyperLink ID="backTGProfile" runat="server" NavigateUrl="~/viewR.aspx"> BACK </asp:HyperLink>    
       </li>
        <li>
             <img src = "GoWhere/Images/home.jpg" height = "30" width = "30">
             <asp:HyperLink ID="backHomeTourG" runat="server" NavigateUrl="~/homeTG.aspx"> HOME </asp:HyperLink>
       </li>
    </ul> 
</asp:Content>

<asp:Content ID="viewRFTRContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="viewRFTRTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="3"> 
                <b> VIEW MY RATINGS FROM TOURISTS</b>
            </asp:TableCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="tID" runat="server" Text="Tour ID"></asp:Label>
             </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="trID" runat="server" Text="Tourist ID"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="R" runat="server" Text="Ratings"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>


