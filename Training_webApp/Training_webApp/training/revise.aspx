<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="revise.aspx.cs" Inherits="Training_webApp.training.revise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="card" style="text-align: center">
              <div class="header" style="text-align: center"> <h5> Upload Document</h5></div> 
         <div class="container" style="text-align: center"> 
             <div><asp:FileUpload ID="flup" runat="server"/>
                  <asp:Button runat="server" Text="upload" ID="upload" OnClick="upload_Click"/>
             </div>
           <div><asp:Label runat="server" ID="lblfile"></asp:Label></div></div>
       </div>
   
   
</asp:Content>
