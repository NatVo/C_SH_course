using System.Data;
using System.Data.SqlClient;

namespace UniversityLib
{
    internal class UniversityUpdateInfo
    {
        private static string _connectionString = @"Data Source=DESKTOP-QNG330J;Initial Catalog=university;Pooling=true;Integrated Security=SSPI;";

        public bool UpdateLecturerInLecturerCourse( string oldLecturerFirstName, string oldLecturerLastName,
                                                    string newLecturerFirstName, string newLecturerLastName, string courseName )
        {
            int existingLecturerCourseId;

            using (SqlConnection connection = new SqlConnection( _connectionString) )
            {
                connection.Open();
                using ( SqlCommand command = connection.CreateCommand() )
                {
                    command.CommandText = @"
                        SELECT [LecturerCourse].[LecturerCourseID]
                        FROM [LecturerCourse]
                        JOIN [Lecturer] ON [Lecturer].[LecturerId] = [LecturerCourse].[LecturerId]
                        JOIN [Course] ON [Course].[CourseId] = [LecturerCourse].[CourseId]
                        WHERE 
                            (
                                [Lecturer].[LecturerFirstName]=@oldLecturerFirstName 
                                AND [Lecturer].[LecturerLastName]=@oldLecturerLastName
                                AND [Course].[CourseName] = @courseName
                            )";

                    command.Parameters.Add( "@oldLecturerFirstName", SqlDbType.NVarChar ).Value = oldLecturerFirstName;
                    command.Parameters.Add( "@oldLecturerLastName", SqlDbType.NVarChar ).Value = oldLecturerLastName;
                    command.Parameters.Add( "@courseName", SqlDbType.NVarChar ).Value = courseName;
                    Console.WriteLine( command.CommandText );
                    existingLecturerCourseId = Convert.ToInt32( command.ExecuteScalar() );
                }

                Console.WriteLine( $"existingLecturerCourseId: {existingLecturerCourseId}" );

                if ( existingLecturerCourseId > 0 )
                {
                    using ( SqlCommand command = connection.CreateCommand() )
                    {
                        command.CommandText = @"
                        UPDATE [LecturerCourse]
                        SET [LecturerId] = (
                                                SELECT [LecturerID] 
                                                FROM [Lecturer] 
                                                WHERE ([LecturerFirstName]=@newLecturerFirstName AND [LecturerLastName]=@newLecturerLastName)
                                           )                  
                        WHERE [LecturerCourseID] = @existingLecturerCourseId";

                        command.Parameters.Add("@newLecturerFirstName", SqlDbType.NVarChar).Value = newLecturerFirstName;
                        command.Parameters.Add("@newLecturerLastName", SqlDbType.NVarChar).Value = newLecturerLastName;
                        command.Parameters.Add("@existingLecturerCourseId", SqlDbType.NVarChar).Value = existingLecturerCourseId;

                        command.ExecuteNonQuery();

                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
