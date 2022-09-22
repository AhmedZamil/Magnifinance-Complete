# Recruiting a Full-Stack Developer - Technical Challenge

 # Setup shortcut [Checked with different machine]
It's Just to setup to all done Now.

    ## 1. Run the setup.bat file
    ## 2. After Running just browse http://localhost:5000/ ( when in bat file command prompt showing Building...)
    
[It will ensure navigate & install dependency for angular as well as for dotnet restore, installing dotnet ef ,add migration , update database , build & run the application with few Seed data]

 * Note : you will find the details below if you want to run development enviourment [Visual Studio 2022] 
 * Note : you will find the Navigation to application to say how to browse application sections & what they do

## Challange & Requerments :

Your customer is a college that needs a management system that allows them to register courses, subjects, teachers and students of a university. Each college course must have multiple subjects, which in turn, contain one teacher and many students. Furthermore, the system must store the name, birthday, and salary of teachers. For the students it must save the name, birthday, registration number and the students grade in the subjects enrolled.

Requisites:
Create a CRUD of the entities (Courses, Subjects, Teacher, Student, Grades)
List the courses and show the number of teachers, students and average of their grades for each course
List the subjects and show the teacher information, number of students and their grades for each subject
List the students and their respectives grades of the subject

Bonus points:
Use of the best practices and Oriented Object Programming
Short time to finish and get back to us
Appearence

Architecture:
ASP MVC 5
SQL Server using Entity Framework 6 and LocalDB
Angular
SignalR

Notes:
You have to set up the EF6 to use the LocalDB and initialize it with test data.
The environment should be automatically created in the local execution. Example
Use GitHub and send us a link with the source code
We will only review technical challenges stored in Git. Please, only send us the link to the Git repository where the solution is stored. Also, in that repository you must have a Setup.md file with all the steps required for us to setup and run your solution locally
The solution must include a batch file that when run will build and run the solution.

## My Submission 

# Domain Requirement 
Yes It's implemented with all Asking requerments
- Create a CRUD of the entities (Courses, Subjects, Teacher, Student, Grades)
- List the courses and show the number of teachers, students and average of their grades for each course
- List the subjects and show the teacher information, number of students and their grades for each subject
- List the students and their respectives grades of the subject
# Technologies
 - Whole project built on Latest .NET Core 5.0 
 - EF 6
 - SignalR [For .NET Core]
 - ASP.NET MVC 6 Ensured
 - Angular 11.2
 - Local DB [MS Sql Server]
# Good to share 
  - I have tried to have the best possible impression , thats why took time to polish & beutify
  -  SignalR Implemented [Nav bar top right corner Magnifinance User : extra, Complete CRUD Operation is there & if you add, Edit ,Delete User There will be broadcast       Notification & Notification count will be in nabvar ring-bell sign ]
  - Tried to maintain S O L I D
     - Interface are segragated
     - rather than a whole Scope tried to use one responsibility for single scope
     - ASP.NET Core Web API are to feed Angular Front End (to be honest not Restful in many ways)
     - Tried to Use JWT Bearer to Autheticate & generate token (For best impression)
     
  - Uses Interface - Repository Pattern (Mixed N-tier)
  - Maximum code to show Angular & Web API [Also M-V-C in Asp.net part]
  - 



# Prerequisites

## Only [.NET Core 5.0 SDK] (https://dotnet.microsoft.com/download) has to be present to Run
## After running setup file , give it some time [after setting up npm-EF-Db-Seed data When it shows "Building" just browse http://localhost:5000/]

If you want to open in developer mode 

* [Visual Studio 2022] (https://visualstudio.microsoft.com/vs/)

* you should have node


* [Angular CLI](https://cli.angular.io/)


If you clone the repo, want to run the code in devlopment mode in visual studio

In Visual Studio 2022:

step 1 : clone the repository

step 2: have Prerequisites

step 3: open the solution file in visual studio 2022

step 4: go to command prompt terminal

step 5: run command to check ,  dotnet --version (it has to be ASP.NET Core 6.0)

step 6: command cd client [to go to client directory where angular front end]

step 7: you will see package.json file in this directory

step 8 : command - npm install [to install dependencies]

step 9: ng build [to build the angular project and it will automatically copies the bundles to wwwwroot/client]

step 10 : run command dotnet restore or clean the solution clean the project and  - build

step 11: make sure you setup the database and Entity Framework migrations!
This is how:
      1. Remove the contents of the folder Migrations.
      2. Then open the Package Manager Console (Tools->Nuget Package Manager->Package Manager Console).
      3. Run the following commands:

          Add-Migration Initial
          Update-Database
 
 
 step 12: run the solution [either with F5 or dotnet run ]

 step 13: Application should be in web browser
 
 
 # Navigation through the application
 
  ## Home : You will see a landing page , click the [Enter] button - student course management system will be with navigation bar
  
  ## Navigation bar (SignalR Activated) : top right corner "Magnifinance User".Click to see complete implementation
         - List View of User
         - Can Search User
         - Can Add - Edit -Delete User
         With every Add-Delete-Edit operation a broadcast message will be poped up in navbar bell-ring icon
         - if you click on the icon in modal you can see the details of Notification Message
         -I hope you will find SignalR popular use Completely with CRUD operation for sample.
  
  ## Courses : You will have a nice Course layout page
       - all courses are in seperate box (With requested Information view)
       - Add Course Button will act to add the new course and navigate back to course
   ## Subject : You will have a layout of Subjects 
        - [Each are in seperate box, subject can be filtered with sub menu]
        - Subject box are sepeerated with requered information 
        - in Box [Show Grade Button will show you the Grades]
        - can navigate back to subject with navigator
        - Add subject button will Guide you to add subject
   ## Teacher : Layout with Teacher Boxes seperated list
        - Add teacher will guide you to
   ## Student : Will show  List of Student with photo 
          - will show you the requerments for this challange
          - Give Grade will lead you to give a grade
          - Add student will lead you to Crud
         

## INSTALLING THE Angular CODE [if curious]

The following are detailed instructions for installing the code so you can code along with the course.

0) Ensure you have node installed.

   At a command prompt, type `node -v` to ensure you have version `14.15.0` or higher before proceeding.

1) Download or clone the code from this repository.

   If you download as a zip file, be sure to unzip it.

2) Navigate to the client folder.

   There should be a package.json file in this folder.

3) In a command window (or the Command prompt in VS Code), type `npm install`. - to install all the necessary dependecies

   This creates a node_modules folder and installs all packages from the package.json file into that client folder. You may see a few warnings during this process, but you should not see any errors.
   
4) In the same command window (or the Command property in VS Code), type `npm start`.

   The application should then compile and launch in your default browser.
   
If these steps don't work for you

5) run the setup.bat file (you wil find it in current working directory)
   it does the below steps 
   - will go to client directory (where package.json file is there)
   - will install npm dependencies (will show out put in windows)
   - will come back to dotnet directory
   - dotnet restore will restore all dependecis
   - dotnet build will build the project
   - check dotnet ef installed or not
    -if not will install globally
    - will create & update database according to migration
    - dotnet run will seed initial data 
    - application should be running in local IIS
