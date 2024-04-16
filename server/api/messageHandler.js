class MessageHandler {
	_io;
	_rooms = { };
	_socketConnectionListener;

	constructor(io, rooms, socketConnectionListener) {
		this._io = io;
		this._rooms = rooms;
		this._socketConnectionListener = socketConnectionListener;
	}
}

module.exports = MessageHandler;