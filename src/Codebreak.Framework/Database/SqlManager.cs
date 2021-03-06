﻿using Codebreak.Framework.Generic;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Codebreak.Framework.Database
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SqlManager
    {
        /// <summary>
        /// 
        /// </summary>
        public static ILog Logger = LogManager.GetLogger(typeof(SqlManager));

        /// <summary>
        /// 
        /// </summary>
        private string m_connectionString;

        /// <summary>
        /// 
        /// </summary>
        public MySqlConnection CreateConnection()
        {
            var connection = new MySqlConnection(m_connectionString);
            connection.Open();
            return connection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public void Initialize(string connectionString)
        {
            m_connectionString = connectionString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public IEnumerable<T> Query<T>(string query, object param = null)
        {
            using (var connection = CreateConnection())
            {
                return connection.Query<T>(query, param);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public T QuerySingle<T>(string query, object param = null)
        {
            using (var connection = CreateConnection())
            {
                return connection.Query<T>(query, param).FirstOrDefault();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int ExecuteQuery(string query, object param = null)
        {
            using (var connection = CreateConnection())
            {
                return connection.ExecuteQuery(query, param);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataObject"></param>
        public bool Insert<T>(T dataObject) where T : DataAccessObject<T>, new()
        {
            using (var connection = CreateConnection())
            {
                try
                {
                    connection.Insert<T>(dataObject);
                    return true;
                }
                catch(Exception ex)
                {
                    Logger.Error("Fatal errror while inserting in database : " + ex.Message);
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataObject"></param>
        public bool InsertWithKey<T>(T dataObject) where T : DataAccessObject<T>, new()
        {
            using (var connection = CreateConnection())
            {
                try
                {
                    connection.InsertWithKey<T>(dataObject);
                    return true;
                }
                catch (Exception ex)
                {
                    Logger.Error("Fatal errror while inserting in database : " + ex.Message);
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataObject"></param>
        public bool InsertWithKey<T>(IEnumerable<T> dataObjects) where T : DataAccessObject<T>, new()
        {
            using (var connection = CreateConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        connection.InsertWithKey<T>(dataObjects, transaction);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Logger.Error("Fatal errror while inserting in database : " + ex.Message);
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataObjects"></param>
        /// <returns></returns>
        public bool Insert<T>(IEnumerable<T> dataObjects) where T : DataAccessObject<T>, new()
        {
            using(var connection = CreateConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        connection.Insert<T>(dataObjects, transaction);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Logger.Error("Fatal errror while inserting in database : " + ex.Message);
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataObject"></param>
        /// <returns></returns>
        public bool Delete<T>(T dataObject) where T : DataAccessObject<T>, new()
        {
            using (var connection = CreateConnection())
            {
                return connection.Delete<T>(dataObject);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataObject"></param>
        /// <returns></returns>
        public void Delete<T>(MySqlConnection connection, MySqlTransaction transaction, IEnumerable<T> dataObjects) where T : DataAccessObject<T>, new()
        {
            connection.Delete<T>(dataObjects, transaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataObject"></param>
        /// <returns></returns>
        public void InsertWithKey<T>(MySqlConnection connection, MySqlTransaction transaction, IEnumerable<T> dataObjects) where T : DataAccessObject<T>, new()
        {
            connection.InsertWithKey<T>(dataObjects, transaction);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataObjects"></param>
        /// <returns></returns>
        public void Update<T>(MySqlConnection connection, MySqlTransaction transaction, IEnumerable<T> dataObjects) where T : DataAccessObject<T>, new()
        {
            connection.Update<T>(dataObjects, transaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataObject"></param>
        public bool Update<T>(T dataObject) where T : DataAccessObject<T>, new()
        {
            using (var connection = CreateConnection())
            {
                return connection.Update<T>(dataObject);
            }
        }       
    }
}
