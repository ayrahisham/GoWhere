<%@ Page Title="Tour Guide - View Tourist of Tour" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewTRofT.aspx.cs" Inherits="viewTRofT" %>

<asp:Content ID ="loginUser" ContentPlaceHolderID="loginUser" runat="server">
    Logged in: <b><u>Tour Guide</u></b>
</asp:Content> 

<asp:Content ID ="menubarViewTRofT" ContentPlaceHolderID="menubar" runat="server">
    <ul>
       <li>
             <img src = "GoWhere/Images/back.png" height = "30" width = "30">
             <asp:HyperLink ID="backTGProfile" runat="server" NavigateUrl="~/viewListTR.aspx"> BACK </asp:HyperLink>    
       </li>
        <li>
             <img src = "GoWhere/Images/home.jpg" height = "30" width = "30">
             <asp:HyperLink ID="backHomeTourG" runat="server" NavigateUrl="~/homeTG.aspx"> HOME </asp:HyperLink>
       </li>
    </ul> 
</asp:Content>

<asp:Content ID="viewTRofTContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="viewTRofTTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="2"> 
                <b> VIEW TOURIST ID </b> 
                <u><asp:Label ID="TRID" runat="server" Text="#"></asp:Label></u>
                <b> OF TOUR ID </b>
                <u><asp:Label ID="tourID" runat="server" Text="#"></asp:Label></u>
            </asp:TableCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="ID" runat="server" Text="Booking ID:"></asp:Label>
                 <asp:TextBox ID="BID" runat="server" MaxLength="10" Width="90px"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell></asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="fname" runat="server" Text="Firstname:"></asp:Label>
                 <asp:TextBox ID="TRfname" runat="server" Width="200px"></asp:TextBox>  
            </asp:TableCell>
             <asp:TableCell>
                <asp:Label ID="lname" runat="server" Text="Lastname:"></asp:Label>
                  <asp:TextBox ID="TRlname" runat="server" Width="200px"></asp:TextBox>  
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
             <asp:TableCell>
                <asp:Label ID="email" runat="server" Text="Email:"></asp:Label>
                  <asp:TextBox ID="TRemail" runat="server" Width="200px"></asp:TextBox>  
            </asp:TableCell>
             <asp:TableCell>
                <asp:Label ID="country" runat="server" Text="Country:"></asp:Label>
                  <asp:TextBox ID="TRcountry" runat="server" Width="200px"></asp:TextBox>  
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Button ID="giveFB2TR" runat="server" Text="Give Feedback" PostBackUrl="~/giveFB2TR.aspx" />
            </asp:TableCell>
            <%--<asp:TableCell>
                <asp:Button ID="giveR2TR" runat="server" Text="Give Ratings" PostBackUrl="~/giveR2TR.aspx" />
            </asp:TableCell>--%>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
