<%@ Page Title="Tour Guide - View Feedback" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewFB.aspx.cs" Inherits="viewFB" debug ="true"%>

<asp:Content ID ="loginUser" ContentPlaceHolderID="loginUser" runat="server">
    Logged in: <b><u>Tour Guide</u></b>
</asp:Content> 

<asp:Content ID ="menubarViewFB" ContentPlaceHolderID="menubar" runat="server">
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

<asp:Content ID="viewFBContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="viewFBTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="2"> 
                <b> VIEW MY FEEDBACK</b>
            </asp:TableCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="FB2TR" runat="server" Text="View Feedback To Tourists" PostBackUrl="~/viewFB2TR.aspx" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="FBFTR" runat="server" Text="View Feedback From Tourists" PostBackUrl="~/viewFBFTR.aspx" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>

