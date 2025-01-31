<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/editRecord.aspx.cs" Inherits="testweb.EditRecord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">


<head runat="server">
    <link href="style/editRecord.css" rel="stylesheet" />
    <title>edit record</title>

     <script type="text/javascript">
         function confirmUpdate() {
             return confirm("Are you sure you want to update this record?");
         }
        
         function toggleFileUpload() {
             var fileUploadContainer = document.getElementById("fileUploadContainer");
             var isVisible = fileUploadContainer.style.display === "block";
             fileUploadContainer.style.display = isVisible ? "none" : "block";
         }
         function redirectToHomePage() {
             window.location.href = "WebForm1.aspx";
         }

     </script>

</head>


<body>


    <header>
    <Button onclick="redirectToHomePage()"> Home </Button>
    </header>
    
    <br/><br/><br/><br/><br/><br/><br/><br/><br/>

<%-------- INTERSECTING SECTION ------%>
    <div class="section">
        <hr/>
    </div>
<%-----------------------------------%>


        <h1>Edit Employee Record</h1>

<%-----------------------------------%>


<%-------- INTERSECTING SECTION ------%>
    <div class="section">
        <hr/>
    </div><br/>
<%-----------------------------------%>


            <br/><br/><br/><br/>



    <div class="container">
        <form runat="server" class="edit-form">

             <div class="form-group">
        <img id="imgEmployee" runat="server" height="200" width="200" />
    </div>

            <div class="form-group">
                <label for="EmpID">Employee ID:</label>
                <asp:TextBox ID="lblEmpID" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="FirstName">First Name:</label>
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="SecondName">Second Name:</label>
                <asp:TextBox ID="txtSecondName" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="Gender">Gender:</label>
                <asp:TextBox ID="txtGender" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="DateOfBirth">D-O-B:</label>
                <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="EmpType">Employee Type:</label>
                <asp:TextBox ID="txtEmpType" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="Salary">Salary:</label>
                <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="Address">Address:</label>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>


            <div class="form-group">
                <label for="CellNo">Cell No:</label>
                <asp:TextBox ID="txtCellNo" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="CNIC">CNIC:</label>
                <asp:TextBox ID="txtCNIC" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="Designation">Designation:</label>
                <asp:TextBox ID="txtDesignation" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="EmergencyContactName">Emergency Contact Name:</label>
                <asp:TextBox ID="txtEmergencyContactName" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="EmergencyContactNumber">Emergency Contact Number:</label>
                <asp:TextBox ID="txtEmergencyContactNumber" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="Scale">Scale:</label>
                <asp:TextBox ID="txtScale" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>

            <label for="EmployeeImage">Employee Image:</label>
        <asp:FileUpload ID="EmployeeImage" runat="server" />

            <br/><br/><br/>

            <asp:Button ID="btnUpdate" runat="server" Text="Update"  OnClientClick="return confirmUpdate();" OnClick="btnUpdate_Click" CssClass="btn btn-primary" />
            <button type="button" id="uploadDocBtn" class="btn btn-primary" onclick="toggleFileUpload()">Upload Document</button> <br />
            <br />
<div id="fileUploadContainer" style="display: none;">
    <Label for ="fileName">File Name:</Label>
    <asp:TextBox ID="fileName" runat="server" CssClass="form-control" required></asp:TextBox>
    <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" />
    <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-primary" OnClick="uploadDoc_Click" />
</div>
                <asp:Label ID="successLabel" runat="server" Text="Uploaded Successfully" Visible="false"></asp:Label>
                <asp:Label ID="errorLabel" runat="server" Text="Please select one or more files to upload." Visible="false"></asp:Label>


            </form>
    </div>
</body>

   


</html>
