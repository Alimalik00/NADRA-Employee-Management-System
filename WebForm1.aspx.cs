using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.IO;


namespace testweb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private SqlConnection connection;

        protected void Page_Load(object sender, EventArgs e)
        {
        
        }


        protected void SubmitButton_Click(object sender, EventArgs e)

        {



            string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the database connection
                    connection.Open();

                    // Insert data into the database using parameterized query
                    string sqlQuery = "INSERT INTO Nadra.dbo.EmpTable (EmpID, FirstName, SecondName, Gender, DateOfBirth, EmpType, Salary, Address, CellNo, CNIC, Designation, EmergencyContactName, EmergencyContactNumber, Scale, img) VALUES (@EmployeeID, @FirstName, @SecondName, @Gender, @DateOfBirth, @EmployeeType, @Salary,  @Address,  @CellNo, @CNIC,   @Designation,  @EmergencyContactName, @EmergencyContactNumber, @Scale, @img)";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        // Get form data from input controls
                        int employeeId = int.Parse(EmpID.Value);

                        string firstName = FirstName.Value;
                        if (firstName.Length > 30)
                        {
                            Response.Write("<span style='color: red;'>Invalid First Name Length. Please check and try again.</span>");
                            return;
                        }

                        string SName = SecondName.Value;
                        if (SName.Length > 30)
                        {
                            Response.Write("<span style='color: red;'>Invalid Second Name Length. Please enter salary above ZERO.</span>");
                            return;
                        }

                        string gender = genderRadioButtonList.SelectedValue;

                        DateTime dateOfBirth = DateTime.Parse(DateOfBirth.Value);


                        string employeeType = EmpType.Value;
                        if (employeeType.Length > 20)
                        {
                            Response.Write("<span style='color: red;'>Invalid Employee type.Please check and try again.</span>");
                            return;
                        }


                        float salary = float.Parse(Salary.Value);
                        string sal = salary.ToString();
                        if (sal.Length < 0)
                        {
                            Response.Write("<span style='color: red;'>Invalid Salary. Please enter salary above ZERO.</span>");
                            return;
                        }



                        string address = Address.Value;
                        if (address.Length > 50)
                        {
                            Response.Write("<span style='color: red;'>Invalid address length. Please enter a shorter address.</span>");
                            return;
                        }

                        string cellNumber = CellNo.Value;
                        if (cellNumber.Length != 11)
                        {
                            Response.Write("<span style='color: red;'>Invalid Phone Number length. Please enter a 11-digit Phone Number.</span>");
                            return;
                        }


                        string cnic = CNIC.Value;
                        if (cnic.Length != 13)
                        {
                            Response.Write("<span style='color: red;'>Invalid CNIC length. Please enter a 13-digit CNIC number.</span>");
                            return;
                        }


                        string designation = Designation.Value;
                        if (designation.Length > 30)
                        {
                            Response.Write("<span style='color: red;'>Invalid designation. Please check and try again.</span>");
                            return;
                        }

                        string emergencyContactName = EmergencyContactName.Value;
                        if (emergencyContactName.Length > 50)
                        {
                            Response.Write("<span style='color: red;'>Invalid Name. Please check and try again.</span>");
                            return;
                        }

                        string emergencyContactNumber = EmergencyContactNumber.Value;
                        if (emergencyContactNumber.Length != 11)
                        {
                            Response.Write("<span style='color: red;'>Invalid Phone Number length. Please enter a 11-digit Phone Number.</span>");
                            return;
                        }
                        string scle = scale.Value;
                        if (scle.Length > 20)
                        {
                            Response.Write("<span style='color: red;'>Invalid Scale. Please check and try again.</span>");
                            return;
                        }

                    byte[] imageData = null;

                        if (EmployeeImage.HasFile)
                        {
                            using (BinaryReader binaryReader = new BinaryReader(EmployeeImage.PostedFile.InputStream))
                            {
                                imageData = binaryReader.ReadBytes(EmployeeImage.PostedFile.ContentLength);
                            }
                        }



                    // Add parameters to the query
                    command.Parameters.AddWithValue("@EmployeeID", employeeId);
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@SecondName", SName);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                        command.Parameters.AddWithValue("@EmployeeType", employeeType);
                        command.Parameters.AddWithValue("@Salary", salary);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@CellNo", cellNumber);
                        command.Parameters.AddWithValue("@CNIC", cnic);
                        command.Parameters.AddWithValue("@Designation", designation);
                        command.Parameters.AddWithValue("@EmergencyContactName", emergencyContactName);
                        command.Parameters.AddWithValue("@EmergencyContactNumber", emergencyContactNumber);
                        command.Parameters.AddWithValue("@Scale", scle);
                        command.Parameters.AddWithValue("@Img", imageData);

                        // Execute the query
                        int affected = command.ExecuteNonQuery();

                        if (affected > 0)
                        {
                            Response.Write("<span style='color: red;'>Data Entered Successfully!</span>");
                        }
                        else
                        {
                            Response.Write("An error occured while inserting data. Please try again");
                        }


                        EmpID.Value = string.Empty;
                        FirstName.Value = string.Empty;
                        SecondName.Value = string.Empty;
                        genderRadioButtonList.ClearSelection();
                        DateOfBirth.Value = string.Empty;
                        EmpType.Value = string.Empty;
                        Salary.Value = string.Empty;
                        Address.Value = string.Empty;
                        CellNo.Value = string.Empty;
                        CNIC.Value = string.Empty;
                        Designation.Value = string.Empty;
                        EmergencyContactName.Value = string.Empty;
                        EmergencyContactNumber.Value = string.Empty;
                        scale.Value = string.Empty;
                        EmployeeImage.Attributes.Clear();
                    }
                }
        }
    }
}
