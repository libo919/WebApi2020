using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApi2020.DB;
using WebApi2020.Models;

namespace WebApi2020.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Test2Controller : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly SqlContext _sqlcontext;

        public Test2Controller(ModelContext context, SqlContext sqlcontext)
        {
            _context = context;
            _sqlcontext = sqlcontext;
        }

        [HttpPost]
        [Route("[action]")]
        // POST: Test2/GetListByName
        public List<User> GetListByName(string name)
        {
            //使用sql封装User
            string sql = "select * from [user] where name like '%@name%'";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@name", name));
            DataTable dt = _sqlcontext.SqlQuery(sql, list);
            var users = from x in dt.AsEnumerable()
                        select new User()
                        {
                            Id = x.Field<int>("id"),
                            Name = x.Field<string>("name"),
                            Del = x.Field<int>("Del")
                        };
            return users.ToList();
        }

        // POST: Test2/GetListByName
        [HttpPost]
        [Route("[action]")]
        public List<User> GetListByName2(string name)
        {
            //使用EF读取
            var users = _context.User.Where(x => x.Name.Contains(name));
            return users.ToList();
        }

        // POST: Test2/GetListByName
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<List<User>>> GetListByName3(string name)
        {
            //使用EF读取，使用异步
            var users = _context.User.Where(x => x.Name.Contains(name));
            return await users.ToListAsync();
        }
    }
}
