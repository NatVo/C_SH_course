using System;
using System.Data;
using UniversityLib;
using System.Data.SqlClient;

namespace UniversityApp
{
    class Program
    {
        private static UniversityManageInfo _universityManageInfo = new UniversityManageInfo();
        static void Main(string[] args)
        {

            Console.WriteLine( $"{args[ 1 ]}" );
            //AutoInput();

            switch ( args[ 1 ] )
            {
                case "AddFaculty":

                    break;
                case "AddDepartment":


                    break;
                case "AddStudentGroup":
                    AddStudentGroup();
                    break;

                case "AddStudent":
                    AddStudent();
                    break;

                default:
                    Console.WriteLine( "Incorrect command line argument!" );
                    break;
            }
            Console.ReadKey();
        }

        private static void AddStudentGroup()
        {
            Console.WriteLine( $"Type student group name:" );
            string studentGroupName = Console.ReadLine();

            string departmentName = _universityManageInfo.GetDepartmentNameByIdInfo();
            //_universityManageInfo.AddStudentGroupInfo( studentGroupName, departmentName );
        }

        private static void AddStudent()
        {
            Console.WriteLine( $"Type student first name:" );
            string studentFirstName = Console.ReadLine();

            while ( studentFirstName.Any( char.IsDigit ) )
            {
                Console.WriteLine( $"Last input was incorrect, type student first name again:" );
                studentFirstName = Console.ReadLine();
            }

            Console.WriteLine( $"Type student last name:" );
            string studentLastName = Console.ReadLine();

            while ( studentLastName.Any( char.IsDigit ) )
            {
                Console.WriteLine( $"Last input was incorrect, type student last name again:" );
                studentLastName = Console.ReadLine();
            }

            Console.WriteLine( $"Type student age:" );
            string studentAgeString = Console.ReadLine();
            int studentAge;

            while( !Int32.TryParse( studentAgeString, out studentAge ) )
            {
                Console.WriteLine( $"Last input was incorrect, type student age again:" );
                studentAgeString = Console.ReadLine();
            }

            string studentGroupName = _universityManageInfo.GetStudentGroupNameByIdInfo();
            //_universityManageInfo.AddStudentInfo( studentFirstName, studentLastName, studentAge, studentGroupName );
        }

        private static void AutoInput()
        {
            //_universityManageInfo.CreateTables();

            //_universityManageInfo.AddFacultyInfo( "FacultyOfInformaticsAndComputerEngineering" );
            //_universityManageInfo.AddFacultyInfo( "FacultyOfForestryAndEcology" );
            //_universityManageInfo.AddFacultyInfo( "FacultyOfEconomics" );

            //_universityManageInfo.AddDepartmentInfo( "DepartmentOfInformationSecurity", "FacultyOfInformaticsAndComputerEngineering" );
            //_universityManageInfo.AddDepartmentInfo( "DepartmentOfSoftwareEngineering", "FacultyOfInformaticsAndComputerEngineering" );
            //_universityManageInfo.AddDepartmentInfo( "DepartmentOfComputerEngineering", "FacultyOfInformaticsAndComputerEngineering" );
            //_universityManageInfo.AddDepartmentInfo( "DepartmentOfForestTaxation", "FacultyOfForestryAndEcology" );

            //_universityManageInfo.AddStudentGroupInfo( "BI-1", "DepartmentOfInformationSecurity" );
            //_universityManageInfo.AddStudentGroupInfo( "BI-2", "DepartmentOfInformationSecurity" );
            //_universityManageInfo.AddStudentGroupInfo( "PS-1", "DepartmentOfSoftwareEngineering" );
            //_universityManageInfo.AddStudentGroupInfo( "PS-2", "DepartmentOfSoftwareEngineering" );
            //_universityManageInfo.AddStudentGroupInfo( "IVT", "DepartmentOfComputerEngineering" );

            //_universityManageInfo.AddStudentInfo( "Natalia", "Vorobeva", 20, "BI-1" );
            //_universityManageInfo.AddStudentInfo( "Ksenia", "Kozlova", 19, "BI-1" );
            //_universityManageInfo.AddStudentInfo( "Maksim", "Kanashin", 20, "BI-1" );
            //_universityManageInfo.AddStudentInfo( "Andrei", "Malinin", 21, "BI-1" );

            //_universityManageInfo.AddStudentInfo( "Lera", "Loskutova", 19, "BI-2" );
            //_universityManageInfo.AddStudentInfo( "Aleksei", "Polikarpov", 20, "BI-2" );
            //_universityManageInfo.AddStudentInfo( "Nikolai", "Kanushkov", 18, "BI-2" );

            //_universityManageInfo.AddStudentInfo( "Ilona", "Chemodanova", 21, "PS-1" );
            //_universityManageInfo.AddStudentInfo( "Anton", "Merzlyakov", 21, "PS-1" );

            //_universityManageInfo.AddStudentInfo( "Denis", "Tikhomirov", 20, "PS-2" );
            //_universityManageInfo.AddStudentInfo( "Elena", "Lyashko", 22, "PS-2" );

            //_universityManageInfo.AddStudentInfo( "Natalia", "Ryzhkova", 19, "IVT" );
            //_universityManageInfo.AddStudentInfo( "Egor", "Pekunov", 18, "IVT" );
            //_universityManageInfo.AddStudentInfo( "Denis", "Karasyov", 22, "IVT" );
            //_universityManageInfo.AddStudentInfo( "Sofia", "Nikulina", 20, "IVT" );
            //_universityManageInfo.AddStudentInfo( "Vladimyr", "Bezrodnyi", 20, "IVT" );

            //_universityManageInfo.AddLecturerInfo( "Alexander", "Ivanov" );
            //_universityManageInfo.AddLecturerInfo( "Nikolai", "Parsaev" );
            //_universityManageInfo.AddLecturerInfo( "Ivan", "Smirnov" );
            //_universityManageInfo.AddLecturerInfo( "Anatolyi", "Leukhin" );
            //_universityManageInfo.AddLecturerInfo( "Alexander", "Gubaev" );

            //_universityManageInfo.AddCourseInfo( "OOPBasics" );
            //_universityManageInfo.AddCourseInfo( "PythonBasics" );
            //_universityManageInfo.AddCourseInfo( "DataBases" );
            //_universityManageInfo.AddCourseInfo( "InfoSecurityBasics" );
            //_universityManageInfo.AddCourseInfo( "CircuitDesign" );
            //_universityManageInfo.AddCourseInfo( "Cryptography" );

            //_universityManageInfo.AddLecturerCourseInfo( "Anatolyi", "Leukhin", "Cryptography" );
            //_universityManageInfo.AddLecturerCourseInfo( "Ivan", "Smirnov", "Cryptography" );
            //_universityManageInfo.AddLecturerCourseInfo( "Ivan", "Smirnov", "InfoSecurityBasics" );
            //_universityManageInfo.AddLecturerCourseInfo( "Nikolai", "Parsaev", "PythonBasics" );
            //_universityManageInfo.AddLecturerCourseInfo( "Nikolai", "Parsaev", "CircuitDesign" );
            //_universityManageInfo.AddLecturerCourseInfo( "Alexander", "Ivanov", "OOPBasics" );

            //_universityManageInfo.AddStudentGroupCourseInfo( "BI-1", "OOPBasics" );
            //_universityManageInfo.AddStudentGroupCourseInfo( "BI-1", "Cryptography" );
            //_universityManageInfo.AddStudentGroupCourseInfo( "BI-1", "InfoSecurityBasics" );
            //_universityManageInfo.AddStudentGroupCourseInfo( "BI-2", "OOPBasics" );
            //_universityManageInfo.AddStudentGroupCourseInfo( "BI-2", "InfoSecurityBasics" );
            //_universityManageInfo.AddStudentGroupCourseInfo( "PS-1", "OOPBasics" );

            _universityManageInfo.UpdateLecturerInLecturerCourseInfo( "Alexander", "Gubaev",
                                                                       "Ivan", "Smirnov", "Cryptography" );
            //_universityManageInfo.UpdateLecturerInLecturerCourseInfo( "Ivan", "Smirnov",
            //                                                          "Alexander", "Gubaev", "Cryptography" );

            //_universityManageInfo.PrintCourseNumberOfStudentsInfo();
            //_universityManageInfo.PrintGeneralDataInfo();
        }
    }
}
