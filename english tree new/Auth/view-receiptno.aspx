﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="view-receiptno.aspx.cs" Inherits="Auth_view_receiptno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Recipt No
<script>

    function ConfirmDelete() {
        if (confirm("Do you want to delete this Record?")) {
            return true;
        }
        else {
            return false;
        }
    }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
  <asp:Label ID="lblcode" runat="server" Text="" Visible="false"></asp:Label>
   <div class="col-md-12 text-right">
            <asp:Button ID="btnadd" runat="server" Text="Add" CssClass=" btn btn-success" 
                onclick="btnadd_Click" />
            <asp:Button ID="btnback" runat="server" Text="Back" CssClass=" btn btn-danger" 
                onclick="btnback_Click"/>
        </div>
  <div class="col-md-12">
<asp:DataGrid ID="gridlist" runat="server" Width="100%" AutoGenerateColumns="false" 
            onitemcommand="gridlist_ItemCommand" class="table table-bordered">
 <Columns>
            <asp:TemplateColumn >
                <HeaderTemplate>
                    #</HeaderTemplate>
                <ItemTemplate>
                    &nbsp;&nbsp;<%# Container.DataSetIndex+1 %>
                </ItemTemplate>
            </asp:TemplateColumn>

             <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">
         
                <HeaderTemplate>
                  Start No.
                </HeaderTemplate>
                <ItemTemplate > 
                     <div style=" text-align:center"><%# Eval("Start_no")%></div>
                   
                </ItemTemplate>
              
        </asp:TemplateColumn>
        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">
         
                <HeaderTemplate>
                 End NO.
                </HeaderTemplate>
                <ItemTemplate > 
                     <div style=" text-align:center"><%# Eval("End_no")%></div>
                   
                </ItemTemplate>
              
        </asp:TemplateColumn>

         
          <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">
         
                <HeaderTemplate>
                  Date
                </HeaderTemplate>
                <ItemTemplate > 
                     <div style=" text-align:center"><%# Eval("Date")%></div>
                   
                </ItemTemplate>
              
        </asp:TemplateColumn>
          <asp:TemplateColumn>
                <HeaderTemplate>
                Action
                </HeaderTemplate>
                <ItemTemplate>
                         <table>
               <tr>
                <td> &nbsp;
                     
                </td>
               <td> &nbsp;
               <asp:ImageButton ToolTip="Edit"   runat="server" ID="lnkEdit" ImageUrl="images/edit.png"  CommandName="edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' /></td>
                 <%-- <td>&nbsp;  <asp:ImageButton ToolTip="Delete"  OnClientClick="return ConfirmDelete()" runat="server" ID="ImageButton1" ImageUrl="images/delete.png"  CommandName="delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' /></td>
                   
               </tr>--%>
               </table>
                </ItemTemplate>
                   <HeaderStyle HorizontalAlign="center" />
                   <ItemStyle HorizontalAlign="center" />
            </asp:TemplateColumn>
        </Columns>
        <HeaderStyle BackColor="#34D1BE" ForeColor="White" Font-Bold="true" HorizontalAlign="Center" />
    </asp:DataGrid>
    
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

