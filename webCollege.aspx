<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webCollege.aspx.cs" Inherits="OLEDB.webCollege" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 600px;
        }
        .auto-style2 {
            height: 124px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <asp:Panel ID="panSchool" runat="server" GroupingText="Select School" Height="153px">
                            <asp:RadioButtonList ID="radlistSchool" runat="server" AutoPostBack="True" OnSelectedIndexChanged="radlistSchool_SelectedIndexChanged">
                            </asp:RadioButtonList>
                        </asp:Panel>
                    </td>
                    <td class="auto-style2">
                        <asp:Panel ID="panPrograms" runat="server" GroupingText="Select a program" Height="153px">
                            <asp:RadioButtonList ID="radlstPrograms" runat="server" AutoPostBack="True" OnSelectedIndexChanged="radlstPrograms_SelectedIndexChanged">
                            </asp:RadioButtonList>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="panCourse" runat="server" GroupingText="Select a course" Height="153px">
                            <asp:CheckBoxList ID="chklstCourses" runat="server" AutoPostBack="True" OnSelectedIndexChanged="chklstCourses_SelectedIndexChanged">
                            </asp:CheckBoxList>
                        </asp:Panel>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gridStudents" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gridStudents_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
