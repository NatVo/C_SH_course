using System;
using System.Data;
using UniversityLib;
using System.Data.SqlClient;

namespace UniversityApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UniversityManageInfo universityManageInfo = new UniversityManageInfo();
            universityManageInfo.CreateTables();

            universityManageInfo.AddFacultyInfo("FacultyOfInformaticsAndComputerEngineering");
            universityManageInfo.AddFacultyInfo("FacultyOfForestryAndEcology");
            universityManageInfo.AddFacultyInfo("FacultyOfEconomics");

            universityManageInfo.AddDepartmentInfo("DepartmentOfInformationSecurity", "FacultyOfInformaticsAndComputerEngineering");
            universityManageInfo.AddDepartmentInfo("DepartmentOfSoftwareEngineering", "FacultyOfInformaticsAndComputerEngineering");
            universityManageInfo.AddDepartmentInfo("DepartmentOfComputerEngineering", "FacultyOfInformaticsAndComputerEngineering");
            universityManageInfo.AddDepartmentInfo("DepartmentOfForestTaxation", "FacultyOfForestryAndEcology");

            universityManageInfo.AddStudentGroupInfo("BI-1", "DepartmentOfInformationSecurity");
            universityManageInfo.AddStudentGroupInfo("BI-2", "DepartmentOfInformationSecurity");
            universityManageInfo.AddStudentGroupInfo("PS-1", "DepartmentOfSoftwareEngineering");
            universityManageInfo.AddStudentGroupInfo("PS-2", "DepartmentOfSoftwareEngineering");
            universityManageInfo.AddStudentGroupInfo("IVT", "DepartmentOfComputerEngineering");

            universityManageInfo.AddStudentInfo("Natalia", "Vorobeva", "BI-1");
            universityManageInfo.AddStudentInfo("Ksenia", "Kozlova", "BI-1");
            universityManageInfo.AddStudentInfo("Maksim", "Kanashin", "BI-1");
            universityManageInfo.AddStudentInfo("Andrei", "Malinin", "BI-1");

            universityManageInfo.AddStudentInfo("Lera", "Loskutova", "BI-2");
            universityManageInfo.AddStudentInfo("Aleksei", "Polikarpov", "BI-2");
            universityManageInfo.AddStudentInfo("Nikolai", "Kanushkov", "BI-2");

            universityManageInfo.AddStudentInfo("Ilona", "Chemodanova", "PS-1");
            universityManageInfo.AddStudentInfo("Anton", "Merzlyakov", "PS-1");

            universityManageInfo.AddStudentInfo("Denis", "Tikhomirov", "PS-2");
            universityManageInfo.AddStudentInfo("Elena", "Lyashko", "PS-2");

            universityManageInfo.AddStudentInfo("Natalia", "Ryzhkova", "IVT");
            universityManageInfo.AddStudentInfo("Egor", "Pekunov", "IVT");
            universityManageInfo.AddStudentInfo("Denis", "Karasyov", "IVT");
            universityManageInfo.AddStudentInfo("Sofia", "Nikulina", "IVT");
            universityManageInfo.AddStudentInfo("Vladimyr", "Bezrodnyi", "IVT");

            universityManageInfo.AddLecturerInfo("Alexander", "Ivanov");
            universityManageInfo.AddLecturerInfo("Nikolai", "Parsaev");
            universityManageInfo.AddLecturerInfo("Ivan", "Smirnov");
            universityManageInfo.AddLecturerInfo("Anatolyi", "Leukhin");
            universityManageInfo.AddLecturerInfo("Alexander", "Gubaev");

            universityManageInfo.AddCourseInfo("OOPBasics");
            universityManageInfo.AddCourseInfo("PythonBasics");
            universityManageInfo.AddCourseInfo("DataBases");
            universityManageInfo.AddCourseInfo("InfoSecurityBasics");
            universityManageInfo.AddCourseInfo("CircuitDesign");
            universityManageInfo.AddCourseInfo("Cryptography");

            universityManageInfo.AddLecturerCourseInfo("Anatolyi", "Leukhin", "Cryptography");
            universityManageInfo.AddLecturerCourseInfo("Ivan", "Smirnov", "Cryptography");
            universityManageInfo.AddLecturerCourseInfo("Ivan", "Smirnov", "InfoSecurityBasics");
            universityManageInfo.AddLecturerCourseInfo("Nikolai", "Parsaev", "PythonBasics");
            universityManageInfo.AddLecturerCourseInfo("Nikolai", "Parsaev", "CircuitDesign");
            universityManageInfo.AddLecturerCourseInfo("Alexander", "Ivanov", "OOPBasics");

            universityManageInfo.AddStudentGroupCourseInfo("BI-1", "OOPBasics");
            universityManageInfo.AddStudentGroupCourseInfo("BI-1", "Cryptography");
            universityManageInfo.AddStudentGroupCourseInfo("BI-1", "InfoSecurityBasics");
            universityManageInfo.AddStudentGroupCourseInfo("BI-2", "OOPBasics");
            universityManageInfo.AddStudentGroupCourseInfo("BI-2", "InfoSecurityBasics");
            universityManageInfo.AddStudentGroupCourseInfo("PS-1", "OOPBasics");

            universityManageInfo.UpdateLecturerInLecturerCourseInfo("Ivan", "Smirnov",
                                                                    "Alexander", "Gubaev", "Cryptography");

            universityManageInfo.PrintCourseNumberOfStudentsInfo();
            universityManageInfo.PrintGeneralDataInfo();

            Console.ReadKey();
        }
    }
}
