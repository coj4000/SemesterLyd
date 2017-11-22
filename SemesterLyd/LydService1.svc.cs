using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SemesterLyd
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LydLydService1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LydLydService1.svc or LydLydService1.svc.cs at the Solution Explorer and start debugging.
    public class LydService1 : ILydService1
    {

        private string conStr =
                "Server=tcp:hotelobliserver.database.windows.net,1433;" +
                "Initial Catalog=HotelObliOpgAPI;Persist Security Info=False;" +
                "User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;" +
                "TrustServerCertificate=False;Connection Timeout=30;"
            ;
        public IList<Lyd> GetAllLyd()
        {
            List<Lyd> temp_list = new List<Lyd>();

            using (SqlConnection conn = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();

                    cmd.CommandText = "Select * from Lyd";
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        temp_list.Add(new Lyd()
                        {
                            Id = (int) reader[0],
                            Lydmal = (int) reader[1],
                        });
                    }
                    return temp_list;
                }
            }
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
