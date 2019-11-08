<%@ Page Title="Tour Guide - Upload Images/Videos For Tour" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="uploadTour.aspx.cs" Inherits="uploadTour" Debug="true"%>

<asp:Content ID ="loginUser" ContentPlaceHolderID="loginUser" runat="server">
    Logged in: <b><u>Tour Guide</u></b>
</asp:Content> 

<asp:Content ID ="menubarUploadTour" ContentPlaceHolderID="menubar" runat="server">
    <ul>
       <li>
             <img src = "GoWhere/Images/back.png" height = "30" width = "30">
             <asp:HyperLink ID="backCreateTour" runat="server" NavigateUrl="~/createTour.aspx"> BACK </asp:HyperLink>    
       </li>
        <li>
             <img src = "GoWhere/Images/home.jpg" height = "30" width = "30">
             <asp:HyperLink ID="backHomeTourG" runat="server" NavigateUrl="~/homeTG.aspx"> HOME </asp:HyperLink>
       </li>
    </ul> 
</asp:Content>

<asp:Content ID="uploadTourContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="uploadTourTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="2"> 
                <b> UPLOAD IMAGES/VIDEOS FOR TOUR </b>
            </asp:TableCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="ID" runat="server" Text="Tour ID:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:TextBox ID="tourID" runat="server" MaxLength="10" Width="90px" 
                ToolTip="Enter ID of Tour"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
             <asp:TableCell>
                <asp:Label ID="upload" runat="server" Text="Select a file to upload:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:FileUpload id="tourUpload" runat="server" ToolTip="Select File to Upload"></asp:FileUpload>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="clearbtn" runat="server" Text="Clear"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="uploadbtn" runat="server" Text="Upload" PostBackUrl="~/createTour.aspx"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>

