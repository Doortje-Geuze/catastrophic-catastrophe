const mySql = require("mysql2/promise");

class MySqlDatabase {

	#connection;

	async initializeDatabase() {
		await this.#createConnection();
	}

	async #createConnection() {
		const serverConfig = global.serverConfig;
		this.#connection = await mySql.createConnection({
			host: serverConfig.database.host,
			port: serverConfig.database.port,
			user: serverConfig.database.username,
			password: serverConfig.database.password,
			database: serverConfig.database.database,
			connectionLimit: serverConfig.database.connectionLimit,
			timezone: "UTC",
			multipleStatements: true
		});
		console.log('connection established');
	}

	async executePreparedQuery(query, parameters) {
		try	{
			const [rows, fields] = await this.#connection.execute(query, parameters);
			return {
				rows: rows,
				fields: fields
			};
		} catch (err) {
			console.log(`An error occurred while executing prepared query: ${err.code} (${err.errno}): ${err.message}`);
		}
	};
}

module.exports = MySqlDatabase;