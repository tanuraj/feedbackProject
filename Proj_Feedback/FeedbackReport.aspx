<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeedbackReport.aspx.cs" Inherits="Proj_Feedback.FeedbackReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/bootstrap.min.css" rel="stylesheet" />
    <script src="/scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="js/jquery/jquery-1.9.0.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="divspacing"></div>
        <div class=" body-content" style="padding: 10px;">
            <div class="row">
                <div class="col-md-4" align="Center">
                    <h2>Feedback Report</h2>
                </div>

            </div>
            <div id="DivPrint" class="DIVImg setPosition">

                <div align="right"  style="width: 93%; padding:10px;">
                   <asp:Button ID="btnForm" CssClass="btn btn-primary" runat="server" Text="Back to Form" OnClick="btnForm_Click" />
               &nbsp; &nbsp;
                      <asp:Button ID="btnExport" CssClass="btn btn-primary" runat="server" Text="Export to Excel" OnClick="btnExport_Click" />
                    
                       <%--     <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Export to Excel test" OnClick="Button1_Click" />--%>
                </div>
            </div>

            <div class="panel ">
                <div class="panel-body control-label formlabel" style="color: Black">
                    <div id="divExportMain" class="outerBorder row">
                        <asp:GridView ID="GvDetail" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True"
                            OnPageIndexChanging="GvDetail_PageIndexChanging" EmptyDataText="No records Found"
                            CellPadding="3" BackColor="White" Width="65%" BorderColor="#CCCCCC" BorderStyle="None"
                            BorderWidth="1px" HorizontalAlign="Center" PageSize="20" AllowPaging="true">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No." HeaderStyle-Width="5%" ItemStyle-Width="5%"
                                    ItemStyle-CssClass="numerdatagrid">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle Width="20px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="NAME" HeaderText="Name"
                                    HeaderStyle-Width="20%" ItemStyle-Width="20%" ItemStyle-CssClass="alphadatagrid">
                                    <ItemStyle CssClass="alphadatagrid" Width="100px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="FEED_DATETIME" HeaderText="Feed Date" HeaderStyle-Width="20%"
                                    ItemStyle-Width="20%" ItemStyle-CssClass="alphadatagrid">
                                    <ItemStyle CssClass="alphadatagrid"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="MY_HAPPINESS_Emoji" HeaderText="MY HAPPINESS" HeaderStyle-Width="10%"
                                    ItemStyle-Width="10%" ItemStyle-CssClass="alphadatagrid">
                                    <ItemStyle CssClass="alphadatagrid"></ItemStyle>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="MY HAPPINESS EMOJI " HeaderStyle-Width="5%" ItemStyle-Width="5%"
                                    ItemStyle-CssClass="numerdatagrid">
                                    <ItemTemplate>
                                        <img alt="Not Found" width="30px" height="30px" src='<%#"emoji/"+ Eval("MY_HAPPINESS_IMG") %>' />
                                        <%-- <asp:Image ID="imgTest" runat="server" ImageUrl='<%#Server.MapPath("emoji/"+Eval("MY_HAPPINESS_IMG"))%>' />--%>
                                    </ItemTemplate>
                                    <ItemStyle Width="20px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="MY_HAPPINESS_REMARK" HeaderText="MY HAPPINESS REMARK" HeaderStyle-Width="10%"
                                    ItemStyle-Width="10%" ItemStyle-CssClass="alphadatagrid">
                                    <ItemStyle CssClass="alphadatagrid"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="MY_PLAY_Emoji" HeaderText="MY Play" HeaderStyle-Width="10%"
                                    ItemStyle-Width="10%" ItemStyle-CssClass="alphadatagrid">
                                    <ItemStyle CssClass="alphadatagrid"></ItemStyle>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="MY HAPPINESS EMOJI " HeaderStyle-Width="5%" ItemStyle-Width="5%"
                                    ItemStyle-CssClass="numerdatagrid">
                                    <ItemTemplate>
                                        <img alt="Not Found" width="30px" height="30px" src='<%# "emoji/"+ Eval("MY_PLAY_IMG") %>' />
                                        <%--"Images/view.gif"--%>
                                    </ItemTemplate>
                                    <ItemStyle Width="20px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="MY_PLAY_REMARK" HeaderText="MY PLAY REMARK" HeaderStyle-Width="10%"
                                    ItemStyle-Width="10%" ItemStyle-CssClass="alphadatagrid">
                                    <ItemStyle CssClass="alphadatagrid"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="TEAM_HAPPINESS_Emoji" HeaderText="TEAM HAPPINESS" HeaderStyle-Width="10%"
                                    ItemStyle-Width="10%" ItemStyle-CssClass="alphadatagrid">
                                    <ItemStyle CssClass="alphadatagrid"></ItemStyle>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="TEAM HAPPINESS EMOJI " HeaderStyle-Width="5%" ItemStyle-Width="5%"
                                    ItemStyle-CssClass="numerdatagrid">
                                    <ItemTemplate>
                                        <img alt="Not Found" width="30px" height="30px" src='<%#"emoji/"+ Eval("TEAM_HAPPINESS_IMG") %>' />
                                        <%--"Images/view.gif"--%>
                                    </ItemTemplate>
                                    <ItemStyle Width="20px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="TEAM_HAPPINESS_REMARK" HeaderText="TEAM HAPPINESS REMARK" HeaderStyle-Width="10%"
                                    ItemStyle-Width="10%" ItemStyle-CssClass="alphadatagrid">
                                    <ItemStyle CssClass="alphadatagrid"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="GAME_HAPPINESS_Emoji" HeaderText="GAME HAPPINESS" HeaderStyle-Width="10%"
                                    ItemStyle-Width="10%" ItemStyle-CssClass="alphadatagrid">
                                    <ItemStyle CssClass="alphadatagrid"></ItemStyle>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="MY HAPPINESS EMOJI " HeaderStyle-Width="5%" ItemStyle-Width="5%"
                                    ItemStyle-CssClass="numerdatagrid">
                                    <ItemTemplate>
                                        <img alt="Not Found" width="30px" height="30px" src='<%#"emoji/"+ Eval("GAME_HAPPINESS_IMG") %>' />
                                        <%--"Images/view.gif"--%>
                                    </ItemTemplate>
                                    <ItemStyle Width="20px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="GAME_HAPPINESS_REMARK" HeaderText="GAME HAPPINESS REMARK" HeaderStyle-Width="10%"
                                    ItemStyle-Width="10%" ItemStyle-CssClass="alphadatagrid">
                                    <ItemStyle CssClass="alphadatagrid"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <PagerStyle BackColor="skyblue" ForeColor="#000066" Font-Size="X-Small" CssClass="PagerCSS"
                                HorizontalAlign="Left" />
                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="Numeric" Position="Bottom" />
                            <HeaderStyle Font-Size="11px" BackColor="#3fafc5" ForeColor="Black" />
                            <AlternatingRowStyle CssClass="AlternatingItemStyle" />
                        </asp:GridView>
                        <div style="text-align: center;">
                            <span id="PrintDate" runat="server" style="font-family: verdana; color: #292626; font-size: 10px;"></span>
                        </div>
                    </div>
                </div>
            </div>


        </div>

        <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Font-Names="Arial">

                <Columns>

                    <asp:BoundField DataField="ID" HeaderText="ID"
                        ItemStyle-Height="150" />

                    <asp:BoundField DataField="FileName" HeaderText="Image Name"
                        ItemStyle-Height="150" />

                    <asp:TemplateField ItemStyle-Height="150"  ItemStyle-Width="170">

                        <ItemTemplate>

                            <asp:Image ID="Image1" runat="server"
                                ImageUrl='<%#Eval("FilePath", GetUrl("{0}")) %>' />

                        </ItemTemplate>

                    </asp:TemplateField>

                </Columns>

            </asp:GridView>--%>
    </form>
</body>
</html>
