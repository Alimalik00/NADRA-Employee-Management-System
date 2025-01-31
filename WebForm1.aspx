<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="testweb.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">


    


<%-------- HEAD STARTS ------%>
<head runat="server">
    <title>Employee Data Input</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <link rel="stylesheet" href="~/style/Nadra.css"> 
</head>
<%-----------------------------------------%>








<%-------- BODY STARTS ------%>
<body>



    <header>
<%-----------------------------------------------------------------------------------------------%>
    <button onclick="redirectToRecordsPage()">Show Records</button><br />
<%-----------------------------------------------------------------------------------------------%>
    </header> <br/><br/><br/><br/>










<%-------- INTERSECTING SECTION ------%>
    <div class="section">
        <br/><br/><br/><hr/>
    </div>
<%-----------------------------------%>

     <h1>Human Resource Department</h1>

<%-----------------------------------%>

<%-------- INTERSECTING SECTION ------%>
    <div class="section">
        <hr/>
    </div><br/>
<%-----------------------------------%>









<%--------------- IMAGE --------------------%>
    <div class="container">
        <div class="row">
            <br/><br/>
            <div class="col-md-12 text-center">
                <br/><br/><br/><br/>
                <img src="emp2.jpg" alt="Nadralogo"/>
            </div>
        </div>
    </div><br/><br/><br/><br/>
<%------------------------------------------%>






<%-------- INTERSECTING SECTION ------%>
    <div class="section">
        <hr/>
    </div><br/>
<%-----------------------------------%>

        <section>
        <br/>
    </section>
<%-----------------------------------%>




<%------------------------------------------- FORM STARTS ----------------------------------------------%>
    <h2>Enter Employee Details:</h2>

    <form runat="server" class="HRData" enctype="multipart/form-data">

        <label for= "EmpID" >Employee ID:</label>
        <input type="number" id="EmpID" name="employee_id" runat="server" required="required"/><br/><br/>

        <label for="FirstName">First Name:</label>
        <input type="text" id="FirstName" name="first_name" runat="server" maxlength="30" required/><br/>

        <label for="SecondName">Second Name:</label>
        <input type="text" id="SecondName" name="last_name" runat="server" required/><br/><br/>



<%------------------------------------------- RADIO BUTTON ---------------------------------------%>
        <label for="Gender">Gender:</label> <br/>
            <asp:RadioButtonList ID="genderRadioButtonList" type="radio" runat="server" Required="true">
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
            </asp:RadioButtonList><br/><br/>
<%------------------------------------------------------------------------------------------------%>




        <label for="DateOfBirth">Date Of Birth:</label>
        <input type= "date" id="DateOfBirth" name="Date_Of_Birth" runat="server" required/><br/><br/>

        <label for="CNIC">CNIC:</label>
        <input type="number" id="CNIC" name="cnic" runat="server" required/><br/><br/>

        <label for="EmpType">Employee Type:</label>
        <input type="text" id="EmpType" name="employee_type" runat="server" required/><br/>

        <label for="Salary">Salary:</label>
        <input type="number" id="Salary" name="salary" runat="server" required/><br/><br/>

        <label for="Address">Address:</label>
        <input type="text" id="Address" name="address" runat="server" required/><br/><br/>

        <label for="CellNo">Phone Number :</label>
        <input type="number" id="CellNo" name="cell_no" runat="server" required/><br/><br/>

        <label for="Designation">Designation:</label>
        <input type="text" id="Designation" name="designation" runat="server" required/><br/><br/>

        <label for="Scale">Scale:</label>
        <input type="text" id="scale" name="scale" runat="server" required/><br/><br/>

        <label for="EmergencyContactName">Emergency Contact Name:</label>
        <input type="text" id="EmergencyContactName" name="emergency_contact_name" runat="server"/><br/><br/>

        <label for="EmergencyContactNumber">Emergency Contact Number:</label>
        <input type="number" id="EmergencyContactNumber" name="emergency_contact_number" runat="server"/><br/><br/>

        <label for="EmployeeImage">Employee Image:</label>
        <asp:FileUpload ID="EmployeeImage" runat="server" />

        <br/><br/>
        <input type="submit" value="Submit" OnServerClick="SubmitButton_Click" runat="server" />


    </form><br/><br/>
      

<%----------------------------------------------------------------------------------------------------%>





<%--------------- FOOTER --------------------%>
<footer>
    <h8>
        National Database And Registration Authority - G-5 Islamabad
    </h8>
</footer>
<%-------------------------------------------%>





<%--------------- SCRIPTING -----------------%>

    <script>
       function redirectToRecordsPage() {
           window.location.href = "showRecord.aspx"
       }
    </script>

<%-------------------------------------------%>


    </body>
<%--------------- BODY ENDS -----------------%>

</html>