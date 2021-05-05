## Math Masters Tutoring Center

### The Math Masters Tutoring Service website connects students to tutors to help all students reach their goals in mathematics.
Table of Contents:
1. Description
1. Installation
1. Usage
1. Credits
1. License

#### 1. Description
The Math Masters Tutoring Service connects students to tutors in the local area. Administrators will be able to create, read, update, and delete students, tutors, and courses to the web application. Students will be able to create, read, update, and delete tutoring sessions (schedule). The app is built on four data tables: Student, Tutor, Course, and Schedule. 
1.	The properties of the Tutor Table are Id (Primary Key), FirstName, and LastName, plus the iCollection CourseList for the list of courses connected to the tutor.
1.	The properties of the Student Table are Id (Primary Key), FirstName, LastName, and GradeLevel.
1.	The properties of the Course Table are Id (Primary Key), Name, and Description, plus the iCollection TutorList, for the list of tutors connected to the course.
1.	The Schedule Table contains the individual tutoring sessions. Its properties are Id (Primary Key) and Rate, which is the hourly cost for the tutoring session, plus the DateTime of the scheduled session. It also contains three foreign keys to the one StudentId (student), one TutorId (tutor), and one CourseId (course) for that individual session.  


#### 2. Installation
MathMaster is an ASP.NET MVC web application built using Visual Studio with Entity Framework 6, Bootstrap, and jquery and deployed using Microsoft Azure.

#### 3. Usage:
It is not operational tutoring center. The current edition is designed for an administrator to select a student based on the student id number. The admininstrator can than build a schedule for the student. In the future, when a student logs in, the student id will automatically populate, allowing the student to build their own schedule.

#### 4. Credits: This web application for administrators was built for completion of Red Badge at Eleven Fifty Academy by Cindy Morgan.

https://docs.microsoft.com/en-us/aspnet/overview
https://docs.microsoft.com/en-us/ef/
https://www.entityframeworktutorial.net/

#### 5. License
Although it is operational, this project is not yet ready for primetime.
