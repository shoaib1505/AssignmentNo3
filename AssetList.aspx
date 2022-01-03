<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.Master" AutoEventWireup="true" CodeBehind="AssetList.aspx.cs" Inherits="Assignment3.AssetList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    <asp:Label ID="lblsearch" runat="server" Text="Search"></asp:Label>

    <asp:Panel ID="Panel2" runat="server" CssClass="Popup" align="center" Style="display: none">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Asset ID"></asp:Label>

                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Font-Size="14px"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Asset Name"></asp:Label>

                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" Font-Size="14px"></asp:TextBox>
                        <br />

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Vendor Name"></asp:Label>

                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList2" runat="server" Width="100px"></asp:DropDownList>

                        <asp:ListItem>Please Select The Vendor Name</asp:ListItem>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Purchase Date"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server" type="date"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Cost"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button3" runat="server" Text="Submit" OnClick="Button3_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Button2" runat="server" Text="Close" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>



    &nbsp;
    <asp:Panel ID="Panel1" runat="server" CssClass="Popup1" align="center" Style="display: none">
        <iframe style="width: 350px; height: 300px;" id="irm1" src="WebForm2.aspx" runat="server"></iframe>
        <br />

    </asp:Panel>
    <asp:TextBox ID="txtsearch" runat="server" AutoPostBack="True" Height="22px" OnTextChanged="txtsearch_TextChanged" ></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
    <br />
    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;

    <asp:Button ID="Button1" runat="server" Text="Add New  Assets"  />

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 <strong><asp:Label ID="Label11" runat="server" Text="Label"></asp:Label></strong>   

    <br />

    <ajaxToolkit:ModalPopupExtender ID="Button1_ModalPopupExtender" runat="server" TargetControlID="Button1" PopupControlID="Panel2">
    </ajaxToolkit:ModalPopupExtender>

    <asp:GridView ID="GridView1" DataKeyNames="Id" EmptyDataText="No Record Found" ShowHeaderWhenEmpty="true" runat="server" AutoGenerateColumns="False" Width="629px" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowDeleting="GridView1_RowDeleting">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Asset Id" />
            <asp:BoundField DataField="AssetName" HeaderText="Asset Name" />
            <asp:BoundField DataField="VendorName" HeaderText="VendorName" />
            <asp:BoundField DataField="Cost" HeaderText="Cost" />
            <asp:TemplateField HeaderText="Edit" >
                <ItemTemplate >
                    <asp:LinkButton  class="btnrowvalue1" ID="LinkButton1" Text="Edit" runat="server" CommandName="Select" />
                    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel3" TargetControlID="LinkButton1"></ajaxToolkit:ModalPopupExtender>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowDeleteButton="True" HeaderText="Delete"/>
        </Columns>
    </asp:GridView>
  
        <asp:Panel ID="Panel3" CssClass="Popup" runat="server">
          <div style="border: 1px solid black; width: 413px;">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="AssetId:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxEditAssetId" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="AssetName:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxEditAssetName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="VendorName:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListEditVendorAsset" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="PurchaseDate"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxEditPurchase" runat="server"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="TextBoxEditPurchase_CalendarExtender" runat="server" BehaviorID="TextBoxEditPurchase_CalendarExtender" TargetControlID="TextBoxEditPurchase" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="Cost"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxEditCost" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ButtonEditAsset" runat="server" Text="Edit" OnClick="ButtonEditAsset_Click" />
                </td>
                <td>
                    <asp:Button ID="ButtonCancelEdit" runat="server" Text="Cancel" OnClick="ButtonCancelEdit_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
