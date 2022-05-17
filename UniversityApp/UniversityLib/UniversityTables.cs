using System.Data.SqlClient;

namespace UniversityLib
{
    public class UniversityTables
    {
        private static string _connectionString = @"Data Source=DESKTOP-QNG330J;Initial Catalog=university;Pooling=true;Integrated Security=SSPI;";

        public void CreateFacultyTable()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Faculty' AND xtype='U')
                            CREATE TABLE [dbo].[Faculty]
	                            (
                                    [FacultyId] [int] IDENTITY(1,1) NOT NULL CONSTRAINT PK_Faculty PRIMARY KEY,
	                                [FacultyName] [nchar](50) NULL,
                                    UNIQUE ([FacultyName])
                                )";
                    command.ExecuteNonQuery();
                }
            }
        }

        public void CreateDepartmentTable()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Department' AND xtype='U')
                            CREATE TABLE [dbo].[Department]
	                            (
                                    [DepartmentId] [int] IDENTITY(1,1) NOT NULL CONSTRAINT PK_Department PRIMARY KEY,
	                                [DepartmentName] [nchar](50) NULL,
                                    UNIQUE ([DepartmentName]),
                                    [FacultyID] [int] FOREIGN KEY REFERENCES [dbo].[Faculty](FacultyId) ON DELETE CASCADE
                                )";
                    command.ExecuteNonQuery();
                }
            }
        }

        public void CreateStudentGroupTable()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='StudentGroup' AND xtype='U')
                            CREATE TABLE [dbo].[StudentGroup]
	                            (
                                    [StudentGroupId] [int] IDENTITY(1,1) NOT NULL CONSTRAINT PK_StudentGroup PRIMARY KEY,
	                                [StudentGroupName] [nchar](15) NULL,
                                    UNIQUE ([StudentGroupName]),
                                    [DepartmentID] [int] FOREIGN KEY REFERENCES [dbo].[Department](DepartmentId) ON DELETE CASCADE
                                )";
                    command.ExecuteNonQuery();
                }
            }
        }

        public void CreateStudentTable()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Student' AND xtype='U')
                            CREATE TABLE [dbo].[Student]
	                            (
                                    [StudentId] [int] IDENTITY(1,1) NOT NULL CONSTRAINT PK_Student PRIMARY KEY,
	                                [StudentFirstName] [nchar](20) NULL,
	                                [StudentLastName] [nchar](20) NULL,
                                    [StudentAge] [int] NULL,
                                    [StudentGroupID] [int] FOREIGN KEY REFERENCES [dbo].[StudentGroup](StudentGroupId) ON DELETE CASCADE
                                )";
                    command.ExecuteNonQuery();
                }
            }
        }

        public void CreateLecturerTable()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Lecturer' AND xtype='U')
                            CREATE TABLE [dbo].[Lecturer]
	                            (
                                    [LecturerId] [int] IDENTITY(1,1) NOT NULL CONSTRAINT PK_Lecturer PRIMARY KEY,
	                                [LecturerFirstName] [nchar](20) NULL,
	                                [LecturerLastName] [nchar](20) NULL
                                )";
                    command.ExecuteNonQuery();
                }
            }
        }

        public void CreateCourseTable()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Course' AND xtype='U')
                            CREATE TABLE [dbo].[Course]
	                            (
                                    [CourseId] [int] IDENTITY(1,1) NOT NULL CONSTRAINT PK_Course PRIMARY KEY,
	                                [CourseName] [nchar](40) NULL,
                                    UNIQUE ([CourseName]),
                                )";
                    command.ExecuteNonQuery();
                }
            }
        }

        public void CreateLecturerCourseTable()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='LecturerCourse' AND xtype='U')
                            CREATE TABLE [dbo].[LecturerCourse]
	                            (
                                    [LecturerCourseId] [int] IDENTITY(1,1) NOT NULL CONSTRAINT PK_LecturerCourse PRIMARY KEY,
                                    [LecturerId] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Lecturer](LecturerId) ON DELETE CASCADE,
                                    [CourseId] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Course](CourseId) ON DELETE CASCADE
                                )";
                    command.ExecuteNonQuery();
                }
            }
        }

        public void CreateStudentGroupCourseTable()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='StudentGroupCourse' AND xtype='U')
                            CREATE TABLE [dbo].[StudentGroupCourse]
	                            (
                                    [StudentGroupCourseId] [int] IDENTITY(1,1) NOT NULL CONSTRAINT PK_StudentGroupCourse PRIMARY KEY,
                                    [StudentGroupID] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[StudentGroup](StudentGroupId) ON DELETE CASCADE,
                                    [CourseID] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Course](CourseId) ON DELETE CASCADE
                                )";
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}