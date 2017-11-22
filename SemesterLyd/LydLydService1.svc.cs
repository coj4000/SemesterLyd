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
    public class LydLydService1 : ILydService1
    {

        private string conStr =
                "Server=tcp:eventmserver.database.windows.net,1433;Initial Catalog=EMDatabase;Persist Security Info=False;User ID=Matias;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            ;


        public IList<Lyd> GetAllLyd()
        
        {
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();

            string sql = "SELECT * FROM MALING";
            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader reader = command.ExecuteReader();

            List<Lyd> lyde = new List<Lyd>();
            while (reader.Read())
            {
                Lyd a = new Lyd();

                a.Id = reader.GetInt32(0);
                a.Lydmal = reader.GetInt32(1);
                


                lyde.Add(a);
            }
            return lyde;
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
