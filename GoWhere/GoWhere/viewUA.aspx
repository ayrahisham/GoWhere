<%@ Page Title="User Admin - View User" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewUA.aspx.cs" Inherits="viewUA" Debug =" True" %>

<asp:Content ID ="loginUser" ContentPlaceHolderID="loginUser" runat="server">
    Logged in as <u>User Admin</u>
</asp:Content> 

<asp:Content ID ="menubar" ContentPlaceHolderID="menubar" runat="server">
    <ul>
        <li>
             <img src = "GoWhere/Images/home.jpg" height = "30" width = "30">
             <asp:HyperLink ID="homeUserA" runat="server" NavigateUrl="~/homeUA.aspx"> HOME </asp:HyperLink>
       </li>
        <li>
             <img src = "GoWhere/Images/view.jpg" height = "30" width = "30">
             <asp:HyperLink ID="viewUser" runat="server" NavigateUrl="~/viewUA.aspx"> VIEW </asp:HyperLink>
       </li>
       <li>
             <img src = "GoWhere/Images/suspend.jpg" height = "30" width = "30">
             <asp:HyperLink ID="suspendUser" runat="server" NavigateUrl="~/suspendUA.aspx"> SUSPEND </asp:HyperLink>    
       </li>
       <li>
             <img src = "GoWhere/Images/logout.png" height = "30" width = "30">
             <asp:HyperLink ID="logout" runat="server" NavigateUrl="~/default.aspx"> LOGOUT </asp:HyperLink>
       </li>
    </ul> 
</asp:Content>

<asp:Content ID="viewContent" ContentPlaceHolderID="content" Runat="Server">
   <asp:Table ID="viewTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="3"> <b> VIEW USER ACCOUNT INFORMATION </b></asp:TableCell>
        </asp:TableHeaderRow>
    </asp:Table>

    <asp:Table ID="DisplayTable" runat="server"></asp:Table>
</asp:Content>



