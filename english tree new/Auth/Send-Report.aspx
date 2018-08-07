<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Send-Report.aspx.cs" Inherits="Auth_Send_Report" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" runat="Server">
    <div class="form-group">
        <div class="col-md-2">
            <div class="form-group">
                <label for="exampleInputEmail1">School Name</label>
                <asp:DropDownList ID="ddlschool" CssClass=" form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
      <%--  <div class="col-md-2">
            <div class="form-group">
                <label for="exampleInputEmail1">class</label>
                <asp:DropDownList ID="ddlclass" CssClass=" form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="col-md-2">
            <div class="form-group">
                <label for="exampleInputEmail1">Section</label>
                <asp:DropDownList ID="ddlsection" runat="server" CssClass=" form-control">
                    <asp:ListItem>Select Section</asp:ListItem>
                    <asp:ListItem>A</asp:ListItem>
                    <asp:ListItem>B</asp:ListItem>
                    <asp:ListItem>C</asp:ListItem>
                    <asp:ListItem>D</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>--%>
        <div class="col-md-2">
            <div class="form-group">
                <label for="exampleInputEmail1">Date</label>
                <asp:TextBox ID="txtdate" runat="server" CssClass=" form-control"></asp:TextBox>
                <asp:CalendarExtender runat="server" Enabled="True" Format="MM/dd/yyyy" TargetControlID="txtdate" ID="txtdate_CalendarExtender"></asp:CalendarExtender>
            </div>
    </div>
    <div class="col-md-4">
        <div class="form-group">
           <label for="exampleInputEmail1">Action</label>
            <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="btn btn-default" OnClick="btnsearch_Click" />
            <asp:Button ID="btnemail" CssClass="btn btn-danger" OnClick="btnemail_Click" runat="server" Text="Send Email" />
        </div>
    </div>
        </div>

    <br />
    
    <asp:ListView ID="GridView1" runat="server" OnItemDataBound="GridView1_ItemDataBound">
        <ItemTemplate>
            Class : <asp:Label ID="lblclass" runat="server" Text='<%#Eval("class") %>'></asp:Label>
            <br />
            <asp:GridView ID="GridView2" runat="server" CssClass="table table-bordered">
            </asp:GridView>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

