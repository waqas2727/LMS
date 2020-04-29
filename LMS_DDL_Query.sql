Create database LMS 
 
create table Admins(
AdminId varchar(50) not Null Primary Key,
UserNames varchar(50) not null,
Passwords varchar(50) not null,
Images image null
)

create table Student(
StudentId varchar(50) not Null Primary Key,	
Passwords varchar(50) not Null,	
DeptartId int not Null,
Session varchar(50) not Null,	
DateOfBirth date Null,
FName varchar(50) not Null,
LName varchar(50) not Null,
Phone varchar(50) not Null,
Gender char not Null check (Gender = 'M' or Gender = 'F'),	
Email varchar(50) not Null,
Images image null
)

Create table Faculty(
FacultyId varchar(50) not Null Primary Key,	
Passwords varchar(50) not Null,	
DeptartId int not Null,
CourseId varchar(50) not Null,	
DateOfBirth date Null,
FName varchar(50) not Null,
LName varchar(50) not Null,
Phone varchar(50) not Null,
Gender char not Null check (Gender = 'M' or Gender = 'F'),	
Email varchar(50) not Null,
Images image null
)

Create table Course(
CourseId varchar(50) not Null Primary Key,	
CourseName varchar(50) not Null,
CeditHours int not Null,
DeptartmentId int not Null
)

Create table Prerequisites(
CourseId varchar(50) not Null,	
PrerequistCourseId varchar(50) not Null
)

Create table Section(
SectionId varchar(50) not Null unique,
StudentId varchar(50) not Null,	
Section char not Null,
Session varchar(50) not Null,
DeptartmentId int not Null
Primary Key(SectionId,StudentId)
)

Create table GradeReport(
StudentId varchar(50) not Null,
Marks int not Null check (Marks >= 0 and Marks <= 100), 	
Garde varchar(50) not Null,	
CourseId varchar(50) not Null
)

Create table AssesmentMarks(
StudentId	varchar(50) not Null,
CourseId	varchar(50) not Null,
AssessmentId int not Null,	
Dates date not Null,
TotalMarks	int not Null check  (TotalMarks > 0),
ObatinMarks int not Null,	
AssessmentType int not Null check (AssessmentType in (1,2,3,4,5))
Primary Key(AssessmentId,AssessmentType)
)

Create table Deptartment(
DeptartmentId int not Null Primary Key,
DeptartmentName varchar(50) not Null
) 

Create table StudentCourse(
StudentId 	varchar(50) not Null,
CourseId	varchar(50) not Null,
SectionId  varchar(50) not Null,
Status int not Null check(Status in (1,2,3))
Primary Key (StudentId,CourseId,SectionId)
)

Alter table AssesmentMarks
add constraint stuassesfk foreign key (StudentId) references Student(StudentId) 
 
Alter table AssesmentMarks
add constraint courseassesfk foreign key (CourseId) references Course(CourseId)

Alter table GradeReport
add constraint stureportfk foreign key (StudentId) references Student(StudentId)

Alter table Prerequisites
add constraint coursePrerequfk foreign key (CourseId) references Course(CourseId)

Alter table Course
add constraint deptcoursefk foreign key (DeptartmentId) references Deptartment(DeptartmentId)

Alter table Faculty
add constraint deptfacultyfk foreign key (DeptartId) references Deptartment(DeptartmentId)

Alter table Faculty
add constraint coursefacultyfk foreign key (CourseId) references Course(CourseId)

Alter table Section
add constraint studsectionfk foreign key (StudentId) references Student(StudentId)

Alter table Section
add constraint deptsectionfk foreign key (DeptartmentId) references Deptartment(DeptartmentId)

Alter table StudentCourse
add constraint studStudentCoursefk foreign key (StudentId) references Student(StudentId)

Alter table StudentCourse
add constraint courseStudentCoursefk foreign key (CourseId) references Course(CourseId)

Alter table StudentCourse
add constraint sectionStudentCoursefk foreign key (SectionId) references Section(SectionId)


