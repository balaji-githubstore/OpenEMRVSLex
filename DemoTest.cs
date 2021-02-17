//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using ClosedXML.Excel;
//using System.Data.SqlClient;
//using System.Data;
//using System.IO;
//using Newtonsoft.Json;
//using OpenEmrAutomation.Utilities;

//namespace OpenEmrAutomation
//{
//    class DemoTest
//    {
//        public static object[] TCData()
//        {
//            string name = "bala";
//            Console.WriteLine("my name {0} ",name);
//           object[] main=  JsonUtils.JsonIntoObjectArray(@"D:\B-Mine\Company\Company\Unitedlex\WebAutomationFramework\OpenEmrAutomation\TestData\data.json", "validcredentialtestdata");
//          return main;
//        }

//        [Test, TestCaseSource("TCData")]
//        public void TC(string username, string password, string language)
//        {
            
//        }


//        [Test]
//        public void ReadJson()
//        {
//            StreamReader reader = new StreamReader(@"D:\B-Mine\Company\Company\Unitedlex\WebAutomationFramework\OpenEmrAutomation\TestData\data.json");
//            string data= reader.ReadToEnd();

//            dynamic json= JsonConvert.DeserializeObject(data);
//            Console.WriteLine(json["connectionstringdb"]);
//        }

//        [Test]
//        public void ReadJson1()
//        {
//            StreamReader reader = new StreamReader(@"D:\B-Mine\Company\Company\Unitedlex\WebAutomationFramework\OpenEmrAutomation\TestData\data.json");
//            string data = reader.ReadToEnd();

//            dynamic json = JsonConvert.DeserializeObject(data);

//            Console.WriteLine(json["validcredentialtestdata"].Count);
//            Console.WriteLine(json["validcredentialtestdata"][0].Count);



//        }


//        [Test]
//        [TestCase("bala","J123")]
//        [TestCase("john", "J123")]
//        [TestCase("Peter", "J123")]
//        public void TM(string username,string pass)
//        {

//        }

//        [Test]
//        public void TM1([Random(1,10,5)] int random)
//        {

//        }

//        [Test]
//        public void TM2([Range(1,10)] int random)
//        {

//        }
//        //sequential, values

//        [Test]
//        public void DBFirstCellReadTest()
//        {
//            string connectionstring = @"Data Source=COMPUTER\PIPETTEX;Initial Catalog=openemr;User ID=sa;Password=123456;Integrated Security=true";
//            SqlConnection con = new SqlConnection(connectionstring);

//            SqlCommand command = new SqlCommand("select * from Persons", con);

//            con.Open();

//            string cell = Convert.ToString(command.ExecuteScalar());

//            con.Close();

//        }

//        [Test]
//        public void DBUpdateDeleteInsertTest()
//        {
//            string connectionstring = @"Data Source=COMPUTER\PIPETTEX;Initial Catalog=openemr;User ID=sa;Password=123456;Integrated Security=true";
//            SqlConnection con = new SqlConnection(connectionstring);

//            SqlCommand command = new SqlCommand("update persons set id=5 where id=1", con);

//            con.Open();

//            int rowAffected = command.ExecuteNonQuery();

//            con.Close();

//        }


//        public DataTable GetSelectStatementIntoDataTable(string query)
//        {
//            string connectionstring = @"Data Source=COMPUTER\PIPETTEX;Initial Catalog=openemr;User ID=sa;Password=123456;Integrated Security=true";
//            SqlConnection con = new SqlConnection(connectionstring);

//            SqlCommand command = new SqlCommand(query, con);

//            DataTable dt = new DataTable();

//            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
//            dataAdapter.Fill(dt);

//            return dt;
//        }
//        [Test]
//        public void DBExecuteReaderTest()
//        {
//            string name = "bala";
//            string colName = "FirstName";
//            string connectionstring = @"Data Source=COMPUTER\PIPETTEX;Initial Catalog=openemr;User ID=sa;Password=123456;Integrated Security=true";
//            SqlConnection con = new SqlConnection(connectionstring);

//            SqlCommand command = new SqlCommand("select * From persons", con);

//            con.Open();

//            SqlDataReader reader= command.ExecuteReader();
//            bool check = false;
//            while (reader.Read())
//            {
//                if(reader[colName].ToString().Contains(name))
//                {
//                    check = true;
//                    break;
//                }
//            }
//            Console.WriteLine(check);
//            con.Close();

//        }

//            [Test]
//        public void DBSelectTest()
//        {
//            string connectionstring = @"Data Source=COMPUTER\PIPETTEX;Initial Catalog=openemr;User ID=sa;Password=123456;Integrated Security=true";
//            SqlConnection con = new SqlConnection(connectionstring);

//            SqlCommand command = new SqlCommand("select * From persons", con);

//            DataTable dt = new DataTable();

//            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
//            dataAdapter.Fill(dt);

//            //for(int i=0;i<dt.Rows.Count;i++)
//            //{
//            //    for(int j=0;j<dt.Columns.Count;j++)
//            //    {
//            //        Console.WriteLine(dt.Rows[i][j]);
//            //    }
//            //}
            
//            foreach(DataRow row in dt.Rows)
//            {
//                Console.WriteLine(row[0]);
//                Console.WriteLine(row[1]);
//                Console.WriteLine(row["age"]);
//            }
            

//            //Console.WriteLine(dt.Rows.Count);
//            //Console.WriteLine(dt.Columns.Count);

//        }

//        [Test]
//        public void ExcelRead()
//        {
//            XLWorkbook book = new XLWorkbook(@"D:\B-Mine\Company\Company\Unitedlex\WebAutomationFramework\OpenEmrAutomation\TestData\OpenEmrData.xlsx");
//            var sheet = book.Worksheet("InvalidCredentialTestData");
//            var range = sheet.RangeUsed();
//            int rowCount = range.RowCount(); //5
//            int colCount = range.ColumnCount(); //4
//            Console.WriteLine(rowCount);
//            Console.WriteLine(colCount);
//            object[] main = new object[rowCount - 1]; //number of test case
//            for (int r = 2;r<= rowCount;r++)
//            {
//                object[] temp = new object[colCount]; //number of parameter
//                for(int c=1;c<=colCount;c++)
//                {
//                    string cellValue = range.Cell(r, c).GetString();
//                    Console.WriteLine(cellValue);
//                    temp[c-1] = cellValue;
//                }

//                main[r-2] = temp;
//            }

//            book.Dispose();
//        }

//        //bala
//        //john
//        //peter
//        //public static object[] jj()
//        //{
//        //    object[] main = new object[3];
//        //    main[0] = "bala";
//        //    main[1] = "john";
//        //    main[2] = "kkk";
//        //    return main;
//        //}

//        //[Test,TestCaseSource("jj")]
//        //public void TestMethod(string name)
//        //{

//        //}
        

//        //john,john123 --> one object[] --> 0 
//        //peter, peter123 --> one object[] --> 1 
//        //mark,mark123
//        //public static object[] jj()
//        //{
//        //    object[] temp1 = new object[2]; //number of parameter
//        //    temp1[0] = "john";
//        //    temp1[1] = "john123";

//        //    object[] temp2 = new object[2];
//        //    temp2[0] = "peter";
//        //    temp2[1] = "peter123";

//        //    object[] temp3 = new object[2];
//        //    temp3[0] = "mark";
//        //    temp3[1] = "mark123";

//        //    object[] main = new object[3]; //number of test case
//        //    main[0] = temp1;
//        //    main[1] = temp2;
//        //    main[2] = temp3;

//        //    return main;
//        //}

//        //[Test, TestCaseSource("jj")]
//        //public void TestMethod(string username,string password)
//        //{
//        //    Console.WriteLine(username+password);
//        //}
//    }
//}
