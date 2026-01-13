# JobTrackerCLIv1

JobTrackerCLIv1 is a simple **C# console (CLI) application** for tracking job applications.  
It allows you to enter application details from the terminal and view the saved entries.

## What it does

- **Add a new job application**

  - Enter: Company name, Role title, Job status, Note, Date
  - Validates inputs so required fields can’t be empty
  - Validates numeric inputs (like status) using safe checks (`TryParse`)

- **Store applications in memory**

  - Saves entries in a list while the program is running

- **Display saved applications**
  - Prints all stored application entries to the console

## Notes

- Data is currently stored **only while the program is running** (no file/database saving yet).
- Built output folders like `bin/` and `obj/` are ignored using `.gitignore`.
