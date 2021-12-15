相关知识点介绍
1 SqlDataAdapter.
	The SqlDataAdapter, serves as a bridge between a DataSet and SQL Server for retrieving and saving data. 
	The SqlDataAdapter provides this bridge by mapping Fill, which changes the data in the DataSet to match the data in the data source, 
	and Update, which changes the data in the data source to match the data in the DataSet, using the appropriate Transact-SQL statements against the data source.

	When the SqlDataAdapter fills a DataSet, it creates the necessary tables and columns for the returned data if they do not already exist. 
	However, primary key information is not included in the implicitly created schema unless the MissingSchemaAction property is set to AddWithKey. You may also have the SqlDataAdapter create the schema of the DataSet, including primary key information, before filling it with data using FillSchema. For more information, see Adding Existing Constraints to a DataSet.

	SqlDataAdapter is used in conjunction with SqlConnection and SqlCommand to increase performance when connecting to a SQL Server database.

	The SqlDataAdapter also includes the SelectCommand, InsertCommand, DeleteCommand, UpdateCommand, and TableMappings properties to facilitate the loading and updating of data.

	When an instance of SqlDataAdapter is created, the read/write properties are set to initial values. For a list of these values, see the SqlDataAdapter constructor.
