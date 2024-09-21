using ShoeWebApp.Models;
using System.Data.SqlClient;
namespace ShoeWebApp.Data
{
    public abstract class Repository
    {
        private SqlConnection _connection;
        private string connectionstring = String.Empty;
        public string ConnectionString { 
            get 
            { 
                return connectionstring;
            } 
            set
            {
                connectionstring = value;
            } 
        }

        protected SqlConnection connection
        {
            get { return _connection; }
        }

        public virtual bool Connect()
        {
            bool returnVal=false;

            if(_connection == null)
            {
                _connection = new SqlConnection();
            }

            if (connectionstring != String.Empty) { 
                _connection.ConnectionString = connectionstring;
            }

            try
            {
                _connection.Open();
                returnVal = true;
            }
            catch (Exception ex) 
            { 
                returnVal = false;
            }
            return returnVal;
        }

        public abstract IList<ProductViewModel> getAll();
        public abstract T getById<T>(int id);
        public abstract T Insert<T>(T data);
        public abstract bool Update<T>(T data);
        public abstract bool Delete<T>(T data);
    }
}
