<%@ Page Title="GoWhere - Login" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="GoWhere_login" Debug ="True"%>

<asp:Content ID="loginContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="loginTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="2"> 
                <b> LOGIN USER ACCOUNT INFORMATION </b>
            </asp:TableCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="username" runat="server" Text="Username:"></asp:Label>
            </asp:TableCell> 
        
            <asp:TableCell> 
                 <asp:TextBox ID="loginUser" runat="server" Width="200px" ToolTip="Enter Username"></asp:TextBox>  
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"   
            ControlToValidate="loginUser" ErrorMessage="Enter username." ForeColor="Red"></asp:RequiredFieldValidator> 
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="pword" runat="server" Text="Password:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:TextBox ID="loginPwd" type="password" runat="server" Width="200px" ToolTip="Enter Password"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"   
            ControlToValidate="loginPwd" ErrorMessage="Enter password." ForeColor="Red"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="Type" runat="server" Text="User Type:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                <asp:DropDownList ID="loginType" runat="server" ToolTip="Enter User Type">
                    <asp:ListItem Value ="TR">Tourist</asp:ListItem>
                    <asp:ListItem Value="TG">Tour Guide</asp:ListItem>
                    <asp:ListItem Value="UA">Administrator</asp:ListItem>
                </asp:DropDownList>  
           </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="backbtn" runat="server" Text="Back" CausesValidation="false" PostBackUrl="~/default.aspx" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="loginbtn" runat="server" Text="Login" onclick="Login_Click" />
                <asp:Label ID="Label2" runat="server"> </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>

