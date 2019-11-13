<%@ Page Title="GoWhere - regSubmit" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="regSubmit.aspx.cs" Inherits="GoWhere_regSubmit" Debug ="True"%>

<asp:Content ID="regSubmitContent" ContentPlaceHolderID="content" Runat="Server">
    <asp:Table ID="regSubmitTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="2"> 
                <b> Your account has been created! </b>
            </asp:TableCell>
        </asp:TableHeaderRow>
        <asp:TableHeaderRow>
            <asp:TableCell ColumnSpan ="2"> 
                <asp:Button ID="back" runat="server" Text="Back" PostBackUrl="~/default.aspx" />
            </asp:TableCell>
        </asp:TableHeaderRow>
    </asp:Table>
</asp:Content>