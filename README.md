MunicipalityApp
Overview

The MunicipalityApp is a web application designed to streamline municipal services for South African communities.
Residents can report issues, stay updated on local events and announcements, and track the status of their service requests in real-time.

The application is built using ASP.NET MVC in Visual Studio Code, and it leverages MongoDB to store submitted reports.
Internally, the system uses custom data structures such as linked lists, priority queues, stacks, dictionaries, and hash sets to manage reports, events, announcements, and user preferences efficiently in memory before persisting to the database.

User Types

Residents: Can report municipal issues, attach media, and track service request status.

Visitors: Can view municipal events, announcements, recently viewed items, and recommended events.

Getting Started
Prerequisites

To set up and run the MunicipalityApp locally, ensure you have:

Visual Studio Code (latest version recommended)

.NET 6.0 SDK or higher

MongoDB installed locally or an active MongoDB Atlas account

Installation Steps

Clone the Repository:
Download the source code or clone the repository to your local machine.

Open in Visual Studio Code:
Open the project folder in VS Code.

Configure MongoDB Connection:
In the appsettings.json file, set your MongoDB connection string for storing reports and user data.

Install Dependencies:
Restore NuGet packages using the terminal.

Build and Run the Application:
Launch the application; the homepage provides navigation to report issues, view submitted reports, or browse municipal events.

Database and Data Structure
Persistent Storage

The system uses MongoDB for persistent storage:

Reports Collection: Stores report details including location, category, description, media file names, status, and submission date.

Custom Data Structures

The application relies on custom-built data structures for in-memory management before persisting data:

Custom Linked List: Stores municipal reports for fast insertion, deletion, and traversal.

Custom Priority Queue (CustomPriorityQueue<Events>): Stores events sorted by date for easy retrieval of upcoming events.

Custom Stack (CustomStack<Events>): Tracks recently viewed events for personalized recommendations.

Custom Dictionary (CustomDictionary<TKey, TValue>): Groups announcements by category and logs user search preferences.

Custom HashSet (CustomHashSet<string>): Maintains unique event and announcement categories.

These structures allow efficient in-memory operations, faster filtering and sorting, and the implementation of features like event recommendations without querying the database repeatedly.

System Features
User Roles

Resident:

Submit municipal issues with details and optional media

Track the status of submitted issues

Visitor:

Browse municipal events and announcements

Filter events by category or date

Search events using keywords

View recently viewed events

Receive recommended events based on previous interactions

Functional Features

Issue Reporting:
Residents can report issues with location, category, description, and multiple image uploads.

Status Tracking:
View the progress of submitted reports using colored indicators.

Event Management:
Display municipal events with title, description, category, and date.

Announcements:
View announcements grouped by category.

Search & Filtering:
Search events by title, description, or category; filter by date or category.

Recommendations:
The system recommends events based on user search history and frequently viewed categories.

Media Upload:
Images attached to reports are stored in a folder or Blob Storage if configured.

Multilingual Support:
UI elements can switch dynamically between supported languages using ASP.NET localization.

Non-Functional Requirements

Performance: Efficient in-memory operations using custom data structures.

Reliability: Stable and resilient, using MongoDB for persistence.

Usability: Clean, modern, and responsive interface.

Security: Role-based access, secure storage, and logging of user interactions.

How to Use the Application
For Residents

Report an Issue:

Navigate to the "Report Issue" page

Enter location, category, description, and attach media

Submit the report

View Submitted Reports:

Access the "Submitted Reports" page

Track issue status with colored indicators

For Visitors

Browse Events:

Go to the "Events" page to see all municipal events

Filter by category or date, and search using keywords

View Announcements:

Check announcements grouped by category

Recently Viewed & Recommendations:

Recently viewed events are tracked for personalized experience

Top recommended events are displayed based on user interactions

Architecture

ASP.NET MVC: Handles the user interface and business logic

Visual Studio Code: Development environment

MongoDB: Stores reports and user data

Custom Data Structures: Efficient in-memory storage of reports, events, announcements, and user preferences

Localization: Supports multiple languages dynamically

Contributions

We welcome contributions:

Report issues or bugs via GitHub issues

Propose features or improvements via GitHub discussions

Submit pull requests following coding guidelines

FAQ

Q: Can I attach multiple images to a report?
A: Yes, residents can upload multiple images when submitting a report.

Q: How do I track the status of my submitted report?
A: Navigate to the "Submitted Reports" page to view status indicators.

Q: Can I filter events by category or date?
A: Yes, the Events page supports filtering and search functionality.

Q: Are event recommendations personalized?
A: Yes, based on previously viewed events and user search preferences.

Contact and Support

For assistance, please contact:
Email: st10258543@vcconnect.edu.za

License

This project is licensed under the MIT License
.

Authors

The MunicipalityApp was developed by Kiana Pillay.

GitHub Link

https://github.com/VCWVL/prog7312-part-1-St10258543.git
