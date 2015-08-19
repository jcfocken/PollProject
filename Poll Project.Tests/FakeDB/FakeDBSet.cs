using Poll_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poll_Project.DAL
{
    public class FakeDbSet<T> : System.Data.Entity.IDbSet<T> where T : class
    {
        private readonly List<T> list = new List<T>();

        public FakeDbSet()
        {
            list = new List<T>();
        }

        public FakeDbSet(IEnumerable<T> contents)
        {
            this.list = contents.ToList();
        }

        #region IDbSet<T> Members

        public T Add(T entity)
        {
            this.list.Add(entity);
            return entity;
        }

        public T Attach(T entity)
        {
            this.list.Add(entity);
            return entity;
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            throw new NotImplementedException();
        }

        public T Create()
        {
            throw new NotImplementedException();
        }

        public virtual T Find(params object[] keyValues)
        {
            throw new NotImplementedException("Derive from FakeDbSet<T> and override Find");
        }

        public System.Collections.ObjectModel.ObservableCollection<T> Local
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public T Remove(T entity)
        {
            this.list.Remove(entity);
            return entity;
        }

        #endregion

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        #endregion

        #region IQueryable Members

        public Type ElementType
        {
            get { return this.list.AsQueryable().ElementType; }
        }

        public System.Linq.Expressions.Expression Expression
        {
            get { return this.list.AsQueryable().Expression; }
        }

        public IQueryProvider Provider
        {
            get { return this.list.AsQueryable().Provider; }
        }

        #endregion
    }

    public class FakePollSet : FakeDbSet<Poll>
    {
        public override Poll Find(params object[] keyValues)
        {
            return this.SingleOrDefault(e => e.ID == (int)keyValues.Single());
        }
    }
}