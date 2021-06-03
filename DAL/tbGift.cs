using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace Xmf.SHMYSYS.DAL
{
	/// <summary>
	/// 数据访问类:tbGift
	/// </summary>
	public partial class tbGift
	{
		public tbGift()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string GUID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tbGift");
			strSql.Append(" where GUID=@GUID ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@GUID", OleDbType.VarChar,255)			};
			parameters[0].Value = GUID;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Xmf.SHMYSYS.Model.tbGift model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbGift(");
			strSql.Append("[GUID],[GIFTNAME],[IMAGE],[NUMBER],[DETAIL],[ADDTIME],[ISUSE])");
			strSql.Append(" values (");
            strSql.Append("@GUID,@GIFTNAME,@IMAGE,@NUMBER,@DETAIL,@ADDTIME,@ISUSE)");
            //strSql.Append(string.Format("'{0}','{1}','{2}','{3}','{4}','{5}','{6}')", model.GUID, model.GIFTNAME, model.IMAGE, model.NUMBER, model.DETAIL, model.ADDTIME, model.ISUSE));
            OleDbParameter[] parameters = {
                    new OleDbParameter("@GUID", OleDbType.VarChar,255),
                    new OleDbParameter("@GIFTNAME", OleDbType.VarChar,255),
                    new OleDbParameter("@IMAGE", OleDbType.VarChar,255),
                    new OleDbParameter("@NUMBER", OleDbType.Integer,4),
                    new OleDbParameter("@DETAIL", OleDbType.VarChar,255),
                    new OleDbParameter("@ADDTIME", OleDbType.Date),
                    new OleDbParameter("@ISUSE", OleDbType.Integer,4)};
            parameters[0].Value = model.GUID;
            parameters[1].Value = model.GIFTNAME;
            parameters[2].Value = model.IMAGE;
            parameters[3].Value = model.NUMBER;
            parameters[4].Value = model.DETAIL;
            parameters[5].Value = model.ADDTIME;
            parameters[6].Value = model.ISUSE;

            int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
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
		public bool Update(Xmf.SHMYSYS.Model.tbGift model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbGift set ");
			strSql.Append("[GIFTNAME]=@GIFTNAME,");
			strSql.Append("[IMAGE]=@IMAGE,");
			strSql.Append("[NUMBER]=@NUMBER,");
			strSql.Append("[DETAIL]=@DETAIL,");
			strSql.Append("[ADDTIME]=@ADDTIME,");
			strSql.Append("[ISUSE]=@ISUSE");
			strSql.Append(" where [GUID]=@GUID ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@GIFTNAME", OleDbType.VarChar,255),
					new OleDbParameter("@IMAGE", OleDbType.VarChar,255),
					new OleDbParameter("@NUMBER", OleDbType.Integer,4),
					new OleDbParameter("@DETAIL", OleDbType.VarChar,255),
					new OleDbParameter("@ADDTIME", OleDbType.Date),
					new OleDbParameter("@ISUSE", OleDbType.Integer,4),
					new OleDbParameter("@GUID", OleDbType.VarChar,255)};
			parameters[0].Value = model.GIFTNAME;
			parameters[1].Value = model.IMAGE;
			parameters[2].Value = model.NUMBER;
			parameters[3].Value = model.DETAIL;
			parameters[4].Value = model.ADDTIME;
			parameters[5].Value = model.ISUSE;
			parameters[6].Value = model.GUID;

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
			strSql.Append("delete from tbGift ");
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
			strSql.Append("delete from tbGift ");
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
		public Xmf.SHMYSYS.Model.tbGift GetModel(string GUID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select [GUID],GIFTNAME,IMAGE,[NUMBER],DETAIL,ADDTIME,ISUSE from tbGift ");
			strSql.Append(" where [GUID]=@GUID ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@GUID", OleDbType.VarChar,255)			};
			parameters[0].Value = GUID;

			Xmf.SHMYSYS.Model.tbGift model=new Xmf.SHMYSYS.Model.tbGift();
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
		public Xmf.SHMYSYS.Model.tbGift DataRowToModel(DataRow row)
		{
			Xmf.SHMYSYS.Model.tbGift model=new Xmf.SHMYSYS.Model.tbGift();
			if (row != null)
			{
				if(row["GUID"]!=null)
				{
					model.GUID=row["GUID"].ToString();
				}
				if(row["GIFTNAME"]!=null)
				{
					model.GIFTNAME=row["GIFTNAME"].ToString();
				}
				if(row["IMAGE"]!=null)
				{
					model.IMAGE=row["IMAGE"].ToString();
				}
				if(row["NUMBER"]!=null && row["NUMBER"].ToString()!="")
				{
					model.NUMBER=int.Parse(row["NUMBER"].ToString());
				}
				if(row["DETAIL"]!=null)
				{
					model.DETAIL=row["DETAIL"].ToString();
				}
				if(row["ADDTIME"]!=null && row["ADDTIME"].ToString()!="")
				{
					model.ADDTIME=DateTime.Parse(row["ADDTIME"].ToString());
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
			strSql.Append("select GUID,GIFTNAME,IMAGE,NUMBER,DETAIL,ADDTIME,ISUSE ");
			strSql.Append(" FROM tbGift ");
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
			strSql.Append("select count(1) FROM tbGift ");
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
			strSql.Append(")AS Row, T.*  from tbGift T ");
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
			parameters[0].Value = "tbGift";
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

