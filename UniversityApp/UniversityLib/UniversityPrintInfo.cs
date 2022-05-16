using System.Data;
using System.Data.SqlClient;

namespace UniversityLib
{
    class CourseNumberOfStudents
    {
        public string CourseName;
        public int NumberOfStudents;
    }

    public class UniversityPrintInfo
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

        public void PrintCourseNumberOfStudents()
        {
            List<CourseNumberOfStudents> list = new List<CourseNumberOfStudents>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
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

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var listElement = new CourseNumberOfStudents
                            {
                                CourseName = Convert.ToString(reader["CourseName"]),
                                NumberOfStudents = Convert.ToInt32(reader["NumberOfStudents"])
                            };
                            list.Add(listElement);
                        }
                    }

                    Console.WriteLine($"\n{"CourseName",-20}{"NumberOfStudents",25}");
                    Console.WriteLine($"-------------------------------------------------");
                    foreach (CourseNumberOfStudents listElement in list)
                    {
                        Console.WriteLine($"{listElement.CourseName} {listElement.NumberOfStudents}");
                    }
                }
            }
        }
    }
}
