<%@ Page Title="Tour Guide - View List of Tourists" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewListTR.aspx.cs" Inherits="viewListTR" Debug =" true"%>

<asp:Content ID ="loginUser" ContentPlaceHolderID="loginUser" runat="server">
    Logged in: <b><u>Tour Guide</u></b>
</asp:Content> 

<asp:Content ID ="menubarViewListTR" ContentPlaceHolderID="menubar" runat="server">
    <ul>
       <li>
             <img src = "GoWhere/Images/back.png" height = "30" width = "30">
             <asp:HyperLink ID="backTGProfile" runat="server" NavigateUrl="~/viewTHistory.aspx"> BACK </asp:HyperLink>    
       </li>
        <li>
             <img src = "GoWhere/Images/home.jpg" height = "30" width = "30">
             <asp:HyperLink ID="backHomeTourG" runat="server" NavigateUrl="~/homeTG.aspx"> HOME </asp:HyperLink>
       </li>
    </ul> 
</asp:Content>

<asp:Content ID="viewListTRContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="viewListTRTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="3"> 
                <b> VIEW LIST OF TOURISTS OF TOUR ID </b>
                <asp:Label ID="tourID" runat="server" Text="#" NavigateUrl=""></asp:Label>
            </asp:TableCell>
        </asp:TableHeaderRow>
         <asp:TableRow>
             <asp:TableCell>
                <asp:Label ID="ID" runat="server" Text="ID"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="fname" runat="server" Text="Firstname"></asp:Label>
            </asp:TableCell>
             <asp:TableCell>
                <asp:Label ID="lname" runat="server" Text="Lastname"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <%--<asp:TableRow>
            <asp:TableCell> 
                <asp:HyperLink ID="TRID" runat="server" NavigateUrl="~/viewTRofT.aspx"> # </asp:HyperLink> 
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:TextBox ID="TRfname" runat="server" Width="200px"></asp:TextBox>  
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:TextBox ID="TRlname" runat="server" Width ="200px"></asp:TextBox>  
            </asp:TableCell>
        </asp:TableRow>--%>
    </asp:Table>
    <asp:Label ID="testing1" runat="server" />
     <asp:Label ID="testing2" runat="server" />
     <asp:Label ID="testing3" runat="server" />
</asp:Content>
