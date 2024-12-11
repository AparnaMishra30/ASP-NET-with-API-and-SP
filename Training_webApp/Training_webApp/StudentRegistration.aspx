<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentRegistration.aspx.cs" Inherits="Training_webApp.StudentRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        .container
        {
           /* justify-content:center;
            border: 1px solid #000;
            justify-items:center;
            align-items:baseline;
            width:auto;
            height:auto;*/

         
            justify-content: center;
            align-items: center;
            height: 80vh; /* This will not take the entire page height */
            margin: 0 auto;
              width: 400px; /* Set the width of the form */
            padding: 20px;
            border: 2px solid #000; /* Black border */
            border-radius: 10px; /* Rounded corners */
            box-shadow: 0 0 15px rgba(0, 0, 0, 0.1); /* Light shadow for effect */
            background-color: #f9f9f9;
        }
    </style>
    <script type="text/javascript">
            function toggleOtherDetails(dropdown) {
                var txtOtherDetails = document.getElementById('<%= txtdept.ClientID %>');
                var txtlbl = document.getElementById('<%= lbldept.ClientID %>');
    if (dropdown.value === "Other") {
        txtOtherDetails.style.display = "block";
        txtlbl.style.display = "block"// Show the textbox
        } 
        }
    </script>
    <title></title>
</head>
<body>
   
    
     <div class="container">
         <h3 style="text-align:center; ">STUDENT REGISTRATION</h3>
    <form id="form1" runat="server"><%-- style="border: 1px solid #000;  justify-items:center; margin-left:auto; margin-right:auto "--%>
        <div class="row" >
            <div class="col-sm-6" style="padding:5px ;">
                <label>Student Name</label>
                <asp:TextBox runat="server" ID="fname"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="fname" ForeColor="Red" ErrorMessage="Name is empty" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </div>
            <div class="col-sm-6" style="padding:5px ;">
                <label> Mobile Number</label>
                <asp:TextBox runat="server" ID="mob"></asp:TextBox>
                <asp:RegularExpressionValidator runat="server" ControlToValidate="mob" ValidationExpression="^[6-9]\d{9}$" ForeColor="Red" Text="invalid number"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="row">
            <div class="col
                
                
                
                
                " style="padding:5px ;">
                <label>DOB</label>
              <%--  <asp:Calendar runat="server" ID="cal"></asp:Calendar>--%>
                <asp:TextBox runat="server" ID="calender" TextMode="Date"></asp:TextBox>
                <asp:RangeValidator runat="server" ControlToValidate="calender" MaximumValue="2009-01-01" MinimumValue="2000-01-01" ForeColor="Red" Text="invalid year"></asp:RangeValidator>
            </div>
            <div class="col" style="padding:5px ;">
                <label>Gender</label>
             <%-- <div class="col-sm-3"><asp:RadioButton runat="server" ID="male" GroupName="gen" Text="Male" /></div>
               <div class="col-sm-3"><asp:RadioButton runat="server" ID="female" GroupName="gen" Text="Female" /></div>--%>
                <asp:RadioButtonList ID="gen" runat="server">
                    <asp:ListItem Text="male" Value="male"></asp:ListItem>
                    <asp:ListItem Text="female" Value="female"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6" style="padding:5px ;">
                <label>Category</label>
                <asp:DropDownList ID="cat" runat="server">
                       <asp:listitem Text="--select Category--" Value="0"></asp:listitem>
                    <asp:ListItem Text="GEN" Value="GEN"></asp:ListItem>
                    <asp:ListItem Text="EWS" Value="EWS"></asp:ListItem>
                    <asp:ListItem Text="OBC" Value="OBC"></asp:ListItem>
                    <asp:ListItem Text="SC" Value="SC"></asp:ListItem>
                    <asp:ListItem Text="ST" Value="ST"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-sm-6" style="padding:5px ;">
                <label>Department</label>
                    <asp:DropDownList ID="DropDownList2" runat="server" onchange="toggleOtherDetails(this)">
                    <%--<asp:listitem Text="--select dept--" Value="0"></asp:listitem>
                    <asp:ListItem Text="CSE" Value="1"></asp:ListItem>
                    <asp:ListItem Text="EE" Value="2"></asp:ListItem>
                    <asp:ListItem Text="ME" Value="3"></asp:ListItem>
                    <asp:ListItem Text="BM" Value="4"></asp:ListItem>
                    <asp:ListItem Text="CIVIL" Value="5"></asp:ListItem>
                    <asp:ListItem Text="EI" Value="6"></asp:ListItem>
                    <asp:ListItem Text="IT" Value="7"></asp:ListItem>
                    <asp:ListItem Text="IP" Value="8"></asp:ListItem>--%>
                </asp:DropDownList>
            </div>
        </div>


        <div class="row">
 <div class="col-sm-6" style="padding:5px ;">
     <asp:Label ID="lbldept" runat="server" Style="display:none;">Specify other</asp:Label>
     <asp:TextBox ID="txtdept" runat="server" placeholder="Specify other" style="display:none;"></asp:TextBox>
     </div></div>

         <div class="row">
            <div class="col" style="padding:5px ;">
                <label>Password</label>
                <asp:TextBox runat="server" ID="pswd"></asp:TextBox>
            </div>
            <div class="col" style="padding:5px ;">
                <label>Confirm Password</label>
                  <asp:TextBox runat="server" ID="conpswd" ></asp:TextBox>
                <asp:CompareValidator runat="server" ControlToValidate="conpswd" ControlToCompare="pswd" ForeColor="Red" Text="Pswd not matched"></asp:CompareValidator>
            </div>

               <div class="row">
            <div class="col-sm-6" style="padding:5px ;">
                <label>State</label>
                <asp:DropDownList ID="DDList5" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDList5_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="col-sm-6" style="padding:5px ;">
                <label>District</label>
                    <asp:DropDownList ID="DDList6" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        </div>

        <div class="row" style="padding:25px ; text-align:center;">
         <%--  <asp:Button ID="submit" Text="submit" runat="server" onclick="submit_Click" />--%>
            <asp:Button ID="submit" Text="Submit" runat="server" OnClick="submit_Click" Visible="false" />
            <asp:Button ID="clear" Text="Clear" runat="server" OnClick="clear_Click" />
            <asp:Button ID="back" Text="Back" runat="server" OnClick="back_Click" />
        </div>

           


        <div class="row" style="padding:25px ; text-align:center;">
          <asp:HyperLink runat="server" Text="LOGIN ?" NavigateUrl="~/Login.aspx" ForeColor="Blue"></asp:HyperLink>
       </div>
       
    </form>
        </div>
</body>
</html>
