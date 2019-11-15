<%@ Page Title="GoWhere - Create" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" Debug ="True"%>

<asp:Content ID="registerContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="registerTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="2"> 
                <b> CREATE USER ACCOUNT INFORMATION </b>
            </asp:TableCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="user" runat="server" Text="Username:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:TextBox ID="registerUser" runat="server" Width="200px" ToolTip="Enter Username"></asp:TextBox>
                <asp:RequiredFieldValidator ID="regUserValidator" runat="server"   
            ControlToValidate="registerUser" ErrorMessage="Enter username." ForeColor="Red"></asp:RequiredFieldValidator> 
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="pass" type="password" runat="server" Text="Password:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:TextBox ID="registerPwd" type="password" runat="server" Width="200px" ToolTip="Enter Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="regPwdValidator" runat="server"   
            ControlToValidate="registerPwd" ErrorMessage="Enter password." ForeColor="Red"></asp:RequiredFieldValidator> 
            </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="fName" type="fName" runat="server" Text="First name:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:TextBox ID="registerFName" runat="server" Width="200px" ToolTip="Enter first name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="regFNameValidator" runat="server"   
            ControlToValidate="registerFName" ErrorMessage="Enter first name." ForeColor="Red"></asp:RequiredFieldValidator> 
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lName" type="lName" runat="server" Text="Last name:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:TextBox ID="registerLName" runat="server" Width="200px" ToolTip="Enter last name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="regLNameValidator" runat="server"   
            ControlToValidate="registerLName" ErrorMessage="Enter last name." ForeColor="Red"></asp:RequiredFieldValidator> 
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="email"  runat="server" Text="Email:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:TextBox ID="registerEmail" runat="server" Width="200px" ToolTip="Enter Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="regEmailValidator" runat="server"   
            ControlToValidate="registerEmail" ErrorMessage="Enter email." ForeColor="Red"></asp:RequiredFieldValidator> 
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="country"  runat="server" Text="Country:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                 <asp:TextBox ID="registerCountry" runat="server" Width="200px" ToolTip="Enter Country"></asp:TextBox>  
                <asp:RequiredFieldValidator ID="regCountryValidator" runat="server"   
            ControlToValidate="registerCountry" ErrorMessage="Enter country." ForeColor="Red"></asp:RequiredFieldValidator> 
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="backbtn" runat="server" Text="Back" CausesValidation="false" PostBackUrl="~/default.aspx" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="registerbtn" runat="server" Text="Create" onClick="Register_Click" />
                <asp:Label ID="Label2" runat="server"> </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>

