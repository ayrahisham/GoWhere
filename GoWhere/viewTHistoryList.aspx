<%@ Page Title="Tour Guide - View Tour History List" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewTHistoryList.aspx.cs" Inherits="viewTHistoryList" Debug ="true"%>

<asp:Content ID ="loginUser" ContentPlaceHolderID="loginUser" runat="server">
    Logged in: <b><u>Tour Guide</u></b>
</asp:Content> 

<asp:Content ID ="menubarViewTHistList" ContentPlaceHolderID="menubar" runat="server">
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

<asp:Content ID="viewTHistListContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="TGTHistListTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="3"> 
                <b> VIEW MY TOURS HISTORY LIST</b>
            </asp:TableCell>
        </asp:TableHeaderRow>
         <asp:TableRow>
             <asp:TableCell>
                <asp:Label ID="ID" runat="server" Text="ID"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="name" runat="server" Text="Name"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="totalTR" runat="server" Text="Total No. of Tourists"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <%--<asp:TableRow>
            <asp:TableCell> 
                <asp:HyperLink ID="tourID" runat="server" NavigateUrl="~/viewTHistory.aspx"> # </asp:HyperLink> 
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:TextBox ID="tourName" runat="server" Width="400px"></asp:TextBox>  
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:TextBox ID="tourtotalTR" runat="server" MaxLength="10" Width="90px"></asp:TextBox>  
            </asp:TableCell>
        </asp:TableRow>--%>
    </asp:Table>
</asp:Content>


