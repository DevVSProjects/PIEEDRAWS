using System;
using System.Data;
using System.Data.SqlClient;

namespace Conexion
{
	/// <summary>
	/// Application block para acceso a  SQL Server
	/// </summary>
public   class SqlHelperPlus
	{
		#region Class Definition
		private SqlHelperPlus()
		{
		}
		#endregion
		#region Method ExecuteNonQuery
		/// <summary>
		/// 
		/// </summary>
		/// <param name="connectionString"></param>
		/// <param name="commandText"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		static public int ExecuteNonQuery(string connectionString, string commandText, params SqlParameter[] parameters)
		{
			return ExecuteNonQuery(connectionString, commandText, CommandType.Text, parameters);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="connectionString"></param>
		/// <param name="commandText"></param>
		/// <param name="type"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		static public int ExecuteNonQuery(string connectionString, string commandText, CommandType type, params SqlParameter[] parameters)
		{
			using(SqlConnection connection = new SqlConnection(connectionString))
			{
				return ExecuteNonQuery(connection, commandText, type, parameters);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="commandText"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		static public int ExecuteNonQuery(SqlConnection connection, string commandText,  params SqlParameter[] parameters)
		{
			return ExecuteNonQuery(connection, commandText, CommandType.Text, parameters);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="commandText"></param>
		/// <param name="type"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		static public int ExecuteNonQuery(SqlConnection connection, string commandText, CommandType type, params SqlParameter[] parameters)
		{
			try
			{
				OpenConnection(connection);
				SqlCommand command = CreateCommand(connection, commandText, type, parameters);
				return command.ExecuteNonQuery();
			}
			finally
			{
				connection.Close();
				
			}
		}
		#endregion
		#region Method ExecuteSqlScalar
		/// <summary>
		/// 
		/// </summary>
		/// <param name="connectionString"></param>
		/// <param name="commandText"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		static public object ExecuteSqlScalar(string connectionString, string commandText, params SqlParameter[] parameters)
		{
			return ExecuteSqlScalar(connectionString, commandText, CommandType.Text, parameters);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="connectionString"></param>
		/// <param name="commandText"></param>
		/// <param name="type"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		static public object ExecuteSqlScalar(string connectionString, string commandText, CommandType type, params SqlParameter[] parameters)
		{
			using(SqlConnection connection = new SqlConnection(connectionString))
			{
				return ExecuteSqlScalar(connection, commandText, type, parameters);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="commandText"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		static public object ExecuteSqlScalar(SqlConnection connection, string commandText,  params SqlParameter[] parameters)
		{
			return ExecuteSqlScalar(connection, commandText, CommandType.Text, parameters);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="commandText"></param>
		/// <param name="type"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		static public object ExecuteSqlScalar(SqlConnection connection, string commandText, CommandType type, params SqlParameter[] parameters)
		{
			try
			{
				OpenConnection(connection);
				SqlCommand command = CreateCommand(connection, commandText, type, parameters);
				return command.ExecuteScalar();
			}
			finally
			{
				connection.Close();
				connection.Dispose();
			}
		}
		#endregion
		#region Method ExecuteDataReader
		/// <summary>
		/// 
		/// </summary>
		/// <param name="connectionString"></param>
		/// <param name="commandText"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		static public SqlDataReader ExecuteDataReader(string connectionString, string commandText, params SqlParameter[] parameters)
		{
			return ExecuteDataReader(connectionString, commandText, CommandType.Text,  parameters);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="connectionString"></param>
		/// <param name="commandText"></param>
		/// <param name="type"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		static public SqlDataReader ExecuteDataReader(string connectionString, string commandText, CommandType type, params SqlParameter[] parameters)
		{
			using(SqlConnection connection = new SqlConnection(connectionString))
			{
				return ExecuteDataReader(connection, commandText, type, CommandBehavior.CloseConnection, parameters);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="commandText"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		static public SqlDataReader ExecuteDataReader(SqlConnection connection, string commandText,  params SqlParameter[] parameters)
		{
			return ExecuteDataReader(connection, commandText, CommandType.Text, CommandBehavior.CloseConnection, parameters);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="commandText"></param>
		/// <param name="commandBehavior"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		static public SqlDataReader ExecuteDataReader(SqlConnection connection, string commandText, CommandBehavior commandBehavior,  params SqlParameter[] parameters)
		{
			return ExecuteDataReader(connection, commandText, CommandType.Text, commandBehavior, parameters);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="commandText"></param>
		/// <param name="type"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		static public SqlDataReader ExecuteDataReader(SqlConnection connection, string commandText, CommandType type, params SqlParameter[] parameters)
		{
			return ExecuteDataReader(connection, commandText, type, CommandBehavior.CloseConnection, parameters);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="commandText"></param>
		/// <param name="type"></param>
		/// <param name="commandBehavior"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		static public SqlDataReader ExecuteDataReader(SqlConnection connection, string commandText, CommandType type, CommandBehavior commandBehavior, params SqlParameter[] parameters)
		{
			try
			{
				OpenConnection(connection);
				SqlCommand command = CreateCommand(connection, commandText, type, parameters);
				return command.ExecuteReader(commandBehavior);
			}
			finally
			{
				connection.Close();
				connection.Dispose();
			}
		}
		#endregion
		#region Method ExecuteDataSet
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dataSet"></param>
		/// <param name="table"></param>
		/// <param name="connectionString"></param>
		/// <param name="commandText"></param>
		/// <param name="parameters"></param>
		static public void ExecuteDataSet(DataSet dataSet, string table, string connectionString, string commandText, params SqlParameter[] parameters)
		{
			ExecuteDataSet(dataSet, table, connectionString, commandText, CommandType.Text, parameters);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dataTable"></param>
		/// <param name="connectionString"></param>
		/// <param name="commandText"></param>
		/// <param name="parameters"></param>
		static public void ExecuteDataSet(DataTable dataTable, string connectionString, string commandText, params SqlParameter[] parameters)
		{
			ExecuteDataSet(dataTable, connectionString, commandText, CommandType.Text, parameters);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dataSet"></param>
		/// <param name="table"></param>
		/// <param name="connectionString"></param>
		/// <param name="commandText"></param>
		/// <param name="type"></param>
		/// <param name="parameters"></param>
		static public void ExecuteDataSet(DataSet dataSet, string table, string connectionString, string commandText, CommandType type, params SqlParameter[] parameters)
		{
			DataTable dataTable = new DataTable(table);
			dataSet.Tables.Add(dataTable);
				ExecuteDataSet(dataTable, connectionString, commandText, type, parameters);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="table"></param>
		/// <param name="connectionString"></param>
		/// <param name="commandText"></param>
		/// <param name="type"></param>
		/// <param name="parameters"></param>
		static public void ExecuteDataSet(DataTable table, string connectionString, string commandText, CommandType type, params SqlParameter[] parameters)
		{
			using(SqlConnection connection = new SqlConnection(connectionString))
			{
				ExecuteDataSet(table, connection, commandText, type, parameters);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dataSet"></param>
		/// <param name="table"></param>
		/// <param name="connection"></param>
		/// <param name="commandText"></param>
		/// <param name="parameters"></param>
		static public void ExecuteDataSet(DataSet dataSet, string table, SqlConnection connection, string commandText,  params SqlParameter[] parameters)
		{
			ExecuteDataSet(dataSet, table, connection, commandText, CommandType.Text, parameters);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="table"></param>
		/// <param name="connection"></param>
		/// <param name="commandText"></param>
		/// <param name="parameters"></param>
		static public void ExecuteDataSet(DataTable table, SqlConnection connection, string commandText,  params SqlParameter[] parameters)
		{
			ExecuteDataSet(table, connection, commandText, CommandType.Text, parameters);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dataSet"></param>
		/// <param name="table"></param>
		/// <param name="connection"></param>
		/// <param name="commandText"></param>
		/// <param name="type"></param>
		/// <param name="parameters"></param>
		static public void ExecuteDataSet(DataSet dataSet, string table, SqlConnection connection, string commandText, CommandType type, params SqlParameter[] parameters)
		{
			DataTable dataTable = new DataTable(table);
			dataSet.Tables.Add(dataTable);
			ExecuteDataSet(dataTable, connection, commandText, type, parameters);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="table"></param>
		/// <param name="connection"></param>
		/// <param name="commandText"></param>
		/// <param name="type"></param>
		/// <param name="parameters"></param>
		static public void ExecuteDataSet(DataTable table, SqlConnection connection, string commandText, CommandType type, params SqlParameter[] parameters)
		{
			SqlDataAdapter adapter = new SqlDataAdapter(
				CreateCommand(connection, commandText, type, parameters));
			adapter.Fill(table);
		}
		

	/// <summary>
	/// Execute a SqlCommand (that returns a resultset) against the specified SqlConnection 
	/// using the provided parameters.
	/// </summary>
	/// <remarks>
	/// e.g.:  
	///  DataSet ds = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24));
	/// </remarks>
	/// <param name="connection">a valid SqlConnection</param>
	/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
	/// <param name="commandText">the stored procedure name or T-SQL command</param>
	/// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
	/// <returns>a dataset containing the resultset generated by the command</returns>
	public static DataSet ExecuteDatasetPlus(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
	{
		//create a command and prepare it for execution
		try
		{
			SqlCommand cmd = new SqlCommand();
			PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);
            cmd.CommandTimeout = 1200;
			//create the DataAdapter & DataSet
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();

			//fill the DataSet using default values for DataTable names, etc.
			da.Fill(ds);
			
			// detach the SqlParameters from the command object, so they can be used again.			
			cmd.Parameters.Clear();
			//return the dataset
			return ds;				
		}
		finally
		{
			if (connection.State == ConnectionState.Open)
			{
			connection.Close();
			
			}
		}
	}
	#endregion

	#region  PrepareCommand
	/// <summary>
	/// This method opens (if necessary) and assigns a connection, transaction, command type and parameters 
	/// to the provided command.
	/// </summary>
	/// <param name="command">the SqlCommand to be prepared</param>
	/// <param name="connection">a valid SqlConnection, on which to execute this command</param>
	/// <param name="transaction">a valid SqlTransaction, or 'null'</param>
	/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
	/// <param name="commandText">the stored procedure name or T-SQL command</param>
	/// <param name="commandParameters">an array of SqlParameters to be associated with the command or 'null' if no parameters are required</param>
	private static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters)
	{
		//if the provided connection is not open, we will open it
		if (connection.State != ConnectionState.Open)
		{
			connection.Open();
		}

		//associate the connection with the command
		command.Connection = connection;

		//set the command text (stored procedure name or SQL statement)
		command.CommandText = commandText;

		//if we were provided a transaction, assign it.
		if (transaction != null)
		{
			command.Transaction = transaction;
		}

		//set the command type
		command.CommandType = commandType;

		//attach the command parameters if they are provided
		if (commandParameters != null)
		{
			AttachParameters(command, commandParameters);
		}

		return;
	}
#endregion


	     #region AttachParameters
	/// <summary>
	/// This method is used to attach array of SqlParameters to a SqlCommand.
	/// 
	/// This method will assign a value of DbNull to any parameter with a direction of
	/// InputOutput and a value of null.  
	/// 
	/// This behavior will prevent default values from being used, but
	/// this will be the less common case than an intended pure output parameter (derived as InputOutput)
	/// where the user provided no input value.
	/// </summary>
	/// <param name="command">The command to which the parameters will be added</param>
	/// <param name="commandParameters">an array of SqlParameters tho be added to command</param>
	private static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
	{
		foreach (SqlParameter p in commandParameters)
		{
			//check for derived output value with no value assigned
			if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
			{
				p.Value = DBNull.Value;
			}
				
			command.Parameters.Add(p);
		}
	}
	#endregion
		#region Method CreateTransaction
		/// <summary>
		/// 
		/// </summary>
		/// <param name="connectionString"></param>
		/// <returns></returns>
		static public SqlTransaction CreateTransaction(string connectionString)
		{
			SqlConnection connection = new SqlConnection(connectionString);
			OpenConnection(connection);
			return connection.BeginTransaction();
		}
		#endregion
		#region Method CreateParameter
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		static public SqlParameter CreateParameter(string name, object value)
		{
			return new SqlParameter(name, value);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		static public SqlParameter CreateParameter(string name, SqlDbType type)
		{
			return new SqlParameter(name, type);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		static public SqlParameter CreateParameter(string name, object value, SqlDbType type)
		{
			SqlParameter parameter = CreateParameter(name, type);
			parameter.Value = value;
			return parameter;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="type"></param>
		/// <param name="size"></param>
		/// <returns></returns>
		static public SqlParameter CreateParameter(string name, SqlDbType type, int size)
		{
			SqlParameter parameter = CreateParameter(name, type);
			parameter.Size = size;
			return parameter;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		/// <param name="type"></param>
		/// <param name="size"></param>
		/// <returns></returns>
		static public SqlParameter CreateParameter(string name, object value, SqlDbType type, int size)
		{
			SqlParameter parameter = CreateParameter(name, type, size);
			parameter.Value = value;
			return parameter;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="type"></param>
		/// <param name="sourceColumn"></param>
		/// <returns></returns>
		static public SqlParameter CreateParameter(string name, SqlDbType type, string sourceColumn)
		{
			SqlParameter parameter = CreateParameter(name, type);
			parameter.SourceColumn = sourceColumn;
			return parameter;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="type"></param>
		/// <param name="size"></param>
		/// <param name="sourceColumn"></param>
		/// <returns></returns>
		static public SqlParameter CreateParameter(string name, SqlDbType type, int size, string sourceColumn)
		{
			SqlParameter parameter = CreateParameter(name, type, size);
			parameter.SourceColumn = sourceColumn;
			return parameter;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="type"></param>
		/// <param name="direction"></param>
		/// <returns></returns>
		static public SqlParameter CreateParameter(string name, SqlDbType type, ParameterDirection direction)
		{
			SqlParameter parameter = CreateParameter(name, type);
			parameter.Direction = direction;
			return parameter;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		/// <param name="type"></param>
		/// <param name="direction"></param>
		/// <returns></returns>
		static public SqlParameter CreateParameter(string name, object value, SqlDbType type, ParameterDirection direction)
		{
			SqlParameter parameter = CreateParameter(name, type, direction);
			parameter.Value = value;
			return parameter;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="type"></param>
		/// <param name="direction"></param>
		/// <param name="size"></param>
		/// <returns></returns>
		static public SqlParameter CreateParameter(string name, SqlDbType type, ParameterDirection direction, int size)
		{
			SqlParameter parameter = CreateParameter(name, type, direction);
			parameter.Size = size;
			return parameter;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		/// <param name="type"></param>
		/// <param name="direction"></param>
		/// <param name="size"></param>
		/// <returns></returns>
		static public SqlParameter CreateParameter(string name, object value, SqlDbType type, ParameterDirection direction, int size)
		{
			SqlParameter parameter = CreateParameter(name, type, direction, size);
			parameter.Value = value;
			return parameter;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="type"></param>
		/// <param name="direction"></param>
		/// <param name="sourceColumn"></param>
		/// <returns></returns>
		static public SqlParameter CreateParameter(string name, SqlDbType type, ParameterDirection direction, string sourceColumn)
		{
			SqlParameter parameter = CreateParameter(name, type, direction);
			parameter.SourceColumn = sourceColumn;
			return parameter;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="type"></param>
		/// <param name="direction"></param>
		/// <param name="size"></param>
		/// <param name="sourceColumn"></param>
		/// <returns></returns>
		static public SqlParameter CreateParameter(string name, SqlDbType type, ParameterDirection direction, int size, string sourceColumn)
		{
			SqlParameter parameter = CreateParameter(name, type, direction, size);
			parameter.SourceColumn = sourceColumn;
			return parameter;
		}
		#endregion
		#region Utils
		/// <summary>
		/// 
		/// </summary>
		/// <param name="connection"></param>
		static private void OpenConnection(SqlConnection connection)
		{
			if(connection.State == ConnectionState.Closed)
			{
				connection.Open();
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="commandText"></param>
		/// <param name="type"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		static private SqlCommand CreateCommand(SqlConnection connection, string commandText, CommandType type, params SqlParameter[] parameters)
		{
			SqlCommand command = new SqlCommand(commandText, connection);
			command.CommandType = type;
			foreach(SqlParameter parameter in parameters)
			{
				command.Parameters.Add(parameter);
			}
			return command;
		}
		#endregion
	}
}