<%@ Page Title="Images" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Images.aspx.cs" Inherits="UserWebFormApp.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="container" style="display:flex; flex-direction:column; width:auto; height:auto; align-items:center; border:1px solid black" >
         <h1 style="font-size:20px;font-family:Roboto; color:rgb(60, 60, 218); text-align: center; height: 91px; margin-bottom:10pt">Image Section</h1>
        <div class="ImageSelection" style="display:flex; flex-direction:column; justify-items:center; border:1px dashed black; width:200pt; height:200pt; border-radius:10px; object-fit:contain;justify-items:center; align-items:center">
            <p style="text-align:center; margin-top:30%">Choose Image</p> 
            <asp:FileUpload ID="ImageSelector" runat="server" style="margin-left:30pt;"/>      
        </div>
        <asp:Label ID="msg" runat="server" style="padding:20pt; color:red;" Text=""></asp:Label>
        <asp:Button ID="Button1" runat="server" style="border: none ; border-radius:5px; padding:5pt; background-image:linear-gradient(to bottom, rgb(133, 133, 190), rgb(96, 96, 255)); color: white; width:100pt" BorderStyle="None" Height="41px" Text="Save" OnClick="Upload_Click" />
    </div>
   
</asp:Content>
