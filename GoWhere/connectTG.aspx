<%@ Page Title="Tourist - Connect With Tour Guide" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="connectTG.aspx.cs" Inherits="connectTG" Debug ="true" %>

<asp:Content ID ="loginUser" ContentPlaceHolderID="loginUser" runat="server">
    Logged in: <b><u>Tourist</u></b>
</asp:Content> 

<asp:Content ID ="menubarConnectTG" ContentPlaceHolderID="menubar" runat="server">
    <ul>
       <li>
             <img src = "GoWhere/Images/back.png" height = "30" width = "30">
             <asp:HyperLink ID="backUpTour" runat="server" NavigateUrl="~/viewUpTourTR.aspx"> BACK </asp:HyperLink>    
       </li>
        <li>
             <img src = "GoWhere/Images/home.jpg" height = "30" width = "30">
             <asp:HyperLink ID="backHomeTourG" runat="server" NavigateUrl="~/homeTR.aspx"> HOME </asp:HyperLink>
       </li>
    </ul> 
</asp:Content>

<asp:Content ID="connectTGContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="connectTGTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="2"> 
                <b> CONNECT WITH MY TOUR GUIDE </b>
            </asp:TableCell>
        </asp:TableHeaderRow>
        <asp:TableHeaderRow>
            <asp:TableCell> 
                <b> MY TOUR GUIDE PROFILE </b>
            </asp:TableCell>
            <asp:TableCell></asp:TableCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="fname" runat="server" Text="Firstname"></asp:Label>
                <asp:TextBox ID="TGfname" runat="server" Width="200px"></asp:TextBox>  
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lname" runat="server" Text="Lastname"></asp:Label>
                <asp:TextBox ID="TGlname" runat="server" Width="200px"></asp:TextBox> 
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="email" runat="server" Text="Email"></asp:Label>
                 <asp:TextBox ID="TGemail" runat="server" Width="100px"></asp:TextBox> 
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="country" runat="server" Text="Country"></asp:Label>
                <asp:TextBox ID="TGcountry" runat="server" Width="100px"></asp:TextBox> 
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableHeaderRow>
            <asp:TableCell> 
                <b> MESSAGE FORM </b>
            </asp:TableCell>
            <asp:TableCell></asp:TableCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="from" runat="server" Text="Sender Tourist ID: "></asp:Label>
                <asp:TextBox ID="TRID" runat="server" MaxLength="10" Width="90px"></asp:TextBox> 
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="to" runat="server" Text="Receiver Tour Guide ID:"></asp:Label>
                <asp:TextBox ID="TGID" runat="server" MaxLength="10" Width="90px"></asp:TextBox>  
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
                 <asp:Label ID="Label1" runat="server" Text="Message:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:Label ID="reply" runat="server" Columns="50" Rows="5" ToolTip="Enter message"></asp:Label>  
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
                <asp:Button ID="sendbtn" runat="server" Text="Send" OnClick ="submitMessage"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>


