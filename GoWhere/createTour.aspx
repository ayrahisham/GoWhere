<%@ Page Title="Tour Guide - Create Tour" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="createTour.aspx.cs" Inherits="createTour" Debug="True"%>

<asp:Content ID ="loginUser" ContentPlaceHolderID="loginUser" runat="server">
    Logged in: <b><u>Tour Guide</u></b>
</asp:Content> 

<asp:Content ID ="menubarCreateTour" ContentPlaceHolderID="menubar" runat="server">
    <ul>
        <li>
             <img src = "GoWhere/Images/back.png" height = "30" width = "30">
             <asp:HyperLink ID="backHomeTourG" runat="server" NavigateUrl="~/homeTG.aspx"> HOME </asp:HyperLink>
       </li>
       <li>
             <img src = "GoWhere/Images/update.jpg" height = "30" width = "30">
             <asp:HyperLink ID="updateTour" runat="server" NavigateUrl="~/updateTourList.aspx"> UPDATE TOUR </asp:HyperLink>    
       </li>
       <%-- <li>
             <img src = "GoWhere/Images/upload.png" height = "30" width = "30">
             <asp:HyperLink ID="uploadTour" runat="server" NavigateUrl="~/uploadTour.aspx"> UPLOAD IMAGES/VIDEOS </asp:HyperLink>
       </li>--%>
    </ul> 
</asp:Content>

<asp:Content ID="createTourContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="createTourTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="2"> 
                <b> CREATE TOUR INFORMATION </b>
            </asp:TableCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="startdate" runat="server" Text="Start Date:"></asp:Label>
                 <asp:TextBox ID="tourStartDate" runat="server" placeholder ="dd/mm/yyyy" MaxLength="10" Width="90px" 
                ToolTip="Enter Start Date of Tour"></asp:TextBox>
                <asp:RequiredFieldValidator ID="startDateValidator" runat="server"   
            ControlToValidate="tourStartDate" ValidationGroup="ValidateMe" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator> 
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="enddate" runat="server" Text="End Date:"></asp:Label>
                 <asp:TextBox ID="tourEndDate" runat="server" placeholder ="dd/mm/yyyy" MaxLength="10" Width="90px" 
                ToolTip="Enter End Date of Tour"></asp:TextBox>
                <asp:RequiredFieldValidator ID="enddateValidator" runat="server"   
            ControlToValidate="tourEndDate" ValidationGroup="ValidateMe" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator> 
            </asp:TableCell>
        </asp:TableRow>
        <%--<asp:TableRow>
            <%--<asp:TableCell>
                <asp:Label ID="duration" runat="server" Text="Duration in Days:"></asp:Label>
                 <asp:TextBox ID="tourDuration" runat="server" MaxLength="100" Width="90px" 
                ToolTip="Enter Duration of Tour"></asp:TextBox>
                <asp:RequiredFieldValidator ID="durationValidator" runat="server"   
            ControlToValidate="tourDuration" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator> 
            </asp:TableCell>
            <asp:TableCell> 
                <asp:Label ID="status" runat="server" Text="Status of Tour:"></asp:Label>
                  <asp:TextBox ID="tourStatus" runat="server" MaxLength="100" Width="90px" IsReadOnly="True">Upcoming</asp:TextBox>
               <%-- <asp:DropDownList ID="tourStatus" runat="server" ToolTip="Enter Status of Tour">
                    <asp:ListItem Selected="True" Value ="U">Upcoming</asp:ListItem>
                </asp:DropDownList>  
           </asp:TableCell>
        </asp:TableRow>--%>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="name" runat="server" Text="Name of Tour:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:TextBox ID="tourName" runat="server" Width="400px" ToolTip="Enter Name of Tour"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="tournameValidator" runat="server"   
            ControlToValidate="tourName" ValidationGroup="ValidateMe" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator> 
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                 <asp:Label ID="desc" runat="server" Text="Description of Tour:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:TextBox ID="tourDesc" runat="server" TextMode="multiline" Columns="50" Rows="5" ToolTip="Enter Description of Tour"></asp:TextBox>  
                 <asp:RequiredFieldValidator ID="tourDescValidator" runat="server"   
            ControlToValidate="tourDesc" ValidationGroup="ValidateMe" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator> 
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="price" runat="server" Text="Price per pax: $"></asp:Label>
                 <asp:TextBox ID="tourPrice" runat="server" Width="90px" ToolTip="Enter Price of Tour"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="priceValidator" runat="server"   
            ControlToValidate="tourPrice" ValidationGroup="ValidateMe" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator> 
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="category" runat="server" Text="Category of Tour:"></asp:Label>
                <asp:TextBox ID="tourCat" runat="server" Width="90px" ToolTip="Enter Category of Tour"></asp:TextBox>
                <asp:RequiredFieldValidator ID="categoryValidator" runat="server"   
            ControlToValidate="tourCat" ValidationGroup="ValidateMe" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator> 
           </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="citycountry" runat="server" Text="City/Country of Tour:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:TextBox ID="tourCityCountry" runat="server" Width="200px" placeholder="City, Country" ToolTip="Enter City/Country of Tour"></asp:TextBox>  
                 <asp:RequiredFieldValidator ID="countryValidator" runat="server"   
            ControlToValidate="tourCityCountry" ValidationGroup="ValidateMe" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator> 
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="clearbtn" runat="server" Text="Clear"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="createbtn" runat="server" CausesValidation="False" Text="Create" onClick="submitTour"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>

