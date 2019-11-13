<%@ Page Title="GoWhere" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" Debug =" True"%>

<asp:Content ID="default" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="loginTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="2"> 
                <b> WELCOME TO GoWhere PORTAL</b>
            </asp:TableCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan ="2">
                What would you like to do?
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                 <asp:Button ID="registerbtn" runat="server" Text="Register" PostBackUrl="~/register.aspx" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="loginbtn" runat="server" Text="Login" PostBackUrl="~/login.aspx" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>

