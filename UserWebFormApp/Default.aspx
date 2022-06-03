<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UserWebFormApp._Default" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <table class="nav-justified" style="height: 603px; width: 76%;">
        <tr>
            <td style="width: 309px">&nbsp;</td>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td style="font-family: Roboto; font-size: 20px; color: rgb(60, 60, 218); font-weight: bolder; height: 59px; text-align: center; " colspan="3">User Registration</td>
        </tr>
        <tr>
            <td style="width: 309px; height: 47px">
                Name</td>
            <td style="width: 170px; height: 47px">
                <asp:TextBox ID="FirstName" runat="server" class="input" style="border-bottom: 1px solid black ;" placeholder="FirstName" BorderStyle="None" Height="20pt" ></asp:TextBox>
            </td>
            <td style="height: 47px">
                <asp:TextBox ID="LastName" runat="server" style="border-bottom: 1px solid black ;" placeholder="LastName" BorderStyle="None" Height="20pt"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 309px; height: 40px">
                Email</td>
            <td colspan="2" style="height: 40px">
                <asp:TextBox ID="Email" runat="server" style="border-bottom: 1px solid black ;" placeholder="Email.." BorderStyle="None" Height="20pt" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 309px; height: 46px">
                Address</td>
            <td colspan="2" style="height: 46px">
                <asp:TextBox ID="Address" runat="server" style="border-bottom: 1px solid black ;" placeholder="Address.." BorderStyle="None" Height="20pt"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 309px; height: 38px">
                State</td>
            <td colspan="2" style="height: 38px">
                <asp:TextBox ID="State" runat="server" style="border-bottom: 1px solid black ;" placeholder="State.." BorderStyle="None" Height="20pt" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 309px; height: 45px;">
                Date of Birth</td>
            <td colspan="2" style="height: 45px">
                <asp:TextBox ID="DOB" runat="server" placeholder="Select Date" style="border-bottom: 1px solid black ;" BorderStyle="None" Height="20pt" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 309px; height: 39px">
                Mobile</td>
            <td colspan="2" style="height: 39px">
                <asp:TextBox ID="Mobile" runat="server" placeholder="xxx-xxx-xxxx" style="border-bottom: 1px solid black ;" BorderStyle="None" Height="20pt" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 309px; height: 46px">
                Password</td>
            <td colspan="2" style="height: 46px">
                <asp:TextBox ID="Password" runat="server" placeholder="xxx-xxx-xxxx" style="border-bottom: 1px solid black ;" BorderStyle="None" Height="20pt" Width="207px" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 309px; height: 40px">
                Confirm Password</td>
            <td colspan="2" style="height: 40px">
                <asp:TextBox ID="ConfirmPassword" placeholder="Confirm Password" style="border-bottom: 1px solid black ;" runat="server" BorderStyle="None" Height="20pt" OnTextChanged="ConfirmPassword_TextChanged" TextMode="Password" Width="208px" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 309px; height: 46px;"></td>
            <td colspan="2" style="height: 46px">
                <asp:Label ID="msg" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 309px; height: 41px;"></td>
            <td colspan="2" style="height: 41px">
                <asp:Button ID="Button1" runat="server" AutoPostBack="false" BackColor="#99CCFF" style="border: none ; border-radius:5px; padding:5pt; background-image:linear-gradient(to bottom, rgb(133, 133, 190), rgb(96, 96, 255)); color: white;"  BorderStyle="None" Height="41px" OnClick="Button1_Click" Text="Register" Width="152px" />
                <asp:Button ID="Button2" runat="server" AutoPostBack="false" BackColor="#99CCFF" style="border: none ; border-radius:5px; padding:5pt; background-image:linear-gradient(to bottom, rgb(133, 133, 190), rgb(1, 23, 224)); color: white;"  BorderStyle="None" Height="41px" OnClick="Button1_Click" Text="Update" Width="152px" />
                <asp:Button ID="Button3" runat="server" AutoPostBack="false" BackColor="#99CCFF" style="border: none ; border-radius:5px; padding:5pt; background-image:linear-gradient(to bottom, rgb(253, 207, 207), rgb(216, 66, 66)); color: white;"  BorderStyle="None" Height="41px" OnClick="Button1_Click" Text="Delete" Width="152px" />
            </td>
        </tr>
        <tr>
            <td style="width: 309px; height: 41px;">&nbsp;</td>
            <td style="height: 41px">
                &nbsp;</td>
            <td style="height: 41px">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="GridView1" AutoGenerateSelectButton="true" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" runat="server" Height="277px" Width="1186px" style="margin-right: 0px">
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

