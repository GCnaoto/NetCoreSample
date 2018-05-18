using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NetCoreEntityFramework.Model;

namespace NetCoreEntityFramework
{
    /// <summary>
    /// 汎用CRUDリポジトリ
    /// </summary>
    public class CRUDRepository : ICRUDRepository
    {
        private WorkDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenegalCRUDRepository"/> class.
        /// </summary>
        /// <param name="context">Navi業務DBContext</param>
        /// <param name="httpContextAccessor">HttpContext</param>
        public CRUDRepository(WorkDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 汎用検索リポジトリ
        /// </summary>
        /// <param name="predicate">テーブルキーの式木</param>
        /// /// <typeparam name="T">エンティティ</typeparam>
        /// <returns>汎用Entity</returns>
        public virtual async Task<List<T>> Find<T>(Expression<Func<T, bool>> predicate)
            where T : ModelBase
        {
            return await _context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
        }

        /// <summary>
        /// 汎用登録リポジトリ
        /// </summary>
        /// <param name="entity">登録する汎用Entity</param>
        /// <typeparam name="T">エンティティ</typeparam>
        /// <returns>処理件数</returns>
        public virtual async Task<int> Add<T>(T entity)
            where T : ModelBase
        {
            DbSet<T> dbSet = _context.Set<T>();

            // インスタンスの値を取得
            dbSet.Add(entity);

            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 汎用更新リポジトリ
        /// </summary>
        /// <param name="entity">更新する汎用Entity</param>
        /// <typeparam name="T">エンティティ</typeparam>
        /// <returns>処理件数</returns>
        public virtual async Task<int> Update<T>(T entity)
            where T : ModelBase
        {
            _context.Entry(entity).State = EntityState.Modified;
            int result = await _context.SaveChangesAsync();

            return result;
        }

        /// <summary>
        /// 汎用削除リポジトリ
        /// </summary>
        /// <param name="entity">削除する汎用Entity</param>
        /// <typeparam name="T">エンティティ</typeparam>
        /// <returns>処理件数</returns>
        public virtual async Task<int> Delete<T>(T entity)
            where T : ModelBase
        {
            int result = 0;
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);

                result = await _context.SaveChangesAsync();
            }

            return result;
        }

        /// <summary>
        /// 汎用全検索リポジトリ
        /// </summary>
        /// <typeparam name="T">エンティティ</typeparam>
        /// <returns>汎用EntityList</returns>
        public virtual async Task<List<T>> All<T>()
            where T : ModelBase
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 汎用存在チェックリポジトリ
        /// </summary>
        /// <param name="predicate">テーブルキーの式木</param>
        /// <typeparam name="T">エンティティ</typeparam>
        /// <returns>存在するか否か</returns>
        public virtual async Task<bool> IsExist<T>(Expression<Func<T, bool>> predicate)
            where T : ModelBase
        {
            return await _context.Set<T>().AnyAsync(predicate);
        }
    }
}
