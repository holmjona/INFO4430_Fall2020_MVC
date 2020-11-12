-- =============================================
-- Author:		holmjona
-- Create date:	11 Nov 2020
-- Description:	Add a new  Instructor to the database.
-- =============================================
CREATE PROCEDURE dbo.sproc_InstructorAdd
@InstructorID int OUTPUT,
@FirstName nvarchar(50),
@LastName nvarchar(60),
@Office int
AS
     INSERT INTO Instructors(FirstName,LastName,Office)
               VALUES(@FirstName,@LastName,@Office)
     SET @InstructorID = @@IDENTITY
GO

GRANT EXECUTE ON dbo.sproc_InstructorAdd TO db_editor
GO
-- =============================================
-- Author:		holmjona
-- Create date:	11 Nov 2020
-- Description:	Update Instructor in the database.
-- =============================================
CREATE PROCEDURE dbo.sproc_InstructorUpdate
@InstructorID int,
@FirstName nvarchar(50),
@LastName nvarchar(60),
@Office int
AS
     UPDATE Instructors
          SET
               FirstName = @FirstName,
               LastName = @LastName,
               Office = @Office
          WHERE InstructorID = @InstructorID
GO

GRANT EXECUTE ON dbo.sproc_InstructorUpdate TO db_editor
GO
-- =============================================
-- Author:		holmjona
-- Create date:	11 Nov 2020
-- Description:	Retrieve specific Instructor from the database.
-- =============================================
CREATE PROCEDURE dbo.sprocInstructorGet
@InstructorID int
AS
BEGIN
     -- SET NOCOUNT ON added to prevent extra result sets from
     -- interfering with SELECT statements.
     SET NOCOUNT ON;

     SELECT * FROM Instructors
     WHERE InstructorID = @InstructorID
END
GO

GRANT EXECUTE ON dbo.sprocInstructorGet TO db_reader
GO
-- =============================================
-- Author:		holmjona
-- Create date:	11 Nov 2020
-- Description:	Retrieve all Instructors from the database.
-- =============================================
CREATE PROCEDURE dbo.sprocInstructorsGetAll
AS
BEGIN
     -- SET NOCOUNT ON added to prevent extra result sets from
     -- interfering with SELECT statements.
     SET NOCOUNT ON;

     SELECT * FROM Instructors
END
GO

GRANT EXECUTE ON dbo.sprocInstructorsGetAll TO db_reader
GO
-- =============================================
-- Author:		holmjona
-- Create date:	11 Nov 2020
-- Description:	Remove specific Instructor from the database.
-- =============================================
CREATE PROCEDURE dbo.sproc_InstructorRemove
@InstructorID int
AS
BEGIN
     DELETE FROM Instructors
          WHERE InstructorID = @InstructorID

     -- Return -1 if we had an error
     IF @@ERROR > 0
     BEGIN
          RETURN -1
     END
     ELSE
     BEGIN
          RETURN 1
     END
END
GO

GRANT EXECUTE ON dbo.sproc_InstructorRemove TO db_editor
GO
-- =============================================
-- Author:		holmjona
-- Create date:	11 Nov 2020
-- Description:	Add a new  Student to the database.
-- =============================================
CREATE PROCEDURE dbo.sproc_StudentAdd
@StudentID int OUTPUT,
@FirstName nvarchar(50),
@LastName nvarchar(60),
@Age int,
@NickName nvarchar(50),
@FavoriteColor nvarchar(40)
AS
     INSERT INTO Students(FirstName,LastName,Age,NickName,FavoriteColor)
               VALUES(@FirstName,@LastName,@Age,@NickName,
               @FavoriteColor)
     SET @StudentID = @@IDENTITY
GO

GRANT EXECUTE ON dbo.sproc_StudentAdd TO db_editor
GO
-- =============================================
-- Author:		holmjona
-- Create date:	11 Nov 2020
-- Description:	Update Student in the database.
-- =============================================
CREATE PROCEDURE dbo.sproc_StudentUpdate
@StudentID int,
@FirstName nvarchar(50),
@LastName nvarchar(60),
@Age int,
@NickName nvarchar(50),
@FavoriteColor nvarchar(40)
AS
     UPDATE Students
          SET
               FirstName = @FirstName,
               LastName = @LastName,
               Age = @Age,
               NickName = @NickName,
               FavoriteColor = @FavoriteColor
          WHERE StudentID = @StudentID
GO

GRANT EXECUTE ON dbo.sproc_StudentUpdate TO db_editor
GO
-- =============================================
-- Author:		holmjona
-- Create date:	11 Nov 2020
-- Description:	Retrieve specific Student from the database.
-- =============================================
CREATE PROCEDURE dbo.sprocStudentGet
@StudentID int
AS
BEGIN
     -- SET NOCOUNT ON added to prevent extra result sets from
     -- interfering with SELECT statements.
     SET NOCOUNT ON;

     SELECT * FROM Students
     WHERE StudentID = @StudentID
END
GO

GRANT EXECUTE ON dbo.sprocStudentGet TO db_reader
GO
-- =============================================
-- Author:		holmjona
-- Create date:	11 Nov 2020
-- Description:	Retrieve all Students from the database.
-- =============================================
CREATE PROCEDURE dbo.sprocStudentsGetAll
AS
BEGIN
     -- SET NOCOUNT ON added to prevent extra result sets from
     -- interfering with SELECT statements.
     SET NOCOUNT ON;

     SELECT * FROM Students
END
GO

GRANT EXECUTE ON dbo.sprocStudentsGetAll TO db_reader
GO
-- =============================================
-- Author:		holmjona
-- Create date:	11 Nov 2020
-- Description:	Remove specific Student from the database.
-- =============================================
CREATE PROCEDURE dbo.sproc_StudentRemove
@StudentID int
AS
BEGIN
     DELETE FROM Students
          WHERE StudentID = @StudentID

     -- Return -1 if we had an error
     IF @@ERROR > 0
     BEGIN
          RETURN -1
     END
     ELSE
     BEGIN
          RETURN 1
     END
END
GO

GRANT EXECUTE ON dbo.sproc_StudentRemove TO db_editor
GO
-- =============================================
-- Author:		holmjona
-- Create date:	11 Nov 2020
-- Description:	Add a new  Course to the database.
-- =============================================
CREATE PROCEDURE dbo.sproc_CourseAdd
@CourseID int OUTPUT,
@Name nvarchar(50),
@IndexNumber int,
@ProfessorID int
AS
     INSERT INTO Courses(Name,IndexNumber,ProfessorID)
               VALUES(@Name,@IndexNumber,@ProfessorID)
     SET @CourseID = @@IDENTITY
GO

GRANT EXECUTE ON dbo.sproc_CourseAdd TO db_editor
GO
-- =============================================
-- Author:		holmjona
-- Create date:	11 Nov 2020
-- Description:	Update Course in the database.
-- =============================================
CREATE PROCEDURE dbo.sproc_CourseUpdate
@CourseID int,
@Name nvarchar(50),
@IndexNumber int,
@ProfessorID int
AS
     UPDATE Courses
          SET
               Name = @Name,
               IndexNumber = @IndexNumber,
               ProfessorID = @ProfessorID
          WHERE CourseID = @CourseID
GO

GRANT EXECUTE ON dbo.sproc_CourseUpdate TO db_editor
GO
-- =============================================
-- Author:		holmjona
-- Create date:	11 Nov 2020
-- Description:	Retrieve specific Course from the database.
-- =============================================
CREATE PROCEDURE dbo.sprocCourseGet
@CourseID int
AS
BEGIN
     -- SET NOCOUNT ON added to prevent extra result sets from
     -- interfering with SELECT statements.
     SET NOCOUNT ON;

     SELECT * FROM Courses
     WHERE CourseID = @CourseID
END
GO

GRANT EXECUTE ON dbo.sprocCourseGet TO db_reader
GO
-- =============================================
-- Author:		holmjona
-- Create date:	11 Nov 2020
-- Description:	Retrieve all Courses from the database.
-- =============================================
CREATE PROCEDURE dbo.sprocCoursesGetAll
AS
BEGIN
     -- SET NOCOUNT ON added to prevent extra result sets from
     -- interfering with SELECT statements.
     SET NOCOUNT ON;

     SELECT * FROM Courses
END
GO

GRANT EXECUTE ON dbo.sprocCoursesGetAll TO db_reader
GO
-- =============================================
-- Author:		holmjona
-- Create date:	11 Nov 2020
-- Description:	Remove specific Course from the database.
-- =============================================
CREATE PROCEDURE dbo.sproc_CourseRemove
@CourseID int
AS
BEGIN
     DELETE FROM Courses
          WHERE CourseID = @CourseID

     -- Return -1 if we had an error
     IF @@ERROR > 0
     BEGIN
          RETURN -1
     END
     ELSE
     BEGIN
          RETURN 1
     END
END
GO

GRANT EXECUTE ON dbo.sproc_CourseRemove TO db_editor
GO
-- =============================================
-- Author:		holmjona
-- Create date:	11 Nov 2020
-- Description:	Add a new  CourseStudent to the database.
-- =============================================
CREATE PROCEDURE dbo.sproc_CourseStudentAdd
@CourseID int OUTPUT,
@StudentID int
AS
     INSERT INTO CourseStudents(StudentID)
               VALUES(@StudentID)
     SET @CourseID = @@IDENTITY
GO

GRANT EXECUTE ON dbo.sproc_CourseStudentAdd TO db_editor
GO
-- =============================================
-- Author:		holmjona
-- Create date:	11 Nov 2020
-- Description:	Update CourseStudent in the database.
-- =============================================
CREATE PROCEDURE dbo.sproc_CourseStudentUpdate
@CourseID int,
@StudentID int
AS
     UPDATE CourseStudents
          SET
               StudentID = @StudentID
          WHERE CourseID = @CourseID
GO

GRANT EXECUTE ON dbo.sproc_CourseStudentUpdate TO db_editor
GO
-- =============================================
-- Author:		holmjona
-- Create date:	11 Nov 2020
-- Description:	Retrieve specific CourseStudent from the database.
-- =============================================
CREATE PROCEDURE dbo.sprocCourseStudentGet
@CourseID int
AS
BEGIN
     -- SET NOCOUNT ON added to prevent extra result sets from
     -- interfering with SELECT statements.
     SET NOCOUNT ON;

     SELECT * FROM CourseStudents
     WHERE CourseID = @CourseID
END
GO

GRANT EXECUTE ON dbo.sprocCourseStudentGet TO db_reader
GO
-- =============================================
-- Author:		holmjona
-- Create date:	11 Nov 2020
-- Description:	Retrieve all CourseStudents from the database.
-- =============================================
CREATE PROCEDURE dbo.sprocCourseStudentsGetAll
AS
BEGIN
     -- SET NOCOUNT ON added to prevent extra result sets from
     -- interfering with SELECT statements.
     SET NOCOUNT ON;

     SELECT * FROM CourseStudents
END
GO

GRANT EXECUTE ON dbo.sprocCourseStudentsGetAll TO db_reader
GO
-- =============================================
-- Author:		holmjona
-- Create date:	11 Nov 2020
-- Description:	Remove specific CourseStudent from the database.
-- =============================================
CREATE PROCEDURE dbo.sproc_CourseStudentRemove
@CourseID int
AS
BEGIN
     DELETE FROM CourseStudents
          WHERE CourseID = @CourseID

     -- Return -1 if we had an error
     IF @@ERROR > 0
     BEGIN
          RETURN -1
     END
     ELSE
     BEGIN
          RETURN 1
     END
END
GO

GRANT EXECUTE ON dbo.sproc_CourseStudentRemove TO db_editor
GO
