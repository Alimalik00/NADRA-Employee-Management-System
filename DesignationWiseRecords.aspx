<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DesignationWiseRecords.aspx.cs" Inherits="testweb.DesignationWiseRecords" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Records</title>
    <link href="style/DesignationWiseRecords.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <header>   
   <asp:Button ID="redirect" runat="server" Text="Home" CssClass="button" OnClick="redirectToHomePage_Click"/>
    </header>

        <br/><br/><br/><br/><br/>

        <h1>Employee Records - Designation Wise</h1>
    <div class="container">
        <h2>Select Designation:</h2>
        <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="form-control"></asp:DropDownList>
        <asp:Button ID="btnShowRecords" runat="server" Text="Show Records" CssClass="btn" OnClick="btnShowRecords_Click" />
    </div>
        <br /><br /><br />
    <div class="records-container">
        <asp:GridView ID="gvEmployeeRecords" runat="server" AutoGenerateColumns="False" CssClass="grid-view">
            <Columns>
                <asp:BoundField DataField="EmpID" HeaderText="Employee ID" HeaderStyle-BackColor="#66ccff" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" HeaderStyle-BackColor="#66ccff" />
                <asp:BoundField DataField="SecondName" HeaderText="Last Name" HeaderStyle-BackColor="#66ccff"/>
                <asp:BoundField DataField="Designation" HeaderText="Designation" HeaderStyle-BackColor="#66ccff"/>
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnExportCSV" runat="server" Text="Export to CSV" CssClass="btn" OnClick="btnExportCSV_Click" />
        <asp:Button ID="btnPrintReport" runat="server" Text="Print Report" CssClass="btn" OnClick="btnPrintReport_Click" />
    </div>

        <br /><br /><br /><br />
     <h1>Employee Records - Employee Type Wise</h1>
            <div class="container">
        <h2>Select Employee Type:</h2>
        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control"></asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Text="Show Records" CssClass="btn" OnClick="btnShowEmpTRecords_Click" />
    </div>
        <br /><br /><br />
    <div class="records-container">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="grid-view">
            <Columns>
                <asp:BoundField DataField="EmpID" HeaderText="Employee ID" HeaderStyle-BackColor="#66ccff" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" HeaderStyle-BackColor="#66ccff" />
                <asp:BoundField DataField="SecondName" HeaderText="Last Name" HeaderStyle-BackColor="#66ccff"/>
                <asp:BoundField DataField="EmpType" HeaderText="Employee Type" HeaderStyle-BackColor="#66ccff"/>
            </Columns>
        </asp:GridView>
        <asp:Button ID="Button2" runat="server" Text="Export to CSV" CssClass="btn" OnClick="btnExportEmptypeCSV_Click" />

    </div>


        </form>
</body>
</html>