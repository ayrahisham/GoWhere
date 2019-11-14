<%@ Page Title="Tourist - View Tours" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewT.aspx.cs" Inherits="viewT" Debug ="true" %>

<asp:Content ID ="loginUser" ContentPlaceHolderID="loginUser" runat="server">
    Logged in as <b><u>Tourist</u></b>
</asp:Content> 

<asp:Content ID ="menubarViewTours" ContentPlaceHolderID="menubar" runat="server">
    <ul>
        <li>
             <img src = "GoWhere/Images/back.png" height = "30" width = "30">
             <asp:HyperLink ID="backHomeTourG" runat="server" NavigateUrl="~/homeTR.aspx"> HOME </asp:HyperLink>
       </li>
    </ul> 
</asp:Content>

<asp:Content ID="viewToursContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="viewTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="3"> <b> Tour Information List</b></asp:TableCell>
        </asp:TableHeaderRow>
    </asp:Table>

    <asp:Table ID="DisplayTable" runat="server"></asp:Table>
</asp:Content>
