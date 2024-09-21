using ShoeWebApp.Models;
using System.Data.SqlClient;
using System.Data;

namespace ShoeWebApp.Data
{
    public class ProductRepository : Repository
    {
        public ProductRepository() {
            ConnectionString = "SERVER=G1-PF2C1HA9-L\\SQLEXPRESS;Database=CanteenMgmt;Integrated Security= true";
            Connect();
        }
        
       
        public override bool Delete<T>(T data)
        {
            throw new NotImplementedException();
            
        }

        public override IList<ProductViewModel> getAll()
        {
            IList<ProductViewModel> products = new List<ProductViewModel>();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from Products";

            
            SqlDataReader reader = command.ExecuteReader(); //This will return a data reader

            if (reader != null)
            {
                while (reader.Read())
                {
                    products.Add(new ProductViewModel
                    {
                        ProductId = Convert.ToInt32(reader["ProductID"]),
                        Name = Convert.ToString(reader["Name"]),
                        Description = Convert.ToString(reader["Description"]),
                        ProductPrice = Convert.ToInt32(reader["ProductPrice"]),
                        img = Convert.ToString(reader["img"]),
                    });

                }
            }
            return products.ToList();
            //return true;
        }

        public override T getById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public override T Insert<T>(T data)
        {
            throw new NotImplementedException();
        }

        public override bool Update<T>(T data)
        {
            throw new NotImplementedException();
        }
    }
}
