using SchPeoSystem.DAO;
using SchPeoSystem.Models;
using System.Net.NetworkInformation;
using System.Xml.Linq;

namespace SchPeoSystem.Services
{
    public class TeacherService
    {
        private static readonly PM_Teacher_DAO _teacherDAO = new PM_Teacher_DAO();
        private TeacherService() { }
        /// <summary>
        /// 得到未被删除、未办理离职的老师的信息
        /// </summary>
        /// <returns>教师信息列表MTeacher（List）</returns>
        public static List<MTeacher> GetAllActiveTeachers()
        {
            List<MTeacher> mTeachers = null;
            try
            {
                mTeachers = _teacherDAO.GetAllActiveTeachers();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return mTeachers;
        }
        /// <summary>
        /// 输入教师信息进行检索
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Status"></param>
        /// <param name="School"></param>
        /// <param name="Job"></param>
        /// <param name="Description"></param>
        /// <returns></returns>
        public static List<MTeacher> GetTeacherByRules(string Name,string Status,string School,string Job,string Description)
        {
            List<MTeacher> mTeachers = null;
            try
            {
                mTeachers = _teacherDAO.GetTeacherByRules(Name, Status, School, Job, Description);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return mTeachers;
        }
    }
}
