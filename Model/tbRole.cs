using System;
namespace Xmf.SHMYSYS.Model
{
	/// <summary>
	/// tbRole:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tbRole
	{
		public tbRole()
		{}
		#region Model
		private string _guid;
		private string _rolename;
		private int? _isuse;
		/// <summary>
		/// 
		/// </summary>
		public string GUID
		{
			set{ _guid=value;}
			get{return _guid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ROLENAME
		{
			set{ _rolename=value;}
			get{return _rolename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ISUSE
		{
			set{ _isuse=value;}
			get{return _isuse;}
		}
		#endregion Model

	}
}

