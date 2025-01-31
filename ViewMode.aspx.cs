using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace testweb
{
    public partial class View_Mode : System.Web.UI.Page
    {
        private string empID;
        private string firstName;
        private string secondName;
        private string gender;
        private DateTime dateOfBirth;
        private string employeeType;
        private decimal salary;
        private string address;
        private string cellNo;
        private string cnic;
        private string designation;
        private string emergencyContactName;
        private string emergencyContactNumber;
        private string scale;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string empID = Request.QueryString["EmpID"];
                if (!string.IsNullOrEmpty(empID))
                {

                    FillForm(empID);
                    // Setting the values from class-level variables back to the text fields
                    ((TextBox)FindControl("lblEmpID")).Text = empID;
                    ((TextBox)FindControl("txtFirstName")).Text = firstName;
                    ((TextBox)FindControl("txtSecondName")).Text = secondName;
                    ((TextBox)FindControl("txtGender")).Text = gender;
                    ((TextBox)FindControl("txtDOB")).Text = dateOfBirth.ToString("yyyy-MM-dd");
                    ((TextBox)FindControl("txtEmpType")).Text = employeeType;
                    ((TextBox)FindControl("txtSalary")).Text = salary.ToString();
                    ((TextBox)FindControl("txtAddress")).Text = address;
                    ((TextBox)FindControl("txtCellNo")).Text = cellNo;
                    ((TextBox)FindControl("txtCNIC")).Text = cnic;
                    ((TextBox)FindControl("txtDesignation")).Text = designation;
                    ((TextBox)FindControl("txtEmergencyContactName")).Text = emergencyContactName;
                    ((TextBox)FindControl("txtEmergencyContactNumber")).Text = emergencyContactNumber;
                    ((TextBox)FindControl("txtScale")).Text = scale;


                    PostingTransferButton.CommandArgument = empID;
                    string imageUrl = GetImageURL(empID);
                    imgEmployee.Src = imageUrl;
                }
            }

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            // Redirect the user to the "EditRecord" page passing the EmpID as a query string parameter
            string empID = Request.QueryString["EmpID"];
            if (!string.IsNullOrEmpty(empID))
            {
                Response.Redirect($"editRecord.aspx?EmpID={empID}");
            }
        }

        private void FillForm(string empID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT EmpID, FirstName, SecondName, Gender, DateOfBirth, EmpType, Salary, Address, CellNo, CNIC, Designation, EmergencyContactName, EmergencyContactNumber, Scale FROM Nadra.dbo.EmpTable WHERE EmpID = @EmpID";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@EmpID", empID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Storing the retrieved values in the class-level variables
                            this.empID = reader["EmpID"].ToString();
                            firstName = reader["FirstName"].ToString();
                            secondName = reader["SecondName"].ToString();
                            gender = reader["Gender"].ToString();
                            dateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                            employeeType = reader["EmpType"].ToString();
                            salary = Convert.ToDecimal(reader["Salary"]);
                            address = reader["Address"].ToString();
                            cellNo = reader["CellNo"].ToString();
                            cnic = reader["CNIC"].ToString();
                            designation = reader["Designation"].ToString();
                            emergencyContactName = reader["EmergencyContactName"].ToString();
                            emergencyContactNumber = reader["EmergencyContactNumber"].ToString();
                            scale = reader["Scale"].ToString();
                        }
                        else
                        {
                            // No matching record found, redirecting to the showRecords page
                            Response.Redirect("showRecords.aspx");
                        }
                    }
                }
            }
        }


        protected string GetImageURL(object empId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT img FROM Nadra.dbo.EmpTable WHERE EmpID = @EmpID";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@EmpID", empId);
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        byte[] imageData = (byte[])result;

                        if (imageData != null && imageData.Length > 0)
                        {
                            // Convert the byte array to base64 string and create the image URL
                            string base64Image = Convert.ToBase64String(imageData);
                            return "data:image/jpeg;base64," + base64Image;
                        }
                    }
                }
            }

            // Returning a default image URL if no image data is found for the EmpID
            return "https://banffventureforum.com/wp-content/uploads/2019/08/No-Image.png";
        }
        protected void DisplayPostingTransferDetails(object sender, EventArgs e)
        {
            // Get the EmpID from the QueryString
            string empID = Request.QueryString["EmpID"];

            if (!string.IsNullOrEmpty(empID))
            {
                // Fetch the posting/transfer details from the database based on the Employee ID
                string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sqlQuery = "SELECT letterNumber, JobTitle, Division, Location, ReportingManager FROM Nadra.dbo.EmpTable WHERE EmpID = @empID";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@EmpID", empID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate the form fields in the popup with the fetched data
                                txtLetterNumber.Text = reader["letterNumber"].ToString();
                                txtJobTitle.Text = reader["JobTitle"].ToString();
                                txtDivision.Text = reader["Division"].ToString();
                                txtLocation.Text = reader["Location"].ToString();
                                txtReportingManager.Text = reader["ReportingManager"].ToString();



                            }
                        }
                    }
                }
                // Display the popup
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowPopup", "showPostingTransferDetails();", true);


            }


        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get the new values from the TextBoxes
            string newLetterNumber = TextBox5.Text;
            string newJobTitle = TextBox1.Text;
            string newDivision = TextBox2.Text;
            string newLocation = TextBox3.Text;
            string newReportingManager = TextBox4.Text;

            // Get the Employee ID from the lblEmpID TextBox (assuming it's present)
            int empId;
            if (!int.TryParse(lblEmpID.Text, out empId))
            {
                // Handle invalid Employee ID (optional)
                return;
            }

            // Define the connection string to your SQL Server database
            string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

            // SQL query to update the database with the new values
            string updateQuery = "UPDATE Nadra.dbo.EmpTable SET letterNumber = @letterNumber, JobTitle = @JobTitle, Division = @Division, Location = @Location, ReportingManager = @ReportingManager WHERE EmpID = @empId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    // Add parameters to the SQL query to prevent SQL injection
                    command.Parameters.AddWithValue("@letterNumber", newLetterNumber);
                    command.Parameters.AddWithValue("@JobTitle", newJobTitle);
                    command.Parameters.AddWithValue("@Division", newDivision);
                    command.Parameters.AddWithValue("@Location", newLocation);
                    command.Parameters.AddWithValue("@ReportingManager", newReportingManager);
                    command.Parameters.AddWithValue("@EmpID", empId);


                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Response.Write("<script>alert('Employee information updated successfully.');</script>");
                        Response.Redirect("showRecord.aspx");
                    }
                    else
                    {

                        Response.Write("<script>alert('Failed to update employee information.');</script>");
                    }
                }
            }
        }
       
        protected void docs_Click(object sender, EventArgs e)
        {
            // Get the EmpID from the QueryString
            string empID = Request.QueryString["EmpID"];

            if (!string.IsNullOrEmpty(empID))
            {
                // Fetch the documents from the database based on the Employee ID
                string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sqlQuery = "SELECT FileData, FileName FROM Nadra.dbo.EmployeeFiles WHERE EmpID = @empID";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@EmpID", empID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Clear any previous links in the documentLinksContainer
                            documentLinksContainer.InnerHtml = "";

                            while (reader.Read())
                            {
                                // Retrieve the file data, file type, and file name from the database
                                if (!reader.IsDBNull(reader.GetOrdinal("FileData")))
                                {
                                    byte[] fileData = (byte[])reader["FileData"];
                                    string fileName = reader["FileName"].ToString();

                                    if (fileData != null && fileData.Length > 0)
                                    {
                                        // Generate a unique ID for each download link
                                        string linkID = $"downloadLink_{Guid.NewGuid()}";

                                        // Convert the byte array to base64 string
                                        string base64FileData = Convert.ToBase64String(fileData);

                                        // Generate the download link and add it to the documentLinksContainer
                                        string downloadLink = $"<a id='{linkID}' href='#' onclick='downloadFile(\"{base64FileData}\", \"{fileName}\"); return false;'>{fileName}</a><br>";
                                        documentLinksContainer.InnerHtml += downloadLink;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

       
    }
}