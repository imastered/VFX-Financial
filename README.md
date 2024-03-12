# VFX-Financial
## The main project is the V2

## Setup
Firstly, install SQL Server, during which the installation process will prompt you if you want to install SQL Management Studio as well. Choose "Yes" to install it. You need both(https://www.microsoft.com/en-us/sql-server/sql-server-downloads) 

After this installation, you'll need to create a database called VFX Financial, on it is possible to do this in SQL Management Studio.

Next, open Visual Studio with the V2 solution.

Then, you'll open the appsettings.json file and change what's selected in the print for the server name in your local PC. I'll follow up with some pictures to help you through this process:
![Screenshot 2024-03-12 181534](https://github.com/imastered/VFX-Financial/assets/92260343/d0f309c5-92de-43ad-bf7f-e8691a65864c)
![Screenshot 2024-03-12 181704](https://github.com/imastered/VFX-Financial/assets/92260343/c773b6b5-6547-40ef-8cbd-c2976b9a3271)
![Screenshot 2024-03-12 181736](https://github.com/imastered/VFX-Financial/assets/92260343/fb6ebe54-1556-44a7-9683-2425ff7f4dd1)
![Screenshot 2024-03-12 181755](https://github.com/imastered/VFX-Financial/assets/92260343/994e192f-82eb-4864-890a-1577d8ceb774)

With everything configured, let's add the Exchange Rates table to our VFX Financial database. To do this, we need to open the Package Manager Console:
![Screenshot 2024-03-12 181504](https://github.com/imastered/VFX-Financial/assets/92260343/0b22e3bf-d5dd-450a-9628-5505c3b21777)

In that console, we'll run the command "Update-Database" to add the table onto databse. After this command refresh the database and in the folder Tables should appear Migrations and ExchangeRates tables.

With all of this set up, finally, we can play with our API. I would advise only changing this (print) as a precaution:
![Screenshot 2024-03-12 181442](https://github.com/imastered/VFX-Financial/assets/92260343/2ee2acbc-7b10-477d-8f71-9e82f3dab24a)

By clicking run, after a few seconds, a pop-up window of your browser should appear with Swagger opened and ready to test the app. 

Start by using the POST request to create data or the GET with options of the currency codes that exist to further populate our exchange rates table.

## Improvements
Scope and Authorization: Implement scope and authentication mechanisms for each request to ensure secure access to the API endpoints.

Pagination for GetAll Requests: Implement pagination for the GetAll endpoint to efficiently handle large datasets and improve performance.

Fix Corner Cases in UpdateExchangeRate and Sync with Third-Party API: Address any edge cases and potential errors in the UpdateExchangeRate function and ensure seamless synchronization with the third-party API.

Additional Variable in Domain Model for Exchange Rate Source: Introduce a new variable in the domain model for exchange rates to indicate whether the rate was added by the user or retrieved from the third-party API.

Database Logging: Set up database logging to store detailed information about API requests, responses, and any relevant actions or events.

Enhanced Logging: Increase the verbosity of logging to capture more detailed information, including errors, warnings, and informational messages, to facilitate troubleshooting and monitoring.

Hangfire Job for Exchange Rate Updates: Implement a Hangfire job to periodically retrieve the latest exchange rate information, compare it with existing data, and update as necessary to ensure data freshness and accuracy.

By implementing these improvements, you'll enhance the security, performance, reliability, and maintainability of your application.

Thank you ^^
