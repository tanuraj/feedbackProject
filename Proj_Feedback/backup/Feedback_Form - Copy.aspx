<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Feedback_Form.aspx.cs" Inherits="Proj_Feedback.Feedback_Form" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <link href="/css/bootstrap.min.css" rel="stylesheet" />
    
    
    <!-- <msdropdown> -->
    <link rel="stylesheet" type="text/css" href="css/msdropdown/dd.css" />


    <script src="js/jquery/jquery-1.9.0.min.js" type="text/javascript"></script>
    <script src="/scripts/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/msdropdown/jquery.dd.js"></script>

    <!-- Script is used to call the JQuery for dropdown -->

    <script type="text/javascript">

        $(document).ready(function (e) {

            try {

                $("#ddlMyHappinessImg").msDropDown();
                $("#ddlMyPlayImg").msDropDown();
                $("#ddlTeamHappyImg").msDropDown();
                $("#ddlGameHappyImg").msDropDown();

            } catch (e) {

                alert(e.message);

            }
            $('#btnSave').click(function (e) {
                try {

                    $("#ddlMyHappinessImg").msDropDown();
                    $("#ddlMyPlayImg").msDropDown();
                    $("#ddlTeamHappyImg").msDropDown();
                    $("#ddlGameHappyImg").msDropDown();

                } catch (e) {

                    alert(e.message);

                }
            });
        });
        


    </script>
    <style>
        .container {
            max-width: 900px !important;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="updPanel1">
            <ContentTemplate>
                <div class="divspacing"></div>
                <div class="container body-content">
                    <div class="row">
                        <div class="col-md-4">
                            <h2>Feedback Form</h2>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="LblError" runat="server" Text="" CssClass="control-label formlabel"></asp:Label>
                        </div>
                    </div>

                    <div class="divspacing"></div>

                    <div class="panel panel-primary">
                        <div class="panel-body control-label formlabel" style="color: Black">

                            <%--Feedback Details:--%>
                            <div class="divspacing"></div>
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-3 control-label">
                                    <asp:Label ID="Label5" runat="server" Text="Name  :" CssClass="control-label formlabel"></asp:Label><span style="color: Red">*</span>
                                </div>
                                <div class="col-md-5 form-group">
                                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" MaxLength="50" autocomplete="Off"></asp:TextBox>
                                </div>
                            </div>

                            <div class="divspacing"></div>
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-3 control-label">
                                    <asp:Label ID="Label1" runat="server" Text="My Happiness :" CssClass="control-label formlabel"></asp:Label><span style="color: Red">*</span>
                                </div>
                                <div class="col-md-5 form-group">
                                    <asp:DropDownList ID="ddlMyHappinessImg" runat="server" CssClass="form-control" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="divspacing"></div>
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-3 control-label">
                                    <asp:Label ID="Label2" runat="server" Text="Remarks :" CssClass="control-label formlabel"></asp:Label><span style="color: Red">*</span>
                                </div>
                                <div class="col-md-5 form-group">
                                    <asp:TextBox ID="txtMyHappiness" TextMode="MultiLine" runat="server" CssClass="form-control" MaxLength="50" autocomplete="Off"></asp:TextBox>
                                </div>
                            </div>
                            <div class="divspacing"></div>
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-3 control-label">
                                    <asp:Label ID="Label3" runat="server" Text="My Play :" CssClass="control-label formlabel"></asp:Label><span style="color: Red">*</span>
                                </div>
                                <div class="col-md-5 form-group">
                                    <asp:DropDownList ID="ddlMyPlayImg" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="divspacing"></div>
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-3 control-label">
                                    <asp:Label ID="Label4" runat="server" Text="Remarks :" CssClass="control-label formlabel"></asp:Label><span style="color: Red">*</span>
                                </div>
                                <div class="col-md-5 form-group">
                                    <asp:TextBox ID="txtMyPlay" TextMode="MultiLine" runat="server" CssClass="form-control" MaxLength="50" autocomplete="Off"></asp:TextBox>
                                </div>
                            </div>
                            <div class="divspacing"></div>
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-3 control-label">
                                    <asp:Label ID="Label6" runat="server" Text="Team Happiness :" CssClass="control-label formlabel"></asp:Label><span style="color: Red">*</span>
                                </div>
                                <div class="col-md-5 form-group">
                                    <asp:DropDownList ID="ddlTeamHappyImg" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="divspacing"></div>
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-3 control-label">
                                    <asp:Label ID="Label7" runat="server" Text="Remarks :" CssClass="control-label formlabel"></asp:Label><span style="color: Red">*</span>
                                </div>
                                <div class="col-md-5 form-group">
                                    <asp:TextBox ID="txtTeamHappiness" TextMode="MultiLine" runat="server" CssClass="form-control" MaxLength="50" autocomplete="Off"></asp:TextBox>
                                </div>
                            </div>
                            <div class="divspacing"></div>
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-3 control-label">
                                    <asp:Label ID="Label8" runat="server" Text="Game Happiness:" CssClass="control-label formlabel"></asp:Label><span style="color: Red">*</span>
                                </div>
                                <div class="col-md-5 form-group">
                                    <asp:DropDownList ID="ddlGameHappyImg" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="divspacing"></div>
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-3 control-label">
                                    <asp:Label ID="Label9" runat="server" Text="Remarks :" CssClass="control-label formlabel"></asp:Label><span style="color: Red">*</span>
                                </div>
                                <div class="col-md-5 form-group">
                                    <asp:TextBox ID="txtGameHappiness" TextMode="MultiLine" runat="server" CssClass="form-control" MaxLength="50" autocomplete="Off"></asp:TextBox>
                                </div>
                            </div>

                            <div class="divspacing"></div>
                            <div class="row">
                                <div class="col-lg-4"></div>
                                <div class="col-lg-4" align="center">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary buttonClass" OnClick="btnSave_Click" />&nbsp;&nbsp;&nbsp;&nbsp;     
                    <asp:Button CssClass="btn btn-primary buttonClass"
                        ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel"
                        OnClick="btnCancel_Click"  />
                                </div>

                            </div>

                        </div>
                    </div>

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>


</body>
</html>
