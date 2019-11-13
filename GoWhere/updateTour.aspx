<%@ Page Title="Tour Guide - Update Tour" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="updateTour.aspx.cs" Inherits="updateTour" Debug="true"%>

<asp:Content ID ="loginUser" ContentPlaceHolderID="loginUser" runat="server">
    Logged in: <b><u>Tour Guide</u></b>
</asp:Content> 

<asp:Content ID ="menubarUpdateTour" ContentPlaceHolderID="menubar" runat="server">
    <ul>
       <li>
             <img src = "GoWhere/Images/back.png" height = "30" width = "30">
             <asp:HyperLink ID="backCreateTour" runat="server" NavigateUrl="~/updateTourList.aspx"> BACK </asp:HyperLink>    
       </li>
        <li>
             <img src = "GoWhere/Images/home.jpg" height = "30" width = "30">
             <asp:HyperLink ID="backHomeTourG" runat="server" NavigateUrl="~/homeTG.aspx"> HOME </asp:HyperLink>
       </li>
    </ul> 
</asp:Content>

<asp:Content ID="updateTourContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="updateTourTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="2"> 
                <b> UPDATE TOUR INFORMATION </b>
                <asp:Label ID="tourID" runat="server" Text="#"></asp:Label>
            </asp:TableCell>
        </asp:TableHeaderRow>
         <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="startdate" runat="server" Text="Start Date:"></asp:Label>
                 <asp:TextBox ID="tourStartDate" runat="server" placeholder ="mm/dd/yyyy" MaxLength="10" Width="90px" 
                ToolTip="Enter Start Date of Tour"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="enddate" runat="server" Text="End Date:"></asp:Label>
                 <asp:TextBox ID="tourEndDate" runat="server" placeholder ="mm/dd/yyyy" MaxLength="10" Width="90px" 
                ToolTip="Enter End Date of Tour"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
              <asp:TableCell ColumnSpan="2">
                <asp:Label ID="status" runat="server" Text="Tour Status"></asp:Label>
                <asp:TextBox ID="tourStatus" runat="server" Width="90px" ToolTip="Enter status of Tour"></asp:TextBox>                   
            </asp:TableCell>
           <%-- <asp:TableCell>
           </asp:TableCell>--%>
             <%--<asp:TableCell> 
                <asp:DropDownList ID="tourStatusDropdown" runat="server" ToolTip="Enter Status">
                    <asp:ListItem Value ="Upcoming">Upcoming</asp:ListItem>
                    <asp:ListItem Value="Completed">Completed</asp:ListItem>
                </asp:DropDownList>  
           </asp:TableCell>--%>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="name" runat="server" Text="Name of Tour:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:TextBox ID="tourName" OnTextChanged="tourName_TextChanged" runat="server" Width="400px" ToolTip="Enter Name of Tour"></asp:TextBox>  
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                 <asp:Label ID="desc" runat="server" Text="Description of Tour:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:TextBox ID="tourDesc" runat="server" TextMode="multiline" Columns="50" Rows="5" ToolTip="Enter Description of Tour"></asp:TextBox>  
            </asp:TableCell>
        </asp:TableRow>
        
        <asp:TableRow>
              <asp:TableCell>
                <asp:Label ID="price" runat="server" Text="Price per pax: $"></asp:Label>
                 <asp:TextBox ID="tourPrice" runat="server" Width="90px" ToolTip="Enter Price of Tour"></asp:TextBox>  
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="category" runat="server" Text="Category of Tour:"></asp:Label>
                 <asp:TextBox ID="tourCat" runat="server" Width="90px" ToolTip="Enter category of Tour"></asp:TextBox>                   
           </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="citycountry" runat="server" Text="City/Country of Tour:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:TextBox ID="tourCityCountry" runat="server" Width="300px" placeholder="City, Country" ToolTip="Enter City/Country of Tour"></asp:TextBox>  
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="clearbtn" runat="server" Text="Clear"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="createbtn" runat="server" Text="Update" CausesValidation="False" onClick="updateTourInfo"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Label ID="testing" runat="server" />
</asp:Content>

