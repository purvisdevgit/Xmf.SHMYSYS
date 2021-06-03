using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.Model;
using Maticsoft.DBUtility;
using Xmf.SHMYSYS.Model;
using System.Data.OleDb;

namespace Maticsoft.DAL
{
    /// <summary>
    /// 用参数方式实现数据层示例。
    /// </summary>
    public class SysManage //这里必须实现接口，否则工厂类创建接口报错
    {
        public SysManage()
        {
        }

        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("NodeID", "S_Tree");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int NodeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from S_Tree where NodeID=@NodeID");

            SqlParameter[] parameters = {
                                            new SqlParameter("@NodeID", SqlDbType.Int,4)
                                        };
            parameters[0].Value = NodeID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);

        }

        public int AddTreeNode(SysNode model)
        {
            model.NodeID = GetMaxId();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into S_Tree(");
            strSql.Append("NodeID,Text,ParentID,Location,OrderID,comment,Url,PermissionID,ImageUrl)");
            strSql.Append(" values (");
            strSql.Append("@NodeID,@Text,@ParentID,@Location,@OrderID,@comment,@Url,@PermissionID,@ImageUrl)");

            //
            SqlParameter[] parameters = {
                                            new SqlParameter("@NodeID", SqlDbType.Int,4),
                                            new SqlParameter("@Text", SqlDbType.VarChar,100),
                                            new SqlParameter("@ParentID", SqlDbType.Int,4),
                                            new SqlParameter("@Location", SqlDbType.VarChar,50),
                                            new SqlParameter("@OrderID", SqlDbType.Int,4),
                                            new SqlParameter("@comment", SqlDbType.VarChar,50),
                                            new SqlParameter("@Url", SqlDbType.VarChar,100),
                                            new SqlParameter("@PermissionID", SqlDbType.Int,4),
                                            new SqlParameter("@ImageUrl", SqlDbType.VarChar,100)};
            parameters[0].Value = model.NodeID;
            parameters[1].Value = model.Text;
            parameters[2].Value = model.ParentID;
            parameters[3].Value = model.Location;
            parameters[4].Value = model.OrderID;
            parameters[5].Value = model.Comment;
            parameters[6].Value = model.Url;
            parameters[7].Value = model.PermissionID;
            parameters[8].Value = model.ImageUrl;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return model.NodeID;
        }


        public void UpdateNode(SysNode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update S_Tree set ");
            strSql.Append("Text=@Text,");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("Location=@Location,");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("comment=@comment,");
            strSql.Append("Url=@Url,");
            strSql.Append("PermissionID=@PermissionID,");
            strSql.Append("ImageUrl=@ImageUrl");
            strSql.Append(" where NodeID=@NodeID");

            SqlParameter[] parameters = {
                                            new SqlParameter("@NodeID", SqlDbType.Int,4),
                                            new SqlParameter("@Text", SqlDbType.VarChar,100),
                                            new SqlParameter("@ParentID", SqlDbType.Int,4),
                                            new SqlParameter("@Location", SqlDbType.VarChar,50),
                                            new SqlParameter("@OrderID", SqlDbType.Int,4),
                                            new SqlParameter("@comment", SqlDbType.VarChar,50),
                                            new SqlParameter("@Url", SqlDbType.VarChar,100),
                                            new SqlParameter("@PermissionID", SqlDbType.Int,4),
                                            new SqlParameter("@ImageUrl", SqlDbType.VarChar,100)};
            parameters[0].Value = model.NodeID;
            parameters[1].Value = model.Text;
            parameters[2].Value = model.ParentID;
            parameters[3].Value = model.Location;
            parameters[4].Value = model.OrderID;
            parameters[5].Value = model.Comment;
            parameters[6].Value = model.Url;
            parameters[7].Value = model.PermissionID;
            parameters[8].Value = model.ImageUrl;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }

        public void DelTreeNode(int NodeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete S_Tree ");
            strSql.Append(" where NodeID=@NodeID");

            SqlParameter[] parameters = {
                                            new SqlParameter("@NodeID", SqlDbType.Int,4)
                                        };
            parameters[0].Value = NodeID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        public DataSet GetTreeList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from S_Tree ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by parentid,orderid ");

            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 得到菜单节点
        /// </summary>
        /// <param name="NodeID"></param>
        /// <returns></returns>
        public SysNode GetNode(int NodeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from S_Tree ");
            strSql.Append(" where NodeID=@NodeID");

            SqlParameter[] parameters = {
                                            new SqlParameter("@NodeID", SqlDbType.Int,4)
                                        };
            parameters[0].Value = NodeID;

            SysNode node = new SysNode();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                node.NodeID = int.Parse(ds.Tables[0].Rows[0]["NodeID"].ToString());
                node.Text = ds.Tables[0].Rows[0]["text"].ToString();
                if (ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    node.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                node.Location = ds.Tables[0].Rows[0]["Location"].ToString();
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    node.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                node.Comment = ds.Tables[0].Rows[0]["comment"].ToString();
                node.Url = ds.Tables[0].Rows[0]["url"].ToString();
                if (ds.Tables[0].Rows[0]["PermissionID"].ToString() != "")
                {
                    node.PermissionID = int.Parse(ds.Tables[0].Rows[0]["PermissionID"].ToString());
                }
                node.ImageUrl = ds.Tables[0].Rows[0]["ImageUrl"].ToString();

                return node;
            }
            else
            {
                return null;
            }


        }

        public int GetPermissionCatalogID(int permissionID)
        {
            string sql = "select CategoryID from Accounts_Permissions where PermissionID=" + permissionID;
            object res = DbHelperSQL.GetSingle(sql);
            if (res == null)
            {
                return 0;
            }
            return (int)res;
        }

        #region 日志
        /// <summary>
        /// 增加日志
        /// </summary>
        /// <param name="time"></param>
        /// <param name="loginfo"></param>
        public void AddLog(string time, string loginfo, string Particular)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into S_Log(");
            strSql.Append("datetime,loginfo,Particular)");
            strSql.Append(" values (");
            strSql.Append("'" + time + "',");
            strSql.Append("'" + loginfo + "',");
            strSql.Append("'" + Particular + "'");
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public void DeleteLog(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete S_Log ");
            strSql.Append(" where ID= " + ID);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public void DelOverdueLog(int days)
        {
            string str = " DATEDIFF(day,[datetime],getdate())>" + days;
            DeleteLog(str);
        }
        public void DeleteLog(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete S_Log ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public DataSet GetLogs(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from S_Log ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID DESC");
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataRow GetLog(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from S_Log ");
            strSql.Append(" where ID= " + ID);
            return DbHelperSQL.Query(strSql.ToString()).Tables[0].Rows[0];
        }
        #endregion
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static tbUser GetUserInfo(string userName, string password)
        {
            OleDbDataReader odr = null ;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT * FROM `tbUser` ");
                strSql.Append(" WHERE EMAIL=@EMAIL");
                strSql.Append(" AND PASSWORD=@PASSWORD AND ISUSE=1");
                OleDbParameter[] parameters = {
                                            new OleDbParameter("@EMAIL", OleDbType.VarChar,200),
                                            new OleDbParameter("@PASSWORD", OleDbType.VarChar,200),
                                        };
                parameters[0].Value = userName;
                parameters[1].Value = password;
                //DbHelperOleDb.WriteLog(1+userName+ password);
                odr = DbHelperOleDb.ExecuteReader(strSql.ToString(), parameters);
                if (odr.Read())
                {
                    tbUser tbuser = new tbUser();
                    tbuser.USERNAME = odr["USERNAME"].ToString();
                    tbuser.NICKNAME = odr["NICKNAME"].ToString();
                    tbuser.AVATAR = odr["AVATAR"].ToString();
                    tbuser.PASSWORD = odr["PASSWORD"].ToString();
                    tbuser.GUID = odr["GUID"].ToString();
                    int TMPI = 0;
                    if (int.TryParse(odr["ISUSE"].ToString(), out TMPI))
                    {
                        tbuser.ISUSE = TMPI;
                    }
                    DateTime ADDTIME = new DateTime();
                    if (DateTime.TryParse(odr["ADDTIME"].ToString(), out ADDTIME))
                    {
                        tbuser.ADDTIME = ADDTIME;
                    }
                    if (int.TryParse(odr["SEX"].ToString(), out TMPI))
                    {
                        tbuser.SEX = TMPI;
                    }
                    tbuser.PHONE = odr["PHONE"].ToString();
                    tbuser.EMAIL = odr["EMAIL"].ToString();
                    tbuser.ADDRESS = odr["ADDRESS"].ToString();
                    tbuser.ROLE = odr["ROLE"].ToString();
                    return tbuser;
                }
                return null;

            }
            catch (Exception ex)
            {
                //DbHelperOleDb.WriteLog(ex.StackTrace+ex.Message+ex.InnerException);
                return null;
            }
            finally
            {

                odr.Close();
            }
        }

    }

}