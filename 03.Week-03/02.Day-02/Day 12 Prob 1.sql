--Create Tables

CREATE TABLE UserInfo (
    EmailId VARCHAR(100) PRIMARY KEY,
    UserName VARCHAR(50) NOT NULL,
    Role VARCHAR(20) NOT NULL,
    Password VARCHAR(20) NOT NULL,

    CONSTRAINT CHK_UserName_Length
        CHECK (LEN(UserName) BETWEEN 1 AND 50),

    CONSTRAINT CHK_User_Role
        CHECK (Role IN ('Admin', 'Participant')),

    CONSTRAINT CHK_User_Password_Length
        CHECK (LEN(Password) BETWEEN 6 AND 20)
);

--EventDetails

CREATE TABLE EventDetails (
    EventId INT PRIMARY KEY,
    EventName VARCHAR(50) NOT NULL,
    EventCategory VARCHAR(50) NOT NULL,
    EventDate DATETIME NOT NULL,
    Description VARCHAR(255) NULL,
    Status VARCHAR(10) NOT NULL,

    CONSTRAINT CHK_EventName_Length
        CHECK (LEN(EventName) BETWEEN 1 AND 50),

    CONSTRAINT CHK_EventCategory_Length
        CHECK (LEN(EventCategory) BETWEEN 1 AND 50),

    CONSTRAINT CHK_Event_Status
        CHECK (Status IN ('Active', 'In-Active'))
);

--SpeakersDetails

CREATE TABLE SpeakersDetails (
    SpeakerId INT PRIMARY KEY,
    SpeakerName VARCHAR(50) NOT NULL,

    CONSTRAINT CHK_SpeakerName_Length
        CHECK (LEN(SpeakerName) BETWEEN 1 AND 50)
);

--SessionInfo

CREATE TABLE SessionInfo (
    SessionId INT PRIMARY KEY,
    EventId INT NOT NULL,
    SessionTitle VARCHAR(50) NOT NULL,
    SpeakerId INT NOT NULL,
    Description VARCHAR(255) NULL,
    SessionStart DATETIME NOT NULL,
    SessionEnd DATETIME NOT NULL,
    SessionUrl VARCHAR(255) NULL,

    CONSTRAINT FK_Session_Event
        FOREIGN KEY (EventId)
        REFERENCES EventDetails(EventId),

    CONSTRAINT FK_Session_Speaker
        FOREIGN KEY (SpeakerId)
        REFERENCES SpeakersDetails(SpeakerId),

    CONSTRAINT CHK_SessionTitle_Length
        CHECK (LEN(SessionTitle) BETWEEN 1 AND 50),

    CONSTRAINT CHK_Session_Time
        CHECK (SessionEnd > SessionStart)
);

--ParticipantEventDetails

CREATE TABLE ParticipantEventDetails (
    Id INT PRIMARY KEY,
    ParticipantEmailId VARCHAR(100) NOT NULL,
    EventId INT NOT NULL,
    SessionId INT NOT NULL,
    IsAttended BIT NOT NULL,

    CONSTRAINT FK_Participant_User
        FOREIGN KEY (ParticipantEmailId)
        REFERENCES UserInfo(EmailId),

    CONSTRAINT FK_Participant_Event
        FOREIGN KEY (EventId)
        REFERENCES EventDetails(EventId),

    CONSTRAINT FK_Participant_Session
        FOREIGN KEY (SessionId)
        REFERENCES SessionInfo(SessionId),

    CONSTRAINT UQ_Participant_Session
        UNIQUE (ParticipantEmailId, SessionId)
);

--Insert Sample Data

  -- Insert Users

  INSERT INTO UserInfo VALUES
('admin@mail.com','AdminUser','Admin','admin123'),
('john@mail.com','John','Participant','john1234');
