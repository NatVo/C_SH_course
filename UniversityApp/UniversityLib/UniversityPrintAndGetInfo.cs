using System.Data;
using System.Data.SqlClient;

namespace UniversityLib
{
    class Faculty
    {
        public int FacultyId;
        public string FacultyName;
    }
    class Department
    {
        public int DepartmentId;
        public string DepartmentName;
    }

    class StudentGroup
    {
        public int StudentGroupId;
        public string StudentGroupName;
    }

    class CourseNumberOfStudents
    {
        public string CourseName;
        public int NumberOfStudents;
    }

    public class UniversityPrintAndGetInfo
    {
        private static string _connectionString = @"Data Source=DESKTOP-QNG330J;Initial Catalog=university;Pooling=true;Integrated Security=SSPI;";

        public void PrintGeneralData()
        {

            int studentAmount;
            int lecturerAmount;
            int courseAmount;

            using ( SqlConnection connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand command = new SqlCommand() )
                {
                    command.Connection = connection;
                    command.CommandText =
                        @"
                            SELECT COUNT([StudentId]) FROM [Student];
                        ";
                    studentAmount = Convert.ToInt32( command.ExecuteScalar() );
                }

                using ( SqlCommand command = new SqlCommand() )
                {
                    command.Connection = connection;
                    command.CommandText =
                        @"
                            SELECT COUNT([LecturerId]) FROM [Lecturer];
                        ";
                    lecturerAmount = Convert.ToInt32( command.ExecuteScalar() );
                }

                using ( SqlCommand command = new SqlCommand() )
                {
                    command.Connection = connection;
                    command.CommandText =
                        @"
                            SELECT COUNT([CourseId]) FROM [Course];
                        ";
                    courseAmount = Convert.ToInt32( command.ExecuteScalar() );
                }
            }

            Console.WriteLine( $"\n{"Sudents:",-10}{"Lecturers:",25}{"Courses:",25}" );
            Console.WriteLine( $"------------------------------------------------------------" );
            Console.WriteLine( $"\n{studentAmount,-10}{lecturerAmount,25}{courseAmount,25}" );
        }

        public string GetDepartmentNameById()
        {
            List<Department> list = new List<Department>();

            using ( SqlConnection connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand command = new SqlCommand() )
                {
                    command.Connection = connection;
                    command.CommandText =
                        @"
                            SELECT [Department].[DepartmentId], [Department].[DepartmentName] FROM [Department]
                        ";

                    using ( SqlDataReader reader = command.ExecuteReader() )
                    {
                        while ( reader.Read() )
                        {
                            var listElement = new Department
                            {
                                DepartmentId = Convert.ToInt32( reader[ "DepartmentId" ] ),
                                DepartmentName = Convert.ToString( reader[ "DepartmentName" ] )
                            };
                            list.Add( listElement );
                        }
                    }

                    Console.WriteLine( $"\n{"Department",-20}{"DepartmentName",25}" );
                    Console.WriteLine( $"-------------------------------------------------" );

                    foreach ( Department listElement in list )
                    {
                        Console.WriteLine( $"{listElement.DepartmentId,-20} {listElement.DepartmentName,25}" );
                    }

                    Console.WriteLine( $"Type department id:" );
                    string studentGroupIdString = Console.ReadLine();
                    int studentGroupId;

                    while ( !Int32.TryParse( studentGroupIdString, out studentGroupId ) )
                    {
                        Console.WriteLine( $"Last input was incorrect, type student group id again:" );
                        studentGroupIdString = Console.ReadLine();
                    }

                    Department department = list.Find( l => l.DepartmentId == studentGroupId );
                    //Console.WriteLine( $"{department.DepartmentName}" );
                    return department.DepartmentName;
                }
            }
        }

        public string GetStudentGroupNameById()
        {
            List<StudentGroup> list = new List<StudentGroup>();

            using ( SqlConnection connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand command = new SqlCommand() )
                {
                    command.Connection = connection;
                    command.CommandText =
                        @"
                            SELECT [StudentGroup].[StudentGroupId], [StudentGroup].[StudentGroupName] FROM [StudentGroup]
                        ";

                    using ( SqlDataReader reader = command.ExecuteReader() )
                    {
                        while ( reader.Read() )
                        {
                            var listElement = new StudentGroup
                            {
                                StudentGroupId = Convert.ToInt32( reader[ "StudentGroupId" ] ),
                                StudentGroupName = Convert.ToString( reader[ "StudentGroupName" ] )
                            };
                            list.Add( listElement );
                        }
                    }

                    Console.WriteLine( $"\n{"StudentGroup", -20}{"StudentGroupName", 25}" );
                    Console.WriteLine( $"-------------------------------------------------" );
                    
                    foreach ( StudentGroup listElement in list )
                    {
                        Console.WriteLine( $"{listElement.StudentGroupId, -20} {listElement.StudentGroupName, 25}" );
                    }

                    Console.WriteLine( $"Type student group id:" );
                    string studentGroupIdString = Console.ReadLine();
                    int studentGroupId;

                    while ( !Int32.TryParse( studentGroupIdString, out studentGroupId ) )
                    {
                        Console.WriteLine( $"Last input was incorrect, type student group id again:" );
                        studentGroupIdString = Console.ReadLine();
                    }

                    StudentGroup studentGroup = list.Find( l => l.StudentGroupId == studentGroupId);
                    //Console.WriteLine( $"{studentGroup.StudentGroupName}" );
                    return studentGroup.StudentGroupName;
                }
            }
        }

        public void PrintCourseNumberOfStudents()
        {
            List<CourseNumberOfStudents> list = new List<CourseNumberOfStudents>();

            using (SqlConnection connection = new SqlConnection( _connectionString) )
            {
                connection.Open();
                using ( SqlCommand command = new SqlCommand() )
                {
                    command.Connection = connection;
                    command.CommandText =
                        @"
                            SELECT [Course].[CourseName], COUNT([StudentGroup].[StudentGroupName]) AS 'NumberOfStudents'
                            FROM [StudentGroupCourse]
                            JOIN [Course] ON [Course].[CourseId]=[StudentGroupCourse].[CourseId]
                            JOIN [StudentGroup] ON [StudentGroup].[StudentGroupId]=[StudentGroupCourse].[StudentGroupId] 
                            JOIN [Student] ON [Student].[StudentGroupId]=[StudentGroupCourse].[StudentGroupId]
                            GROUP BY [CourseName]
                        ";

                    using ( SqlDataReader reader = command.ExecuteReader() )
                    {
                        while ( reader.Read() )
                        {
                            var listElement = new CourseNumberOfStudents
                            {
                                CourseName = Convert.ToString( reader["CourseName"] ),
                                NumberOfStudents = Convert.ToInt32( reader["NumberOfStudents"] )
                            };
                            list.Add( listElement );
                        }
                    }

                    Console.WriteLine( $"\n{"CourseName",-20}{"NumberOfStudents",25}" );
                    Console.WriteLine( $"-------------------------------------------------" );
                    
                    foreach (CourseNumberOfStudents listElement in list)
                    {
                        Console.WriteLine( $"{listElement.CourseName} {listElement.NumberOfStudents}" );
                    }
                }
            }
        }
    }
}
