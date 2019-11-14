<%@ Page Title="Tour Guide - View Profile" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewTG.aspx.cs" Inherits="viewTG" Debug="true"%>

<asp:Content ID ="loginUser" ContentPlaceHolderID="loginUser" runat="server">
    Logged in as <b><u>Tour Guide</u></b>
</asp:Content> 

<asp:Content ID ="menubarViewTGProfile" ContentPlaceHolderID="menubar" runat="server">
    <ul>
        <li>
             <img src = "GoWhere/Images/back.png" height = "30" width = "30">
             <asp:HyperLink ID="backHomeTourG" runat="server" NavigateUrl="~/homeTG.aspx"> HOME </asp:HyperLink>
       </li>
       <li>
             <img src = "GoWhere/Images/upcoming.png" height = "30" width = "30">
             <asp:HyperLink ID="upcomingTour" runat="server" NavigateUrl="~/viewUpTourList.aspx"> VIEW UPCOMING TOURS </asp:HyperLink>    
       </li>
        <li>
             <img src = "GoWhere/Images/history.png" height = "30" width = "30">
             <asp:HyperLink ID="tourHistory" runat="server" NavigateUrl="~/viewTHistoryList.aspx"> VIEW TOUR HISTORY </asp:HyperLink>
       </li>
        <li>
             <img src = "GoWhere/Images/feedback.png" height = "30" width = "30">
             <asp:HyperLink ID="TGfeedback" runat="server" NavigateUrl="~/viewFB.aspx"> VIEW FEEDBACK </asp:HyperLink>
       </li>
         <li>
             <img src = "GoWhere/Images/ratings.png" height = "30" width = "30">
             <asp:HyperLink ID="TGRatings" runat="server" NavigateUrl="~/viewR.aspx"> VIEW RATINGS </asp:HyperLink>
       </li>
    </ul> 
</asp:Content>

<asp:Content ID="viewTGProfileContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="TGProfileTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="2"> 
                <b> VIEW MY PROFILE </b>
            </asp:TableCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
             <asp:TableCell>
                <asp:Label ID="fname" runat="server" Text="First name:"></asp:Label>
                 <asp:Label ID="TGFName" runat="server" Width="200px"></asp:Label>  
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lname" runat="server" Text="Last name:"></asp:Label>
                 <asp:Label ID="TGLName" runat="server" Width="200px"></asp:Label>  
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
             <asp:TableCell>
                <asp:Label ID="email" runat="server" Text="Email:"></asp:Label>
                 <asp:Label ID="TGEmail" runat="server" Width="200px"></asp:Label>  
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="country" runat="server" Text="Country:"></asp:Label>
                 <asp:Label ID="TGCountry" runat="server" Width="200px"></asp:Label>  
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Label ID="lab" runat="server"></asp:Label>
</asp:Content>

