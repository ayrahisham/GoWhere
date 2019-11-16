<%@ Page Title="Tourist - Book Tour" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="createBooking.aspx.cs" Inherits="createBooking" Debug="True"%>

<asp:Content ID ="loginUser" ContentPlaceHolderID="loginUser" runat="server">
    Logged in as <b><u>Tourist </u></b>
</asp:Content>

<asp:Content ID ="menubarCreateBookingTR" ContentPlaceHolderID="menubar" runat="server">
    <ul>
       <li>
             <img src = "GoWhere/Images/back.png" height = "30" width = "30">
             <asp:HyperLink ID="backViewT" runat="server" NavigateUrl="~/viewTourListByDate.aspx"> BACK </asp:HyperLink>    
       </li>
        <li>
             <img src = "GoWhere/Images/home.jpg" height = "30" width = "30">
             <asp:HyperLink ID="backHomeTR" runat="server" NavigateUrl="~/homeTR.aspx"> HOME </asp:HyperLink>
       </li>
    </ul> 
</asp:Content>


<asp:Content ID="bookingContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="bookingTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="2"> 
                <b> TOUR DETAILS </b>
                <u><asp:Label ID="tourID" runat="server" Text="#"></asp:Label></u>
            </asp:TableCell>
        </asp:TableHeaderRow>
         <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="startdate" runat="server" Text="Start Date: "></asp:Label>
                 <asp:Label ID="tourStartDate" runat="server" placeholder ="mm/dd/yyyy" MaxLength="10" Width="90px"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="enddate" runat="server" Text="End Date: "></asp:Label>
                 <asp:Label ID="tourEndDate" runat="server" placeholder ="mm/dd/yyyy" MaxLength="10" Width="90px"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="duration" runat="server" Text="Duration of Days: "></asp:Label>
                 <asp:Label ID="tourDuration" runat="server" MaxLength="100" Width="90px"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                <asp:Label ID="status" runat="server" Text="Status of Tour: "></asp:Label>
                <asp:Label ID="tourStatus" runat="server" Width="90px"></asp:Label>    
           </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="name" runat="server" Text="Name of Tour: "></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:Label ID="tourName" runat="server" Width="400px"></asp:Label>  
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                 <asp:Label ID="desc" runat="server" Text="Description of Tour: "></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:Label ID="tourDesc" runat="server" TextMode="multiline" Columns="50" Rows="5"></asp:Label>  
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="category" runat="server" Text="Category of Tour: "></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                <asp:Label ID="tourCategory" runat="server"></asp:Label>  
           </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="citycountry" runat="server" Text="City/Country of Tour:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:Label ID="tourCityCountry" runat="server" Width="300px" placeholder="City, Country"></asp:Label>  
            </asp:TableCell>
        </asp:TableRow>
         <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="2"> 
                <b> BOOKING DETAILS </b>
            </asp:TableCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="Price_Desc_L" runat="server" Text="Price Per Pax (SGD):"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Price_L" runat="server" MaxLength="10" Width="90px"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="pax" runat="server" Text="Enter Pax:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="paxText" runat="server" MaxLength="10" Width="90px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="paxValidator" runat="server"   
            ControlToValidate="paxText" ErrorMessage="Requried" ForeColor="Red"></asp:RequiredFieldValidator> 
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan ="2">
                <asp:Button ID="bookTourBtn" runat="server" Text="Book Tour" OnClick="book_Click"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
