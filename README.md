Task Management 
--------------

A web application for creating, editing, deleting, and tracking task.

setup project
--------------
1. clone project
2. ensure localDB is installed and MSSQLLocalDB is running
3. if required update connection string
4. excute below commend in package manager console :
   Enable-Migrations
   Add-Migration InitialCreate
   Update-Database
5. clean and build solution.

Technology used 
------------------
Asp.net MVC version 5.2.9.0
Entity Framework
SQL Server Express LocalDB ((localdb)\MSSQLLocalDB)
jQuery & Bootstrap
