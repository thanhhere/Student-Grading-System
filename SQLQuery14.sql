use Student_Grading_System
go

CREATE TABLE Useres (
    UserID INT PRIMARY KEY IDENTITY (1,1),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Role NVARCHAR(20) CHECK (Role IN ('Admin', 'Teacher', 'Student')) NOT NULL
);

DELETE FROM Useres
WHERE Role = 'Admin';


CREATE TABLE Students (
    StudentID INT PRIMARY KEY IDENTITY (1,1),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    UserID INT FOREIGN KEY REFERENCES Useres(UserID)
);

CREATE TABLE Teachers (
    TeacherID INT PRIMARY KEY IDENTITY (1,1),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    UserID INT FOREIGN KEY REFERENCES Useres(UserID)
);


CREATE TABLE Courses (
    CourseID INT PRIMARY KEY IDENTITY (1,1),
    CourseName NVARCHAR(100) NOT NULL,
    TeacherID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
);

CREATE TABLE Gradess (
    GradeID INT PRIMARY KEY IDENTITY(1,1),
    Score DECIMAL(5, 2) NOT NULL,
    CourseID INT FOREIGN KEY REFERENCES Courses(CourseID),
    StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
);
ALTER TABLE Gradess
ALTER COLUMN Score NVARCHAR(10);

SELECT * FROM Gradess



------Useres
INSERT INTO Useres ( Username, Password, Role )
VALUES ( 'Thanh09', '12345', 'Student');
INSERT INTO Useres ( Username, Password, Role )
vALUES ('Trung01','6789', 'Student')
INSERT INTO Useres ( Username, Password, Role )
VALUES ('Hanh03', '0001', 'Teacher')
INSERT INTO Useres ( Username, Password, Role )
VALUES ('Dong02', '2005', 'Teacher')


SELECT * FROM Useres


-----Student
INSERT INTO Students (Name, Email)
VALUES ('Pham_Van_Thanh', 'tp2995392@gmail.com');
INSERT INTO Students (Name, Email, UserID)
VALUES ('Pham_Hieu_Trung', 'trungatk123@gmail.com');

UPDATE Students
SET Name = 'Pham_Van_Thanh', 
    Email = 'tp2995392@gmail.com',
	UserID = '1'
WHERE StudentID = 1;

UPDATE Students
SET Name = 'Pham_Hieu_Trung', 
    Email = 'trungatk123@gmail.com',
	UserID = '2'
WHERE StudentID = 2;


SELECT * FROM Students

----------Teacher
INSERT INTO Teachers (Name, Email)
VALUES ('Ngo_Thi_Hong_Hanh', 'Hanh0123@gmail.com');

INSERT INTO Teachers  (Name, Email)
VALUES ('Dinh_Van_Dong', 'dong00012gmail.com') 

UPDATE Teachers
SET Name = 'Ngo_Thi_Hong_Hanh', 
    Email = 'Hanh0123@gmail.com',
	UserID = '3'
WHERE TeacherID = 1;

UPDATE Teachers
SET Name = 'Dinh_Van_Dong', 
    Email = 'dong0001@gmail.com',
	UserID = '5'
WHERE TeacherID = 3;



SELECT * FROM Teachers 



---Course
INSERT INTO Courses (CourseName)
VALUES ('Database and Design Development');

INSERT INTO Courses (CourseName)
VALUES ('Professional Practice');

UPDATE Courses
SET TeacherID = (SELECT TeacherID FROM Teachers WHERE Name = 'Dinh_Van_Dong')
WHERE CourseName = 'Professional Practice';

UPDATE Courses
SET TeacherID = (SELECT TeacherID FROM Teachers WHERE Name = 'Ngo_Thi_Hong_Hanh')
WHERE CourseName = 'Database and Design Development';

SELECT * FROM Courses

-----Gradess
INSERT INTO Gradess (Score)
VALUES ('M');

INSERT INTO Gradess (Score)
VALUES ('P');

UPDATE Gradess
SET CourseID = (SELECT CourseID FROM Courses WHERE CourseName = 'Database and Design Development'),
    StudentID = (SELECT StudentID FROM Students WHERE Name = 'Pham_Van_Thanh')
WHERE GradeID = 1;

UPDATE Gradess
SET CourseID = (SELECT CourseID FROM Courses WHERE CourseName = 'Database and Design Development'),
    StudentID = (SELECT StudentID FROM Students WHERE Name = 'Pham_Hieu_Trung')
WHERE GradeID = 2;


INSERT INTO Students (Name, Email, UserID)
VALUES ('Nguyen_Duc_Hung', 'hung1122@gmail.com', (SELECT UserID FROM Useres WHERE Role = 'Student'));
SELECT SCOPE_IDENTITY(); 

INSERT INTO Gradess (Score, CourseID, StudentID)
VALUES ('M', '1', '3');

INSERT INTO Gradess (Score, CourseID, StudentID)
VALUES ('P', '3', '1');
INSERT INTO Gradess (Score, CourseID, StudentID)
VALUES ('M', '3', '2');
INSERT INTO Gradess (Score, CourseID, StudentID)
VALUES ('M', '3', '13');
INSERT INTO Gradess (Score, CourseID, StudentID)
VALUES ('D', '3', '18');





SELECT StudentID, Name, Email
FROM [dbo].[Students]

SELECT [CourseID],[CourseName]
FROM [dbo].[Courses]

SELECT [UserID], [Username], [Password], [Role]
FROM [dbo].[Useres]
 
SELECT [TeacherID], [Name], [Email]
FROM [dbo].[Teachers]

SELECT [GradeID], [Score]
FROM [dbo].[Gradess]




SELECT 
    s.UserID,
    s.Name AS StudentName,
    g.Score,
    s.Email,
    t.Name AS TeacherName,
    c.CourseName
FROM 
    Students s
JOIN 
    Gradess g ON s.StudentID = g.StudentID
JOIN 
    Courses c ON g.CourseID = c.CourseID
JOIN 
    Teachers t ON c.TeacherID = t.TeacherID;


SELECT [UserID], [Role]
FROM [dbo].[Useres]

SELECT * FROM [dbo].[Useres]
 







