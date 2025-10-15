# MunicipalityApp

## Overview

**MunicipalityApp** is a web application designed to streamline municipal services for South African communities.  
Residents can report issues, stay updated on local events and announcements, and track the status of their service requests in real-time.

The application is built using **ASP.NET MVC** in Visual Studio Code and leverages **MongoDB** to store submitted reports.  
Internally, the system uses custom data structures such as **linked lists, priority queues, stacks, dictionaries, and hash sets** to efficiently manage reports, events, announcements, and user preferences in memory before persisting to the database.

---

## User Types

- **Residents:** Can report municipal issues, attach media, and track service request status.  
- **Visitors:** Can view municipal events, announcements, recently viewed items, and recommended events.

---

## Getting Started

### Prerequisites

To set up and run the MunicipalityApp locally, ensure you have:

- **Visual Studio Code** (latest version recommended)  
- **.NET 6.0 SDK** or higher  
- **MongoDB** installed locally or an active MongoDB Atlas account  

### Installation Steps

1. **Clone the Repository:**  
   ```bash
   git clone https://github.com/St10258543/prog7312-part-2-St10258543 

### Installation Steps

1. **Clone the Repository:**
   Download the source code or clone the repository to your local machine.

2. **Open in Visual Studio Code:**
   Open the project folder in VS Code.

3. **Configure MongoDB Connection:**
   In the `appsettings.json` file, set your MongoDB connection string for storing reports and user data.

4. **Install Dependencies:**
   Use the terminal to restore NuGet packages

5. **Build and Run the Application:**
   Build and run the project

   The application will launch, and the homepage provides navigation to report issues or view submitted reports.

---

## Database and Data Structure

The system uses **MongoDB** for persistent storage:

* **Reports Collection:** Stores report details including location, category, description, media file names, status, and submission date.
  
### Custom Data Structures

The application relies on custom-built data structures for in-memory management:

* Custom Linked List: Stores municipal reports for fast insertion, deletion, and traversal.

* Custom Priority Queue : Stores events sorted by date for easy retrieval of upcoming events.

* Custom Stack : Tracks recently viewed events for personalized recommendations.

* Custom Dictionary : Groups announcements by category and logs user search preferences.

* Custom HashSet : Maintains unique event and announcement categories.

* These structures allow efficient in-memory operations, faster filtering and sorting, and the implementation of features like event recommendations without querying the database repeatedly.

---

## System Features

### User Roles

* **Resident:**

  * Submit municipal issues with details and optional media
  * Track the status of submitted issues
 
* **Visitor:**

  * Browse municipal event and announcements
  * Filter events by category or date
  * Search events using keywords
  * View recently viewed events
  * Recieve recommended events based on previous interactions

### Functional Features

* **Issue Reporting:**
  Residents can report issues, provide location and category, and attach multiple images.

* **Status Tracking:**
  Residents can view the progress of their submitted reports with colored status indicators.

* **Event Management:**
  Display municipal events with title, description, category, and date.

* **Announcements:**
  View announcements grouped by category.

* **Search & Filtering:**
  Search events by title, description, or category; filter by date or category.

*  **Recommendations:**
  System recommends events based on user search history and frequently viewed categories.

* **Media Upload:**
  Users can upload images associated with issues, which are stored in a folder or Blob Storage if configured.

* **Multilingual Support:**
  All UI elements can switch dynamically between supported languages using **ASP.NET localization**.


---

### Non-Functional Requirements

* **Performance:** Efficient in-memory operations using a custom linked list before persisting to MongoDB.
* **Reliability:** Stable and resilient with MongoDB for storage.
* **Usability:** Clean, modern UI with responsive layout for desktop and mobile.
* **Security:** Role-based access and secure data storage in MongoDB.

---

## How to Use the Application

### For Residents

1. **Report an Issue:**

   * Navigate to the "Report Issue" page
   * Enter location, category, description, and attach media
   * Submit the report

2. **View Submitted Reports:**

   * Check the "Submitted Reports" page
   * Track issue status with colored indicators

### For Visitors

1. **Browse Events:**
   
   * Go to the "Events" page to see all municipal events
   * Filter by category or date, and search using keywords
     
2. **View Announcements:**
   
   * Check announcements grouped by category

4. **Recently Viewed & Recommendations:**
   
   * Recently viewed events are tracked for personalized experience, and top recommended events are displayed based on user interactions

## Architecture

* **ASP.NET MVC:** Handles the user interface and business logic
* **Visual Studio Code:** Development environment
* **MongoDB:** Stores reports and user data
* **Custom Data Structures: Efficient in-memory storage of reports, events, announcements, and user preferences
* **Localization:** Supports multiple languages dynamically

---

## Contributions

We welcome contributions:

* Report issues or bugs via GitHub issues
* Propose features or improvements via GitHub discussions
* Submit pull requests following coding guidelines

---

## FAQ

**Q:** Can I attach multiple images to a report?
**A:** Yes, residents can upload multiple images when submitting a report.

**Q:** How do I track the status of my submitted report?
**A:** Navigate to the "Submitted Reports" page to view status indicators.

**Q:** Can I filter events by category or date?
**A:** Yes, the Events page supports filtering and search functionality.

**Q:** Are event recommendations personalized?
**A:** Yes, based on previously viewed events and user search preferences.

---

## Contact and Support

For assistance, please contact:
**Email:** st10258543@vcconnect.edu.za

---

## License

This project is licensed under the [MIT License](LICENSE).

---

## Authors

The MunicipalityApp was developed by **Kiana Pillay**.

---

## GitHub Link
https://github.com/St10258543/prog7312-part-2-St10258543 

