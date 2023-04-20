# CO699-TaskTrackerApp
Instructions to run prototype (targeting .NET 7, Visual Studio 2022 required):
1. Clone this GitHub repository and open the project solution file "CO699-TaskTrackerApp.sln" in Visual Studio
2. Run the solution using IIS Express by clicking on the green play button - select IIS Express using the dropdown arrow if it is not currently selected
3. If prompted by the framework to apply database migrations, proceed by clicking on the apply button
4. After the application is launched and the login page is shown, register for a new account with sample details [e.g. "user1@testemail.com" as the email and "TestUser1!" as the password]
5. Confirm the account by clicking on the link shown after submitting the registration form
6. Once redirected to the My List page, sample tasks will be shown. Click the Add Task button to add a new task to the list
7. Filter tasks in the list by title using the search box, or sort by due date or task priority level in ascending/descending order using the sorting hyperlinks 
8. To view account settings, click on the account's email in the top-right corner of the navigation bar

Key Razor Pages with modifications:
- UserTasks/[Index.cshtml](CO699-TaskTrackerApp/Pages/UserTasks/Index.cshtml) - The main page where the task list is located; includes the Bootstrap Cards component to display each task
- UserTasks/[Index.cshtml.cs](CO699-TaskTrackerApp/Pages/UserTasks/Index.cshtml.cs) - Contains the sorting and filtering code for the task list
- Identity/Pages/Account/[Login.cshtml](CO699-TaskTrackerApp/Areas/Identity/Pages/Account/Login.cshtml), [Register.cshtml](CO699-TaskTrackerApp/Areas/Identity/Pages/Account/Register.cshtml) - Login and registration pages
- UserTasks/[Create.cshtml](CO699-TaskTrackerApp/Pages/UserTasks/Create.cshtml), [Edit.cshtml](CO699-TaskTrackerApp/Pages/UserTasks/Edit.cshtml), [Delete.cshtml](CO699-TaskTrackerApp/Pages/UserTasks/Delete.cshtml) - CRUD operations for managing tasks
- Shared/[_Layout.cshtml](CO699-TaskTrackerApp/Pages/Shared/_Layout.cshtml) - Contains the page layout structure including the navigation bar and its links, shown to users that are logged in
- Shared/[_GuestLayout.cshtml](CO699-TaskTrackerApp/Pages/Shared/_GuestLayout.cshtml) - Contains the page layout structure without the navigation bar's links, shown to users that are not logged in
