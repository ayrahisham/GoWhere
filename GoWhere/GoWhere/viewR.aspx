<%@ Page Title="Tour Guide - View Ratings" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewR.aspx.cs" Inherits="viewR" Debug ="true"%>


<asp:Content ID ="loginUser" ContentPlaceHolderID="loginUser" runat="server">
    Logged in: <b><u>Tour Guide</u></b>
</asp:Content> 

<asp:Content ID ="menubarViewR" ContentPlaceHolderID="menubar" runat="server">
    <ul>
       <li>
             <img src = "GoWhere/Images/back.png" height = "30" width = "30">
             <asp:HyperLink ID="backTGProfile" runat="server" NavigateUrl="~/viewTG.aspx"> BACK </asp:HyperLink>    
       </li>
        <li>
             <img src = "GoWhere/Images/home.jpg" height = "30" width = "30">
             <asp:HyperLink ID="backHomeTourG" runat="server" NavigateUrl="~/homeTG.aspx"> HOME </asp:HyperLink>
       </li>
    </ul> 
</asp:Content>

<asp:Content ID="viewRContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="viewRTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="2"> 
                <b> VIEW MY RATINGS</b>
            </asp:TableCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="R2TR" runat="server" Text="View Ratings To Tourists" PostBackUrl="~/viewR2TR.aspx" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="RFTR" runat="server" Text="View Ratings From Tourists" PostBackUrl="~/viewRFTR.aspx" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>



