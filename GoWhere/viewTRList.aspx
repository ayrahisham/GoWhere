<%@ Page Title="Tour Guide - View Tourists List" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewTRList.aspx.cs" Inherits="viewTRList" Debug ="true"%>

<asp:Content ID ="loginUser" ContentPlaceHolderID="loginUser" runat="server">
    Logged in: <b><u>Tour Guide</u></b>
</asp:Content> 

<asp:Content ID ="menubarViewTRList" ContentPlaceHolderID="menubar" runat="server">
    <ul>
       <li>
             <img src = "GoWhere/Images/back.png" height = "30" width = "30">
             <asp:HyperLink ID="backUpTour" runat="server" NavigateUrl="~/viewUpTour.aspx"> BACK </asp:HyperLink>    
       </li>
        <li>
             <img src = "GoWhere/Images/home.jpg" height = "30" width = "30">
             <asp:HyperLink ID="backHomeTourG" runat="server" NavigateUrl="~/homeTG.aspx"> HOME </asp:HyperLink>
       </li>
    </ul> 
</asp:Content>

<asp:Content ID="viewTRListContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="viewTRListTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="3"> 
                <b> VIEW MY TOURISTS LIST FOR TOUR ID </b>
                <asp:Label ID="TID" runat="server" Text="#"></asp:Label>
            </asp:TableCell>
        </asp:TableHeaderRow>
         <asp:TableRow>
             <asp:TableCell>
                <asp:Label ID="ID" runat="server" Text="Tourist ID"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="fname" runat="server" Text="Firstname"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="email" runat="server" Text="Email"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <%--<asp:TableRow>
            <asp:TableCell> 
                <asp:HyperLink ID="TRID" runat="server" NavigateUrl="~/viewTR.aspx"> # </asp:HyperLink>  
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:TextBox ID="TRfname" runat="server" Width="200px"></asp:TextBox>  
            </asp:TableCell>
            <asp:TableCell> 
                <asp:TextBox ID="TRemail" runat="server" Width="100px"></asp:TextBox> 
            </asp:TableCell>
        </asp:TableRow>--%>
    </asp:Table>
</asp:Content>
