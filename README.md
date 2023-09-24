# WPF - File Data reader using background serivce and EF for DB operation 

## Project Detail
- Created on VS 2022 using C# .NET 6 WPF
- EF as ORM and SQLite for DB storage
- background service for file processing

### How to Run
- Run the service by clicking on the start service button 
- In the project Directory, Place the sample data files from the  **DATA_FILES** folder to **IN_PROCESS** folder 
- The service will pick the **very first .txt** file from the **DATA_FILES/IN_PROCESS** folder for processing and wait for 5 second to start the process again 
- The processed file will be moved to **DATA_FILES/COMPLETED**  
- You will be shown pop up if any data is loaded from the file and inserted into the **ELDEvents** table 
- you can switch tab if you want to see if any data is loaded in the table or not 
- To stop the service click close the application