using System.Data;
using System.Data.SqlClient;

namespace UniversityLib
{
    class GeneralList
    {
        public int ItemId;
        public string ItemName;
    }

    class PersonList
    {
        public int PersonId;
        public string PersonFirstName;
        public string PersonLastName;
    }

    class LecturerCourse
    {
        public string LecturerFirstName;
        public string LecturerLastName;
        public string CourseName;
    }

    class CourseNumberOfStudents
    {
        public string CourseName;
        public int NumberOfStudents;
    }

    public class UniversityPrintAndGetInfo
    {
        private static string _connectionString = @"Data Source=DESKTOP-QNG330J;Initial Catalog=university;Pooling=true;Integrated Security=SSPI;";

        private List<GeneralList> _generalList = new List<GeneralList>();
        private List<PersonList> _personList = new List<PersonList>();
        
        public string GetItemNameById( string itemIdString, string itemNameString, string commandLine )
        {
            _generalList.Clear();

            using ( SqlConnection connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand command = new SqlCommand() )
                {
                    command.Connection = connection;
                    command.CommandText = commandLine;
                        
                    using ( SqlDataReader reader = command.ExecuteReader() )
                    {
                        while ( reader.Read() )
                        {
                            var listElement = new GeneralList
                            {
                                ItemId = Convert.ToInt32( reader[ itemIdString ] ),
                                ItemName = Convert.ToString( reader[ itemNameString ] ).TrimEnd()
                            };
                            _generalList.Add( listElement );
                        }
                    }

                    Console.WriteLine( $"\n{itemIdString,-20} {itemNameString,25}" );
                    Console.WriteLine( $"-------------------------------------------------" );

                    foreach ( GeneralList listElement in _generalList )
                    {
                        Console.WriteLine( $"{listElement.ItemId,-20} {listElement.ItemName,25}" );
                    }

                    Console.WriteLine( $"Type selected {itemIdString.Substring( 0, itemIdString.Length -2 )} item id:" );
                    string itemIdInputString = Console.ReadLine();
                    int itemId;

                    while ( !Int32.TryParse( itemIdInputString, out itemId ) )
                    {
                        Console.WriteLine( $"Last input was incorrect, type id again:" );
                        itemIdInputString = Console.ReadLine();
                    }

                    GeneralList outputList = _generalList.Find( l => l.ItemId == itemId );
                    Console.WriteLine( $"\nYou have selected: {outputList.ItemName}" );

                    return outputList.ItemName;
                }
            }
        }

        public string GetPersonNameById( string personIdString, string personFirstNameString, string personLastNameString, string commandLine )
        {
            _personList.Clear();

            using ( SqlConnection connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand command = new SqlCommand() )
                {
                    command.Connection = connection;
                    command.CommandText = commandLine;

                    using ( SqlDataReader reader = command.ExecuteReader() )
                    {
                        while ( reader.Read() )
                        {
                            var listElement = new PersonList
                            {
                                PersonId = Convert.ToInt32( reader[ personIdString ] ),
                                PersonFirstName = Convert.ToString( reader[ personFirstNameString ] ).TrimEnd(),
                                PersonLastName = Convert.ToString( reader[ personLastNameString ] ).TrimEnd()
                            };
                            _personList.Add( listElement );
                        }
                    }

                    Console.WriteLine( $"\n{personIdString,-20} {personFirstNameString,25} {personLastNameString,25}" );
                    Console.WriteLine( $"----------------------------------------------------------------------------" );

                    foreach ( PersonList listElement in _personList )
                    {
                        Console.WriteLine( $"{listElement.PersonId,-20} {listElement.PersonFirstName,25} {listElement.PersonLastName,25}" );
                    }

                    Console.WriteLine( $"Type selected {personIdString.Substring( 0, personIdString.Length - 2 )} id:" );
                    string personIdInputString = Console.ReadLine();
                    int personId;

                    while ( !Int32.TryParse( personIdInputString, out personId ) )
                    {
                        Console.WriteLine( $"Last input was incorrect, type id again:" );
                        personIdInputString = Console.ReadLine();
                    }

                    PersonList outputList = _personList.Find( l => l.PersonId == personId );
                    Console.WriteLine( $"You have selected: {outputList.PersonFirstName} {outputList.PersonLastName}" );

                    return outputList.PersonFirstName + " " + outputList.PersonLastName;
                }
            }
        }

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

            Console.WriteLine( $"\n{"Sudents:",-10} {"Lecturers:",25} {"Courses:",25}" );
            Console.WriteLine( $"------------------------------------------------------------" );
            Console.WriteLine( $"\n{studentAmount,-10} {lecturerAmount,25} {courseAmount,25}" );
        }

        public void PrintLecturerCourseWithNames()
        {
            List<LecturerCourse> list = new List<LecturerCourse>();

            using ( SqlConnection connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand command = new SqlCommand() )
                {
                    command.Connection = connection;
                    command.CommandText =
                        @"
                            SELECT [Lecturer].[LecturerFirstName], [Lecturer].[LecturerLastName], [Course].[CourseName]
                            FROM [LecturerCourse]
                            JOIN [Lecturer] ON [Lecturer].[LecturerId] = [LecturerCourse].[LecturerId]
                            JOIN [Course] ON [Course].[CourseId] = [LecturerCourse].[CourseId]
                        ";

                    using ( SqlDataReader reader = command.ExecuteReader() )
                    {
                        while ( reader.Read() )
                        {
                            var listElement = new LecturerCourse
                            {
                                LecturerFirstName = Convert.ToString( reader[ "LecturerFirstName" ] ).TrimEnd(),
                                LecturerLastName = Convert.ToString( reader[ "LecturerLastName" ] ).TrimEnd(),
                                CourseName = Convert.ToString( reader[ "CourseName" ] ).TrimEnd()
                            };
                            list.Add( listElement );
                        }
                    }

                    Console.WriteLine( $"\n{"LecturerFirstName",-20} {"LecturerLastName",25} {"CourseName",25}" );
                    Console.WriteLine( $"---------------------------------------------------------------------------" );

                    foreach ( LecturerCourse listElement in list )
                    {
                        Console.WriteLine( $"{listElement.LecturerFirstName,-20} {listElement.LecturerLastName,25} {listElement.CourseName,25}" );
                    }
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
                                CourseName = Convert.ToString( reader["CourseName"] ).TrimEnd(),
                                NumberOfStudents = Convert.ToInt32( reader["NumberOfStudents"] )
                            };
                            list.Add( listElement );
                        }
                    }

                    Console.WriteLine( $"\n{"CourseName", -20} {"NumberOfStudents", 25}" );
                    Console.WriteLine( $"-------------------------------------------------" );
                    
                    foreach (CourseNumberOfStudents listElement in list)
                    {
                        Console.WriteLine( $"{listElement.CourseName,-20} {listElement.NumberOfStudents,25}" );
                    }
                }
            }
        }
    }
}
