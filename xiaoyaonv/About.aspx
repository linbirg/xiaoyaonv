<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="About.aspx.cs" Inherits="About" %>
 
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="main">
      <div id="banner">
         <div class="col_1">
            <div style="margin-top:2px"><img src="images/index_ad.gif" style="width:699px ;height:150px" /></div>
         </div>
         <DIV class="col_2">
            <div id="right" style="margin-top:2px"><img src="images/hot.jpg" style="width:240px; height:150px" /></div>
         </DIV>
      </div>
       <div id="content_1">
       <asp:DataList ID="DlNewGoods" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                                    Width="100%" DataSourceID="SqlDataSource1" >
                                    <ItemTemplate>
                                        <table width="146px" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 5px;">
                                            <tr style="padding-top: 5px; padding-bottom: 5px;">
                                                <td background="Style/wonext/goodsIDdig.gif">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td>
                                                                <span class="digmun">
                                                                    <asp:Label ID="labnum" runat="server" Text='          '></asp:Label></span>人喜欢</td>
                                                            <td align="center">
                                                                <table width="51" height="25" border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td background="Style/wonext/show_dig.gif">
                                                                            <asp:Label ID="labdig" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="center" style="padding-top: 10px; padding-bottom: 5px;">
                                                                <a href=' '>
                                                                    <img src=' ' 
                                                                        alt=' ' width="120" height="90" border="0" style="border: 1px #fff solid"
                                                                        onmouseover="this.style.borderColor='FF6600'" onmouseout="this.style.borderColor='fff'"></a></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="padding-left: 5px; padding-bottom: 3px; padding-right: 5px;">
                                                                <a href=' '> </a><br>
                                                                By：<a href=' '> </a><br>
                                                                <img src="Style/wonext/vodpl.gif" width="14" height="14"><a href=' '> 5条评论</a>"
                                                                 
                                                               5 位观众</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
           
       </div>
       <div id="content_2">
       </div>
 </div>


</asp:Content>
