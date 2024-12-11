<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="userreport.aspx.cs" Inherits="Training_webApp.userreport" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
   <style>
      
         th
        {
            background: #337ab7;
            color: #fff;
        }
         /*.card{
        font-size:x-large;
            place-items:center;
            box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);*/ /* Light shadow for effect */
            /*background-color: #f9f9f9;
            padding:10px;
            margin-left:150px;
           
         }*/

        /*.table > tbody > tr > th, table.dataTable > tbody > tr > th
        {
            padding: 5px 5px;
        }*/

        #ContentPlaceHolder1_gridd {
        
             font-size: 14px;
             padding:1px;
        }

        #ContentPlaceHolder1_gridd_filter {
            padding-right: 7px !important;
           /* text-align: left;*/
        }

            #ContentPlaceHolder1_gridd_filter label {
                /*text-align: left;*/
                font-size: 10px;
            }
        /*#ContentPlaceHolder_GrvProgramParticipant_filter input{
            width: 60%;
        }*/
  #ContentPlaceHolder1_griddt_length label {
            /*display: inline-flex;*/
            font-size: 2px;
        }

            #ContentPlaceHolder1_gridd_length label > select {
                display: inline-block;
                position: absolute;
                width: 25px;
                top: 20px;
            }
           .row{
               font-weight:100;
           }
   </style>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        $(document).ready(function () {
            DisplayUser();
        });
        function DisplayUser() {
            $(".dataTable").DataTable(
                {
                    bLengthChange: true,
                    lengthMenu: [[5, 10, 15, -1], [5, 10, 15, "All"]],
                    bFilter: true,
                    bSort: true,
                    bPaginate: true,
                    responsive: true,
                    bDestroy: true
                }
            );
        }
    </script>
<%--    <div class="card" style="text-align: center">--%>
      <div class="header" style="text-align: center"> <h3> Total Student List</h3></div> 
    <asp:GridView ID="gridd" runat="server" AutoGenerateColumns="false" CssClass="table dataTable" OnRowEditing="gridd_RowEditing" OnRowUpdating="gridd_RowUpdating" OnRowCancelingEdit="gridd_RowCancelingEdit" OnRowDeleting="gridd_RowDeleting1">
         <Columns>
             <asp:TemplateField HeaderText="Sr.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
             <asp:TemplateField HeaderText="ID">
                       <ItemTemplate>
                            <asp:Label ID="Labelid" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                       </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="Name">
                      
                 <EditItemTemplate>
                     <asp:TextBox ID="editname" runat="server" Text='<%# Bind("fname") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("fname") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>

              <asp:TemplateField HeaderText="Mobile No">
                  <EditItemTemplate>
                     <asp:TextBox ID="editmob" runat="server" Text='<%# Bind("mob")%>'></asp:TextBox>
                 </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("mob")%>'></asp:Label>
                        </ItemTemplate></asp:TemplateField>

              <asp:TemplateField HeaderText="DOB">
                  <EditItemTemplate>
                     <asp:TextBox ID="editdob" runat="server" Text='<%# Bind("calender")%>'></asp:TextBox>
                 </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("calender")%>'></asp:Label>
                        </ItemTemplate></asp:TemplateField>

              <asp:TemplateField HeaderText="Gender">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("gen")%>'></asp:Label>
                        </ItemTemplate></asp:TemplateField>

               <asp:TemplateField HeaderText="Category">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("cat")%>'></asp:Label>
                        </ItemTemplate></asp:TemplateField>

               <asp:TemplateField HeaderText="Department">
                        <ItemTemplate>
                            <asp:Label ID="Department" runat="server" Text='<%# Bind("Department")%>'></asp:Label>
                        </ItemTemplate></asp:TemplateField>   
           
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                      <div class="row"><asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" /></div>
                      <div class="row"><asp:Button ID="btn_delete" runat="server" Text="delete" CommandName="delete" /></div>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/><asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>
                    </EditItemTemplate>
                </asp:TemplateField>
                            </Columns>
    </asp:GridView>
        <div class="button"><asp:Button ID="Btn" Text="Exit" runat="server" OnClick="Btn_Click" BackColor="#337ab7" BorderColor="#337ab7"/>
        <asp:Button ID="prnt" Text="Print" runat="server" BackColor="#337ab7" BorderColor="#337ab7" />
        </div><%--</div>--%>
</asp:Content>

