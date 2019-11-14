<%@ Page Title="Tour Guide - Home" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="homeTG.aspx.cs" Inherits="homeTG" Debug ="True"%>

<asp:Content ID ="loginUser" ContentPlaceHolderID="loginUser" runat="server">
    Logged in: <b><u>Tour Guide</u></b>
    <br />
    <img src = "GoWhere/Images/switch.png" height = "30" width = "30">
    <asp:HyperLink ID="switch" runat="server" NavigateUrl="~/homeTR.aspx"> SWITCH ACCOUNT </asp:HyperLink>
</asp:Content> 

<asp:Content ID ="menubarTG" ContentPlaceHolderID="menubar" runat="server">
    <ul>
        <li>
             <img src = "GoWhere/Images/home.jpg" height = "30" width = "30">
             <asp:HyperLink ID="homeTourG" runat="server" NavigateUrl="~/homeTG.aspx"> HOME </asp:HyperLink>
       </li>
        <li>
             <img src = "GoWhere/Images/viewProfile.jpg" height = "30" width = "30">
             <asp:HyperLink ID="viewProfileTG" runat="server" NavigateUrl="~/viewTG.aspx"> VIEW PROFILE</asp:HyperLink>
       </li>
       <li>
             <img src = "GoWhere/Images/create.jpg" height = "30" width = "30">
             <asp:HyperLink ID="createTour" runat="server" NavigateUrl="~/createTour.aspx"> CREATE TOUR </asp:HyperLink>    
       </li>
       <li>
             <img src = "GoWhere/Images/logout.png" height = "30" width = "30">
             <asp:HyperLink ID="logout" runat="server" NavigateUrl="~/default.aspx"> LOGOUT </asp:HyperLink>
       </li>
    </ul> 
</asp:Content>

<asp:Content ID="homeContent" ContentPlaceHolderID="content" Runat="Server">
     <table>
        <tr>
            <th colspan = 2 id = "weekly"><b>WEEKLY POPULAR TOURS</b></th>
        </tr>
        <tr>
            <td>
                <img src = "GoWhere/Images/beijing.jpg" alt = "Beijing, China">
                <p>
                    <b>Beijing, China</b>: The Ancient Chinese Architecture
                     The Great Wall of China, one of the Seven Wonders of the Ancient World, 
                     is a short tour bus ride away and a must-see for any visitor. 
                     The fabulously wealthy dynasties that ruled China centuries ago left 
                     behind palaces such as the Forbidden City.
                </p>
            </td>
        </tr>
        <tr>
            <td>
            <img src = "GoWhere/Images/germany.jpg" alt = "Berlin, Germany">
                <p>
                    <b>Berlin, Germany</b>: It is known as the former capital of the 
                    German Democratic Republic and the rebuilding of the Berlin Schloss 
                    required the dismantling of the gaudy Palast der Republik, the capitol 
                    of the GDR. It is known as the front line of the Cold War.
                </p>
            </td>
       </tr>
       <tr>
            <td>
            <img src = "GoWhere/Images/czech.jpg" alt = "Prague, Czech Republic">
                <p>
                   <b>Prague, Czech Republic</b>: Within the castle walls are a number of 
                    Prague's most popular tourist sites, including St. Vitus Cathedral, St. 
                    George's Basilica, the Powder Tower, the Old Royal Palace, and the 
                    Golden Lane. Prague castle is known for it's best.
                </p>
           </td>
      </tr>
      <tr>
          <td>
          <img src = "GoWhere/Images/russia.jpg" alt = "St. Petersburg, Russia">
                <p>
                    <b>St. Petersburg, Russia</b>: St. Petersburg is a mecca of cultural, 
                    historical, and architectural landmarks. Founded by Tsar Peter I (the 
                    Great) as Russia's “window on Europe,” it bears the unofficial status 
                    of Russia's cultural capital and most European city, a distinction that
                    it strives to retain in its perennial competition with Moscow.
               </p>
         </td>
     </tr>
    </table>
</asp:Content>
