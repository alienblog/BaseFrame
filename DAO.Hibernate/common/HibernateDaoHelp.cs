using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using Spring.Data.NHibernate;
using Spring.Data.NHibernate.Generic;
using Spring.Data.NHibernate.Generic.Support;

namespace DAO.Hibernate.common
{
    
/**
 * GenericHibernateDao 继承 HibernateDao，简单封HibernateTemplate各项功能
* 基于Hibernate Dao 的编写�
* 
* @author rls
*/
    public class HibernateDaoHelp<T, TK> : HibernateDaoSupport, IDaoHelp<T, TK> where T : class
  {
 // -------------------- 基本增加修改删除操作--------------------
        /// <summary>
        ///根据主键获取实体。如果没有相应的实体，返回null�
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get(TK id)
        {
            return HibernateTemplate.Get<T>(id);
        }
        /// <summary>
        /// 根据主键获取实体并加锁�?如果没有相应的实体，返回 null�?
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <param name="locked">锁</param>
        /// <returns>返回一个对象实体</returns>
        public T GetWithLock(TK id, LockMode locked)
        {
            var t =  HibernateTemplate.Get<T>(id,locked);
            if (t != null)
            {
                 HibernateTemplate.Flush(); // 立即刷新，否则锁不会生效�?
            }
            return t;
        }
        /// <summary>
        /// 根据主键获取实体。如果没有相应的实体，抛出异常�?
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public T Load(TK id)
        {
            return  HibernateTemplate.Load<T>(id);
        }
        /// <summary>
        /// 根据主键获取实体并加锁�?如果没有相应的实体，抛出异常�?
        /// </summary>
        /// <param name="id"></param>
        /// <param name="locked"></param>
        /// <returns></returns>
        public T LoadWithLock(TK id, LockMode locked)
        {
            var t =   HibernateTemplate.Get<T>(id, 
            locked)
            ;
            if (t != null)
            {
                 HibernateTemplate.Flush(); // 立即刷新，否则锁不会生效�?
            }
            return t;
        }
        /// <summary>
        /// 获取全部实体
        /// </summary>
        /// <returns></returns>
        public List<T> LoadAll()
        {
            return  HibernateTemplate.LoadAll<T>().ToList();
        }
        /// <summary>
        /// 更新实体信息
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
             HibernateTemplate.Update(entity);
        }
        /// <summary>
        /// 更新实体并加锁
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="locked"></param>
        public void UpdateWithLock(T entity, LockMode locked)
        {
            HibernateTemplate.Update(entity, 
            locked);
             HibernateTemplate.Flush(); // 立即刷新，否则锁不会生效
        }
        /// <summary>
        ///  存储实体到数据库
        /// </summary>
        /// <param name="entity"></param>
        public void Save(T entity)
        {
              HibernateTemplate.Save(entity);
        }
      /// <summary>
      /// 实现实体列表的保存
      /// </summary>
      /// <param name="entities"></param>
        public void SaveAll(List<T> entities)
      {
          //for (int i = 0; i < entities.Count; i++)
          //{
          //    HibernateTemplate.Save(entities[i]);
          //}
          var session = SessionFactory.OpenStatelessSession(); 
          using (var tx = session.BeginTransaction())
          {
              foreach (var entity in entities)
              {
                  session.Insert(entity);
              }
              tx.Commit();
          }
          session.Close();
      }
        /// <summary>
        /// 增加或更新
        /// </summary>
        /// <param name="entity"></param>
        public void SaveOrUpdate(T entity)
        {
             HibernateTemplate.SaveOrUpdate(Session.Merge(entity));
        }
        /// <summary>
        /// 增加或更新集合中的全部实体
        /// </summary>
        /// <param name="entities"></param>
        public void SaveOrUpdateAll(Collection<T> entities)
        {
            foreach (var ent in entities)
            {
                  HibernateTemplate.SaveOrUpdate(ent);
            }
        }
        /// <summary>
        /// 删除指定的实体
        /// </summary>
        /// <param name="modeentity"></param>
        public void Delete(T modeentity)
        {
             HibernateTemplate.Delete(modeentity);
        }

      public int Delete(string queryString)
      {
          return HibernateTemplate.Delete(queryString);
      }

      /// <summary>
      /// 带参数的删除语句，可实现批量删除
      /// </summary>
      /// <param name="queryString"></param>
      /// <param name="values"></param>
      /// <param name="types"></param>
        public void Delete(string queryString,object[] values,NHibernate.Type.IType[] types)
        {
            HibernateTemplate.Delete(queryString,values,types);
        }
        /// <summary>
        /// 加锁并删除指定的实体
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="locked"></param>
        public void DeleteWithLock(T entity, LockMode locked)
        {
             HibernateTemplate.Delete(entity, locked);
             HibernateTemplate.Flush(); // 立即刷新，否则锁不会生效�?
        }
        /// <summary>
        /// 根据主键删除指定实体
        /// </summary>
        /// <param name="id">主键ID</param>
        public void DeleteByKey(TK id)
        {
            Delete(Load(id));
        }
        /// <summary>
        /// 根据主键加锁并删除指定的实体
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <param name="locked">锁</param>
        public void DeleteByKeyWithLock(TK id, LockMode locked)
        {
            DeleteWithLock(Load(id), 
            locked);
        }
        /// <summary>
        /// 删除集合信息
        /// </summary>
        /// <param name="entities"></param>
        public void DeleteAll(Collection<T> entities)
        {
            foreach (var entitie in entities)
            {
                 HibernateTemplate.Delete(entitie);
            }
        }

      public int UpdateHQL(string hql)
      {
          IQuery iQuery = this.GetSession().CreateQuery(hql);
          return iQuery.ExecuteUpdate();
      }

      /// <summary>
        ///  删除集合信息
        /// </summary>
        /// <param name="entities"></param>
        public void DeleteAll(List<T> entities)
        {
            foreach (var entitie in entities)
            {
                 HibernateTemplate.Delete(entitie);
            }
        }
// -------------------- 基本增加修改删除操作结束--------------------

// ---------------------- HSQL语句查询--------------------
      /// <summary>
      /// 返回总记录数
      /// </summary>
      /// <param name="countHql"></param>
      /// <param name="values"></param>
      /// <returns></returns>
      public int CountHql(string countHql, object[] values)
        {
            countHql = "select count(*) " + RemoveSelectAndOrder(countHql);
            IQuery iQuery = this.GetSession().CreateQuery(countHql);
            for (int i = 0; i < values.Count(); i++)
            {
                iQuery.SetParameter(i, values[i]);
            }
            return int.Parse(iQuery.UniqueResult().ToString());
        }

      /// <summary>
      /// 使用hql获取分页,实体列表
      /// </summary>
      /// <param name="hql"></param>
      /// <param name="values"></param>
      /// <param name="pageIndex"></param>
      /// <param name="pageSize"></param>
      /// <returns></returns>
      public List<T> FindListByHql(string hql, object[] values, int pageIndex, int pageSize)
        {
            IQuery iQuery = this.GetSession().CreateQuery(hql);
            for (int i = 0; i < values.Count(); i++)
            {
                iQuery.SetParameter(i, values[i]);
            }
            var list = (List<T>)iQuery.SetFirstResult((pageIndex - 1) * pageSize)
                                           .SetMaxResults(pageSize).List<T>();
            return list;
        }
      /// <summary>
      /// 使用hql获取分页,实体列表
      /// </summary>
      /// <param name="hql"></param>
      /// <param name="paramNames"></param>
      /// <param name="values"></param>
      /// <param name="pageIndex"></param>
      /// <param name="pageSize"></param>
      /// <returns></returns>
      public List<T> FindListByHql(string hql, string[] paramNames, object[] values, int pageIndex, int pageSize)
      {
          IQuery iQuery = this.GetSession().CreateQuery(hql);
          for (int i = 0; i < values.Count(); i++)
          {
              iQuery.SetParameter(paramNames[i], values[i]);
          }
          var list = (List<T>)iQuery.SetFirstResult((pageIndex - 1) * pageSize)
                                         .SetMaxResults(pageSize).List<T>();
          return list;
      }

      /// <summary>
      /// 使用hql获取分页,数组列表
      /// </summary>
      /// <param name="hql"></param>
      /// <param name="values"></param>
      /// <param name="pageIndex"></param>
      /// <param name="pageSize"></param>
      /// <returns></returns>
      public List<object[]> FindObjsByHql(string hql, object[] values, int pageIndex, int pageSize)
      {
          IQuery iQuery = this.GetSession().CreateQuery(hql);
          for (int i = 0; i < values.Count(); i++)
          {
              iQuery.SetParameter(i, values[i]);
          }
          var list = (List<object[]>)iQuery.SetFirstResult((pageIndex - 1) * pageSize)
                                         .SetMaxResults(pageSize)
                                         .List<object[]>();
          return list;
      }
      /// <summary>
      /// 使用hql获取分页,数组列表
      /// </summary>
      /// <param name="hql"></param>
      /// <param name="values"></param>
      /// <returns></returns>
      public List<object[]> FindObjsByHql(string hql, object[] values)
      {
          IQuery iQuery = this.GetSession().CreateQuery(hql);
          if(values !=null)
          for (int i = 0; i < values.Count(); i++)
          {
              iQuery.SetParameter(i, values[i]);
          }
          var list = (List<object[]>)iQuery.List<object[]>();
          return list;
      }

      /// <summary>
      /// 使用hql获取分页,数组列表
      /// </summary>
      /// <param name="hql"></param>
      /// <param name="paramNames"></param>
      /// <param name="values"></param>
      /// <param name="pageIndex"></param>
      /// <param name="pageSize"></param>
      /// <returns></returns>
      public List<object[]> FindObjsByHql(string hql, string[] paramNames, object[] values, int pageIndex, int pageSize)
      {
          IQuery iQuery = this.GetSession().CreateQuery(hql);
          for (int i = 0; i < values.Count(); i++)
          {
              iQuery.SetParameter(paramNames[i], values[i]);
          }
          var list = (List<object[]>)iQuery.SetFirstResult((pageIndex - 1) * pageSize)
                                         .SetMaxResults(pageSize)
                                         .List<object[]>();
          return list;
      }

      /// <summary>
        /// 使用HSQL语句查询数据
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public List<T> Find(String queryString)
        {
            return  HibernateTemplate.Find<T>(queryString).ToList();
        }
        /// <summary>
        ///  使用带参数的HSQL语句查询指定数据
        /// </summary>
        /// <param name="queryString">HQL语句</param>
        /// <param name="values">值集合</param>
        /// <returns>结果集</returns>
        public List<T> Find(String queryString, Object[] values)
        {
             
            return  HibernateTemplate.Find<T>(queryString, values).ToList();
        }
        /// <summary>
        /// 使用带命名的参数的HSQL语句查询数据
        /// </summary>
        /// <param name="queryString">HQL语句</param>
        /// <param name="paramNames">参数名称集合</param>
        /// <param name="values">值结合</param>
        /// <returns>结果集</returns>
        public List<T> FindByNamedParam(string queryString, string[] paramNames,
                                     Object[] values)
        {
             
            return  HibernateTemplate.FindByNamedParam<T>(queryString, paramNames,
                                                           values).ToList();
        }
        /// <summary>
        /// 使用命名的HSQL语句查询数据
        /// </summary>
        /// <param name="queryName">HQL语句</param>
        /// <returns>结果集</returns>
        public List<T> FindByNamedQuery(String queryName)
        {
            return  HibernateTemplate.FindByNamedQuery<T>(queryName).ToList();
        }
        /// <summary>
        /// 使用带参数的命名HSQL语句查询数据
        /// </summary>
        /// <param name="queryName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public List<T> FindByNamedQuery(String queryName, Object[] values)
        {
            return  HibernateTemplate.FindByNamedQuery<T>(queryName, values).ToList();
        }
        /// <summary>
        /// 使用带命名参数的命名HSQL语句查询数据
        /// </summary>
        /// <param name="queryName"></param>
        /// <param name="paramNames"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public List<T> FindByNamedQueryAndNamedParam(String queryName,
                                                  String[] paramNames, Object[] values)
        { 
            return  HibernateTemplate.FindByNamedQueryAndNamedParam<T>(queryName,
                                                                        paramNames, values).ToList();
        }
 // ---------------------- HSQL语句查询结束--------------------

// -------------------------------- Criteria ------------------------------
        /// <summary>
        /// 创建与会话无关的Criteria标准
        /// </summary>
        /// <returns></returns>
        public DetachedCriteria CreateDetachedCriteria()
        {
            return DetachedCriteria.For<T>();
        }

        /// <summary>
        /// 创建与会话绑定的Criteria标准
        /// </summary>
        /// <returns></returns>
        public NHibernate.ICriteria CreateCriteria()
        {
            return this.GetSession().CreateCriteria<T>();
         }
// -------------------------------- Criteria 结束------------------------------

//--------------------------------复合查询2-----------------------------------
        /// <summary>
        /// DetachedCriteria满足标准的数据
        /// </summary>
        /// <param name="detachedCriteria"> </param>
        /// <returns>对象结果集</returns>
        public IList<T> FindByCriteria(DetachedCriteria detachedCriteria)
        {
            ICriteria iCriteria = detachedCriteria.GetExecutableCriteria(GetSession());
            return iCriteria.List<T>();
            //var entityType = HibernateTemplate.Execute(new HibernateDelegate<IList<T>>(delegate(ISession session)
            //{
            //    ICriteria iCriteria = detachedCriteria.GetExecutableCriteria(session);
            //    return iCriteria.List<T>();
            //}));
            //return entityType;
        }
        /// <summary>
        /// DetachedCriteria满足标准的数据，返回指定范围的记�?
        /// </summary>
        /// <param name="detachedCriteria"> </param>
        /// <param name="firstResult"></param>
        /// <param name="maxResults"></param>
        /// <returns></returns>
        public IList<T> FindByCriteria(DetachedCriteria detachedCriteria, int firstResult,
                                   int maxResults)
        {
            detachedCriteria.SetFirstResult(firstResult).SetMaxResults(maxResults);
            ICriteria iCriteria = detachedCriteria.GetExecutableCriteria(GetSession());
            return iCriteria.List<T>();

            //detachedCriteria.SetFirstResult(firstResult).SetMaxResults(maxResults);
            //var entityType = HibernateTemplate.Execute(new HibernateDelegate<IList<T>>(delegate(ISession session)
            //{
            //    if (session == null) throw new ArgumentNullException("session");
            //    ICriteria iCriteria = detachedCriteria.GetExecutableCriteria(session);
            //    return iCriteria.List<T>();
            //}));
            //return entityType;
        }
        /// <summary>
        /// “复杂条件”实体对象列表
        /// 注意：没有关闭Session!
        /// (criteria是criterion的复数) 标准
        /// </summary>
        public IList<T> GetEntities(ICriterion iCriterion)
        {
            //这是参考E:\NHibernate\Spring.net\官网下载\Spring.NET-1.3.2\Spring.NET\src\Spring\Spring.Data.NHibernate12\Data\NHibernate\Generic\ HibernateTemplate.cs
            //取集合的，别有取单个实体的!
            //exposeNativeSession的作用：（取自spring.net）
            //(exposeNativeSession ? session : classic HibernateTemplate.CreateSessionProxy(session));
          
            return  HibernateTemplate.ExecuteFind(new FindByCriterionHibernateCallback<T>(iCriterion), true);
        }
//--------------------------------复合查询2结束-----------------------------------

//*********************************linq查询方式*****************************
        /// <summary>
        /// 使用linq查询数据
        /// </summary>
        /// <returns></returns>
          public IQueryable<T> FindByLinq()
        {
           
            return this.GetSession().Query<T>();
          }
//*********************************linq查询方式结束*****************************

          //-----------------------------------存储过程------------------------------------
          #region IList ExecuteStoredProc(string spName, ICollection<ParamInfo> paramInfos)
          public IList ExecuteStoredProc(string spName, ICollection<ParamInfo> paramInfos)
          {
              IList result = new ArrayList();

              IDbCommand cmd = this.GetSession().Connection.CreateCommand();

              cmd.CommandText = spName;
              cmd.CommandType = CommandType.StoredProcedure;

              // 加入参数 
              if (paramInfos != null)
              {
                  foreach (ParamInfo info in paramInfos)
                  {
                      IDbDataParameter parameter = cmd.CreateParameter();
                      parameter.ParameterName = info.Name; // driver.FormatNameForSql( info.Name ); 
                      parameter.Value = info.Value;
                      cmd.Parameters.Add(parameter);
                  }
              }

              IDbConnection conn = GetSession().Connection;
              //conn.Open();
              try
              {
                  cmd.Connection = conn;
                  IDataReader rs = cmd.ExecuteReader();

                  while (rs.Read())
                  {
                      var fieldCount = rs.FieldCount;
                      var values = new Object[fieldCount];
                      for (int i = 0; i < fieldCount; i++)
                          values[i] = rs.GetValue(i);
                      result.Add(values);
                  }
              }
              finally
              {
                  this.GetSession().Connection.Close();
              }

              return result;
          }

      public IDataReader GetDataReaderStoredProc(string spName, ICollection<ParamInfo> paramInfos)
      {
          IDbCommand cmd = this.GetSession().Connection.CreateCommand();

          cmd.CommandText = spName;
          cmd.CommandType = CommandType.StoredProcedure;

          // 加入参数 
          if (paramInfos != null)
          {
              foreach (ParamInfo info in paramInfos)
              {
                  IDbDataParameter parameter = cmd.CreateParameter();
                  parameter.ParameterName = info.Name; // driver.FormatNameForSql( info.Name ); 
                  parameter.Value = info.Value;
                  cmd.Parameters.Add(parameter);
              }
          }

          IDbConnection conn = GetSession().Connection;
          //conn.Open();
          IDataReader rs = null;
          try
          {
              cmd.Connection = conn;
              rs = cmd.ExecuteReader();
          }
          finally
          {
              this.GetSession().Connection.Close();
          }

          return rs;
      }

      #endregion
//-----------------------------------存储过程结束----------------------------------------

//***********************************其他***************************************
          /// <summary>
          /// 未实现强制初始化指定的实体
          /// </summary>
          /// <param name="proxy"></param>
          public void Initialize(object proxy)
          {
            
            throw new NotImplementedException();
          }
          /// <summary>
          /// 强制立即更新缓冲数据到数据库（否则仅在事务提交时才更新）
          /// </summary>
          public void Flush()
          {
               HibernateTemplate.Flush();
          }
          /// <summary>
          /// 获取Session
          /// </summary>
          /// <returns></returns>
          public ISession GetSession()
          {
              return this.Session;
          }
          /// <summary>
          /// 关闭session
          /// </summary>
          public void CloseSession()
          {
              this.Session.Close();
          }
          /// <summary>
          /// 强制立即缓冲数据
          /// </summary>
          public void Clear()
          {
               HibernateTemplate.Clear();
          }
          /// <summary>
          /// 去掉hql中的select和order
          /// </summary>
          /// <param name="hql"></param>
          /// <returns></returns>
          public string RemoveSelectAndOrder(string hql)
          { 
              string hql_ = hql.ToLower();
              int beginPos = hql_.IndexOf("from");
              if (beginPos != -1)
                  hql_ = hql.Substring(beginPos);
              beginPos = hql_.IndexOf("order");
              if (beginPos != -1)
                  hql_ = hql_.Substring(0, beginPos);
              return hql_;
          }
//***********************************其他结束***************************************

//***********************************************************内部类*********************************
          internal class HibernateCallback<TH> : IHibernateCallback
          {
              private DetachedCriteria DCriteria{ set; get; }
              public HibernateCallback( DetachedCriteria dCriteria)
              {
                  DCriteria = dCriteria;
              }
              public Object DoInHibernate(ISession session)
              {
                  ICriteria criteri = DCriteria.GetExecutableCriteria(session);
                  return criteri.List<TH>();
              }
        }

        internal class FindByCriterionHibernateCallback<TT> : IFindHibernateCallback<TT>
        {
            private ICriterion ic;
            public FindByCriterionHibernateCallback(ICriterion iCriterion)
            {
                ic = iCriterion;
            }
            /// <summary>
            /// Gets called by  HibernateTemplate with an active
            /// Hibernate Session. Does not need to care about activating or closing
            /// the Session, or handling transactions.
            /// </summary>
            /// <remarks>
            /// <p>
            /// Allows for returning a result object created within the callback, i.e.
            /// a domain object or a collection of domain objects. Note that there's
            /// special support for single step actions: see  HibernateTemplate.find etc.
            /// </p>
            /// </remarks>
            public IList<TT> DoInHibernate(ISession session)
            {
                var criteria = session.CreateCriteria(typeof(TT));
                criteria.Add(ic);
                var entities = criteria.List<TT>();
                return entities;
            }
        }
//***********************************************************内部类结束*********************************
    }
}
