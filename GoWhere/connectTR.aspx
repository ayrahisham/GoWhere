<%@ Page Title="Tour Guide - Connect With Tourist" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="connectTR.aspx.cs" Inherits="connectTR" Debug ="true" %>

<asp:Content ID ="loginUser" ContentPlaceHolderID="loginUser" runat="server">
    Logged in: <b><u>Tour Guide</u></b>
</asp:Content> 

<asp:Content ID ="menubarConnectTR" ContentPlaceHolderID="menubar" runat="server">
    <ul>
       <li>
             <img src = "GoWhere/Images/back.png" height = "30" width = "30">
             <asp:HyperLink ID="backUpTour" runat="server" NavigateUrl="~/viewTR.aspx"> BACK </asp:HyperLink>    
       </li>
        <li>
             <img src = "GoWhere/Images/home.jpg" height = "30" width = "30">
             <asp:HyperLink ID="backHomeTourG" runat="server" NavigateUrl="~/homeTG.aspx"> HOME </asp:HyperLink>
       </li>
    </ul> 
</asp:Content>

<asp:Content ID="connectTRContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="connectTRTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="2"> 
                <b> CONNECT WITH MY TOURIST </b>
            </asp:TableCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="from" runat="server" Text="Sender Tour Guide ID: "></asp:Label>
                <asp:TextBox ID="TGID" runat="server" MaxLength="10" Width="90px"></asp:TextBox> 
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="to" runat="server" Text="Receiver Tourist ID:"></asp:Label>
                <asp:TextBox ID="TRID" runat="server" MaxLength="10" Width="90px"></asp:TextBox>  
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
             <asp:TableCell>
                <asp:Label ID="tID" runat="server" Text="Tour ID:"></asp:Label>
                 <asp:TextBox ID="tourID" runat="server" MaxLength="10" Width="90px"></asp:TextBox>  
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="bID" runat="server" Text="Booking ID:"></asp:Label>
                 <asp:TextBox ID="bookingID" runat="server" MaxLength="10" Width="90px"></asp:TextBox>  
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
             <asp:TableCell>
                <asp:Label ID="time" runat="server" Text="Time:"></asp:Label>
                 <asp:TextBox ID="TGTime" runat="server" Width="100px"></asp:TextBox>  
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="date" runat="server" Text="Date:"></asp:Label>
                 <asp:TextBox ID="TGDate" runat="server" placeholder ="mm/dd/yyyy" MaxLength="10" Width="90px"></asp:TextBox>  
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                 <asp:Label ID="msg" runat="server" Text="Message:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:TextBox ID="TGmsg" runat="server" TextMode="multiline" Columns="50" Rows="5" ToolTip="Enter Description of Tour"></asp:TextBox>  
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="clearbtn" runat="server" Text="Clear"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="sendbtn" runat="server" Text="Send" PostBackUrl="~/viewTRList.aspx" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>


