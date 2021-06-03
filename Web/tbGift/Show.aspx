<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Xmf.SHMYSYS.Web.tbGift.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		GUID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblGUID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		GIFTNAME
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblGIFTNAME" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		IMAGE
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblIMAGE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		NUMBER
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblNUMBER" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DETAIL
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDETAIL" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ADDTIME
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblADDTIME" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ISUSE
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblISUSE" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




