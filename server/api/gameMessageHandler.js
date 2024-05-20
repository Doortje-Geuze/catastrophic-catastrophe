const MessageHandler = require('./messageHandler.js');
class GameMessageHandler extends MessageHandler {

	constructor(io, socketConnectionListener) {
		super(io, socketConnectionListener);
	}

	handleIncomingMessages(socket) {
		this.#handleIncomingStartGameMessages(socket);
		this.#handleIncomingCreatePieceMessages(socket);
		this.#handleIncomingMovePieceMessages(socket);
	}

	#handleIncomingStartGameMessages(socket) {
		socket.on('end game', async (data) => {

			//send a message to all players that the game has started.
			//the client in the specific room can then start the game.
			//other clients can remove the game from the list of active games.
			this._io.emit('end game', data);
			const response = await this._socketConnectionListener.executePreparedQuery("INSERT INTO `match` (TotalWavesSurvived, KilledBy, Kills, HealthLeft) VALUES (?, ?, ?, ?)", [6, 'bullet', 6, 6]);
			console.log(response);
		});
	}

	#handleIncomingCreatePieceMessages(socket) {
		socket.on('create piece', (data) => {
			// Data contains all information needed to construct
			// a new piece on the board:
			// type, status effects, side, position
			this._io.emit('create piece', data);
		});
	}

	#handleIncomingMovePieceMessages(socket) {
		socket.on('move piece', (data) => {
			// Data contains all information needed to
			// move a piece on the board:
			// pieceId, old position, new position
			this._io.emit('move piece', data);
		});
	}
}

module.exports = GameMessageHandler;
