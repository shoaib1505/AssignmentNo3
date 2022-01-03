<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.Master" AutoEventWireup="true" CodeBehind="New Asset.aspx.cs" Inherits="Assignment3.New_Asset" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 21px;
        }
        .auto-style2 {
            width: 456px;
        }
        .auto-style3 {
            width: 204px;
        }
        .auto-style4 {
            height: 21px;
            width: 204px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <table class="auto-style2">
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label1" runat="server" Text="Asset Name:"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxAssetName" runat="server" Height="16px" Width="166px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxAssetName" ErrorMessage="mandatory Field" ForeColor="Red">Enter Asset</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label2" runat="server" Text="Vendor Name:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DropDownListVendorName" runat="server" Width="170px" Height="25px">
                    </asp:DropDownList>
                   
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label3" runat="server" Text="Purchase Date:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="161px" AutoCompleteType="Disabled"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" BehaviorID="TextBox1_CalendarExtender" TargetControlID="TextBox1" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1" ErrorMessage="Mandatory Field " ForeColor="Red">Select Date </asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Cost:"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBoxCost1" runat="server" min="1" max="100000" Height="16px" Width="126px"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="TextBoxCost1_FilteredTextBoxExtender" runat="server" BehaviorID="TextBoxCost1_FilteredTextBoxExtender" FilterType="Numbers" TargetControlID="TextBoxCost1" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxCost1" ErrorMessage="Mandatory Field" ForeColor="Red">Enter Valid</asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style2">
                    <asp:Button ID="ButtonAddAsset" runat="server" OnClick="ButtonAddAsset_Click" Text="Add" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="ButtonCancelAsset" runat="server" Text="Cancel" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
