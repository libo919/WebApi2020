﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;

namespace WebApi2020.DB
{
    public partial class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }
        #region 支持SQL操作
        private DataTable SqlQuery(string sql, params SqlParameter[] parameters)
        {
            using (var conn = base.Database.GetDbConnection())
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(parameters);
                var reader = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                conn.Close();
                return dt;
            }
        }
        public DataTable SqlQuery(string sql, List<SqlParameter> list = null)
        {
            if (list == null)
            {
                return SqlQuery(sql);
            }
            return SqlQuery(sql, list.ToArray());
        }
        private object SqlSingle(string sql, params SqlParameter[] parameters)
        {
            using (var conn = base.Database.GetDbConnection())
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(parameters);
                var obj = cmd.ExecuteScalar();
                conn.Close();
                return obj;
            }
        }
        public object SqlSingle(string sql, List<SqlParameter> list = null)
        {
            if (list == null)
            {
                return SqlSingle(sql);
            }
            return SqlSingle(sql, list.ToArray());
        }
        #endregion

        public DbSet<WebApi2020.Models.User> User { get; set; }

        public DbSet<WebApi2020.Models.SysUser> SysUser { get; set; }
    }
}
