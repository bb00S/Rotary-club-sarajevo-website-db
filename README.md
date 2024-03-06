# Rotary-club-sarajevo-website-db
# Intro

This GitHub repo contains all code required and produced by me and my mentor for the development of the Rotary Club Sarajevo website. 
As part of my role as a full-stack developer at Finit Consulting, I undertook the task of creating a digital platform that embodies the essence of the Rotary organization.
Throughout the development journey, I engaged with various technologies including JavaScript, HTML, CSS, Bootstrap, .Net, and C#. 
Complex functionalities such as interface-to-database connection and user interface implementation were meticulously crafted to ensure a seamless user experience.

An integral aspect of this project involved database management utilizing SQL Server.  I adeptly developed and executed numerous queries and exports to maintain data integrity and facilitate accessibility. 
While adhering to the aesthetic principles of the Rotary organization, this endeavor provided a significant opportunity to showcase uniqueness and creativity within the constraints of the design. 
This report encapsulates the comprehensive journey of creating the Rotary Club Sarajevo website, highlighting the technical intricacies, creative solutions, 
and enduring impact within the Rotary community. 

## Navigate to the Repository:
Open your repository on GitHub where you want to add the connection string and complete data migration.

## Clone the Repository:
  If you haven't already cloned the repository to your local machine, use the following command:

  git clone <repository-url>
  Replace <repository-url> with the URL of your repository.

## Locate the appsettings.json file:
  Navigate to the directory where your ASP.NET Core project is located and locate the appsettings.json file.

## Edit the appsettings.json file:
  Open the appsettings.json file and add a new section for the connection string. Here is an example of how it might look:
  
    {
      "ConnectionStrings": {
        "DefaultConnection": "YourConnectionStringHere"
      }
    }
    
Replace "YourConnectionStringHere" with your actual database connection string.

## Save and commit changes:
  Save the changes to the appsettings.json file and commit them to your local repository using Git:
  
  git add appsettings.json
  git commit -m "Added database connection string to appsettings.json"
  git push origin master

## Locate the Initial.cs file:

  Find the Initial.cs file in your project. This file typically contains code for initial database migrations.

## Complete data migration using Initial.cs:

  Open the Initial.cs file and add necessary migration code to ensure that your database schema is created or updated according to your model changes. This might involve defining new     tables, modifying existing ones, etc.

## Save and commit changes:
  Save the changes to the Initial.cs file and commit them to your local repository using Git:

  git add Initial.cs
  git commit -m "Completed data migration in Initial.cs"
  git push origin master

## Verify Changes:
  After pushing the changes to your GitHub repository, verify that the changes reflect correctly in the GitHub repository's code.

By following these steps, you should have successfully added a connection string through the appsettings.json file and completed data migration through the Initial.cs file in your GitHub repository.

# More Project Information
The full report can be found at https://github.com/bb00S/Rotary-club-sarajevo-website-db
