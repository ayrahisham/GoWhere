<%@ Page Title="User Admin - Suspend User" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="suspendUA.aspx.cs" Inherits="suspendUA" Debug="True" %>

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
             <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/suspendUA.aspx"> SUSPEND </asp:HyperLink>    
       </li>
       <li>
             <img src = "GoWhere/Images/logout.png" height = "30" width = "30">
             <asp:HyperLink ID="logout" runat="server" NavigateUrl="~/default.aspx"> LOGOUT </asp:HyperLink>
       </li>
    </ul> 
</asp:Content>

<asp:Content ID="suspendContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="viewTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="2"> <b> SUSPEND USER ACCOUNT INFORMATION </b></asp:TableCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="user" runat="server" Text="Enter username:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:TextBox ID="suspendUser" runat="server" Width="200px"></asp:TextBox>  
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"   
            ControlToValidate="suspendUser" ErrorMessage="Enter username." ForeColor="Red"></asp:RequiredFieldValidator> 
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="clearbtn" runat="server" Text="Clear"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="suspendbtn" runat="server" Text="Suspend" onclick="Suspend_Click" />
                <asp:Label ID="Label2" runat="server"> </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>

