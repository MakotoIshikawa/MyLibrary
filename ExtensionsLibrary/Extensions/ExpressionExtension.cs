using System;
using System.Linq.Expressions;
using System.Reflection;

namespace ExtensionsLibrary.Extensions {
	/// <summary>
	/// Expression を拡張するメソッドを提供します。
	/// </summary>
	public static partial class ExpressionExtension {
		#region メソッド

		/// <summary>
		/// メンバーを抽出する式木を指定して、
		/// メンバー情報を取得します。
		/// </summary>
		/// <typeparam name="T">メンバーを抽出するオブジェクトの型</typeparam>
		/// <typeparam name="TMember">抽出するメンバーの型</typeparam>
		/// <param name="this">T</param>
		/// <param name="fetchMember">メンバーを抽出する式木</param>
		/// <returns>メンバー情報を返します。</returns>
		public static MemberInfo GetMemberInfo<T, TMember>(this T @this, Expression<Func<T, TMember>> fetchMember)
			=> fetchMember?.GetMember();

		/// <summary>
		/// メンバー情報を取得します。
		/// </summary>
		/// <typeparam name="T">メンバーを抽出するオブジェクトの型</typeparam>
		/// <typeparam name="TMember">抽出するメンバーの型</typeparam>
		/// <param name="this">Expression</param>
		/// <returns>メンバー情報を返します。</returns>
		public static MemberInfo GetMember<T, TMember>(this Expression<Func<T, TMember>> @this)
			=> ((MemberExpression)@this?.Body)?.Member;

		/// <summary>
		/// メンバーの名前を取得します。
		/// </summary>
		/// <typeparam name="T">メンバーを抽出するオブジェクトの型</typeparam>
		/// <typeparam name="TMember">抽出するメンバーの型</typeparam>
		/// <param name="this">Expression</param>
		/// <returns>メンバー名を返します。</returns>
		public static string GetMemberName<T, TMember>(this Expression<Func<T, TMember>> @this)
			=> @this?.GetMember()?.Name;

		/// <summary>
		/// フィールドまたはプロパティのコンテナーオブジェクトを取得します。
		/// </summary>
		/// <typeparam name="T">メンバーを抽出するオブジェクトの型</typeparam>
		/// <typeparam name="TMember">抽出するメンバーの型</typeparam>
		/// <param name="this">Expression</param>
		/// <returns>コンテナーオブジェクトを返します。</returns>
		public static Expression GetExpression<T, TMember>(this Expression<Func<T, TMember>> @this)
			=> ((MemberExpression)@this?.Body)?.Expression;

		#endregion
	}
}
