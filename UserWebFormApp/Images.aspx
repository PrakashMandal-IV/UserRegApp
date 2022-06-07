<%@ Page Title="Images" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UserWebFormApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="container" style="display:flex; flex-direction:column; width:auto; height:auto; align-items:center;" >
         <h1 style="font-size:20px;font-family:Roboto; color:rgb(60, 60, 218); text-align: center; height: 91px; margin-bottom:5pt">Image Section</h1>
        <div class="ImageSelection" style="display:flex; flex-direction:column; justify-items:center; border:1px dashed black; width:200pt; height:200pt; border-radius:10px; object-fit:contain;justify-items:center; align-items:center">
            <p style="text-align:center; margin-top:30%">Choose Image</p> 
            <asp:FileUpload ID="ImageSelector" runat="server" style="margin-left:30pt;"/>      
        </div>
        <asp:Label ID="Info" runat="server" style="padding:20pt; font-family:Roboto;" Text="File Size Should not exceed 50mb"></asp:Label>
        <asp:Label ID="msg" runat="server" style="padding:20pt; font-size:10px; color:red;" Text=""></asp:Label>
        <asp:Button ID="Button1" runat="server" style="border: none ; border-radius:5px; padding:5pt; background-image:linear-gradient(to bottom, rgb(133, 133, 190), rgb(96, 96, 255)); color: white; width:100pt" BorderStyle="None" Height="41px" Text="Save" OnClick="Upload_Click" />
        <asp:Label ID="successMsg" runat="server" style="padding:20pt; font-family:Roboto;" Text=""></asp:Label>
        </div>
        <div class="Second_Part" style="display:flex;gap:10pt;">
         <asp:GridView ID="ImageData" CssClass="table table-condensed table-responsive table-hover" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" runat="server" Height="16px" Width="486px" style="margin-right: 0px; margin-top: 29px;" GridLines="none" AllowSorting="True">
                    <HeaderStyle BackColor="black" ForeColor="White" Font-Names="Roboto" Height="30pt" />
                   <RowStyle/>
             <Columns>
                 <asp:TemplateField>
                     <ItemTemplate>
                         <asp:Button ID="ViewBtn" CssClass="Button" runat="server" style="border: none ; border-radius:5px; background-image:linear-gradient(to bottom, rgb(133, 133, 190), rgb(96, 96, 255)); color: white; width:100pt" BorderStyle="None" Height="20px" Text="View" Value='<%#Eval("Id") %>' CommandName="Select"  />
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
                </asp:GridView>
            <div style="margin:20pt">
            <asp:Image ID="ImageOrg" style="width:auto; height:auto; max-height:250pt;border:none;border-radius:5px" runat="server" />   
            <asp:Image ID="Thumbnail" style="width:auto;height:auto; max-height:150pt;border:none; margin:10pt; border:1px solid rgb(96, 96, 255);align-self:center; border-radius:5px" runat="server" />
                </div>
            </div>
</asp:Content>
