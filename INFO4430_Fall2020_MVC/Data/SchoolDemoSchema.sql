
--DROP TABLE dbo.CourseStudents
--DROP TABLE dbo.Courses
--DROP TABLE dbo.Students
--DROP TABLE dbo.Instructors


CREATE TABLE dbo.Instructors(
	InstructorID int IDENTITY(1,1) PRIMARY KEY
	,FirstName nvarchar(50) NOT NULL
	,LastName nvarchar(60) NOT NULL
	,Office int NOT NULL
)

CREATE TABLE dbo.Students(
	StudentID int IDENTITY(1,1) PRIMARY KEY
	,FirstName nvarchar(50) NOT NULL
	,LastName nvarchar(60) NOT NULL
	,Age int NOT NULL
	,NickName nvarchar(50) NOT NULL
	,FavoriteColor nvarchar(40) NOT NULL
)

CREATE TABLE dbo.Courses(
	CourseID int IDENTITY(1,1) PRIMARY KEY
	,Name nvarchar(50) NOT NULL
	,IndexNumber int NOT NULL
	,ProfessorID int CONSTRAINT Course_Instructor
		REFERENCES dbo.Instructors(InstructorID)
)

CREATE TABLE dbo.CourseStudents(
	CourseID int CONSTRAINT Student_Course
		REFERENCES dbo.Courses(CourseID)
	,StudentID int CONSTRAINT Course_Student
		REFERENCES dbo.Students(StudentID)
)

SET IDENTITY_INSERT dbo.Instructors ON
INSERT INTO Instructors(InstructorID,FirstName,LastName,Office) VALUES
	(1,'Mary','Moore',100)
SET IDENTITY_INSERT dbo.Instructors OFF

SET IDENTITY_INSERT dbo.Students ON
INSERT INTO Students(StudentID,FirstName,LastName,Age,NickName,FavoriteColor) VALUES
	(1,'Jack', 'Sparrow', 100, 'Captain', 'Black'),
	(2,'Will', 'Turner', 21, 'Boy', 'Brown'),
	(3,'Elizabeth', 'Swann', 18, 'Puttin', 'Pink'),
	(4,'Bill', 'Turner', 56, 'Bootstrap', 'Blue'),
	(5,'Hector', 'Barbossa', 120, 'First Mate', 'Red');
SET IDENTITY_INSERT dbo.Students OFF

SET IDENTITY_INSERT dbo.Courses ON
INSERT INTO Courses(CourseID,Name,IndexNumber,ProfessorID) VALUES
	(1,'How to be a Pirate', 512323, 1),
	(2,'Swashbuckling 101', 521357, 1);
SET IDENTITY_INSERT dbo.Courses OFF

INSERT INTO CourseStudents VALUES
	(1, 1),
	(1, 2),
	(1, 3),
	(1, 4),
	(1, 5)

