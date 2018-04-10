using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDAL
{
    public class TestRepository:AbstractRepository<Test>
    {
        public string ConnStr
        {
            get
            {
                return SqlHelper.GetConnString(DBEnum.ATP_ACC);
            }
        }
        public SqlConnection Conn
        {
            get
            {
                return SqlHelper.GetConnection(ConnStr);
            }
        }
        public override Test FindByPrimaryKey(object id)
        {
            var parameters = new List<SqlParameter>(){new SqlParameter("@ID", id)}.ToArray();
            var reader = SqlHelper.ExecuteReader(ConnStr, CommandType.Text, "select * from test where ID=@ID", parameters);
            var t = new Test();
            if (reader != null)
            {
                reader.NextResult();
                t = ConvertHelper(reader).FirstOrDefault();
            }
            return t;
        }

        public override IList<Test> FindAll()
        {
            var reader = SqlHelper.ExecuteReader(Conn, CommandType.Text, "select * from Test");
            var result = ConvertHelper(reader);
            return result;
        }

        public override IList<Test> FindAll(string whereStr="")
        {
            if (whereStr == "")
                return FindAll();
            else
            {
                var reader = SqlHelper.ExecuteReader(Conn, CommandType.Text, "select * from Test "+whereStr);
                var result = ConvertHelper(reader);
                return result;
            }
        }

        public override object Create(Test instance)
        {
            var sql = "insert into Test values(@Value)";
            var param = new SqlParameter("@Value", instance.Value);
            var result = SqlHelper.ExecuteNonQuery(Conn, CommandType.Text, sql,param);
            return result;
        }

        public override bool Update(Test instance)
        {
            var sql = "update Test set Value=@Value";
            var param = new SqlParameter("@Value", instance.Value);
            var result = SqlHelper.ExecuteNonQuery(Conn, CommandType.Text, sql, param);
            return result>0;
        }

        public override bool Delete(Test instance)
        {
            var sql = "delete from Test where ID=@ID";
            var param = new SqlParameter("@ID", instance.ID);
            var result = SqlHelper.ExecuteNonQuery(Conn, CommandType.Text, sql, param);
            return result > 0;
        }

        public override bool Delete(string propertyName, string propertyValue)
        {
            IDictionary<string, string> property = new Dictionary<string, string>();
            property.Add(propertyName, propertyValue);
            return Delete(property);
        }

        public override bool Delete(IDictionary<string, string> propertys)
        {
            var sql = "delete from Test where 1=1";
            var paramList = new List<SqlParameter>();
            List<string> clause = new List<string>();
            foreach (KeyValuePair<string, string> kv in propertys)
            {
                var param = new SqlParameter();
                param.ParameterName = "@"+kv.Key;
                param.Value = kv.Value;
                paramList.Add(param);
                clause.Add(kv.Key + "=" + param.ParameterName);
            }
            if (clause.Count > 0)
            {
                if (!sql.EndsWith("and", StringComparison.CurrentCultureIgnoreCase))
                    sql = sql + " and ";
                sql += string.Join(",", clause);
            }
            var result = SqlHelper.ExecuteNonQuery(Conn, CommandType.Text, sql, paramList.ToArray());
            return result > 0;
        }

        public override bool Delete(IList<Test> entities)
        {
            throw new NotImplementedException();
        }

        public override IList<Test> FindAllByWhere(int pageSize, int pageCurrent, out int countRows, out int countPages, string whereStr)
        {
            throw new NotImplementedException();
        }
    }
}
