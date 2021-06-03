using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace Xmf.SHMYSYS.DAL
{
	/// <summary>
	/// 数据访问类:tbGiftTemp
	/// </summary>
	public partial class tbGiftTemp
	{
		public tbGiftTemp()
		{ }
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string GUID, string USERGUID, string GIFTGUID, int APPLYNUM, string APPLYNAME, DateTime APPLYDATE, int ISUSE)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from tbGiftTemp");
			strSql.Append(" where GUID=@GUID and USERGUID=@USERGUID and GIFTGUID=@GIFTGUID and APPLYNUM=@APPLYNUM and APPLYNAME=@APPLYNAME and APPLYDATE=@APPLYDATE and ISUSE=@ISUSE ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@GUID", OleDbType.VarChar,255),
					new OleDbParameter("@USERGUID", OleDbType.VarChar,255),
					new OleDbParameter("@GIFTGUID", OleDbType.VarChar,255),
					new OleDbParameter("@APPLYNUM", OleDbType.Integer,4),
					new OleDbParameter("@APPLYNAME", OleDbType.VarChar,255),
					new OleDbParameter("@APPLYDATE", OleDbType.Date),
					new OleDbParameter("@ISUSE", OleDbType.Integer,4)           };
			parameters[0].Value = GUID;
			parameters[1].Value = USERGUID;
			parameters[2].Value = GIFTGUID;
			parameters[3].Value = APPLYNUM;
			parameters[4].Value = APPLYNAME;
			parameters[5].Value = APPLYDATE;
			parameters[6].Value = ISUSE;

			return DbHelperOleDb.Exists(strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Xmf.SHMYSYS.Model.tbGiftTemp model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into tbGiftTemp(");
			strSql.Append("[GUID],[USERGUID],[GIFTGUID],[APPLYNUM],[APPLYNAME],[APPLYDATE],[ISUSE],[GIFTNAME],[IMAGE],[DETAIL])");
			strSql.Append(" values (");
			strSql.Append("@GUID,@USERGUID,@GIFTGUID,@APPLYNUM,@APPLYNAME,@APPLYDATE,@ISUSE,@GIFTNAME,@IMAGE,@DETAIL)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@GUID", OleDbType.VarChar,255),
					new OleDbParameter("@USERGUID", OleDbType.VarChar,255),
					new OleDbParameter("@GIFTGUID", OleDbType.VarChar,255),
					new OleDbParameter("@APPLYNUM", OleDbType.Integer,4),
					new OleDbParameter("@APPLYNAME", OleDbType.VarChar,255),
					new OleDbParameter("@APPLYDATE", OleDbType.Date),
					new OleDbParameter("@ISUSE", OleDbType.Integer,4),
					new OleDbParameter("@GIFTNAME", OleDbType.VarChar,255),
					new OleDbParameter("@IMAGE", OleDbType.VarChar,255),
					new OleDbParameter("@DETAIL", OleDbType.VarChar,255)};
			parameters[0].Value = model.GUID;
			parameters[1].Value = model.USERGUID;
			parameters[2].Value = model.GIFTGUID;
			parameters[3].Value = model.APPLYNUM;
			parameters[4].Value = model.APPLYNAME;
			parameters[5].Value = model.APPLYDATE;
			parameters[6].Value = model.ISUSE;
			parameters[7].Value = model.GIFTNAME;
			parameters[8].Value = model.IMAGE;
			parameters[9].Value = model.DETAIL;

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
		public bool Update(Xmf.SHMYSYS.Model.tbGiftTemp model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update tbGiftTemp set ");
			strSql.Append("[USERGUID]=@USERGUID,");
			strSql.Append("[GIFTGUID]=@GIFTGUID,");
			strSql.Append("[APPLYNUM]=@APPLYNUM,");
			strSql.Append("[APPLYNAME]=@APPLYNAME,");
			strSql.Append("[APPLYDATE]=@APPLYDATE,");
			strSql.Append("[ISUSE]=@ISUSE");
			strSql.Append(" where GUID=@GUID and ISUSE=@ISUSE ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@USERGUID", OleDbType.VarChar,255),
					new OleDbParameter("@GIFTGUID", OleDbType.VarChar,255),
					new OleDbParameter("@APPLYNUM", OleDbType.Integer,4),
					new OleDbParameter("@APPLYNAME", OleDbType.VarChar,255),
					new OleDbParameter("@APPLYDATE", OleDbType.Date),
					new OleDbParameter("@ISUSE", OleDbType.Integer,4),
					new OleDbParameter("@GUID", OleDbType.VarChar,255)};
			parameters[0].Value = model.USERGUID;
			parameters[1].Value = model.GIFTGUID;
			parameters[2].Value = model.APPLYNUM;
			parameters[3].Value = model.APPLYNAME;
			parameters[4].Value = model.APPLYDATE;
			parameters[5].Value = model.ISUSE;
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
			strSql.Append("delete from tbGiftTemp ");
			strSql.Append(" where GUID=@GUID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@GUID", OleDbType.VarChar,255)      };
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
		/// 得到一个对象实体
		/// </summary>
		public Xmf.SHMYSYS.Model.tbGiftTemp GetModel(string GUID, string USERGUID, string GIFTGUID, int APPLYNUM, string APPLYNAME, DateTime APPLYDATE, int ISUSE)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select GUID,USERGUID,GIFTGUID,APPLYNUM,APPLYNAME,APPLYDATE,ISUSE from tbGiftTemp ");
			strSql.Append(" where GUID=@GUID and USERGUID=@USERGUID and GIFTGUID=@GIFTGUID and APPLYNUM=@APPLYNUM and APPLYNAME=@APPLYNAME and APPLYDATE=@APPLYDATE and ISUSE=@ISUSE ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@GUID", OleDbType.VarChar,255),
					new OleDbParameter("@USERGUID", OleDbType.VarChar,255),
					new OleDbParameter("@GIFTGUID", OleDbType.VarChar,255),
					new OleDbParameter("@APPLYNUM", OleDbType.Integer,4),
					new OleDbParameter("@APPLYNAME", OleDbType.VarChar,255),
					new OleDbParameter("@APPLYDATE", OleDbType.Date),
					new OleDbParameter("@ISUSE", OleDbType.Integer,4)           };
			parameters[0].Value = GUID;
			parameters[1].Value = USERGUID;
			parameters[2].Value = GIFTGUID;
			parameters[3].Value = APPLYNUM;
			parameters[4].Value = APPLYNAME;
			parameters[5].Value = APPLYDATE;
			parameters[6].Value = ISUSE;

			Xmf.SHMYSYS.Model.tbGiftTemp model = new Xmf.SHMYSYS.Model.tbGiftTemp();
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
		public Xmf.SHMYSYS.Model.tbGiftTemp DataRowToModel(DataRow row)
		{
			Xmf.SHMYSYS.Model.tbGiftTemp model = new Xmf.SHMYSYS.Model.tbGiftTemp();
			if (row != null)
			{
				if (row["GUID"] != null)
				{
					model.GUID = row["GUID"].ToString();
				}
				if (row["USERGUID"] != null)
				{
					model.USERGUID = row["USERGUID"].ToString();
				}
				if (row["GIFTNAME"] != null)
				{
					model.GIFTNAME = row["GIFTNAME"].ToString();
				}
				if (row["IMAGE"] != null)
				{
					model.IMAGE = row["IMAGE"].ToString();
				}
				if (row["DETAIL"] != null)
				{
					model.DETAIL = row["DETAIL"].ToString();
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
				if (row["APPLYDATE"] != null && row["APPLYDATE"].ToString() != "")
				{
					model.APPLYDATE = DateTime.Parse(row["APPLYDATE"].ToString());
				}
				if (row["ISUSE"] != null && row["ISUSE"].ToString() != "")
				{
					model.ISUSE = int.Parse(row["ISUSE"].ToString());
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
			strSql.Append("select GUID,GIFTNAME,IMAGE,DETAIL,USERGUID,GIFTGUID,APPLYNUM,APPLYNAME,APPLYDATE,ISUSE ");
			strSql.Append(" FROM tbGiftTemp ");
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
			strSql.Append("select count(1) FROM tbGiftTemp ");
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
				strSql.Append("order by T.ISUSE desc");
			}
			strSql.Append(")AS Row, T.*  from tbGiftTemp T ");
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
			parameters[0].Value = "tbGiftTemp";
			parameters[1].Value = "ISUSE";
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

