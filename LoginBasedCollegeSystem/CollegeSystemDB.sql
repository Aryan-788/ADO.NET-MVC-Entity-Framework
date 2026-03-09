use CollegeSystemDB;

INSERT INTO Students (IdCardNumber, Password, Name, Course) VALUES
('LPU1001', '12345', 'Aryan Narayan', 'B.Tech CSE'),
('LPU1002', 'abc123', 'Rahul Sharma', 'B.Tech IT'),
('LPU1003', 'pass123', 'Priya Singh', 'BCA');

INSERT INTO SemesterMarks (SemesterNumber, Subject, Marks, StudentId) VALUES
(1, 'Mathematics', 85, 1),
(1, 'Physics', 78, 1),
(1, 'Programming', 90, 1),

(2, 'Data Structures', 88, 1),
(2, 'DBMS', 92, 1),

(1, 'Networking', 75, 2),
(1, 'Operating Systems', 82, 2),

(1, 'Computer Fundamentals', 80, 3),
(1, 'C Programming', 87, 3);