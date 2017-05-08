﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WRYJC.DAL;
using WRYJC.Domain;

namespace DALTest
{
    /*
     * author：戴清
     * 2017-05-07 17:09:34
     * 有关DAL层的测试
     */
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDayData()
        {
            Response<GasDayData> data = new GasDayDataDALImpl().GetDayDataByID(0);
            //Console.WriteLine(data.ID + " " + data.Status);
            Assert.AreEqual("0", data.list[0].ID);
        }

        [TestMethod]
        public void TestToString()
        {
            //init 
            ISysUserDAL target = new SysUserDALImpl();
            //action
            SysUser user = target.GetUserByNameAndPassWord("admin", "123456").list[0];
            //assert
            Assert.AreNotEqual("xxx", user.ToString());
        }

        [TestMethod]
        public void TestSysUserLogin()
        {
            ISysUserDAL userGetter = new SysUserDALImpl();
            Response<SysUser> res = userGetter.GetUserByNameAndPassWord("admin", "123456");

            Assert.AreEqual(true, res.isSuccess);
            Assert.AreEqual("admin", res.list[0].LoginName);

            res = userGetter.GetUserByNameAndPassWord("admin", "1234");
            Assert.AreEqual(false, res.isSuccess);
        }
        [TestMethod]
        public void TestSysRoleAndSysPower()
        {
            ISysRoleAndSysPowerDAL target = new SysRoleAndSysPowerDALImpl();
            Response<SysPower> result = target.GetSysPowerByRoleId(2);
            Assert.AreEqual(33,result.list.Count);
        }
        [TestMethod]
        public void TestSysUserAndSysRole()
        {
            ISysUserAndSysRoleDAL target = new SysUserAndSysRoleDALImpl();
            Response<SysRole> result = target.GetSysRoleBySysUserId(1);
            Assert.AreEqual(2, result.list[0].Id);
            Assert.AreEqual(1, result.list[0].RoleName);
        }
    }
}
