using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for WebConstant
/// </summary>
/// 
public class WebConstant
{
    public struct Config
    {
        public static string ImageLocation = "images\\";
        public static string AppURL = "~/";
        public static string Resource = "announcementid";
    }

    public struct QueryStringEnum
    {
        public static string UserID = "user_id";
        public static string ReserveID = "reserve_id";
        public static string BankID = "bank_id";
        public static string VillageID = "village_id";
        public static string Familyid = "family_id";
        public static string FamilyMemberID = "familymem_id";
        public static string INSTID = "instid";
        public static string RELO_ID = "reloid";
        
        

        

        



        public static string LoginName = "loginname";
       
        public static string AnnouncementID = "announcementid";
        public static string CourseID = "courseid";
        public static string ClassID = "classid";
        public static string StatusID = "statusid";
        public static string CustomerID = "customerid";
        public static string CustomerCode = "customercode";
        public static string MemberID = "memberid";
        public static string LessonID = "lessonid";
        public static string UnitID = "unitid";
        public static string ObjectiveID = "objectiveid";
        public static string PageID = "pageid";
        public static string TicketID = "ticketid";
        public static string ParentCustomerID = "parentcustomerid";
        public static string ActivationMethod = "method";
        public static string RoleID = "roleid";
        public static string GradeLevelID = "gradelevelid";
        public static string LicenseCustomerID = "licensecustomerid";
        public static string LicenseID = "licenseid";
        public static string SettingID = "settingid";
        public static string ChooseProfileID = "profileid";
        public static string ReturnUrl = "returnurl";
        public static string ObjectiveCategoryID = "objectivecategoryid";
        public static string QuizID = "quizid";
        public static string QuestionID = "questionid";
        public static string QuizQuestionID = "QuizQuestionID";
        public static string OptionID = "OptionID";
        public static string AddressID = "AddressID";
        public static string MemberInformationID = "memberInformationID";
        public static string MemberPropertyID = "memberPropertyID";
        public static string AttendanceID = "attendanceID";
        public static string AppdateID = "appdateID";
        public static string AttendanceDate = "attendanceDate";
        public static string GradeBookID = "gradebookid";
        public static string GradeBookCategoryID = "gradebookcategoryid";
        public static string GradeBookEntryID = "gradebookentryid";
        public static string ExamID = "examid";
        public static string message = "message";
        public static string ExamBankID = "exambankID";
        public static string ExamBankClassID = "exambankclassID";
        public static string ExamClassID = "examclassid";
        public static string ExamTimeID = "examtimeid";
        public static string ExamQuestionID = "examQuestionid";
        public static string ProductID = "productID";
        public static string ProductTypeID = "productTypeID";
        public static string MessageID = "messageID";
        public static string MessageMemberID = "messagememberID";
        public static string MailFlag = "mailflag";
    }

    public struct ApplicationPages
    {
        public static string Home = "~/secure/homepage.aspx";
        public static string EditRole = "~/secure/security/editrole.aspx";
        public static string MembersInRole = "~/secure/security/membersinrole.aspx";
        public static string Roles = "~/secure/security/roles.aspx";
        public static string Login = "~/login.aspx";
        public static string CourseHome = "~/Course/default.aspx";
        public static string UserAccount = "~/secure/account/IndividualAccount.aspx";
        public static string CustomerAccount = "~/secure/account/CreateNewAccount.aspx";
        public static string PageHome = "~/secure/class/CreatePage.aspx";
        public static string RegistrationSuccess = "~/RegistrationSuccess.aspx";
        public static string CreateObjective = "~/secure/course/CreateObjectives.aspx";
        public static string ListObjectives = "~/secure/course/ListObjectives.aspx";
        public static string EditLesson = "~/secure/class/EditLesson.aspx";
        public static string UnitLesson = "~/secure/course/CreateUnitLessons.aspx";
        public static string CreatePage = "~/secure/class/CreatePage.aspx";
        public static string CreateClass = "~/secure/class/CreateClass.aspx";
        public static string CreateCourse = "~/secure/course/CreateCourse.aspx";
        public static string ListClasses = "~/secure/class/ListClasses.aspx";
        public static string ListCourses = "~/secure/course/ListCourses.aspx";
        public static string ListLessons = "~/secure/class/ListLessons.aspx";
        public static string ListGradeLevels = "~/secure/course/ListGradeLevels.aspx";
        public static string ListObjectiveCategories = "~/secure/course/ListObjectiveCategories.aspx";
        public static string ListUnits = "~/secure/class/ListUnits.aspx";
        public static string CreateUnit = "~/secure/class/CreateUnit.aspx";
        public static string EditTicket = "~/secure/ticket/EditTicket.aspx";
        public static string LessonObjective = "~/secure/course/CreateLessonObjectives.aspx";
        public static string CreateAnnouncement = "~/secure/announcement/CreateAnnouncement.aspx";
        public static string CreateCustomerLicence = "~/secure/Licence/AddCustomerLicence.aspx";
        public static string CreateLicence = "~/secure/Licence/AddLicence.aspx";
        public static string ViewCustomerFrontPage = "~/secure/account/ViewCustomerSettings.aspx";
        public static string CreateCustomerFrontPage = "~/secure/account/CreateCustomerSettings.aspx";
        public static string ChooseProfile = "~/secure/account/ChooseProfile.aspx";
        public static string AddQuiz = "~/secure/Quiz/CreateQuiz.aspx";
        public static string ListQuestion = "~/secure/Quiz/ListQuestions.aspx";
        public static string CreateQuestion = "~/secure/Quiz/CreateQuestions.aspx";
        public static string CreateQuizQuestion = "~/secure/Quiz/CreateQuizQuestion.aspx";
        public static string AddQuestionOptions = "~/secure/Quiz/AddQuestionOptions.aspx";
        public static string ListQuestionOptions = "~/secure/Quiz/ListQuestionOptions.aspx";
        public static string EditAddress = "~/secure/address/UpdateAddress.aspx";
        public static string EditAttendance = "editattendance.aspx";
        public static string RolePermissions = "~/secure/security/rolepermissions.aspx";
        public static string Gradebook = "~/secure/gradebook/gradebook.aspx";
        public static string CreateGradebook = "~/secure/gradebook/creategradebook.aspx";
        public static string CreateGradebookCategory = "~/secure/gradebook/creategradebookcategory.aspx";
        public static string CreateGradebookEntry = "~/secure/gradebook/creategradebookentry.aspx";
        public static string Profile = "~/secure/registration/profiles.aspx";
        public static string AddressHistory = "~/secure/address/addresshistory.aspx";
        public static string ActivateAccountControl = "~/secure/account/ActivateAccount.ascx";
        public static string ListAnnouncement = "~/secure/announcement/ListAnnouncements.aspx";
        public static string CreateStateStandard = "~/secure/course/CreateStateStandard.aspx";
        public static string CreateGradeLevel = "~/secure/course/CreateGradeLevel.aspx";
        public static string ListQuizQuestion = "~/secure/Quiz/ListQuizQuestions.aspx";
        public static string IndividualAttendance = "~/secure/class/IndividualAttendance.aspx";
        public static string MonthlyAttendance = "~/secure/class/MonthlyAttendance.aspx";
        public static string OverallAttendance = "~/secure/class/OverallAttendance.aspx";
        public static string ListStudents = "~/secure/class/ListStudents.aspx";
        public static string EnrollStudents = "~/secure/class/EnrollStudents.aspx";
        public static string TeacherHomePage = "~/secure/class/TeacherHomePage.aspx";
        public static string Attendance = "~/secure/class/Attendance.aspx";
        public static string EditMemberRole = "~/secure/security/editmemberrole.aspx";
        public static string ListExamBanks = "~/secure/exam/ListExamBanks.aspx";
        public static string CreateExamBank = "~/secure/exam/CreateExamBank.aspx";
        public static string ExamActivation = "~/secure/exam/ExamActivation.aspx";
        public static string ActivateExam = "~/secure/exam/ActivateExam.aspx";
        public static string DeactivateExam = "~/secure/exam/DeactivateExam.aspx";
        public static string SelectedStudentList = "~/secure/exam/SelectedStudentList.aspx";
        public static string RetakeExam = "~/secure/exam/RetakeExam.aspx";
        public static string SetLocalTime = "~/secure/exam/SetLocalTime.aspx";
        public static string CreateExamQuestion = "~/secure/exam/CreateExamQuestion.aspx";
        public static string ListExam = "~/secure/exam/ListExam.aspx";
        public static string CreateExam = "~/secure/exam/CreateExam.aspx";
        public static string StartExam = "~/secure/exam/StartExam.aspx";
        public static string AddProduct = "~/secure/store/AddProduct.aspx";
        public static string ProductsDisplay = "~/secure/store/ProductsDisplay.aspx";
        public static string IndividualProductDisplay = "~/secure/store/IndividualProductDisplay.aspx";
        public static string ShoppingCart = "~/secure/store/ShoppingCart.aspx";
        public static string CreditCardDetail = "~/secure/store/CreditCardDetail.aspx";
        public static string CreateMail = "~/secure/Student/CreateMail.aspx";
        public static string OpenMail = "~/secure/Student/OpenMail.aspx";
        public static string StudentHomePage = "~/secure/Student/StudentHomePage.aspx";

    }

    public struct UserFriendlyMessages
    { 
        // author name :- jitin purwal(Software Developer Trainee)
        //Start
        public static string AccountCreationSuccess = "User account has been created successfully.";
        public static string AccountUpdateSuccess = "User account has been updated successfully.";
        public static string PasswordChangeSuccess = "Your password has been changed successfully.";
        public static string ReserveUpdateSuccess = "Reserve Details has been Updated successfully.";
        public static string VillageUpdateSuccess = "Village Details has been Updated successfully.";
        public static string FamilyCreatedSuccess = "Family Details has been Created successfully.";
        public static string InstallmentAdded = "Installment Inserted successfully.";
        public static string SellerDetail = "Seller Details has been Inserted successfully.";
        public static string FDDetails = "FD Detail has been Inserted successfully.";
        public static string UpdatedINST = "Installment has been updated successfully.";
        public static string UpdatedFD = "FD has been updated successfully.";

        public static string NGO = "NGO Details Inserted successfully.";
        public static string CDP = "CDP Details Inserted successfully.";
           public static string LegalFormAdded =  "Legal Form Inserted Successfully";
        public static string NGOEdit = "NGO Details Updated successfully.";
        

       
        
        
        //End
        public static string AccountActivationSuccess = "Your account has been activated successfully.";
        public static string AccountActivationFailure = "We have encountered an error while activating your account. Please try again later";
        public static string AccountCreationError = "You have encountered an error during account creation. Please try again later";
        public static string ClassCreationSuccess = "Your Class has been created successfully.";
        public static string ClassUpdateSuccess = "Your Class has been updated successfully.";
        public static string CourseCreationFailure = "An Error has occured during course creation.";
       
        public static string PasswordChangeFailure = "An error has occured during password change. Please try again.";
        public static string UnitCreationSuccess = "Unit Created successfully.";
        public static string UnitUpdateSuccess = "Unit Updated successfully.";
        public static string GeneralErrorMessage = "An error has occured. Please try again.";
        public static string ObjectiveCreationSuccess = "Your Objective has been created successfully.";
        public static string ObjectiveUpdateSuccess = "Your Objective has been updated successfully.";
        public static string LessonCreationSuccess = "Your Lesson has been created successfully.";
        public static string LessonUpdateSuccess = "Your Lesson has been updated successfully.";
        public static string PageCreationSuccess = "Your Page has been created successfully.";
        public static string PageUpdateSuccess = "Your Page has been updated successfully.";
        public static string TicketCreationSuccess = "Your Ticket has been created successfully.";
        public static string TicketUpdateSuccess = "Your Ticket has been updated successfully.";
        public static string LessonObjectiveCreationSuccess = "Your LessonObjective has been created successfully.";
        public static string LessonObjectiveUpdateSuccess = "Your LessonObjective has been updated successfully.";
        public static string StateObjectiveCreationSuccess = "Your State Objectives have been created successfully.";
        public static string GradeLevelCreationSuccess = "Grade Level has been created successfully.";
        public static string ObjectiveCategoryCreationSuccess = "Objective Category has been created successfully.";
        public static string StateStandardCreationSuccess = "State Standard has been created successfully.";
        public static string LicenceUpdateSuccess = "Your  Licence have been updated successfully.";
        public static string LicenceCreatedSuccess = "Your  Licence have been created successfully.";
        public static string FrontPageUpdateSuccess = "Your Logo have been updated successfully.";
        public static string FrontPageSuccess = "Your Logo have been created successfully.";
        public static string ClassEnrollSuccess = "Message has been sent to your teacher to approve you in class";
        public static string QuizUpdateSuccess = "Your Quiz have been updated successfully.";
        public static string QuizCreatedSussess = "Your Quiz have been created successfully.";
        public static string QuizQuestionCreatedSussess = "Your Quiz question have been created successfully.";
        public static string QuizQuestionUpdatedSussess = "Your Quiz Question have been updated successfully.";
        public static string QuestionOptionCreatedSussess = "Your  question option have been created successfully.";
        public static string QuestionOptionUpdatedSussess = "Your  question option have been updated successfully.";
      
        public static string selectMonthYear = "Select month and Year";
        public static string selectDigit = "Select digit";
        public static string ExamCreationSuccess = "Your ExamBank have been created successfully.";
        public static string ExamUpdationSuccess = "Your ExamBank have been updated successfully.";
        public static string ExamBankClassCreationSuccess = "Your class ExamBank have been created successfully.";
        public static string ExamBankClassUpdationSuccess = "Your class ExamBank have been updated successfully.";
        public static string SelectLanguage = "Select Language";
        public static string SelectStatus = "Select Status";
        public static string ExamCreatedSussess = "Your Exam have been created successfully.";
        public static string ClassExamCreatedSussess = "Your Class Exam have been created successfully.";
        public static string selectExamBank = "Select Exam Bank";
        public static string selectExamType = "Select Exam Type";
        public static string selectExam = "Select Exam";
        public static string ExamQuestion = "Your Exam Question have been created successfully.";
        public static string cantdelete = "Can’t delete the selected record.";
        public static string SelectStandard = "Select Standard";
        public static string SelectGradeLevel = "Select Grade Level";
        public static string SelectObjectiveCategory = "Select Objective Category";
        public static string SelectObjective = "Select Objective";
        public static string ProductAdditionSuccess = "Your Product has been added successfully.";
        public static string ProductUpdateSuccess = "Your Product has been updated successfully.";
        public static string GradebookCategoryCreationSuccess = "Gradebook Category has been created successfully.";
        public static string GradebookCategoryCreationFailure = "An error has occured during Gradebook Category creation.";
        public static string GradebookEntryCreationSuccess = "Gradebook Entry has been created successfully.";
        public static string DuplicateEmailAddress = "User with this email address already exists. Please try again with different email";
        public static string DuplicateUserName = "This username is already in use. Please try again with different username";
        public static string RegisteredWithNoCustomer = "Your account has been created, but we can not assign you to any customer at this point. Please contact technical support";
        public static string ProductAdditionFailure = "An error has occured during Product addition.";
        public static string SelectYear = "Select Year";
        public static string YearType = "Select Year Type";

        // author name :- jitin purwal(Software Developer Trainee)
        //Start


        public static string selectstatename = "Please Select State Name";
        public static string selectReservename = "Please Select Reserve Area Name";
        public static string selectDistrictname = "Please Select District Name";
        public static string selectTehsilname = "Please Select Tehsil Name";
        public static string selectGrampanchayatname = "Please Select Grampanchayat Name";
        public static string selectvilllglstts = "Please Select Village Legal Status";
        public static string selectvillstts= "Please Select Village Status";
        public static string selectviilcrbuffstts = "Please Select Village Core/Buffer Status";



        public static string ExceptionError = "Error Occur.Please Try Again Later";
        public static string LoginIDNotFound = "This Login ID Does Not Exists";
        public static string LoginIDDuplicasy = "This Login ID Already Exists!!Please Try Different";
        public static string CaptchaMessage = "Wrong Code. Please Try Again!!!";
        public static string InvalidPassword = "User id or Password is incorrect!!Try Again!!";
        public static string AccountDeactivatedSuccessfully = "User Account has been Deactivated Successfully!!";
        public static string ReserveDeactivatedSuccessfully = "Reserve Area  has been Deactivated Successfully!!";
        public static string VillageCreatedSuccessfully = "Village Created Successfully!!";
        public static string BankCreatedSuccessfully = "Bank Details has been Submitted Successfully!!";
        public static string BankDeactivatedSuccessfully = "Bank has been Deactivated Successfully!!";
        public static string SelectStatusError = "Please Select State Status";
        public static string VillageDeactivatedSuccessfully = "Village has been Deactivated Successfully!!";
        public static string VillageCodeMessage = "This Village Code Already Exists Please Try Another!!";
        public static string ReserveCreatedSuccessfully = "Reserve Area  has been Created Successfully!!";
        public static string NoRecordFound = "No Record Found";
        public static string PasswordResetSuccess = "Your Password  has been Reset Successfully!!";
        public static string EmailIDDuplicasy = "This Email ID Already Exists!!Please Try Different";
        //End
    }

    public enum StatusEnum { Active = 1, Canceled = 2, Pending = 3 };
    public enum Role { Admin = 1,  DEO = 2, Users = 3 };

    public enum LanguageEnum { English = 1, German = 2 };

    public enum CourseTypeEnum { Static = 1, Dynamic = 2 };

    public enum ExamLevelEnum { StateExam = 1, SchoolExam = 2 };

    public enum ExamTypeEnum { Quiz = 1, Assignment = 2, Project = 3, MidTerm = 4, Final = 5 };

    public enum AttendanceTypeEnum { Present = 1, Absent = 2, Leave = 3, Excused = 4, NonExcused = 5 };

    public enum TicketStatusEnum { New = 1, Unresolved = 2, Resolved = 3, Closed = 4 };

    public enum PriorityEnum { Low = 1, Medium = 2, High = 3 };

    public enum MailEnum { Reply = 1, Forward = 2 };
}
