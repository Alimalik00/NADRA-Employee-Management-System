using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.IO;
using System.Web;

namespace testweb
{
    public partial class EditRecord : System.Web.UI.Page
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
                    FillEditForm(empID);

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

                    string imageUrl = GetImageURL(empID);
                    imgEmployee.Src = imageUrl;


                }
                else
                {
                    Response.Redirect("showRecords.aspx");
                }
            }
        }

        

        private void FillEditForm(string empID)
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
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Using the stored values from the class-level variables
            empID = ((TextBox)FindControl("lblEmpID")).Text;
            firstName = ((TextBox)FindControl("txtFirstName")).Text;
            secondName = ((TextBox)FindControl("txtSecondName")).Text;
            gender = ((TextBox)FindControl("txtGender")).Text;
            dateOfBirth = DateTime.Parse(((TextBox)FindControl("txtDOB")).Text);
            employeeType = ((TextBox)FindControl("txtEmpType")).Text;
            salary = decimal.Parse(((TextBox)FindControl("txtSalary")).Text);
            address = ((TextBox)FindControl("txtAddress")).Text;
            cellNo = ((TextBox)FindControl("txtCellNo")).Text;
            cnic = ((TextBox)FindControl("txtCNIC")).Text;
            designation = ((TextBox)FindControl("txtDesignation")).Text;
            emergencyContactName = ((TextBox)FindControl("txtEmergencyContactName")).Text;
            emergencyContactNumber = ((TextBox)FindControl("txtEmergencyContactNumber")).Text;
            scale = ((TextBox)FindControl("txtScale")).Text;

            byte[] imageData = null;

            if (EmployeeImage.HasFile)
            {
                using (BinaryReader binaryReader = new BinaryReader(EmployeeImage.PostedFile.InputStream))
                {
                    imageData = binaryReader.ReadBytes(EmployeeImage.PostedFile.ContentLength);
                }
            }
            else
            {
                string errorMessage = "An error occurred while updating the record. Please try again.";
                string script = $"alert('{errorMessage}');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "UpdateError", script, true);

            }

            // Performing the update operation in the database
            string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "UPDATE Nadra.dbo.EmpTable SET FirstName = @FirstName, SecondName = @SecondName, Gender = @Gender, DateOfBirth = @DateOfBirth, EmpType = @EmpType, Salary = @Salary, Address = @Address, CellNo = @CellNo, CNIC = @CNIC, Designation = @Designation, EmergencyContactName = @EmergencyContactName, EmergencyContactNumber = @EmergencyContactNumber, Scale = @Scale, img = @img WHERE EmpID = @EmpID";

                connection.Open();

                
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@EmpID", empID);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@SecondName", secondName);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                    command.Parameters.AddWithValue("@EmpType", employeeType);
                    command.Parameters.AddWithValue("@Salary", salary);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@CellNo", cellNo);
                    command.Parameters.AddWithValue("@CNIC", cnic);
                    command.Parameters.AddWithValue("@Designation", designation);
                    command.Parameters.AddWithValue("@EmergencyContactName", emergencyContactName);
                    command.Parameters.AddWithValue("@EmergencyContactNumber", emergencyContactNumber);
                    command.Parameters.AddWithValue("@Scale", scale);
                    command.Parameters.AddWithValue("@img", imageData);

                    
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Update successful, redirecting to the showRecords page
                        Response.Redirect("showRecord.aspx");
                    }
                    else
                    {
                        string errorMessage = "An error occurred while updating the record. Please try again.";
                        string script = $"alert('{errorMessage}');";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "UpdateError", script, true);
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

        protected void uploadDoc_Click(object sender, EventArgs e)
        {
            // Get the EmpID from the QueryString
            string empID = Request.QueryString["EmpID"];

            if (!string.IsNullOrEmpty(empID) && FileUpload1.HasFiles)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Looping through each uploaded file and save it to the database
                    foreach (HttpPostedFile uploadedFile in FileUpload1.PostedFiles)
                    {
                        // Getting the file data
                        byte[] fileData = new byte[uploadedFile.ContentLength];
                        string filename = uploadedFile.FileName;
                        uploadedFile.InputStream.Read(fileData, 0, uploadedFile.ContentLength);

                        // Save the file data to the database along with the EmpID
                        string sqlQuery = "INSERT INTO Nadra.dbo.EmployeeFiles (EmpID, FileData, FileName) VALUES (@EmpID, @FileData, @FileName)";
                        using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                        {
                            command.Parameters.AddWithValue("@EmpID", empID);
                            command.Parameters.AddWithValue("@FileData", fileData);
                            command.Parameters.AddWithValue("@FileName", filename);

                            command.ExecuteNonQuery();
                        }
                    }
                }

                
                successLabel.Text = "Files uploaded successfully!";
                successLabel.Visible = true;
                errorLabel.Visible = false;
            }
            else
            {
                
                errorLabel.Text = "Please select one or more files to upload.";
                errorLabel.Visible = true;
                successLabel.Visible = false;
            }
        }

    }
}

