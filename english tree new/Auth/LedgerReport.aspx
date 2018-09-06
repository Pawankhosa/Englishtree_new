<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="LedgerReport.aspx.cs" Inherits="Auth_LedgerReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" runat="Server">
    Date Wise Report
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" runat="Server">
    <div>

        <section>
            <div class="form-group col-md-3">
                <label for="exampleInputEmail1">From</label>
                <asp:TextBox ID="txtFromDate" CssClass=" form-control" runat="server"></asp:TextBox>

                <ajaxToolkit:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" BehaviorID="txtFromDate_CalendarExtender" TargetControlID="txtFromDate" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>

                <%-- <asp:CalendarExtender runat="server" Format="dd/MM/yyyy" TargetControlID="txtFromDate" ID="txtFromDate_CalendarExtender"></asp:CalendarExtender>--%>
            </div>
            <div class="form-group col-md-3">
                <label for="exampleInputPassword1">To</label>
                <asp:TextBox ID="txtToDate" CssClass="form-control" runat="server"></asp:TextBox>

                <ajaxToolkit:CalendarExtender ID="txtToDate_CalendarExtender" runat="server" BehaviorID="txtToDate_CalendarExtender" TargetControlID="txtToDate" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>

                <%--<asp:CalendarExtender runat="server" Format="dd/MM/yyyy" TargetControlID="txtToDate" ID="txtToDate_CalendarExtender"></asp:CalendarExtender>--%>
            </div>

            <div class="form-group col-md-3">
                <br />
                <asp:Button ID="BtnLoadReport" CssClass="btn btn-default" runat="server"
                    Text="Load Report" OnClick="BtnLoadReport_Click" />
            </div>
        </section>
           <asp:Panel ID="pnlContents" runat="server">

        <asp:DataGrid ID="gridPaymentinfo" runat="server" AutoGenerateColumns="false" Width="100%"
            HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#C2DCEB"
            HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="black"
            OnItemDataBound="gridPaymentinfo_ItemDataBound" CssClass="table table-bordered">


            <Columns>
                <asp:TemplateColumn>
                    <HeaderTemplate>
                        #
                    </HeaderTemplate>
                    <ItemTemplate>
                        &nbsp;&nbsp;<%# Container.DataSetIndex+1 %>
                    </ItemTemplate>

                </asp:TemplateColumn>

                <asp:TemplateColumn>

                    <HeaderTemplate>
                        Date
                    </HeaderTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lbldate" runat="server" Text='<%# Eval("Date")%>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateColumn>

                <asp:BoundColumn DataField="name" HeaderText="Name"></asp:BoundColumn>

                <asp:BoundColumn DataField="Rollno" HeaderText="Roll No"></asp:BoundColumn>
                <asp:BoundColumn DataField="CourseName" HeaderText="Course Name"></asp:BoundColumn>

                <asp:TemplateColumn>

                    <HeaderTemplate>
                        Paid Amount
                    </HeaderTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblpaid" runat="server" Text='<%# Eval("TodayPaidFee")%>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateColumn>
                <asp:BoundColumn DataField="TokenNo" HeaderText="Receipt No."></asp:BoundColumn>
            </Columns>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
        </asp:DataGrid>

        <div style="float: right; width: 200px">
            <table>

                <tr>
                    <td>
                         Paid Amount Total: &nbsp</td><td> <%=Total %>

                    </td>
                </tr>
            </table>
        </div>
</asp:Panel>

        <br />


        <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-danger" Text="Print" OnClientClick="return PrintPanel();" />
        <asp:Button ID="btnBack" CssClass="btn btn-info"
            PostBackUrl="Default.aspx" runat="server" Text="Back" />
    </div>
    <div style="text-align: right">
        <asp:Button ID="btnExporttoexcel" CssClass="btn btn-success" runat="server"
            Text="Export Reports to Excel" OnClick="btnExporttoexcel_Click" />

    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" runat="Server">
      <script type="text/javascript">
        function PrintPanel() {
            debugger;
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        };
    </script>
</asp:Content>

