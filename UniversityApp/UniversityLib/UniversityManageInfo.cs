using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLib
{
    public class UniversityManageInfo
    {
        private UniversityTables _universityTable = new UniversityTables();
        private UniersityInsertInfo _universityAddInfo = new UniersityInsertInfo();
        private UniversityUpdateInfo _universityUpdateInfo = new UniversityUpdateInfo();
        private UniversityPrintAndGetInfo _universityPrintInfo = new UniversityPrintAndGetInfo();

        public void CreateTables()
        {
            try
            {
                _universityTable.CreateFacultyTable();
                _universityTable.CreateDepartmentTable();
                _universityTable.CreateStudentGroupTable();
                _universityTable.CreateStudentTable();
                _universityTable.CreateLecturerTable();
                _universityTable.CreateCourseTable();
                _universityTable.CreateLecturerCourseTable();
                _universityTable.CreateStudentGroupCourseTable();

                Console.WriteLine( "Successfully created all tables" );
            }
            catch (Exception exception)
            {
                Console.WriteLine( $"\nUnable to create tables: {exception.Message}" );
            }
        }

        public void AddFacultyInfo( string facultyName )
        {
            try
            {
                _universityAddInfo.InsertFaculty( facultyName);
                Console.WriteLine( $"\nSuccessfully added faculty: {facultyName}" );
            }
            catch ( Exception exception )
            {
                Console.WriteLine( $"\nUnable to add faculty: '{facultyName}' - {exception.Message}" );
            }
        }

        public void AddDepartmentInfo( string departmentName, string facultyName )
        {
            try
            {
                _universityAddInfo.InsertDepartment( departmentName, facultyName );
                Console.WriteLine( $"\nSuccessfully added department: {departmentName}" );
            }
            catch (Exception exception)
            {
                Console.WriteLine( $"\nUnable to add faculty: '{departmentName}' - {exception.Message}" );
            }
        }

        public void AddStudentGroupInfo( string studentGroupName, string departmentName )
        {
            try
            {
                _universityAddInfo.InsertStudentGroup( studentGroupName, departmentName );
                Console.WriteLine( $"\nSuccessfully added student group: {studentGroupName}" );
            }
            catch (Exception exception)
            {
                Console.WriteLine( $"\nUnable to add student group: '{studentGroupName}' - {exception.Message}" );
            }
        }

        public void AddStudentInfo( string studentFirstName, string studentLastName, int studentAge, string studentGroupName)
        {
            try
            {
                _universityAddInfo.InsertStudent( studentFirstName, studentLastName, studentAge, studentGroupName );
                Console.WriteLine( $"\nSuccessfully added student: '{studentFirstName} {studentLastName} age: {studentAge}' to group: '{studentGroupName}'" );
            }
            catch ( Exception exception )
            {
                Console.WriteLine( $"\nUnable to add student: '{studentFirstName} {studentLastName} age: {studentAge}' - {exception.Message}" );
            }
        }

        public void AddLecturerInfo( string lecturerFirstName, string lecturerLastName )
        {
            try
            {
                _universityAddInfo.InsertLecturer( lecturerFirstName, lecturerLastName );
                Console.WriteLine( $"\nSuccessfully added lecturer: {lecturerFirstName} {lecturerLastName}" );
            }
            catch (Exception exception)
            {
                Console.WriteLine( $"\nUnable to add lecturer: '{lecturerFirstName} {lecturerLastName}' - {exception.Message}" );
            }
        }

        public void AddCourseInfo( string courseName )
        {
            try
            {
                _universityAddInfo.InsertCourse( courseName );
                Console.WriteLine($"\nSuccessfully added course: {courseName}");
            }
            catch ( Exception exception )
            {
                Console.WriteLine( $"\nUnable to add course: '{courseName}' - {exception.Message}" );
            }
        }

        public void AddLecturerCourseInfo( string lecturerFirstName, string lecturerLastName, string courseName )
        {
            try
            {
                _universityAddInfo.InsertLecturerCourse( lecturerFirstName, lecturerLastName, courseName );
                Console.WriteLine( $"\nSuccessfully added lecturer '{lecturerFirstName} {lecturerLastName}' to course: '{courseName}'" );
            }
            catch ( Exception exception )
            {
                Console.WriteLine( $"\nUnable to add lecturer '{lecturerFirstName} {lecturerLastName}' to course: '{courseName}' - {exception.Message}" );
            }
        }

        public void AddStudentGroupCourseInfo( string studentGroupName, string courseName )
        {
            try
            {
                _universityAddInfo.InsertStudentGroupCourse( studentGroupName, courseName );
                Console.WriteLine( $"\nSuccessfully added student group {studentGroupName} to course: '{courseName}'" );
            }
            catch ( Exception exception )
            {
                Console.WriteLine( $"\nUnable to add student group '{studentGroupName}' to course: '{courseName}' - {exception.Message}" );
            }
        }

        public void UpdateLecturerInLecturerCourseInfo( string oldLecturerFirstName, string oldLectuerLastName,
                                                        string newLecturerFirstName, string newLectuerLastName, string courseName )
        {
            try
            {
                if (_universityUpdateInfo.UpdateLecturerInLecturerCourse( oldLecturerFirstName, oldLectuerLastName,
                                                                          newLecturerFirstName, newLectuerLastName, courseName) )
                {
                    Console.WriteLine( $"\nSuccessfully updated lecturer/course info: " +
                                        $"from {oldLecturerFirstName} {oldLectuerLastName} with course: {courseName}" +
                                        $" to {newLecturerFirstName} {newLectuerLastName} with course: {courseName}" );
                }
                else
                {
                    Console.WriteLine( $"\nUnable to update lecturer/course info" );
                }
            }
            catch ( Exception exception )
            {
                Console.WriteLine( $"\nUnable to update lecturer/course info - {exception.Message}" );
            }
        }

        public void PrintCourseNumberOfStudentsInfo()
        {
            try
            {
                _universityPrintInfo.PrintCourseNumberOfStudents();
            }
            catch ( Exception exception )
            {
                Console.WriteLine( $"\nUnable to print course - number of students information {exception.Message}" );
            }
        }

        public void PrintGeneralDataInfo()
        {
            try
            {
                _universityPrintInfo.PrintGeneralData();
            }
            catch ( Exception exception )
            {
                Console.WriteLine( $"\nUnable to print general information {exception.Message}" );
            }
        }

        public string GetDepartmentNameByIdInfo()
        {
            try
            {
                return _universityPrintInfo.GetDepartmentNameById();
            }
            catch ( Exception exception )
            {
                return "";
                Console.WriteLine( $"\nUnable to get department name information by id {exception.Message}" );
            }
        }

        public string GetStudentGroupNameByIdInfo()
        {
            try
            {
                return _universityPrintInfo.GetStudentGroupNameById();
            }
            catch ( Exception exception )
            {
                return "";
                Console.WriteLine( $"\nUnable to get student group name information by id {exception.Message}" );
            }
        }


    }
}
