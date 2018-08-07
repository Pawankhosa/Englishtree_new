<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Print-Fill.aspx.cs" Inherits="Auth_Print_Fill" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
        }
        .auto-style3 {
            width: 41px;
        }
        .auto-style4 {
        }
        .auto-style5 {
            width: 176px;
        }
        .auto-style6 {
            width: 121px;
        }
        .auto-style7 {
        }
        .auto-style8 {
            width: 59px;
        }
        .auto-style9 {
            width: 134px;
        }
    </style>
       <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
         <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick = "return PrintPanel();" />
        <asp:Panel ID="pnlContents" runat="server">
        <div style="margin: 0px auto; width: 377px; padding: 10px; height: 566px; background: menu">
            <table style="width: 100%;">
                <tr>
                    <td>
                        <h1 style="font-size: 50px; margin: 0px; font-family: cursive;">INSIGHT EDUCATION</h1>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p style="margin: 0px; text-align: center; font-size: 14px;">
                            Mob : 9332200009
                        </p>
                    </td>
                </tr>
                </table>
            <br />
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style4"><b>Name :</b></td>
                    <td class="auto-style5"><%=name %></td>
                    <td class="auto-style3">Date :</td>
                    <td><%=date %></td>
                </tr>
                <tr>
                    <td class="auto-style4">Passport :</td>
                    <td class="auto-style2" colspan="3"><%=pass %></td>
                </tr>
                <tr>
                    <td class="auto-style4">D.O.B</td>
                    <td class="auto-style5">&nbsp;<%=dob %>&nbsp;</td>
                    <td>D.O.E</td>
                    <td><%=doe %></td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="4">
                        <table style="width:100%;">
                            <tr>
                                <td class="auto-style9">Date Of Exam .</td>
                                <td class="auto-style7">1st Choice : <%=c1 %></td>
                            </tr>
                            <tr>
                                <td class="auto-style9">&nbsp;</td>
                                <td class="auto-style7">2nd Choice : <%=c2 %></td>
                            </tr>
                            <tr>
                                <td class="auto-style9">&nbsp;</td>
                                <td class="auto-style7">3rd Choice : <%=c3 %></td>
                            </tr>
                            <tr>
                                <td class="auto-style9">Module :</td>
                                <td class="auto-style7">&nbsp;<%=module %>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style9">Venue : </td>
                                <td class="auto-style7">&nbsp;<%=v1 %> / <%=v2 %> / <%=v3 %>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style9">Mode Of Payment :</td>
                                <td class="auto-style7"><%=mode %></td>
                            </tr>
                            <tr>
                                <td class="auto-style9">Status :</td>
                                <td class="auto-style7"><%=status %></td>
                            </tr>
                            <tr>
                                <td class="auto-style9">Institute Name :</td>
                                <td class="auto-style7"><%=inst %></td>
                            </tr>
                            <tr>
                                <td class="auto-style9">&nbsp;</td>
                                <td class="auto-style7">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style9">Signature</td>
                                <td class="auto-style7">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style9">&nbsp;</td>
                                <td class="auto-style7">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style9">T.R.F</td>
                                <td class="auto-style7">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style9">Receivers Sign :</td>
                                <td class="auto-style7">...................... Date : ....................</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style8">Result :</td>
                    <td class="auto-style6">L&nbsp;&nbsp;&nbsp;&nbsp; R&nbsp;&nbsp;&nbsp;&nbsp; W&nbsp;&nbsp;&nbsp;&nbsp; S</td>
                    <td>Overall : ............................</td>
                </tr>
                
            </table>
        </div>
            </asp:Panel>
        

    </form>
</body>
</html>
