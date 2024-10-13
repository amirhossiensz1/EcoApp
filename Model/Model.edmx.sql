
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/16/2023 15:45:06
-- Generated from EDMX file: D:\Project\C#Project\ControllerProject\ECOApp\Model\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EchoDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AcsGroupAcsArea_AccessArea]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AcsGroupAcsArea] DROP CONSTRAINT [FK_AcsGroupAcsArea_AccessArea];
GO
IF OBJECT_ID(N'[dbo].[FK_AcsGroupAcsArea_AccessGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AcsGroupAcsArea] DROP CONSTRAINT [FK_AcsGroupAcsArea_AccessGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_Card_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Card] DROP CONSTRAINT [FK_Card_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_DaySchedule_AccessType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DaySchedule] DROP CONSTRAINT [FK_DaySchedule_AccessType];
GO
IF OBJECT_ID(N'[dbo].[FK_DaySchedule_DayType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DaySchedule] DROP CONSTRAINT [FK_DaySchedule_DayType];
GO
IF OBJECT_ID(N'[dbo].[FK_Device_DeviceType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Device] DROP CONSTRAINT [FK_Device_DeviceType];
GO
IF OBJECT_ID(N'[dbo].[FK_DeviceEmp_Device]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DeviceEmp] DROP CONSTRAINT [FK_DeviceEmp_Device];
GO
IF OBJECT_ID(N'[dbo].[FK_DeviceEmp_DeviceType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DeviceEmp] DROP CONSTRAINT [FK_DeviceEmp_DeviceType];
GO
IF OBJECT_ID(N'[dbo].[FK_DeviceEmp_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DeviceEmp] DROP CONSTRAINT [FK_DeviceEmp_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_DeviceSchGroup_AccessArea]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DeviceSchGroup] DROP CONSTRAINT [FK_DeviceSchGroup_AccessArea];
GO
IF OBJECT_ID(N'[dbo].[FK_DeviceSchGroup_Device]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DeviceSchGroup] DROP CONSTRAINT [FK_DeviceSchGroup_Device];
GO
IF OBJECT_ID(N'[dbo].[FK_DeviceSchGroup_ScheduleGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DeviceSchGroup] DROP CONSTRAINT [FK_DeviceSchGroup_ScheduleGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_Employee_AccessGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [FK_Employee_AccessGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_Employee_Organization]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [FK_Employee_Organization];
GO
IF OBJECT_ID(N'[dbo].[FK_Face_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Face] DROP CONSTRAINT [FK_Face_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_Finger_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Finger] DROP CONSTRAINT [FK_Finger_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_HoliDays_HoliDaysGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HoliDays] DROP CONSTRAINT [FK_HoliDays_HoliDaysGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_HoliDaysSchGroup_HoliDaysGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HoliDaysSchGroup] DROP CONSTRAINT [FK_HoliDaysSchGroup_HoliDaysGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_HoliDaysSchGroup_ScheduleGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HoliDaysSchGroup] DROP CONSTRAINT [FK_HoliDaysSchGroup_ScheduleGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_Organization_AccessGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Organization] DROP CONSTRAINT [FK_Organization_AccessGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_Setting_Device]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Setting] DROP CONSTRAINT [FK_Setting_Device];
GO
IF OBJECT_ID(N'[dbo].[FK_WeekSchedule_DayType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WeekSchedule] DROP CONSTRAINT [FK_WeekSchedule_DayType];
GO
IF OBJECT_ID(N'[dbo].[FK_WeekSchedule_ScheduleGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WeekSchedule] DROP CONSTRAINT [FK_WeekSchedule_ScheduleGroup];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AccessArea]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccessArea];
GO
IF OBJECT_ID(N'[dbo].[AccessGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccessGroup];
GO
IF OBJECT_ID(N'[dbo].[AccessType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccessType];
GO
IF OBJECT_ID(N'[dbo].[AcsGroupAcsArea]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AcsGroupAcsArea];
GO
IF OBJECT_ID(N'[dbo].[Card]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Card];
GO
IF OBJECT_ID(N'[dbo].[Client]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Client];
GO
IF OBJECT_ID(N'[dbo].[DaySchedule]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DaySchedule];
GO
IF OBJECT_ID(N'[dbo].[DayType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DayType];
GO
IF OBJECT_ID(N'[dbo].[Device]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Device];
GO
IF OBJECT_ID(N'[dbo].[DeviceEmp]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DeviceEmp];
GO
IF OBJECT_ID(N'[dbo].[DeviceSchGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DeviceSchGroup];
GO
IF OBJECT_ID(N'[dbo].[DeviceType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DeviceType];
GO
IF OBJECT_ID(N'[dbo].[Employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employee];
GO
IF OBJECT_ID(N'[dbo].[Face]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Face];
GO
IF OBJECT_ID(N'[dbo].[Finger]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Finger];
GO
IF OBJECT_ID(N'[dbo].[HoliDays]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HoliDays];
GO
IF OBJECT_ID(N'[dbo].[HoliDaysGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HoliDaysGroup];
GO
IF OBJECT_ID(N'[dbo].[HoliDaysSchGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HoliDaysSchGroup];
GO
IF OBJECT_ID(N'[dbo].[Operator]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Operator];
GO
IF OBJECT_ID(N'[dbo].[Organization]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Organization];
GO
IF OBJECT_ID(N'[dbo].[ScheduleGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScheduleGroup];
GO
IF OBJECT_ID(N'[dbo].[Setting]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Setting];
GO
IF OBJECT_ID(N'[dbo].[TrafficLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TrafficLog];
GO
IF OBJECT_ID(N'[dbo].[WeekSchedule]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WeekSchedule];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AccessAreas'
CREATE TABLE [dbo].[AccessAreas] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL
);
GO

-- Creating table 'AccessGroups'
CREATE TABLE [dbo].[AccessGroups] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'AccessTypes'
CREATE TABLE [dbo].[AccessTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL
);
GO

-- Creating table 'AcsGroupAcsAreas'
CREATE TABLE [dbo].[AcsGroupAcsAreas] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [AcsGroupID] int  NULL,
    [AcsAreaID] int  NULL
);
GO

-- Creating table 'Cards'
CREATE TABLE [dbo].[Cards] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CardNumber] int  NULL,
    [CardData] nvarchar(15)  NOT NULL,
    [StartDate] nvarchar(12)  NULL,
    [EndDate] nvarchar(12)  NULL,
    [EmpID] int  NULL,
    [IsGuest] bit  NULL
);
GO

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ClientName] nvarchar(max)  NULL,
    [ClientIP] nvarchar(15)  NOT NULL,
    [ClientPort] int  NOT NULL,
    [ServerIP] nvarchar(15)  NOT NULL
);
GO

-- Creating table 'DaySchedules'
CREATE TABLE [dbo].[DaySchedules] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [StartTime] nvarchar(15)  NULL,
    [EndTime] nvarchar(15)  NULL,
    [AccessTypeID] int  NULL,
    [DayTypeID] int  NULL
);
GO

-- Creating table 'DayTypes'
CREATE TABLE [dbo].[DayTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL
);
GO

-- Creating table 'Devices'
CREATE TABLE [dbo].[Devices] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [DeviceName] nvarchar(50)  NULL,
    [IP] nvarchar(15)  NULL,
    [Port] int  NULL,
    [SettingID] int  NULL,
    [ZoneID] int  NULL,
    [UDPPort] int  NULL,
    [DeviceSerial] nvarchar(15)  NULL,
    [RegistrationCode] nvarchar(9)  NULL,
    [ActivationCode] nvarchar(65)  NULL,
    [ServerIP] nvarchar(15)  NULL,
    [webUser] nvarchar(15)  NULL,
    [webPass] nvarchar(15)  NULL,
    [TypeId] int  NULL
);
GO

-- Creating table 'DeviceEmps'
CREATE TABLE [dbo].[DeviceEmps] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [EmpID] int  NULL,
    [DeviceID] int  NULL,
    [TypeID] int  NULL,
    [Description] nvarchar(25)  NULL,
    [Finger] bit  NULL,
    [Db] bit  NULL,
    [Picture] bit  NULL
);
GO

-- Creating table 'DeviceSchGroups'
CREATE TABLE [dbo].[DeviceSchGroups] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [AcsAreaID] int  NULL,
    [SchgroupID] int  NULL,
    [DeviceID] int  NULL
);
GO

-- Creating table 'DeviceTypes'
CREATE TABLE [dbo].[DeviceTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(50)  NULL
);
GO

-- Creating table 'Faces'
CREATE TABLE [dbo].[Faces] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [FaceData] nvarchar(max)  NULL,
    [EmpId] int  NULL,
    [PersonalNum] nvarchar(15)  NULL,
    [image] varbinary(max)  NULL
);
GO

-- Creating table 'Fingers'
CREATE TABLE [dbo].[Fingers] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [EmpID] int  NULL,
    [FingerNum] int  NULL,
    [Data] varbinary(max)  NULL,
    [Md5] nvarchar(max)  NULL,
    [DataLength] int  NULL,
    [EnrollTime] nvarchar(max)  NULL,
    [fingerQuality] int  NULL,
    [PdpID] nvarchar(10)  NULL,
    [DataStr] nvarchar(max)  NULL
);
GO

-- Creating table 'HoliDays'
CREATE TABLE [dbo].[HoliDays] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Date] nvarchar(50)  NULL,
    [HolidaysGrpID] int  NULL
);
GO

-- Creating table 'HoliDaysGroups'
CREATE TABLE [dbo].[HoliDaysGroups] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL
);
GO

-- Creating table 'HoliDaysSchGroups'
CREATE TABLE [dbo].[HoliDaysSchGroups] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [HoliDaysGroupID] int  NULL,
    [SchGroupID] int  NULL
);
GO

-- Creating table 'Operators'
CREATE TABLE [dbo].[Operators] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(20)  NULL,
    [Password] nvarchar(20)  NULL,
    [Name] nvarchar(20)  NULL,
    [Lname] nvarchar(20)  NULL
);
GO

-- Creating table 'Organizations'
CREATE TABLE [dbo].[Organizations] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [OrganizationID] int  NULL,
    [name] nvarchar(50)  NULL,
    [Description] nvarchar(max)  NULL,
    [AcsGroupID] int  NULL
);
GO

-- Creating table 'ScheduleGroups'
CREATE TABLE [dbo].[ScheduleGroups] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [year] nchar(4)  NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'Settings'
CREATE TABLE [dbo].[Settings] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [DeviceID] int  NULL,
    [EchoDir] nvarchar(15)  NULL,
    [EchoName] nvarchar(15)  NULL,
    [Description] nvarchar(max)  NULL,
    [DHCP] bit  NULL,
    [IP] nvarchar(15)  NULL,
    [Subnet] nvarchar(15)  NULL,
    [gateway] nvarchar(15)  NULL,
    [ServerEnabled] bit  NULL,
    [ServerIP] nvarchar(15)  NULL,
    [ServerPort] nvarchar(15)  NULL,
    [UDPPort] nvarchar(15)  NULL,
    [TimeOutMenu] int  NULL,
    [NormalBrightness] int  NULL,
    [SleepBrightness] int  NULL,
    [LockHomeScreen] bit  NULL,
    [VacationDuty] bit  NULL,
    [DeviceInfo] bit  NULL,
    [AuthenticationType] nvarchar(15)  NULL,
    [Relay] bit  NULL,
    [RelayDuration] nvarchar(15)  NULL,
    [RelayDriven] int  NULL,
    [Audio] bit  NULL,
    [PreventConsecutive] bit  NULL,
    [ConsecutivePassessDelay] int  NULL,
    [WebUser] nvarchar(10)  NULL,
    [WebPass] nvarchar(10)  NULL
);
GO

-- Creating table 'TrafficLogs'
CREATE TABLE [dbo].[TrafficLogs] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Time] nvarchar(10)  NULL,
    [DeviceID] int  NULL,
    [DeviceSerialNumber] nvarchar(20)  NULL,
    [ReaderNo] nchar(5)  NULL,
    [PersonalNum] nvarchar(10)  NULL,
    [EmpID] int  NULL,
    [Mode] int  NULL,
    [Type] int  NULL,
    [Date] nvarchar(12)  NULL,
    [status] bit  NULL,
    [SuccessPass] bit  NULL,
    [TimeOfSpi] nvarchar(10)  NULL,
    [Access] bit  NULL,
    [ReqType] nvarchar(20)  NULL
);
GO

-- Creating table 'WeekSchedules'
CREATE TABLE [dbo].[WeekSchedules] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [weekday] int  NULL,
    [SchGroupID] int  NULL,
    [DayTypeID] int  NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [OrganizationID] int  NULL,
    [AcsGroupID] int  NULL,
    [EmpFname] nvarchar(max)  NULL,
    [EmpLname] nvarchar(max)  NULL,
    [EmpNationalCode] nvarchar(10)  NULL,
    [PersonalNum] nvarchar(10)  NULL,
    [EmpPinCode] nvarchar(10)  NULL,
    [AuthenticationMode] nvarchar(10)  NULL,
    [TelePhone] nvarchar(20)  NULL,
    [Post] nvarchar(50)  NULL,
    [HasFinger] bit  NULL,
    [Image] varbinary(max)  NULL,
    [HasCard] bit  NULL,
    [MenuAccess] nvarchar(10)  NULL,
    [IsGuest] bit  NULL,
    [PrivateAccess] bit  NULL,
    [SendToZK] bit  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'AccessAreas'
ALTER TABLE [dbo].[AccessAreas]
ADD CONSTRAINT [PK_AccessAreas]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'AccessGroups'
ALTER TABLE [dbo].[AccessGroups]
ADD CONSTRAINT [PK_AccessGroups]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'AccessTypes'
ALTER TABLE [dbo].[AccessTypes]
ADD CONSTRAINT [PK_AccessTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'AcsGroupAcsAreas'
ALTER TABLE [dbo].[AcsGroupAcsAreas]
ADD CONSTRAINT [PK_AcsGroupAcsAreas]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Cards'
ALTER TABLE [dbo].[Cards]
ADD CONSTRAINT [PK_Cards]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'DaySchedules'
ALTER TABLE [dbo].[DaySchedules]
ADD CONSTRAINT [PK_DaySchedules]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'DayTypes'
ALTER TABLE [dbo].[DayTypes]
ADD CONSTRAINT [PK_DayTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Devices'
ALTER TABLE [dbo].[Devices]
ADD CONSTRAINT [PK_Devices]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'DeviceEmps'
ALTER TABLE [dbo].[DeviceEmps]
ADD CONSTRAINT [PK_DeviceEmps]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'DeviceSchGroups'
ALTER TABLE [dbo].[DeviceSchGroups]
ADD CONSTRAINT [PK_DeviceSchGroups]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'DeviceTypes'
ALTER TABLE [dbo].[DeviceTypes]
ADD CONSTRAINT [PK_DeviceTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Faces'
ALTER TABLE [dbo].[Faces]
ADD CONSTRAINT [PK_Faces]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Fingers'
ALTER TABLE [dbo].[Fingers]
ADD CONSTRAINT [PK_Fingers]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'HoliDays'
ALTER TABLE [dbo].[HoliDays]
ADD CONSTRAINT [PK_HoliDays]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'HoliDaysGroups'
ALTER TABLE [dbo].[HoliDaysGroups]
ADD CONSTRAINT [PK_HoliDaysGroups]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'HoliDaysSchGroups'
ALTER TABLE [dbo].[HoliDaysSchGroups]
ADD CONSTRAINT [PK_HoliDaysSchGroups]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Operators'
ALTER TABLE [dbo].[Operators]
ADD CONSTRAINT [PK_Operators]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Organizations'
ALTER TABLE [dbo].[Organizations]
ADD CONSTRAINT [PK_Organizations]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ScheduleGroups'
ALTER TABLE [dbo].[ScheduleGroups]
ADD CONSTRAINT [PK_ScheduleGroups]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Settings'
ALTER TABLE [dbo].[Settings]
ADD CONSTRAINT [PK_Settings]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TrafficLogs'
ALTER TABLE [dbo].[TrafficLogs]
ADD CONSTRAINT [PK_TrafficLogs]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'WeekSchedules'
ALTER TABLE [dbo].[WeekSchedules]
ADD CONSTRAINT [PK_WeekSchedules]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AcsAreaID] in table 'AcsGroupAcsAreas'
ALTER TABLE [dbo].[AcsGroupAcsAreas]
ADD CONSTRAINT [FK_AcsGroupAcsArea_AccessArea]
    FOREIGN KEY ([AcsAreaID])
    REFERENCES [dbo].[AccessAreas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AcsGroupAcsArea_AccessArea'
CREATE INDEX [IX_FK_AcsGroupAcsArea_AccessArea]
ON [dbo].[AcsGroupAcsAreas]
    ([AcsAreaID]);
GO

-- Creating foreign key on [AcsAreaID] in table 'DeviceSchGroups'
ALTER TABLE [dbo].[DeviceSchGroups]
ADD CONSTRAINT [FK_DeviceSchGroup_AccessArea]
    FOREIGN KEY ([AcsAreaID])
    REFERENCES [dbo].[AccessAreas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DeviceSchGroup_AccessArea'
CREATE INDEX [IX_FK_DeviceSchGroup_AccessArea]
ON [dbo].[DeviceSchGroups]
    ([AcsAreaID]);
GO

-- Creating foreign key on [AcsGroupID] in table 'AcsGroupAcsAreas'
ALTER TABLE [dbo].[AcsGroupAcsAreas]
ADD CONSTRAINT [FK_AcsGroupAcsArea_AccessGroup]
    FOREIGN KEY ([AcsGroupID])
    REFERENCES [dbo].[AccessGroups]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AcsGroupAcsArea_AccessGroup'
CREATE INDEX [IX_FK_AcsGroupAcsArea_AccessGroup]
ON [dbo].[AcsGroupAcsAreas]
    ([AcsGroupID]);
GO

-- Creating foreign key on [AcsGroupID] in table 'Organizations'
ALTER TABLE [dbo].[Organizations]
ADD CONSTRAINT [FK_Organization_AccessGroup]
    FOREIGN KEY ([AcsGroupID])
    REFERENCES [dbo].[AccessGroups]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Organization_AccessGroup'
CREATE INDEX [IX_FK_Organization_AccessGroup]
ON [dbo].[Organizations]
    ([AcsGroupID]);
GO

-- Creating foreign key on [AccessTypeID] in table 'DaySchedules'
ALTER TABLE [dbo].[DaySchedules]
ADD CONSTRAINT [FK_DaySchedule_AccessType]
    FOREIGN KEY ([AccessTypeID])
    REFERENCES [dbo].[AccessTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DaySchedule_AccessType'
CREATE INDEX [IX_FK_DaySchedule_AccessType]
ON [dbo].[DaySchedules]
    ([AccessTypeID]);
GO

-- Creating foreign key on [DayTypeID] in table 'DaySchedules'
ALTER TABLE [dbo].[DaySchedules]
ADD CONSTRAINT [FK_DaySchedule_DayType]
    FOREIGN KEY ([DayTypeID])
    REFERENCES [dbo].[DayTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DaySchedule_DayType'
CREATE INDEX [IX_FK_DaySchedule_DayType]
ON [dbo].[DaySchedules]
    ([DayTypeID]);
GO

-- Creating foreign key on [DayTypeID] in table 'WeekSchedules'
ALTER TABLE [dbo].[WeekSchedules]
ADD CONSTRAINT [FK_WeekSchedule_DayType]
    FOREIGN KEY ([DayTypeID])
    REFERENCES [dbo].[DayTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WeekSchedule_DayType'
CREATE INDEX [IX_FK_WeekSchedule_DayType]
ON [dbo].[WeekSchedules]
    ([DayTypeID]);
GO

-- Creating foreign key on [TypeId] in table 'Devices'
ALTER TABLE [dbo].[Devices]
ADD CONSTRAINT [FK_Device_DeviceType]
    FOREIGN KEY ([TypeId])
    REFERENCES [dbo].[DeviceTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Device_DeviceType'
CREATE INDEX [IX_FK_Device_DeviceType]
ON [dbo].[Devices]
    ([TypeId]);
GO

-- Creating foreign key on [DeviceID] in table 'DeviceEmps'
ALTER TABLE [dbo].[DeviceEmps]
ADD CONSTRAINT [FK_DeviceEmp_Device]
    FOREIGN KEY ([DeviceID])
    REFERENCES [dbo].[Devices]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DeviceEmp_Device'
CREATE INDEX [IX_FK_DeviceEmp_Device]
ON [dbo].[DeviceEmps]
    ([DeviceID]);
GO

-- Creating foreign key on [DeviceID] in table 'DeviceSchGroups'
ALTER TABLE [dbo].[DeviceSchGroups]
ADD CONSTRAINT [FK_DeviceSchGroup_Device]
    FOREIGN KEY ([DeviceID])
    REFERENCES [dbo].[Devices]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DeviceSchGroup_Device'
CREATE INDEX [IX_FK_DeviceSchGroup_Device]
ON [dbo].[DeviceSchGroups]
    ([DeviceID]);
GO

-- Creating foreign key on [DeviceID] in table 'Settings'
ALTER TABLE [dbo].[Settings]
ADD CONSTRAINT [FK_Setting_Device]
    FOREIGN KEY ([DeviceID])
    REFERENCES [dbo].[Devices]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Setting_Device'
CREATE INDEX [IX_FK_Setting_Device]
ON [dbo].[Settings]
    ([DeviceID]);
GO

-- Creating foreign key on [TypeID] in table 'DeviceEmps'
ALTER TABLE [dbo].[DeviceEmps]
ADD CONSTRAINT [FK_DeviceEmp_DeviceType]
    FOREIGN KEY ([TypeID])
    REFERENCES [dbo].[DeviceTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DeviceEmp_DeviceType'
CREATE INDEX [IX_FK_DeviceEmp_DeviceType]
ON [dbo].[DeviceEmps]
    ([TypeID]);
GO

-- Creating foreign key on [SchgroupID] in table 'DeviceSchGroups'
ALTER TABLE [dbo].[DeviceSchGroups]
ADD CONSTRAINT [FK_DeviceSchGroup_ScheduleGroup]
    FOREIGN KEY ([SchgroupID])
    REFERENCES [dbo].[ScheduleGroups]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DeviceSchGroup_ScheduleGroup'
CREATE INDEX [IX_FK_DeviceSchGroup_ScheduleGroup]
ON [dbo].[DeviceSchGroups]
    ([SchgroupID]);
GO

-- Creating foreign key on [HolidaysGrpID] in table 'HoliDays'
ALTER TABLE [dbo].[HoliDays]
ADD CONSTRAINT [FK_HoliDays_HoliDaysGroup]
    FOREIGN KEY ([HolidaysGrpID])
    REFERENCES [dbo].[HoliDaysGroups]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HoliDays_HoliDaysGroup'
CREATE INDEX [IX_FK_HoliDays_HoliDaysGroup]
ON [dbo].[HoliDays]
    ([HolidaysGrpID]);
GO

-- Creating foreign key on [HoliDaysGroupID] in table 'HoliDaysSchGroups'
ALTER TABLE [dbo].[HoliDaysSchGroups]
ADD CONSTRAINT [FK_HoliDaysSchGroup_HoliDaysGroup]
    FOREIGN KEY ([HoliDaysGroupID])
    REFERENCES [dbo].[HoliDaysGroups]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HoliDaysSchGroup_HoliDaysGroup'
CREATE INDEX [IX_FK_HoliDaysSchGroup_HoliDaysGroup]
ON [dbo].[HoliDaysSchGroups]
    ([HoliDaysGroupID]);
GO

-- Creating foreign key on [SchGroupID] in table 'HoliDaysSchGroups'
ALTER TABLE [dbo].[HoliDaysSchGroups]
ADD CONSTRAINT [FK_HoliDaysSchGroup_ScheduleGroup]
    FOREIGN KEY ([SchGroupID])
    REFERENCES [dbo].[ScheduleGroups]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HoliDaysSchGroup_ScheduleGroup'
CREATE INDEX [IX_FK_HoliDaysSchGroup_ScheduleGroup]
ON [dbo].[HoliDaysSchGroups]
    ([SchGroupID]);
GO

-- Creating foreign key on [SchGroupID] in table 'WeekSchedules'
ALTER TABLE [dbo].[WeekSchedules]
ADD CONSTRAINT [FK_WeekSchedule_ScheduleGroup]
    FOREIGN KEY ([SchGroupID])
    REFERENCES [dbo].[ScheduleGroups]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WeekSchedule_ScheduleGroup'
CREATE INDEX [IX_FK_WeekSchedule_ScheduleGroup]
ON [dbo].[WeekSchedules]
    ([SchGroupID]);
GO

-- Creating foreign key on [AcsGroupID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_Employee_AccessGroup]
    FOREIGN KEY ([AcsGroupID])
    REFERENCES [dbo].[AccessGroups]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Employee_AccessGroup'
CREATE INDEX [IX_FK_Employee_AccessGroup]
ON [dbo].[Employees]
    ([AcsGroupID]);
GO

-- Creating foreign key on [EmpID] in table 'Cards'
ALTER TABLE [dbo].[Cards]
ADD CONSTRAINT [FK_Card_Employee]
    FOREIGN KEY ([EmpID])
    REFERENCES [dbo].[Employees]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Card_Employee'
CREATE INDEX [IX_FK_Card_Employee]
ON [dbo].[Cards]
    ([EmpID]);
GO

-- Creating foreign key on [EmpID] in table 'DeviceEmps'
ALTER TABLE [dbo].[DeviceEmps]
ADD CONSTRAINT [FK_DeviceEmp_Employee]
    FOREIGN KEY ([EmpID])
    REFERENCES [dbo].[Employees]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DeviceEmp_Employee'
CREATE INDEX [IX_FK_DeviceEmp_Employee]
ON [dbo].[DeviceEmps]
    ([EmpID]);
GO

-- Creating foreign key on [OrganizationID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_Employee_Organization]
    FOREIGN KEY ([OrganizationID])
    REFERENCES [dbo].[Organizations]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Employee_Organization'
CREATE INDEX [IX_FK_Employee_Organization]
ON [dbo].[Employees]
    ([OrganizationID]);
GO

-- Creating foreign key on [EmpId] in table 'Faces'
ALTER TABLE [dbo].[Faces]
ADD CONSTRAINT [FK_Face_Employee]
    FOREIGN KEY ([EmpId])
    REFERENCES [dbo].[Employees]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Face_Employee'
CREATE INDEX [IX_FK_Face_Employee]
ON [dbo].[Faces]
    ([EmpId]);
GO

-- Creating foreign key on [EmpID] in table 'Fingers'
ALTER TABLE [dbo].[Fingers]
ADD CONSTRAINT [FK_Finger_Employee]
    FOREIGN KEY ([EmpID])
    REFERENCES [dbo].[Employees]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Finger_Employee'
CREATE INDEX [IX_FK_Finger_Employee]
ON [dbo].[Fingers]
    ([EmpID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------