using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperUtility
{
    public class LoginInfomation
    {
        private static LoginInfomation instance = new LoginInfomation();

        public LoginInfomation() { }

        public static LoginInfomation getInstance()
        {
            return instance;
        }
        /// <summary>
        /// 登录的用户名 
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 登录的用户角色
        /// </summary>
        public string UserRole { get; set; }
        /// <summary>
        /// 登录的用户code
        /// </summary>
        public string UserCode { get; set; }

        private List<string> readpermission = new List<string>();
        /// <summary>
        /// 角色读取的权限
        /// </summary>
        public List<string> ReadPermission
        {
            get { return readpermission; }
            set { readpermission = value; }
        }

        /// <summary>
        /// 添加具有的读取权限模块名
        /// </summary>
        /// <param name="moduleName"></param>
        public void ReadpermissionAdd(string moduleName)
        {
            readpermission.Add(moduleName);
        }

        private List<string> writepermission = new List<string>();
        /// <summary>
        /// 角色写入的权限
        /// </summary>
        public List<string> WritePermission
        {
            get { return writepermission; }
            set { writepermission = value; }
        }
        /// <summary>
        /// 添加具有的写入权限模块名
        /// </summary>
        /// <param name="moduleName"></param>
        public void WritepermissionAdd(string moduleName)
        {
            writepermission.Add(moduleName);
        }

        private List<string> auditpermission = new List<string>();
        /// <summary>
        /// 角色审核的权限
        /// </summary>
        public List<string> AuditPermission
        {
            get { return auditpermission; }
            set { auditpermission = value; }
        }
        /// <summary>
        /// 添加具有的审核权限模块名
        /// </summary>
        /// <param name="moduleName"></param>
        public void AuditPermissionAdd(string moduleName)
        {
            auditpermission.Add(moduleName);
        }
    }
}
