<%@ Page Title="Tour Guide - Give Feedback to Tourist" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="giveFB2TR.aspx.cs" Inherits="giveFB2TR" Debug ="true"%>

<asp:Content ID ="loginUser" ContentPlaceHolderID="loginUser" runat="server">
    Logged in: <b><u>Tour Guide</u></b>
</asp:Content> 

<asp:Content ID ="menubargiveFB2TR" ContentPlaceHolderID="menubar" runat="server">
    <ul>
       <li>
             <img src = "GoWhere/Images/back.png" height = "30" width = "30">
             <asp:HyperLink ID="backTGProfile" runat="server" NavigateUrl="~/viewTRofT.aspx"> BACK </asp:HyperLink>    
       </li>
        <li>
             <img src = "GoWhere/Images/home.jpg" height = "30" width = "30">
             <asp:HyperLink ID="backHomeTourG" runat="server" NavigateUrl="~/homeTG.aspx"> HOME </asp:HyperLink>
       </li>
    </ul> 
</asp:Content>

<asp:Content ID="giveFB2TRContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="giveFB2TRTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="2"> 
                <b> NEW FEEDBACK TO TOURIST ID </b> 
                <u><asp:Label ID="TRID" runat="server" Text="#"></asp:Label></u>
                <b> OF TOUR ID </b>
                <u><asp:Label ID="tourID" runat="server" Text="#"></asp:Label></u>
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
                <%--<asp:RadioButtonList  ColumnSpan="5" ID="rdoPriceRange" runat="server" RepeatLayout="Flow">
                  
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                </asp:RadioButtonList>--%>
                 <asp:RadioButton id="rating1" Text="1" GroupName="ratingsRadio" runat="server"/>
                 <asp:RadioButton id="rating2" Text="2" GroupName="ratingsRadio" runat="server"/>
                <asp:RadioButton id="rating3" Text="3" GroupName="ratingsRadio" runat="server"/>
                <asp:RadioButton id="rating4" Text="4" Checked="True" GroupName="ratingsRadio" runat="server"/>
                <asp:RadioButton id="rating5" Text="5" GroupName="ratingsRadio" runat="server"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                 <asp:Label ID="desc" runat="server" Text="Description of Feedback:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:TextBox ID="TRFB" runat="server" TextMode="multiline" Columns="50" Rows="5" ToolTip="Enter Description of Feedback"></asp:TextBox>  
            </asp:TableCell>
        </asp:TableRow>
       <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="clearbtn" runat="server" Text="Clear"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="createbtn" runat="server" Text="Submit" onClick="submitFeedback"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
