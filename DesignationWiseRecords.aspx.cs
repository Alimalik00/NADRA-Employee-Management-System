using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Generic;
using Microsoft.Reporting.WebForms;

namespace testweb
{
    public partial class DesignationWiseRecords : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                LoadDesignations();
                LoadEmpType();
            }
        }

        protected void LoadDesignations()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT Designation FROM Nadra.dbo.Emptable";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    ddlDesignation.DataSource = reader;
                    ddlDesignation.DataTextField = "Designation";
                    ddlDesignation.DataBind();
                }
            }
        }


        protected void LoadEmpType()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT EmpType FROM Nadra.dbo.Emptable";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    DropDownList1.DataSource = reader;
                    DropDownList1.DataTextField = "EmpType";
                    DropDownList1.DataBind();
                }
            }
        }


        protected void btnShowRecords_Click(object sender, EventArgs e)
        {
            string selectedDesignation = ddlDesignation.SelectedItem.Text;
            LoadEmployeeRecords(selectedDesignation);
        }
        protected void btnShowEmpTRecords_Click(object sender, EventArgs e)
        {
            string selectedEmpType = DropDownList1.SelectedItem.Text;
            LoadEmployeeTypeRecords(selectedEmpType);
        }


        protected void LoadEmployeeRecords(string designation)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT EmpID, FirstName, SecondName, Designation FROM Nadra.dbo.Emptable WHERE Designation = @Designation";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Designation", designation);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    gvEmployeeRecords.DataSource = dataTable;
                    gvEmployeeRecords.DataBind();
                }
            }
        }


        protected void LoadEmployeeTypeRecords(string EmpType)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT EmpID, FirstName, SecondName, EmpType FROM Nadra.dbo.Emptable WHERE EmpType = @EmpType";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmpType", EmpType);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();
                }
            }
        }





        protected void redirectToHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("dashboard.aspx");
        }

        protected void btnExportCSV_Click(object sender, EventArgs e)
        {
            string selectedDesignation = ddlDesignation.SelectedItem.Text;
            DataTable dataTable = GetEmployeeRecords(selectedDesignation);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                string csv = GetCSVString(dataTable);
                ExportToCSV(csv);
            }
        }

        protected void btnExportEmptypeCSV_Click(object sender, EventArgs e)
        {
            string selectedEmpType = DropDownList1.SelectedItem.Text;
            DataTable dataTable = GetEmployeeTypeRecords(selectedEmpType);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                string csv = GetCSVString(dataTable);
                ExportToCSV(csv);
            }
        }


        protected DataTable GetEmployeeRecords(string designation)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT EmpID, FirstName, SecondName, Designation FROM Nadra.dbo.EmpTable WHERE Designation = @Designation";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Designation", designation);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        protected DataTable GetEmployeeTypeRecords(string Emptype)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT EmpID, FirstName, SecondName, Emptype FROM Nadra.dbo.EmpTable WHERE Emptype = @Emptype";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Emptype", Emptype);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }


        protected string GetCSVString(DataTable dataTable)
        {
            StringWriter writer = new StringWriter();
            foreach (DataColumn column in dataTable.Columns)
            {
                writer.Write(column.ColumnName + ",");
            }
            writer.WriteLine();
            foreach (DataRow row in dataTable.Rows)
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    writer.Write(row[i].ToString() + ",");
                }
                writer.WriteLine();
            }
            return writer.ToString();
        }

        protected void ExportToCSV(string csv)
        {
            string fileName = "EmployeeRecords_" + ".csv";
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
            Response.Charset = "";
            Response.ContentType = "application/text";
            Response.Output.Write(csv);
            Response.Flush();
            Response.End();
        }

        protected void btnPrintReport_Click(object sender, EventArgs e)
        {
            string selectedDesignation = ddlDesignation.SelectedItem.Text;
            DataTable dataTable = GetEmployeeRecords(selectedDesignation);


            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                // Prepare the report data source
                ReportDataSource rds = new ReportDataSource("EmployeeDataSet", dataTable);



               


                DataSet1 DataSet2 = new DataSet1();


                DataTable dt = dataTable;

                DataSet2.EnforceConstraints = false;

                DataSet2.Tables["Emptable"].Merge(dt);

                ReportDataSource datasource = new ReportDataSource("DataSet1", DataSet2.Tables["EmpTable"]);
                /*
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report1.rdlc");

                ReportViewer1.LocalReport.DataSources.Add(datasource);

                ReportViewer1.LocalReport.Refresh();

                Response.End();

                
                Set up the ReportViewer control
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.LocalReport.ReportPath = Server.MapPath("Report1.rdlc");
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(rds);
                reportViewer.LocalReport.Refresh();

                 Render the report as PDF
                 byte[] reportBytes = reportViewer.LocalReport.Render("PDF");

                 Send the PDF to the client for printing
                Response.Clear();
                 Response.ContentType = "application/pdf";
                 Response.AddHeader("Content-Disposition", "inline; filename=EmployeeReport.pdf");
                 Response.BinaryWrite(reportBytes);
                reportViewer.Dispose();
                */
            }
        }
    }
}
