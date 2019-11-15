<%@ Page Title="Tourist - View Upcoming Tour" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewUpTourTR.aspx.cs" Inherits="viewUpTourTR" Debug ="true"%>

<asp:Content ID ="loginUser" ContentPlaceHolderID="loginUser" runat="server">
    Logged in: <b><u>Tourist </u></b>
</asp:Content> 

<asp:Content ID ="menubarViewUpTourTR" ContentPlaceHolderID="menubar" runat="server">
    <ul>
       <li>
             <img src = "GoWhere/Images/back.png" height = "30" width = "30">
             <asp:HyperLink ID="backTGProfile" runat="server" NavigateUrl="~/viewUpTourListTR.aspx"> BACK </asp:HyperLink>    
       </li>
        <li>
             <img src = "GoWhere/Images/home.jpg" height = "30" width = "30">
             <asp:HyperLink ID="backHomeTourG" runat="server" NavigateUrl="~/homeTR.aspx"> HOME </asp:HyperLink>
       </li>
    </ul> 
</asp:Content>

<asp:Content ID="viewUpTourTRContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="TRUpTourTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="2"> 
                <b> VIEW MY UPCOMING TOUR </b>
                <u><asp:Label ID="tourID" runat="server"></asp:Label></u>
            </asp:TableCell>
        </asp:TableHeaderRow>
        <asp:TableHeaderRow>
            <asp:TableCell> <b><i> BOOKING DETAILS </i></b></asp:TableCell>
            <asp:TableCell></asp:TableCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="ID" runat="server" Text="Booking ID:"></asp:Label>
                 <asp:TextBox ID="BID" runat="server" MaxLength="10" Width="90px"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="date" runat="server" Text="Booking Date:"></asp:Label>
                 <asp:TextBox ID="Bdate" runat="server" MaxLength="10" Width="90px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="tID" runat="server" Text="Tourist ID:"></asp:Label>
                 <asp:TextBox ID="TRID" runat="server" MaxLength="10" Width="90px"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="email" runat="server" Text="Email:"></asp:Label>
                 <asp:TextBox ID="TRemail" runat="server" MaxLength="10" Width="90px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="pax" runat="server" Text="No. of Pax:"></asp:Label>
                <asp:TextBox ID="noOfPax" runat="server" MaxLength="100" Width="90px"></asp:TextBox>
            </asp:TableCell>
              <asp:TableCell>
                <asp:Label ID="totalprice" runat="server" Text="Total Price: $"></asp:Label>
                 <asp:TextBox ID="ttltourPrice" runat="server" Width="90px"></asp:TextBox>  
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableHeaderRow>
            <asp:TableCell> <b><i> TOUR DETAILS </i></b></asp:TableCell>
            <asp:TableCell></asp:TableCell>
        </asp:TableHeaderRow>
         <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="startdate" runat="server" Text="Start Date:"></asp:Label>
                 <asp:TextBox ID="tourStartDate" runat="server" placeholder ="mm/dd/yyyy" MaxLength="10" Width="90px"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="enddate" runat="server" Text="End Date:"></asp:Label>
                 <asp:TextBox ID="tourEndDate" runat="server" placeholder ="mm/dd/yyyy" MaxLength="10" Width="90px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
            </asp:TableCell>
            <asp:TableCell> 
                <asp:Label ID="status" runat="server" Text="Status of Tour:"></asp:Label>
                <asp:TextBox ID="tourStatus" runat="server" Width="90px"></asp:TextBox>    
           </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="name" runat="server" Text="Name of Tour:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:TextBox ID="tourName" runat="server" Width="400px"></asp:TextBox>  
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                 <asp:Label ID="desc" runat="server" Text="Description of Tour:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:TextBox ID="tourDesc" runat="server" TextMode="multiline" Columns="50" Rows="5"></asp:TextBox>  
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="category" runat="server" Text="Type of Tour:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
               <asp:TextBox ID="category_field" runat="server" Width="200px"></asp:TextBox> 
           </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="citycountry" runat="server" Text="City/Country of Tour:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:TextBox ID="tourCityCountry" runat="server" Width="300px" placeholder="City, Country"></asp:TextBox>  
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="cancel" runat="server" Text="Cancel Booking" OnClick = "cancel_book"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="connectTG" runat="server" Text="Connect with Tour Guide" PostBackUrl="~/connectTG.aspx" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>

