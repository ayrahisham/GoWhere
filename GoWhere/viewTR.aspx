<%@ Page Title="Tour Guide - View Tourist" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewTR.aspx.cs" Inherits="viewTR" Debug="true" %>

<asp:Content ID ="loginUser" ContentPlaceHolderID="loginUser" runat="server">
    Logged in as <b><u>Tour Guide</u></b>
</asp:Content> 

<asp:Content ID ="menubarViewTR" ContentPlaceHolderID="menubar" runat="server">
    <ul>
       <li>
             <img src = "GoWhere/Images/back.png" height = "30" width = "30">
             <asp:HyperLink ID="backUpTour" runat="server" NavigateUrl="~/viewTRList.aspx"> BACK </asp:HyperLink>    
       </li>
        <li>
             <img src = "GoWhere/Images/home.jpg" height = "30" width = "30">
             <asp:HyperLink ID="backHomeTourG" runat="server" NavigateUrl="~/homeTG.aspx"> HOME </asp:HyperLink>
       </li>
    </ul> 
</asp:Content>

<asp:Content ID="viewTRContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="viewTRTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="2"> 
                <b> VIEW MY TOURIST FOR TOUR ID </b>
                <asp:HyperLink ID="TID" runat="server" NavigateUrl="~/viewUpTour.aspx"></asp:HyperLink>
            </asp:TableCell>
        </asp:TableHeaderRow>
         <asp:TableRow>
             <asp:TableCell>
                <asp:Label ID="ID" runat="server" Text="ID"></asp:Label>
                <asp:TextBox ID="TRID" runat="server" MaxLength="10" Width="90px"></asp:TextBox> 
            </asp:TableCell>
             <asp:TableCell></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="fname" runat="server" Text="Firstname"></asp:Label>
                <asp:TextBox ID="TRfname" runat="server" Width="200px"></asp:TextBox>  
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lname" runat="server" Text="Lastname"></asp:Label>
                <asp:TextBox ID="TRlname" runat="server" Width="200px"></asp:TextBox> 
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="email" runat="server" Text="Email"></asp:Label>
                 <asp:TextBox ID="TRemail" runat="server" Width="200px"></asp:TextBox> 
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="country" runat="server" Text="Country"></asp:Label>
                <asp:TextBox ID="TRcountry" runat="server" Width="100px"></asp:TextBox> 
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="5">
                <asp:Button ID="connectTR" runat="server" Text="Connect with Tourist" PostBackUrl="~/connectTR.aspx" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>


