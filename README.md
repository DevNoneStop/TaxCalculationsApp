# TaxCalculationsApp

Steps to run the TaxCalculationApp solution.

Step	1: How to connect to the LocalDB instance.

•	Navigate to where you save the solution file.

•	Unzip the TaxCalculationApp folder to the same directory.

•	Open Microsoft SQL Server Management Studio >> connect to your localDB:
    o	The right click on Database and select Attach... on the SQL Server instance where you want to attach the database
    
    o	On the pop window >> Click on the Add button to find the mdf file that you want to attach, select the files, and click OK.
    
    o	When you have selected the correct files, click OK and you will see the screen show a green checkmark and then the screen will close.
    
    
•	The database should be connected to your MS Sql server management studio and ready to be used.

•	Alternatively, use the script on the folder called “CreateEmployeeDBandTable.sql” and run the script after connecting on your localDB to create the an empty Database and Table.


Step 2: How to run the the TaxCalculationApp Solution

•	Navigate to where you save the solution file.

•	Unzip the TaxCalculationApp folder to the same directory.

•	Open the TaxCalculationApp folder until you see the TaxCalculationApp.sln file and right click the file to open with Microsoft Visual Studio 2022

•	Navigate to the solution explorer and click on the solution name >> Properties >> Common Properties >> Startup Project.

o	Click on “Multiple startup projects” >> make sure “EmployeeTaxCal.API” and “TaxCalculatorWeb” action is set to “Start” apply then okay to close the popup window.

•	Build the solution and after start the solution.
