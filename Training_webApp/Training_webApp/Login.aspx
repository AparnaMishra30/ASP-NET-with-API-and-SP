<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Training_webApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <style>
        /*.container
        {
         
            justify-content: center;
            align-items: center;
            height: 40vh;*/ /* This will not take the entire page height */
            /*margin: 0 auto;
              width: 250px;*/ /* Set the width of the form */
            /*padding: 20px;
            border: 2px solid #000;*/ /* Black border */
            /*border-radius: 10px;*/ /* Rounded corners */
            /*box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);*/ /* Light shadow for effect */
            /*background-color: #f9f9f9;
        }*/
         .container
         {
    
            justify-content: center;
            align-items: center;
            margin: 0 auto;
            height: 100%;
             padding: 20px;
            width: 300px;
            text-align: center;
            border: 2px solid #000; /* Black border */
            border-radius: 10px; /* Rounded corners */
            box-shadow: 0 0 15px rgba(0, 0, 0, 0.1); /* Light shadow for effect */
            background-color: #f9f9f9;
         }
    </style>
    <title> 
    </title>
</head>
<body>
     <div class="container">
         <h3 style="text-align:center; ">Login</h3>
    <form id="form1" runat="server"> 
        <div class="row" >
            <div class="col-sm-6" style="padding:2px ;">
                <label>Username</label>
                <asp:TextBox runat="server" ID="fname"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="fname" ForeColor="Red" Text="* required" ErrorMessage="UserName is empty"></asp:RequiredFieldValidator>
            </div>
            <div class="col-sm-6" style="padding:2px ;">
                <label>Password</label>
                <asp:TextBox runat="server" ID="pswd" TextMode="Password"></asp:TextBox>
            </div>
        </div>
        
    
        <div class="row" style="padding:25px ; text-align:center;">
           <asp:Button ID="submit" Text="submit" runat="server" onclick="submit_Click"/>
            <asp:Button ID="clear" Text="clear" runat="server" OnClick="clear_Click" />
        </div>
        <div class="row">
            <asp:HyperLink runat="server" Text="Not Registered?" NavigateUrl="~/StudentRegistration.aspx" ForeColor="Blue"></asp:HyperLink>
        </div>
    </form>
        </div>
</body>
</html>

