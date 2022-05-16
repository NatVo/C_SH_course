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
        private static string _connectionString = @"Data Source=LAPTOP-SSK5J58N;Initial Catalog=university;Pooling=true;Integrated Security=SSPI;";

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
