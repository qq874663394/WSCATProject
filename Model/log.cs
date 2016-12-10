
using System;
namespace Model
{
	/// <summary>
	/// 上下班时刻表
	/// </summary>
	[Serializable]
	public partial class Log
	{
		public Log()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _operationcode;
		private string _operationname;
		private string _operationtable;
		private DateTime _operationtime;
		private int? _result;
		private string _objective;
		private string _operationcontent;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string operationCode
		{
			set{ _operationcode=value;}
			get{return _operationcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string operationName
		{
			set{ _operationname=value;}
			get{return _operationname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string operationTable
		{
			set{ _operationtable=value;}
			get{return _operationtable;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime operationTime
		{
			set{ _operationtime=value;}
			get{return _operationtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? result
		{
			set{ _result=value;}
			get{return _result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string objective
		{
			set{ _objective=value;}
			get{return _objective;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string operationContent
		{
			set{ _operationcontent=value;}
			get{return _operationcontent;}
		}
		#endregion Model

	}
}

