# example-feature-flag-saas
 
prereq:
dotnet 9.0
dotnet-ef: dotnet tool install --global dotnet-ef

SQLite generates two files once you run the application - featureflags.db-shm and featureflags.db-wal. They are related to the Write-Ahead Logging (WAL) mode. They are used for transaction management and performance optimization.

## Setting Up the Database

1. Ensure you have the necessary packages installed:
   ```sh
   dotnet restore

2. Apply the initial migration to create the database:
dotnet ef database update

3. Run the application:
dotnet run