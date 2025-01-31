<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewMode.aspx.cs" Inherits="testweb.View_Mode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="style/ViewMode.css" rel="stylesheet" />
    <title>View</title>


    <script type="text/javascript">
    function showPostingTransferDetails() {
        // Get the reference to the popup div
        var popup = document.getElementById("postingTransferPopup");

        // Display the popup
        popup.style.display = "block";
    }

    function hidePostingTransferDetails() {
        // Get the reference to the popup div
        var popup = document.getElementById("postingTransferPopup");

        // Hide the popup
        popup.style.display = "none";
        }

    function showTransferEmployeePopup() {
        // Get the reference to the popup div
        var popup = document.getElementById("TransferEmployeePopup");

        // Display the popup
        popup.style.display = "block";
        }
        function downloadFile(base64FileData, fileName) {
            const byteCharacters = atob(base64FileData);
            const byteArrays = [];

            for (let offset = 0; offset < byteCharacters.length; offset += 512) {
                const slice = byteCharacters.slice(offset, offset + 512);

                const byteNumbers = new Array(slice.length);
                for (let i = 0; i < slice.length; i++) {
                    byteNumbers[i] = slice.charCodeAt(i);
                }

                const byteArray = new Uint8Array(byteNumbers);
                byteArrays.push(byteArray);
            }

            const blob = new Blob(byteArrays, { type: 'application/octet-stream' });
            const url = URL.createObjectURL(blob);

            const a = document.createElement('a');
            a.href = url;
            a.download = fileName;
            a.click();

            URL.revokeObjectURL(url);
        }

      
            function redirectToHomePage() {
                window.location.href = "dashboard.aspx";
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


        <h1>Viewing Employee Record</h1>

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

                <div class="center">
        <img id="imgEmployee" runat="server" height="200" width="200" />
    </div>
                <br /><br />
                <label for="EmpID">Employee ID:</label>
                <asp:TextBox ID="lblEmpID" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="FirstName">First Name:</label>
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="SecondName">Second Name:</label>
                <asp:TextBox ID="txtSecondName" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="Gender">Gender:</label>
                <asp:TextBox ID="txtGender" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="DateOfBirth">D-O-B:</label>
                <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="EmpType">Employee Type:</label>
                <asp:TextBox ID="txtEmpType" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="Salary">Salary:</label>
                <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="Address">Address:</label>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>


            <div class="form-group">
                <label for="CellNo">Cell No:</label>
                <asp:TextBox ID="txtCellNo" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="CNIC">CNIC:</label>
                <asp:TextBox ID="txtCNIC" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="Designation">Designation:</label>
                <asp:TextBox ID="txtDesignation" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="EmergencyContactName">Emergency Contact Name:</label>
                <asp:TextBox ID="txtEmergencyContactName" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="EmergencyContactNumber">Emergency Contact Number:</label>
                <asp:TextBox ID="txtEmergencyContactNumber" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="Scale">Scale:</label>
                <asp:TextBox ID="txtScale" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>


  <%------------------------------------------------BUTTONS----------------------------------------------------------%>

            <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn-edit" OnClick="btnEdit_Click" /><br />
            <asp:Button ID="PostingTransferButton" runat="server" Text="Posting/Transfer Details" CssClass="btn-edit" OnClick="DisplayPostingTransferDetails" /><br />
             <asp:Button ID="docs" runat="server" Text="View Documents" CssClass="btn-edit" OnClick="docs_Click"/>

 <%----------------------------------------------------------------------------------------------------------%>
            <br />
<div id="documentLinksContainer" runat="server" class="document-links-container"></div>
<asp:Label ID="lblNoFileMessage" runat="server" Text="There are no files for this employee." Visible="false" />
 <%----------------------------------------POSTING TRANSFER POPUP----------------------------------------------------------%>




            <div id="postingTransferPopup" class="popup" style="display: none;">
    <h2>Posting/Transfer Details</h2>
                    <div class="form-group">
        <label for="CurrentLetterNumber">Letter Number:</label>
        <asp:TextBox ID="txtLetterNumber" runat="server" CssClass="form-control" Enabled="false" ClientIDMode="Static"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="CurrentJobTitle">Current Job Title:</label>
        <asp:TextBox ID="txtJobTitle" runat="server" CssClass="form-control" Enabled="false" ClientIDMode="Static"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="CurrentDivision">Current Division:</label>
        <asp:TextBox ID="txtDivision" runat="server" CssClass="form-control" Enabled="false" ClientIDMode="Static"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="CurrentLocation">Current Location:</label>
        <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control" Enabled="false" ClientIDMode="Static"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="CurrentReportingManager">Current Reporting Manager:</label>
        <asp:TextBox ID="txtReportingManager" runat="server" CssClass="form-control" Enabled="false" ClientIDMode="Static"></asp:TextBox>
    </div>

    <button onclick="hidePostingTransferDetails()">Close</button>
    <asp:Button ID="btnTransferEmployee" runat="server" Text="Transfer Employee" CssClass="btn-edit" OnClientClick="showTransferEmployeePopup(); return false;" />


</div>
            
<%----------------------------------------------------------------------------------------------------------%>


 <%-------------------------------------TransferEmployeePopup-----------------------------------------------%>

     <div id="TransferEmployeePopup" class="popup" style="display: none;">
    <h2>Posting/Transfer Details</h2>

                 <div class="form-group">
        <label for="newLetterNumber">Letter Number:</label>
        <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" Enabled="true"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="newJobTitle">New Job Title:</label>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Enabled="true"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="newDivision">New Division:</label>
        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Enabled="true"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="newLocation">New Location:</label>
        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" Enabled="true"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="newReportingManager">New Reporting Manager:</label>
        <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" Enabled="true"></asp:TextBox>
    </div>

         <div class="this-buttons">
    <button onclick="hidePostingTransferDetails()">Close</button>
    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn-edit" OnClick="btnUpdate_Click " />
             </div>
</div>

<%----------------------------------------------------------------------------------------------------------%>

        </form>
    </div>

    

</body>


</html>
