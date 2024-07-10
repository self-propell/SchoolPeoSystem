using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchPeoSystem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SchPeoSystem.DAO.Tests
{
    [TestClass()]
    public class PM_Account_DAOTests
    {
        [TestMethod()]
        public void GetAccountsByRulesTest()
        {
            string id = "admin";
            string des = "";
            string isfreez = "active";
            PM_Account_DAO _Account_DAO = new PM_Account_DAO();
            System.Console.WriteLine(_Account_DAO.GetAccountsByRules("","active","")[0].Login_Id);
            //// 没有描述
            //System.Console.WriteLine(_Account_DAO.GetAccountsByRules(id, isfreez, des).ToString());
            //// 错误描述
            //des = "error";
            //System.Console.WriteLine(_Account_DAO.GetAccountsByRules(id, isfreez, des).Count());
            //// 错误id导致无结果
            //id = "errorid";
            //des = "";
            //System.Console.WriteLine(_Account_DAO.GetAccountsByRules(id, isfreez, des).Count());
        }
    }
}