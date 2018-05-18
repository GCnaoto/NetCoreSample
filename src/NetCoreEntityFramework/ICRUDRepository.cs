using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NetCoreEntityFramework.Model;

namespace NetCoreEntityFramework
{
    /// <summary>
    /// 汎用CRUDリポジトリ
    /// </summary>
    /// <typeparam name="T">エンティティ</typeparam>
    public interface ICRUDRepository
    {
        /// <summary>
        /// 汎用登録リポジトリ
        /// </summary>
        /// <param name="entity">登録する汎用Entity</param>
        /// <typeparam name="T">エンティティ</typeparam>
        /// <returns>処理件数</returns>
        Task<int> Add<T>(T entity)
            where T : ModelBase;

        /// <summary>
        /// 汎用全検索リポジトリ
        /// </summary>
        /// <typeparam name="T">エンティティ</typeparam>
        /// <returns>汎用EntityList</returns>
        Task<List<T>> All<T>()
            where T : ModelBase;

        /// <summary>
        /// 汎用削除リポジトリ
        /// </summary>
        /// <param name="entity">削除する汎用Entity</param>
        /// <typeparam name="T">エンティティ</typeparam>
        /// <returns>処理件数</returns>
        Task<int> Delete<T>(T entity)
            where T : ModelBase;

        /// <summary>
        /// 汎用検索リポジトリ
        /// </summary>
        /// <param name="predicate">テーブルキーの式木</param>
        /// <typeparam name="T">エンティティ</typeparam>
        /// <returns>汎用Entity</returns>
        Task<List<T>> Find<T>(Expression<Func<T, bool>> predicate)
            where T : ModelBase;

        /// <summary>
        /// 汎用存在チェックリポジトリ
        /// </summary>
        /// <param name="predicate">テーブルキーの式木</param>
        /// <typeparam name="T">エンティティ</typeparam>
        /// <returns>存在するか否か</returns>
        Task<bool> IsExist<T>(Expression<Func<T, bool>> predicate)
            where T : ModelBase;

        /// <summary>
        /// 汎用更新リポジトリ
        /// </summary>
        /// <param name="entity">更新する汎用Entity</param>
        /// <typeparam name="T">エンティティ</typeparam>
        /// <returns>処理件数</returns>
        Task<int> Update<T>(T entity)
            where T : ModelBase;
    }
}
