using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace Xmf.SHMYSYS.DAL
{
    /// <summary>
    /// 数据访问类:tbApply
    /// </summary>
    public partial class tbApply
    {
        public tbApply()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string GUID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbApply");
            strSql.Append(" where GUID=@GUID ");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@GUID", OleDbType.VarChar,255)          };
            parameters[0].Value = GUID;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Xmf.SHMYSYS.Model.tbApply model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbApply(");
            strSql.Append("[GUID],[GIFTGUID],[APPLYNUM],[APPLYNAME],[APPLYSTATE],[APPLYDATE],[ISUSE],[REMARK],[GIFTNAME],[IMAGE],[DETAIL])");
            strSql.Append(" values (");
            strSql.Append("@GUID,@GIFTGUID,@APPLYNUM,@APPLYNAME,@APPLYSTATE,@APPLYDATE,@ISUSE,@REMARK,@GIFTNAME,@IMAGE,@DETAIL)");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@GUID", OleDbType.VarChar,255),
                    new OleDbParameter("@GIFTGUID", OleDbType.VarChar,255),
                    new OleDbParameter("@APPLYNUM", OleDbType.Integer,4),
                    new OleDbParameter("@APPLYNAME", OleDbType.VarChar,255),
                    new OleDbParameter("@APPLYSTATE", OleDbType.Integer,4),
                    new OleDbParameter("@APPLYDATE", OleDbType.Date),
                    new OleDbParameter("@ISUSE", OleDbType.Integer,4),
                    new OleDbParameter("@REMARK", OleDbType.VarChar,255),
                    new OleDbParameter("@GIFTNAME", OleDbType.VarChar,255),
                    new OleDbParameter("@IMAGE", OleDbType.VarChar,255),
                    new OleDbParameter("@DETAIL", OleDbType.VarChar,255)};
            parameters[0].Value = model.GUID;
            parameters[1].Value = model.GIFTGUID;
            parameters[2].Value = model.APPLYNUM;
            parameters[3].Value = model.APPLYNAME;
            parameters[4].Value = model.APPLYSTATE;
            parameters[5].Value = model.APPLYDATE;
            //parameters[6].Value = model.AUDITDATE;
            //parameters[7].Value = model.RELEASEDATE;
            parameters[6].Value = model.ISUSE;
            parameters[7].Value = model.REMARK;
            parameters[8].Value = model.GIFTNAME;
            parameters[9].Value = model.IMAGE;
            parameters[10].Value = model.DETAIL;
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
        public bool Update(Xmf.SHMYSYS.Model.tbApply model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbApply set ");
            strSql.Append("GIFTGUID=@GIFTGUID,");
            strSql.Append("APPLYNUM=@APPLYNUM,");
            strSql.Append("APPLYNAME=@APPLYNAME,");
            strSql.Append("APPLYSTATE=@APPLYSTATE,");
            strSql.Append("APPLYDATE=@APPLYDATE,");
            //strSql.Append("AUDITDATE=@AUDITDATE,");
            //strSql.Append("RELEASEDATE=@RELEASEDATE,");
            strSql.Append("ISUSE=@ISUSE,");
            strSql.Append("REMARK=@REMARK");
            strSql.Append(" where GUID=@GUID ");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@GIFTGUID", OleDbType.VarChar,255),
                    new OleDbParameter("@APPLYNUM", OleDbType.Integer,4),
                    new OleDbParameter("@APPLYNAME", OleDbType.VarChar,255),
                    new OleDbParameter("@APPLYSTATE", OleDbType.Integer,4),
                    new OleDbParameter("@APPLYDATE", OleDbType.Date),
					//new OleDbParameter("@AUDITDATE", OleDbType.Date),
					//new OleDbParameter("@RELEASEDATE", OleDbType.Date),
					new OleDbParameter("@ISUSE", OleDbType.Integer,4),
                    new OleDbParameter("@REMARK", OleDbType.VarChar,255),
                    new OleDbParameter("@GUID", OleDbType.VarChar,255)};
            parameters[0].Value = model.GIFTGUID;
            parameters[1].Value = model.APPLYNUM;
            parameters[2].Value = model.APPLYNAME;
            parameters[3].Value = model.APPLYSTATE;
            parameters[4].Value = model.APPLYDATE;
            //parameters[5].Value = model.AUDITDATE;
            //parameters[6].Value = model.RELEASEDATE;
            parameters[5].Value = model.ISUSE;
            parameters[6].Value = model.REMARK;
            parameters[7].Value = model.GUID;

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
        /// 更新审核数据
        /// </summary>
        public bool AUDITUpdate(Xmf.SHMYSYS.Model.tbApply model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbApply set ");
            strSql.Append("GIFTGUID=@GIFTGUID,");
            strSql.Append("APPLYNUM=@APPLYNUM,");
            strSql.Append("APPLYNAME=@APPLYNAME,");
            strSql.Append("APPLYSTATE=@APPLYSTATE,");
            strSql.Append("APPLYDATE=@APPLYDATE,");
            strSql.Append("AUDITDATE=@AUDITDATE,");
            strSql.Append("AUDITNAME=@AUDITNAME,");
            //strSql.Append("RELEASEDATE=@RELEASEDATE,");
            strSql.Append("ISUSE=@ISUSE");
            strSql.Append(" where GUID=@GUID ");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@GIFTGUID", OleDbType.VarChar,255),
                    new OleDbParameter("@APPLYNUM", OleDbType.Integer,4),
                    new OleDbParameter("@APPLYNAME", OleDbType.VarChar,255),
                    new OleDbParameter("@APPLYSTATE", OleDbType.Integer,4),
                    new OleDbParameter("@APPLYDATE", OleDbType.Date),
                    new OleDbParameter("@AUDITDATE", OleDbType.Date),
                     new OleDbParameter("@AUDITNAME", OleDbType.VarChar,255),
					//new OleDbParameter("@RELEASEDATE", OleDbType.Date),
					new OleDbParameter("@ISUSE", OleDbType.Integer,4),
                    new OleDbParameter("@GUID", OleDbType.VarChar,255)};
            parameters[0].Value = model.GIFTGUID;
            parameters[1].Value = model.APPLYNUM;
            parameters[2].Value = model.APPLYNAME;
            parameters[3].Value = model.APPLYSTATE;
            parameters[4].Value = model.APPLYDATE;
            parameters[5].Value = model.AUDITDATE;
            parameters[6].Value = model.AUDITNAME;
            //parameters[6].Value = model.RELEASEDATE;
            parameters[7].Value = model.ISUSE;
            parameters[8].Value = model.GUID;

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

        public bool RELEASEUpdate(Xmf.SHMYSYS.Model.tbApply model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbApply set ");
            strSql.Append("GIFTGUID=@GIFTGUID,");
            strSql.Append("APPLYNUM=@APPLYNUM,");
            strSql.Append("APPLYNAME=@APPLYNAME,");
            strSql.Append("APPLYSTATE=@APPLYSTATE,");
            strSql.Append("APPLYDATE=@APPLYDATE,");
            strSql.Append("RELEASEDATE=@RELEASEDATE,");
            strSql.Append("RELEASENAME=@RELEASENAME,");
            strSql.Append("ISUSE=@ISUSE");
            strSql.Append(" where GUID=@GUID ");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@GIFTGUID", OleDbType.VarChar,255),
                    new OleDbParameter("@APPLYNUM", OleDbType.Integer,4),
                    new OleDbParameter("@APPLYNAME", OleDbType.VarChar,255),
                    new OleDbParameter("@APPLYSTATE", OleDbType.Integer,4),
                    new OleDbParameter("@APPLYDATE", OleDbType.Date),
					//new OleDbParameter("@AUDITDATE", OleDbType.Date),
					new OleDbParameter("@RELEASEDATE", OleDbType.Date),
                                        new OleDbParameter("@RELEASENAME", OleDbType.VarChar,255),
                    new OleDbParameter("@ISUSE", OleDbType.Integer,4),
                    new OleDbParameter("@GUID", OleDbType.VarChar,255)};
            parameters[0].Value = model.GIFTGUID;
            parameters[1].Value = model.APPLYNUM;
            parameters[2].Value = model.APPLYNAME;
            parameters[3].Value = model.APPLYSTATE;
            parameters[4].Value = model.APPLYDATE;
            //parameters[5].Value = model.AUDITDATE;
            parameters[5].Value = model.RELEASEDATE;
            parameters[6].Value = model.RELEASENAME;
            parameters[7].Value = model.ISUSE;
            parameters[8].Value = model.GUID;

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
            strSql.Append("delete from tbApply ");
            strSql.Append(" where GUID=@GUID ");
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
            strSql.Append("delete from tbApply ");
            strSql.Append(" where GUID in (" + GUIDlist + ")  ");
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
        public Xmf.SHMYSYS.Model.tbApply GetModel(string GUID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select GUID,GIFTGUID,APPLYNUM,APPLYNAME,APPLYSTATE,APPLYDATE,AUDITDATE,RELEASEDATE,ISUSE,REMARK from tbApply ");
            strSql.Append(" where GUID=@GUID ");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@GUID", OleDbType.VarChar,255)          };
            parameters[0].Value = GUID;

            Xmf.SHMYSYS.Model.tbApply model = new Xmf.SHMYSYS.Model.tbApply();
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
        public Xmf.SHMYSYS.Model.tbApply DataRowToModel(DataRow row)
        {
            Xmf.SHMYSYS.Model.tbApply model = new Xmf.SHMYSYS.Model.tbApply();
            if (row != null)
            {
                if (row["GUID"] != null)
                {
                    model.GUID = row["GUID"].ToString();
                }
                if (row["GIFTGUID"] != null)
                {
                    model.GIFTGUID = row["GIFTGUID"].ToString();
                }
                if (row["APPLYNUM"] != null && row["APPLYNUM"].ToString() != "")
                {
                    model.APPLYNUM = int.Parse(row["APPLYNUM"].ToString());
                }
                if (row["APPLYNAME"] != null)
                {
                    model.APPLYNAME = row["APPLYNAME"].ToString();
                }
                if (row["APPLYSTATE"] != null && row["APPLYSTATE"].ToString() != "")
                {
                    model.APPLYSTATE = int.Parse(row["APPLYSTATE"].ToString());
                }
                if (row["APPLYDATE"] != null && row["APPLYDATE"].ToString() != "")
                {
                    model.APPLYDATE = DateTime.Parse(row["APPLYDATE"].ToString());
                }
                if (row["AUDITDATE"] != null && row["AUDITDATE"].ToString() != "")
                {
                    model.AUDITDATE = DateTime.Parse(row["AUDITDATE"].ToString());
                }
                if (row["RELEASEDATE"] != null && row["RELEASEDATE"].ToString() != "")
                {
                    model.RELEASEDATE = DateTime.Parse(row["RELEASEDATE"].ToString());
                }
                if (row["ISUSE"] != null && row["ISUSE"].ToString() != "")
                {
                    model.ISUSE = int.Parse(row["ISUSE"].ToString());
                }
                if (row["REMARK"] != null && row["REMARK"].ToString() != "")
                {
                    model.REMARK = row["REMARK"].ToString();
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
            strSql.Append("select GUID,GIFTGUID,APPLYNUM,APPLYNAME,APPLYSTATE,APPLYDATE,AUDITDATE,RELEASEDATE,ISUSE,AUDITNAME,RELEASENAME,REMARK,GIFTNAME,IMAGE,DETAIL ");
            strSql.Append(" FROM tbApply ");
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
            strSql.Append("select count(1) FROM tbApply ");
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
                strSql.Append("order by T.GUID desc");
            }
            strSql.Append(")AS Row, T.*  from tbApply T ");
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
			parameters[0].Value = "tbApply";
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

