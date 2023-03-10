using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatGPT_Model.AppModel;
using SqlSugar;

namespace ChatGPT_Mapper
{
    public class SugarConfig
    {
        private static SqlSugarScope db = null;
        public static SqlSugarScope CretClient()
        {
            string dbConnectionString = AppSettingsHelper.Configuration["DBConfig:DBConnectionString"].ToString();
            string dbType = AppSettingsHelper.Configuration["DBConfig:DBType"].ToString();
            SqlSugar.DbType SugarDbType = new SqlSugar.DbType();
            switch (dbType)
            {
                case "mssql":
                    SugarDbType = SqlSugar.DbType.SqlServer;
                    break;
                case "mysql":
                    SugarDbType = SqlSugar.DbType.MySql;
                    break;
                case "oracle":
                    SugarDbType = SqlSugar.DbType.Oracle;
                    break;
                case "dm":
                    SugarDbType = SqlSugar.DbType.Dm;
                    break;
                case "kdbndp":
                    SugarDbType = SqlSugar.DbType.Kdbndp;
                    break;
                case "huawei":
                    SugarDbType = SqlSugar.DbType.PostgreSQL;
                    break;
            }
            db = new SqlSugarScope(new ConnectionConfig()
            {
                ConnectionString = dbConnectionString, //数据库连接字符串
                DbType = SugarDbType,
                IsAutoCloseConnection = true, //默认false
            });
            //SQL执行前
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                //5.0.8.2 获取无参数化 SQL 
                //UtilMethods.GetSqlString(DbType.SqlServer,sql,pars)
            };
            //SQL执行完
            db.Aop.OnLogExecuted = (sql, pars) =>
            {
                //执行完了可以输出SQL执行时间 (OnLogExecutedDelegate) 
                //监控执行时间超过1秒
                if (db.Ado.SqlExecutionTime.TotalSeconds > 1)
                {
                    //代码CS文件名
                    var fileName = db.Ado.SqlStackTrace.FirstFileName;
                    //代码行数
                    var fileLine = db.Ado.SqlStackTrace.FirstLine;
                    //方法名
                    var FirstMethodName = db.Ado.SqlStackTrace.FirstMethodName;
                    //db.Ado.SqlStackTrace.MyStackTraceList[1].xxx 获取上层方法的信息
                }
                //相当于EF的 PrintToMiniProfiler
            };
            //SQL报错
            db.Aop.OnError = (exp) =>
            {
                string ErrSql = exp.Sql;
                string con = dbConnectionString;
                //exp.sql 这样可以拿到错误SQL，性能无影响拿到ORM带参数使用的SQL
                throw new Exception(exp.Message);
                //5.0.8.2 获取无参数化 SQL  对性能有影响，特别大的SQL参数多的，调试使用         
            };
            return db;
        }
    }
}
