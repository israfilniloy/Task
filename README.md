# CRUD Operations in C# Windows Forms Application

## Project Overview:

This project demonstrates how to implement CRUD (Insert, Update, Delete) operations using C# and SQL Server within a Windows Forms Application. 
It provides a user-friendly interface for managing student records.

## Table of Contents:

Technologies Used-
C#: Core programming language for the Windows Forms application.
SQL Server: Used as the database to store student records.
Windows Forms: Provides the graphical user interface (GUI) for interacting with the application.
Visual Studio: Integrated Development Environment (IDE) for building and debugging the application.

## Features:

1.Add New Users: Input user details such as User ID, Name, and Age. The new user is added to both the list and the SQL Server database.
2.View/Search User Information: Displays all user records in a grid format, showing the user’s ID, name, and age. Users can search for records by ID.
3.Update User Information: Modify existing user details in the grid and save the changes to the database.
4.Delete User Records: Remove a user record from the database by ID, with confirmation to avoid accidental deletions.
5.Search Users: Search for users by ID using the search bar.

## Schema Diagram:
Table: UserTab
Columns:
- ID (int, primary key)
- Name (nvarchar(50))
- Age (float)


## Set Up SQL Server Database-

1.Open SQL Server Management Studio (SSMS) and connect to your SQL Server instance.
2.Create the Database:
Use the provided .sql file located in the project folder to set up the schema and insert initial data.
Update Connection String:
3.Find and modify the connection string in your project files:
SqlConnection con = new SqlConnection("Data Source=NILOY\\SQLEXPRESS02;Integrated Security=True");
Update this to
private readonly string connectionString = "Server=<YOUR_SERVER_NAME>;Database=<YOUR_DATABASE_NAME>;Trusted_Connection=True;";

4.Create Student Information Table:
CREATE TABLE [dbo].[UserTab] (
    [ID]   INT           NOT NULL,
    [Name] NVARCHAR (50) NULL,
    [Age]  FLOAT (53)    NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

## Create a C# Windows Forms Application:
1.Open Visual Studio.
2.Create a New Project:
Select C# > Windows Forms App (.NET Framework).
Name the project and choose a location.

3.Design Your Form:
Add text boxes for Student ID, Name, and Age.
Add buttons for Insert, Update, Delete, and Search.
Add a DataGridView to display student records.

4.Configure SQL Server Connection:
Set up the connection string in your C# code
string connectionString = "Data Source=YOUR_SERVER_NAME;Initial Catalog=StudentDB;Integrated Security=True;";

5.Install SQL Server NuGet Package (if necessary):
In Solution Explorer, right-click the project and select Manage NuGet Packages.
Search for System.Data.SqlClient and install it.

## C# Code Implementation:
## Insert Data-
private void button1_Click(object sender, EventArgs e)
{
    using (SqlConnection con = new SqlConnection(connectionString))
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO UserTab (ID, Name, Age) VALUES (@ID, @Name, @Age)", con);
        cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
        cmd.Parameters.AddWithValue("@Name", textBox2.Text);
        cmd.Parameters.AddWithValue("@Age", double.Parse(textBox3.Text));
        cmd.ExecuteNonQuery();
        con.Close();
        MessageBox.Show("Successfully Saved");
        LoadData(); // Refresh data
    }
}


## Update Data-
private void button2_Click(object sender, EventArgs e)
{
    using (SqlConnection con = new SqlConnection(connectionString))
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("UPDATE UserTab SET Name=@Name, Age=@Age WHERE ID=@ID", con);
        cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
        cmd.Parameters.AddWithValue("@Name", textBox2.Text);
        cmd.Parameters.AddWithValue("@Age", double.Parse(textBox3.Text));

        int rowsAffected = cmd.ExecuteNonQuery();
        con.Close();

        if (rowsAffected > 0)
        {
            MessageBox.Show("Successfully Updated");
            LoadData(); // Refresh data
        }
        else
        {
            MessageBox.Show("Update Failed. Record Not Found.");
        }
    }
}

## Delete Data-
 private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM UserTab WHERE ID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));

                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Successfully Deleted");
                    LoadData(); // Refresh data
                }
                else
                {
                    MessageBox.Show("Delete Failed. Record Not Found.");
                }
            }
        }

  ## Load Data-
  private void LoadData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM UserTab", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
        
 ## Event Handling:
Each button (Insert, Update, Delete) has an event handler to execute its respective CRUD operation.
The LoadData() function is called after each operation to refresh the data displayed in the grid.

 ## Challenges and Considerations:
 Error Handling: Implement error handling for database connection issues and invalid inputs.
 Database Constraints: Ensure proper validation to avoid inserting incorrect data.

 ## How to Run the Project:
  1.Clone the Repository- Clone the project from the GitHub repository.
      (https://github.com/israfilniloy/Task.git)
 2.Set Up the Database: Configure your SQL Server or SQLite database using the script in the .sql file.
 3.Build the Project: Open the project in Visual Studio and build the solution.
 4.Run the Application:  Manage user records through the Windows Forms interface. 
    Insert, update, delete, and search records in the SQL Server database.

## ScreenShots:

![Screenshot 2024-09-18 183607](https://github.com/user-attachments/assets/824a89fa-bba3-4613-9cae-81b95586ef50)



 

 

