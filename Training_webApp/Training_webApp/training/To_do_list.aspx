<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="To_do_list.aspx.cs" Inherits="Training_webApp.training.To_do_list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

          <asp:Label runat="server" ID="lblmsg" ></asp:Label>       
        <div>
            <h4>To do list</h4>
            <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
            <asp:Button ID="btnsubmit" Text="submit" runat="server" OnClick="btnsubmit_Click" />
            <asp:Button ID="btnupdate" Text="update" runat="server" OnClick="btnupdate_Click"/>
              <asp:Label runat="server" ID="lblTaskId"  Visible="false" />
        </div>



          <asp:GridView ID="gridd" runat="server" AutoGenerateColumns="false">
<Columns>
    <asp:TemplateField>
        <ItemTemplate>
            <asp:Label ID="id" Text='<%#Eval("Id")%>' runat="server"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField>
       <ItemTemplate>
           <asp:Label ID="Name" Text='<%#Eval("Name")%>' runat="server"></asp:Label>
       </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField>
        <ItemTemplate>
            <asp:Button ID="btnedit" OnClick="btnedit_Click" Text="edit" runat="server" />
            <asp:Button runat="server" ID="btndelete" Text="Delete" OnClick="btndelete_Click" />
        </ItemTemplate>
    </asp:TemplateField>
</Columns>
    </asp:GridView>
   
    </form>
  
</body>
</html>
