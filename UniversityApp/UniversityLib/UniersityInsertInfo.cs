using System.Data;
using System.Data.SqlClient;

namespace UniversityLib
{
    public class UniersityInsertInfo
    {
        private static string _connectionString = @"Data Source=DESKTOP-QNG330J;Initial Catalog=university;Pooling=true;Integrated Security=SSPI;";
        
        public void InsertFaculty(string facultyName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                    INSERT INTO [Faculty]
                       ([FacultyName]) 
                    VALUES 
                       (@facultyName)";

                    command.Parameters.Add("@facultyName", SqlDbType.NVarChar).Value = facultyName;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertDepartment(string departmentName, string facultyName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                    INSERT INTO [Department]
                       (
                            [DepartmentName],
                            [FacultyId]
                       ) 
                    VALUES 
                       (
                            @departmentName,
                            (SELECT [FacultyId] FROM [Faculty] WHERE [FacultyName]=@facultyName)
                       )";

                    command.Parameters.Add("@departmentName", SqlDbType.NVarChar).Value = departmentName;
                    command.Parameters.Add("@facultyName", SqlDbType.NVarChar).Value = facultyName;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertStudentGroup(string studentGroupName, string departmentName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                    INSERT INTO [StudentGroup]
                       (
                            [StudentGroupName],
                            [DepartmentId]
                       ) 
                    VALUES 
                       (
                            @studentGroupName,
                            (SELECT [DepartmentId] FROM [Department] WHERE [DepartmentName]=@departmentName)
                       )";

                    command.Parameters.Add("@studentGroupName", SqlDbType.NVarChar).Value = studentGroupName;
                    command.Parameters.Add("@departmentName", SqlDbType.NVarChar).Value = departmentName;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertStudent(string studentFirstName, string studentLastName, string studentGroupName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                    INSERT INTO [Student]
                       (
                            [StudentFirstName],
                            [StudentLastName],
                            [StudentGroupId]
                       ) 
                    VALUES 
                       (
                            @studentFirstName,
                            @studentLastName,
                            (SELECT [StudentGroupId] FROM [StudentGroup] WHERE [StudentGroupName]=@studentGroupName)
                       )";

                    command.Parameters.Add("@studentFirstName", SqlDbType.NVarChar).Value = studentFirstName;
                    command.Parameters.Add("@studentLastName", SqlDbType.NVarChar).Value = studentLastName;
                    command.Parameters.Add("@studentGroupName", SqlDbType.NVarChar).Value = studentGroupName;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertLecturer(string lecturerFirstName, string lecturerLastName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                    INSERT INTO [Lecturer]
                       (
                            [LecturerFirstName],
                            [LecturerLastName]
                       ) 
                    VALUES 
                       (
                            @lecturerFirstName,
                            @lecturerLastName
                       )";

                    command.Parameters.Add("@lecturerFirstName", SqlDbType.NVarChar).Value = lecturerFirstName;
                    command.Parameters.Add("@lecturerLastName", SqlDbType.NVarChar).Value = lecturerLastName;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertCourse(string courseName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                    INSERT INTO [Course]
                       ([CourseName]) 
                    VALUES 
                       (@courseName)";

                    command.Parameters.Add("@courseName", SqlDbType.NVarChar).Value = courseName;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertLecturerCourse(string lecturerFirstName, string lecturerLastName, string courseName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                    INSERT INTO [LecturerCourse]
                       (
                            [LecturerID],
                            [CourseID]
                       ) 
                    VALUES 
                       (
                            (
                                SELECT [LecturerID] 
                                FROM [Lecturer] 
                                WHERE ([LecturerFirstName]=@lecturerFirstName AND [LecturerLastName]=@lecturerLastName)
                            ),
                            (SELECT [CourseId] FROM [Course] WHERE [CourseName]=@courseName)
                       )";

                    command.Parameters.Add("@lecturerFirstName", SqlDbType.NVarChar).Value = lecturerFirstName;
                    command.Parameters.Add("@lecturerLastName", SqlDbType.NVarChar).Value = lecturerLastName;
                    command.Parameters.Add("@courseName", SqlDbType.NVarChar).Value = courseName;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertStudentGroupCourse(string studentGroupName, string courseName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                    INSERT INTO [StudentGroupCourse]
                       (
                            [StudentGroupID],
                            [CourseID]
                       ) 
                    VALUES 
                       (
                            (SELECT [StudentGroupID] FROM [StudentGroup] WHERE ([StudentGroupName]=@studentGroupName)),
                            (SELECT [CourseId] FROM [Course] WHERE [CourseName]=@courseName)
                       )";

                    command.Parameters.Add("@studentGroupName", SqlDbType.NVarChar).Value = studentGroupName;
                    command.Parameters.Add("@courseName", SqlDbType.NVarChar).Value = courseName;

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
