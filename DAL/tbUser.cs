using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace Xmf.SHMYSYS.DAL
{
    /// <summary>
    /// 数据访问类:tbUser
    /// </summary>
    public partial class tbUser
    {
        public tbUser()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string GUID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbUser");
            strSql.Append(" where [GUID]=@GUID ");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@GUID", OleDbType.VarChar,255)          };
            parameters[0].Value = GUID;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Xmf.SHMYSYS.Model.tbUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbUser(");
            strSql.Append("[GUID],[PASSWORD],[ROLE],[ADDTIME],[ISUSE],[EMAIL],[SUPERIOR])");
            strSql.Append(" values (");
            strSql.Append("@GUID,@PASSWORD,@ROLE,@ADDTIME,@ISUSE,@EMAIL,@SUPERIOR)");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@GUID", OleDbType.VarChar,255),
                    new OleDbParameter("@PASSWORD", OleDbType.VarChar,255),
                    new OleDbParameter("@ROLE", OleDbType.VarChar,255),
                    new OleDbParameter("@ADDTIME", OleDbType.Date),
                    new OleDbParameter("@ISUSE", OleDbType.Integer,4),
                    new OleDbParameter("@EMAIL", OleDbType.VarChar,255),
                    new OleDbParameter("@SUPERIOR", OleDbType.VarChar,255)};
            parameters[0].Value = model.GUID;
            parameters[1].Value = model.PASSWORD;
            parameters[2].Value = model.ROLE;
            parameters[3].Value = model.ADDTIME;
            parameters[4].Value = model.ISUSE;
            parameters[5].Value = model.EMAIL;
            parameters[6].Value = model.SUPERIOR;
            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Xmf.SHMYSYS.Model.tbUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbUser set ");
            strSql.Append("[PASSWORD]=@PASSWORD,");
            strSql.Append("[ROLE]=@ROLE,");
            strSql.Append("[ADDTIME]=@ADDTIME,");
            strSql.Append("[EMAIL]=@EMAIL,");
            strSql.Append("[ISUSE]=@ISUSE,");
            strSql.Append("[SUPERIOR]=@SUPERIOR");
            strSql.Append(" where [GUID]=@GUID ");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@PASSWORD", OleDbType.VarChar,255),
                    new OleDbParameter("@ROLE", OleDbType.VarChar,255),
                    new OleDbParameter("@ADDTIME", OleDbType.Date),
                    new OleDbParameter("@EMAIL", OleDbType.VarChar,255),
                    new OleDbParameter("@ISUSE", OleDbType.Integer,4),
                    new OleDbParameter("@SUPERIOR", OleDbType.VarChar,255),
                    new OleDbParameter("@GUID", OleDbType.VarChar,255)};
            parameters[0].Value = model.PASSWORD;
            parameters[1].Value = model.ROLE;
            parameters[2].Value = model.ADDTIME;
            parameters[3].Value = model.EMAIL;
            parameters[4].Value = model.ISUSE;
            parameters[5].Value = model.SUPERIOR;
            parameters[6].Value = model.GUID;

            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string GUID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbUser ");
            strSql.Append(" where [GUID]=@GUID ");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@GUID", OleDbType.VarChar,255)          };
            parameters[0].Value = GUID;

            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string GUIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbUser ");
            strSql.Append(" where [GUID] in (" + GUIDlist + ")  ");
            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Xmf.SHMYSYS.Model.tbUser GetModel(string GUID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [GUID],USERNAME,NICKNAME,AVATAR,PASSWORD,ROLE,ADDTIME,ISUSE,SEX,PHONE,EMAIL,ADDRESS,SUPERIOR from tbUser ");
            strSql.Append(" where [GUID]=@GUID ");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@GUID", OleDbType.VarChar,255)          };
            parameters[0].Value = GUID;

            Xmf.SHMYSYS.Model.tbUser model = new Xmf.SHMYSYS.Model.tbUser();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Xmf.SHMYSYS.Model.tbUser DataRowToModel(DataRow row)
        {
            Xmf.SHMYSYS.Model.tbUser model = new Xmf.SHMYSYS.Model.tbUser();
            if (row != null)
            {
                if (row["GUID"] != null)
                {
                    model.GUID = row["GUID"].ToString();
                }
                if (row["USERNAME"] != null)
                {
                    model.USERNAME = row["USERNAME"].ToString();
                }
                if (row["NICKNAME"] != null)
                {
                    model.NICKNAME = row["NICKNAME"].ToString();
                }
                if (row["AVATAR"] != null)
                {
                    model.AVATAR = row["AVATAR"].ToString();
                }
                if (row["PASSWORD"] != null)
                {
                    model.PASSWORD = row["PASSWORD"].ToString();
                }
                if (row["ROLE"] != null)
                {
                    model.ROLE = row["ROLE"].ToString();
                }
                if (row["ADDTIME"] != null && row["ADDTIME"].ToString() != "")
                {
                    model.ADDTIME = DateTime.Parse(row["ADDTIME"].ToString());
                }
                if (row["ISUSE"] != null && row["ISUSE"].ToString() != "")
                {
                    model.ISUSE = int.Parse(row["ISUSE"].ToString());
                }
                if (!string.IsNullOrEmpty(row["SEX"].ToString()))
                {
                    model.SEX = Convert.ToInt32(row["SEX"]);
                }
                if (row["PHONE"] != null)
                {
                    model.PHONE = row["PHONE"].ToString();
                }
                if (row["EMAIL"] != null)
                {
                    model.EMAIL = row["EMAIL"].ToString();
                }
                if (row["ADDRESS"] != null)
                {
                    model.ADDRESS = row["ADDRESS"].ToString();
                }
                if (row["SUPERIOR"] != null)
                {
                    model.SUPERIOR = row["SUPERIOR"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [GUID],USERNAME,NICKNAME,AVATAR,PASSWORD,ROLE,ADDTIME,ISUSE,SEX,PHONE,EMAIL,ADDRESS,SUPERIOR ");
            strSql.Append(" FROM tbUser ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tbUser ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.[GUID] desc");
            }
            strSql.Append(")AS Row, T.*  from tbUser T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOleDb.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			OleDbParameter[] parameters = {
					new OleDbParameter("@tblName", OleDbType.VarChar, 255),
					new OleDbParameter("@fldName", OleDbType.VarChar, 255),
					new OleDbParameter("@PageSize", OleDbType.Integer),
					new OleDbParameter("@PageIndex", OleDbType.Integer),
					new OleDbParameter("@IsReCount", OleDbType.Boolean),
					new OleDbParameter("@OrderType", OleDbType.Boolean),
					new OleDbParameter("@strWhere", OleDbType.VarChar,1000),
					};
			parameters[0].Value = "tbUser";
			parameters[1].Value = "GUID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOleDb.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

