<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="testweb.dashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">


<head runat="server">
    <title>Dashboard</title>
        <link rel="stylesheet" href="/style/dashboard.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css"/>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    

        <script>
     function redirectToRecordsPage() {
                        window.location.href = "showRecord.aspx"
     }

            function redirctToHomePage() {
                    window.location.href = "WebForm1.aspx"
          }
        </script>

</head>


<body>
    <form id="form1" runat="server">
             <div class="dashboard-container">
            <div class="sidebar">
                <div class="logo">
                    &nbsp;<img src="dashboard.jpg" alt="Company Logo" style="width: 1601px" /></div>
                
            </div>
            <div class="main-content">
                <div class="header">
                 <button type="submit" value="Submit"  OnServerClick="SubmitButton_Click" runat="server">Insert Records</button>
                 <button type="submit" value="Submit"  OnServerClick="SubmitAButton_Click" runat="server">Show Records</button>
                 <button type="submit" value="Submit"  OnServerClick="SubmitBButton_Click" runat="server">Designation Wise</button>
                    </div>
                </div>


                <br /><br /><br /><br />

             <div class="summary">
                    <div class="card">
                        <div class="animated-literal">
                        <i class="fas fa-users card-icon"></i>
                        <h2>Total Employees</h2>
                            <div style="font-size: 25px;" >
                        <p><asp:Literal ID="litTotalEmployees"  runat="server" ></asp:Literal></p>
                                </div>
                            </div>
                    </div>
                    <div class="card">
                        <div class="animated-literal">
                        <i class="fas fa-dollar-sign card-icon"></i> 
                        <h2>Average Salary</h2>
                            <div style="font-size: 20px;" >
                        <asp:Literal ID="litAverageSalary" runat="server"></asp:Literal>
                                </div>
                            </div>
                    </div>
                    <div class="card">
                        <div class="animated-literal">
                        <i class="fas fa-globe card-icon"></i>
                        <h2>Locations</h2>
                            <div style="font-size: 20px;" >
                        <p><asp:Literal ID="litlocations" runat="server" ></asp:Literal></p>
                                </div>
                            </div>
                    </div>

                    <div class="card">
                            <div class="animated-literal">
                        <i class="fas fa-briefcase card-icon"></i>
                        <h2>Projects</h2>
                                <div style="font-size: 20px;" >
                        <p><asp:Literal ID="litTransfer" runat="server"></asp:Literal></p>
                                    </div>
                            </div>
                    </div>
                    
                    <div class="card">
                        <div class="animated-literal">
                        <i class="fas fa-sitemap card-icon"></i>
                        <h2>Total Departments</h2>
                            <div style="font-size: 20px;" >
                        <p><asp:Literal ID="litdepartments" runat="server" ></asp:Literal></p>
                                </div>
                            </div>
                    </div>

            </div>
              
                
               
<%-------- INTERSECTING SECTION ------%>
    <div class="section">
        <br/><br/><br/><hr/>
    </div>
<%-----------------------------------%>

            </div>
        </div>
    </form>

    <br /><br /><br />

    <div class="charts-container">
   <canvas id="employeeLocationsChart" style =" width:650px; height:490px; background-color: #055119;"  ></canvas>    
   <canvas id="LocationChart" style =" width:650px; height:490px; background-color: #055119;"  ></canvas>    
        </div>


    <script>
        // Fetch employee data from the server using AJAX
        function fetchEmployeeData() {
            return fetch('dashboard.aspx/GetEmployeeData', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({})
            })
                .then(response => response.json())
                .then(result => result.d)  // Extract the 'd' property containing the array
                .catch(error => {
                    console.error('Error fetching employee data:', error);
                    return [];
                });
        }


        function populateChart(data) {

            // Filter out items with empty or null locations
            var filteredData = data.filter(item => item.Location !== '' && item.Location !== null);

            // Extract location names and counts for the chart
            var locations = filteredData.map(item => item.Location);
            var counts = filteredData.map(item => item.Count);

            // Create a chart using Chart.js
            var ctx = document.getElementById('employeeLocationsChart').getContext('2d');
            var chart = new Chart(ctx, {
                type: 'doughnut',
                data: {
                    labels: locations,
                    datasets: [{
                        label: 'Employee Locations',
                        data: counts,
                        backgroundColor: [
                            '#d32f0f',
                            '#7c00ff',
                            '#ffd400',

                        ],
                        borderWidth: 1
                    }]
                },
                options: {
                    responsive: false,
                    maintainAspectRatio: false,
                    scales: {
                        y: {
                            beginAtZero: true,
                            ticks: {
                                color: '#ffffff' // Change y-axis labels font color
                            },

                        },
                        x: {
                            ticks: {
                                color: '#ffffff' // Change y-axis labels font color
                            },
                        }
                    },


                    plugins: {
                        legend: {
                            display: true,
                            position: 'top', // 'top', 'bottom', 'left', 'right'
                            labels: {
                                color: '#ffff', // Legend label color
                                font: {
                                    size: 12, // Legend label font size
                                }
                            }
                        },
                        title: {
                            display: true,

                            text: 'Employee Locations Chart', // Chart title
                            color: '#ffff', // Title color
                            font: {
                                size: 16, // Title font size
                                weight: 'bold', // Title font weight
                            }
                        }
                    }
                }
            });

            var ctx = document.getElementById('LocationChart').getContext('2d');
            var chart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: locations,
                    datasets: [{
                        label: 'Employee Locations',
                        data: counts,
                        backgroundColor: [
                            '#d32f0f',
                            '#7c00ff',
                            '#ffd400',

                        ],
                        borderWidth: 1
                    }]
                },
                options: {
                    responsive: false,
                    maintainAspectRatio: false,
                    scales: {
                        y: {
                            beginAtZero: true,
                            ticks: {
                                color: '#ffffff' // Change y-axis labels font color
                            },

                        },
                        x: {
                            ticks: {
                                color: '#ffffff' // Change y-axis labels font color
                            },
                        }
                    },


                    plugins: {
                        legend: {
                            display: true,
                            position: 'top', // 'top', 'bottom', 'left', 'right'
                            labels: {
                                color: '#ffff', // Legend label color
                                font: {
                                    size: 12, // Legend label font size
                                }
                            }
                        },
                        title: {
                            display: true,

                            text: 'Employee Locations Chart', // Chart title
                            color: '#ffff', // Title color
                            font: {
                                size: 16, // Title font size
                                weight: 'bold', // Title font weight
                            }
                        }
                    }
                }
            });

        }

        fetchEmployeeData().then(data => {
            console.log(data);
            populateChart(data);
        });


    </script>


    <%-------- INTERSECTING SECTION ------%>
    <div class="section">
        <br/><br/><br/><hr/><br/><br/><br/>
    </div>
<%-----------------------------------%>



    <%--------------- FOOTER --------------------%>
<footer>
    <h8>
        National Database And Registration Authority - G-5 Islamabad
    </h8>
</footer>
<%-------------------------------------------%>



</body>
</html>




