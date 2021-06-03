using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace Xmf.SHMYSYS.DAL
{
	/// <summary>
	/// 数据访问类:tbRole
	/// </summary>
	public partial class tbRole
	{
		public tbRole()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string GUID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tbRole");
			strSql.Append(" where GUID=@GUID ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@GUID", OleDbType.VarChar,255)			};
			parameters[0].Value = GUID;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Xmf.SHMYSYS.Model.tbRole model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbRole(");
			strSql.Append("GUID,ROLENAME,ISUSE)");
			strSql.Append(" values (");
			strSql.Append("@GUID,@ROLENAME,@ISUSE)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@GUID", OleDbType.VarChar,255),
					new OleDbParameter("@ROLENAME", OleDbType.VarChar,255),
					new OleDbParameter("@ISUSE", OleDbType.Integer,4)};
			parameters[0].Value = model.GUID;
			parameters[1].Value = model.ROLENAME;
			parameters[2].Value = model.ISUSE;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(Xmf.SHMYSYS.Model.tbRole model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbRole set ");
			strSql.Append("ROLENAME=@ROLENAME,");
			strSql.Append("ISUSE=@ISUSE");
			strSql.Append(" where GUID=@GUID ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ROLENAME", OleDbType.VarChar,255),
					new OleDbParameter("@ISUSE", OleDbType.Integer,4),
					new OleDbParameter("@GUID", OleDbType.VarChar,255)};
			parameters[0].Value = model.ROLENAME;
			parameters[1].Value = model.ISUSE;
			parameters[2].Value = model.GUID;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbRole ");
			strSql.Append(" where GUID=@GUID ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@GUID", OleDbType.VarChar,255)			};
			parameters[0].Value = GUID;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string GUIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbRole ");
			strSql.Append(" where GUID in ("+GUIDlist + ")  ");
			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString());
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
		public Xmf.SHMYSYS.Model.tbRole GetModel(string GUID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select GUID,ROLENAME,ISUSE from tbRole ");
			strSql.Append(" where GUID=@GUID ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@GUID", OleDbType.VarChar,255)			};
			parameters[0].Value = GUID;

			Xmf.SHMYSYS.Model.tbRole model=new Xmf.SHMYSYS.Model.tbRole();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public Xmf.SHMYSYS.Model.tbRole DataRowToModel(DataRow row)
		{
			Xmf.SHMYSYS.Model.tbRole model=new Xmf.SHMYSYS.Model.tbRole();
			if (row != null)
			{
				if(row["GUID"]!=null)
				{
					model.GUID=row["GUID"].ToString();
				}
				if(row["ROLENAME"]!=null)
				{
					model.ROLENAME=row["ROLENAME"].ToString();
				}
				if(row["ISUSE"]!=null && row["ISUSE"].ToString()!="")
				{
					model.ISUSE=int.Parse(row["ISUSE"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select GUID,ROLENAME,ISUSE ");
			strSql.Append(" FROM tbRole ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tbRole ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.GUID desc");
			}
			strSql.Append(")AS Row, T.*  from tbRole T ");
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
			parameters[0].Value = "tbRole";
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

