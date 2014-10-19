using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Northwind.Tests
{
    public class PullImagesFromOldSystem
    {
        public void Fetch_Categories()
        {
            using (var connection = new SqlConnection("server=.;database=Northwind;Integrated Security=SSPI"))
            using (var command = new SqlCommand("select CategoryId, Picture from categories where picture is not null", connection))
            {
                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);

                foreach (DataRow dataRow in ds.Tables[0].Rows)
                {
                    var id = (int)dataRow[0];
                    var image = (byte[])dataRow[1];
                    var file = new FileStream(@"c:\temp\category-" + id + ".bmp", FileMode.CreateNew);
                    file.Write(image, 78, image.Length - 78);
                }
            }
        }

        public void Fetch_Employees()
        {
            using (var connection = new SqlConnection("server=.;database=Northwind;Integrated Security=SSPI"))
            using (var command = new SqlCommand("select EmployeeId, Photo from employees where Photo is not null", connection))
            {
                var adapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                adapter.Fill(ds);

                foreach (DataRow dataRow in ds.Tables[0].Rows)
                {
                    var id = (int)dataRow[0];
                    var image = (byte[])dataRow[1];
                    var file = new FileStream(@"c:\temp\employee-" + id + ".bmp", FileMode.CreateNew);
                    file.Write(image, 78, image.Length - 78);
                }
            }
        }
    }
}
    //// http://stackoverflow.com/questions/5371222/getting-binary-data-using-sqldatareader
    //// http://www.xtremedotnettalk.com/showthread.php?t=92297