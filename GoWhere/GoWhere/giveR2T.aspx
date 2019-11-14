<%@ Page Title="Tourist - Give Ratings to Tour" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="giveR2T.aspx.cs" Inherits="giveR2T" Debug ="true"%>

<asp:Content ID ="loginUser" ContentPlaceHolderID="loginUser" runat="server">
    Logged in as <b><u>Tourist</u></b>
</asp:Content> 

<asp:Content ID ="menubargiveR2T" ContentPlaceHolderID="menubar" runat="server">
    <ul>
       <li>
             <img src = "GoWhere/Images/back.png" height = "30" width = "30">
             <asp:HyperLink ID="backTGProfile" runat="server" NavigateUrl="~/viewTHistoryTR.aspx"> BACK </asp:HyperLink>    
       </li>
        <li>
             <img src = "GoWhere/Images/home.jpg" height = "30" width = "30">
             <asp:HyperLink ID="backHomeTourG" runat="server" NavigateUrl="~/homeTR.aspx"> HOME </asp:HyperLink>
       </li>
    </ul> 
</asp:Content>

<asp:Content ID="giveR2TContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="giveR2TTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="2"> 
                <b> NEW RATINGS TO TOUR ID </b> 
                <u><asp:Label ID="TID" runat="server" Text="#"></asp:Label></u>
                <b> OF TOUR GUIDE ID </b>
                <u><asp:Label ID="TGID" runat="server" Text="#"></asp:Label></u>
            </asp:TableCell>
        </asp:TableHeaderRow>
         <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="ID" runat="server" Text="Booking ID:"></asp:Label>
            </asp:TableCell>
             <asp:TableCell>
                 <asp:TextBox ID="BID" runat="server" MaxLength="10" Width="90px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                 <asp:Label ID="ratings" runat="server" Text="Ratings:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:RadioButton id="rating1" Text="*" GroupName="ratingsRadio" runat="server"/>
                 <asp:RadioButton id="rating2" Text="**" GroupName="ratingsRadio" runat="server"/>
                <asp:RadioButton id="rating3" Text="***" GroupName="ratingsRadio" runat="server"/>
                <asp:RadioButton id="rating4" Text="****" Checked="True" GroupName="ratingsRadio" runat="server"/>
                <asp:RadioButton id="rating5" Text="*****" GroupName="ratingsRadio" runat="server"/>
            </asp:TableCell>
        </asp:TableRow>
       <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="clearbtn" runat="server" Text="Clear"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="createbtn" runat="server" Text="Submit" PostBackUrl="~/viewTHistoryTR.aspx" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>




