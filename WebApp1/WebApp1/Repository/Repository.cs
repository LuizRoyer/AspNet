using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebApp1.Data;

namespace WebApp1.Repository
{
    public class Repository<T> : IDisposable where T : class
    {
        private ContextApp _cotext;
        private DbSet<T> _dbSet;


        public Repository(ContextApp contexApp)
        {
            _cotext = contexApp;
            _dbSet = contexApp.Set<T>();
        }

        public void Dispose()
        {
            _cotext.Dispose();
        }
     
        public void Edit(T entity)
        {
            _cotext.Entry(entity).State = EntityState.Modified;
        }
        /// <summary>
        /// Retorna todo o Contexto da classe
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> FindAll()
        {
            return _cotext.Set<T>();
        }
        /// <summary>
        /// Pesquisa generica passando qualquer condicao como filtro
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
        /// <summary>
        /// recupero o Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T FinById(int id)
        {
            return _dbSet.Find(id);
        }
        /// <summary>
        /// Remove o Objeto do Banco
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(T entity)
        {
            _cotext.Set<T>().Remove(entity);
        }
        /// <summary>
        /// Adiciona o Objeto
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            _cotext.Set<T>().Add(entity);
        }
    }
}