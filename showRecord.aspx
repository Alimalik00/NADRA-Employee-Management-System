<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/showRecord.aspx.cs" Inherits="testweb.showRecords" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Records</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="~/style/showRecords.css"/>

    <script>
        function redirectToHomePage() {
            window.location.href = "dashboard.aspx";
        }
    </script>
</head>



<body>




<header>
    <Button onclick="redirectToHomePage()"> Home </Button>
</header>




    <form runat="server">



<%-------- INTERSECTING SECTION ------%>
    <div class="section">
        <br/><br/><br/><hr/>
    </div>
<%-----------------------------------%>



        <h1>Employee Records</h1>

<%-------- INTERSECTING SECTION ------%>
    <div class="section">
        <hr/><br/><br/><br/>
    </div>
<%-----------------------------------%>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" HeaderStyle-BackColor="#2cba36">
            <Columns>


                <asp:TemplateField HeaderText="Sr. No.">
            <ItemTemplate>
             <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
        </asp:TemplateField>


                <asp:BoundField DataField="EmpID" HeaderText="EmpID"/>
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="SecondName" HeaderText="Second Name" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                <asp:BoundField DataField="DateOfBirth" HeaderText="Date of Birth" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="EmpType" HeaderText="Employee Type" />
                <asp:BoundField DataField="Salary" HeaderText="Salary" DataFormatString="&#x20A8;{0:n}" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="CellNo" HeaderText="Phone Number" />
                <asp:BoundField DataField="CNIC" HeaderText="CNIC" />
                <asp:BoundField DataField="Designation" HeaderText="Designation" />
                <asp:BoundField DataField="EmergencyContactName" HeaderText="Emergency Contact Name" />
                <asp:BoundField DataField="EmergencyContactNumber" HeaderText="Emergency Contact Number" />
                <asp:BoundField DataField="Scale" HeaderText="Scale" />


                <asp:TemplateField HeaderText="Edit/View">
            <ItemTemplate>
                <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="EditRow" CommandArgument='<%# Eval("EmpID") %>' OnClick="btnEdit_Click" />
                <br /><br />
                <asp:Button ID="btnView" runat="server" Text="View" CommandName="ViewRow" CommandArgument='<%# Eval("EmpID") %>' OnClick="btnView_Click" />

                </ItemTemplate>
        </asp:TemplateField>

                

            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
