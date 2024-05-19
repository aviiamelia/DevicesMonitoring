namespace DevicesMonitoring.Infra.database;

public class Schema
{
    public string CreateSchema()
    {
        string createTableSql = @"CREATE TABLE Users (
    UserId SERIAL PRIMARY KEY,
    Username VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    PasswordHash VARCHAR(200) NOT NULL,
    CreatedAt TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- Create the Devices table
CREATE TABLE Devices (
    DeviceId SERIAL PRIMARY KEY,
    DeviceName VARCHAR(100) NOT NULL,
    DeviceType VARCHAR(100) NOT NULL,
    CreatedAt TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UserId INT NOT NULL,
    CONSTRAINT FK_UserDevice FOREIGN KEY (UserId)
        REFERENCES Users (UserId)
        ON DELETE CASCADE
);";
        return createTableSql;
    }
}
