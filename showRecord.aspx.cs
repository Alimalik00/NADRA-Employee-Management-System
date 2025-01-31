using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace testweb
{
    public partial class showRecords : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT EmpID, FirstName, SecondName, Gender, DateOfBirth, EmpType, Salary, Address, CellNo, CNIC, Designation, EmergencyContactName, EmergencyContactNumber, Scale FROM Nadra.dbo.EmpTable";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            // Getting the EmpID from the clicked button's CommandArgument
            Button btnEdit = (Button)sender;
            string empID = btnEdit.CommandArgument;

            // Redirecting to the edit page with the EmpID as a parameter
            Response.Redirect("EditRecord.aspx?EmpID=" + empID);
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            // Getting the EmpID from the clicked button's CommandArgument
            Button btnView = (Button)sender;
            string empID = btnView.CommandArgument;

            // Redirecting to the edit page with the EmpID as a parameter
            Response.Redirect("ViewMode.aspx?EmpID=" + empID);
        }


    }
}
