const mySql = require("mysql2/promise");

class MySqlDatabase {
	#pool;

	async initializeDatabase() {
		await this.#createPool();
	}

	async #createPool() {
		const serverConfig = global.serverConfig;
		this.#pool = mySql.createPool({
			host: serverConfig.database.host,
			port: serverConfig.database.port,
			user: serverConfig.database.username,
			password: serverConfig.database.password,
			database: serverConfig.database.database,
			connectionLimit: serverConfig.database.connectionLimit,
			timezone: "UTC",
			multipleStatements: true,
			waitForConnections: true
		});
		console.log('connection established');
	}

	async executePreparedQuery(query, parameters) {
		let connection;
		try	{
			connection = await this.#pool.getConnection();
			const [rows, fields] = await connection.execute(query, parameters);
			return {
				rows: rows,
				fields: fields
			};
		} catch (err) {
			console.log(`An error occurred while executing prepared query: ${err.code} (${err.errno}): ${err.message}`);
		} finally {
			if (connection) connection.release();
		}
	};
}

module.exports = MySqlDatabase;