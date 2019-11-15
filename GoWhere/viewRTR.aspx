<%@ Page Title="Tourist - View Ratings" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewRTR.aspx.cs" Inherits="viewRTR" Debug ="true"%>

<asp:Content ID ="loginUser" ContentPlaceHolderID="loginUser" runat="server">
    Logged in: <b><u>Tourist</u></b>
</asp:Content> 

<asp:Content ID ="menubarViewRTR" ContentPlaceHolderID="menubar" runat="server">
    <ul>
       <li>
             <img src = "GoWhere/Images/back.png" height = "30" width = "30">
             <asp:HyperLink ID="backTGProfile" runat="server" NavigateUrl="~/viewTRProfile.aspx"> BACK </asp:HyperLink>    
       </li>
        <li>
             <img src = "GoWhere/Images/home.jpg" height = "30" width = "30">
             <asp:HyperLink ID="backHomeTourG" runat="server" NavigateUrl="~/homeTR.aspx"> HOME </asp:HyperLink>
       </li>
    </ul> 
</asp:Content>

<asp:Content ID="viewRTRContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="viewRTRTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="2"> 
                <b> VIEW MY RATINGS</b>
            </asp:TableCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="R2T" runat="server" Text="View Ratings To Tours" PostBackUrl="~/viewR2T.aspx" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="RFTG" runat="server" Text="View Ratings From Tour Guides" PostBackUrl="~/viewRFTG.aspx" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>



