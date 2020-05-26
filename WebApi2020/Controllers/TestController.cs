using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApi2020.DB;
using WebApi2020.DB.Models;

namespace WebApi2020.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [Route("[action]")]
        public string S1()
        {
            //添加测试数据
            using (var db = new MyContext())
            {
                //User useradd = new User() { name = "姓名" };
                //db.User.Add(useradd);
                //db.SaveChanges();
                return "S1";
            }
        }


        [Route("[action]")]
        public string S2()
        {
            //linq查询
            using (var db = new MyContext())
            {
                User user = (from x in db.User
                             orderby x.Id descending
                             select x).FirstOrDefault();
                if (user == null)
                {
                    return "";
                }
                return user.name;
            }
        }

        //强制要求post方式提交请求
        [HttpPost]
        [Route("[action]")]
        public User S3(int id)
        {
            //Lambda表达式查询，返回实体对象
            using (var db = new MyContext())
            {
                User user = db.User.FirstOrDefault(x => x.Id == id);
                return user;
            }
        }

        [Route("[action]")]
        public ActionResult<User> S4()
        {
            //返回标准http响应
            using (var db = new MyContext())
            {
                Random r = new Random();
                int id = r.Next(1, 10);
                User user = db.User.FirstOrDefault(x => x.Id == id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
        }


        [Route("[action]")]
        public string SqlTable()
        {
            //执行sql查询
            using (var db = new MyContext())
            {
                string sql = "seelct id,name from [user] where id = @id";
                List<SqlParameter> list = new List<SqlParameter>() {
                    new SqlParameter("@id", 1)
                };
                DataTable dt = db.SqlQuery(sql, list);
                if (dt.Rows.Count == 0)
                {
                    return "";
                }
                string name = dt.Rows[0]["name"].ToString();
                return name;
            }
        }
    }
}
