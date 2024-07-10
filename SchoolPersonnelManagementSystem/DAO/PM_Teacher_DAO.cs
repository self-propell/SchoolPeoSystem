using SchPeoSystem.Models;
using SchPeoSystem.Utils;
using System.Data.SqlClient;
using System.Data;

namespace SchPeoSystem.DAO
{
    public class PM_Teacher_DAO : BASE_DAO<MTeacher>
    {
        /// <summary>
        /// 获取所有未离职、未删除教师信息
        /// </summary>
        /// <returns></returns>
        public List<MTeacher> GetAllActiveTeachers()
        {
            SqlConnection connection = null;
            List<MTeacher> teachers = new List<MTeacher>();
            try
            {
                connection = SqlConnectionFactory.GetSession();
                // 这条语句获取教师信息【学院信息保存为ID，没有进行连接查询】
                string sqlstr = "SELECT * FROM PM_Teacher LEFT JOIN PM_School WHERE is_deleted=0 AND is_departed=0";
                ////获取教师信息，同时获取学院名称【左连接学院表】
                //string sqlstr = "SELECT t.*,s.school_name FROM PM_Teacher t LEFT JOIN PM_School s ON t.school_id=s.school_id WHERE t.is_deleted=0 AND t.is_departed=0";
                SqlCommand command = new SqlCommand(sqlstr, connection);
                DataTable dt = new DataTable();
                new SqlDataAdapter(command).Fill(dt);
                teachers = ConvertToList(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                if (connection is not null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            return teachers;
        }

        public List<MTeacher> GetTeacherByRules(string Name, string Status, string School, string Job, string Description)
        {
            SqlConnection connection = SqlConnectionFactory.GetSession();
            List<MTeacher> mTeachers = new List<MTeacher>();
            try
            {
                connection = SqlConnectionFactory.GetSession();
                string sqlstr = "SELECT * FROM PM_Teacher WHERE ";
                SqlCommand command = new SqlCommand(sqlstr, connection);
                // 根据条件添加检索语句
                // 教师状态
                switch (Status)
                {
                    case "active":
                        sqlstr += " is_departed=0 AND is_deleted=0";
                        break;
                    case "departed":
                        sqlstr += " is_departed=1 AND is_deleted=0";
                        break;
                    case "deleted":
                        sqlstr += " is_deleted=1";
                        break;
                    default: throw new NotImplementedException();
                }
                // 姓名
                if (!string.IsNullOrEmpty(Name))
                {
                    sqlstr += " AND name like @Name"

                }
                // 学院
                if (string.IsNullOrEmpty(School))
                {
                    sqlstr += " "
                }
                DataTable dt = new DataTable();
                new SqlDataAdapter(command).Fill(dt);
                mTeachers = ConvertToList(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            return mTeachers;
        }
    }
