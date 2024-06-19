using DotNetTrainingBatch4.ConsoleApp;

Console.WriteLine("Hello, World!");

// nuget

//Ctrl + .  = suggestion 
//F10 (line by line)
//F11 (details)
//F9 = breakpoints 

// => C# => Db


// SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();

//   stringBuilder.DataSource = "AERA\\SQLEXPRESS"; //server name
//   stringBuilder.InitialCatalog = "DotNetTrainingBatch4";  //database name
//   stringBuilder.UserID = "sa";
//   stringBuilder.Password = "ingyinkhine@123";

//   SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);

//   connection.Open();
//   Console.WriteLine("Hello");


//   string query = "select* from tbl_blog";
//   SqlCommand cmd = new SqlCommand(query, connection);
//   SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
//   DataTable dt = new DataTable();
//   sqlDataAdapter.Fill(dt);

//   connection.Close();
//   Console.WriteLine("Close");

//dataset => datatable
//datatable => datarow
//datarow => datacolumn

//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine("Blog ID => " + dr["BlogID"]);
//    Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
//    Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
//    Console.WriteLine("Blog Conetnt => " + dr["BlogContent"]);
//    Console.WriteLine("------------------------------------------");
//}



// Ado.Net Read

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read(); 
//adoDotNetExample.Create("author", "title", "content");

//adoDotNetExample.Update(3, "test author", "test title", "test content");
//adoDotNetExample.Delete(3);
//adoDotNetExample.Edit(3);
//adoDotNetExample.Edit(1); 


//IGKDapper igkDapper = new IGKDapper();
//igkDapper.Run();

EFCoreExample eFCoreExample = new EFCoreExample();
eFCoreExample.Run();

Console.ReadKey();






