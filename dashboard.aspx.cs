using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public class EmployeeData
{
    public string Location { get; set; }
    public int Count { get; set; }
}

namespace testweb
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillTotalEmployees();
                fillAvgSal();
                litlocations.Text = "398";
                litTransfer.Text = "1 this week";
                litdepartments.Text = "22";
            }
        }
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }

        protected void SubmitAButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("showRecord.aspx");
        }
        protected void SubmitBButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("DesignationWiseRecords.aspx");
        }


        protected void fillTotalEmployees()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the database connection
                connection.Open();

                string sqlQuery = "SELECT COUNT(*) AS EmpID FROM Nadra.dbo.EmpTable";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    int totalEmployees = (int)command.ExecuteScalar();
                    // Set the value to the literal
                    litTotalEmployees.Text = totalEmployees.ToString();
                }
            }
        }

        protected void fillAvgSal()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the database connection
                connection.Open();

                string sqlQuery = "SELECT AVG(Salary) AS AvgSalary FROM Nadra.dbo.EmpTable";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            decimal avgSalary = reader.GetDecimal(reader.GetOrdinal("AvgSalary"));
                            litAverageSalary.Text = avgSalary.ToString("C", new CultureInfo("en-PK"));             
                        }
                    }
                }
            }
        }

        [System.Web.Services.WebMethod]
        public static List<EmployeeData> GetEmployeeData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            List<EmployeeData> employeeData = new List<EmployeeData>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT Location, COUNT(*) AS Count FROM Nadra.dbo.EmpTable GROUP BY Location";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int locationOrdinal = reader.GetOrdinal("Location");
                        string location = reader.IsDBNull(locationOrdinal) ? string.Empty : reader.GetString(locationOrdinal);

                        int count = reader.GetInt32(reader.GetOrdinal("Count"));
                        employeeData.Add(new EmployeeData { Location = location, Count = count });
                    }
                }
            }

            // Log the retrieved data for debugging
            System.Diagnostics.Debug.WriteLine("Retrieved Employee Data:");
            foreach (var item in employeeData)
            {
                System.Diagnostics.Debug.WriteLine($"Location: {item.Location}, Count: {item.Count}");
            }

            return employeeData;
        }
    }
}

