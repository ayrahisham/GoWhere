<%@ Page Title="Tourist - Give Feedback to Tour" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="giveFB2T.aspx.cs" Inherits="giveFB2T" Debug ="true"%>

<asp:Content ID ="loginUser" ContentPlaceHolderID="loginUser" runat="server">
    Logged in: <b><u>Tourist</u></b>
</asp:Content> 

<asp:Content ID ="menubargiveFB2T" ContentPlaceHolderID="menubar" runat="server">
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

<asp:Content ID="giveFB2TContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="giveFB2TTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="2"> 
                <b> NEW FEEDBACK TO TOUR ID </b> 
                <u><asp:Label ID="TID_label" runat="server"></asp:Label></u>
                <b> by TOUR GUIDE ID </b>
                <u><asp:Label ID="TGID_label" runat="server"></asp:Label></u>
            </asp:TableCell>
        </asp:TableHeaderRow>
         <asp:TableRow>
             <asp:TableCell>
                <asp:Label ID="Label" runat="server" Text="Booking ID:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="ID" runat="server"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                 <asp:Label ID="desc" runat="server" Text="Description of Feedback:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:TextBox ID="TRFB" TextMode="multiline" Columns="50" Rows="5" runat="server" ToolTip="Enter Description of Feedback"></asp:TextBox>  
            </asp:TableCell>
        </asp:TableRow>
       <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="clearbtn" runat="server" Text="Clear"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="createbtn" runat="server" Text="Submit" OnClick ="submit_fb"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>


