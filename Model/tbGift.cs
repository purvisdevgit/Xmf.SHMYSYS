using System;
namespace Xmf.SHMYSYS.Model
{
	/// <summary>
	/// tbGift:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tbGift
	{
		public tbGift()
		{}
		#region Model
		private string _guid;
		private string _giftname;
		private string _image;
		private int? _number;
		private string _detail;
		private DateTime? _addtime;
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
		public string GIFTNAME
		{
			set{ _giftname=value;}
			get{return _giftname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IMAGE
		{
			set{ _image=value;}
			get{return _image;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? NUMBER
		{
			set{ _number=value;}
			get{return _number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DETAIL
		{
			set{ _detail=value;}
			get{return _detail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ADDTIME
		{
			set{ _addtime=value;}
			get{return _addtime;}
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

