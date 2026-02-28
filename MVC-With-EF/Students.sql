Use Collage;

CREATE TABLE Students (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50),
    Age INT,
    Department NVARCHAR(50)
);
 INSERT INTO Students VALUES ('Arun', 20, 'CSE');
INSERT INTO Students VALUES ('Meena', 21, 'ECE');
INSERT INTO Students VALUES ('Rahul', 22, 'IT');

Select * from Students;