<%@ Page Title="Tour Guide - View Feedback to Tourists" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewFB2TR.aspx.cs" Inherits="viewFB2TR" Debug ="true" %>

<asp:Content ID ="loginUser" ContentPlaceHolderID="loginUser" runat="server">
    Logged in: <b><u>Tour Guide</u></b>
</asp:Content> 

<asp:Content ID ="menubarViewFB2TR" ContentPlaceHolderID="menubar" runat="server">
    <ul>
       <li>
             <img src = "GoWhere/Images/back.png" height = "30" width = "30">
             <asp:HyperLink ID="backTGProfile" runat="server" NavigateUrl="~/viewFB.aspx"> BACK </asp:HyperLink>    
       </li>
        <li>
             <img src = "GoWhere/Images/home.jpg" height = "30" width = "30">
             <asp:HyperLink ID="backHomeTourG" runat="server" NavigateUrl="~/homeTG.aspx"> HOME </asp:HyperLink>
       </li>
    </ul> 
</asp:Content>

<asp:Content ID="viewFB2TRContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="viewFB2TRTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="3"> 
                <b> VIEW MY FEEDBACK TO TOURISTS</b>
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
                <asp:Label ID="FB" runat="server" Text="Description of Feedback"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>

